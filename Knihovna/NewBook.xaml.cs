using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NewBook.xaml
    /// </summary>
    public partial class NewBook : Window
    {
       
        private bool succes = false;
        Book book;
        public NewBook()
        {
            InitializeComponent();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Isbn.TryValidate(txtIsbn.Text))
            {
                loadImage("http://covers.openlibrary.org/b/isbn/" + txtIsbn.Text + "-M.jpg");
                lblError.Text = "";
            }
            else
            { lblError.Text = "ISBN není validní!"; }


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
                    };

                    imgBitmap.DownloadFailed += (o, e) =>
                    {
                        BitmapImage imgBit = new BitmapImage(new Uri(@"placehoder.jpg", UriKind.RelativeOrAbsolute));
                        imgBook.Source = imgBitmap;
                    };
                }
            }
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        public Book GetBook()
        {
            return book;
        }
        public bool GetSucces()
        {
            return succes;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (txtAuthor.Text.Length == 0 || txtName.Text.Length == 0 || txtIsbn.Text.Length == 0 || txtTotalBooks.Text.Length == 0)
            {
                MessageBox.Show("Nejsou vyplněné všechny povinné údaje", "Nová kniha", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
                succes = true;

            int numberOfBooks = int.Parse(txtTotalBooks.Text);

            book = new Book(0, txtName.Text, txtAuthor.Text, numberOfBooks, txtIsbn.Text, 0, txtPublisher.Text, txtPublished.Text, cbGenre.Text);
            this.Close();
        }

        private void txtTotalBooks_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
