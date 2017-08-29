using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Knihovna
{
    class Libray
    {

        private static object _lock = new object();
        protected Database database = new Database(MainWindow.connectionString);
        public ObservableCollection<Book> books { get; protected set; }
        public ObservableCollection<Book> filteredBooks { get; protected set; }

        public static ObservableCollection<Book> LibraryBooks;


        public Libray()
        {

            books = new ObservableCollection<Book>();
            filteredBooks = new ObservableCollection<Book>();
            BindingOperations.EnableCollectionSynchronization(books, _lock);
            BindingOperations.EnableCollectionSynchronization(filteredBooks, _lock);
        }


        public void LoadBooks()
        {
            LibraryLogic l = new LibraryLogic();

            Thread thread = new Thread(GetBooks);
            thread.Start();
        }

        public bool AddBook(Book book)
        {
            return database.AddBook(book);
        }

        public int RecentlyAddedBook()
        {
            return int.Parse(database.GetAddedBook());
        }

        /// <summary>
        /// Return books thats contains text in name
        /// </summary>
        /// <param name="name">Name of book</param>
        public void FindBook(string name)
        {
            try
            {
                int half = books.Count / 2;
                int secondHalf = books.Count - half;
                Thread thread = new Thread(FindBooks);
                thread.Start(name + ";0;" + half);
                Debug.WriteLine("Vklakno start");

                Thread thread1 = new Thread(FindBooks);
                thread1.Start(name + ";" + half + ";" + books.Count);
                Debug.WriteLine("Vklakno start");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Privátní metoda která se spuští ve vlákně a dává knihy které odpovídaji hledání do kolekce
        /// </summary>
        ///// <param name="bookName"></param>
        private void FindBooks(object bookName)
        {
            var split = bookName.ToString().Split(';');
            string name = split[0];
            int i = int.Parse(split[1].ToString());
            int to = int.Parse(split[2].ToString());

            for (int a = i; a < to; a++)
            {
                if (books[a].Name.ToLower().Contains(name.ToLower()))
                    filteredBooks.Add(books[a]);
            }
        }

        private void GetBooks()
        {
            int id;
            string name;
            string author;
            int numberOfBooks;
            string isbn;
            int borrowed;
            string publisher;
            string published;
            string genre;
            DataTable dt = new DataTable();
            dt = database.GetData();

            foreach (DataRow dtRow in dt.Rows)
            {
                id = int.Parse(dtRow["id"].ToString());
                name = dtRow.Field<string>("name");
                author = dtRow.Field<string>("author");
                numberOfBooks = int.Parse(dtRow["total"].ToString());
                isbn = dtRow.Field<string>("ibsn");
                borrowed = int.Parse(dtRow["borrowed"].ToString());
                publisher = dtRow.Field<string>("publisher");
                published = dtRow.Field<string>("published");
                genre = dtRow.Field<string>("genre");
                books.Add(new Book(id, name, author, numberOfBooks, isbn, borrowed, publisher, published, genre));
            }
            LibraryBooks = books;
        }

        public void SaveBooks()
        {

        }

    }
}
