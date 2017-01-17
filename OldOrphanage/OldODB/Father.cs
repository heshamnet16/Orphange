using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace OrphansRegistries
{
    public class Father : Person 
    {        
        private int _id;
        private string _name;
        private DateTime _die;
        private string _notes;
        private string _Work;
        public Father(int id,string name,DateTime die,string notes)
        {
            this.Id = id;
            this.Name = name;
            this.Birthday = die;
            this.Notes = notes;
        }
        public Father() { this._notes = null; this._name = null; this._id = 0; this._die = new DateTime(); }
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
        public string Work
        {
            get
            {
                return _Work;
            }
            set
            {
                _Work = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return _die;
            }
            set
            {
                _die = value;
            }
        }
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public static Father GetFather(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Father where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
            {
                Father F = new Father();
                foreach (Hashtable h in ar)
                {
                    F._die = h["DieDate"] != null ? (DateTime)h["DieDate"] : new DateTime(9999, 12, 1);
                    F._id = id;
                    F._name = h["Name"] != null ? (string)h["Name"] : "";
                    F._notes = h["Notes"] != null ? (string)h["Notes"] : "";
                    F._Work = h["Work"] != null && !(h["Work"] is DBNull) ? (string)h["Work"] : "";
                }
                GC.Collect();
                return F;
            }
            else
            {
                GC.Collect();
                return null;
            }
        }
        public static Father[] GetFathers()
        {
            string sql;
            sql = "select id from Father";

            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Father[] Fs = new Father[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i] = GetFather(fids);
                    i++;
                }
                return Fs;
            }
            else
                return null;
        }
        public static Father[] GetFathers(string Fname,StringComparison comp)
        {
            string sql;
            if (comp == StringComparison.CurrentCulture || comp == StringComparison.InvariantCulture ||
                comp == StringComparison.Ordinal)
            {
                sql = "select id from Father where name='" + Fname + "'";
            }
            else
                sql = "select id from Father where name like'%" + Fname + "%'";
                
            DataBaseWorker dbw = new DataBaseWorker();            
            ArrayList ar= dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Father[] Fs = new Father[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i++] = GetFather(fids);
                }
                return Fs;
            }
            else
                return null;            
        }
        public static Father[] GetFathers(DateTime diedate, char Operator)
        {
            if (Operator == '>' || Operator == '<' || Operator == '=')
            {
                string sql;
                sql = "select id from Father where dieDate "+ Operator + "'" + diedate.ToString("yyyy/MM/dd") + "'";

                DataBaseWorker dbw = new DataBaseWorker();
                ArrayList ar = dbw.ExcuteResultCommand(sql);
                if (ar.Count > 0)
                {
                    Father[] Fs = new Father[ar.Count];
                    int i = 0;
                    foreach (Hashtable h in ar)
                    {
                        int fids = int.Parse(h["id"].ToString());
                        Fs[i++] = GetFather(fids);
                    }
                    return Fs;
                }
                else
                    return null;  
            }
            else
                return null;

        }
        public static Father[] GetSupportedFathers()
        {
            string sql;
            sql = "select distinct F.id from Father F , Family Fa , Orphan O where (O.Family_ID=Fa.id) and"+
                " (Fa.F_id=F.id) and ((O.suporter_id > 0) Or (O.suporter_id is not NULL) )";

            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Father[] Fs = new Father[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i] = GetFather(fids);
                    i++;
                }
                return Fs;
            }
            else
                return null;
        }
        public static Father[] GetUnSupportedFathers()
        {
            string sql;
            sql = "select distinct F.id from Father F , Family Fa , Orphan O where (O.Family_ID=Fa.id) and" +
                " (Fa.F_id=F.id) and ((O.suporter_id = 0) or (O.suporter_id is NULL))";

            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Father[] Fs = new Father[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i] = GetFather(fids);
                    i++;
                }
                return Fs;
            }
            else
                return null;
        }
        public static bool HasAnSupportedOrphan(Father F)
        {
            string sql;           
            sql = "select O.id from orphan O ,family f,Father Fa where (O.Family_ID=f.id) and (f.F_id="+F.Id+") "+
                "and ((O.suporter_id is not NULL) or (O.suporter_id > 0) ) ";

            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                return true;
            }
            else
                return false; 
        }
        public static int getFathersCount()
        {
            string sql = "select count(id) as maxx from Father";
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
        public static int getMarriedtwiceFathersCount()
        {
            string sql = "select count(F_id) as maxx from family";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Hashtable h = (Hashtable)ar[0];
                int fids = int.Parse(h["maxx"].ToString());
                fids = fids - getFathersCount();
                return fids;
            }
            else
                return 0;

        }
        public static int getMaryterFathers()
        {
            string sql = "select count(id) as maxx from father where diedate > '2011/03/14'";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Hashtable h = (Hashtable)ar[0];
                int fids = int.Parse(h["maxx"].ToString());
                fids =  getFathersCount() - fids;
                return fids;
            }
            else
                return 0; 
        }
        public static int getUnMaryterFathers()
        {
            string sql = "select count(id) as maxx from father where diedate <= '2011/03/14'";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Hashtable h = (Hashtable)ar[0];
                int fids = int.Parse(h["maxx"].ToString());
                fids =  getFathersCount() - fids;
                return fids;
            }
            else
                return 0;
        }

        public static bool Exist(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Father where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
                return true;
            else
                return false;
        }
        public static Father Exist(Father fath)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Father where name='" + fath.Name + "' and DieDate='"
                +fath.Birthday.ToString("yyyy/MM/dd") +"'";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
                return Father.GetFather(ToOffice.txtToInt(((Hashtable)(ar[0]))["id"].ToString()));
            else
                return null;
        }
        public static int GetFreeId()
        {
            string sql = "select id from father order by id desc";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            return int.Parse(((Hashtable)ar[0])["id"].ToString())+1;
        }
        public static int GetLastId()
        {
            string sql = "select id from father order by id desc";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            return int.Parse(((Hashtable)ar[0])["id"].ToString());
        }
        public bool Save()
        {
            DataBaseWorker dbw = new DataBaseWorker();
            if (Exist(this._id))
            {
                string sql = "Update Father Set Name='" + this._name + "'," +
                    "DieDate='" + this.Birthday.ToString("yyyy/MM/dd") +
                    "',Work='"+this._Work + "',Notes='" + this._notes + "' where Id=" + this._id.ToString();
                return dbw.ExcuteCommand(sql);
            }
            else
            {
                Father[] faths = Father.GetFathers(this.Name, StringComparison.CurrentCultureIgnoreCase);
                if (faths != null)
                {
                    foreach (Father f in faths)
                    {
                        if (f.Birthday == this.Birthday)
                        {
                            this.Name += "(مكرر)";
                            break;
                        }
                    }
                }
                string sql = "Insert Into Father(Name,DieDate,Notes,Work) Values("
                    + "'" + this._name + "','" +this.Birthday.ToString("yyyy/MM/dd") + "','" +
                    this._notes +"','"+ this._Work + "')";
                return dbw.ExcuteCommand(sql);
            }
        }
        public Family[] GetFamily()
        {
            string sql = "select id from Family where F_id=" + this._id.ToString();
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
        public Orphan[] GetSons()
        {
            string sql = "select id from Orphan where Family_id in (select id from Family where F_id="
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
                ar.Clear();
                GC.Collect();
                return O;
            }
            else
            { GC.Collect(); return null; }
        }
        public int GetSonsNumber()
        {
            string sql = "select count(id) As ee from Orphan where Family_id in (select id from Family where F_id="
                             + this._id.ToString() + ")";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Hashtable h = (Hashtable)ar[0];
                return int.Parse(h["ee"].ToString());
            }
            else
                return 0;
        }
        public Mother[] GetWifes()
        {
            string sql = "select id from Mother where Husband_id=" + this._id.ToString();
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Mother[] O = new Mother[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int Oid = int.Parse(h["id"].ToString());
                    O[i++] = Mother.GetMother(Oid);
                }
                return O;
            }
            else
                return null;
        }


        public bool Delete()
        {
            if (this._id == 0) return false;
            Orphan[] ors = GetSons();
                string sql1 = "delete from Father where id=" + this._id;
                string sql = "delete from Mother where Husband_id=" + this.Id;
                string sql2 = "delete from Family where  F_id=" + this._id.ToString();
                string sql4 = "delete from bondsMan where id in (select BondsMan_id from Orphan where Family_id in ("+
                    "select id from family where F_id="+this._id.ToString() + "))";
                string sql3=null;
                if (this.GetFamily() != null)
                {
                    sql3 = "delete from Orphan where Family_id in (select id from Family where F_id=" +
                           +this._id + ")";
                    DataBaseWorker dbw = new DataBaseWorker();
                    return dbw.ExcuteTransaction(new string[] { sql3, sql2, sql1, sql,sql4 });
                }
                else
                {
                    DataBaseWorker dbw = new DataBaseWorker();
                    return dbw.ExcuteTransaction(new string[] { sql2, sql1, sql,sql4 });
                }            
        }
    }
}
