using System;
using System.IO;
using Z80;

namespace Spectrums.Common
{
	/// <summary>
	/// Summary description for Video.
	/// </summary>
	public class Video:Z80.IODevice
	{

		IMemory _Memory;
		bool FlashStateInverse = false;

		private System.Drawing.Bitmap _DefaultOutputBitmap;
		private System.Windows.Forms.Control _BorderControl;


		/// <summary>
		/// Create a new video output based on memory specified
		/// </summary>
		/// <param name="Memory">Z80 Memory</param>
		public Video(IMemory Memory)
		{
			_Memory = Memory;
			_Memory.OnWrite += new OnWriteHandler(_Memory_OnWrite);
		}


		/// <summary>
		/// Bitmap where output will be flushed if no other bitmap is specified
		/// </summary>
		public System.Drawing.Bitmap DefaultOutputBitmap
		{
			get
			{
				return _DefaultOutputBitmap;
			}
			set
			{
				_DefaultOutputBitmap = value;
			}
		}


		/// <summary>
		/// Write the video to a file
		/// </summary>
		/// <param name="FileName">File name</param>
		public void WriteFileSCR(string FileName)
		{
			Stream stream = new FileStream(FileName, FileMode.Create);
			stream.Write(_Memory.Raw, 0x4000, 0x1B00);
			stream.Close();
		}

		/// <summary>
		/// Read the video from a file
		/// </summary>
		/// <param name="FileName">File name</param>
		public void ReadFileSCR(string FileName)
		{
			Stream stream = new FileStream(FileName, FileMode.Open);
			if (stream.Length != 0x1B00)
				throw new Exception("Invalid file size.");

			stream.Read(_Memory.Raw, 0x4000, 0x1B00);
			stream.Close();
		}


		/// <summary>
		/// Draw complete video from memory to default bitmap
		/// </summary>
		public void Refresh()
		{
			Refresh(_DefaultOutputBitmap);
		}


		/// <summary>
		/// Redraw the screen inverting the ink and the paper color
		/// </summary>
		public void Flash()
		{
			// Invert the flashing state
			FlashStateInverse = !FlashStateInverse;

			// Look for an an attribute with flash bit set
			for (ushort Address = 0x5800; Address < 0x5B00; Address++)
				if ((_Memory.Raw[Address] & 0x80) != 0)
				{
					System.Drawing.Color fgColor;
					System.Drawing.Color bgColor;
					GetColorsFromAttributeAddress(Address, FlashStateInverse, out fgColor, out bgColor);
				
					Draw8Bytes(GetPixelAddressFromAttributeAddress(Address), fgColor, bgColor);
				}
		}

		/// <summary>
		/// Draw complete video from memory to specified bitmap
		/// </summary>
		/// <param name="Video">Bitmap</param>
		public void Refresh(System.Drawing.Bitmap Video)
		{
			// Main x cicle
			for (ushort Address = 0x4000; Address < 0x5800; Address++)
					DrawSingleByte(Video, Address);

		}


		/// <summary>
		/// Draw a single byte of video memory to specified bitmap
		/// </summary>
		/// <param name="Address">The absolute address (0x4000 + relative address)</param>
		public void DrawSingleByte(ushort Address)
		{
			DrawSingleByte(_DefaultOutputBitmap, Address);
			System.Windows.Forms.Application.DoEvents();
		}


		/// <summary>
		/// Draw a single byte of video memory  to specified bitmap
		/// </summary>
		/// <param name="Video">Bitmap</param>
		/// <param name="Address">The absolute address (0x4000 + relative address)</param>
		public void DrawSingleByte(System.Drawing.Bitmap Video, ushort Address)
		{
			byte _b = _Memory.Raw[Address];

			// _Address rappresents the relative address.
			// It's in the form yyyyyyyy xxxxx. yyyyyyyy does not really rappresent
			// y coordinate.
			//
			// The video is splitted in 3 sections, up, middle low section. The
			// section is determined by the first 2 bit of memory_y. In each
			// section the y rows are 8/interleaved.
			// Example
			// Memory_y   y
			//        0   0
			//        1   8
			//        2   16
			//        .
			//        8   1
			//        9   9
			//       10  17
			//
			// The format of memory_y is bb yyy zzz where bb is the block, yyy
			// is the y of the pixel in block and zzz is the block
			// to determine y we can invert yyy with zzz.

			ushort RelativeAddress = (ushort) (Address - 0x4000);
			
			byte x8 = (byte) (RelativeAddress & 0x001F);
			byte memory_y = (byte) ((RelativeAddress >> 5));
			
			byte y = (byte) (memory_y & 0xC0 | ((memory_y & 0x07) << 3) | (memory_y >> 3) & 0x07);
			
			System.Drawing.Color fgColor;
			System.Drawing.Color bgColor;
			GetColorsFromPixelAddress(Address, FlashStateInverse, out fgColor, out bgColor);
			
			for (byte x1 = 0; x1 < 8; x1++)
			{
				// x position
				byte x = (byte) ((x8 << 3) | x1);
				// mask to use to check bit
				byte x1mask = (byte) (0x80 >> x1);
				if ((_b & x1mask) != 0)
					Video.SetPixel(x, y, fgColor);
				else
					Video.SetPixel(x, y, bgColor);
			}						

		}

