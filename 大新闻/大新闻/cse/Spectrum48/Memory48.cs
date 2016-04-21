using System;
using System.IO;
using Z80;

namespace Spectrums.Spectrum48
{
	/// <summary>
	/// IMemory implementation for a 48k Speccy
	/// </summary>
	public class Memory48 : IMemory
	{

		byte[] _Memory = new byte[0x10000];

		/// <summary>
		/// Raised before read
		/// </summary>
		public event OnReadHandler OnRead;

		/// <summary>
		/// Raised before write
		/// </summary>
		public event OnWriteHandler OnWrite;

		/// <summary>
		/// Initialize memory and load rom
		/// </summary>
		public Memory48()
		{
			LoadROM();
		}


		/// <summary>
		/// Load a ROM file from address 0x0000 to address 0x3FFF
		/// </summary>
		private void LoadROM()
		{
			
			Stream stream = new FileStream("C:\\Speccy\\Spectrum.rom" , FileMode.Open);
			if (stream.Length != 0x4000)
				throw new Exception("Invalid file size.");
			
			//Stream stream = new FileStream("C:\\Speccy\\IndexRegisters.obj" , FileMode.Open);

			stream.Read(_Memory, 0x0000, (int) stream.Length);
			stream.Close();
		}



		/// <summary>
		/// Reads a memory cell
		/// </summary>
		/// <param name="Address">Address to read</param>
		/// <returns>The byte readed</returns>
		public byte ReadByte(ushort Address)
		{
			if (OnRead != null)
				OnRead(Address);
			return _Memory[Address];
		}

		/// <summary>
		/// Writes a memory cell
		/// </summary>
		/// <param name="Address">Address to write</param>
		/// <param name="Value">The byte to write</param>
		public void WriteByte(ushort Address, byte Value)
		{
			// Avoid ROM write
			if (Address < 0x4000)
				return;

			_Memory[Address] = Value;

			if (OnWrite != null)
				OnWrite(Address, Value);

		}

		/// <summary>
		/// Read a word from memory
		/// </summary>
		/// <param name="Address">Address to read</param>
		/// <returns>the word readed</returns>
		public ushort ReadWord(ushort Address)
		{
			return (ushort) (ReadByte((ushort) (Address + 1)) << 8 | ReadByte(Address));
		}

		/// <summary>
		/// Write a word to memory
		/// </summary>
		/// <param name="Address">Address</param>
		/// <param name="Value">The word to write</param>
		public void WriteWord(ushort Address, ushort Value)
		{
			WriteByte(Address, (byte) (Value & 0x00FF));
			WriteByte((ushort) (Address + 1), (byte) ((Value & 0xFF00) >> 8));
		}

		/// <summary>
		/// Memory size
		/// </summary>
		public int Size
		{
			get
			{
				return 0x10000;
			}
		}

		/// <summary>
		/// Access to whole memory
		/// </summary>
		public byte this[int Address]
		{
			get
			{
				return _Memory[Address];
			}
			set
			{
				_Memory[Address] = value;
			}
		}

		/// <summary>
		/// Memory as byte array
		/// </summary>
		public byte[] Raw
		{
			get
			{
				return _Memory;
			}
		}


	}
}
