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

    public class BookUpdateView: ViewBase<Book>
    {
        public BookUpdateView(Book model) : base(model) { }
        public override void Render()
        {
            ViewHelp.WriteLine("UPDATE BOOK INFORMATION", ConsoleColor.Green);
            
            string author = ViewHelp.InputString("Authors: ", Model.Authors);
            string title = ViewHelp.InputString("Title: ", Model.Title);
            string pubisher = ViewHelp.InputString("Publisher: ", Model.Publisher);
            var lsbn = ViewHelp.InputString("Isbn: ", Model._lsbn);
            var tags = ViewHelp.InputString("Tags: ", Model._tags);
            var description = ViewHelp.InputString("Description: ", Model.Description);
            var file = ViewHelp.InputString("File: ", Model.File);
            var year = ViewHelp.InputInt("Year: ", Model.Year);
            var edition = ViewHelp.InputInt("Edition: ", Model.Edition);
            var rating = ViewHelp.InputInt("Int: ", Model.Rating);
            var reading = ViewHelp.InputBool("Reading: ", Model.Reading);
            var authors = ViewHelp.InputString("Author: ",Model.Authors);
            var publisher = ViewHelp.InputString("Publisher: ", Model.Publisher);
            var request =
               "do create ? " +
               $"title = {title}" +
               $" & author = {authors}" +
               $" & publisher = {publisher}" +
               $" & year = {year}" +
               $" & edition = {edition}" +
               $" & tags = {tags}" +
               $" & description = {description}" +
               $" & rate = {rating}" +
               $" & reading = {reading}" +
               $" & file = {file}";
            Router.Forward(request);
        }
        public void WriteLine(string mess, ConsoleColor color = ConsoleColor.Magenta, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mess);
            if (resetColor)
                Console.ResetColor();
        }
        public void Write(string mess, ConsoleColor color = ConsoleColor.Magenta, bool resetColor = true)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(mess);
            if (resetColor)
                Console.ResetColor();
        }
    }
}
