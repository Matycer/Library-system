using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Knihovna
{
    /// <summary>
    /// Interaction logic for Borrow.xaml
    /// </summary>
    public partial class Borrow : Window
    {
        BorrowService service = new BorrowService();
        string bookName;
        int id;
        User user;
        List<BookName> bookNames = new List<BookName>(); 

        public Borrow(string book, int id, User u)
        {
            InitializeComponent();
            this.bookName = book;
            this.id = id;
            if (u != null)
                user = u;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                txtBook.Text = bookName;
                dgvBorrowed.ItemsSource = service.BorrowDetail;
                service.GetBorrowDetail(id.ToString());
            }
            else
            {
                txtBook.Text = user.FirstName + " " + user.LastName;
                foreach (int id in user.BorrowedBooks)
                {
                    service.GetBorrowedBooks(id.ToString());
                }

                foreach (BorrowedBook b in service.BorrowedBooks)
                {
                    bookNames.Add(new BookName(b.BookName,b.Remaining,b.From.ToShortDateString()));
                }
                dgvBorrowed.ItemsSource = bookNames;
            }
        }

        private void dgvBorrowed_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                DataGridTextColumn dataGridTextColumn = e.Column as DataGridTextColumn;
                if (dataGridTextColumn != null)
                    dataGridTextColumn.Binding.StringFormat = "dd.MM.yyyy";
            }
        }

        private void dgvBorrowed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class BookName
    {
        public string Jmeno { get; set; }
        public string Zbyva { get; set; }
        public string Vypujceno { get; set; }

        public BookName(string name, string borr, string from)
        {
            Jmeno = name;
            Vypujceno = from;
            Zbyva = borr;
           

        }
    }
}
