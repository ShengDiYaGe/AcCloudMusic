using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace CSE
{
	/// <summary>
	/// Summary description for Byte.
	/// </summary>
	public class Byte : System.Windows.Forms.UserControl
	{
		private Bit[] bits = new Bit[8];
		private CSE.LabelNumber Number;
		private byte _Value;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Standard creator
		/// </summary>
		public Byte()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			InitializeBits();

		}

		private void InitializeBits()
		{
			for (int n = 0; n < 8; n++)
			{
				bits[n] = new Bit();
				bits[n].Location = new System.Drawing.Point(16 * 7 - 16 * n, 2);
				bits[n].Name = "bit" + n.ToString();
				bits[n].Size = new System.Drawing.Size(12, 12);
				bits[n].TabIndex = n;

				bits[n].Click += new EventHandler(Byte_Click);
			}

			this.Controls.AddRange(bits);

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Number = new CSE.LabelNumber();
			this.SuspendLayout();
			// 
			// Number
			// 
			this.Number.Digits = 2;
			this.Number.Location = new System.Drawing.Point(132, 0);
			this.Number.Name = "Number";
			this.Number.Size = new System.Drawing.Size(24, 16);
			this.Number.TabIndex = 0;
			this.Number.Value = 0;
			// 
			// Byte
			// 
			this.Controls.Add(this.Number);
			this.Name = "Byte";
			this.Size = new System.Drawing.Size(156, 16);
			this.ResumeLayout(false);

		}
		#endregion

	
		/// <summary>
		/// Sets or gets contained value
		/// </summary>
		public byte Value
		{
			get
			{
				return (byte) Number.Value;
			}
			set
			{
				Number.Value = value;
				for (int n = 0; n < 8; n++)
					bits[n].Value = (value & (1 << n)) != 0;
			}
		}

		private void Byte_Click(object sender, EventArgs e)
		{
			// The sender is CSE.Bit with name bit<n>
			byte nBit = byte.Parse(((Control) sender).Name.Substring(3,1));
			
			// Invert the value of the bit
			if (bits[nBit].Value)
				Value = (byte)((~(1 << nBit)) & Value);
			else
				Value = (byte)((1 << nBit) | Value);

		}
	}
}
