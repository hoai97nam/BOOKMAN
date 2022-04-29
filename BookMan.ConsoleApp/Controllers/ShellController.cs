using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Controllers
{
    using Models;
    using DataServices;
    using Views;
    using Framework;
    using System.IO;
    using System.Diagnostics;

    internal class ShellController:ControlBase
    {
        protected Repository Repository;
        public ShellController(IDataAccess context)
        {
            Repository = new Repository(context);
        }
        public void Shell(string folder, string ext = "*.pdf")
        {
            if (!Directory.Exists(folder))
            {
                Error("Folder not found");
                return;
            }
            var files = Directory.GetFiles(folder, ext ?? "*.pdf", SearchOption.AllDirectories);
            foreach(var f in files)
            {
                Repository.Insert(new Book { Title = Path.GetFileNameWithoutExtension(f), File = f });
            }
            if (files.Length > 0)
            {
                Success($"{files.Length} item(s) found!");
                return;
            }
            Information("No item  found!", "Sorry!");
        }
        public void Read(int id)
        {
            var book = Repository.Select(id);
            if (book == null)
            {
                Error("Book not found!");
                return;
            }
            if (!File.Exists(book.File))
            {
                Error("Book not found!");
                return;
            }
            Process.Start(book.File);
            Success($"You are reading book {book.Title}");
        }
        public void Clear(bool process = false)
        {
            if (!process)
            {
                Confirmation("Do you really want to clear the shell? ", "do clear");
                return;
            }
            Repository.Clear();
            Information("The shell has been cleared");
        }
        public void Save()
        {
            Repository.SaveChanges();
            Success("Data saved");
        }
    }
}
