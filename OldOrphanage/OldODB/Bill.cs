using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Itenso.TimePeriod;
namespace OrphansRegistries
{
    public class Bill
    {
        private int _Id;
        private int _OrphanId;
        private string _OrphanName;
        private float _Money;
        private int _SupporterID;
        private string _SupporterName;
        private string _Duration;
        private DateTime _StartDate;
        private DateTime _EndDate;
        private DateTime _RegDate;
        private bool _IsCanceled;
        private bool _IsFinished;

        public Bill() 
        {
            _StartDate = new DateTime();
            _EndDate = new DateTime();
            _RegDate = DateTime.Now;
        }
        public Bill(int Orphanid,int supporterId , DateTime startDate,DateTime EndDate,float Money)
        {
            this._EndDate = EndDate;
            this.Money = Money;
            this.OrphanId = Orphanid;
            this._StartDate = startDate;
            this._SupporterID = supporterId;
        }
        
        public bool IsFinished
        {
            get { return _IsFinished; }
            set { _IsFinished = value; }
        }


        public bool IsCanceled
        {
            get { return _IsCanceled; }
            set { _IsCanceled = value; }
        }

        public  DateTime RegDate
        {
            get { return _RegDate; }
        }

        public DateTime EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }


        public DateTime StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }


        public string Duration
        {
            get { return _Duration; }
            set { _Duration = value; }
        }

        public string SupporterName
        {
            get { return _SupporterName; }
            set { _SupporterName = value; }
        }


        public int SupporterID
        {
            get { return _SupporterID; }
            set { _SupporterID = value; }
        }


        public float Money
        {
            get { return _Money; }
            set { _Money = value; }
        }


        public string OrphanName
        {
            get { return _OrphanName; }
            set { _OrphanName = value; }
        }


        public int OrphanId
        {
            get { return _OrphanId; }
            set { _OrphanId = value; }
        }


        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public static string GetDuration(DateTime from, DateTime To)
        {
            string ret = "";
            To = To.AddMonths(1);
            DateDiff diff = new DateDiff(from, To);
            if (diff.ElapsedYears > 0)
            {
                switch (diff.ElapsedYears)
                {
                    case 1:
                        {
                            ret = "سنة "; break;
                        }
                    case 2:
                        { ret = "سنتان "; break; }
                    default: { ret = diff.ElapsedYears + " سنوات "; break; }
                }
            }            
            if (diff.ElapsedMonths > 0)
            {
                if (ret.Length > 0) ret += "و ";
                switch (diff.ElapsedMonths)
                {
                    case 1:
                        {
                            ret += "شهر "; break;
                        }
                    case 2:
                        { ret += "شهران "; break; }
                    case 11:
                        { ret += "11 شهراً "; break; }
                    default: { ret += diff.ElapsedMonths + " أشهر "; break; }
                }
            }
            if (diff.ElapsedDays > 0)
            {
                if (ret.Length > 0) ret += "و ";
                switch (diff.ElapsedDays)
                {
                    case 1:
                        {
                            ret += "يوم "; break;
                        }
                    case 2:
                        { ret += "يومين "; break; }
                    case 3:
                        { ret += "3 أيام "; break; }
                    case 4:
                        { ret += "4 أيام "; break; }
                    case 5:
                        { ret += "5 أيام "; break; }
                    case 6:
                        { ret += "6 أيام "; break; }
                    case 7:
                        { ret += "7 أيام "; break; }
                    case 8:
                        { ret += "8 أيام "; break; }
                    case 9:
                        { ret += "9 أيام "; break; }
                    case 10:
                        { ret += "10 أيام "; break; }
                    default: { ret += diff.ElapsedDays + " يوماً "; break; }
                }
                
            }
            return ret;
        }
        public static bool Exist(int id)
        {
            try
            {
                DataBaseWorker dbw = new DataBaseWorker();
                string sql = "Select * from Bill where id =" + id;
                ArrayList ar = dbw.ExcuteResultCommand(sql);
                if (ar.Count == 1)
                    return true;
                else
                    return false;
            }
            catch {return false; }
        }
        public static Bill GetBill(int id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select * from Bill where id =" + id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
            {
                Bill M = new Bill();
                foreach (Hashtable h in ar)
                {
                    M._Id = id;
                    M._OrphanId = h["orphan_id"] is DBNull ? 0 : int.Parse(h["orphan_id"].ToString());
                    M._OrphanName = h["orphan_name"] != null ? (string)h["orphan_name"] : "";
                    M.Money = h["orphan_money"] is DBNull ? 0 : int.Parse(h["orphan_money"].ToString());
                    M.SupporterID = h["supporter_id"] is DBNull ? 0 : int.Parse(h["supporter_id"].ToString());
                    M.SupporterName = h["supporter_name"] != null ? (string)h["supporter_name"] : "";
                    M.Duration = h["duration"] != null ? (string)h["duration"] : "";
                    M._StartDate  = h["start_date"] is DBNull  ?new DateTime(1950,1,1) : DateTime.Parse(h["start_date"].ToString());
                    M._EndDate = h["end_date"] is DBNull ? new DateTime(1950, 1, 1) : DateTime.Parse(h["end_date"].ToString());
                    M._RegDate = h["reg_date"] is DBNull ? new DateTime(1950, 1, 1) : DateTime.Parse(h["reg_date"].ToString());
                    M._IsFinished = h["is_finished"] is DBNull ? false : (bool)h["is_finished"];
                    M._IsCanceled = h["is_canceled"] is DBNull ? false : (bool)h["is_canceled"];
                }
                return M;
            }
            else
                return null;

        }
        public static Bill[] GetBills()
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            sql = "Select * from Bill";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        ret[i] = Bill.GetBill(int.Parse(h["id"].ToString()));                        
                    }
                    else
                        ret[i] = null;
                    i++;
                }
                return ret;
            }
            else
                return null;
        }
        public static Orphan GetOrphan(int B_id)
        {
             DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select orphan_id from Bill where id =" + B_id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
            {
                Hashtable h = (Hashtable)ar[0];
                if (h["orphan_id"] is DBNull == false)
                {
                    return Orphan.GetOrphan(int.Parse(h["orphan_id"].ToString()));
                }
                else
                    return null;
            }
            else
                return null;
        }
        public static Suporter GetSupporter(int B_id)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "Select supporter_id from Bill where id =" + B_id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
            {
                Hashtable h = (Hashtable)ar[0];
                if (h["supporter_id"] is DBNull == false)
                {
                    return Suporter.GetSuporter(int.Parse(h["supporter_id"].ToString()));
                }
                else
                    return null;
            }
            else
                return null;
        }
        public static Bill[] GetBillsByDate(DateTime _date, bool is_start_date)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            if(is_start_date)
                sql= "Select * from Bill where start_date='" + _date.ToString("yyyy/MM/dd") + "'";
            else
                sql = "Select * from Bill where end_date='" + _date.ToString("yyyy/MM/dd") + "'";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i =0;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        ret[i] = Bill.GetBill(int.Parse(h["id"].ToString()));
                    }
                    else
                        ret[i] = null;
                    i++;
                }
                return ret;
            }
            else
                return null;
        }
        public static Bill[] GetBillsBetweenStartEndDates(DateTime start, DateTime end, bool is_start_date)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            if(is_start_date)
                sql= "Select * from Bill where start_date between '" + start.ToString("yyyy/MM/dd") + "' and '"
                    + end.ToString("yyyy/MM/dd") + "'";
            else
                sql = "Select * from Bill where end_date between '" + start.ToString("yyyy/MM/dd") + "' and '"
                    + end.ToString("yyyy/MM/dd") + "'";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i =0;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        ret[i] = Bill.GetBill(int.Parse(h["id"].ToString()));
                    }
                    else
                        ret[i] = null;
                    i++;
                }
                return ret;
            }
            else
                return null;
        }
        public static Bill[] getBillsBySupporter(Suporter sup)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            sql = "Select * from Bill where supporter_id="+sup.Id ;                    
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        ret[i] = Bill.GetBill(int.Parse(h["id"].ToString()));
                    }
                    else
                        ret[i] = null;
                    i++;
                }
                return ret;
            }
            else
                return null;
        }
        public static Bill[] getBillsByOrphan(Orphan orph)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            sql = "Select * from Bill where orphan_id=" + orph.Id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        ret[i] = Bill.GetBill(int.Parse(h["id"].ToString()));
                    }
                    else
                        ret[i] = null;
                    i++;
                }
                return ret;
            }
            else
                return null;
        }
        public static Bill[] getCanceledBills()
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            sql = "Select * from Bill where is_canceled=1";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        ret[i] = Bill.GetBill(int.Parse(h["id"].ToString()));
                    }
                    else
                        ret[i] = null;
                    i++;
                }
                return ret;
            }
            else
                return null;
        }
        public static Bill[] getFinishedBills()
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            sql = "Select * from Bill where is_finished=1";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        ret[i] = Bill.GetBill(int.Parse(h["id"].ToString()));
                    }
                    else
                        ret[i] = null;
                    i++;
                }
                return ret;
            }
            else
                return null;
        }
        public static Bill[] getUnCanceledBills()
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            sql = "Select * from Bill where is_canceled=0";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        ret[i] = Bill.GetBill(int.Parse(h["id"].ToString()));
                    }
                    else
                        ret[i] = null;
                    i++;
                }
                return ret;
            }
            else
                return null; 
        }
        public static Bill[] getUnFinishedBills()
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            sql = "Select * from Bill where is_finished=0";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        ret[i] = Bill.GetBill(int.Parse(h["id"].ToString()));
                    }
                    else
                        ret[i] = null;
                    i++;
                }
                return ret;
            }
            else
                return null;
        }
        public static Bill[] getBillsByRegisteration(DateTime reg)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            sql = "Select * from Bill where reg_date='" + reg.ToString("yyyy/MM/dd") + "'";
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i = 0;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        ret[i] = Bill.GetBill(int.Parse(h["id"].ToString()));
                    }
                    else
                        ret[i] = null;
                    i++;
                }
                return ret;
            }
            else
                return null;
        }
        public static Bill getSpecificBill(Orphan o, Suporter sup)
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            sql = "Select * from Bill where orphan_id=" + o.Id + " and supporter_id=" + sup.Id;
            ArrayList ar = dbw.ExcuteResultCommand(sql);
            if (ar.Count == 1)
            {
                Hashtable h = (Hashtable)ar[0];
                if (h["id"] is DBNull == false)
                {
                    return Bill.GetBill(int.Parse(h["id"].ToString()));
                }
                else
                    return null;
            }
            else if (ar.Count > 1)
            {
                bool foundVailed = false;
                Bill bil = null;
                foreach (Hashtable h in ar)
                {
                    if (h["id"] is DBNull == false)
                    {
                        bil = Bill.GetBill(int.Parse(h["id"].ToString()));
                        if (bil.IsCanceled == false && bil.IsFinished == false)
                        {
                            if (foundVailed == false)
                                foundVailed = true;
                            else
                            {
                                Bill.checkBills(true);
                                return null;
                            }
                        }
                    }
                }
                return bil;
            }
            else
                return null;
        }
        public static Bill[] getOrphanValiedBills(Bill bill)
        {
            if (bill.IsFinished || bill.IsCanceled) return null;
            Bill[] ret;
            DataBaseWorker DBW = new DataBaseWorker();
            string sql = "select id from bill where orphan_id="+bill.OrphanId;
            ArrayList ar = DBW.ExcuteResultCommand(sql);
            ArrayList re = new ArrayList();
            if (ar.Count > 0)
            {//bill:end:1/5/2011
             //b"start:1/4/2011
             //
                foreach (Hashtable h in ar)
                {
                    Bill b = Bill.GetBill(int.Parse(h["id"].ToString()));
                    //Itenso.TimePeriod.DateDiff diff = new DateDiff(b.StartDate, bill.EndDate);
                    if (!b.IsCanceled && !b.IsFinished && (b.StartDate!=bill.StartDate && b.EndDate != bill.EndDate) )
                    {
                        if (b.StartDate >= bill.StartDate && b.StartDate <= bill.EndDate)
                            re.Add(b);
                        if (b.StartDate < bill.StartDate && b.EndDate >= bill.StartDate)
                           re.Add(b);
                    }
                }
                ret = new Bill[re.Count];
                int i = 0;
                foreach (Bill bi in re)
                { ret[i] = bi; i++; }
                return ret;
            }
            else
                return null;
        }
        public static Bill[] checkBills(bool FixErrors)
        {
            Bill[] bills = GetBills();
            ArrayList ar = new ArrayList();
            if (bills != null)
            {
                foreach (Bill bill in bills)
                {
                    if (bill != null)
                    {
                        DateDiff diff;
                        diff = new DateDiff(DateTime.Now,bill.EndDate);
                        if (diff.ElapsedMonths <= 0 && bill.IsFinished == false 
                            && bill.IsCanceled == false)
                        {
                            bill._IsFinished = true;
                            if (FixErrors) bill.Save();
                            ar.Add(bill);
                        }
                        if (!Orphan.Exist(bill.OrphanId))
                        {
                            if (FixErrors)
                                bill.Delete();
                            ar.Add(bill);
                        }   
                        Bill[] com = getOrphanValiedBills (bill);
                        if(com != null && com.Length>0)
                        {
                            foreach (Bill w in com)
                            {
                                if (!ar.Contains(w))
                                {
                                    ar.Add(w);
                                    if (FixErrors)
                                        w.Delete();
                                }
                            }
                        }
                    }
                }
            }
            else
                return null;
            if (ar.Count > 0)
            {
                Bill[] ret = new Bill[ar.Count];
                int i = 0;
                foreach (Bill b in ar)
                {
                    ret[i] = b;
                    i++;
                }
                return ret;
            }
            else
                return null;

        }
        public bool Save()
        {
            DataBaseWorker dbw = new DataBaseWorker();
            string sql;
            if (_OrphanId == 0 || _SupporterID == 0 || _StartDate == null ||
               _StartDate.Year < 2000 || EndDate == null || _EndDate.Year < 2000) return false;
            if (_OrphanName == null || _OrphanName == "")
                _OrphanName = Orphan.GetOrphan(_OrphanId).Name;
            if (_SupporterName == null || _SupporterName == "")
                _SupporterName = Suporter.GetSuporter(_SupporterID).Name;
            _Duration = GetDuration(_StartDate,_EndDate);
            if (!Exist(_Id))
            {
                _IsCanceled = false;
                _IsFinished = false;
                sql = "insert into Bill(orphan_id,orphan_name,orphan_money,supporter_id,supporter_name,duration,start_date,end_date," +
                    "reg_date,is_canceled,is_finished) values(" + _OrphanId + ",'" + _OrphanName + "'," +
                    _Money + "," + _SupporterID + ",'" + _SupporterName + "','" + _Duration + "','" +
                    _StartDate.ToString("yyyy/MM/dd") + "','" + _EndDate.ToString("yyyy/MM/dd") + "','" +
                    DateTime.Now.ToString("yyyy/MM/dd") + "',0,0)";
            }
            else
            {
                sql = "update bill set orphan_id="+_OrphanId + ",orphan_name='"+_OrphanName+
                    "',orphan_money="+_Money + ",supporter_id="+_SupporterID +",supporter_name='"+
                    _SupporterName+"',duration='"+_Duration+"',start_date='"+_StartDate.ToString("yyyy/MM/dd")+
                        "',end_date='"+_EndDate.ToString("yyyy/MM/dd")+"',is_canceled="+ToOffice.GetboolValue(_IsCanceled )+
                        ",is_finished="+ToOffice.GetboolValue(_IsFinished) + " where id="+_Id;
            }
            return dbw.ExcuteCommand(sql);
        }
        public bool Delete()
        {
            if (_Id == 0) return false;
            if (!Exist(_Id)) return false;
            DataBaseWorker dbw = new DataBaseWorker();
            string sql = "delete from bill where id=" + _Id;
            if (!this.IsCanceled || this.IsFinished)
            {
                if (Bill.GetSupporter(_Id) != null && Bill.GetOrphan(_Id) != null )
                {
                    if (Bill.GetSupporter(_Id).DisSuport(Bill.GetOrphan(_Id)))
                    {
                        return dbw.ExcuteCommand(sql);
                    }
                    else
                        return false;
                }
                else
                    return dbw.ExcuteCommand(sql);
            }
            else
                return dbw.ExcuteCommand(sql);
        }
    }
}
