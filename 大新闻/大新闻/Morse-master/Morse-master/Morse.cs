using System;

namespace Morse
{
	public class Morse
	{

		string _file;
		string _data;
		string[]_morse;

		public Morse (string file)
		{
			this._file = file;
			ParseMorse ();
			Console.Write (string.Join("\n", _morse));
		}

		private void ParseMorse ()
		{
			_morse = System.IO.File.ReadAllLines (@_file);
		}

		public void ParseMorse (string file)
		{
			_morse = System.IO.File.ReadAllLines (@file);
		}
	}
}

