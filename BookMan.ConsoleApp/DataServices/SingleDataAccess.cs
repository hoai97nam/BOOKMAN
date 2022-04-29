using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.DataServices
{
    using Models;
    /// <summary>
    /// is a list, contains books
    /// </summary>
    public class SingleDataAccess
    {
        public List<Book> Books { get; set; }
        public void Load()
        {
            Books = new List<Book>
            {
                new Book{Id=1,Title="A new book title 1" },
                new Book{Id=2,Title="A new book title 2" },
                new Book{Id=3,Title="A new book title 3" },
                new Book{Id=4,Title="A new book title 4" },
                new Book{Id=5,Title="A new book title 5" },
                new Book{Id=6,Title="A new book title 6" },
                new Book{Id=7,Title="A new book title 7" },
                new Book{Id=8,Title="A new book title 8" },
                new Book{Id=9,Title="A new book title 9" },
            };
        }
        public void SaveChanges() { }
    }
}