		/// <summary>
		/// This version of DrawSingleByte can be used when the bgColor and the fgColor is well known
		/// It can be used for blinking management and during incremental screen refresh.
		/// For details see other versions
		/// </summary>
		/// <param name="Address">Absolute address of pixel</param>
		/// <param name="fgColor">Foreground color (ink)</param>
		/// <param name="bgColor">Background color (paper)</param>
		public void DrawSingleByte(ushort Address, System.Drawing.Color fgColor, System.Drawing.Color bgColor)
		{
			byte _b = _Memory.Raw[Address];


			ushort RelativeAddress = (ushort) (Address - 0x4000);
			
			byte x8 = (byte) (RelativeAddress & 0x001F);
			byte memory_y = (byte) ((RelativeAddress >> 5));
			
			byte y = (byte) (memory_y & 0xC0 | ((memory_y & 0x07) << 3) | (memory_y >> 3) & 0x07);
			
			for (byte x1 = 0; x1 < 8; x1++)
			{
				// x position
				byte x = (byte) ((x8 << 3) | x1);
				// mask to use to check bit
				byte x1mask = (byte) (0x80 >> x1);
				if ((_b & x1mask) != 0)
					_DefaultOutputBitmap.SetPixel(x, y, fgColor);
				else
					_DefaultOutputBitmap.SetPixel(x, y, bgColor);
			}						

		}


		/// <summary>
		/// Draw 8 Bytes (8x8 pixels). It can be used when an attribute changes or during screen blink
		/// </summary>
		/// <param name="Address">Absolute address of the first pixel. The address of the other 7 pixels blocks are aa001aaaaaaaa aa010aaaaaaaa and so on.</param>
		/// <param name="fgColor">Foreground color (ink)</param>
		/// <param name="bgColor">Background color (paper)</param>
		public void Draw8Bytes(ushort Address, System.Drawing.Color fgColor, System.Drawing.Color bgColor)
		{
			for (ushort y = 0; y < 8; y++)
				DrawSingleByte((ushort) (Address | (y << 8)), fgColor, bgColor);
		}


		/// <summary>
		/// From the address of an attribute retrieve the address of the first 8 pixels associated with the attribute
		/// The address returned is in the form aa000aaaaaaaa. The address of the other 7 pixels blocks are aa001aaaaaaaa
		/// aa010aaaaaaaa and so on.
		/// </summary>
		/// <param name="AttributeAddress">Address of the attribute</param>
		/// <returns>The address of the first 8 pixels</returns>
		public ushort GetPixelAddressFromAttributeAddress(ushort AttributeAddress)
		{
			ushort AttributeRelativeAddress = (ushort) (AttributeAddress - 0x5800);
			ushort PixelRelativeAddress = (ushort) (((AttributeRelativeAddress & 0x300) << 3) | AttributeRelativeAddress & 0xFF);
			return (ushort) (0x4000 + PixelRelativeAddress);
		}

		/// <summary>
		/// From a memory address of an eight pixel set retrieve the atribute
		/// </summary>
		/// <param name="Address">The absolute address (0x4000 + relative address)</param>
		/// <param name="FlashReversed">True if Spectrum is in the state to display flashing pixel in reverse</param>
		/// <param name="Foreground">Foreground attribute</param>
		/// <param name="Background">Background attribute</param>
		public void GetColorsFromPixelAddress(ushort Address, bool FlashReversed, out System.Drawing.Color Foreground, out System.Drawing.Color Background)
		{
			ushort RelativeAddress = (ushort) (Address - 0x4000);

			// The color of a pixel is determined with a byte at the end of the screen memory
			// Each byte determines the color of an 8x8 pixel group so of a block.
			// To determine the address of an attribute (so the color was called on speccy)
			// from the memory address in the form of bb yyy zzz xxxxx we can use
			// bb zzz xxxxx (section + block address).
			ushort AttributeRelativeAddress = (ushort) ((RelativeAddress >> 3) & 0x300 | RelativeAddress & 0xFF);

			GetColorsFromAttribute(_Memory[AttributeRelativeAddress + 0x5800], FlashReversed, out Foreground, out Background);
		}


		/// <summary>
		/// Get ink and paper colors from attribute address
		/// </summary>
		/// <param name="Address">Address of attribute</param>
		/// <param name="FlashReversed">True if Spectrum is in the state to display flashing pixel in reverse</param>
		/// <param name="Foreground">Foreground attribute</param>
		/// <param name="Background">Background attribute</param>
		public void GetColorsFromAttributeAddress(ushort Address, bool FlashReversed, out System.Drawing.Color Foreground, out System.Drawing.Color Background)
		{
			GetColorsFromAttribute(_Memory[Address], FlashReversed, out Foreground, out Background);
		}


