using System;
using Z80;
using Spectrums.Common;

namespace Spectrums.Spectrum48
{
	/// <summary>
	/// Emulation of a Spectrum 48k
	/// </summary>
	public class Spectrum48
	{

		private Memory48 _Memory;
		private IO48 _IO;
		private Video _Video;
		private uP _Z80;

		public Spectrum48()
		{
			_Memory = new Memory48();
			_IO = new IO48();
			_Video = new Video(_Memory);
			_Z80 = new uP(_Memory, _IO);
			_IO.Video = _Video;			// Border handling
		}


		public void Run()
		{

		}

		public Memory48 Memory
		{
			get {return _Memory;}
		}

		public Video Video
		{
			get {return _Video;}
		}

		public IO48 IO
		{
			get {return _IO;}
		}

		public Z80.uP Z80
		{
			get {return _Z80;}
		}

	}
}
