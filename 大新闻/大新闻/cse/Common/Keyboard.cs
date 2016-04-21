using System;

namespace Spectrums.Common
{
	/// <summary>
	/// Class for keyboard handling. It keeps status of pressed keys and
	/// it can answer to input requests
	/// </summary>
	public class Keyboard:Z80.IIDevice
	{

		private KeyLine keyB_Spc = new KeyLine();
		private KeyLine keyY_P = new KeyLine();
		private KeyLine keyH_Ent = new KeyLine();
		private KeyLine key6_0 = new KeyLine();

		private KeyLine key1_5 = new KeyLine();
		private KeyLine keyQ_T = new KeyLine();
		private KeyLine keyA_G = new KeyLine();
		private KeyLine keyCaps_V = new KeyLine();


		/// <summary>
		/// Decode an IO address (convert to a keyline) and return a keyboard state
		/// </summary>
		/// <param name="Address">Port address</param>
		/// <param name="Value">Value</param>
		/// <returns>True if the address is a KeyLine address (so the value is valid), False otherwise</returns>
		public bool ReadPort(ushort Address, out byte Value)
		{

			Value = 0xFF;

			// Check if is a keyboard access
			if ((Address & 0xFF) != 0xFE)
				return false;

      if ((Address & 0x8000) == 0)
          Value = (byte) (Value & keyB_Spc.Value);
      
      if ((Address & 0x4000) == 0)
          Value = (byte) (Value & keyH_Ent.Value);
      
      if ((Address & 0x2000) == 0)
          Value = (byte) (Value & keyY_P.Value);
      
      if ((Address & 0x1000) == 0)
          Value = (byte) (Value & key6_0.Value);
      
      if ((Address & 0x800) == 0)
          Value = (byte) (Value & key1_5.Value);
      
      if ((Address & 0x400) == 0)
          Value = (byte) (Value & keyQ_T.Value);
      
      if ((Address & 0x200) == 0)
          Value = (byte) (Value & keyA_G.Value);
      
      if ((Address & 0x100) == 0)
          Value = (byte) (Value & keyCaps_V.Value);
        
			return true;
		}


