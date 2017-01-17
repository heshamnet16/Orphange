namespace OrphanageClient
{
    partial class frmMic
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numSampleRate = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numBitRate = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numChannels = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBitRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChannels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numChannels);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numBitRate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numSampleRate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // numSampleRate
            // 
            this.numSampleRate.Location = new System.Drawing.Point(98, 18);
            this.numSampleRate.Maximum = new decimal(new int[] {
            48000,
            0,
            0,
            0});
            this.numSampleRate.Name = "numSampleRate";
            this.numSampleRate.Size = new System.Drawing.Size(120, 20);
            this.numSampleRate.TabIndex = 0;
            this.numSampleRate.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sample Rate :";
            // 
            // numBitRate
            // 
            this.numBitRate.Location = new System.Drawing.Point(98, 47);
            this.numBitRate.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numBitRate.Name = "numBitRate";
            this.numBitRate.Size = new System.Drawing.Size(120, 20);
            this.numBitRate.TabIndex = 0;
            this.numBitRate.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bit Rate :";
            // 
            // numChannels
            // 
            this.numChannels.Location = new System.Drawing.Point(98, 78);
            this.numChannels.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numChannels.Name = "numChannels";
            this.numChannels.Size = new System.Drawing.Size(120, 20);
            this.numChannels.TabIndex = 0;
            this.numChannels.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Channels:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(22, 226);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(136, 226);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(77, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "IP Address :";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(90, 142);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(140, 20);
            this.txtIP.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Port :";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(89, 173);
            this.numPort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(141, 20);
            this.numPort.TabIndex = 0;
            this.numPort.Value = new decimal(new int[] {
            7077,
            0,
            0,
            0});
            // 
            // frmMic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 261);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.numPort);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "frmMic";
            this.Text = "frmMic";
            this.Load += new System.EventHandler(this.frmMic_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBitRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChannels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numChannels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBitRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSampleRate;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPort;
    }
}