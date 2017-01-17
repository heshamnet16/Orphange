namespace OrphanageClient
{
    partial class frmCam
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbVideoSize = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFrame = new System.Windows.Forms.Button();
            this.cmbVideoDevices = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.numFrameRate = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTimerStart = new System.Windows.Forms.Button();
            this.btnTimerStop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameRate)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(271, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 233);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cmbVideoSize
            // 
            this.cmbVideoSize.FormattingEnabled = true;
            this.cmbVideoSize.Items.AddRange(new object[] {
            "120*90",
            "160*120",
            "180*135",
            "240*180",
            "280*210",
            "320*240",
            "360*270",
            "400*300",
            "440*330",
            "480*360",
            "520*390",
            "560*420",
            "600*450",
            "640*480",
            "720*540",
            "800*600",
            "1024*768"});
            this.cmbVideoSize.Location = new System.Drawing.Point(94, 37);
            this.cmbVideoSize.Name = "cmbVideoSize";
            this.cmbVideoSize.Size = new System.Drawing.Size(109, 21);
            this.cmbVideoSize.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(15, 164);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(107, 164);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Vedio Size:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 100);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(108, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Use Copmerssion";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(118, 128);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Comperssion Ratio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "%";
            // 
            // btnFrame
            // 
            this.btnFrame.Enabled = false;
            this.btnFrame.Location = new System.Drawing.Point(16, 222);
            this.btnFrame.Name = "btnFrame";
            this.btnFrame.Size = new System.Drawing.Size(167, 23);
            this.btnFrame.TabIndex = 2;
            this.btnFrame.Text = "Get a Frame";
            this.btnFrame.UseVisualStyleBackColor = true;
            this.btnFrame.Click += new System.EventHandler(this.btnFrame_Click);
            // 
            // cmbVideoDevices
            // 
            this.cmbVideoDevices.FormattingEnabled = true;
            this.cmbVideoDevices.Location = new System.Drawing.Point(94, 6);
            this.cmbVideoDevices.Name = "cmbVideoDevices";
            this.cmbVideoDevices.Size = new System.Drawing.Size(109, 21);
            this.cmbVideoDevices.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Vedio devices:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Referesh Rate:";
            // 
            // numFrameRate
            // 
            this.numFrameRate.DecimalPlaces = 2;
            this.numFrameRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numFrameRate.Location = new System.Drawing.Point(94, 69);
            this.numFrameRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numFrameRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numFrameRate.Name = "numFrameRate";
            this.numFrameRate.Size = new System.Drawing.Size(74, 20);
            this.numFrameRate.TabIndex = 7;
            this.numFrameRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numFrameRate.ValueChanged += new System.EventHandler(this.numFrameRate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sec";
            // 
            // btnTimerStart
            // 
            this.btnTimerStart.Enabled = false;
            this.btnTimerStart.Location = new System.Drawing.Point(15, 193);
            this.btnTimerStart.Name = "btnTimerStart";
            this.btnTimerStart.Size = new System.Drawing.Size(75, 23);
            this.btnTimerStart.TabIndex = 3;
            this.btnTimerStart.Text = "Start Timer";
            this.btnTimerStart.UseVisualStyleBackColor = true;
            this.btnTimerStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTimerStop
            // 
            this.btnTimerStop.Enabled = false;
            this.btnTimerStop.Location = new System.Drawing.Point(107, 193);
            this.btnTimerStop.Name = "btnTimerStop";
            this.btnTimerStop.Size = new System.Drawing.Size(75, 23);
            this.btnTimerStop.TabIndex = 4;
            this.btnTimerStop.Text = "Stop Timer";
            this.btnTimerStop.UseVisualStyleBackColor = true;
            this.btnTimerStop.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 81);
            this.button1.TabIndex = 8;
            this.button1.Text = "SnapShot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frmCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 255);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numFrameRate);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTimerStop);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnTimerStart);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cmbVideoDevices);
            this.Controls.Add(this.btnFrame);
            this.Controls.Add(this.cmbVideoSize);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(598, 294);
            this.Name = "frmCam";
            this.Text = "frmCam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCam_FormClosing);
            this.Load += new System.EventHandler(this.frmCam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrameRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbVideoSize;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFrame;
        private System.Windows.Forms.ComboBox cmbVideoDevices;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numFrameRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTimerStart;
        private System.Windows.Forms.Button btnTimerStop;
        private System.Windows.Forms.Button button1;
    }
}