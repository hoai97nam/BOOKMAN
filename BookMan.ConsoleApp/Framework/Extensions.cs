using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Framework
{
    public static class Extensions
    {
        public static int ToInt(this string str)
        {
            return int.Parse(str);
        }
        public static bool ToInt(this string str, out int i)
        {
            return int.TryParse(str, out i);
        }
        public static bool ToBool(this string str)
        {
            var v = str.ToLower();
            return (v == "y" || v == "true") ? true : false;
        }
        public static string ToString(this bool val, string fo)
        {
            return fo == "y/n" ? (val?"Yes":"No"): (fo=="True/False"?(val?"True":"No"):"");            
        }
    }
}