		public Keyboard()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Parse the key and set the state for input and output answers
		/// </summary>
		/// <param name="Down">True if the key has been pressed (KeyDown event), False if the key has been released (KeyUp event)</param>
		/// <param name="e">The event arg passed to the event</param>
		public void ParseKey(bool Down, System.Windows.Forms.KeyEventArgs e)
		{


			bool SetBit = !Down;

			bool CAPS = e.Shift;
			bool SYMB = e.Control;

			int ascii = e.KeyValue; 

			// Change control versions of keys to lower case
			if ((ascii >= 1) && (ascii <= 0x27) && SYMB)
				ascii = ascii + 97 - 1;
	    
			if (CAPS) 
				keyCaps_V.Reset(0);
			else
				keyCaps_V.Set(0);
    
			if (SYMB) 
				keyB_Spc.Reset(1);
			else
				keyB_Spc.Set(1);

			switch (ascii)
			{
				case 8: // Backspace
					if (Down)
					{
						key6_0.Reset(0);
						keyCaps_V.Reset(0);
					}
					else
					{
						key6_0.Set(0);
						if (!CAPS)
							keyCaps_V.Set(1);
					}
					break;

				
				
				case 65: // A
					keyA_G.Set(0, SetBit);
					break;
				case 66: // B
					keyB_Spc.Set(4, SetBit);
					break;
				case 67: // C
					keyCaps_V.Set(3, SetBit);
					break;
				case 68: // D
					keyA_G.Set(2, SetBit);
					break;
				case 69: // E
					keyQ_T.Set(2, SetBit);
					break;
				case 70: // F
					keyA_G.Set(3, SetBit);
					break;
				case 71: // G
					keyA_G.Set(4, SetBit);
					break;
				case 72: // H
					keyH_Ent.Set(4, SetBit);
					break;
				case 73: // I
					keyY_P.Set(2, SetBit);
					break;
				case 74: // J
					keyH_Ent.Set(3, SetBit);
					break;
				case 75: // K
					keyH_Ent.Set(2, SetBit);
					break;
				case 76: // L
					keyH_Ent.Set(1, SetBit);
					break;
				case 77: // M
					keyB_Spc.Set(2, SetBit);
					break;
				case 78: // N
					keyB_Spc.Set(3, SetBit);
					break;
				case 79: // O
					keyY_P.Set(1, SetBit);
					break;
				case 80: // P
					keyY_P.Set(0, SetBit);
					break;
				case 81: // Q
					keyQ_T.Set(0, SetBit);
					break;
				case 82: // R
					keyQ_T.Set(3, SetBit);
					break;
				case 83: // S
					keyA_G.Set(1, SetBit);
					break;
				case 84: // T
					keyQ_T.Set(4, SetBit);
					break;
				case 85: // U
					keyY_P.Set(3, SetBit);
					break;
				case 86: // V
					keyCaps_V.Set(4, SetBit);
					break;
				case 87: // W
					keyQ_T.Set(1, SetBit);
					break;
				case 88: // X
					keyCaps_V.Set(2, SetBit);
					break;
				case 89: // Y
					keyY_P.Set(4, SetBit);
					break;
				case 90: // Z
					keyCaps_V.Set(1, SetBit);
					break;
				case 48: // 0
					key6_0.Set(0, SetBit);
					break;
				case 49: // 1
					key1_5.Set(0, SetBit);
					break;
				case 50: // 2
					key1_5.Set(1, SetBit);
					break;
				case 51: // 3
					key1_5.Set(2, SetBit);
					break;
				case 52: // 4
					key1_5.Set(3, SetBit);
					break;
				case 53: // 5
					key1_5.Set(4, SetBit);
					break;
				case 54: // 6
          key6_0.Set(4, SetBit);
					break;
				case 55: // 7
					key6_0.Set(3, SetBit);
					break;
				case 56: // 8
					key6_0.Set(2, SetBit);
					break;
				case 57: // 9
					key6_0.Set(1, SetBit);
					break;
				case 96: // Keypad 0
					key6_0.Set(0, SetBit);
					break;
				case 97: // Keypad 1
					key1_5.Set(0, SetBit);
					break;
				case 98: // Keypad 2
					key1_5.Set(1, SetBit);
					break;
				case 99: // Keypad 3
					key1_5.Set(2, SetBit);
					break;
				case 100: // Keypad 4
					key1_5.Set(3, SetBit);
					break;
				case 101: // Keypad 5
					key1_5.Set(4, SetBit);
					break;
				case 102: // Keypad 6
					key6_0.Set(4, SetBit);
					break;
				case 103: // Keypad 7
					key6_0.Set(3, SetBit);
					break;
				case 104: // Keypad 8
					key6_0.Set(2, SetBit);
					break;
				case 105: // Keypad 9
					key6_0.Set(1, SetBit);
					break;

				
				
				case 106: // Keypad *
					if (Down) 
					{
						keyB_Spc.Reset(2);
						keyB_Spc.Reset(4);
					}
					else
					{
						if (SYMB)
							keyB_Spc.Set(4);
						else
						{
							keyB_Spc.Set(2);
							keyB_Spc.Set(4);
						}
					}
					break;		            
		        
				case 107: // Keypad +
					if (Down) 
					{
						keyH_Ent.Reset(2);
						keyB_Spc.Reset(1);
					}
					else
					{
						keyH_Ent.Set(2);
						if (!SYMB)
							keyB_Spc.Set(1);
					}
		      break; 
 
				case 109: // Keypad -
					if (Down) 
					{
						keyH_Ent.Reset(3);
						keyB_Spc.Reset(1);
					}
					else
					{
						keyH_Ent.Set(3);
						if (!SYMB)
							keyB_Spc.Set(1);
					}
					break; 
		            
		        
				case 110: // Keypad .
					if (Down) 
					{
						keyB_Spc.Reset(2);
						keyB_Spc.Reset(1);
					}
					else
					{
						keyB_Spc.Set(2);
						if (!SYMB)
							keyB_Spc.Set(1);
					}
					break; 
		        
				case 111: // Keypad /
					if (Down) 
					{
						keyCaps_V.Reset(4);
						keyB_Spc.Reset(1);
					}
					else
					{
						keyCaps_V.Set(4);
						if (!SYMB)
							keyB_Spc.Set(1);
					}
					break; 

				
				
				
				case 37: // Left
					if (Down) 
					{
						key1_5.Reset(4);
						keyCaps_V.Reset(0);
					}
					else
					{
						key1_5.Set(4);
						if (!SYMB)
							keyB_Spc.Set(1);
					}
					break; 
		        
				case 38: // Up
					if (Down) 
					{
						key6_0.Reset(3);
						keyCaps_V.Reset(0);
					}
					else
					{
						key6_0.Set(3);
						if (!SYMB)
							keyCaps_V.Set(1);
					}
					break; 
		        
				case 39: // Right
					if (Down) 
					{
						key6_0.Reset(2);
						keyCaps_V.Reset(0);
					}
					else
					{
						key6_0.Set(2);
						if (!SYMB)
							keyCaps_V.Set(1);
					}
					break; 
		        
				case 40: // Down
					if (Down) 
					{
						key6_0.Reset(4);
						keyCaps_V.Reset(0);
					}
					else
					{
						key6_0.Set(4);
						if (!SYMB)
							keyCaps_V.Set(1);
					}
					break; 
		            
		        
				case 13: // RETURN
					keyH_Ent.Set(0, SetBit);
					break;
				case 32: // SPACE BAR
					keyB_Spc.Set(0, SetBit);
					break;
				case 187: // =/+ key
					if (Down)
					{
						if (CAPS)
							keyH_Ent.Reset(2);
						else
							keyH_Ent.Reset(1);
						keyB_Spc.Reset(1);
						keyCaps_V.Set(0);
					}
					else
					{
						keyH_Ent.Set(2);
						keyH_Ent.Set(1);
						keyB_Spc.Set(1);
					}
					break;
		        
				case 189: // -/_ key
					if (Down)
					{
						if (CAPS)
							key6_0.Reset(0);
						else
							keyH_Ent.Reset(3);
		    
						keyB_Spc.Reset(1);
						keyCaps_V.Set(0);
					}
					else
					{
						key6_0.Set(0);
						keyH_Ent.Set(3);
						keyB_Spc.Set(1);
					}
					break;
		        
				case 186: // ;/: keys
					if (Down)
					{
						if (CAPS) 
							keyCaps_V.Reset(1);
						else
							keyY_P.Reset(1);
		          
						keyB_Spc.Reset(1);
						keyCaps_V.Set(0);
					}
					else
					{
						keyCaps_V.Set(1);
						keyY_P.Set(1);
						keyB_Spc.Set(1);
					}
					break;
		        
				default:
					// ???
					break;
			}

			
		
		}


		/// <summary>
		/// A line of keys readed with a single input operation
		/// </summary>
		private class KeyLine
		{
			
			private byte _Value = 0xFF;

			/// <summary>
			/// Gets or set the value of the key pattern
			/// </summary>
			public byte Value
			{
				get
				{
					return _Value;
				}
				set
				{
					_Value = value;
				}
			}


			/// <summary>
			/// Set a bit
			/// </summary>
			/// <param name="Bit">Bit to set</param>
			public void Set(byte Bit)
			{
				_Value = (byte) (_Value | (1 << Bit));
			}

			/// <summary>
			/// Reset a bit
			/// </summary>
			/// <param name="Bit">Bit to reset</param>
			public void Reset(byte Bit)
			{
				_Value = (byte) (_Value & (~(1 << Bit)));
			}

			/// <summary>
			/// Sets or resets a bit
			/// </summary>
			/// <param name="Bit">Bit to change</param>
			/// <param name="Value">True if the bit have to be set else false</param>
			public void Set(byte Bit, bool Value)
			{
				if (Value)
					Set(Bit);
				else
					Reset(Bit);
			}

		}

	}



}
