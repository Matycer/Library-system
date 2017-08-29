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
    /// Interaction logic for BookDetail.xaml
    /// </summary>
    partial class BookDetail : Window
    {
        Book book;
        public BookDetail(Book book)
        {
            InitializeComponent();
            this.book = book;
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            BitmapImage imgBitmap = new BitmapImage(new Uri(@"placehoder.jpg", UriKind.RelativeOrAbsolute));
            imgBookPlaceholder.Source = imgBitmap;
           
            loadImage(book.Url);
            txtGenre.Text = book.Genre;
            txtName.Text = book.Name;
            txtAuthor.Text = book.Author;
            txtPublisher.Text = book.Publisher;
            txtPublished.Text = book.Published;
            txtBorrowedBooks.Text = book.Borrowed.ToString();
            txtAvailableBooks.Text = book.Available.ToString();
            txtTotalBooks.Text = book.NumberOfBooks.ToString();
        }

        private void loadImage(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                string largeImg = url.Replace("-M", "-L");
                var imgBitmap = new BitmapImage(new Uri(largeImg));
                imgBook.Source = imgBitmap;
               
                if (imgBitmap.IsDownloading)
                {
                   
                    imgBitmap.DownloadCompleted += (o, e) =>
                    {
                        gridLoad.Visibility = Visibility.Collapsed;
                        imgBook.Visibility = Visibility.Visible;
                        imgBookPlaceholder.Visibility = Visibility.Collapsed;
                    };

                    imgBitmap.DownloadFailed += (o, e) =>
                    {
                        // stop download animation here
                    };
                }
            }
        }
        
        private void imgBook_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBlock_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Borrow borrowDetail = new Borrow(book.Name,book.Id,null);
            borrowDetail.ShowDialog();
        }
    }
}
