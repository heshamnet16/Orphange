using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ATDFormater
{
    public class ArabicDateFormater
    {
        public static string getFullArabicTime(int Hours,int Minutes,int Seconds)
        {
            string ret = "";
            if (Hours > 0)
            {
                ret += GetArabicHour(Hours);
            }
            if (Minutes > 0)
            {
                if (ret.Length > 0)
                {
                    ret += " و ";
                }
                ret += GetArabicMinute(Minutes);
            }
            if (Seconds > 0)
            {
                if (ret.Length > 0)
                {
                    ret += " و ";
                }
                ret += GetArabicSecond(Seconds);
            }
            return ret;
        }
        public static string getFullArabicDate(int Year,int Month,int Days)
        {
            string ret = "";
            if (Year > 0 ) 
            {                 
                ret += GetArabicYear(Year  );
            }
            if (Month > 0)
            {
                if (ret.Length > 0)
                {
                    ret += " و ";
                }
                ret += GetArabicMonth(Month);
            }
            if (Days > 0)
            {
                if (ret.Length > 0)
                {
                    ret += " و ";
                }
                 ret += GetArabicDay(Days);
            }
            return ret;
        }

        public static string GetArabicHour(int _IntD)
        {
            switch (_IntD)
            {
                case 0:
                    {
                        return "أقل من ساعة";
                    }
                case 1:
                    {
                        return "ساعة";
                    }
                case 2:
                    {
                        return "ساعتين";
                    }
            }
            if ((_IntD >= 3) && (_IntD <= 10))
            {
                return _IntD + " ساعات";
            }
            else
                return _IntD + " ساعة";
        }
        public static string GetArabicMinute(int _IntD)
        {
            switch (_IntD)
            {
                case 0:
                    {
                        return "أقل من دقيقة";
                    }
                case 1:
                    {
                        return "دقيقة";
                    }
                case 2:
                    {
                        return "دقيتان";
                    }
            }
            if ((_IntD >= 3) && (_IntD <= 10))
            {
                return _IntD + " دقائق";
            }
            else
                return _IntD + " دقيقة";
        }
        public static string GetArabicSecond(int _IntD)
        {
            switch (_IntD)
            {
                case 0:
                    {
                        return "أقل من ثانية";
                    }
                case 1:
                    {
                        return "ثانية";
                    }
                case 2:
                    {
                        return "ثانيتين";
                    }
            }
            if ((_IntD >= 3) && (_IntD <= 10))
            {
                return _IntD + " ثوان";
            }
            else
                return _IntD + " ثانية";
        }

        public static string GetArabicYear(int _IntD)
        {
            switch  (_IntD) 
            {
                case 0:
                    {
                        return "أقل من سنة";
                    }
                case 1:
                    {
                        return "سنة";
                    }
                case 2:
                    {
                        return "سنتان";
                    }
            }
            if ((_IntD >= 3) && (_IntD <= 10))
            {
                return _IntD + " سنوات";
            }
            else
                return _IntD + " سنة";
        }
        public static string GetArabicMonth(int _IntD)
        {
            switch (_IntD)
            {
                case 0:
                    {
                        return "أقل من شهر";
                    }
                case 1:
                    {
                        return "شهر";
                    }
                case 2:
                    {
                        return "شهران";
                    }
            }
            if ((_IntD >= 3) && (_IntD <= 10))
            {
                return _IntD + " أشهر";
            }
            else
                return _IntD + " شهراً";
        }
        public static string GetArabicDay(int _IntD)
        {
            switch (_IntD)
            {
                case 0:
                    {
                        return "أقل من يوم";
                    }
                case 1:
                    {
                        return "يوم";
                    }
                case 2:
                    {
                        return "يومان";
                    }
            }
            if ((_IntD >= 3) && (_IntD <= 10))
            {
                return _IntD + " أيام";
            }
            else
                return _IntD + " يوماً";
        }

    }
}
