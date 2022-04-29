using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Framework
{
    public static class ViewHelp
    {
        public static void WriteLine(string mess, ConsoleColor color = ConsoleColor.Magenta, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mess);
            if (resetColor)
                Console.ResetColor();
        }
        public static void Write(string mess, ConsoleColor color = ConsoleColor.Magenta, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(mess);
            if (resetColor)
                Console.ResetColor();
        }
        public static bool InputBool(string mess)
        {
            Write(mess);
            ConsoleKeyInfo k = Console.ReadKey();
            Console.WriteLine();
            return k.KeyChar == 'y' || k.KeyChar == 'Y' ? true : false;
        }
        public static string InputString(string mess)
        {
            Write(mess);
            string str = Console.ReadLine();
            return str;
        }
        public static int InputInt(string mess)
        {
            Write(mess);
            int i = int.Parse(Console.ReadLine());
            return i;
        }
        public static string InputString(string label, string oldVal, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valColor = ConsoleColor.White)
        {
            Write($"{label}: ", labelColor);
            Write(oldVal, ConsoleColor.Yellow);
            Write("New value >>", ConsoleColor.Green);
            string newVal = Console.ReadLine();

            return string.IsNullOrEmpty(newVal.Trim()) ? oldVal : newVal;
        }
        public static int InputInt(string label, int oldVal, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valColor = ConsoleColor.White)
        {
            Write($"{label}: ", labelColor);
            Write($"{oldVal}", ConsoleColor.Yellow);
            Write("New value >> ", ConsoleColor.Green);
            Console.ForegroundColor = valColor;
            var str = Console.ReadLine();
            if (str.ToInt(out int i)) return i;
            return oldVal;
        }
        public static bool InputBool(string label, bool oldVal, ConsoleColor labelColor = ConsoleColor.Magenta, ConsoleColor valColor = ConsoleColor.White)
        {
            Write($"{label}: ", labelColor);
            Write(oldVal.ToString("y/n"), ConsoleColor.Yellow);
            Write("New value >>",ConsoleColor.Green);
            Console.ForegroundColor = valColor;
            string newVal = Console.ReadLine();
            return string.IsNullOrEmpty(newVal) ? oldVal : newVal.ToBool();
        }
    }
}
