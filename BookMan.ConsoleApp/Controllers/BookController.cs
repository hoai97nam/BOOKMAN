using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Controllers
{
    using Models;
    using Views;
    using DataServices;
    using Framework;
    public class BookController: ControlBase
    {
        protected Repository repository;
        public BookController(IDataAccess context)
        {
            repository = new Repository(context);
            
        }
        public void Single(int id, string path="")
        {
            var model = repository.Select(id);
            Render(new BookSingleView(model), path);
        }
        public void Create(Book book =null)
        {
            if (book == null)
            {
                Render(new BookCreateView());
                return;
            }
            repository.Insert(book);
            Success("book create");
            
        }
        public void Update(int id,Book book = null)
        {
            if(book == null)
            {
                var model = repository.Select(id);
                var view = new BookUpdateView(model);
                Render(view);
                return;
            }
            repository.Update(id, book);
            Success("Book updated!");
        }
        public void List(string path="")
        {
            var model = repository.Select();
            Render(new BookListView(model), path);
        }
        public void Delete(int id, bool process = false)
        {
            if (process == false)
            {
                var b = repository.Select(id);
                Confirmation($"Do you want to delete this book {b.Title} ?", $"do delete?id={b.Id}");
            }
            else
            {
                repository.Delete(id);
                Success("Book delete!");
            }
        }
        public void Filter(string key)
        {
            var model = repository.Select(key);
            if (model.Length == 0)
                Information("No matches book found");
            else
                Render(new BookListView(model));
        }
        public void Mark(int id, bool read = true)
        {
            var book = repository.Select(id);
            if (book == null)
            {
                Error("Book not found!");
                return;
            }
            book.Reading = read;
            Success($"The book '{book.Title}' are marked as { (read ? "READ" : "UNREAD")}");
        }

        public void ShowMarks()
        {
            var model = repository.SelectMarked();
            var view = new BookListView(model);
            Render(view);
        }
        public void Stats()
        {
            var model = repository.Stats();
            var view = new BookStatsView(model);
            Render(view);
        }
    }
}
