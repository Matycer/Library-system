using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Knihovna
{
    class BorrowService
    {
        
        BorrowDatabase borrowDatabase = new BorrowDatabase(MainWindow.connectionString);
        public ObservableCollection<BorrowedBook> BorrowDetail { get; protected set; }
        public ObservableCollection<BorrowedBook> BorrowedBooks { get; protected set; }

        public BorrowService()
        {
            BorrowDetail = new ObservableCollection<BorrowedBook>();
            BorrowedBooks = new ObservableCollection<BorrowedBook>();
        }



        public void GetBorrowDetail(string id)
        {

            string name;
            DateTime borrowed;
            DataTable dt = new DataTable();
            dt = borrowDatabase.GetBorrowDetail(id);

            foreach (DataRow dtRow in dt.Rows)
            {
                name = dtRow.Field<string>("userName");
                borrowed = dtRow.Field<DateTime>("borrowed");
                BorrowDetail.Add(new BorrowedBook(name, borrowed, getBookName(id)));
            }
        }

        public void GetBorrowedBooks(string bookId)
        {
            var dt = borrowDatabase.GetBorowedBooks(bookId.ToString());
            string name = "";
            int id = 0;
            foreach (DataRow dtRow in dt.Rows)
            {
                id = int.Parse(dtRow["id"].ToString());
                name = dtRow.Field<string>("name");
                DateTime date = DateTime.Parse(dtRow["borrowed"].ToString());


                BorrowedBooks.Add(new BorrowedBook("", date, name));
            }
        }

        private string getBookName(string id)
        {
            foreach (var book in Libray.LibraryBooks)
            {
                if (book.Id.ToString().Equals(id))
                    return book.Name;
            }
            return "";
        }



    }
}
