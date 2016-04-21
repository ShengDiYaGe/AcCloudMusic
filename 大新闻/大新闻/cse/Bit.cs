using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace CSE
{
	/// <summary>
	/// Summary description for Bit.
	/// </summary>
	public class Bit : System.Windows.Forms.Control
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private bool _Value = false;
		
		/// <summary>
		/// Standard creator
		/// </summary>
		public Bit()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
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

		}
		#endregion


		/// <summary>
		/// Value of this bit
		/// </summary>
		public bool Value
		{
			get
			{
				return _Value;
			}
			set
			{
				// Set the value and redraw the control
				_Value = value;
				this.Invalidate();
			}
		}


		/// <summary>
		/// Draw the control
		/// </summary>
		/// <param name="pe">events</param>
		protected override void OnPaint(PaintEventArgs pe)
		{
			System.Drawing.Graphics g = base.CreateGraphics();
			System.Drawing.Brush brush;

			// Green for high bits, gray for low bits
			if (_Value)
				brush = System.Drawing.Brushes.GreenYellow;
			else
				brush = System.Drawing.Brushes.Gray;

			// Draw external rectangle
			g.DrawRectangle(System.Drawing.Pens.Black, 0, 0, this.Width, this.Height);
			
			// Draw internal rectangle
			g.FillRectangle(brush, 1, 1, this.Width - 2, this.Height - 2);

			// Calling the base class OnPaint
			base.OnPaint(pe);
		}

	}
}
