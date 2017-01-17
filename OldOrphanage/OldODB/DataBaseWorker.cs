using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
namespace OrphansRegistries
{
    public class DataBaseWorker
    {
        public static string DBPath;
        private string _ConnectionString;
        private SqlConnection Con;
        private bool _isConnected = false;

        public bool IsConnected
        {
            get { return _isConnected; }
            set { _isConnected = value; }
        }
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }
        public DataBaseWorker()
        {
            if (this._ConnectionString == null || this._ConnectionString == "")
            {
                
                string dataSource = DBPath ;
                this.ConnectionString = "Data Source=.\\SQLEXPRESS" + 
                    ";AttachDbFilename="+ dataSource 
                    +";Integrated Security=True;Connect Timeout=30;User Instance=True";
            }
        }
        ~DataBaseWorker()
        {
            if (_isConnected)
                Disconnect();
            GC.Collect();
        }
        private void Connect()
        {
            this.Con = new SqlConnection(this._ConnectionString);
            try
            {
                if (!_isConnected)
                {
                    this.Con.Open();
                    _isConnected = true;
                }
            }
            catch (Exception) { _isConnected = false; throw; }
        }
        private void Disconnect()
        {
            try
            {
                if (_isConnected)
                {
                    this.Con.Close();
                    _isConnected = false;
                }
            }
            catch (Exception){ throw;}
        }

        public bool ExcuteCommand(string command)
        {
            bool ret = false;
            try
            {
                Connect();
                SqlCommand comm = new SqlCommand(command, this.Con);
                comm.ExecuteNonQuery();
                Disconnect();
                ret = true;
            }
            catch (Exception ex)
            {
                Disconnect();
                ret = false;
                throw ex;
            }
            return ret;
        }

        public bool ExcuteCommand(string command,Hashtable Parameters)
        {
            bool ret = false;
            try
            {
                Connect();
                SqlCommand comm = new SqlCommand(command, this.Con);
                foreach (string Param in Parameters.Keys)
                {
                    if (Parameters[Param] is System.Drawing.Bitmap || Parameters[Param] is System.Drawing.Image)
                    {
                        System.Drawing.Image img = (System.Drawing.Image)Parameters[Param];
                        System.IO.MemoryStream mem = new System.IO.MemoryStream();
                        img.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] xx = mem.ToArray() ;
                        mem.Close();
                        comm.Parameters.AddWithValue(Param, xx); 
                    }
                    else
                    {
                        if (Parameters[Param] != null)
                        {
                            comm.Parameters.AddWithValue(Param, Parameters[Param]);
                        }
                        else
                        {
                            System.Drawing.Image bit = new System.Drawing.Bitmap(250,250);
                            System.IO.MemoryStream mem = new System.IO.MemoryStream();
                            bit.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                            byte[] xx = mem.ToArray();
                            comm.Parameters.AddWithValue(Param, xx);
                        }
                    }
                }
                comm.ExecuteNonQuery();
                Disconnect();
                ret = true;
            }
            catch (Exception ex)
            {
                Disconnect();
                ret = false;
                throw ex;
            }
            return ret;
        }
        public ArrayList ExcuteResultCommand(string Sql)
        {
            bool ret = false;
            SqlDataReader Dreader = null;
            ArrayList ar = new ArrayList();
            try
            {
                Connect();
                SqlCommand comm = new SqlCommand(Sql , this.Con);
                Dreader = comm.ExecuteReader();
                while (Dreader.Read())
                {
                    Hashtable hash = new Hashtable();
                    for (int i = 0; i < Dreader.FieldCount; i++)
                    {
                        hash.Add(Dreader.GetName(i), Dreader[i]);
                    }
                    ar.Add(hash);                    
                }
                Disconnect();
                ret = true;
                GC.Collect();
            }
            catch (Exception ex) { Disconnect(); ret = false; throw ex; }
            if (ret)
                return ar;
            else
                return null;
        }
        public SqlDataReader  ExcuteDRcommand(string Sql)
        {
            try
            {
                Connect();
                SqlCommand comm = new SqlCommand(Sql, this.Con);
                return comm.ExecuteReader();                
            }
            catch (Exception ex) { Disconnect(); throw ex; }
        }
        public bool ExcuteTransaction(string[] commands)
        {
            bool ret = false;
            try
            {
                Connect();
                SqlTransaction tr = this.Con.BeginTransaction();
                foreach (string ss in commands)
                {
                    try
                    {
                        SqlCommand comm = new SqlCommand(ss, this.Con, tr);
                        comm.ExecuteNonQuery();
                        ret = true;
                    }
                    catch { ret = false; tr.Rollback(); break; }
                }
                if (ret)
                    tr.Commit();
                Disconnect();
            }
            catch (Exception ex)
            {
                Disconnect();
                ret = false;
                throw ex;
            }
            return ret;
        }
    }
}
