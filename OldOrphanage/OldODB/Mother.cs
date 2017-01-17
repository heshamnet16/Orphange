using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace OrphansRegistries
{
    public class Mother:Person
    {
        private int _id;
        private string _name;
        private DateTime _birthday;
        private string _notes;
        private string _jop;
        private bool _IsMarried;
        private bool _isOwnOrphan;
        private bool _isAlive;
        private int _HusbandId;
        private string _IsOwnOtherOrphans;
        private string _IdentityNum;

        public Mother(int id,string name,DateTime birthday,string notes,string jop,bool isMarried,
            bool isOwnOrphan,bool isAlive,string IsownOthers,string IdentityNum,int husbandiD)
        {
            this._birthday = birthday;
            this._HusbandId = husbandiD;
            this._id = id;
            this._IdentityNum = IdentityNum;
            this.IsAlive = isAlive;
            this._IsMarried = isMarried;
            this._isOwnOrphan = isOwnOrphan;
            this._IsOwnOtherOrphans = IsownOthers;
            this._jop = jop;
            this._name = name;
            this._notes = notes;
        }
        public Mother() { }
        public string Jop
        {
            get { return _jop; }
            set { _jop = value; }
        }
        public bool IsMarried
        {
            get { return _IsMarried; }
            set { _IsMarried = value; }
        }
        public bool IsOwnOrphan
        {
            get { return _isOwnOrphan; }
            set { _isOwnOrphan = value; }
        }
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }
        public int HusbandId
        {
            get { return _HusbandId; }
            set { _HusbandId = value; }
        }
        public string IdentityNum
        {
            get { return _IdentityNum; }
            set { _IdentityNum = value; }
        }
        public string IsOwnOtherOrphans
        {
            get { return _IsOwnOtherOrphans; }
            set { _IsOwnOtherOrphans = value; }
        }
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
            }
        }
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
 
        public static bool Exist(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Mother where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
                return true;
            else
                return false;
        }
        public static Mother GetMother(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Mother where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
            {
                Mother M = new Mother();
                foreach (Hashtable h in ar)
                {
                    M._birthday = h["Birthday"] != null ? (DateTime)h["Birthday"] : new DateTime(9999, 12, 1);
                    M._id = id;
                    M._name = h["Name"] != null ? (string)h["Name"] : "";
                    M._notes = h["Notes"] != null ? (string)h["Notes"] : "";
                    M._HusbandId = h["Husband_id"] != null ? int.Parse(h["Husband_id"].ToString()) : 0;
                    M._IdentityNum = h["IdentityNumber"] != null ? (string)h["IdentityNumber"] : "";
                    M._jop = h["Jop"] != null ? (string)h["Jop"] : "";
                    M._IsOwnOtherOrphans = h["IsOwnOrphans"] != null ? (string)h["IsOwnOrphans"] : "";
                    M._isAlive = h["IsAlive"] != null ? bool.Parse(h["IsAlive"].ToString()) : false;
                    M._isOwnOrphan = h["IsOwnOrphan"] != null ? bool.Parse(h["IsOwnOrphan"].ToString()) : false;
                    M._IsMarried = h["IsMarried"] != null ? bool.Parse(h["IsMarried"].ToString()) : false;
                }
                return M;
            }
            else
                return null;
        }
        public static Mother[] GetMothers(string Mname, StringComparison comp)
        {
            string sql;
            if (comp == StringComparison.CurrentCulture || comp == StringComparison.InvariantCulture ||
                comp == StringComparison.Ordinal)
            {
                sql = "select id from Mother where name='" + Mname + "'";
            }
            else
                sql = "select id from Mother where name like'%" + Mname + "%'";

            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Mother[] Fs = new Mother[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i++] = GetMother(fids);
                }
                return Fs;
            }
            else
                return null;
        }
        public static Mother[] GetMothers(bool IsAlive)
        {
            string sql;
            string value;
            if (IsAlive)
                value = "1";
            else
                value = "0";
            sql = "select id from Mother where IsAlive =" +  value + "";

            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Mother[] Fs = new Mother[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["Id"].ToString());
                    Fs[i++] = GetMother(fids);
                }
                return Fs;
            }
            else
                return null;
        }
        public static Mother[] GetMothers()
        {
            string sql;
            sql = "select id from Mother ";

            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Mother[] Fs = new Mother[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i++] = GetMother(fids);
                }
                return Fs;
            }
            else
                return null;
        }
     
        public Family[] GetFamily()
        {
            string sql = "select id from Family where M_id=" + this._id.ToString();
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Family[] O = new Family[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int Oid = int.Parse(h["id"].ToString());
                    O[i++] = Family.GetFamily(Oid);
                }
                return O;
            }
            else
                return null;
        }
        public static int GetFreeId()
        {
            string sql = "select id from mother order by id desc";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            return int.Parse(((Hashtable)ar[0])["id"].ToString())+1;
        }
        public static int getMothersCount()
        {
            string sql = "select count(id) as maxx from Mother";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Hashtable h = (Hashtable)ar[0];
                int fids = int.Parse(h["maxx"].ToString());
                return fids;
            }
            else
                return 0;

        }

        public static int GetLastId()
        {
            string sql = "select id from mother order by id desc";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            return int.Parse(((Hashtable)ar[0])["id"].ToString());
        }
        public Father[] GetHusband()
        {
            if (this._HusbandId > 0)
            {
                string sql = "select id from Father where id="+this._HusbandId.ToString();
                DataBaseWorker dbw = new DataBaseWorker();
                ArrayList ar= dbw.ExcuteResultCommand(sql);
                if (ar.Count > 0)
                {
                    Father[] Fs = new Father[ar.Count];
                    int i = 0;
                    foreach (Hashtable h in ar)
                    {
                        int fids = int.Parse(h["id"].ToString());
                        Fs[i++] = Father.GetFather(fids);
                    }
                    return Fs;
                }
                else
                    return null;
            }
            else
                return null;
        }
        public Orphan[] GetSons()
        {
            string sql = "select id from Orphan where Family_id in (select id from Family where M_id="
                        + this._id.ToString() + ")";
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

        public int GetSonsNumber()
        {
            string sql = "select count(id) as ee from Orphan where Family_id in (select id from Family where M_id="
                        + this._id.ToString() + ")";
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
        public bool Save()
        {
            DataBaseWorker dbw = new DataBaseWorker();
            if (Exist(this._id))
            {
                string sql = "Update Mother Set Name='" + this._name + "'," +
                    "Birthday='" + this.Birthday.ToString("yyyy/MM/dd") + "',IdentityNumber='" +
                    this._IdentityNum + "',Jop='" + this._jop + "',IsOwnOrphans='" + this._IsOwnOtherOrphans +
                    "',IsOwnOrphan=" + GetboolValue(this._isOwnOrphan) + ",IsMarried=" +
                    GetboolValue(this._IsMarried) + ",Notes='" + this._notes + "',IsAlive=" + GetboolValue(this._isAlive) +
                    ",Husband_id=" + this._HusbandId.ToString() + " where Id=" + this._id.ToString();
                return dbw.ExcuteCommand(sql);
            }
            else
            {
                Mother[] mothers = Mother.GetMothers(this.Name, StringComparison.CurrentCultureIgnoreCase);
                if (mothers != null)
                {
                    foreach (Mother moth in mothers)
                    {
                        if (moth.Birthday == moth.Birthday || moth.HusbandId == moth.HusbandId)
                        {
                            this.Name += "(مكرر)";
                            break;
                        }
                    }
                }
                string sql = "Insert Into Mother(Name,Birthday,IdentityNumber,Jop,IsMarried,IsOwnOrphan," +
                    "IsOwnOrphans,Notes,IsAlive,Husband_id) Values("
                    + "'" + this._name + "'," +
                    "'" + this.Birthday.ToString("yyyy/MM/dd") + "','" +
                    this._IdentityNum + "','" + this._jop + "'," + GetboolValue(this._IsMarried) +
                    "," + GetboolValue(this._isOwnOrphan) + ",'" +
                    this._IsOwnOtherOrphans + "','" + this._notes + "'," + GetboolValue(this._isAlive) +
                    "," + this._HusbandId.ToString() + ")";
                return dbw.ExcuteCommand(sql);
            }

        }
        private char GetboolValue(bool par)
        {
            if (par) return '1';
            else
                return '0';
        }
        public static Mother Exist(Mother Moth)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Mother where name='" + Moth.Name + "' and Birthday='"
                + Moth.Birthday.ToString("yyyy/MM/dd") + "'";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
                return Mother.GetMother(ToOffice.txtToInt(((Hashtable)(ar[0]))["Id"].ToString()));
            else
                return null;
        }


        public bool Delete()
        {
            if (this._id == 0) return false;
            Orphan[] ors = GetSons();

            //if (this.GetHusband() == null)
            //{
            //    string sql = "delete from Mother where id=" + this._id;
            //    DataBaseWorker dbw = new DataBaseWorker();
            //    return dbw.ExcuteTransaction(new string[] {  sql });
            //}
            if (this.GetHusband()[0].GetWifes().Length == 1)
            {

                string sql1 = "delete from Father where id=" + this.HusbandId;
                string sql = "delete from Mother where id=" + this._id;
                string sql2 = "delete from Family where M_id=" + this.Id.ToString() + " and F_id=" + this.HusbandId.ToString();
                string sql3 = "delete from Orphan where Family_id=" + this.GetFamily()[0].Id;
                DataBaseWorker dbw = new DataBaseWorker();
                if (ors != null)
                {
                    foreach (Orphan or in ors)
                    {
                        try
                        {
                            or.GetBondsMan().Delete();
                        }
                        catch (NullReferenceException) { }
                        catch (Exception) { throw; }
                    }
                }
                return dbw.ExcuteTransaction(new string[] { sql3, sql2, sql1, sql });
            }
            else
            {
                string sql = "delete from Mother where id=" + this._id;
                string sql2 = "delete from Family where M_id=" + this.Id.ToString() + " and F_id=" + this.HusbandId.ToString();
                string sql3 = "delete from Orphan where Family_id=" + this.GetFamily()[0].Id;                
                ArrayList bondsmans = new ArrayList();
                foreach (Mother Dor in this.GetHusband()[0].GetWifes())
                {
                    if (Dor.Id != this.Id)
                    {
                        Orphan[] sons = Dor.GetSons();
                        if (sons != null && sons.Length > 0)
                        {
                            foreach (Orphan or in sons)
                            {
                                int B_id = or.GetBondsMan().Id;
                                if (!bondsmans.Contains(B_id))
                                    bondsmans.Add(B_id);
                            }
                        }
                    }
                }
                if (ors != null)
                {
                    foreach (Orphan or in ors)
                    {
                        try
                        {
                            BondsMan bo = or.GetBondsMan();
                            if (!bondsmans.Contains(bo.Id))
                                or.GetBondsMan().Delete();
                        }
                        catch (NullReferenceException) { }
                        catch (Exception) { throw; }
                    }
                }
                DataBaseWorker dbw = new DataBaseWorker();
                return dbw.ExcuteTransaction(new string[] { sql3, sql2, sql });
            }
        }
    }
}
