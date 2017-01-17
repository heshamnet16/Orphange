using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Install
{
    class Installer
    {
        static void Main(string[] args)
        {
            //args = new string[] { "u"};
            if (args.Length == 1)
            {
                string Type = args[0];
                if (Type.Trim().ToLower() == "i")
                {
                    if (System.IO.File.Exists("OrphansBackup.exe"))
                    {
                        string SystemDrive = Environment.SystemDirectory.Substring(0, 3) + "windows";
                        string DotNET4 = SystemDrive + @"\Microsoft.NET\Framework\v4.0.30319";
                        string Installerpath = DotNET4 + "\\InstallUtil.exe";
                        System.Diagnostics.ProcessStartInfo pinfo = new System.Diagnostics.ProcessStartInfo(Installerpath);
                        pinfo.Arguments = "/i" + " \"" + Environment.CurrentDirectory + "\\OrphansBackup.exe"+"\"";
                        pinfo.CreateNoWindow = false;
                        pinfo.UseShellExecute = false;
                        pinfo.RedirectStandardOutput = true;
                        System.Diagnostics.Process P = System.Diagnostics.Process.Start(pinfo);
                        string All = P.StandardOutput.ReadToEnd();
                        Console.Write(All);                        
                        pinfo = new System.Diagnostics.ProcessStartInfo("NET");
                        pinfo.Arguments = "Start OrphansAutoBackup";
                        P = System.Diagnostics.Process.Start(pinfo);
                    }
                }
                else if (Type.Trim().ToLower() == "u")
                {
                if (System.IO.File.Exists("OrphansBackup.exe"))
                    {
                        string SystemDrive = Environment.SystemDirectory.Substring(0, 3) + "windows";
                        string DotNET4 = SystemDrive + @"\Microsoft.NET\Framework\v4.0.30319";
                        string Installerpath = DotNET4 + "\\InstallUtil.exe";
                        System.Diagnostics.ProcessStartInfo pinfo = new System.Diagnostics.ProcessStartInfo(Installerpath);
                        pinfo.Arguments = "/u" + "\t\"" + Environment.CurrentDirectory + "\\OrphansBackup.exe"+"\"";
                        pinfo.CreateNoWindow = false;
                        pinfo.UseShellExecute = false;
                        pinfo.RedirectStandardOutput = true;
                        System.Diagnostics.Process P = System.Diagnostics.Process.Start(pinfo);
                        string All = P.StandardOutput.ReadToEnd();
                        Console.Write(All);                        
                        pinfo = new System.Diagnostics.ProcessStartInfo("NET");
                        pinfo.Arguments = "Start OrphansAutoBackup";
                        P = System.Diagnostics.Process.Start(pinfo);
                    }
                }
            }
        }
    }
}
