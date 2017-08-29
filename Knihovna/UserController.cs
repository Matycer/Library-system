using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Knihovna
{
    public class UserController
    {

        private static object _lock = new object();
        public ObservableCollection<User> users { get; protected set; }
        public ObservableCollection<User> filteredUsers { get; protected set; }
        UserDatabase database = new UserDatabase(MainWindow.connectionString);

        public UserController()
        {
            users = new ObservableCollection<User>();
            filteredUsers = new ObservableCollection<User>();
            BindingOperations.EnableCollectionSynchronization(users, _lock);
            BindingOperations.EnableCollectionSynchronization(filteredUsers, _lock);
        }

        public void LoadUsers()
        {
            users.Clear();
            Thread thread = new Thread(GetUsers);
            thread.Start();
        }

        private void GetUsers()
        {
            int id;
            string firstName;
            string lastName;
            DateTime dateOfBirth;

            DataTable dt = new DataTable();

            dt = database.GetUsers();
            DataView dv = dt.DefaultView;
            dv.Sort = "lastName asc";
            DataTable sortedDT = dv.ToTable();

            foreach (DataRow dtRow in sortedDT.Rows)
            {
                id = int.Parse(dtRow["Id"].ToString());
                firstName = dtRow.Field<string>("firstName");
                lastName = dtRow.Field<string>("lastName");
                dateOfBirth = DateTime.Parse(dtRow["dateOfBirdth"].ToString());

                users.Add(new User(id, firstName, lastName, dateOfBirth, GetBorrowedBooks(id)));
            }
        }

        private List<int> GetBorrowedBooks(int id)
        {
            DataTable dt = new DataTable();
            dt = database.GetUserBorowedBook(id.ToString());

            List<int> books = dt.AsEnumerable().Select(x => int.Parse(x[0].ToString())).ToList();

            return books;
        }
    }
}
