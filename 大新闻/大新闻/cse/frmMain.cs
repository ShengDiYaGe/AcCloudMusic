using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Spectrums.Spectrum48;

namespace CSE
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnDisassembly;
		private System.Windows.Forms.Button btnHex;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btn1Step;
		private System.Windows.Forms.Button btnStatus;
		private System.Windows.Forms.Button btnTrace;
		private System.Windows.Forms.Button btnDefaultIO;
		private System.Windows.Forms.Button btn1StepOver;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// 
		/// </summary>
		public Form1()
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
				if (components != null) 
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
			this.button1 = new System.Windows.Forms.Button();
			this.btnDisassembly = new System.Windows.Forms.Button();
			this.btnHex = new System.Windows.Forms.Button();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.btnRun = new System.Windows.Forms.Button();
			this.btn1Step = new System.Windows.Forms.Button();
			this.btnStatus = new System.Windows.Forms.Button();
			this.btnTrace = new System.Windows.Forms.Button();
			this.btnDefaultIO = new System.Windows.Forms.Button();
			this.btn1StepOver = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 260);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "Reset";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnDisassembly
			// 
			this.btnDisassembly.Location = new System.Drawing.Point(124, 308);
			this.btnDisassembly.Name = "btnDisassembly";
			this.btnDisassembly.Size = new System.Drawing.Size(80, 23);
			this.btnDisassembly.TabIndex = 2;
			this.btnDisassembly.Text = "Disassembly";
			this.btnDisassembly.Click += new System.EventHandler(this.button2_Click);
			// 
			// btnHex
			// 
			this.btnHex.Location = new System.Drawing.Point(124, 340);
			this.btnHex.Name = "btnHex";
			this.btnHex.Size = new System.Drawing.Size(80, 23);
			this.btnHex.TabIndex = 3;
			this.btnHex.Text = "Hex";
			this.btnHex.Click += new System.EventHandler(this.btnHex_Click);
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(4, 316);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.Size = new System.Drawing.Size(108, 20);
			this.txtAddress.TabIndex = 4;
			this.txtAddress.Text = "0";
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(232, 256);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(92, 24);
			this.btnRun.TabIndex = 5;
			this.btnRun.Text = "Run";
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// btn1Step
			// 
			this.btn1Step.Location = new System.Drawing.Point(232, 284);
			this.btn1Step.Name = "btn1Step";
			this.btn1Step.Size = new System.Drawing.Size(92, 20);
			this.btn1Step.TabIndex = 6;
			this.btn1Step.Text = "1 Step Into";
			this.btn1Step.Click += new System.EventHandler(this.btn1Step_Click);
			// 
			// btnStatus
			// 
			this.btnStatus.Location = new System.Drawing.Point(232, 348);
			this.btnStatus.Name = "btnStatus";
			this.btnStatus.Size = new System.Drawing.Size(72, 20);
			this.btnStatus.TabIndex = 7;
			this.btnStatus.Text = "Status";
			this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
			// 
			// btnTrace
			// 
			this.btnTrace.Location = new System.Drawing.Point(128, 396);
			this.btnTrace.Name = "btnTrace";
			this.btnTrace.Size = new System.Drawing.Size(72, 20);
			this.btnTrace.TabIndex = 8;
			this.btnTrace.Text = "Trace";
			this.btnTrace.Click += new System.EventHandler(this.btnTrace_Click);
			// 
			// btnDefaultIO
			// 
			this.btnDefaultIO.Location = new System.Drawing.Point(232, 400);
			this.btnDefaultIO.Name = "btnDefaultIO";
			this.btnDefaultIO.Size = new System.Drawing.Size(68, 24);
			this.btnDefaultIO.TabIndex = 9;
			this.btnDefaultIO.Text = "Default IO";
			this.btnDefaultIO.Click += new System.EventHandler(this.btnDefaultIO_Click);
			// 
			// btn1StepOver
			// 
			this.btn1StepOver.Location = new System.Drawing.Point(232, 308);
			this.btn1StepOver.Name = "btn1StepOver";
			this.btn1StepOver.Size = new System.Drawing.Size(92, 20);
			this.btn1StepOver.TabIndex = 10;
			this.btn1StepOver.Text = "1 Step Over";
			this.btn1StepOver.Click += new System.EventHandler(this.btn1StepOver_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(8, 12);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(324, 232);
			this.pictureBox2.TabIndex = 11;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(36, 28);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(256, 192);
			this.pictureBox1.TabIndex = 12;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(368, 546);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.btn1StepOver);
			this.Controls.Add(this.btnDefaultIO);
			this.Controls.Add(this.btnTrace);
			this.Controls.Add(this.btnStatus);
			this.Controls.Add(this.btn1Step);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.btnHex);
			this.Controls.Add(this.btnDisassembly);
			this.Controls.Add(this.button1);
			this.KeyPreview = true;
			this.Name = "Form1";
			this.Text = "Form1";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		Spectrum48 Speccy;

		private void button1_Click(object sender, System.EventArgs e)
		{
			SpeccyReset();
		}

		private void SpeccyReset()
		{
			pictureBox1.Image = new System.Drawing.Bitmap(pictureBox1.Width, pictureBox1.Height);

			Speccy = new Spectrums.Spectrum48.Spectrum48();
			Speccy.Video.DefaultOutputBitmap = (System.Drawing.Bitmap) pictureBox1.Image;
			Speccy.Video.BorderControl = pictureBox2;
			Speccy.Z80.Reset();
			//Speccy.Video.ReadFileSCR("C:\\Speccy\\Test.scr");
			//Speccy.Video.Refresh();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			frmShowMemoryDisassembly f = new frmShowMemoryDisassembly(Speccy.Memory, ushort.Parse(txtAddress.Text));
			f.Show();
		}

		private void btnHex_Click(object sender, System.EventArgs e)
		{
			frmShowMemory f = new frmShowMemory(Speccy.Memory, ushort.Parse(txtAddress.Text));
			f.Show();
		}


		private bool _Running = false;
		private System.Threading.Timer PowerCycles;
		private bool HandlingPowerCycle = false;
		private void btnRun_Click(object sender, System.EventArgs e)
		{
			// Is Speccy ready?
			if (Speccy == null)
				SpeccyReset();

			if (_Running)
			{
				// Disable Z80 run
				if (PowerCycles != null)
					PowerCycles.Dispose();
				PowerCycles = null;
				HandlingPowerCycle = false;

				_Running = false;
				btnRun.Text = "Run";
				return;
			}

			_Running = true;
			btnRun.Text = "Stop";
			

			// This is the monothread not sinchronized version
			/*
			while (_Running)
			{

				Speccy.Z80.Execute();
				Speccy.Video.Flash();
				Speccy.Z80.tstates -= Speccy.Z80.event_next_event;
				Speccy.Z80.Interrupt();
				System.Windows.Forms.Application.DoEvents();
				this.Refresh();
			}
			*/


			// This is the multithreaded sincronized version
			PowerCycles = new System.Threading.Timer(new System.Threading.TimerCallback(PowerCycleHandler), null, 0, 20);

		}

		/// <summary>
		/// Counter for flashing 2 times a second
		/// </summary>
		int FlashCounter = 0;
		private void PowerCycleHandler(object State)
		{

			// Just to be sure
			if (!_Running)
				return;
			
			lock(PowerCycles)
			{
				if (HandlingPowerCycle)
					return;

				HandlingPowerCycle = true;
			}			

			Speccy.Z80.Execute();
			
			FlashCounter++;
#warning Flash counter does not work
			if (FlashCounter >= 10)
			{
				FlashCounter = 0;
				Speccy.Video.Flash();
			}
			
			Speccy.Z80.tstates -= Speccy.Z80.event_next_event;
			Speccy.Z80.Interrupt();
			this.Refresh();
			
			// Check if the spectrum is stopped
			if (PowerCycles == null)
				return;
			
			// No more in PowerCycleHandler
			lock(PowerCycles)
			{
				HandlingPowerCycle = false;
			}
		}


		private void btn1Step_Click(object sender, System.EventArgs e)
		{
			Speccy.Z80.StatementsToFetch = 1;
			Speccy.Z80.Execute();
		}

		private void btnStatus_Click(object sender, System.EventArgs e)
		{
			frmShowStatus f = new frmShowStatus();
			f.Z80 = Speccy.Z80;
			f.Show();
			f.RefreshOutput();
		}

		private void btnTrace_Click(object sender, System.EventArgs e)
		{
			frmTraceStatus f = new frmTraceStatus();
			f.Z80 = Speccy.Z80;
			f.Show();
		}


		#region Keyboard handling

		private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (_Running)
				Speccy.IO.Keyboard.ParseKey(true, e);
		}

		private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (_Running)
				Speccy.IO.Keyboard.ParseKey(false, e);
		}

		#endregion


		#region Default IO form Handling
		
		private void btnDefaultIO_Click(object sender, System.EventArgs e)
		{
			if (Speccy.IO.DefaultIO != null)
				return;

			frmIO frmIO = new frmIO();
			frmIO.Closed += new EventHandler(frmIO_Closed);			
			
			Speccy.IO.DefaultIO = frmIO;
			frmIO.Show();
		}

		private void frmIO_Closed(object sender, EventArgs e)
		{
			// DefaultIO is not redirected to the form anymore
			Speccy.IO.DefaultIO = null;			
		}

		#endregion

		
		private void btn1StepOver_Click(object sender, System.EventArgs e)
		{
			Z80.Z80Disassembler disassembler = new Z80.Z80Disassembler(Speccy.Memory);
			ushort Address = Speccy.Z80.Status.PC;
			disassembler.Disassemble(ref Address);

			while (Speccy.Z80.Status.PC != Address)
			{
				// No event handling on step over
				Speccy.Z80.tstates = 0;
				
				Speccy.Z80.StatementsToFetch = 1;
				Speccy.Z80.Execute();

			}
		}

	}

}
