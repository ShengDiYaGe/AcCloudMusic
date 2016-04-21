using System;
using System.Media;

namespace Morse
{
	class MainClass
	{

		public const string versionID = "v0.1";

		public static void Main (string[] args)
		{
			Sound sineWave = new Sound ("Sound/dit.wav", "Sound/dah.wav");
			Morse morse = new Morse("InternationalMorse.txt", sineWave);

			while (true)
			{
				morse.RunAll ();
				System.Threading.Thread.Sleep (200);
			}

		}
	}
}
