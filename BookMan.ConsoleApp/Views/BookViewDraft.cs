using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Views
{
    using Models;
    class BookViewDraft
    {
        protected BookDraft Book;
        enum daysOfWeek : byte
        {
            Mon = 0,
            Tue = 1,
            Wed,
            Thu,
            Fri,
            Sat,
            Sun
        }
        public BookViewDraft(BookDraft book)
        {
            Book = book;
        }
        public void Render()
        {
            if (Book != null)
            {
                Console.WriteLine($"ID - {Book.Id}");
                Console.WriteLine($"Author - {Book.Author}");
                Console.WriteLine($"Name - {Book.Name}");
                Console.WriteLine($"Rating - {Book.Rating}");
                Console.WriteLine($"File - {Book.File}");
                Console.WriteLine($"Filename - {Book.Filename}");
            }
        }
    }
}
