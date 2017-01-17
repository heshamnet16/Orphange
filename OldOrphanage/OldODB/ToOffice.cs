using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using System.Collections;
using System.Windows.Forms;

namespace OrphansRegistries
{
    public class ToOffice
    {

        public static char GetboolValue(bool par)
        {
            if (par) return '1';
            else
                return '0';
        }

        public static  bool TxtToBool(string txt)
        {
            if (txt.Contains("نعم"))
                return true;
            else
                return false;
        }
        public static string BoolToTxt(bool bol)
        {
            if (bol)
                return "نعم";
            else
                return "لا";
        }
        public static int txtToInt(string txt)
        {
            string xx="";
            foreach (char c in txt)
                if (Char.IsNumber(c))
                {
                    xx += c;
                }
                else
                    break;
            return int.Parse(xx);
        }

   
        public static int ConvertToFloor(int num,byte digets)
        {
            int dev;
            string strDiv = "1";
            while (digets > 0)
            {
                strDiv += "0";
                digets--;
            }
            dev = int.Parse(strDiv);
            if (dev > 0)
                return (int)Math.Floor((decimal)num / (decimal)dev) * 100;
            else
                return 0;
        }
    }
}
