using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Knihovna
{
    class Database
    {
        protected string ConnectionString;

        public Database(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DataTable GetData()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "SELECT * FROM Books";
            SqlCommand cmd = new SqlCommand(query, conn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public DataTable FilterData(string name)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "SELECT * FROM Books WHERE name like '%" + name + "%'";
            SqlCommand cmd = new SqlCommand(query, conn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public string GetAddedBook()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Books ORDER BY Id DESC", conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return reader["Id"].ToString();
                }
            }
            conn.Close();
            return "";

        }

        public bool AddBook(Book book)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Books (name,author,total,ibsn,borrowed,publisher,published,genre) VALUES (@name,@author,@total,@isbn,@borrowed,@publisher,@published,@genre)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@name", book.Name);
                    cmd.Parameters.AddWithValue("@author", book.Author);
                    cmd.Parameters.AddWithValue("@total", book.NumberOfBooks);
                    cmd.Parameters.AddWithValue("@isbn", book.Isbn);
                    cmd.Parameters.AddWithValue("@borrowed", 0);
                    cmd.Parameters.AddWithValue("@publisher", book.Publisher);
                    cmd.Parameters.AddWithValue("@published", book.Published);
                    cmd.Parameters.AddWithValue("@genre", book.Genre);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Chyba při vkládání záznamu do databáze. Úkol se nepovedlo přidat\n\r" + ex.Message, "public bool Pridej_ukol");
                return false;
            }
        }






    }
}
