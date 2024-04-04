using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public class SQLDatabaseHelper
    {
        private readonly string _connectionString;

        public SQLDatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }
    }


}