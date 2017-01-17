using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;

namespace RemotingServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            try
            {
                TcpChannel m_TcpChanWeb = new TcpChannel(6060); //open a channel
                ChannelServices.RegisterChannel(m_TcpChanWeb, false);
                Type theType = typeof(WMCont.WMCont);
                RemotingConfiguration.RegisterWellKnownServiceType(theType, "HeshamWMCont", 
                    WellKnownObjectMode.Singleton);
            }
            catch
            {

            }
        }
    }
}
