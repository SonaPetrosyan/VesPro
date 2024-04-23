using System;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public static class FindMaxID
    {
        public static int MaxId(string connectionString,string SqlTable)
        {
            string query = $"SELECT MAX(Id) FROM {SqlTable}";
            int maxId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        maxId = Convert.ToInt32(result);
                    }
                    else
                    {
                        // Handle case where there are no rows in the table
                        maxId = 0; // Default value
                    }
                }
            }

            return maxId;
        }
    }
}

