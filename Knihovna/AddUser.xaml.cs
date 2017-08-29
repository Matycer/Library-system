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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        private bool ok = false;
        UserDatabase database = new UserDatabase(MainWindow.connectionString);
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != "" && txtSurname.Text != "" )
            {
                database.AddUser(txtName.Text, txtSurname.Text, dateBi);
                ok = true;
                this.Close();
            }
            else
                MessageBox.Show("Nejsou vyplněné žádné údaje", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public bool Succes()
        {
            return ok;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
