using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace OrphansRegistries
{
    public class Family
    {
        public enum FamilySearch{Financial,ResidenceType,ResidenceState};
        private int _id=0;
        private int _Number;
        private string _FinancialState;
        private string _ResidenceState;
        private string _ResidenceType;
        private int _FatherId;
        private int _MotherId;

        public int MotherId
        {
            get { return _MotherId; }
            set { _MotherId = value; }
        }
        public int FatherId
        {
            get { return _FatherId; }
            set { _FatherId = value; }
        }
        public string ResidenceType
        {
            get { return _ResidenceType; }
            set { _ResidenceType = value; }
        }
        public string ResidenceState
        {
            get { return _ResidenceState; }
            set { _ResidenceState = value; }
        }
        public string FinancialState
        {
            get { return _FinancialState; }
            set { _FinancialState = value; }
        }
        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public static Family GetFamily(int fid)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Family where id =" + fid;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
            {
                Family F = new Family();
                foreach (Hashtable h in ar)
                {
                    F._id = fid;
                    F.ResidenceState = h["ResidenceState"] != null ? (string)h["ResidenceState"] : "";
                    F.ResidenceType = h["ResidenceType"] != null ? (string)h["ResidenceType"] : "";
                    F.FinancialState = h["FinancialState"] != null ? (string)h["FinancialState"] : "";
                    F.MotherId = h["M_id"] != null ? int.Parse(h["M_id"].ToString()) : 0;
                    F.FatherId = h["F_id"] != null ? int.Parse(h["F_id"].ToString()) : 0;
                    F.Number = h["Number"] != null ? int.Parse(h["Number"].ToString()) : 0;
                }
                return F;
            }
            else
                return null;
        }
        public static Family[] GetFamily(string Finan, FamilySearch type, StringComparison comp)
        {
            string sql = null;
            if (comp == StringComparison.CurrentCulture || comp == StringComparison.InvariantCulture ||
                comp == StringComparison.Ordinal)
            {
                switch (type)
                {
                    case FamilySearch.Financial:
                        {
                            sql = "select id from Family where FinancialState='" + Finan + "'";
                            break;
                        }
                    case FamilySearch.ResidenceState:
                        {
                            sql = "select id from Family where ResidenceState='" + Finan + "'";
                            break;
                        }
                    case FamilySearch.ResidenceType:
                        {
                            sql = "select id from Family where ResidenceType='" + Finan + "'";
                            break;
                        }
                }
            }
            else
            {
                switch (type)
                {
                    case FamilySearch.Financial:
                        {
                            sql = "select id from Family where FinancialState like '" + Finan + "'";
                            break;
                        }
                    case FamilySearch.ResidenceState:
                        {
                            sql = "select id from Family where ResidenceState like '" + Finan + "'";
                            break;
                        }
                    case FamilySearch.ResidenceType:
                        {
                            sql = "select id from Family where ResidenceType like '" + Finan + "'";
                            break;
                        }
                }
            }
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Family[] Fs = new Family[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i++] = GetFamily(fids);
                }
                return Fs;
            }
            else
                return null; 
        }

        public static bool Exist(Family fath)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Family where F_id'" + fath.FatherId+ " and M_id="
                + fath.MotherId + "";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
                return true;
            else
                return false;
        }
        public static bool Exist(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Family where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
                return true;
            else
                return false;
        }
        public static int GetLastId()
        {
            string sql = "select id from family order by id desc";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            return int.Parse(((Hashtable)ar[0])["id"].ToString());
        }
        public bool Save()
        {
            DataBaseWorker dbw = new DataBaseWorker();

            if (Exist(this._id))
            {
                string sql = "Update Family Set Number=" + this._Number.ToString() + 
                    ",FinancialState='" + this._FinancialState + "',ResidenceType='" + this._ResidenceType +
                    "',ResidenceState='" + this._ResidenceState +
                    "',F_id=" + this._FatherId.ToString() + ",M_id="+ this._MotherId.ToString() + 
                    " where Id=" + this._id.ToString();
                return dbw.ExcuteCommand(sql);
            }
            else
            {
                string sql = "Insert Into Family(Number,FinancialState,ResidenceType,ResidenceState,F_id,M_id) Values("
                    + this._Number + ",'" + this._FinancialState  + "','" +
                    this._ResidenceType  + "','"+ this._ResidenceState +"',"+ this._FatherId.ToString() +
                    ","+ this._MotherId.ToString() +")";
                return dbw.ExcuteCommand(sql);
            }
        }

        public Father GetFather()
        {
            if (this._FatherId > 0)
            {
                return Father.GetFather(this._FatherId);
            }
            else
                return null;
        }
        public Mother GetMother()
        {
            if (this._MotherId > 0)
                return Mother.GetMother(this._MotherId);
            else
                return null;
        }
        public Orphan[] getChilderns()
        {
            string sql = "select id from Orphan where Family_id ="
                        + this._id.ToString() + ")";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Orphan[] O = new Orphan[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int Oid = int.Parse(h["Id"].ToString());
                    O[i++] = Orphan.GetOrphan(Oid);
                }
                return O;
            }
            else
                return null;
        }

        public bool Delete()
        {
            if (this._id == 0) return false;
            return this.GetMother().Delete();
        }
    }
}
