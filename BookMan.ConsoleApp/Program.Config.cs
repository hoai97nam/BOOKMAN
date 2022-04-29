namespace BookMan.ConsoleApp
{
    using Models;
    using Framework;
    using DataServices;
    using Controllers;

    internal partial class Program
    {
        private static void ConfigRouter()
        {
            IDataAccess context = new BinaryDataAccess();
            BookController controller = new BookController(context);
            ShellController shell = new ShellController(context);
            Router r = Router.Instance;

            r.Register("about", About);
            r.Register("help", Help);
            r.Register(route: "create",
                action: p => controller.Create(),
                help: "[create]\r enter new book");
            r.Register(route: "do create",
                action: p => controller.Create(toBook(p)),
                help: "this route should be used in code only");
            r.Register(route: "list",
                action: p => controller.List(),
                help: "[list]\r hien thi tat ca danh sach");
            r.Register(route: "list file",
                action: p => controller.List(p["path"]),
                help: "[list file ? path = <value>] \r hien thi tat ca danh sach");
            r.Register(route: "single",
                action: p => controller.Single(p["id"].ToInt()),
                help: "[single ? id=<value>]\r hien thi  cuon sach theo id");
            r.Register(route: "single file",
                action: p => controller.Single(p["id"].ToInt(), p["path"]),
                help: "[single file ? id = <value> & path = <value>]\r");
            r.Register(route: "update",
                action: p => controller.Update(p["id"].ToInt()),
                help: "[update ? id = <value>]\t tim va cap nhat sach");
            r.Register(route: "do update",
                action: p => controller.Update(p["id"].ToInt(), toBook(p)),
                help: "this route should be used in code only");
            r.Register(route: "delete",
                action: p => controller.Delete(p["id"].ToInt()),
                help: "[delete ? id = <value>]");
            r.Register(route: "do delete",
                action: p => controller.Delete(p["id"].ToInt(), true),
                help: "this route should be used in code only");
            r.Register(route: "filter",
                action: p => controller.Filter(p["key"]),
                help: "[filter ? key = <value>] \r tim danh sach theo tu khoa");
            r.Register(route: "add shell",
                action: p => shell.Shell(p["path"], p["ext"]),
                help: "[add shell ? path = <value>]");
            r.Register(route: "read",
                 action: p => shell.Read(p["id"].ToInt()),
                 help: "[read ? id = <value>]");
            r.Register(route: "mark",
                action: p => controller.Mark(p["id"].ToInt()),
                help: "[mark ? id = <value>]");
            r.Register(route: "unmark",
                action: p => controller.Mark(p["id"].ToInt(), false),
                help: "[unmark ? id = <value>]");
            r.Register(route: "show marks",
                action: p => controller.ShowMarks(),
                help: "[show marks]");
            r.Register(route: "clear",
                action: p => shell.Clear(),
                help: "[clear]\r\nUse with care");
            r.Register(route: "do clear",
                action: p => shell.Clear(true),
                help: "[clear]\r\nUse with care");
            r.Register(route: "save shell",
                action: p => shell.Save(),
                help: "[save shell]");
            r.Register(route: "show stats",
                action: p => controller.Stats(),
                help: "[show stats]");


            #region helper
            Models.Book toBook(Parameter p)
            {
                var b = new Models.Book();
                if (p.ContainKey("id")) b.Id = p["id"].ToInt();
                if (p.ContainKey("author")) b.Authors = p["author"];
                if (p.ContainKey("tittle")) b.Title = p["tittle"];
                if (p.ContainKey("publisher")) b.Publisher = p["publisher"];
                if (p.ContainKey("year")) b.Year = p["year"].ToInt();
                if (p.ContainKey("edition")) b.Edition = p["edition"].ToInt();
                if (p.ContainKey("isbn")) b._lsbn = p["isbn"];
                if (p.ContainKey("tags")) b._tags = p["tags"];
                if (p.ContainKey("description")) b.Description = p["id"];
                if (p.ContainKey("file")) b.File = p["file"];
                if (p.ContainKey("rate")) b.Rating = p["rate"].ToInt();
                if (p.ContainKey("reading")) b.Reading = p["reading"].ToBool();
                return b;
            }
            #endregion


        }
        
    }
}