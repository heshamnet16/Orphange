using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATDFormater
{
    public class ArabicBooleanFormatter
    {
        public static string BooleanToArabic(bool val)
        {
            if (val)
                return "نعم";
            else
                return "لا";
        }
        public static bool ArabicToBoolean(string val)
        {
            if (val.Trim().IndexOf("نعم") >-1)
                return true;
            else
                return false;
        }
    }
}
