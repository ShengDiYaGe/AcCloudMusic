namespace SoundStudioCS
{
    partial class SoundStudioFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundStudioFrm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ctlVolume = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.peakMeterCtrl1 = new Ernzo.WinForms.Controls.PeakMeterCtrl();
            this.btnMute = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ctlVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtFilePath
            // 
            resources.ApplyResources(this.txtFilePath, "txtFilePath");
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openDialog
            // 
            resources.ApplyResources(this.openDialog, "openDialog");
            // 
            // btnQuit
            // 
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnQuit.Image = global::SoundStudioCS.Properties.Resources.exit;
            resources.ApplyResources(this.btnQuit, "btnQuit");
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = global::SoundStudioCS.Properties.Resources.stop;
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Image = global::SoundStudioCS.Properties.Resources.play;
            resources.ApplyResources(this.btnPlay, "btnPlay");
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // ctlVolume
            // 
            resources.ApplyResources(this.ctlVolume, "ctlVolume");
            this.ctlVolume.Name = "ctlVolume";
            this.ctlVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ctlVolume.ValueChanged += new System.EventHandler(this.ctlVolume_ValueChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // peakMeterCtrl1
            // 
            this.peakMeterCtrl1.BandsCount = 19;
            this.peakMeterCtrl1.ColorHigh = System.Drawing.Color.Red;
            this.peakMeterCtrl1.ColorHighBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.peakMeterCtrl1.ColorMedium = System.Drawing.Color.Yellow;
            this.peakMeterCtrl1.ColorMediumBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(150)))));
            this.peakMeterCtrl1.ColorNormal = System.Drawing.Color.Green;
            this.peakMeterCtrl1.ColorNormalBack = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(150)))));
            this.peakMeterCtrl1.FalloffColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.peakMeterCtrl1.GridColor = System.Drawing.Color.Gainsboro;
            this.peakMeterCtrl1.LEDCount = 20;
            resources.ApplyResources(this.peakMeterCtrl1, "peakMeterCtrl1");
            this.peakMeterCtrl1.Name = "peakMeterCtrl1";
            // 
            // btnMute
            // 
            resources.ApplyResources(this.btnMute, "btnMute");
            this.btnMute.Image = global::SoundStudioCS.Properties.Resources.sound;
            this.btnMute.Name = "btnMute";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.CheckedChanged += new System.EventHandler(this.btnMute_CheckedChanged);
            // 
            // SoundStudioFrm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.peakMeterCtrl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctlVolume);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "SoundStudioFrm";
            this.Load += new System.EventHandler(this.SoundStudioFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctlVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar ctlVolume;
        private System.Windows.Forms.Label label3;
        private Ernzo.WinForms.Controls.PeakMeterCtrl peakMeterCtrl1;
        private System.Windows.Forms.CheckBox btnMute;
    }
}

