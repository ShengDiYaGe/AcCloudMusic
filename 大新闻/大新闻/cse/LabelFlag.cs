using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace CSE
{
	/// <summary>
	/// Summary description for LabelFlag.
	/// </summary>
	public class LabelFlag : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label lblFlag;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label17;

		private System.Windows.Forms.Label[] lblBits;
		private System.Windows.Forms.Label label3;


		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Standard creator
		/// </summary>
		public LabelFlag()
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
			this.lblFlag = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblFlag
			// 
			this.lblFlag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblFlag.Location = new System.Drawing.Point(0, 0);
			this.lblFlag.Name = "lblFlag";
			this.lblFlag.Size = new System.Drawing.Size(140, 64);
			this.lblFlag.TabIndex = 0;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(124, 4);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(12, 16);
			this.label14.TabIndex = 70;
			this.label14.Text = "0";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(124, 20);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(12, 16);
			this.label15.TabIndex = 69;
			this.label15.Text = "C";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(108, 20);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(12, 16);
			this.label18.TabIndex = 66;
			this.label18.Text = "N";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(92, 4);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(12, 16);
			this.label20.TabIndex = 64;
			this.label20.Text = "2";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(92, 20);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(12, 16);
			this.label21.TabIndex = 63;
			this.label21.Text = "P";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(76, 4);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(12, 16);
			this.label23.TabIndex = 61;
			this.label23.Text = "3";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label24
			// 
			this.label24.Location = new System.Drawing.Point(76, 20);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(12, 16);
			this.label24.TabIndex = 60;
			this.label24.Text = "3";
			this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(52, 4);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(12, 16);
			this.label8.TabIndex = 58;
			this.label8.Text = "4";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(52, 20);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 16);
			this.label9.TabIndex = 57;
			this.label9.Text = "H";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(36, 4);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(12, 16);
			this.label11.TabIndex = 55;
			this.label11.Text = "5";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(36, 20);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(12, 16);
			this.label12.TabIndex = 54;
			this.label12.Text = "5";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(20, 4);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 16);
			this.label5.TabIndex = 52;
			this.label5.Text = "6";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(12, 16);
			this.label2.TabIndex = 49;
			this.label2.Text = "7";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(12, 16);
			this.label1.TabIndex = 48;
			this.label1.Text = "S";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(108, 4);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(12, 16);
			this.label17.TabIndex = 67;
			this.label17.Text = "1";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(20, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(12, 16);
			this.label3.TabIndex = 71;
			this.label3.Text = "Z";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LabelFlag
			// 
			InitializeMyComponents();
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblFlag);
			this.Name = "LabelFlag";
			this.Size = new System.Drawing.Size(140, 64);
			this.ResumeLayout(false);

		}
		#endregion


		private void InitializeMyComponents()
		{
			this.lblBits = new System.Windows.Forms.Label[8];

			for (int n = 0; n < 8; n++)
			{
				this.lblBits[7-n] = new System.Windows.Forms.Label();
				this.lblBits[7-n].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
				this.lblBits[7-n].Name = "lblBits" + n.ToString();
				this.lblBits[7-n].Size = new System.Drawing.Size(12, 16);
				this.lblBits[7-n].TabIndex = n;
				this.lblBits[7-n].Text = "0";
				this.lblBits[7-n].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				this.lblBits[7-n].Location = new System.Drawing.Point(4 + n * 16 + (n < 4 ? 0 : 8), 44);

				this.Controls.Add(this.lblBits[7-n]);

			}
		}
	

		/// <summary>
		/// Value of Flag (F) register
		/// </summary>
		public byte Value
		{
			get
			{
				int retVal = 0;
				for (int n = 0; n < 8; n++)
					retVal |= lblBits[n].Text == "1" ? 1 << n : 0;
				return (byte) retVal;
			}
			set
			{
				for (int n = 0; n < 8; n++)
					lblBits[n].Text = (value & (1 << n)) != 0 ? "1" : "0";
			}
		}
	
	}


}
