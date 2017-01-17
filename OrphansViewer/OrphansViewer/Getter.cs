using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AddressForm;
namespace OrphansViewer
{
    class Getter
    {
        public static string GetAddress(AddressForm.AddressForm nam)
        {
            string ret = "";
            char sep = '-';
            if (nam == null) return null;
            if (nam.Country != null && nam.Country.Length > 0)
                ret = nam.Country;
            if (nam.City != null && nam.City.Length > 0)
                if (ret.Length > 0)
                    ret = ret + sep + nam.City;
                else
                    ret = nam.City;
            if (nam.Town != null && nam.Town.Length > 0)
                if (ret.Length > 0)
                    ret = ret + sep + nam.Town;
                else
                    ret = nam.Town;
            if (nam.Street != null && nam.Street.Length > 0)
                if (ret.Length > 0)
                    ret = ret + sep + nam.Street;
                else
                    ret = nam.Street;
            return ret;
        }
        public static string GetFullName(NameForm.NameForm nam)
        {
            if (nam.Middle == null || nam.Middle.Length == 0)
                return nam.First + " " + nam.Last;
            else
                return nam.First + " " + nam.Middle + " " + nam.Last;
        }
    }
}
