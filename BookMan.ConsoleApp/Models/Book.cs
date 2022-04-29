using System;

namespace BookMan.ConsoleApp.Models
{
    [Serializable]
    public class Book
    {
        private int _id = 1;
        public int Id
        {
            get => _id;
            set { if (value > 1) _id = value; }
        }
        private string _authors = "Unknown Author";
        public string Authors
        {
            get => _authors;
            set { if (!string.IsNullOrEmpty(value)) _authors = value; }
        }
        private string _title = "A new book";
        public string Title
        {
            get => _title;
            set { if (!string.IsNullOrEmpty(value)) _title = value; }
        }
        private string _publisher = "Unknow Publisher";
        public string Publisher
        {
            get => _publisher;
            set { if (!string.IsNullOrEmpty(value)) _publisher = value; }
        }
        private int _year = 2018;
        public int Year
        {
            get => _year;
            set { if (value > 1950) _year = value; }
        }
        private int _edition { get; set; } = 1; //default value = 1
        public int Edition
        {
            get => _edition;
            set { if (value >= 1) _edition = value; }
        }
        public string _lsbn { get; set; } = "";
        public string _tags { get; set; } = "";
        public string Description { get; set; } = "A new book";
        private string _file;
        public string File
        {
            get { return _file; }
            set { if (System.IO.File.Exists(value)) _file = value; }
        }
        public string FileName
        {
            get => System.IO.Path.GetFileName(_file);
        }
        public bool Reading { get; set; }
        private int _rating = 1;
        public int Rating
        {
            get => _rating;
            set { if (value >= 1 && value <= 5) _rating = value; }
        }
    }
}
