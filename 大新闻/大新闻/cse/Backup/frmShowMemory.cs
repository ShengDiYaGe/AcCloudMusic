using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


#warning Actually it does not support paged memory

namespace CSE
{
	/// <summary>
	/// Summary description for frmDebug.
	/// </summary>
	public class frmShowMemory : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtDisassembly;

		/// <summary>
		/// Address of displayed memory
		/// </summary>
		private ushort _Address;

		/// <summary>
		/// Z80 Memory to show
		/// </summary>
		private Z80.IMemory _Memory;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Do not use this
		/// </summary>
		public frmShowMemory()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		
		/// <summary>
		/// Standard constructor.
		/// A reference to memory will be saved for memory refreshes.
		/// This class is then registered as a Memory Write Handler so on write the output is refreshed
		/// </summary>
		/// <param name="Memory">Z80 Memory</param>
		/// <param name="Address">Address to show</param>
		public frmShowMemory(Z80.IMemory Memory, ushort Address)
		{
			InitializeComponent();

			_Memory = Memory;
			_Address = Address;

			// Register this class as a OnWrite event receiver
			_Memory.OnWrite += new Z80.OnWriteHandler(OnMemoryWrite); 

			RefreshOutput();
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtDisassembly = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtDisassembly
			// 
			this.txtDisassembly.AcceptsReturn = true;
			this.txtDisassembly.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDisassembly.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDisassembly.Location = new System.Drawing.Point(0, 0);
			this.txtDisassembly.Multiline = true;
			this.txtDisassembly.Name = "txtDisassembly";
			this.txtDisassembly.ReadOnly = true;
			this.txtDisassembly.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDisassembly.Size = new System.Drawing.Size(300, 266);
			this.txtDisassembly.TabIndex = 0;
			this.txtDisassembly.Text = "";
			this.txtDisassembly.WordWrap = false;
			// 
			// frmShowMemory
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(300, 266);
			this.Controls.Add(this.txtDisassembly);
			this.Name = "frmShowMemory";
			this.Text = "Memory";
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// Refreshes output reading memory from previous address
		/// </summary>
		public void RefreshOutput()
		{
			string output = "";
			for (int n = 0; n < 0x40; n++)
			{

				string outputHex = "";
				string outputAscii = "";

				for(int m = 0; m < 0x10; m++)
				{
					byte b = _Memory.ReadByte((ushort) (((n << 4) | m) + _Address));
					outputHex += string.Format("{0,2:X} ", b);
					outputAscii += (b < 33 || b > 127) ? '.' : (char) b;
				}

				output += string.Format("{0,5} {1} {2}\r\n", (n << 4) + _Address, outputHex, outputAscii);

			}
			
			txtDisassembly.Text = output;
		}

		/// <summary>
		/// _Memory.OnMemoryWrite event handler
		/// </summary>
		/// <param name="Address">Address changed</param>
		/// <param name="Value">Value</param>
		private void OnMemoryWrite(ushort Address, byte Value)
		{
			RefreshOutput();
		}
	
	}
}
