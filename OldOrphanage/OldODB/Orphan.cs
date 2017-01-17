using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace OrphansRegistries
{
    public class Orphan:Person
    {
        public enum OrphanSearch {Name,Birthday,BirthPlace,Sex,HealthState,StudiesStage};
        private int _id;
        private string _name;
        private DateTime _Birthday;
        private string _BirthPlace;
        private int _Family_Id;
        private string _Nationality;
        private string _Sex;
        private string _HealthyState;
        private string _StudiesStage;
        private string _BondsMan_R;
        private System.Drawing.Image _Photo;
        private string _Notes;
        private int _Bondsman_Id;
        private int _Suporter_ID;
        private int _Rating;
        private int _Salary;
        private DateTime _Suporter_endDate;
        private DateTime _Suporter_StartDate;
        private byte[] _BytePhoto;
        public byte[] BytePhoto
        {
            get 
            {
                return _BytePhoto;
            }
            set { _BytePhoto = value; }
        }
        private int _ApproximateSalary;

        public int ApproximateSalary
        {
            get { return _ApproximateSalary; }
            set { _ApproximateSalary = value; }
        }

        public int Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }
        public DateTime Suporter_StartDate
        {
            get { return _Suporter_StartDate; }
            set { _Suporter_StartDate = value; }
        }
        public int Suporter_ID
        {
            get { return _Suporter_ID; }
            set { _Suporter_ID = value; }
        }
        public DateTime Suporter_endDate
        {
            get { return _Suporter_endDate; }
            set { _Suporter_endDate = value; }
        }

        public int Rating
        {
            get { return _Rating; }
            set { _Rating = value; }
        }
        public string BirthPlace
        {
            get { return _BirthPlace; }
            set { _BirthPlace = value; }
        }
        public string Nationality
        {
            get { return _Nationality; }
            set { _Nationality = value; }
        }
        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
        public string HealthyState
        {
            get { return _HealthyState; }
            set { _HealthyState = value; }
        }
        public string StudiesStage
        {
            get { return _StudiesStage; }
            set { _StudiesStage = value; }
        }
        public string BondsMan_R
        {
            get { return _BondsMan_R; }
            set { _BondsMan_R = value; }
        }
        public System.Drawing.Image Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        public int Bondsman_Id
        {
            get { return _Bondsman_Id; }
            set { _Bondsman_Id = value; }
        }
        public int Family_Id
        {
            get { return _Family_Id; }
            set { _Family_Id = value; }
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
        public DateTime Birthday
        {
            get
            {
                return this._Birthday;
            }
            set
            {
                this._Birthday = value;
            }
        }

        public static int GetAllOrphanNumber()
        {
            string sql = "select id from Orphan";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                return ar.Count;
            }
            else
            {
                return 0;
            } 
        }
        public static int GetFreeId()
        {
            string sql = "select id from Orphan order by id DESC";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                return int.Parse(((Hashtable)ar[0])["id"].ToString()) + 1;
            }
            else
            {
                return 1;
            }

        }
        public bool IsSupported()
        {
            if (this.Suporter_ID > 0)
            {
                Bill b = Bill.getSpecificBill(this, this.GetSuporter());
                if (b != null)
                {
                    if (b.IsCanceled == false && b.IsFinished == false)
                        return true;
                    else
                        return false;
                }
                else
                {
                    try
                    {
                        this.GetSuporter().DisSuport(this);
                        this._Suporter_ID = 0;
                        Save();
                    }
                    catch { }
                    return false;
                }
            }
            return false;
        }
        public static Orphan GetOrphan(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql ="Select * from Orphan where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql); 
            if(ar.Count ==1)
            {
                Orphan O = new Orphan();
                foreach (Hashtable h in ar)
                {
                    O._Birthday =  h["Birthday"] != null ? (DateTime)h["Birthday"] : new DateTime(9999,12,1);
                    //O.Suporter_endDate = h["Support_End"] is DBNull == false ? (DateTime)h["Support_End"] : new DateTime(9999, 12, 1);
                    //O.Suporter_StartDate = h["Support_Start"] is DBNull == false ? (DateTime)h["Support_Start"] : new DateTime(9999, 12, 1);
                    O._BirthPlace = h["Birthplace"] != null ? (string)h["Birthplace"] : "";
                    O._Bondsman_Id = h["Bondsman_Id"] !=null ? int.Parse(h["Bondsman_Id"].ToString()) : 0;
                    O._BondsMan_R = h["BondsMan_Relationship"] != null ? (string)h["BondsMan_Relationship"] : "";
                    O._Family_Id = h["Family_ID"] != null ? int.Parse(h["Family_ID"].ToString()) : 0;
                    O._HealthyState = h["HealthyState"] != null ? (string)h["HealthyState"] : "";
                    O._id = id;
                    O._name = h["Name"] != null ? (string)h["Name"] : "";
                    O._Nationality = h["Nationality"] != null ? (string)h["Nationality"] : "";
                    O._Notes = h["Notes"] is DBNull == false ? (string)h["Notes"] : "";
                    O._Sex = h["Sex"] != null ? (string)h["Sex"] : "";
                    O._StudiesStage = h["StudiesStage"] != null ? (string)h["StudiesStage"] : "";
                    try
                    {
                        byte[] bytes = h["Photo"] != null ? (byte[])h["Photo"] : null;
                        System.IO.MemoryStream mem = new System.IO.MemoryStream(bytes);
                        O._Photo = System.Drawing.Image.FromStream(mem);
                        O._BytePhoto = bytes;
                        mem.Close();
                        mem.Dispose();
                    }
                    catch 
                    {
                        O._Photo = null;
                        O._BytePhoto = null;
                    }
                    O._Suporter_ID = h["Suporter_ID"].GetType() != typeof (DBNull) ? int.Parse(h["Suporter_ID"].ToString()) : 0;
                    O._Rating = h["Rating"].GetType() != typeof(DBNull) ? int.Parse(h["Rating"].ToString()) : 0;
                    O._Salary = h["Salary"].GetType() != typeof(DBNull) ? int.Parse(h["Salary"].ToString()) : 0;
                    O._ApproximateSalary = h["ApproximateSalary"].GetType() != typeof(DBNull) ? int.Parse(h["ApproximateSalary"].ToString()) : 0;                    
                }
                return O;
            }
            else
                return null;

        }
        public static Orphan[] GetOrphans(string txt, OrphanSearch Searchtype, StringComparison comp)
        {
            string sql = null;
            if (comp == StringComparison.CurrentCulture || comp == StringComparison.InvariantCulture ||
                comp == StringComparison.Ordinal)
            {
                switch (Searchtype)
                {
                    case OrphanSearch.Name :
                        {
                            sql = "select id from Orphan where Name='" + txt + "'";
                            break;
                        }
                    case OrphanSearch.Birthday:
                        {
                            sql = "select id from Orphan where Name='" + txt + "'";
                            break;
                        }

                    case OrphanSearch.BirthPlace:
                        {
                            sql = "select id from Orphan where Birthplace='" + txt + "'";
                            break;
                        }
                    case OrphanSearch.HealthState:
                        {
                            sql = "select id from Orphan where HealthState='" + txt + "'";
                            break;
                        }
                    case OrphanSearch.StudiesStage:
                        {
                            sql = "select id from Orphan where StudiesStage='" + txt + "'";
                            break;
                        }
                    case OrphanSearch.Sex:
                        {
                            sql = "select id from Orphan where Sex='" + txt + "'";
                            break;
                        }
                }
            }
            else
            {
                switch (Searchtype)
                {
                    case OrphanSearch.Name:
                        {
                            sql = "select id from Orphan where Name like '%" + txt + "%'";
                            break;
                        }
                    case OrphanSearch.BirthPlace:
                        {
                            sql = "select id from Orphan where Birthplace like '%" + txt + "%'";
                            break;
                        }
                    case OrphanSearch.HealthState:
                        {
                            sql = "select id from Orphan where HealthState like '%" + txt + "%'";
                            break;
                        }
                    case OrphanSearch.StudiesStage:
                        {
                            sql = "select id from Orphan where StudiesStage like '%" + txt + "%'";
                            break;
                        }
                    case OrphanSearch.Sex:
                        {
                            sql = "select id from Orphan where Sex like '%" + txt + "%'";
                            break;
                        }
                }
            }
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Orphan[] Fs = new Orphan[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i++] = GetOrphan(fids);
                }
                return Fs;
            }
            else
                return null; 
        }
        public static Orphan[] GetOrphans(DateTime birthday, char Operator)
        {
            if (Operator == '>' || Operator == '<' || Operator == '=')
            {
                string sql;
                sql = "select id from Orphan where Birthday " + Operator + "'" + birthday.ToString("yyyy/MM/dd") + "'";

                DataBaseWorker dbw = new DataBaseWorker();
                ArrayList ar = dbw.ExcuteResultCommand(sql);
                if (ar.Count > 0)
                {
                    Orphan[] Fs = new Orphan[ar.Count];
                    int i = 0;
                    foreach (Hashtable h in ar)
                    {
                        int fids = int.Parse(h["Id"].ToString());
                        Fs[i++] = GetOrphan(fids);
                    }
                    return Fs;
                }
                else
                    return null;
            }
            else
                return null;

        }
        public static Orphan[] GetOrphans(int _rating, char Operator)
        {
            if (Operator == '>' || Operator == '<' || Operator == '=')
            {
                string sql;
                sql = "select id from Orphan where rating " + Operator + _rating.ToString();

                DataBaseWorker dbw = new DataBaseWorker();
                ArrayList ar = dbw.ExcuteResultCommand(sql);
                if (ar.Count > 0)
                {
                    Orphan[] Fs = new Orphan[ar.Count];
                    int i = 0;
                    foreach (Hashtable h in ar)
                    {
                        int fids = int.Parse(h["id"].ToString());
                        Fs[i++] = GetOrphan(fids);
                    }
                    return Fs;
                }
                else
                    return null;
            }
            else
                return null;

        }
        public static Orphan[] GetOrphans(string search)
        {
            string sql = "select Id from orphan where " + search;
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Orphan[] Fs = new Orphan[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["Id"].ToString());
                    Fs[i++] = GetOrphan(fids);
                }
                return Fs;
            }
            else
                return null; 
        }
        public static Orphan[] GetOrphans(bool IsSuported)
        {
            string sql;
            if(IsSuported)
                sql = "select id from Orphan where (Suporter_id > 0)";
            else
                sql = "select id from Orphan where (Suporter_id is NULL) or (Suporter_id = 0)";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Orphan[] Fs = new Orphan[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i++] = GetOrphan(fids);
                }
                return Fs;
            }
            else
                return null;
        }
        public static Orphan[] GetOrphans(int From,int To)
        {
            string sql = "select id from Orphan where (id >=" + From.ToString() + ") And (id <="
                + To.ToString() + ")";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Orphan[] Fs = new Orphan[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    int fids = int.Parse(h["id"].ToString());
                    Fs[i++] = GetOrphan(fids);
                }
                return Fs;
            }
            else
                return null;
        }
        public static Orphan[] GetOrphans()
        {
                string sql = "select id from Orphan";
                DataBaseWorker dbw = new DataBaseWorker();
                ArrayList ar = dbw.ExcuteResultCommand(sql);
                if (ar.Count > 0)
                {
                    Orphan[] Fs = new Orphan[ar.Count];                    
                    int i = 0;
                    foreach (Hashtable h in ar)
                    {
                        int fids = int.Parse(h["id"].ToString());
                        Fs[i++] = GetOrphan(fids);
                    }
                    return Fs;
                }
                else
                    return null;
        }
        public static int GetMaxOrphanId()
        {
            string sql = "select Max(id) as maxx from Orphan";
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
        public static bool Exist(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql ="Select * from Orphan where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql); 
            if(ar.Count ==1)
                return true;
            else
                return false;
        }
        public static Orphan Exist(Orphan O)
        {
            Father F = O.GetFather();
            Mother M = O.GetMother();
            
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Orphan where Family_Id in(select id from Family where F_id="+F.Id + " and M_id="+M.Id+
                ") and Name Like '"+ O.Name + "'";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
                return Orphan.GetOrphan(ToOffice.txtToInt(((Hashtable)(ar[0]))["Id"].ToString()));
            else
                return null;
        }
        public static int GetOrphansCount()
        {
            string sql = "select count(id) as cou from Orphan";
            DataBaseWorker dbw = new DataBaseWorker();
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Hashtable h = (Hashtable)ar[0];
                int fids = int.Parse(h["cou"].ToString());
                return fids;
            }
            else
                return 0;
        }
        public static int GetSuportedOrphanCount()
        {
            string sql = "select count(id) as maxx from Orphan where (suporter_id <> NULL) or (suporter_id <> 0)";
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
        public static int getOrphansUnder10()
        {
            DateTime dt = new DateTime(DateTime.Now.Year - 10, 1, 1);
            string sql = "select count(id) as maxx from Orphan where birthday between '"+
                dt.ToString("yyyy/MM/dd") + "' and '" + DateTime.Now.ToString("yyyy/MM/dd") + "'";
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
        public static int getOrphansUnder6()
        {
            DateTime dt = new DateTime(DateTime.Now.Year - 6, 1, 1);
            string sql = "select count(id) as maxx from Orphan where birthday between '" +
                dt.ToString("yyyy/MM/dd") + "' and '" + DateTime.Now.ToString("yyyy/MM/dd") + "'";
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
        public static int getOrphansUnder3()
        {
            DateTime dt = new DateTime(DateTime.Now.Year - 3, 1, 1);
            string sql = "select count(id) as maxx from Orphan where birthday between '" +
                dt.ToString("yyyy/MM/dd") + "' and '" + DateTime.Now.ToString("yyyy/MM/dd") + "'";
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
        public static int getOrphansUnderYear()
        {
            DateTime dt = new DateTime(DateTime.Now.Year - 1, 1, 1);
            string sql = "select count(id) as maxx from Orphan where birthday between '" +
                dt.ToString("yyyy/MM/dd") + "' and '" + DateTime.Now.ToString("yyyy/MM/dd") + "'";
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

        public bool Save()
        {
            if (this._id == 0) return false;
            DataBaseWorker dbw = new DataBaseWorker();
            if (Exist(this._id))
            {
                string sql;
                if(this.Suporter_ID >0)
                    sql = "Update Orphan Set Name='" + this._name + "'," +
                        "Birthday='" + this.Birthday.ToString("yyyy/MM/dd") + "',Nationality='" +
                        this._Nationality + "',Sex='" + this._Sex + "',HealthyState='" + this._HealthyState +
                        "',StudiesStage='" + this._StudiesStage + "',BondsMan_Relationship='" +
                        this._BondsMan_R + "',Notes='" + this._Notes + "',Bondsman_Id=" + this._Bondsman_Id.ToString() +
                        ",Family_ID=" + this._Family_Id.ToString() + ",Birthplace='" + this._BirthPlace + "',Photo=@Photo"
                        + ",Rating=" + this._Rating.ToString() + ",Salary=" + this._Salary.ToString()
                        + ",ApproximateSalary=" + this._ApproximateSalary.ToString() + ",Suporter_ID=" + this.Suporter_ID 
                        + ",Support_End='" + this._Suporter_endDate.ToString("yyyy/MM/dd") + "'" +
                        ",Support_Start='" + this._Suporter_endDate.ToString("yyyy/MM/dd") + "'" + " where Id=" + this._id.ToString();
                else
                    sql = "Update Orphan Set Name='" + this._name + "'," +
                        "Birthday='" + this.Birthday.ToString("yyyy/MM/dd") + "',Nationality='" +
                        this._Nationality + "',Sex='" + this._Sex + "',HealthyState='" + this._HealthyState +
                        "',StudiesStage='" + this._StudiesStage + "',BondsMan_Relationship='" +
                        this._BondsMan_R + "',Notes='" + this._Notes + "',Bondsman_Id=" + this._Bondsman_Id.ToString() +
                        ",Family_ID=" + this._Family_Id.ToString() + ",Birthplace='" + this._BirthPlace + "',Photo=@Photo"
                        + ",Rating=" + this._Rating.ToString() + ",Salary=" + this._Salary.ToString()
                    + ",ApproximateSalary=" + this._ApproximateSalary.ToString() + ",Suporter_ID=NULL"
                        + " where Id=" + this._id.ToString();
                System.IO.MemoryStream mem = new System.IO.MemoryStream();
                this._Photo.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                Hashtable h = new Hashtable();
                h.Add("@Photo", mem.ToArray());
                return dbw.ExcuteCommand(sql, h);
            }
            else
            {
                Orphan[] bros = this.GetBrothers();
                if (bros != null)
                {
                    foreach (Orphan bro in bros)
                    {
                        if (bro.Name == this.Name)
                        {
                            this.Name += " (مكرر) ";
                            break;
                        }
                    }
                }
                string sql = "Insert Into Orphan(Id,Name,Birthday,Nationality,Sex,HealthyState,StudiesStage," +
                    "BondsMan_Relationship,Notes,Bondsman_Id,Family_ID,Birthplace,Photo) Values("
                    + this._id.ToString() + ",'" + this._name + "'," +
                    "'" + this.Birthday.ToString("yyyy/MM/dd") + "','" +
                    this._Nationality + "','" + this._Sex + "','" + this._HealthyState +
                    "','" + this._StudiesStage + "','" +
                    this._BondsMan_R + "','" + this._Notes + "'," + this._Bondsman_Id.ToString() +
                    "," + this._Family_Id.ToString() + ",'" + this._BirthPlace + "',@Photo"
                      +")";
                Hashtable h = new Hashtable();
                if (this.Photo != null)
                {
                    System.IO.MemoryStream mem = new System.IO.MemoryStream();
                    this._Photo.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                    h.Add("@Photo", mem.ToArray());
                }
                else
                    h.Add("@Photo", null);
                return dbw.ExcuteCommand(sql, h);
            }
        }
        public Father GetFather()
        {
            if (this._Family_Id > 0)
            {
                string sql = "select id from Father where id in (select F_id from Family where id="
            + this._Family_Id + ")";
                DataBaseWorker dbw = new DataBaseWorker();
                ArrayList ar = dbw.ExcuteResultCommand(sql);
                if (ar.Count == 1)
                {
                    Father O = new Father();
                    foreach (Hashtable h in ar)
                    {
                        int Oid = int.Parse(h["id"].ToString());
                        O = Father.GetFather(Oid);
                    }
                    return O;
                }
                else
                    return null;
            }
            else
                return null;
        }
        public Mother  GetMother()
        {
            if (this._Family_Id > 0)
            {
                string sql = "select id from Mother where id in (select M_id from Family where id="
                    + this._Family_Id + ")";
                DataBaseWorker dbw = new DataBaseWorker();
                ArrayList ar = dbw.ExcuteResultCommand(sql);
                if (ar.Count == 1)
                {
                    Mother O = new Mother();
                    foreach (Hashtable h in ar)
                    {
                        int Oid = int.Parse(h["id"].ToString());
                        O = Mother.GetMother(Oid);
                    }
                    return O;
                }
                else
                    return null;
            }
            else
                return null;
        }
        public Family GetFamily()
        {
            if (this._Family_Id > 0)
                return Family.GetFamily(this._Family_Id) ;
            else
                return null;
        }
        public Orphan[] GetBrothers()
        {
            if (this._Family_Id > 0)
            {
                string sql = "select id from Orphan where Family_ID in(select id from family where F_id="+this.GetFather().Id + ")";
               string  sql2 = "select id from Orphan where Family_ID in(select id from family where m_id=" + this.GetMother().Id + ")";

                DataBaseWorker dbw = new DataBaseWorker();
                ArrayList ar = dbw.ExcuteResultCommand(sql);                
                ArrayList AllBro = new ArrayList();
                if (ar.Count > 1)
                {
                    foreach (Hashtable h in ar)
                    {
                        if (int.Parse(h["id"].ToString()) != this._id)
                        {
                            AllBro.Add(int.Parse(h["id"].ToString()));
                        }
                    }
                }
                ar = dbw.ExcuteResultCommand(sql2);
                if (ar.Count > 1)
                {
                    foreach (Hashtable h in ar)
                    {
                        if (int.Parse(h["id"].ToString()) != this._id)
                        {
                            int pp = int.Parse(h["id"].ToString());
                            if (!AllBro.Contains(pp))
                            {
                                AllBro.Add(pp);
                            }
                        }
                    }
                }
                if (AllBro.Count > 0)
                {
                    Orphan[] o = new Orphan[AllBro.Count];
                    int i = 0;
                    foreach (int f in AllBro)
                    {
                        o[i] = GetOrphan(f);
                        i++;
                    }
                    AllBro.Clear();
                    ar.Clear();
                    GC.Collect();
                    return o;
                }
                else
                {
                    GC.Collect();
                    return null; 
                }
            }
            else
                return null;
        }
        public BondsMan GetBondsMan()
        {
            if (this._Bondsman_Id  > 0)
                return BondsMan.GetBondsMan(this._Bondsman_Id);
            else
                return null;
        }
        public Suporter GetSuporter()
        {
            if (this._Suporter_ID> 0)
                return Suporter.GetSuporter(this._Suporter_ID);
            else
                return null;
        }
        private int ExtructNumber(string xx)
        {
            int i = -1, j = 0, ist = 0;
            int ret = 0;
            bool found = false;
            foreach (char x in xx)
            {
                if (char.IsNumber(x))
                {
                    if (i == -1)
                    { i = j; ist = j; }
                    else
                        if (i != j - 1)
                        {                            
                            break;
                        }
                        else
                            i = j;
                    found = true;
                }
                j++;
            }
            if(found)
                if(xx.Length>1)
                    ret = int.Parse(xx.Substring(ist, i - ist));
                else
                    ret = int.Parse(xx.Substring(ist,1));
            
            return ret;
        }
        public bool Delete()
        {
            if (this._id == 0) return false;
            if (GetBrothers() != null)
            {
                string sql3 = "delete from Orphan where id =" + this.Id;
                DataBaseWorker dbw = new DataBaseWorker();
                Orphan[] bro = GetBrothers();
                if (bro == null)
                {
                    GetFamily().Delete();
                }
                return dbw.ExcuteCommand(sql3);
            }
            else
            {
                return this.GetFamily().Delete();
            }
        }
    }
}
