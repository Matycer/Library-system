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
  public  class BorrowDatabase
    {
        private string ConnectionString;

        public BorrowDatabase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public DataTable GetBorrowDetail(string bookId)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "SELECT CONCAT(u.firstName, ' ', u.lastName) AS userName , b.borrowed FROM Borrowed b INNER JOIN Users u on u.Id = b.userId WHERE b.bookId = '" + bookId + "'";
            SqlCommand cmd = new SqlCommand(query, conn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public DataTable GetUserBorowedBook(string userId)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "SELECT bookId from Borrowed WHERE userId = '" + userId + "'";
            SqlCommand cmd = new SqlCommand(query, conn);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }


        public DataTable GetBorowedBooks(string bookId)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string query = "SELECT Books.Id,Books.name,Borrowed.borrowed FROM Books INNER JOIN Borrowed ON Books.Id = Borrowed.bookId WHERE Books.Id = '" + bookId + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            return dt;
        }

        public void BorrowBook(string bookId, string userId, DateTime date)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Borrowed (userId,bookId,borrowed) VALUES (@userId,@bookId,@date)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@bookId", bookId);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@date", date);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Chyba při vkládání knihy do databáze. knihu se nepovedlo pujčit\n\r" + ex.Message,
                    "public bool Pridej_ukol");
            }
        }

        public void UpdateBorrowCount(string Id, int count)
        {
            
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Books SET borrowed = @borrowed WHERE Id = @bookId");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@bookId", Id);
                    cmd.Parameters.AddWithValue("@borrowed", count);
            

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Chyba při vkládání knihy do databáze. knihu se nepovedlo pujčit\n\r" + ex.Message,
                    "public bool Pridej_ukol");
            }
        }



    }
}


