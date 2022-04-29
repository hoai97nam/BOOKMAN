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

    public class BookListView:ViewBase<Book[]>
    {
        protected Book[] Model;
        public BookListView(Book[] model) : base(model) { }
        public override void Render()
        {
            if(Model.Length == 0)
            {
                ViewHelp.WriteLine("No book found!", ConsoleColor.Yellow);
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            ViewHelp.WriteLine("THE BOOK LIST", ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach(Book a in Model)
            {
                ViewHelp.Write($"{a.Id}", ConsoleColor.Yellow);
                ViewHelp.WriteLine($"{a.Title}", a.Reading ? ConsoleColor.Cyan : ConsoleColor.White);
            }
            ViewHelp.WriteLine($"{Model.Length} item(s)", ConsoleColor.Green);
        }              
    }
}
