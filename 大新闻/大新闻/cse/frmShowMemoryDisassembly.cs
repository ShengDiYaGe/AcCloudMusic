using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


#warning Actually it does not support paged memory

namespace CSE
{
	/// <summary>
	/// Shows a disassembly of memory
	/// </summary>
	public class frmShowMemoryDisassembly : System.Windows.Forms.Form
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
		/// Z80 Disassembler
		/// </summary>
		private Z80.Z80Disassembler _Disassembler;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Do not use this
		/// </summary>
		public frmShowMemoryDisassembly()
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
		/// This class is *not* registered as a Memory Write Handler.
		/// We hope that program is not going to be rewritten by code itself.
		/// A new disassembler class is created
		/// </summary>
		/// <param name="Memory">Z80 Memory</param>
		/// <param name="Address">Address to show</param>
		public frmShowMemoryDisassembly(Z80.IMemory Memory, ushort Address)
		{
			InitializeComponent();

			_Memory = Memory;
			_Address = Address;

#warning n form = n disassembler classes. Is this good?
			_Disassembler = new Z80.Z80Disassembler(_Memory);

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
			this.txtDisassembly.AutoSize = false;
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
			// frmShowMemoryDisassembly
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(300, 266);
			this.Controls.Add(this.txtDisassembly);
			this.Name = "frmShowMemoryDisassembly";
			this.Text = "Memory";
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// Refreshes output reading memory. 0x80 statements will be written
		/// </summary>
		public void RefreshOutput()
		{
			ushort PC = _Address;
			ushort oldPC;
			string statement;
			string statementHex;
			string output = "";
			for (int n = 0; n < 0x80; n++)
			{
				// Save the old PC
				oldPC = PC;
				// Disassembly next statement
				statement = _Disassembler.Disassemble(ref PC);
				// Retrieve the statement in HEX
				statementHex = "";
				for (ushort m = oldPC; m < PC; m++)
					statementHex += string.Format("{0:X2}", _Memory.ReadByte(m));

				output += string.Format("{0,5} {1,-12} {2}\r\n", oldPC, statementHex, statement);			
			}

			txtDisassembly.Text = output;
		}

	
	}
}
