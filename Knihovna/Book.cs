using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Knihovna
{

    public class Book : INotifyPropertyChanged
    {


        private int id;
        private string name;
        private string author;
        private int numberOfBooks;
        private int available;
        private string isbn;
        private string publisher;
        private string published;
        private string genre;
        private string url;
        private int borrowed;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged(); } }
        public string Author { get { return author; } set { author = value; } }
        public int NumberOfBooks { get { return numberOfBooks; } set { numberOfBooks = value; } }
        public int Available { get { return available; } set { available = value; NotifyPropertyChanged(); } }
        public string Isbn { get { return isbn; } set { isbn = value; } }
        public string Publisher { get { return publisher; } set { publisher = value; } }
        public string Published { get { return published; } set { published = value; } }
        public string Genre { get { return genre; } set { genre = value; } }

        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                NotifyPropertyChanged();
            }
        }
        public int Borrowed
        {
            get { return borrowed; }
            set
            {
                borrowed = value;
                NotifyPropertyChanged();

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        
        public Book(int id, string name, string author, int numberOfBooks, string isbn, int borrowed, string publisher, string published, string genre)
        {
            Id = id;
            Name = name;
            Author = author;
            NumberOfBooks = numberOfBooks;
            Isbn = isbn;
            Borrowed = borrowed;
            Publisher = publisher;
            Published = published;
            Genre = genre;
           // BitmapImage imgBitmap = new BitmapImage(new Uri(@"placehoder.jpg", UriKind.RelativeOrAbsolute));
            Url = "http://covers.openlibrary.org/b/isbn/" + Isbn + "-M.jpg";
          //  Url = @"placehoder.jpg";
            AvailableBooks();
           // CheckNameLength();
        }

        private void AvailableBooks()
        {
            Available = NumberOfBooks - Borrowed;
        }

        private void CheckNameLength()
        {
            if (Name.Length > 30)
            {
                Name = Name.Substring(0, 27);
                Name += "...";
            }
        }

    }
}
