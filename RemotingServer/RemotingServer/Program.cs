using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace RemotingServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool onlyInstance = false;
            Mutex mm = new Mutex(true, "RemotingServer", out onlyInstance);
            if (!onlyInstance)
                return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            GC.KeepAlive(mm);
        }
    }
}
