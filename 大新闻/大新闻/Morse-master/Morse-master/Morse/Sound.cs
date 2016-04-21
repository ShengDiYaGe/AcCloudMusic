using System;
using System.Media;

namespace Morse
{
	public class Sound
	{

		SoundPlayer _dit;
		SoundPlayer _dah;

		public Sound (string ditFile, string dahFile)
		{
			_dit = new SoundPlayer (ditFile);
			_dah = new SoundPlayer (dahFile);
		}

		public void PlayDit()
		{
			_dit.Play ();
			System.Threading.Thread.Sleep (230);
		}

		public void PlayDah()
		{
			_dah.Play ();
			System.Threading.Thread.Sleep (430);
		}
	}
}

