using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CSE
{
	/// <summary>
	/// This form implements an IO system to allow IO simulation on Z80
	/// </summary>
	public class frmIO : System.Windows.Forms.Form, Z80.IIO
	{

		private System.Windows.Forms.ListView lvwIO;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// Standard creator
		/// </summary>
		public frmIO()
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
			this.lvwIO = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// lvwIO
			// 
			this.lvwIO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																																						this.columnHeader1,
																																						this.columnHeader2,
																																						this.columnHeader3});
			this.lvwIO.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwIO.Location = new System.Drawing.Point(0, 0);
			this.lvwIO.Name = "lvwIO";
			this.lvwIO.Size = new System.Drawing.Size(532, 318);
			this.lvwIO.TabIndex = 0;
			this.lvwIO.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "IO";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Port";
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Value";
			// 
			// frmIO
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(532, 318);
			this.Controls.Add(this.lvwIO);
			this.KeyPreview = true;
			this.Name = "frmIO";
			this.Text = "frmDevices";
			this.ResumeLayout(false);

		}
		#endregion




		/// <summary>
		/// Reads a single byte from a port
		/// </summary>
		/// <param name="Address">Port address</param>
		/// <returns>The byte readed</returns>
		public byte ReadPort(ushort Address)
		{
			byte Value = 0xFF;

			ListViewItem lvwItem = new ListViewItem("In");
			lvwItem.SubItems.Add(Address.ToString("X4"));
			lvwItem.SubItems.Add(Value.ToString("X2"));
			lvwIO.Items.Add(lvwItem);
			return Value;
		}

		/// <summary>
		/// Writes a single byte to a port
		/// </summary>
		/// <param name="Address">Port address</param>
		/// <param name="Value">The byte readed</param>
		public void WritePort(ushort Address, byte Value)
		{
			ListViewItem lvwItem = new ListViewItem("Out");
			lvwItem.SubItems.Add(Address.ToString("X4"));
			lvwItem.SubItems.Add(Value.ToString("X2"));
			lvwIO.Items.Add(lvwItem);
		}

	
	}
}
