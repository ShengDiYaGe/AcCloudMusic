using System;
using Z80;

namespace Spectrums.Spectrum48
{
	/// <summary>
	/// Summary description for IO48.
	/// </summary>
	public class IO48: IIO
	{

		private Spectrums.Common.Keyboard _Keyboard = new Spectrums.Common.Keyboard();
		private Spectrums.Common.Video _Video;

		private IIO _DefaultIO = null;

		/// <summary>
		/// Create a new IO
		/// </summary>
		public IO48()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Reads a single byte from a port
		/// </summary>
		/// <param name="Port">Port to read from</param>
		/// <returns>The byte value</returns>
		public byte ReadPort(ushort Port)
		{
			byte Value;
			
			if (_Keyboard.ReadPort(Port, out Value))
				return Value;
			
			if (_DefaultIO != null)
				return _DefaultIO.ReadPort(Port);

			return 0xFF;
		}

		

		/// <summary>
		/// Writes a single byte to a port
		/// </summary>
		/// <param name="Port">Port to write to</param>
		/// <param name="Value">The byte value</param>
		public void WritePort(ushort Port, byte Value)
		{
			_Video.WritePort(Port, Value);

			if (_DefaultIO != null)
				_DefaultIO.WritePort(Port, Value);
		}


		/// <summary>
		/// The keyboard to read from
		/// </summary>
		public Spectrums.Common.Keyboard Keyboard
		{
			get
			{
				return _Keyboard;
			}
		}

		/// <summary>
		/// The video that's hosting the border
		/// </summary>
		public Spectrums.Common.Video Video
		{
			get
			{
				return _Video;
			}
			set
			{
				_Video = value;
			}
		}

		/// <summary>
		/// Used if no one can handle the port request. It should be used for debug purpose only
		/// </summary>
		public IIO DefaultIO
		{
			get
			{
				return _DefaultIO;
			}
			set
			{
				_DefaultIO = value;
			}
		}


	}
}
