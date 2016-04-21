using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSE
{
	/// <summary>
	/// Summary description for frmTraceStatus.
	/// </summary>
	public class frmTraceStatus : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		/// <summary>
		/// Class for Z80 disassembly
		/// </summary>
		private Z80.Z80Disassembler _Disassembler = new Z80.Z80Disassembler();

		/// <summary>
		/// Z80 to trace status
		/// </summary>
		private Z80.uP _Z80;

		
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ListView lvwTrace;



		/// <summary>
		/// Standard form creator
		/// </summary>
		public frmTraceStatus()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.lvwTrace = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwTrace
			// 
			this.lvwTrace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																																							 this.columnHeader1,
																																							 this.columnHeader2,
																																							 this.columnHeader3,
																																							 this.columnHeader4,
																																							 this.columnHeader5,
																																							 this.columnHeader6,
																																							 this.columnHeader7,
																																							 this.columnHeader8,
																																							 this.columnHeader9,
																																							 this.columnHeader10,
																																							 this.columnHeader11,
																																							 this.columnHeader12,
																																							 this.columnHeader13});
			this.lvwTrace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwTrace.FullRowSelect = true;
			this.lvwTrace.Location = new System.Drawing.Point(0, 0);
			this.lvwTrace.MultiSelect = false;
			this.lvwTrace.Name = "lvwTrace";
			this.lvwTrace.Size = new System.Drawing.Size(336, 294);
			this.lvwTrace.TabIndex = 0;
			this.lvwTrace.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "PC";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Statement";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "AF";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "BC";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "DE";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "HL";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "AF\'";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "BC\'";
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "DE\'";
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "HL\'";
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "SP";
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "IX";
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "IY";
			// 
			// frmTraceStatus
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(336, 294);
			this.Controls.Add(this.lvwTrace);
			this.Name = "frmTraceStatus";
			this.Text = "frmTraceStatus";
			this.Load += new System.EventHandler(this.frmTraceStatus_Load);
			this.Closed += new System.EventHandler(this.frmTraceStatus_Closed);
			this.ResumeLayout(false);

		}
		#endregion



		/// <summary>
		/// Z80 to trace. Must be setted after creation before FormLoad
		/// </summary>
		public Z80.uP Z80
		{
			get
			{
				return _Z80;
			}
			set
			{
				_Z80 = value;
				_Disassembler.Memory = _Z80.Memory;
			}
		}


		Z80.uP.OnFetchHandler FetchHandler;
		private void frmTraceStatus_Load(object sender, System.EventArgs e)
		{
			FetchHandler = new Z80.uP.OnFetchHandler(_Z80_OnFetch);
			_Z80.OnFetch += FetchHandler;
		}

		private void frmTraceStatus_Closed(object sender, System.EventArgs e)
		{
			_Z80.OnFetch -= FetchHandler;
		}


		private void _Z80_OnFetch()
		{
			ushort Address = _Z80.Status.PC;
			ListViewItem lvwItem = new ListViewItem(_Z80.Status.PC.ToString("X4"));
			lvwItem.SubItems.Add(_Disassembler.Disassemble(ref Address));
			lvwItem.SubItems.Add(_Z80.Status.RegisterAF.w.ToString("X4"));
			lvwItem.SubItems.Add(_Z80.Status.RegisterBC.w.ToString("X4"));
			lvwItem.SubItems.Add(_Z80.Status.RegisterDE.w.ToString("X4"));
			lvwItem.SubItems.Add(_Z80.Status.RegisterHL.w.ToString("X4"));
			lvwItem.SubItems.Add(_Z80.Status.RegisterAF_.w.ToString("X4"));
			lvwItem.SubItems.Add(_Z80.Status.RegisterBC_.w.ToString("X4"));
			lvwItem.SubItems.Add(_Z80.Status.RegisterDE_.w.ToString("X4"));
			lvwItem.SubItems.Add(_Z80.Status.RegisterHL_.w.ToString("X4"));
			lvwItem.SubItems.Add(_Z80.Status.SP.ToString("X4"));
			lvwItem.SubItems.Add(_Z80.Status.IX.ToString("X4"));
			lvwItem.SubItems.Add(_Z80.Status.IY.ToString("X4"));
			lvwTrace.Items.Add(lvwItem);
			lvwItem.EnsureVisible();
		}
	}
}
