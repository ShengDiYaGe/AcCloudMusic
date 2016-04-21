using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Ernzo.WinForms.Controls;
using Ernzo.Windows.WaveAudio;
using Ernzo.Windows.DirectShowLib.MMStreaming;
using Ernzo.DSP;
using SoundStudioCS.Properties;
namespace SoundStudioCS
{

    public partial class SoundStudioFrm : Form, IWaveNotifyHandler
    {
        private const int WM_USER = 0x0400;
        private const int WM_AUDIO_DONE = WM_USER + 0x100;
        private const int WM_MIXM_CONTROL_CHANGE = MixerConstants.MM_MIXM_CONTROL_CHANGE;
        private const int MAX_BUFFERS = 4;
        //private const int MAX_BUFSIZE = 2048;
        private const double FFT_SPEED = 0.06;
        private const int NUM_FREQUENCY = 19;
        private int[] METER_FREQUENCY = new int[NUM_FREQUENCY] { 30, 60, 80, 90, 100, 150, 200, 330, 480, 660, 880, 1000, 1500, 2000, 3000, 5000, 8000, 12000, 16000 };
        private int[] _meterData = new int[NUM_FREQUENCY];
        private double[] RealIn;
        private double[] RealOut;
        private double[] ImagOut;
        private double[] AmplOut;
        private byte[] waveData;    // copy of wave data - unless 'unsafe' code is an option
        private WaveFormat _wfmt;
        private WaveBuffer[] _waveBuffer;
        private WaveOutDevice _waveOutput;
        private IntPtr _CopyWindowHandle;
        private MMAudioStream _AudioStream;
        private MultimediaStream _MediaStream;
        private uint _bufferSize;
        private uint _numSamples;
        private int _numOutBuffers;
        private WaveMixerDevice _mixerDevice;
        private IntPtr _mixerDataPtr;
        private int _MuteControlId;
        private int _VolumeControlId;

        public SoundStudioFrm()
        {
            InitializeComponent();
            _numSamples = 0;
            _numOutBuffers = 0;
        }

