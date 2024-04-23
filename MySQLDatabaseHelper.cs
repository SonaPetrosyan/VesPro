using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp4
{
    public class MySQLDatabaseHelper
    {
        private string connectionString;
        private MySqlConnection connection;
        public MySQLDatabaseHelper(string server, string database, string username, string password)
        {
            // Replace "YourConnectionString" with the actual connection string for your MySQL database
            connectionString = $"Server='{server}';Database='{database}';User Id='{username}';Password='{password}';CharSet = utf8mb4;";
            connection = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log or display an error message
                Console.WriteLine($"Error opening database connection: {ex.Message}");
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log or display an error message
                Console.WriteLine($"Error closing database connection: {ex.Message}");
                return false;
            }
        }

        // Additional methods for executing SQL commands can be added here

        // Example method for executing a SQL query
        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (OpenConnection())
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, e.g., log or display an error message
               Console.WriteLine($"Error executing query: {ex.Message}");
            }

            finally
            {
                CloseConnection();
            }
            return dataTable;
        }
        public MySqlConnection GetConnection()
        {
            return connection;
        }
    }
}
