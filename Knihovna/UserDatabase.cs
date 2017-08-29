using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Knihovna
{
    public class UserDatabase : BorrowDatabase
    {
        private string ConnectionString;

        public UserDatabase(string connectionString)
            : base(connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DataTable GetUsers()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(query, conn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public bool AddUser(string firstName, string lastName, DatePicker date)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Users (firstName,lastName,dateOfBirdth) VALUES (@first,@second,@date)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@first", firstName);
                    cmd.Parameters.AddWithValue("@second", lastName);
                    cmd.Parameters.AddWithValue("@date", date.DisplayDate);


                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Chyba při vkládání záznamu do databáze. Uživatele se nepovedlo přidat\n\r" + ex.Message,
                    "public bool Pridej_ukol");
                return false;
            }

        }
    }
}
