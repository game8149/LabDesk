using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Code
{
    class FormatString
    {

        public static string FormatName(string[] strings)
        {           
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Concat(strings));
        }


        public static string FormatAddress(string Address, string Ubigeo, string Sector)
        {
            string[] textArray1 = new string[] { Address, " (", Ubigeo, ",", Sector, ")" };
            return string.Concat(textArray1);
        }
    }
}
