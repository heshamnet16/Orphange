using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace OrphanageClient
{
    public partial class frmMic : Form
    {
        public frmMic()
        {
            InitializeComponent();
        }
        public static string GetPublicIP()
        {
            try
            {
                string url = "http://checkip.dyndns.org";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                string[] a = response.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                string a4 = a3[0];
                return a4;
            }
            catch { return ""; }
        }
        private void frmMic_Load(object sender, EventArgs e)
        {
            txtIP.Text = GetPublicIP();
        }
        Socket sock = null;
        object objS = new object();
        byte[] buff = new byte[20000];
        WMCont.WMCont speak = new WMCont.WMCont();
        private void btnStart_Click(object sender, EventArgs e)
        {
            Form1.obj.StartMic( (int)numSampleRate.Value,(int)numBitRate.Value,(int)numChannels.Value,txtIP.Text,(int)numPort.Value);
            IPEndPoint endp = new IPEndPoint(IPAddress.Parse(txtIP.Text), (int)numPort.Value);
            sock  = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.Bind(endp);
            sock.BeginReceive(buff, 0, buff.Length, SocketFlags.None,
                new AsyncCallback(ReceivedAsc), sock);
            speak.StartSpeaker((int)numSampleRate.Value, (int)numBitRate.Value, (int)numChannels.Value);
        }
        public void ReceivedAsc(IAsyncResult e)
        {
            Socket sok = (Socket)e.AsyncState;
            int readedAmount = sok.EndReceive(e);
            byte[] ff = new byte[readedAmount];
            lock (objS)
            {
                for (int i = 0; i < readedAmount; i++)
                {
                    ff[i] = buff[i];
                }
            }
            if (readedAmount > 0)
            {
                //waveout.AddEncryptedAudio(fifo.Dequeue());
                speak.AddEncryptedAudio(ff);
            }
            sok.BeginReceive(buff, 0, buff.Length, SocketFlags.None,
                    new AsyncCallback(ReceivedAsc), sok);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Form1.obj.StopMic();
            speak.StopSpeaker();
        }
    }
}
