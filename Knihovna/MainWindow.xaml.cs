using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Knihovna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public static string connectionString =
            "Data Source=DESKTOP-M901IKU;Initial Catalog=Library;Integrated Security=True";
        Libray library = new Libray();
        UserController userCont;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            userCont = new UserController();

            lw.ItemsSource = library.books;
            library.LoadBooks();

            lwUsers.ItemsSource = userCont.users;
            userCont.LoadUsers();

            //User u = new User();
            //lw.Items.Clear();

            //k.Add(new est(@"C:\Users\metey\Desktop\ter3.png", "blah b sfd s", "5", "Matyáš Černohous", "15452255", "Nova kniha"));

            //lw.ItemsSource = k;
            //lw.ItemsSource = library.Books();
            //library.LoadBooks();
        }



        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
                return;
            
            FrameworkElement element = (FrameworkElement)e.OriginalSource;

            Book book = (Book)element.DataContext;
            BookDetail detailWindow = new BookDetail(book);
            detailWindow.ShowDialog();


        }



        private void lw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                library.filteredBooks.Clear();
                lw.ItemsSource = library.filteredBooks;
                library.FindBook(txtSeatch.Text);
            }
            catch { MessageBox.Show("Error"); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NewBook newBook = new NewBook();
            newBook.ShowDialog();
            if (newBook.GetSucces())
            {
                Book book = newBook.GetBook();
                if (library.AddBook(book))
                {
                    MessageBox.Show("Kniha přidána úspěšně!", "Přidání knihy", MessageBoxButton.OK, MessageBoxImage.Information);
                    book.Id = library.RecentlyAddedBook() + 1;
                    library.books.Add(book);
                }
            }

        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)e.OriginalSource;

            User user = (User)element.DataContext;

            Borrow borrowDetail = new Borrow("", 0, user);
            borrowDetail.ShowDialog();
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
            if (addUser.Succes())
            {
                userCont.LoadUsers();
            }
        }

        private void TextBlock_KeyDown(object sender, KeyEventArgs e)
        {
    
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)e.OriginalSource;

            Book book = (Book)element.DataContext;
            BorrowBook br = new BorrowBook(book, userCont);
            br.ShowDialog();
            if(br.Successful())
                userCont.LoadUsers();
        }

    }
}
