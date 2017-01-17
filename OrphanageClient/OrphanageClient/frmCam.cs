using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.IO;

namespace OrphanageClient
{
    public partial class frmCam : Form
    {
        public frmCam()
        {
            InitializeComponent();
        }
        private void frmCam_Load(object sender, EventArgs e)
        {
            cmbVideoSize.SelectedIndex = 3;
            cmbVideoDevices.Items.AddRange(Form1.obj.s_getCamDevicesNames());
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = checkBox1.Checked;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                string[] xx = cmbVideoSize.SelectedItem.ToString().Split(new char[] { '*' });
                Form1.obj.StartCam(new Size(int.Parse(xx[0]), int.Parse(xx[1])));
                Form1.obj.CamCompressionRatio = (int)numericUpDown1.Value;
                Form1.obj.CamUseCompression = checkBox1.Checked;
                btnFrame.Enabled = true;
                btnStop.Enabled = true;
                btnTimerStart.Enabled = true;
                btnTimerStop.Enabled = false;
                btnStart.Enabled = false;
            }catch{}
        }

        private void numFrameRate_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)( numFrameRate.Value * 1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                byte[] ss = Form1.obj.getCamNextBytes();
                if (ss != null)
                {
                    MemoryStream mm = new MemoryStream(ss);
                    Image bb = Image.FromStream(mm);
                    pictureBox1.Image = bb;
                }
            }
            catch { }
        }

        private void btnFrame_Click(object sender, EventArgs e)
        {
                try
                {
                    byte[] ss = Form1.obj.getCamNextBytes();
                    if (ss != null)
                    {
                        MemoryStream mm = new MemoryStream(ss);
                        Image bb = Image.FromStream(mm);
                        pictureBox1.Image = bb;
                    }
                }
                catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = (int)(numFrameRate.Value * 1000);
            btnTimerStart.Enabled = false;
            btnTimerStop.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnTimerStart.Enabled = true;
            btnTimerStop.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Form1.obj.StopCam();
            btnFrame.Enabled = false;
            btnStop.Enabled = false;
            btnTimerStart.Enabled = false;
            btnTimerStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Form1.obj.CamCompressionRatio = (int) numericUpDown1.Value;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string[] xx = cmbVideoSize.SelectedItem.ToString().Split(new char[] { '*' });
                byte[] ss = Form1.obj.S_GetCamSnapshot(new Size(int.Parse(xx[0]), int.Parse(xx[1])));
                if (ss != null)
                {
                    MemoryStream mm = new MemoryStream(ss);
                    Image bb = Image.FromStream(mm);
                    pictureBox1.Image = bb;
                }
            }
            catch { }
        }

        private void frmCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                Form1.obj.StopCam();
            }
            catch { }
        }
    }
}
