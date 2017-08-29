using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Knihovna
{
    class LibraryLogic : Libray
    {
        public LibraryLogic()
        { }


        public void FindBooks(object bookName)
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

        public void GetBooks()
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

           
        }
    }
}
