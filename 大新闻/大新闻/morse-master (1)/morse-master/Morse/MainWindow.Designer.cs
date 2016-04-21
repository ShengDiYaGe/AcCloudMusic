namespace Morse
{
    sealed partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.displayWord = new System.Windows.Forms.Label();
            this.inputField = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.resultIcon = new System.Windows.Forms.PictureBox();
            this.currentLevel = new System.Windows.Forms.Label();
            this.mainWindowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.resultIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // displayWord
            // 
            this.displayWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayWord.Location = new System.Drawing.Point(10, 12);
            this.displayWord.Name = "displayWord";
            this.displayWord.Size = new System.Drawing.Size(601, 221);
            this.displayWord.TabIndex = 0;
            this.displayWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inputField
            // 
            this.inputField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputField.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputField.Location = new System.Drawing.Point(95, 290);
            this.inputField.Name = "inputField";
            this.inputField.Size = new System.Drawing.Size(434, 62);
            this.inputField.TabIndex = 1;
            this.inputField.TextChanged += new System.EventHandler(this.inputField_TextChanged);
            this.inputField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputField_KeyDown);
            // 
            // enterButton
            // 
            this.enterButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterButton.Location = new System.Drawing.Point(248, 369);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(129, 56);
            this.enterButton.TabIndex = 2;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // resultIcon
            // 
            this.resultIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.resultIcon.Location = new System.Drawing.Point(545, 290);
            this.resultIcon.Name = "resultIcon";
            this.resultIcon.Size = new System.Drawing.Size(64, 64);
            this.resultIcon.TabIndex = 3;
            this.resultIcon.TabStop = false;
            // 
            // currentLevel
            // 
            this.currentLevel.AutoSize = true;
            this.currentLevel.Location = new System.Drawing.Point(12, 415);
            this.currentLevel.Name = "currentLevel";
            this.currentLevel.Size = new System.Drawing.Size(0, 13);
            this.currentLevel.TabIndex = 4;
            // 
            // mainWindowBindingSource
            // 
            this.mainWindowBindingSource.DataSource = typeof(Morse.MainWindow);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(624, 437);
            this.Controls.Add(this.currentLevel);
            this.Controls.Add(this.resultIcon);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.inputField);
            this.Controls.Add(this.displayWord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Morse Trainer";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainWindowBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label displayWord;
        private System.Windows.Forms.TextBox inputField;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.PictureBox resultIcon;
        private System.Windows.Forms.Label currentLevel;
        private System.Windows.Forms.BindingSource mainWindowBindingSource;
    }
}

