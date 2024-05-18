using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp4
{
    public class DatabaseUpdater
    {
        private string connectionString;

        public DatabaseUpdater(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string FieldValue { get; private set; }
        //updater.UpdateRecord(tableName, searchField, searchValue, field_return, field_update, newValue);
        public void UpdateRecord(string tableName, string searchField, string searchValue, string field_return, string field_update, string newValue)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string selectQuery = $"SELECT * FROM {tableName} WHERE {searchField} = @searchValue";
                    using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@searchValue", searchValue);

                        using (MySqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Record found
                                if (field_return.Length > 0) FieldValue = reader[field_return].ToString();
                                reader.Close();

                                // Replace field2 with the new value
                                string updateQuery = $"UPDATE {tableName} SET {field_update} = @newValue WHERE {searchField} = @searchValue";
                                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@newValue", newValue);
                                    updateCommand.Parameters.AddWithValue("@searchValue", searchValue);
                                    updateCommand.ExecuteNonQuery();
                                }

                                Console.WriteLine($"{field_return} value: {FieldValue}");
                                Console.WriteLine($"{field_update} updated with new value: {newValue}");
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