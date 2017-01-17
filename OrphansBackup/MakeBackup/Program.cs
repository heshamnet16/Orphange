using System;
using SqlBackups;
namespace MakeBackup
{
    class Program
    {
        //args DbName FileName [-B|-R] 
        static void Main(string[] args)
        {

            //args = new string[] { "OrphansDB", @"E:\FullDB.odb", "-R" };
            if (args == null || args.Length != 3)
            {
                Console.WriteLine("Please pass the specific parameters :\n\t1-Database Name.\n\t2-Backup file path\n\t3-Type of operation -B for backup or -R for restore. ");
                Console.Read();
                return;
            }

            if (args[0].Length <= 1)
            {
                Console.WriteLine("Please Enter valied name for database");
                Console.Read();
                return;
            }
            if (args[1].Length <= 1)
            {
                Console.WriteLine("Please Enter valied Path for backup/restore file.");
                Console.Read();
                return;
            }
            if (args[2] != "-R" && args[2] != "-B")
            {
                Console.WriteLine("Please Enter valied operation (-B for backup OR -R for restore).");
                Console.Read();
                return;
            }
            if (args[2] == "-R")
            {
                if (!System.IO.File.Exists(args[1]))
                {
                    Console.WriteLine("Please Enter valied name for database");
                    Console.Read();
                    return;
                }
            }
            string DBName = args[0];
            string FilePath = args[1];
            string Operation = args[2];
            try
            {
                SqlBackupRestore bkR = new SqlBackupRestore(DBName);
                bkR.BackupFileName = FilePath;
                bkR.ProgressPercent += new SqlBackupRestore.PercentEventHandler(bkR_ProgressPercent);
                if (Operation == "-B")
                {
                    if (System.IO.File.Exists(FilePath))
                    {
                        System.IO.File.Delete(FilePath);
                    }
                    bkR.DoBackup();
                }
                else
                {
                    bkR.Restor();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erorr----\n {0}%", ex.Message);
                Console.Read();
            }
        }

        static void bkR_ProgressPercent(int perc)
        {
            Console.Clear();
            Console.WriteLine("Done {0}%", perc);
        }
    }
}
