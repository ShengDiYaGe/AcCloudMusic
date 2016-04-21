using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSE
{
	/// <summary>
	/// Summary description for frmShowStatus.
	/// </summary>
	public class frmShowStatus : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblDescrizione2;
		private System.Windows.Forms.Label lblDescrizione3;
		private System.Windows.Forms.Label lblDescrizione4;
		private System.Windows.Forms.Label lblAF;
		private System.Windows.Forms.Label lblBC;
		private System.Windows.Forms.Label lblDE;
		private System.Windows.Forms.Label lblHL;
		private CSE.LabelRegister lblRegHL;
		private CSE.LabelRegister lblRegDE;
		private CSE.LabelRegister lblRegBC;
		private CSE.LabelRegister lblRegAF;
		private CSE.LabelFlag lblFlag;
		private System.Windows.Forms.Label lblF;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblF_;
		private CSE.LabelRegister lblRegHL_;
		private System.Windows.Forms.Label lblHL_;
		private CSE.LabelRegister lblRegDE_;
		private System.Windows.Forms.Label lblDE_;
		private CSE.LabelRegister lblRegBC_;
		private System.Windows.Forms.Label lblBC_;
		private CSE.LabelRegister lblRegAF_;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblAF_;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label9;
		private CSE.LabelNumber lblI;
		private System.Windows.Forms.Label label10;
		private CSE.LabelNumber lblR;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label lblIFF1;
		private System.Windows.Forms.Label lblIFF2;
		private System.Windows.Forms.Label label15;
		private CSE.LabelNumber lblPC;
		private CSE.LabelNumber lblSP;
		private CSE.LabelNumber lbl_SP_;
		private CSE.LabelNumber lbl_SP1_;
		private System.Windows.Forms.Label lbl_PC_;
		private CSE.LabelNumber lblIY;
		private CSE.LabelNumber lblIX;
		private System.Windows.Forms.Label lblIM;
		private System.Windows.Forms.ToolTip toolTip;
		private CSE.LabelFlag lblFlag_;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Standard class creator
		/// </summary>
		public frmShowStatus()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Fetch Handler for this instance
			FetchHandler = new Z80.uP.OnFetchHandler(_Z80_OnFetch);
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
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblF = new System.Windows.Forms.Label();
			this.lblFlag = new CSE.LabelFlag();
			this.lblRegHL = new CSE.LabelRegister();
			this.lblHL = new System.Windows.Forms.Label();
			this.lblRegDE = new CSE.LabelRegister();
			this.lblDE = new System.Windows.Forms.Label();
			this.lblRegBC = new CSE.LabelRegister();
			this.lblBC = new System.Windows.Forms.Label();
			this.lblRegAF = new CSE.LabelRegister();
			this.lblDescrizione4 = new System.Windows.Forms.Label();
			this.lblDescrizione3 = new System.Windows.Forms.Label();
			this.lblDescrizione2 = new System.Windows.Forms.Label();
			this.lblAF = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblF_ = new System.Windows.Forms.Label();
			this.lblFlag_ = new CSE.LabelFlag();
			this.lblRegHL_ = new CSE.LabelRegister();
			this.lblHL_ = new System.Windows.Forms.Label();
			this.lblRegDE_ = new CSE.LabelRegister();
			this.lblDE_ = new System.Windows.Forms.Label();
			this.lblRegBC_ = new CSE.LabelRegister();
			this.lblBC_ = new System.Windows.Forms.Label();
			this.lblRegAF_ = new CSE.LabelRegister();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblAF_ = new System.Windows.Forms.Label();
			this.lblPC = new CSE.LabelNumber();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblSP = new CSE.LabelNumber();
			this.label3 = new System.Windows.Forms.Label();
			this.lbl_SP_ = new CSE.LabelNumber();
			this.lbl_SP1_ = new CSE.LabelNumber();
			this.label4 = new System.Windows.Forms.Label();
			this.lbl_PC_ = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblIY = new CSE.LabelNumber();
			this.label9 = new System.Windows.Forms.Label();
			this.lblIX = new CSE.LabelNumber();
			this.lblI = new CSE.LabelNumber();
			this.label10 = new System.Windows.Forms.Label();
			this.lblR = new CSE.LabelNumber();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lblIFF1 = new System.Windows.Forms.Label();
			this.lblIFF2 = new System.Windows.Forms.Label();
			this.lblIM = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblF);
			this.groupBox1.Controls.Add(this.lblFlag);
			this.groupBox1.Controls.Add(this.lblRegHL);
			this.groupBox1.Controls.Add(this.lblHL);
			this.groupBox1.Controls.Add(this.lblRegDE);
			this.groupBox1.Controls.Add(this.lblDE);
			this.groupBox1.Controls.Add(this.lblRegBC);
			this.groupBox1.Controls.Add(this.lblBC);
			this.groupBox1.Controls.Add(this.lblRegAF);
			this.groupBox1.Controls.Add(this.lblDescrizione4);
			this.groupBox1.Controls.Add(this.lblDescrizione3);
			this.groupBox1.Controls.Add(this.lblDescrizione2);
			this.groupBox1.Controls.Add(this.lblAF);
			this.groupBox1.Location = new System.Drawing.Point(8, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(184, 204);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Main registers";
			// 
			// lblF
			// 
			this.lblF.Location = new System.Drawing.Point(12, 136);
			this.lblF.Name = "lblF";
			this.lblF.Size = new System.Drawing.Size(20, 16);
			this.lblF.TabIndex = 12;
			this.lblF.Text = "F";
			// 
			// lblFlag
			// 
			this.lblFlag.Location = new System.Drawing.Point(36, 132);
			this.lblFlag.Name = "lblFlag";
			this.lblFlag.Size = new System.Drawing.Size(140, 64);
			this.lblFlag.TabIndex = 11;
			this.lblFlag.Value = ((System.Byte)(0));
			// 
			// lblRegHL
			// 
			this.lblRegHL.Location = new System.Drawing.Point(68, 104);
			this.lblRegHL.Name = "lblRegHL";
			this.lblRegHL.Size = new System.Drawing.Size(108, 16);
			this.lblRegHL.TabIndex = 10;
			this.lblRegHL.Value = 52428;
			// 
			// lblHL
			// 
			this.lblHL.Location = new System.Drawing.Point(12, 104);
			this.lblHL.Name = "lblHL";
			this.lblHL.Size = new System.Drawing.Size(36, 16);
			this.lblHL.TabIndex = 9;
			this.lblHL.Text = "HL";
			// 
			// lblRegDE
			// 
			this.lblRegDE.Location = new System.Drawing.Point(68, 84);
			this.lblRegDE.Name = "lblRegDE";
			this.lblRegDE.Size = new System.Drawing.Size(108, 16);
			this.lblRegDE.TabIndex = 8;
			this.lblRegDE.Value = 52428;
			// 
			// lblDE
			// 
			this.lblDE.Location = new System.Drawing.Point(12, 84);
			this.lblDE.Name = "lblDE";
			this.lblDE.Size = new System.Drawing.Size(36, 16);
			this.lblDE.TabIndex = 7;
			this.lblDE.Text = "DE";
			// 
			// lblRegBC
			// 
			this.lblRegBC.Location = new System.Drawing.Point(68, 64);
			this.lblRegBC.Name = "lblRegBC";
			this.lblRegBC.Size = new System.Drawing.Size(108, 16);
			this.lblRegBC.TabIndex = 6;
			this.lblRegBC.Value = 52428;
			// 
			// lblBC
			// 
			this.lblBC.Location = new System.Drawing.Point(12, 64);
			this.lblBC.Name = "lblBC";
			this.lblBC.Size = new System.Drawing.Size(36, 16);
			this.lblBC.TabIndex = 5;
			this.lblBC.Text = "BC";
			// 
			// lblRegAF
			// 
			this.lblRegAF.Location = new System.Drawing.Point(68, 44);
			this.lblRegAF.Name = "lblRegAF";
			this.lblRegAF.Size = new System.Drawing.Size(108, 16);
			this.lblRegAF.TabIndex = 4;
			this.lblRegAF.Value = 52428;
			// 
			// lblDescrizione4
			// 
			this.lblDescrizione4.Location = new System.Drawing.Point(148, 24);
			this.lblDescrizione4.Name = "lblDescrizione4";
			this.lblDescrizione4.Size = new System.Drawing.Size(28, 16);
			this.lblDescrizione4.TabIndex = 3;
			this.lblDescrizione4.Text = "wd";
			this.lblDescrizione4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDescrizione3
			// 
			this.lblDescrizione3.Location = new System.Drawing.Point(92, 24);
			this.lblDescrizione3.Name = "lblDescrizione3";
			this.lblDescrizione3.Size = new System.Drawing.Size(28, 16);
			this.lblDescrizione3.TabIndex = 2;
			this.lblDescrizione3.Text = "l";
			this.lblDescrizione3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblDescrizione2
			// 
			this.lblDescrizione2.Location = new System.Drawing.Point(60, 24);
			this.lblDescrizione2.Name = "lblDescrizione2";
			this.lblDescrizione2.Size = new System.Drawing.Size(28, 16);
			this.lblDescrizione2.TabIndex = 1;
			this.lblDescrizione2.Text = "h";
			this.lblDescrizione2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblAF
			// 
			this.lblAF.Location = new System.Drawing.Point(12, 44);
			this.lblAF.Name = "lblAF";
			this.lblAF.Size = new System.Drawing.Size(36, 16);
			this.lblAF.TabIndex = 0;
			this.lblAF.Text = "AF";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblF_);
			this.groupBox2.Controls.Add(this.lblFlag_);
			this.groupBox2.Controls.Add(this.lblRegHL_);
			this.groupBox2.Controls.Add(this.lblHL_);
			this.groupBox2.Controls.Add(this.lblRegDE_);
			this.groupBox2.Controls.Add(this.lblDE_);
			this.groupBox2.Controls.Add(this.lblRegBC_);
			this.groupBox2.Controls.Add(this.lblBC_);
			this.groupBox2.Controls.Add(this.lblRegAF_);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.lblAF_);
			this.groupBox2.Location = new System.Drawing.Point(208, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(184, 204);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Alternate registers";
			// 
			// lblF_
			// 
			this.lblF_.Location = new System.Drawing.Point(12, 136);
			this.lblF_.Name = "lblF_";
			this.lblF_.Size = new System.Drawing.Size(20, 16);
			this.lblF_.TabIndex = 12;
			this.lblF_.Text = "F\'";
			// 
			// lblFlag_
			// 
			this.lblFlag_.Location = new System.Drawing.Point(36, 132);
			this.lblFlag_.Name = "lblFlag_";
			this.lblFlag_.Size = new System.Drawing.Size(140, 64);
			this.lblFlag_.TabIndex = 11;
			this.lblFlag_.Value = ((System.Byte)(0));
			// 
			// lblRegHL_
			// 
			this.lblRegHL_.Location = new System.Drawing.Point(68, 104);
			this.lblRegHL_.Name = "lblRegHL_";
			this.lblRegHL_.Size = new System.Drawing.Size(108, 16);
			this.lblRegHL_.TabIndex = 10;
			this.lblRegHL_.Value = 52428;
			// 
			// lblHL_
			// 
			this.lblHL_.Location = new System.Drawing.Point(12, 104);
			this.lblHL_.Name = "lblHL_";
			this.lblHL_.Size = new System.Drawing.Size(36, 16);
			this.lblHL_.TabIndex = 9;
			this.lblHL_.Text = "HL\'";
			// 
			// lblRegDE_
			// 
			this.lblRegDE_.Location = new System.Drawing.Point(68, 84);
			this.lblRegDE_.Name = "lblRegDE_";
			this.lblRegDE_.Size = new System.Drawing.Size(108, 16);
			this.lblRegDE_.TabIndex = 8;
			this.lblRegDE_.Value = 52428;
			// 
			// lblDE_
			// 
			this.lblDE_.Location = new System.Drawing.Point(12, 84);
			this.lblDE_.Name = "lblDE_";
			this.lblDE_.Size = new System.Drawing.Size(36, 16);
			this.lblDE_.TabIndex = 7;
			this.lblDE_.Text = "DE\'";
			// 
			// lblRegBC_
			// 
			this.lblRegBC_.Location = new System.Drawing.Point(68, 64);
			this.lblRegBC_.Name = "lblRegBC_";
			this.lblRegBC_.Size = new System.Drawing.Size(108, 16);
			this.lblRegBC_.TabIndex = 6;
			this.lblRegBC_.Value = 52428;
			// 
			// lblBC_
			// 
			this.lblBC_.Location = new System.Drawing.Point(12, 64);
			this.lblBC_.Name = "lblBC_";
			this.lblBC_.Size = new System.Drawing.Size(36, 16);
			this.lblBC_.TabIndex = 5;
			this.lblBC_.Text = "BC\'";
			// 
			// lblRegAF_
			// 
			this.lblRegAF_.Location = new System.Drawing.Point(68, 44);
			this.lblRegAF_.Name = "lblRegAF_";
			this.lblRegAF_.Size = new System.Drawing.Size(108, 16);
			this.lblRegAF_.TabIndex = 4;
			this.lblRegAF_.Value = 52428;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(148, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(28, 16);
			this.label6.TabIndex = 3;
			this.label6.Text = "wd";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(92, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(28, 16);
			this.label7.TabIndex = 2;
			this.label7.Text = "l";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(60, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(28, 16);
			this.label8.TabIndex = 1;
			this.label8.Text = "h";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblAF_
			// 
			this.lblAF_.Location = new System.Drawing.Point(12, 44);
			this.lblAF_.Name = "lblAF_";
			this.lblAF_.Size = new System.Drawing.Size(36, 16);
			this.lblAF_.TabIndex = 0;
			this.lblAF_.Text = "AF\'";
			// 
			// lblPC
			// 
			this.lblPC.Digits = 4;
			this.lblPC.Location = new System.Drawing.Point(52, 228);
			this.lblPC.Name = "lblPC";
			this.lblPC.Size = new System.Drawing.Size(40, 16);
			this.lblPC.TabIndex = 2;
			this.lblPC.Value = 52428;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 228);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(36, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "PC";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 252);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "SP";
			// 
			// lblSP
			// 
			this.lblSP.Digits = 4;
			this.lblSP.Location = new System.Drawing.Point(52, 252);
			this.lblSP.Name = "lblSP";
			this.lblSP.Size = new System.Drawing.Size(40, 16);
			this.lblSP.TabIndex = 4;
			this.lblSP.Value = 52428;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(116, 252);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "(SP)";
			// 
			// lbl_SP_
			// 
			this.lbl_SP_.Digits = 2;
			this.lbl_SP_.Location = new System.Drawing.Point(152, 252);
			this.lbl_SP_.Name = "lbl_SP_";
			this.lbl_SP_.Size = new System.Drawing.Size(24, 16);
			this.lbl_SP_.TabIndex = 7;
			this.lbl_SP_.Value = 204;
			// 
			// lbl_SP1_
			// 
			this.lbl_SP1_.Digits = 2;
			this.lbl_SP1_.Location = new System.Drawing.Point(240, 252);
			this.lbl_SP1_.Name = "lbl_SP1_";
			this.lbl_SP1_.Size = new System.Drawing.Size(24, 16);
			this.lbl_SP1_.TabIndex = 9;
			this.lbl_SP1_.Value = 204;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(200, 252);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "(SP+1)";
			// 
			// lbl_PC_
			// 
			this.lbl_PC_.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lbl_PC_.Location = new System.Drawing.Point(116, 228);
			this.lbl_PC_.Name = "lbl_PC_";
			this.lbl_PC_.Size = new System.Drawing.Size(148, 16);
			this.lbl_PC_.TabIndex = 10;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(312, 252);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 16);
			this.label5.TabIndex = 14;
			this.label5.Text = "IY";
			// 
			// lblIY
			// 
			this.lblIY.Digits = 4;
			this.lblIY.Location = new System.Drawing.Point(352, 252);
			this.lblIY.Name = "lblIY";
			this.lblIY.Size = new System.Drawing.Size(40, 16);
			this.lblIY.TabIndex = 13;
			this.lblIY.Value = 52428;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(312, 228);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(36, 16);
			this.label9.TabIndex = 12;
			this.label9.Text = "IX";
			// 
			// lblIX
			// 
			this.lblIX.Digits = 4;
			this.lblIX.Location = new System.Drawing.Point(352, 228);
			this.lblIX.Name = "lblIX";
			this.lblIX.Size = new System.Drawing.Size(40, 16);
			this.lblIX.TabIndex = 11;
			this.lblIX.Value = 52428;
			// 
			// lblI
			// 
			this.lblI.Digits = 2;
			this.lblI.Location = new System.Drawing.Point(308, 288);
			this.lblI.Name = "lblI";
			this.lblI.Size = new System.Drawing.Size(24, 16);
			this.lblI.TabIndex = 18;
			this.lblI.Value = 204;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(292, 288);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(20, 16);
			this.label10.TabIndex = 17;
			this.label10.Text = "I";
			// 
			// lblR
			// 
			this.lblR.Digits = 2;
			this.lblR.Location = new System.Drawing.Point(364, 288);
			this.lblR.Name = "lblR";
			this.lblR.Size = new System.Drawing.Size(24, 16);
			this.lblR.TabIndex = 20;
			this.lblR.Value = 204;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(348, 288);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(20, 16);
			this.label11.TabIndex = 19;
			this.label11.Text = "R";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(16, 288);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(36, 16);
			this.label12.TabIndex = 21;
			this.label12.Text = "IFF1";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(68, 288);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(36, 16);
			this.label13.TabIndex = 22;
			this.label13.Text = "IFF2";
			// 
			// lblIFF1
			// 
			this.lblIFF1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblIFF1.Location = new System.Drawing.Point(44, 288);
			this.lblIFF1.Name = "lblIFF1";
			this.lblIFF1.Size = new System.Drawing.Size(16, 16);
			this.lblIFF1.TabIndex = 23;
			// 
			// lblIFF2
			// 
			this.lblIFF2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblIFF2.Location = new System.Drawing.Point(96, 288);
			this.lblIFF2.Name = "lblIFF2";
			this.lblIFF2.Size = new System.Drawing.Size(16, 16);
			this.lblIFF2.TabIndex = 24;
			// 
			// lblIM
			// 
			this.lblIM.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblIM.Location = new System.Drawing.Point(172, 288);
			this.lblIM.Name = "lblIM";
			this.lblIM.Size = new System.Drawing.Size(16, 16);
			this.lblIM.TabIndex = 26;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(144, 288);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(36, 16);
			this.label15.TabIndex = 25;
			this.label15.Text = "IM";
			// 
			// frmShowStatus
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 314);
			this.Controls.Add(this.lblIM);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.lblIFF2);
			this.Controls.Add(this.lblIFF1);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.lblR);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.lblI);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lblIY);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.lblIX);
			this.Controls.Add(this.lbl_PC_);
			this.Controls.Add(this.lbl_SP1_);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lbl_SP_);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblSP);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblPC);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "frmShowStatus";
			this.Text = "Z80 Status";
			this.Closed += new System.EventHandler(this.frmShowStatus_Closed);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private Z80.uP _Z80;
		private Z80.uP.OnFetchHandler FetchHandler;
		private Z80.Z80Disassembler _Disassembler = new Z80.Z80Disassembler();

		/// <summary>
		/// Status (used during refresh)
		/// </summary>
		public Z80.Status Status
		{
			get
			{
				return _Z80.Status;
			}
		}

		/// <summary>
		/// Memory (used during refresh)
		/// </summary>
		public Z80.IMemory Memory
		{
			get
			{
				return _Disassembler.Memory;
			}
		}

		/// <summary>
		/// Processor. During set the event OnFetch is catched to perform automatic refresh
		/// </summary>
		public Z80.uP Z80
		{
			get
			{
				return _Z80;
			}
			set
			{
				// Check if there is an old fetch handler
				if (_Z80 != null)
					_Z80.OnFetch -= FetchHandler;

				// Change the uP that's going to be monitored
				_Z80 = value;

				if (value != null)
				{
					// Catch the event with the fetch handler
					_Z80.OnFetch += FetchHandler;

					// Set the memory to disassemble
					_Disassembler.Memory = _Z80.Memory;
				}
			}
		}


		/// <summary>
		/// Show Z80 Status. It should not be called because the state is refreshed on each fetch.
		/// Class Z80 raise the OnFetch event and the OnFetch event calls this.
		/// </summary>
		public void RefreshOutput()
		{
			lblRegAF.Value = Status.AF;
			lblRegBC.Value = Status.BC;
			lblRegDE.Value = Status.DE;
			lblRegHL.Value = Status.HL;

			lblFlag.Value = Status.F;

			lblRegAF_.Value = Status.RegisterAF_.w;
			lblRegBC_.Value = Status.RegisterBC_.w;
			lblRegDE_.Value = Status.RegisterDE_.w;
			lblRegHL_.Value = Status.RegisterHL_.w;

			lblFlag_.Value = Status.RegisterAF_.l.Value;


			lblPC.Value = Status.PC;
			lblSP.Value = Status.SP;

			lblIX.Value = Status.IX;
			lblIY.Value = Status.IY;

			lblIFF1.Text = Status.IFF1 ? "1" : "0";
			lblIFF2.Text = Status.IFF2 ? "1" : "0";

			lblIM.Text = Status.IM.ToString();

			lblI.Value = Status.I;
			lblR.Value = Status.R;

			lbl_SP_.Value = Memory.ReadByte(Status.SP);
			lbl_SP1_.Value = Memory.ReadByte((ushort) (Status.SP + 1));

			string disassembly = "";
			ushort disassemblyAddress = Status.PC;

			disassembly = _Disassembler.Disassemble(ref disassemblyAddress);
			lbl_PC_.Text = disassembly;

			for (int i = 0; i < 10; i++)
				disassembly += "\n" + _Disassembler.Disassemble(ref disassemblyAddress);

			toolTip.SetToolTip(lbl_PC_, disassembly);

		}

		/// <summary>
		/// Raised when a new instruction in performed
		/// </summary>
		private void _Z80_OnFetch()
		{
			RefreshOutput();
		}

		private void frmShowStatus_Closed(object sender, System.EventArgs e)
		{
			// Release the OnFetch handler
			if (_Z80 != null)
				_Z80.OnFetch -= FetchHandler;

		}
	}
}
