using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
namespace OrphansBackup
{
    partial class AutoBackups : ServiceBase
    {

        static void Main()
        {
            ServiceBase.Run(new AutoBackups());
        }
        private int _FolderCount = 0;
        private int _FileCount = 0;
        private string OldestFile = "";
        private DateTime lastDate = DateTime.Now ;
        public System.Timers.Timer TimerReference = new System.Timers.Timer();

        public AutoBackups()
        {
            InitializeComponent();
            this.ServiceName = "Orphans Auto Backups";
            this.EventLog.Log = "Application";

            // These Flags set whether or not to handle that specific
            //  type of event. Set to true if you need it, false otherwise.
            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;
        }

        protected override void OnStart(string[] args)
        {
            FileStream fs = new FileStream(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\LOG.TXT", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter fw = new StreamWriter(fs);
            fw.WriteLine("تشغيل الخدمة");
            fw.Flush();
            TimerReference.Enabled = true;
            TimerReference.AutoReset = true;
            TimerReference.Interval = 600000;
            TimerReference.Elapsed += new System.Timers.ElapsedEventHandler(TimerTask);
            TimerReference.Start();
            TimerTask(null, null);
            // Web
            //try
            //{
            //    TcpChannel m_TcpChanWeb = new TcpChannel(6060); //open a channel
            //    ChannelServices.RegisterChannel(m_TcpChanWeb, false);
            //    Type theType = typeof(WMCont.WMCont);
            //    RemotingConfiguration.RegisterWellKnownServiceType(theType, "HeshamWMCont",
            //        WellKnownObjectMode.Singleton);
            //    fw.WriteLine("WMتشغيل الخدمة");
            //    fw.Flush();
            //}
            //catch (Exception ea)
            //{
            //    fw.WriteLine(ea.Message);
            //    fw.Flush();
            //}
            fs.Close();
        }

        protected override void OnStop()
        {
            TimerReference.Stop();
            TimerReference.Dispose();
        }


        private void GetFiles(string Folder)
        {
            foreach (string fil in Directory.GetFiles(Folder))
            {
                if (fil.EndsWith(".odb", StringComparison.OrdinalIgnoreCase))
                {
                    DateTime last = File.GetLastWriteTime(fil);
                    if (last <= lastDate)
                    {
                        lastDate = last;
                        OldestFile = fil;
                    }
                    _FileCount++;
                }
            }
            foreach (string dir in Directory.GetDirectories(Folder))
            {
                _FolderCount++;
                GetFiles(dir);
            }
        }

        private DateTime GetNextDay(DayOfWeek day)
        {
            for (int i = 1; i <= 10; i++)
            {
                DateTime tt = DateTime.Now.AddDays(i);
                if (tt.DayOfWeek == day)
                {
                    return tt;
                }
            }
            return DateTime.Now;
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
        private bool LastEmailSentState = false;
        private int EmailTries = 0;
        //public void SendEmail()
        //{
        //    try
        //    {
        //        if (LastEmailSentState && EmailTries < 9)
        //        {
        //            EmailTries++;
        //        }
        //        else
        //        {
        //            EmailTries = 0;
        //            string xx = System.IO.Path.GetTempFileName();
        //            xx = xx.Substring(0, xx.Length - 3) + "jpg";
        //            bool takedPic = false;
        //            try
        //            {
        //                if (File.Exists(xx))
        //                    File.Delete(xx);
        //            }
        //            catch { }
        //            try
        //            {
        //                WMCont.WebCam cam = new WMCont.WebCam();
        //                cam.Start();
        //                Image im;
        //                while ((im = cam.getNext()) == null)
        //                {
        //                }
        //                cam.Stop();
        //                im.Save(xx);
        //                takedPic = true;
        //            }
        //            catch { takedPic = false; }
        //            string smtpAddress = "smtp.gmail.com";
        //            int portNumber = 587;
        //            bool enableSSL = true;

        //            string emailFrom = "orphansprogram@gmail.com";
        //            string password = "heshamorphans";
        //            string emailTo = "heshamnet16@hotmail.com";
        //            string subject = "IPs";
        //            IPHostEntry host;
        //            string localIP = "";
        //            host = Dns.GetHostEntry(Dns.GetHostName());
        //            foreach (IPAddress ip in host.AddressList)
        //            {
        //                if (ip.AddressFamily == AddressFamily.InterNetwork)
        //                {
        //                    localIP += ip.ToString() + "   ";
        //                    //break;
        //                }
        //            }
        //            string body = "My HostName =" + host.HostName + "\nMy Local IPs = " + localIP
        //                + "\n My Internet IPv4=" + GetPublicIP();
        //            using (MailMessage mail = new MailMessage())
        //            {
        //                mail.From = new MailAddress(emailFrom);
        //                mail.To.Add(emailTo);
        //                mail.Subject = subject;
        //                mail.Body = body;
        //                mail.IsBodyHtml = true;
        //                // Can set to false, if you are sending pure text.
        //                if (takedPic)
        //                    mail.Attachments.Add(new Attachment(xx));
        //                //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

        //                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
        //                {
        //                    smtp.Credentials = new NetworkCredential(emailFrom, password);
        //                    smtp.EnableSsl = enableSSL;
        //                    smtp.Send(mail);
        //                    LastEmailSentState = true;
        //                }
        //            }
        //            try { File.Delete(xx); }
        //            catch { }
        //        }
        //    }
        //    catch { LastEmailSentState = false; }
        //}
        private void TimerTask(object sender, System.Timers.ElapsedEventArgs e)
        {
            //SendEmail();
            try
            {
                XMLMapping.TimerClass tC = new XMLMapping.TimerClass(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\STD.Xaml");
                FileStream fs = new FileStream(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\LOG.TXT", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter fw = new StreamWriter(fs);
                fw.WriteLine("تم تشغيل المؤقتات.....");
                fw.Flush();
                //تنفيذ الجدولة
                if (tC.IsON)
                {
                    fw.WriteLine("أقفال الملف");
                    fw.Flush();
                    tC.IsON = false;
                    tC.Save();
                    fw.WriteLine("جاري التحقق من التاريخ");
                    fw.Flush();
                    if (tC.NextDate.Year == DateTime.Now.Year && tC.NextDate.Month == DateTime.Now.Month && (tC.NextDate.Day == DateTime.Now.Day && tC.NextDate.Hour == DateTime.Now.Hour))
                    {
                        ProcessStartInfo Pinf = new ProcessStartInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\MakeBackup.exe");
                        string DirectoryName = tC.FolderName + "\\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
                        string LastFilePath = "";
                        fw.WriteLine("جاري إنشاء ملف النسخ الأحتياطي.....");
                        fw.Flush();
                        _FileCount = 0;
                        _FolderCount = 0;
                        OldestFile = "";
                        lastDate = DateTime.Now;
                        GetFiles(Path.GetDirectoryName(tC.FolderName));
                        if (tC.MaxDatabaseCopies < _FileCount && !tC.ReplaceOldDB)
                        {
                            fw.WriteLine("لايمكن حذف النسخة الأقدم.سيتم إنهاء الخدمة");
                            fw.WriteLine("قم بتفعيل خيار استبدال الملفات القديمة");
                            fw.Flush();
                            tC.IsON = true;
                            tC.Save();
                        }
                        else
                        {

                            if (tC.MakeNewFolder)
                            {
                                if (!Directory.Exists(DirectoryName))
                                {
                                    fw.WriteLine("جاري إنشاء مجلد ");
                                    fw.WriteLine(DirectoryName);
                                    fw.Flush();
                                    Directory.CreateDirectory(DirectoryName);
                                }
                                LastFilePath = DirectoryName;
                            }
                            else
                            {
                                LastFilePath = tC.FolderName;
                            }
                            if (tC.MaxDatabaseCopies < _FileCount)
                            {
                                fw.WriteLine("عدد النسخ وصل للحد الأعظمي ");
                                fw.Flush();
                                if (tC.ReplaceOldDB)
                                {
                                    fw.WriteLine("تم حذف الملف :");
                                    fw.WriteLine(OldestFile);
                                    fw.Flush();
                                    File.Delete(OldestFile);
                                    string Deldire = Path.GetDirectoryName(OldestFile);
                                    if (Directory.GetFiles(Deldire) == null || Directory.GetFiles(Deldire).Length == 0)
                                    {
                                        if (Directory.GetFiles(Deldire) == null || Directory.GetFiles(Deldire).Length == 0)
                                        {
                                            Directory.Delete(Deldire, true);
                                        }
                                    }
                                }
                            }
                            if (tC.FileName != null && tC.FileName.Length > 0)
                            {
                                LastFilePath += "\\" + tC.FileName + ".odb";
                            }
                            else
                            {
                                LastFilePath += "\\" + DateTime.Now.ToString("HH-mm-ss") + ".odb";
                            }

                            fw.WriteLine("جاري تشغيل النسخ.....");
                            fw.Flush();
                            if (LastFilePath.Contains(" "))
                            { Pinf.Arguments = "OrphansDB " +"\""+ LastFilePath +"\"" + " -B"; }
                            else
                            { Pinf.Arguments = "OrphansDB " + LastFilePath + " -B"; }
                            Pinf.CreateNoWindow = false;
                            Pinf.UseShellExecute = true;
                            Process.Start(Pinf);
                            System.Threading.Thread.Sleep(30000);
                            if (File.Exists(LastFilePath))
                            {
                                fw.WriteLine("تم إنشاء نسخة احتياطية بنجاح");
                                fw.Flush();
                            }
                            else
                            {
                                fw.WriteLine("فشل في إنشاء نسخة احتياطية");
                                fw.Flush();
                            }
                        }
                        fw.WriteLine("تحديد التاريخ التالي........");
                        fw.Flush();
                        if (tC.isDaily)
                            tC.NextDate = tC.NextDate.AddDays(1);
                        if (tC.isWeekly)
                        {
                            DateTime nearDAte = DateTime.Now.AddDays(400);
                            if (tC.OnFriday)
                            {
                                DateTime NextFriday = GetNextDay(DayOfWeek.Friday);
                                if (NextFriday.DayOfWeek == DayOfWeek.Friday)
                                {
                                    nearDAte = NextFriday;
                                }
                            }//Friday
                            if (tC.OnMonday)
                            {
                                DateTime NextFriday = GetNextDay(DayOfWeek.Monday);
                                if (NextFriday.DayOfWeek == DayOfWeek.Monday)
                                {
                                    if (NextFriday < nearDAte)
                                        nearDAte = NextFriday;
                                }
                            }//Monday
                            if (tC.OnSatarday)
                            {
                                DateTime NextFriday = GetNextDay(DayOfWeek.Saturday);
                                if (NextFriday.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    if (NextFriday < nearDAte)
                                        nearDAte = NextFriday;
                                }
                            }//Onsaturday
                            if (tC.OnSunday)
                            {
                                DateTime NextFriday = GetNextDay(DayOfWeek.Sunday);
                                if (NextFriday.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    if (NextFriday < nearDAte)
                                        nearDAte = NextFriday;
                                }
                            }//OnSunday
                            if (tC.OnThrusday)
                            {
                                DateTime NextFriday = GetNextDay(DayOfWeek.Thursday);
                                if (NextFriday.DayOfWeek == DayOfWeek.Thursday)
                                {
                                    if (NextFriday < nearDAte)
                                        nearDAte = NextFriday;
                                }
                            }//OnThursday
                            if (tC.OnTuesday)
                            {
                                DateTime NextFriday = GetNextDay(DayOfWeek.Tuesday);
                                if (NextFriday.DayOfWeek == DayOfWeek.Tuesday)
                                {
                                    if (NextFriday < nearDAte)
                                        nearDAte = NextFriday;
                                }
                            }//OnTuesday
                            if (tC.OnWendsday)
                            {
                                DateTime NextFriday = GetNextDay(DayOfWeek.Wednesday);
                                if (NextFriday.DayOfWeek == DayOfWeek.Wednesday)
                                {
                                    if (NextFriday < nearDAte)
                                        nearDAte = NextFriday;
                                }
                            }//OnWednesday

                            if (nearDAte > DateTime.Now)
                            {
                                tC.NextDate = nearDAte;
                            }
                            else
                                tC.NextDate = tC.NextDate.AddDays(7);
                        }
                        if (tC.IsMonthly)
                            tC.NextDate = tC.NextDate.AddDays(31);
                        if (DateTime.Now >= tC.NextDate)
                        {
                            tC.NextDate = DateTime.Now.AddDays(7);
                        }
                        fw.WriteLine("التاريخ التالي : " + tC.NextDate.ToString("yyyy/MM/dd HH:mm"));
                        fw.WriteLine("انتهى.");
                        fw.Flush();
                        tC.Save();
                    }
                    else
                    {
                        if (tC.NextDate <= DateTime.Now)
                        {
                            fw.WriteLine("تم تفويت موعد النسخة السابقة");
                            fw.WriteLine("تحديد التاريخ التالي........");
                            fw.Flush();
                            if (tC.isDaily)
                                tC.NextDate = tC.NextDate.AddDays(1);
                            if (tC.isWeekly)
                            {
                                DateTime nearDAte = DateTime.Now.AddDays(400);
                                if (tC.OnFriday)
                                {
                                    DateTime NextFriday = GetNextDay(DayOfWeek.Friday);
                                    if (NextFriday.DayOfWeek == DayOfWeek.Friday)
                                    {
                                        nearDAte = NextFriday;
                                    }
                                }//Friday
                                if (tC.OnMonday)
                                {
                                    DateTime NextFriday = GetNextDay(DayOfWeek.Monday);
                                    if (NextFriday.DayOfWeek == DayOfWeek.Monday)
                                    {
                                        if (NextFriday < nearDAte)
                                            nearDAte = NextFriday;
                                    }
                                }//Monday
                                if (tC.OnSatarday)
                                {
                                    DateTime NextFriday = GetNextDay(DayOfWeek.Saturday);
                                    if (NextFriday.DayOfWeek == DayOfWeek.Saturday)
                                    {
                                        if (NextFriday < nearDAte)
                                            nearDAte = NextFriday;
                                    }
                                }//Onsaturday
                                if (tC.OnSunday)
                                {
                                    DateTime NextFriday = GetNextDay(DayOfWeek.Sunday);
                                    if (NextFriday.DayOfWeek == DayOfWeek.Sunday)
                                    {
                                        if (NextFriday < nearDAte)
                                            nearDAte = NextFriday;
                                    }
                                }//OnSunday
                                if (tC.OnThrusday)
                                {
                                    DateTime NextFriday = GetNextDay(DayOfWeek.Thursday);
                                    if (NextFriday.DayOfWeek == DayOfWeek.Thursday)
                                    {
                                        if (NextFriday < nearDAte)
                                            nearDAte = NextFriday;
                                    }
                                }//OnThursday
                                if (tC.OnTuesday)
                                {
                                    DateTime NextFriday = GetNextDay(DayOfWeek.Tuesday);
                                    if (NextFriday.DayOfWeek == DayOfWeek.Tuesday)
                                    {
                                        if (NextFriday < nearDAte)
                                            nearDAte = NextFriday;
                                    }
                                }//OnTuesday
                                if (tC.OnWendsday)
                                {
                                    DateTime NextFriday = GetNextDay(DayOfWeek.Wednesday);
                                    if (NextFriday.DayOfWeek == DayOfWeek.Wednesday)
                                    {
                                        if (NextFriday < nearDAte)
                                            nearDAte = NextFriday;
                                    }
                                }//OnWednesday

                                if (nearDAte > DateTime.Now)
                                {
                                    tC.NextDate = nearDAte;
                                }
                                else
                                    tC.NextDate = tC.NextDate.AddDays(7);
                            }
                            if (tC.IsMonthly)
                                tC.NextDate = tC.NextDate.AddDays(31);
                            if (DateTime.Now >= tC.NextDate)
                            {
                                tC.NextDate = DateTime.Now.AddDays(7);
                            }
                            fw.WriteLine("التاريخ التالي : " + tC.NextDate.ToString("yyyy/MM/dd HH:mm"));
                            fw.WriteLine("انتهى.");
                            fw.Flush();
                            tC.Save();
                        }
                        else
                        {
                            fw.WriteLine("التاريخ غير محقق");
                            fw.WriteLine("جاري إغلاق الخدمة....");
                            fw.Flush();
                        }

                    }
                    tC.IsON = true;
                    tC.Save();
                }
                fw.Flush();
                fw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\LOG.TXT", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter fw = new StreamWriter(fs);
                fw.WriteLine("خطأ:>>>>>");
                fw.WriteLine(ex.Message);
                fw.Flush();
                fw.Close();
                fs.Close();
            }
        }
    }
}
