using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace CSE
{
	/// <summary>
	/// Summary description for LabelRegister.
	/// </summary>
	public class LabelRegister : System.Windows.Forms.UserControl
	{
		private CSE.LabelNumber lblh;
		private CSE.LabelNumber lbll;
		private CSE.LabelNumber lblhl;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Standard initializer
		/// </summary>
		public LabelRegister()
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
			this.lblh = new CSE.LabelNumber();
			this.lbll = new CSE.LabelNumber();
			this.lblhl = new CSE.LabelNumber();
			this.SuspendLayout();
			// 
			// lblh
			// 
			this.lblh.Digits = 2;
			this.lblh.Location = new System.Drawing.Point(0, 0);
			this.lblh.Name = "lblh";
			this.lblh.Size = new System.Drawing.Size(24, 16);
			this.lblh.TabIndex = 0;
			this.lblh.Value = 204;
			// 
			// lbll
			// 
			this.lbll.Digits = 2;
			this.lbll.Location = new System.Drawing.Point(32, 0);
			this.lbll.Name = "lbll";
			this.lbll.Size = new System.Drawing.Size(24, 16);
			this.lbll.TabIndex = 1;
			this.lbll.Value = 204;
			// 
			// lblhl
			// 
			this.lblhl.Digits = 4;
			this.lblhl.Location = new System.Drawing.Point(68, 0);
			this.lblhl.Name = "lblhl";
			this.lblhl.Size = new System.Drawing.Size(40, 16);
			this.lblhl.TabIndex = 2;
			this.lblhl.Value = 52428;
			// 
			// LabelRegister
			// 
			this.Controls.Add(this.lblhl);
			this.Controls.Add(this.lbll);
			this.Controls.Add(this.lblh);
			this.Name = "LabelRegister";
			this.Size = new System.Drawing.Size(108, 16);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 16 bits register value
		/// </summary>
		public int Value
		{
			get
			{
				return lblhl.Value;
			}
			set
			{
				lblhl.Value = value;
				lblh.Value = (value >> 8);
				lbll.Value = value & 0xFF;
			}
		}
	}
}