		/// <summary>
		/// Get ink and paper colors from attribute
		/// </summary>
		/// <param name="Attribute">The attribute</param>
		/// <param name="FlashReversed">True if Spectrum is in the state to display flashing pixel in reverse</param>
		/// <param name="Foreground">Foreground attribute</param>
		/// <param name="Background">Background attribute</param>
		private void GetColorsFromAttribute(byte Attribute, bool FlashReversed, out System.Drawing.Color Foreground, out System.Drawing.Color Background)
		{
#warning Non funziona correttamente il bright

			/*			
			if((Attribute & 0x80) != 0 && FlashReversed) 
			{
				Foreground = NibbleToColor(_b);
				Background = NibbleToColor(_b >> 4);

				*ink  = (attr & ( 0x0f << 3 ) ) >> 3;
				*paper= (attr & 0x07) + ( (attr & 0x40) >> 3 );
			} 
			else 
			{
				Foreground = NibbleToColor(_b);
				Background = NibbleToColor(_b >> 4);

				*ink= (attr & 0x07) + ( (attr & 0x40) >> 3 );
				*paper= (attr & ( 0x0f << 3 ) ) >> 3;
			}
			*/			
			Foreground = Table_Colors[(Attribute & 0x07)];
			Background = Table_Colors[((Attribute >> 3) & 0x0F)];

			if (FlashReversed && ((Attribute & 0x80) != 0))
			{
				System.Drawing.Color c = Foreground;
				Foreground = Background;
				Background = c;
			}

		}

		private System.Drawing.Color[] Table_Colors = new System.Drawing.Color[] 
		{
			System.Drawing.Color.Black, 
			System.Drawing.Color.Blue,	
			System.Drawing.Color.Red, 
			System.Drawing.Color.Magenta, 
			System.Drawing.Color.Green, 
			System.Drawing.Color.Cyan,
      System.Drawing.Color.Yellow,
			System.Drawing.Color.WhiteSmoke,
			System.Drawing.Color.Black,
			System.Drawing.Color.LightBlue,
			System.Drawing.Color.Tomato,
			System.Drawing.Color.LightPink,
			System.Drawing.Color.LightGreen,
			System.Drawing.Color.LightCyan,
			System.Drawing.Color.LightYellow,
			System.Drawing.Color.White 
		};

		
		/*private System.Drawing.Color NibbleToColor(byte Nibble)
		{
			switch (Nibble & 0x07)
			{
				case 0:
					return System.Drawing.Color.Black;
				case 1:
					return System.Drawing.Color.Blue;
				case 2:
					return System.Drawing.Color.Red;
				case 3:
					return System.Drawing.Color.Magenta;
				case 4:
					return System.Drawing.Color.Green;
				case 5:
					return System.Drawing.Color.Cyan;
				case 6:
					return System.Drawing.Color.Yellow;
				case 7:
					return System.Drawing.Color.White;
				default:
					throw new Exception("No! No! No!");
			}
		}

		*/

		private void _Memory_OnWrite(ushort Address, byte Value)
		{
			if (Address >= 0x5B00)
				// Address is over video memory
				return;
			else if (Address >= 0x5800)
			{
				// Address is in attribute memory

				// Memory still contains the old copy (so bad to do this!!!)
				_Memory.Raw[Address] = Value;

				System.Drawing.Color fgColor;
				System.Drawing.Color bgColor;
				GetColorsFromAttributeAddress(Address, FlashStateInverse, out fgColor, out bgColor);
				
				Draw8Bytes(GetPixelAddressFromAttributeAddress(Address), fgColor, bgColor);
			}
			else if (Address >= 0x4000)
			{
				//Address is in pixel memory

				// Memory still contains the old copy (so bad to do this!!!)
				_Memory.Raw[Address] = Value;
				DrawSingleByte(Address);
			}
			
		}


		/// <summary>
		/// Gets or sets the control that's hosting the border
		/// Video class will access to property backcolor of this
		/// control when the border is set with an out statement.
		/// </summary>
		public System.Windows.Forms.Control BorderControl
		{
			get
			{
				return _BorderControl;
			}
			set
			{
				_BorderControl = value;
			}
		}


		/// <summary>
		/// IODevice (Interface Output Device) Implementation
		/// </summary>
		/// <param name="Port">Port to write to</param>
		/// <param name="Value">Value to write</param>
		/// <returns>True if the port is handled by the video</returns>
		public bool WritePort(ushort Port, byte Value)
		{
			if ((Port & 0x01) == 0)
			{
				_BorderControl.BackColor = Table_Colors[Value & 0x07];
				return true;
			}
			return false;
		}

	}

}
