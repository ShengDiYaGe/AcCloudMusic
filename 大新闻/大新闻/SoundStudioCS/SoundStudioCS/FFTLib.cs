using System;
using System.Collections.Generic;
using System.Security;
using System.Runtime.InteropServices;
using System.Text;

namespace SoundStudioCS
{
    public class FFTLib
    {
        [DllImportAttribute("FFTlib.dll", EntryPoint = "ComputeF", CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurityAttribute]
        public static extern int ComputeF([In]uint NumSamples, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pRealIn, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pImagIn, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pRealOut, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pImagOut, [In, MarshalAs(UnmanagedType.Bool)] bool bInverseTransform);

        [DllImportAttribute("FFTlib.dll", EntryPoint = "NormF", CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurityAttribute]
        public static extern int NormF([In]uint NumSamples, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pReal, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pImag, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pAmpl);

        [DllImportAttribute("FFTlib.dll", EntryPoint = "PeakFrequencyF")]
        [SuppressUnmanagedCodeSecurityAttribute]
        public static extern double PeakFrequencyF([In]uint NumSamples, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] float[] pAmpl, float samplingRate, ref uint index);

        [DllImportAttribute("FFTlib.dll", EntryPoint = "ComputeD", CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurityAttribute]
        public static extern int ComputeD([In]uint NumSamples, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] double[] pRealIn, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] double[] pImagIn, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] double[] pRealOut, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] double[] pImagOut, [In, MarshalAs(UnmanagedType.Bool)] bool bInverseTransform);

        [DllImportAttribute("FFTlib.dll", EntryPoint = "NormD", CallingConvention = CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurityAttribute]
        public static extern int NormD([In]uint NumSamples, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] double[] pReal, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] double[] pImag, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] double[] pAmpl);

        [DllImportAttribute("FFTlib.dll", EntryPoint = "PeakFrequencyD")]
        [SuppressUnmanagedCodeSecurityAttribute]
        public static extern double PeakFrequencyD([In]uint NumSamples, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] double[] pAmpl, double samplingRate, ref uint index);

    }
}
