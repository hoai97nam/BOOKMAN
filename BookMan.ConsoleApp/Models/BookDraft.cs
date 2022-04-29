using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Models
{
    class BookDraft
    {
        private int _id = 1;
        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 1) _id = value;
            }
        }
        private string _name = "unkown";
        public string Name { get; set; }

        private string _author = "dell biet";
        public string Author
        {
            get => _author;
            set { if (string.IsNullOrEmpty(value)) _author = value; }
        }

        private int _rating = 1;
        public int Rating
        {
            get => _rating;
            set
            {
                if (value >= 1 && value <= 5)
                {
                    _rating = value;
                }
            }
        }
        private string _file;
        public string File
        {
            get => _file;
            set
            {
                if (System.IO.File.Exists(value))
                {
                    _file = value;
                }
            }
        }
        public string Filename
        {
            get => System.IO.Path.GetFileName(_file);
        }

    }
}
