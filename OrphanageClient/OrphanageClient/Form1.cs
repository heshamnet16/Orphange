using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Diagnostics;
using System.Runtime.Remoting.Channels.Http;
using System.IO;
using System.Net.Sockets;
using System.Net;
namespace OrphanageClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static  WMCont.WMCont obj;
        TcpChannel chan;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Connect()
        {
            try
            {
                if (chan == null)
                    chan = new TcpChannel();
                ChannelServices.RegisterChannel(chan,false);
                string URI = "Tcp://" + textBox1.Text + ":6060/HeshamWMCont";
                obj = (WMCont.WMCont)Activator.GetObject(
                  typeof(WMCont.WMCont),
                  URI );
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
                DisConnect();
            }
        }
        public void DisConnect()
        {
            try {
                ChannelServices.UnregisterChannel(chan);
                obj = null;                
            }
            catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisConnect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisConnect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmCam frm = new frmCam();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Click(object sender, EventArgs e)
        {
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void btnMic_Click(object sender, EventArgs e)
        {
            frmMic frm = new frmMic();
            frm.Show();
        }
    }
}
