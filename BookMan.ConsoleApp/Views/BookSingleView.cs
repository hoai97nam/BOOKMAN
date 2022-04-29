using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Models;
    using Framework;
    using static BookMan.ConsoleApp.Framework.ViewBase;

    internal class BookSingleView :ViewBase<Book>
    {
        public BookSingleView(Book model) : base(model) { }
        public override void Render()
        {
            if (Model == null)
            {
                WriteLine("NO BOOK HAS FOUND, LEAVE", ConsoleColor.Red);
                return;
            }
            WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);

            Console.WriteLine($"Authors: {Model.Authors}");
            Console.WriteLine($"Title:   {Model.Title}");
            Console.WriteLine($"Publisher: {Model.Publisher}");
            Console.WriteLine($"Year: {Model.Year}");
            Console.WriteLine($"Edition: {Model.Edition}");
            Console.WriteLine($"Isbn: {Model._lsbn}");
            Console.WriteLine($"Tags: { Model._tags} ");
            Console.WriteLine($"Description: {Model.Description}");
            Console.WriteLine($"Rating: {Model.Rating}");
            Console.WriteLine($"Reading: {Model.Reading}");
            Console.WriteLine($"File: {Model.File}");
            Console.WriteLine($"File Name: {Model.FileName}");

            Console.ReadKey();
        }
        protected void WriteLine(string mess, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mess);
            Console.ResetColor();
        }        
    }
}
