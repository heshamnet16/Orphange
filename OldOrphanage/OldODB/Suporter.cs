using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace OrphansRegistries 
{
    public class Suporter   
    {
        private int _id;
        private string _Name;
        private float _Money;
        private int _OrphanNumber;
        private string _Notes;
        private float _ResetMoney;
        private int _ResetOrphanNum;

        public int ResetOrphanNum
        {
            get { return _ResetOrphanNum; }
            set { _ResetOrphanNum = value; }
        }


        public float ResetMoney
        {
            get { return _ResetMoney; }
            set { _ResetMoney = value; }
        }

        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        public int OrphanNumber
        {
            get { return _OrphanNumber; }
            set { _OrphanNumber = value; }
        }

        public float Money
        {
            get { return _Money; }
            set { _Money = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Father[] getFathers()
        {
            string sql = "select DISTINCT  fa.f_id from  family fa , orphan o where (o.Suporter_ID ="
                    + this._id.ToString() + ") and (o.family_id=fa.id)";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Father[] O = new Father[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int Oid = int.Parse(h["f_id"].ToString());
                    O[i++] = Father.GetFather(Oid);
                }
                return O;
            }
            else
                return null;
        }
        public Orphan[] getOrphans()
        {
            string sql = "select id from Orphan where Suporter_ID ="
    + this._id.ToString();
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Orphan[] O = new Orphan[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int Oid = int.Parse(h["id"].ToString());
                    O[i++] = Orphan.GetOrphan(Oid);
                }
                return O;
            }
            else
                return null;
        }

        public static bool Exist(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Suporter where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
                return true;
            else
                return false;
        }
        public static Suporter GetSuporter(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Suporter where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
            {
                Suporter M = new Suporter();
                foreach (Hashtable h in ar)
                {
                    M._id = id;
                    M._Name = h["Name"] != null ? (string)h["Name"] : "";
                    M._Notes = h["Notes"] is DBNull != true ? (string)h["Notes"] : "";
                    M._OrphanNumber = h["OrphanNum"] is DBNull != true  ? int.Parse(h["OrphanNum"].ToString()) : 0;
                    M._Money = h["Money"].GetType() != typeof(DBNull) ? float.Parse(h["Money"].ToString()) : 0;
                    M._ResetMoney = h["ResetMony"].GetType() != typeof(DBNull) ? float.Parse(h["ResetMony"].ToString()) : 0;
                    M._ResetOrphanNum = h["RestOrphanNum"] is DBNull != true ? int.Parse(h["RestOrphanNum"].ToString()) : 0;
                }
                return M;
            }
            else
                return null;
        }
        public static int GetFreeId()
        {
            string sql = "select id from Suporter order by id desc";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            return int.Parse(((Hashtable)ar[0])["id"].ToString()) + 1;
        }
        public bool Suport(Orphan orph)
        {
            bool ret = false;
            orph.Suporter_ID = this.Id;
            this.ResetOrphanNum--;
            if (this._ResetOrphanNum < 0) return false;
            Itenso.TimePeriod.DateDiff diff = new Itenso.TimePeriod.DateDiff(orph.Suporter_StartDate, orph.Suporter_endDate);
            int TotalMonth = diff.Months + 1;
            int totalMoney = TotalMonth * orph.Salary;
            if (totalMoney <= _ResetMoney)
            {
                this.ResetMoney -= totalMoney;
                ret = Save();
                if (ret) { ret = orph.Save(); }               
                else return false;
                if (ret)
                {
                    Bill b = new Bill(orph.Id, this.Id, orph.Suporter_StartDate, orph.Suporter_endDate, orph.Salary);
                    return b.Save();
                }
                else
                    return false;
            }
            else
                return false;
        }
        public bool DisSuport(Orphan orph)
        {
            if (orph.Suporter_ID == this.Id)
            {
                Itenso.TimePeriod.DateDiff diff = new Itenso.TimePeriod.DateDiff(DateTime.Now, orph.Suporter_StartDate);
                if (diff.Months+1 > 0)
                {
                    int resetMonths = diff.Months + 1;
                    if (resetMonths > 0)
                    {
                        _ResetMoney += resetMonths * orph.Salary;
                        _ResetOrphanNum++;
                    }
                    orph.Salary = 0;
                    string sql = "UPDATE Orphan SET Suporter_ID = NULL WHERE (Id =" + orph.Id.ToString() + ")";
                    DataBaseWorker dbw = new DataBaseWorker();
                    orph.Suporter_ID = 0;
                    bool ret = false;
                    ret = dbw.ExcuteCommand(sql);
                    if (ret)
                        ret = Save();
                    else
                        return false;
                    if (ret)
                    {
                        Bill b = Bill.getSpecificBill(orph, this);
                        if (b != null)
                        {
                            b.IsCanceled = true;
                            return b.Save();
                        }
                    }
                    return ret;
                }
                else
                {
                    Bill b = Bill.getSpecificBill(orph, this);
                    if (b != null && b.IsFinished == false)
                    {
                        b.IsFinished = true;
                        b.Save();
                    }
                    string sql = "UPDATE Orphan SET Suporter_ID = NULL WHERE (Id =" + orph.Id.ToString() + ")";
                    DataBaseWorker dbw = new DataBaseWorker();
                    orph.Suporter_ID = 0;
                    bool ret = false;
                    ret = dbw.ExcuteCommand(sql);
                    if (ret)
                        ret = Save();
                    else
                        return false;
                }
            }
            else
                return false;
            return true;
        }
        public static Suporter[] GetSuporters()
        {
            string sql;
            sql = "select id from suporter";

            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Suporter[] Fs = new Suporter[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i] = GetSuporter(fids);
                    i++;
                }
                return Fs;
            }
            else
                return null;
        }
        public bool Save()
        {
            DataBaseWorker dbw = new DataBaseWorker();

            if (Exist(this._id))
            {
                //Orphan[] ors = getOrphans();
                //if (ors != null && ors.Length > this._OrphanNumber)
                //{
                //    return false;
                //}
                string sql = "Update Suporter Set Name='" + this._Name +
                    "',Money=" + this._Money + ",OrphanNum=" + this._OrphanNumber+
                    ",Notes='" + this._Notes +
                    "',ResetMony="+ this._ResetMoney+  ",RestOrphanNum="+
                    this._ResetOrphanNum +" where Id=" + this._id.ToString();
                return dbw.ExcuteCommand(sql);
            }
            else
            {
                this._ResetMoney = _Money;
                this._ResetOrphanNum = _OrphanNumber;
                string sql = "Insert Into Suporter(Name,Money,OrphanNum,Notes,RestOrphanNum,ResetMony) Values('"
                    + this._Name + "'," + this._Money + "," +
                    this._OrphanNumber + ",'" + this._Notes + "'," + this._ResetOrphanNum + "," + this._ResetMoney + ")";
                return dbw.ExcuteCommand(sql);
            }
        }
        public static int GetLastId()
        {
            string sql = "select id from Suporter order by id desc";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            return int.Parse(((Hashtable)ar[0])["id"].ToString());
        }
        public bool Delete()
        {
            if (this._id == 0) return false;
            DataBaseWorker dbw = new DataBaseWorker();
            if (!dbw.ExcuteCommand("update orphan set Suporter_ID=NULL where Suporter_ID=" + this.Id.ToString()))
                    return false;            
            string sql = "delete from Suporter where id=" + this._id;
            return dbw.ExcuteCommand(sql);
        }
    }
}
