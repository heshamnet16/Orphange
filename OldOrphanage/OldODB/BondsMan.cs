using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace OrphansRegistries
{
   public  class BondsMan
    {
       public enum BondsManSearch {Name,Jop,MonthlyIncome,Phone,Address };
        private int _id;
        private string _name;
        private string _notes;
        private string _jop;
        private string _MonthlyIncome;
        private string _Address;
        private string _Phone;
        private int _Rating;
        private int _Salary;

        public int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }
        public int Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }
        public string MonthlyIncome
        {
            get { return _MonthlyIncome; }
            set { _MonthlyIncome = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }        
        public string Notes
        {
            get { return this._notes ; }
            set { this._notes = value; }
        }
        public string Jop
        {
            get { return _jop; }
            set { _jop = value; }
        }
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public static bool Exist(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from BondsMan where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
                return true;
            else
                return false;
        }
        public static BondsMan Exist(BondsMan bo)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from BondsMan where name='" + bo.Name + "' and (Phone='"+bo.Phone+
                "' or Address='"+bo.Address + "')";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
                return (BondsMan.GetBondsMan(ToOffice.txtToInt(((Hashtable)ar[0])["Id"].ToString())));
            else
                return null;
        }
        public static BondsMan  GetBondsMan(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from BondsMan where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
            {
                BondsMan M = new BondsMan();
                foreach (Hashtable h in ar)
                {
                    M._id = id;
                    M._name = h["Name"] != null ? (string)h["Name"] : "";
                    M._notes = h["Notes"] is DBNull != true ? (string)h["Notes"] : "";
                    M._MonthlyIncome = h["MonthlyIncome"] != null ? h["MonthlyIncome"].ToString() : "";
                    M._jop = h["Jop"] != null ? (string)h["Jop"] : "";
                    M._Phone = h["Phone"] != null ? (string)h["Phone"] : "";
                    M._Address = h["Address"] != null ? h["Address"].ToString() : "";
                    M._Rating = h["Rating"].GetType() != typeof(DBNull) ? int.Parse(h["Rating"].ToString()) : 0;
                    M._Salary = h["Salary"].GetType() != typeof(DBNull) ? int.Parse(h["Salary"].ToString()) : 0;
                }
                return M;
            }
            else
                return null;
        }
        public static int GetFreeId()
        {
            string sql = "select id from bondsman order by id desc";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            return int.Parse(((Hashtable)ar[0])["id"].ToString())+1;
        }
        public static int GetLastId()
        {
            string sql = "select id from bondsman order by id desc";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            return int.Parse(((Hashtable)ar[0])["id"].ToString());
        }
        public static BondsMan[] GetBondsMans(string txt, BondsManSearch Searchtype, StringComparison comp)
        {
            string sql = null;
            if (comp == StringComparison.CurrentCulture || comp == StringComparison.InvariantCulture ||
                comp == StringComparison.Ordinal)
            {
                switch (Searchtype)
                {
                    case BondsManSearch.Name:
                        {
                            sql = "select id from BondsMan where Name='" + txt + "'";
                            break;
                        }
                    case BondsManSearch.Jop:
                        {
                            sql = "select id from BondsMan where Jop='" + txt + "'";
                            break;
                        }
                    case BondsManSearch.MonthlyIncome:
                        {
                            sql = "select id from BondsMan where MonthlyIncome='" + txt + "'";
                            break;
                        }
                    case BondsManSearch.Phone:
                        {
                            sql = "select id from BondsMan where Phone='" + txt + "'";
                            break;
                        }
                    case BondsManSearch.Address:
                        {
                            sql = "select id from BondsMan where Address='" + txt + "'";
                            break;
                        }
                }
            }
            else
            {
                switch (Searchtype)
                {
                    case BondsManSearch.Name:
                        {
                            sql = "select id from BondsMan where Name like '%" + txt + "%'";
                            break;
                        }
                    case BondsManSearch.Jop:
                        {
                            sql = "select id from BondsMan where Jop like '%" + txt + "%'";
                            break;
                        }
                    case BondsManSearch.MonthlyIncome:
                        {
                            sql = "select id from BondsMan where MonthlyIncome like '%" + txt + "%'";
                            break;
                        }
                    case BondsManSearch.Phone:
                        {
                            sql = "select id from BondsMan where Phone like '%" + txt + "%'";
                            break;
                        }
                    case BondsManSearch.Address:
                        {
                            sql = "select id from BondsMan where Address like '%" + txt + "%'";
                            break;
                        }
                }
            }
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                BondsMan[] Fs = new BondsMan[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i++] = GetBondsMan(fids);
                }
                return Fs;
            }
            else
                return null;
        }
        public static BondsMan[] GetBondsMans()
        {
            string sql = "select id from BondsMan";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                BondsMan[] Fs = new BondsMan[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i++] = GetBondsMan(fids);
                }
                return Fs;
            }
            else
                return null;
        }
        public Orphan[] getOrphans()
        {
            string sql = "select id from Orphan where Bondsman_Id ="
    + this._id.ToString() ;
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
        public int getOrphansNumber()
        {
            string sql = "select count(id) as ee from Orphan where Bondsman_Id ="
    + this._id.ToString();
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Hashtable h = (Hashtable)ar[0];
                int Oid = int.Parse(h["ee"].ToString());
                return Oid;
            }
            else
                return 0;
        }
        public int CalculateRating(bool excep)
        {
            double num = 0,sum=0;
            Orphan[] ors = getOrphans();
            if (ors == null || ors.Length == 0) return 0;
            foreach (Orphan or in ors)
            {
                if (!excep)
                {
                    num++;
                    sum += or.Rating;
                }
                else
                    if (or.Suporter_ID == 0)
                    {
                        num++;
                        sum += or.Rating;
                    }
            }
            int rat = 0;
            if (num != 0)
            {
                int Mid = (int)Math.Ceiling(sum / num);

                if (num == 1) rat = (Mid + 20) / 2;
                else if (num >= 2 && num <= 3) rat = (Mid + 40) / 2;
                else if (num >= 4 && num <= 5) rat = (Mid + 60) / 2;
                else if (num >= 6 && num <= 7) rat = (Mid + 80) / 2;
                else
                    rat = (Mid + 100) / 2;
            }
            else
                rat = 0;
            this._Rating = rat;
            Save();
            return rat;

        }

        public bool Save()
        {
            DataBaseWorker dbw = new DataBaseWorker();

            if (Exist(this._id))
            {            
                string sql = "Update BondsMan Set Name='" + this._name  +
                    "',Jop='" + this._jop + "',MonthlyIncome='" + this._MonthlyIncome +
                    "',Phone='" + this._Phone +
                    "',Address='" + this._Address + "',Notes='" + this._notes +
                    "',Rating=" + this._Rating.ToString() +
                    ",Salary=" + this._Salary.ToString() + " where Id=" + this._id.ToString();
                return dbw.ExcuteCommand(sql);
            }
            else
            {
                string sql = "Insert Into BondsMan(Name,Jop,MonthlyIncome,Phone,Address,Notes) Values('"
                    + this._name + "','" + this._jop + "','" +
                    this._MonthlyIncome + "','" + this._Phone + "','" + this._Address +
                    "','" + this._notes  + "')";
                return dbw.ExcuteCommand(sql);
            }
        }
        public bool Delete()
        {
            if (this._id == 0) return false;
            string sql = "delete from BondsMan where id=" + this._id;
            DataBaseWorker dbw = new DataBaseWorker();
            return dbw.ExcuteCommand(sql);
        }
    }
}
