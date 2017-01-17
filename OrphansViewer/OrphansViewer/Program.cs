using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrphansViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //return;
            if (args != null && args.Length > 0)
            {
                string fileName = args[0];
                if (System.IO.File.Exists(fileName) && frmMain.IsCorrectFile(fileName))
                {
                    Application.Run(new frmMain(fileName));
                }
                else
                {
                    throw new Exception("الملف غير صالح");
                }
            }
            else
                Application.Run(new frmMain());
        }
    }
}
