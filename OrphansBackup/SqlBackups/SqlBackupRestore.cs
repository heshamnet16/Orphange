using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk;
using System.Data.SqlClient;

namespace SqlBackups
{
    public class SqlBackupRestore
    {
        public  delegate void PercentEventHandler(int perc);
        public  event PercentEventHandler  ProgressPercent;
        private SqlConnection con;
        private string _DbName;

        public SqlBackupRestore(string DatabaseName)
        {
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=" + DatabaseName + ";Integrated Security=True");
            this._DbName = DatabaseName;
        }
        public string DbName
        {
            get { return _DbName; }
            set { _DbName = value; }
        }
        private string _BackupFileName;

        public string BackupFileName
        {
            get { return _BackupFileName; }
            set { _BackupFileName = value; }
        }

        public void DoBackup()
        {
            try
            {
                Backup bkpDBFull = new Backup();

                bkpDBFull.Action = BackupActionType.Database;

                bkpDBFull.Database = _DbName;

                bkpDBFull.Devices.AddDevice(_BackupFileName, DeviceType.File);
                bkpDBFull.BackupSetName = "Database backup";
                bkpDBFull.BackupSetDescription = string.Format("Database: {0}. Date: {1}.",
                _DbName, DateTime.Now.ToString("dd.MM.yyyy hh:m")); ;
                bkpDBFull.Initialize = false;
                bkpDBFull.MediaDescription = "Disk";
                bkpDBFull.PercentComplete += CompletionStatusInPercent;
                ServerConnection sc = new ServerConnection(con);
                Server MyServer = new Server(sc);
                bkpDBFull.SqlBackup(MyServer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CompletionStatusInPercent(object sender, PercentCompleteEventArgs args)
        {
            if (args.Percent <= 25)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (args.Percent > 25 && args.Percent  <= 50)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (args.Percent > 50 && args.Percent <= 75)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Done : {0} %.", args.Percent);
            if (ProgressPercent != null)
            {
                ProgressPercent(args.Percent);
            }
        }

        public void Restor()
        {
            Restore dbRestore = new Restore();
            ServerConnection sc = new ServerConnection();
            dbRestore.Database = _DbName;
            dbRestore.Action = RestoreActionType.Database;
            dbRestore.ReplaceDatabase = true;
            BackupDeviceItem device = new BackupDeviceItem
                (_BackupFileName, DeviceType.File);
            dbRestore.PercentComplete +=
            new PercentCompleteEventHandler(CompletionStatusInPercent);
            sc.ServerInstance = ".\\SQLEXPRESS";
            Server MyServer = new Server(sc);
            try
            {

                dbRestore.Devices.Add(device);

                RelocateFile DataFile = new RelocateFile();
                //string MDF = dbRestore.ReadFileList(MyServer).Rows[0][1].ToString();
                DataFile.LogicalFileName = dbRestore.ReadFileList(MyServer).Rows[0][0].ToString();
                DataFile.PhysicalFileName = MyServer.Databases[_DbName].FileGroups[0].Files[0].FileName;

                RelocateFile LogFile = new RelocateFile();
                //string LDF = dbRestore.ReadFileList(MyServer).Rows[1][1].ToString();
                LogFile.LogicalFileName = dbRestore.ReadFileList(MyServer).Rows[1][0].ToString();
                LogFile.PhysicalFileName = MyServer.Databases[_DbName].LogFiles[0].FileName;

                dbRestore.RelocateFiles.Add(DataFile);
                dbRestore.RelocateFiles.Add(LogFile);



                dbRestore.SqlRestore(MyServer);
                sc.Disconnect();                
            }
            catch (Exception exc)
            {
                dbRestore.Abort();
                if (exc.InnerException != null)
                    throw exc.InnerException;
                else
                    throw exc;
            }
        }
    }
}
