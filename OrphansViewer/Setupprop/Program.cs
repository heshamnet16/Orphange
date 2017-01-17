using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace Setupprop
{
    class Program
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, MoveFileFlags dwFlags);

        internal enum MoveFileFlags
        {
            MOVEFILE_REPLACE_EXISTING = 1,
            MOVEFILE_COPY_ALLOWED = 2,
            MOVEFILE_DELAY_UNTIL_REBOOT = 4,
            MOVEFILE_WRITE_THROUGH = 8
        }

        static void InstallIconHandler()
        {
            //if (System.IO.File.Exists(Folder+"ovih.dll") && System.IO.File.Exists(Folder+"ovth.dll"))
            if (System.IO.File.Exists("ovth.dll"))
            {
                string SystemDrive = Environment.SystemDirectory.Substring(0, 3) + "windows";
                string DotNET4;
                if (Environment.Is64BitOperatingSystem)
                    DotNET4 = SystemDrive + @"\Microsoft.NET\Framework64\v4.0.30319";
                else
                    DotNET4 = SystemDrive + @"\Microsoft.NET\Framework\v4.0.30319";
                string Installerpath = DotNET4 + "\\regasm.exe";
                System.Diagnostics.ProcessStartInfo pinfo = new System.Diagnostics.ProcessStartInfo(Installerpath);
                pinfo.Arguments = "/codebase" + " \"" + Environment.CurrentDirectory + "\\ovth.dll" + "\"";
                pinfo.CreateNoWindow = false;
                pinfo.UseShellExecute = false;
                pinfo.RedirectStandardOutput = true;
                System.Diagnostics.Process P = System.Diagnostics.Process.Start(pinfo);
                string All = P.StandardOutput.ReadToEnd();
                Console.Write(All);
                pinfo = new System.Diagnostics.ProcessStartInfo(Installerpath);
                pinfo.Arguments = "/codebase" + " \"" + Environment.CurrentDirectory + "\\ovih.dll" + "\"";
                pinfo.CreateNoWindow = false;
                pinfo.UseShellExecute = false;
                pinfo.RedirectStandardOutput = true;
                P = System.Diagnostics.Process.Start(pinfo);
                All = P.StandardOutput.ReadToEnd();
                Console.Write(All);
            }
        }
        static void UninstallIconHandler()
        {
            if (System.IO.File.Exists("ovih.dll") && System.IO.File.Exists("ovth.dll"))
            //if (System.IO.File.Exists("ovth.dll"))
            {
                string SystemDrive = Environment.SystemDirectory.Substring(0, 3) + "windows";
                string DotNET4;
                if (Environment.Is64BitOperatingSystem)
                    DotNET4 = SystemDrive + @"\Microsoft.NET\Framework64\v4.0.30319";
                else
                    DotNET4 = SystemDrive + @"\Microsoft.NET\Framework\v4.0.30319";
                string Installerpath = DotNET4 + "\\regasm.exe";
                System.Diagnostics.ProcessStartInfo pinfo = new System.Diagnostics.ProcessStartInfo(Installerpath);
                pinfo.Arguments = "/unregister" + " \"" + Environment.CurrentDirectory + "\\ovth.dll" + "\"";
                pinfo.CreateNoWindow = false;
                pinfo.UseShellExecute = false;
                pinfo.RedirectStandardOutput = true;
                System.Diagnostics.Process P = System.Diagnostics.Process.Start(pinfo);
                string All = P.StandardOutput.ReadToEnd();
                Console.Write(All);
                try
                {
                    bool res = MoveFileEx("ovth.dll", null,
                            MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);
                }
                catch { }
                pinfo = new System.Diagnostics.ProcessStartInfo(Installerpath);
                pinfo.Arguments = "/unregister" + " \"" + Environment.CurrentDirectory + "\\ovih.dll" + "\"";
                pinfo.CreateNoWindow = false;
                pinfo.UseShellExecute = false;
                pinfo.RedirectStandardOutput = true;
                P = System.Diagnostics.Process.Start(pinfo);
                All = P.StandardOutput.ReadToEnd();
                Console.Write(All);
                try
                {
                    bool res = MoveFileEx("ovih.dll", null,
                            MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);
                }
                catch { }
            }
        }
        static void RegProgram()
        {
            string DircPath = Environment.CurrentDirectory + "\\";
            string AppPath = DircPath + "\\OrphansViewer.exe";
            RegistryKey  rg = Registry.LocalMachine;
            rg = rg.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\OrphansViewer.exe");
            rg.SetValue("", AppPath  , RegistryValueKind.String);
            rg.SetValue("Path",DircPath , RegistryValueKind.String);
            RegistryKey rgH = Registry.ClassesRoot;
            rgH.CreateSubKey("Applications\\OrphansViewer.exe\\SupportedTypes\\.Fam");
            rgH = Registry.ClassesRoot.CreateSubKey(".Fam");
            rgH.SetValue("", "Fam_auto_file");
            rgH.SetValue("PerceivedType", "Fam_auto_file", RegistryValueKind.String);
            rgH = Registry.ClassesRoot.CreateSubKey("Fam_auto_file\\shell");
            rgH.CreateSubKey("open\\command").SetValue("", AppPath + " \"%1\"");
            rgH = rgH = Registry.ClassesRoot.CreateSubKey("SystemFileAssociations\\Fam_auto_file\\shell");
            rgH.CreateSubKey("open\\command").SetValue("", AppPath + " \"%1\"" );
        }
        static void unRegProgram()
        {
            try
            {
                string DircPath = Environment.CurrentDirectory + "\\";
                string AppPath = DircPath + "\\OrphansViewer.exe";
                RegistryKey rg = Registry.LocalMachine;
                rg.DeleteSubKeyTree("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\OrphansViewer.exe", false);
                RegistryKey rgH = Registry.ClassesRoot;
                rgH.DeleteSubKeyTree("Applications\\OrphansViewer.exe\\SupportedTypes\\.Fam", false);
                rgH.DeleteSubKeyTree(".Fam");
                rgH.DeleteSubKeyTree("Fam_auto_file");
                rgH.DeleteSubKeyTree("SystemFileAssociations\\Fam_auto_file");
            }
            catch { }
        }
        static void Main(string[] args)
        {
            //args = new string[] { "u"};
            if (args.Length == 1)
            {
                string Type = args[0];
                Console.WriteLine(args[0]);
                if (Type.Trim().ToLower() == "i")
                {
                    RegProgram();
                    InstallIconHandler();
                }
                else if (Type.Trim().ToLower() == "u")
                {
                    UninstallIconHandler();
                    unRegProgram();
                }
            }
            if (args.Length == 2)
            {
                string Type = args[0];
                string FolderW = args[1];
                if (!FolderW.EndsWith("\\"))
                    FolderW += "\\";
                if (Type.Trim().ToLower() == "i")
                {
                    RegProgram(FolderW);
                    InstallIconHandler(FolderW);
                }
                else if (Type.Trim().ToLower() == "u")
                {
                    UninstallIconHandler(FolderW);
                    unRegProgram();
                }
            }
            //Console.ReadLine();
        }

        static void InstallIconHandler(string Folder)
        {
            if (System.IO.File.Exists(Folder + "ovih.dll") && System.IO.File.Exists(Folder + "ovth.dll"))
                //if ( System.IO.File.Exists(Folder + "ovth.dll"))
            {
                string SystemDrive = Environment.SystemDirectory.Substring(0, 3) + "windows";
                string DotNET4;
                    if (Environment.Is64BitOperatingSystem )
                        DotNET4 = SystemDrive + @"\Microsoft.NET\Framework64\v4.0.30319";
                    else
                        DotNET4 = SystemDrive + @"\Microsoft.NET\Framework\v4.0.30319";
                string Installerpath = DotNET4 + "\\regasm.exe";
                System.Diagnostics.ProcessStartInfo pinfo = new System.Diagnostics.ProcessStartInfo(Installerpath);
                pinfo.Arguments = " \"" + Folder + "ovth.dll" + "\" " + " /codebase";
                pinfo.CreateNoWindow = false;
                pinfo.UseShellExecute = false;
                pinfo.RedirectStandardOutput = true;
                System.Diagnostics.Process P = System.Diagnostics.Process.Start(pinfo);
                string All = P.StandardOutput.ReadToEnd();
                Console.Write(All);
                pinfo = new System.Diagnostics.ProcessStartInfo(Installerpath);
                pinfo.Arguments = " \"" + Folder + "ovih.dll" + "\"" + " /codebase";
                pinfo.CreateNoWindow = false;
                pinfo.UseShellExecute = false;
                pinfo.RedirectStandardOutput = true;
                P = System.Diagnostics.Process.Start(pinfo);
                All = P.StandardOutput.ReadToEnd();
                Console.Write(All);
            }
        }
        static void UninstallIconHandler(string Folder)
        {
            if (System.IO.File.Exists(Folder + "ovih.dll") && System.IO.File.Exists(Folder + "ovth.dll"))
            //if (System.IO.File.Exists(Folder + "ovth.dll"))
            {
                string SystemDrive = Environment.SystemDirectory.Substring(0, 3) + "windows";
                string DotNET4;
                if (Environment.Is64BitOperatingSystem)
                    DotNET4 = SystemDrive + @"\Microsoft.NET\Framework64\v4.0.30319";
                else
                    DotNET4 = SystemDrive + @"\Microsoft.NET\Framework\v4.0.30319";
                string Installerpath = DotNET4 + "\\regasm.exe";
                System.Diagnostics.ProcessStartInfo pinfo = new System.Diagnostics.ProcessStartInfo(Installerpath);
                pinfo.Arguments = " \"" + Folder + "ovth.dll" + "\" " + " /unregister";
                pinfo.CreateNoWindow = false;
                pinfo.UseShellExecute = false;
                pinfo.RedirectStandardOutput = true;
                System.Diagnostics.Process P = System.Diagnostics.Process.Start(pinfo);
                string All = P.StandardOutput.ReadToEnd();
                Console.Write(All);
                try
                {
                    bool res = MoveFileEx(Folder + "ovth.dll", null,
                            MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);
                }
                catch { }
                pinfo = new System.Diagnostics.ProcessStartInfo(Installerpath);
                pinfo.Arguments = " \"" + Folder + "ovih.dll" + "\"" + " /unregister" ;
                pinfo.CreateNoWindow = false;
                pinfo.UseShellExecute = false;
                pinfo.RedirectStandardOutput = true;
                P = System.Diagnostics.Process.Start(pinfo);
                All = P.StandardOutput.ReadToEnd();
                Console.Write(All);
                try
                {
                    bool r1es = MoveFileEx(Folder + "ovth.dll", null,
                        MoveFileFlags.MOVEFILE_DELAY_UNTIL_REBOOT);
                }
                catch { }
            }
        }
        static void RegProgram(string Folder)
        {
            string DircPath = Folder;
            string AppPath = DircPath + "OrphansViewer.exe";
            RegistryKey rg = Registry.LocalMachine;
            rg = rg.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\OrphansViewer.exe");
            rg.SetValue("", AppPath, RegistryValueKind.String);
            rg.SetValue("Path", DircPath, RegistryValueKind.String);
            RegistryKey rgH = Registry.ClassesRoot;
            rgH.CreateSubKey("Applications\\OrphansViewer.exe\\SupportedTypes\\.Fam");
            rgH = Registry.ClassesRoot.CreateSubKey(".Fam");
            rgH.SetValue("", "Fam_auto_file");
            rgH.SetValue("PerceivedType", "Fam_auto_file", RegistryValueKind.String);
            rgH = Registry.ClassesRoot.CreateSubKey("Fam_auto_file\\shell");
            rgH.CreateSubKey("open\\command").SetValue("", AppPath + " \"%1\"");
            rgH = rgH = Registry.ClassesRoot.CreateSubKey("SystemFileAssociations\\Fam_auto_file\\shell");
            rgH.CreateSubKey("open\\command").SetValue("", AppPath + " \"%1\"");
        }
    }
}
