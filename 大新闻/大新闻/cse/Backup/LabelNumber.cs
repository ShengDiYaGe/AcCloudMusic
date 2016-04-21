using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace CSE
{
	/// <summary>
	/// A label that contain a number
	/// </summary>
	public class LabelNumber : System.Windows.Forms.UserControl
	{

		
		private int _Digits = 2;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.ToolTip toolTip;
		private System.ComponentModel.IContainer components;

		public LabelNumber()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
			this.components = new System.ComponentModel.Container();
			this.lbl = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// lbl
			// 
			this.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbl.Location = new System.Drawing.Point(0, 0);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(150, 150);
			this.lbl.TabIndex = 0;
			this.lbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// LabelNumber
			// 
			this.Controls.Add(this.lbl);
			this.Name = "LabelNumber";
			this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// Value
		/// </summary>
		public int Value
		{
			get
			{
				// Standard visualization in Hex Format
				return (int) ushort.Parse("0" + lbl.Text, System.Globalization.NumberStyles.AllowHexSpecifier);
			}
			set
			{
				// Show in Hex format and add tooltip containing other formats
				string hexFormat = "{0:X" + _Digits.ToString() + "}";
				lbl.Text = string.Format(hexFormat, value);

				string tooltip = "";
				tooltip += "Hex: " + string.Format(hexFormat, value) + "\n";
				tooltip += "Decimal: " + value.ToString() + "\n";
				tooltip += "Binary:\n";

				for (int n = 0; n < (_Digits >> 1); n++)
				{
					byte b = (byte) (value & 0xFF);
					value >>= 8;
					tooltip += "   " + ByteBinary(b) + "\n";
				}

				toolTip.SetToolTip(lbl, tooltip);

			}

		}

		/// <summary>
		/// Convert a single byte in binary
		/// </summary>
		/// <param name="b">The byte</param>
		/// <returns>Binary rapresentation of b</returns>
		private string ByteBinary(byte b)
		{
			string retVal = "";
			for (int n = 0; n < 8; n++)
			{
				retVal += (b & 0x80) != 0 ? '1' : '0';
				b <<= 1;
			}
			return retVal;
		}

		/// <summary>
		/// Number of digits to show (2 or 4)
		/// </summary>
		public int Digits
		{
			get
			{
				return _Digits;
			}
			set
			{
				_Digits = value;
			}
		}

	}
}