        private void Terminate()
        {
            ReleaseWaveOutput();
            ReleaseFFTData();
            _CopyWindowHandle = IntPtr.Zero;
            this.btnPlay.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnMute.Enabled = false;
            this.ctlVolume.Enabled = false;
        }
        private void SoundStudioFrm_Load(object sender, EventArgs e)
        {
            this.peakMeterCtrl1.SetRange(40, 70, 100);
            this.peakMeterCtrl1.Start(33);
            this.btnPlay.Enabled = true;
            this.btnStop.Enabled = false;
            this.btnMute.Enabled = false;
            this.ctlVolume.Enabled = false;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            Terminate();
            base.OnHandleDestroyed(e);
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openDialog.FileName;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (_waveOutput == null)
            {
                CreateWaveOutput();
            }
            if (!_waveOutput.IsOpen())
            {
                _CopyWindowHandle = this.Handle;
                try
                {
                    // NOTE: Since our main thread belongs to a Single-thread apartment
                    // make sure this object is accessed from the same thread
                    // create multimedia stream object
                    IMediaStream pAudioStream = null;
                    _MediaStream = new MultimediaStream();
                    int mmr = _MediaStream.Initialize(STREAM_TYPE.STREAMTYPE_READ, (int)AMMSF_INIT.AMMSF_NOGRAPHTHREAD, null);
                    mmr = _MediaStream.AddMediaStream(null, MSPurposeId.PrimaryAudio, 0, out pAudioStream);
                    MSStatus.ThrowExceptionForHR(mmr);

                    // open media file
                    mmr = _MediaStream.OpenFile(this.txtFilePath.Text, (int)AMMSF_OPEN.AMMSF_RUN);
                    MSStatus.ThrowExceptionForHR(mmr);

                    _AudioStream = new MMAudioStream();
                    mmr = _AudioStream.SetMediaStream(pAudioStream);
                    MSStatus.ThrowExceptionForHR(mmr);

                    _wfmt = new WaveFormat(_AudioStream.Format);
                    mmr = _waveOutput.Open(WaveConstants.WAVE_MAPPER, _wfmt);
                    WaveOutStatus.ThrowExceptionForHR(mmr);

                    // calculate required buffer
                    _bufferSize = (uint)FFT.NextPowerOfTwo((uint)(_wfmt.BytesPerSecond * FFT_SPEED));
                    CreateBuffers();
                    AllocFFTData();
                    _numSamples = 0;
                    _numOutBuffers = 0;
                    for (int index = 0; index < MAX_BUFFERS; ++index)
                    {
                        WaveBuffer curBuffer = _waveBuffer[index];
                        int dwSize = curBuffer.BufferLength;
                        mmr = _AudioStream.GetSampleData(curBuffer.AudioData, ref dwSize, (int)COMPLETION_STATUS_FLAGS.COMPSTAT_WAIT, System.Threading.Timeout.Infinite);
                        MSStatus.ThrowExceptionForHR(mmr);
                        if (dwSize > 0)
                        {
                            mmr = _waveOutput.PrepareBuffer(curBuffer);
                            mmr = _waveOutput.AddBuffer(curBuffer);
                            WaveOutStatus.ThrowExceptionForHR(mmr);
                            Interlocked.Increment(ref _numOutBuffers);
                            if (index == 0)
                            {
                                mmr = _waveOutput.Start();
                                WaveOutStatus.ThrowExceptionForHR(mmr);
                            }
                        }
                    }
                    // setup mixer
                    CreateMixerDevice();
                    mmr = SetupMixer();
                    WaveOutStatus.ThrowExceptionForHR(mmr);
                    btnPlay.Enabled = false;
                    btnStop.Enabled = true;
                    btnMute.Enabled = true;
                    ctlVolume.Enabled = true;
                }
                catch (Exception ex) // typically: COMException, SystemException (waveout)
                {
                    DumpDebugMessage(ex.Message);
                    Terminate();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Terminate();
        }

        private void btnMute_CheckedChanged(object sender, EventArgs e)
        {
            if (_mixerDevice != null && _mixerDevice.IsOpen())
            {
                MixerControlDetails mxcd = new MixerControlDetails();
                tMIXERCONTROLDETAILS_BOOLEAN mxMute;

                mxMute.fValue = this.btnMute.Checked ? 1 : 0;
                Marshal.WriteInt32(_mixerDataPtr, mxMute.fValue);
                mxcd.ControlID = _MuteControlId;
                mxcd.NumChannels = 1;
                mxcd.MultipleItems = 0;
                mxcd.CbDetails = (int)Marshal.SizeOf(typeof(tMIXERCONTROLDETAILS_BOOLEAN));
                mxcd.DataArray = _mixerDataPtr;
                int hr = _mixerDevice.SetControlDetails(ref mxcd, MixerConstants.MIXER_SETCONTROLDETAILSF_VALUE);
            }
        }

        private void ctlVolume_ValueChanged(object sender, EventArgs e)
        {
            if (_mixerDevice != null && _mixerDevice.IsOpen())
            {
                MixerControlDetails mxcd = new MixerControlDetails();
                tMIXERCONTROLDETAILS_SIGNED mxVolume;

                mxVolume.lValue = this.ctlVolume.Value;
                Marshal.WriteInt32(_mixerDataPtr, mxVolume.lValue);
                mxcd.ControlID = _VolumeControlId;
                mxcd.NumChannels = 1;
                mxcd.MultipleItems = 0;
                mxcd.CbDetails = (int)Marshal.SizeOf(typeof(tMIXERCONTROLDETAILS_SIGNED));
                mxcd.DataArray = _mixerDataPtr;
                int hr = _mixerDevice.SetControlDetails(ref mxcd, MixerConstants.MIXER_SETCONTROLDETAILSF_VALUE);
            }
        }

        int SetupMixer()
        {
            int mmr = _mixerDevice.Open((int)_waveOutput.GetId(), WaveConstants.CALLBACK_WINDOW | MixerConstants.MIXER_OBJECTF_HWAVEOUT, this.Handle);
            if (mmr == WaveConstants.MMSYSERR_NOERROR)
            {
                MixerLineInfo mxli = new MixerLineInfo();
                MixerLineControls mxlcs = new MixerLineControls();
                MixerCaps mxcaps = new MixerCaps();
                MixerControlDetails mxcd = new MixerControlDetails();
                _mixerDataPtr = Marshal.AllocHGlobal(256);
                mmr = _mixerDevice.GetDeviceCaps(ref mxcaps);
                if (mmr == WaveConstants.MMSYSERR_NOERROR)
                {
                    DumpDebugMessage(string.Format("Mixer Caps: {0}, Ver:0x{1:x} (0x{2:x})", mxcaps.ProductName, mxcaps.Version, mxcaps.SupportFlag));
                }
                mxli.ComponentType = MixerConstants.MIXERLINE_COMPONENTTYPE_DST_SPEAKERS;
                mmr = _mixerDevice.GetLineInfo(ref mxli, MixerConstants.MIXER_GETLINEINFOF_COMPONENTTYPE);
                if (mmr == WaveConstants.MMSYSERR_NOERROR)
                {
                    tMIXERCONTROLW mxc;
                    Marshal.WriteInt32(_mixerDataPtr, (int)Marshal.OffsetOf(typeof(tMIXERCONTROLW), "cbStruct"), (int)Marshal.SizeOf(typeof(tMIXERCONTROLW)));
                    mxlcs.LineID = mxli.LineID;
                    mxlcs.NumControls = 1;
                    mxlcs.ControlType = MixerConstants.MIXERCONTROL_CONTROLTYPE_MUTE;
                    mxlcs.CbControl = (int)Marshal.SizeOf(typeof(tMIXERCONTROLW));
                    mxlcs.DataArray = _mixerDataPtr;
                    mmr = _mixerDevice.GetLineControls(ref mxlcs, MixerConstants.MIXER_GETLINECONTROLSF_ONEBYTYPE);
                    if (mmr == WaveConstants.MMSYSERR_NOERROR)
                    {
                        tMIXERCONTROLDETAILS_BOOLEAN mxMute;
                        mxc = (tMIXERCONTROLW)Marshal.PtrToStructure(_mixerDataPtr, typeof(tMIXERCONTROLW));
                        _MuteControlId = mxc.dwControlID;
                        DumpDebugMessage(string.Format("Mute control: {0}", mxc.dwControlID));

                        mxcd.ControlID = _MuteControlId;
                        mxcd.NumChannels = 1;
                        mxcd.MultipleItems = 0;
                        mxcd.CbDetails = (int)Marshal.SizeOf(typeof(tMIXERCONTROLDETAILS_BOOLEAN));
                        mxcd.DataArray = _mixerDataPtr;
                        mmr = _mixerDevice.GetControlDetails(ref mxcd, MixerConstants.MIXER_GETCONTROLDETAILSF_VALUE);
                        if (mmr == WaveConstants.MMSYSERR_NOERROR)
                        {
                            mxMute = (tMIXERCONTROLDETAILS_BOOLEAN)Marshal.PtrToStructure(_mixerDataPtr, typeof(tMIXERCONTROLDETAILS_BOOLEAN));
                            this.btnMute.Checked = (mxMute.fValue != 0);
                        }
                    }

                    mxlcs.LineID = mxli.LineID;
                    mxlcs.NumControls = 1;
                    mxlcs.ControlType = MixerConstants.MIXERCONTROL_CONTROLTYPE_VOLUME;
                    mxlcs.CbControl = (int)Marshal.SizeOf(typeof(tMIXERCONTROLW));
                    mxlcs.DataArray = _mixerDataPtr;
                    Marshal.WriteInt32(_mixerDataPtr, (int)Marshal.OffsetOf(typeof(tMIXERCONTROLW), "cbStruct"), (int)Marshal.SizeOf(typeof(tMIXERCONTROLW)));
                    mmr = _mixerDevice.GetLineControls(ref mxlcs, MixerConstants.MIXER_GETLINECONTROLSF_ONEBYTYPE);
                    if (mmr == WaveConstants.MMSYSERR_NOERROR)
                    {
                        tMIXERCONTROLDETAILS_SIGNED mxVolume;
                        mxc = (tMIXERCONTROLW)Marshal.PtrToStructure(_mixerDataPtr, typeof(tMIXERCONTROLW));
                        _VolumeControlId = mxc.dwControlID;
                        DumpDebugMessage(string.Format("Volume control: {0}", mxc.dwControlID));

                        mxcd.ControlID = _VolumeControlId;
                        mxcd.NumChannels = 1;
                        mxcd.MultipleItems = 0;
                        mxcd.CbDetails = (int)Marshal.SizeOf(typeof(tMIXERCONTROLDETAILS_SIGNED));
                        mxcd.DataArray = _mixerDataPtr;
                        mmr = _mixerDevice.GetControlDetails(ref mxcd, MixerConstants.MIXER_GETCONTROLDETAILSF_VALUE);
                        if (mmr == WaveConstants.MMSYSERR_NOERROR)
                        {
                            mxVolume = (tMIXERCONTROLDETAILS_SIGNED)Marshal.PtrToStructure(_mixerDataPtr, typeof(tMIXERCONTROLDETAILS_SIGNED));
                            this.ctlVolume.SetRange(mxc.Bounds.Signed.lMinimum, mxc.Bounds.Signed.lMaximum);
                            this.ctlVolume.TickFrequency = ((mxc.Bounds.Signed.lMaximum-mxc.Bounds.Signed.lMinimum) / 10);
                            this.ctlVolume.Value = (int)((ushort)mxVolume.lValue);
                        }
                    }
                }
            }
            return mmr;
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                // Process audio done message
                case WM_AUDIO_DONE:
                {
                    GCHandle gch = (GCHandle)(m.LParam);
                    WaveBuffer wbuf = gch.Target as WaveBuffer;
                    if (wbuf != null && _waveOutput != null)
                    {
                        try
                        {
                            int mmr = _waveOutput.UnprepareBuffer(wbuf);
                            WaveOutStatus.ThrowExceptionForHR(mmr);
                            Interlocked.Decrement(ref _numOutBuffers);

                            WaveStatus status = _waveOutput.GetDeviceStatus();
                            if (status == WaveStatus.waveStarted)
                            {
                                ProcessAudioData(wbuf);
                            }
                        }
                        catch (Exception ex) // typically: COMException, SystemException (waveout)
                        {
                            DumpDebugMessage(ex.Message);
                        }
                    }
                    else
                    {
                        DumpDebugMessage("WM_AUDIO_DONE - AUDIO STOPPED");
                    }
                    if (gch.IsAllocated)
                    {
                        gch.Free();
                    }
                    return;
                }
                case WM_MIXM_CONTROL_CHANGE: // MixerConstants.MM_MIXM_CONTROL_CHANGE
                {
                    if (_mixerDevice != null && _mixerDevice.IsOpen())
                    {
                        MixerControlDetails mxcd = new MixerControlDetails();
                        mxcd.ControlID = (int)(m.LParam);
                        mxcd.NumChannels = 1;
                        int hr = MSStatus.MS_S_FALSE;
                        if (mxcd.ControlID == _MuteControlId)
                        {
                            mxcd.CbDetails = (int)Marshal.SizeOf(typeof(tMIXERCONTROLDETAILS_BOOLEAN));
                            mxcd.DataArray = _mixerDataPtr;
                            hr = MSStatus.MS_S_OK;
                        }
                        else if (mxcd.ControlID == _VolumeControlId)
                        {
                            mxcd.CbDetails = (int)Marshal.SizeOf(typeof(tMIXERCONTROLDETAILS_SIGNED));
                            mxcd.DataArray = _mixerDataPtr;
                            hr = MSStatus.MS_S_OK;
                        }
                        if (hr == MSStatus.MS_S_OK)
                        {
                            hr = _mixerDevice.GetControlDetails(ref mxcd, MixerConstants.MIXER_GETCONTROLDETAILSF_VALUE);
                            if (mxcd.ControlID == _MuteControlId)
                            {
                                tMIXERCONTROLDETAILS_BOOLEAN mxMute;
                                mxMute = (tMIXERCONTROLDETAILS_BOOLEAN)Marshal.PtrToStructure(_mixerDataPtr, typeof(tMIXERCONTROLDETAILS_BOOLEAN));
                                this.btnMute.Checked = (mxMute.fValue != 0);
                                if (this.btnMute.Checked)
                                {
                                    this.btnMute.Image = Resources.sound_mute;
                                }
                                else
                                {
                                    this.btnMute.Image = Resources.sound;
                                }
                            }
                            else if (mxcd.ControlID == _VolumeControlId)
                            {
                                tMIXERCONTROLDETAILS_SIGNED mxVolume;
                                mxVolume = (tMIXERCONTROLDETAILS_SIGNED)Marshal.PtrToStructure(_mixerDataPtr, typeof(tMIXERCONTROLDETAILS_SIGNED));
                                this.ctlVolume.Value = mxVolume.lValue;
                            }
                        }
                    }
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private delegate void WndProcCallback(ref Message m);
        public void ProcessEvent(IWaveDevice waveDevice, int uMsg, WaveBuffer wbuf)
        {
            if (waveDevice == _waveOutput)
            {
                switch (uMsg)
                {
                    case WaveConstants.MM_WOM_OPEN:
                        DumpDebugMessage("Wave Opened");
                        break;
                    case WaveConstants.MM_WOM_DONE:
                        {
                            GCHandle gch = GCHandle.Alloc(wbuf);
                            // Create message
                            if (this.IsHandleCreated)
                            {
                                Message m = Message.Create(_CopyWindowHandle, WM_AUDIO_DONE, IntPtr.Zero, (IntPtr)gch);
                                WndProcCallback wndCallback = new WndProcCallback(WndProc);
                                // Ensure all calls will be thread-safe
                                this.BeginInvoke(wndCallback, m);
                            }
                        }
                        break;
                    case WaveConstants.MM_WOM_CLOSE:
                        DumpDebugMessage("Wave Closed");
                        break;
                }
            }
        }

        private void ProcessAudioData(WaveBuffer wbuf)
        {
            try
            {
                if (_waveOutput.GetDeviceStatus() == WaveStatus.waveStarted)
                {
                    ComputeFFT(wbuf);
                }

                int chunkSize = wbuf.BufferLength;
                int mmr = _AudioStream.GetSampleData(wbuf.AudioData, ref chunkSize, (int)COMPLETION_STATUS_FLAGS.COMPSTAT_WAIT, System.Threading.Timeout.Infinite);
                MSStatus.ThrowExceptionForHR(mmr);
                if (mmr == MSStatus.MS_S_OK)
                {
                    // Append silence if necessary
                    PutAudioData(wbuf.AudioData, wbuf.BufferLength, chunkSize, _wfmt);
                    mmr = _waveOutput.PrepareBuffer(wbuf);
                    WaveOutStatus.ThrowExceptionForHR(mmr);

                    mmr = _waveOutput.AddBuffer(wbuf);
                    WaveOutStatus.ThrowExceptionForHR(mmr);
                    Interlocked.Increment(ref _numOutBuffers);
                }
                else if (_numOutBuffers == 0) // all buffers done
                {
                    // stop
                    Terminate();
                }
            }
            catch (Exception ex) // typically: COMException, SystemException (waveout)
            {
                DumpDebugMessage(ex.Message);
            }
        }

        void ComputeFFT(WaveBuffer wbuf)
        {
            if (GetAudioData(wbuf.AudioData, wbuf.BufferLength, _wfmt))
            {
                // adjust FFT Sample to next power 2 but fill data with silence
                uint pow2Samples = FFT.NextPowerOfTwo(_numSamples);
                if (pow2Samples != _numSamples)
                {
                    double dsilence = 0.0;
                    if (_wfmt.BitsPerSample == 8)
                    {
                        dsilence = 128.0;
                    }
                    for (uint ii = _numSamples; ii < pow2Samples; ii++)
                    {
                        RealIn[ii] = dsilence;
                    }
                    _numSamples = pow2Samples;
                }

                // You may want to add 'USE_FFTLIB' under the project settings (Build->General tab)
                // to get better performance
#if USE_FFTLIB
                // Do the FFT
                FFTLib.ComputeD(_numSamples, RealIn, null, RealOut, ImagOut, false);
                // We can skip N/2 to N samples (mirror frequencies) - Digital samples are real integer
                FFTLib.NormD(_numSamples / 2, RealOut, ImagOut, AmplOut);
#else
                FFT.Compute(_numSamples, RealIn, null, RealOut, ImagOut, false);
                FFT.Norm(_numSamples / 2, RealOut, ImagOut, AmplOut);
#endif
                double maxAmpl = (_wfmt.BitsPerSample == 8) ? (127.0 * 127.0) : (32767.0 * 32767.0);

                // update meter
                int centerFreq = (_wfmt.SamplesPerSecond / 2);
                for (int i = 0; i < NUM_FREQUENCY; ++i)
                {
                    if (METER_FREQUENCY[i] > centerFreq)
                        _meterData[i] = 0;
                    else
                    {
                        int indice = (int)(METER_FREQUENCY[i] * _numSamples / _wfmt.SamplesPerSecond);
                        int metervalue = (int)(20.0 * Math.Log10(AmplOut[indice] / maxAmpl));
                        _meterData[i] = metervalue;
                    }
                }
                peakMeterCtrl1.SetData(_meterData, 0, NUM_FREQUENCY);
                _numSamples = 0; // ready to do it again
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("GET Audio data failed.");
            }
        }

        bool GetAudioData(IntPtr ptr, int cbSize, WaveFormat wfmt)
        {
            bool samplesReady = false;
            if (cbSize == 0)
                return false; // no data
            switch (wfmt.BitsPerSample)
            {
                case 8:
                    {
                        // NOTE: waveData member is necessary to prevent using 'unsafe' code block
                        Marshal.Copy(ptr, waveData, 0, (int)cbSize);
                        if (wfmt.Channels == 1) // mono
                        {
                            for (uint i = 0; i < cbSize; ++i)
                            {
                                RealIn[i] = (double)((waveData[i] - 128) << 6);// Out = (In-128)*64
                                // LeftIn[i] = RealIn[i]; // Out = (In-128)*64
                            }
                            _numSamples = (uint)cbSize;
                        }
                        else if (wfmt.Channels == 2) // stereo
                        {
                            // Stereo has Right+Left channels
                            int Samples = cbSize >> 1;
                            for (uint i = 0, j = 0; i < Samples; ++i, j += 2)
                            {
                                RealIn[i] = (double)((waveData[j] - 128) << 6); // Out = (In-128)*64
                                // LeftIn[i] = (double)((waveData[j+1]-128)<<6); // Out = (In-128)*64
                            }
                            _numSamples = (uint)Samples;
                        }
                        samplesReady = (_numSamples != 0);
                    }
                    break;
                case 16:
                    {
                        // NOTE: waveData member is necessary to prevent using 'unsafe' code block
                        Marshal.Copy(ptr, waveData, 0, (int)cbSize);
                        if (wfmt.Channels == 1) // mono
                        {
                            int Samples = cbSize >> 1;
                            for (uint i = 0, j = 0; i < Samples; ++i, j += 2)
                            {
                                short val = (short)unchecked(((waveData[j + 1] << 8) + waveData[j]));
                                RealIn[i] = (double)val;
                            }
                            _numSamples = (uint)Samples;
                        }
                        else if (wfmt.Channels == 2) // stereo
                        {
                            // Stereo has Right+Left channels
                            int Samples = cbSize >> 2;
                            for (uint i = 0, j = 0; i < Samples; ++i, j += 4)
                            {
                                short val = unchecked((short)((waveData[j + 1] << 8) + waveData[j])); // right
                                RealIn[i] = (double)val;
                                // val = unchecked((short)((waveData[j+3] << 8) + waveData[j+2])); // left
                            }
                            _numSamples = (uint)Samples;
                        }
                        samplesReady = (_numSamples != 0);
                    }
                    break;
                default:
                    System.Diagnostics.Debug.Assert(false, "Format not supported"); // not supported
                    break;
            }
            return samplesReady;
        }
        bool PutAudioData(IntPtr pbData, int cbSize, int recvBytes, WaveFormat wfmt)
        {
            bool samplesReady = true;
            switch( wfmt.BitsPerSample )
            {
            case 8:
                {
                    // fill with silence - no smoothing
                    if ( cbSize > recvBytes )
                    {
                        MemorySet(pbData, 0x80, (cbSize - recvBytes));
                    }
                }
                break;
            case 16:
            default:
                {
                    // fill with silence - no smoothing
                    if ( cbSize > recvBytes )
                    {
                        MemorySet(pbData, 0x00, (cbSize - recvBytes));
                    }
                }
                break;
            }
            return samplesReady;
        }
        void MemorySet(IntPtr ptrData, byte val, int cb)
        {
            byte[] silence = { val };
            for (int i = 0; i < cb; ++i)
            {
                IntPtr ptrDest = (IntPtr)((int)ptrData + i);
                Marshal.Copy(silence, 0, ptrDest, 1);
            }
        }
        void CreateWaveOutput()
        {
            if (_waveOutput == null)
            {
                _waveOutput = new WaveOutDevice();
                _waveOutput.SetNotifyHandler(this);
            }
        }
        void ReleaseWaveOutput()
        {
            if (_waveOutput != null)
            {
                _waveOutput.Dispose();
                _waveOutput = null;
                ReleaseBuffers();
            }
            ReleaseMixerDevice();
            if (_AudioStream != null)
            {
                _AudioStream.Dispose();
                _AudioStream = null;
            }
            if (_MediaStream != null)
            {
                _MediaStream.Dispose();
                _MediaStream = null;
            }
        }
        void CreateMixerDevice()
        {
            if (_mixerDevice == null)
            {
                _mixerDevice = new WaveMixerDevice();
            }
        }
        void ReleaseMixerDevice()
        {
            if (_mixerDevice != null)
            {
                _mixerDevice.Dispose();
                _mixerDevice = null;
                Marshal.FreeHGlobal(_mixerDataPtr);
                _mixerDataPtr = IntPtr.Zero;
            }
        }
        void CreateBuffers()
        {
            if (_waveBuffer == null)
            {
                _waveBuffer = new WaveBuffer[MAX_BUFFERS];
                for (int ii = 0; ii < MAX_BUFFERS; ++ii)
                {
                    _waveBuffer[ii] = new WaveBuffer();
                    _waveBuffer[ii].Allocate((int)_bufferSize);
                }
            }
        }
        void ReleaseBuffers()
        {
            if (_waveBuffer != null)
            {
                for (int ii = 0; ii < MAX_BUFFERS; ++ii)
                {
                    _waveBuffer[ii].Dispose();
                }
                _waveBuffer = null;
            }
        }

        void AllocFFTData()
        {
            int numSamples = (int)_bufferSize / _wfmt.BlockAlign;
            RealIn = new double[numSamples];
            RealOut = new double[numSamples];
            ImagOut = new double[numSamples];
            AmplOut = new double[numSamples];
            waveData = new byte[_bufferSize];
        }
        void ReleaseFFTData()
        {
            RealIn = null;
            RealOut = null;
            ImagOut = null;
            AmplOut = null;
            waveData = null;
        }

        [ConditionalAttribute("DEBUG")]
        void DumpWaveErrorMessage(string message, int error)
        {
            StringBuilder sError = new StringBuilder(256);
            WaveOutput.waveOutGetErrorTextW(error, sError, 256);
            Trace.WriteLine(string.Format("{0} {1}", message, sError.ToString()));
        }

        [ConditionalAttribute("DEBUG")]
        void DumpDebugMessage(string message)
        {
            Trace.WriteLine(message);
        }
    }
}