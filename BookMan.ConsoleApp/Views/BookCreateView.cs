using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Framework;
    public class BookCreateView:ViewBase
    {
        public BookCreateView()
        {
        }
        public override void Render()
        {
            WriteLine("CREATE A NEW BOOK", ConsoleColor.Green);

            string title = ViewHelp.InputString("Title: ");
            string authors = ViewHelp.InputString("Authors: ");
            string publisher = ViewHelp.InputString("Publisher: ");
            int year = ViewHelp.InputInt("Year: ");
            int edition = ViewHelp.InputInt("Edition: ");
            bool reading = ViewHelp.InputBool("Reading [y/n]");
            var tag = ViewHelp.InputString("Tags: ");
            var description = ViewHelp.InputString("Description: ");
            var rate = ViewHelp.InputInt("Rate: ");
            var file = ViewHelp.InputString("File: ");

            var request =
                "do create ? " +
                $"title = {title}" +
                $" & author = {authors}" +
                $" & publisher = {publisher}" +
                $" & year = {year}" +
                $" & edition = {edition}" +
                $" & tags = {tag}" +
                $" & description = {description}" +
                $" & rate = {rate}" +
                $" & reading = {reading}" + 
                $" & file = {file}";
            Router.Forward(request);
        }
        public void WriteLine(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            if (resetColor)
                Console.ResetColor();
        }
        public void Write(string message, ConsoleColor color = ConsoleColor.White, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            if (resetColor)
                Console.ResetColor();
        }
        public bool InputBool(string mess)
        {
            Write(mess);
            ConsoleKeyInfo k = Console.ReadKey();
            Console.WriteLine();
            return k.KeyChar == 'y' || k.KeyChar == 'Y' ? true : false;
        }
        public string InputString(string mess)
        {
            Write(mess);
            string str = Console.ReadLine();
            return str;
        }
        public int InputInt(string mess)
        {
            Write(mess);
            int i = int.Parse(Console.ReadLine());
            return i;
        }
    }
}
