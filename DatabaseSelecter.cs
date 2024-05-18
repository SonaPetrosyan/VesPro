using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class DatabaseSelecter
    {
        private string connectionString;

        public DatabaseSelecter(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string Field1Value { get; private set; }
        public string Field2Value { get; private set; }
        public string Field3Value { get; private set; }
        public string Field4Value { get; private set; }
        public string Return_value { get; private set; }

        //updater.UpdateRecord(tableName, searchField, searchValue, field_return, field_update, newValue);
        public void SelectRecord(string Query, string field1_return, string field2_return, string field3_return, string field4_return, string value_return)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = Query;
                    //string selectQuery = "SELECT MAX(ticket) AS max_ticket FROM seans0 WHERE 1"; //Query;
                    using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))

                    {
                        // selectCommand.Parameters.AddWithValue("@searchValue", searchValue);

                        using (MySqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Record found
                                if (field1_return.Length > 0) Field1Value = reader[field1_return].ToString();
                                if (field2_return.Length > 0) Field2Value = reader[field2_return].ToString();
                                if (field3_return.Length > 0) Field3Value = reader[field3_return].ToString();
                                if (field4_return.Length > 0) Field4Value = reader[field4_return].ToString();
                                if (value_return.Length > 0)
                                {
                                    Return_value = value_return.ToString();
                                    // Access the max_ticket value
                                    object maxTicketValue = reader["max_ticket"];

                                    // Check for DBNull and then convert to the appropriate data type
                                    if (maxTicketValue != DBNull.Value)
                                    {
                                        int maxTicket = Convert.ToInt32(maxTicketValue);
                                    }
                                }
                                reader.Close();
                            }
                            else
                            {
                                // Record not found
                                Console.WriteLine("Record not found.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}



