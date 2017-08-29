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
    /// Interaction logic for BorrowBook.xaml
    /// </summary>
    public partial class BorrowBook : Window
    {
        BorrowDatabase database = new BorrowDatabase(MainWindow.connectionString);
        private Book book;
        private UserController user;
        private bool success = true;
        public BorrowBook(Book selBook,UserController us)
        {
            InitializeComponent();
            book = selBook;
            user = us;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtAuthor.Text = book.Author;
            txtBook.Text = book.Name;
            cbUsers.ItemsSource = user.users;
        }

        private void bntVypujcit_Click(object sender, RoutedEventArgs e)
        {
            if (book.Available == 0)
            {
                MessageBox.Show("Kniha není dostupná", "Nedostatek knih", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (cbUsers.SelectedValue == null)
                MessageBox.Show("Není vybrán uživatel", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                database.BorrowBook(book.Id.ToString(),cbUsers.SelectedValue.ToString(),DateTime.Now);
                database.UpdateBorrowCount(book.Id.ToString(),book.Borrowed+1);
                book.Available--;
                book.Borrowed++;
                MessageBox.Show("Kniha byla půjčena", "Vypůjčena", MessageBoxButton.OK, MessageBoxImage.Information);
                success = true;
                this.Close();
            }
        }

        public bool Successful()
        {
            return success;
        }

    }
}
