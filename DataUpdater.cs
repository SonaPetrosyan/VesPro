using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

public static class TableUpdater
{
    public static void UpdateTableFromJson(string connectionString, string jsonFilePath)
    {
        //      try
        //      {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            // Read JSON file
            string jsonContent = File.ReadAllText(jsonFilePath);
            JObject json = JObject.Parse(jsonContent);

            // Process each item in the 'items' array
            JArray items = (JArray)json["items"];
            foreach (var item in items)
            {
                string code = item["Code"].ToString().Trim();
                string name = item["Name"].ToString();

                // Check if the code already exists in the table
                bool codeExists = CheckIfCodeExists(connection, "table_215_copy", code);

                if (codeExists)
                {
                    // Update the name if the code exists
                    UpdateName(connection, "table_215_copy", code, name);
                    Console.WriteLine($"Updated: Code = {code}, Name = {name}");
                }
                else
                {
                    // Insert a new record if the code doesn't exist
                    InsertRecord(connection, "table_215_copy", code, name);
                    Console.WriteLine($"Inserted: Code = {code}, Name = {name}");
                }
            }
            //          }
            //      }
            //      catch (Exception ex)
            //      {
            //          Console.WriteLine($"Error: {ex.Message}");
            //      }
        }
    }
    private static bool CheckIfCodeExists(MySqlConnection connection, string tableName, string code)
    {
        string query = $"SELECT COUNT(*) FROM {tableName} WHERE Code = @Code";
        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Code", code);
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
    }

    private static void UpdateName(MySqlConnection connection, string tableName, string code, string name)
    {
        string query = $"UPDATE {tableName} SET Name = @Name WHERE Code = @Code";
        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Code", code);
            command.ExecuteNonQuery();
        }
    }

    private static void InsertRecord(MySqlConnection connection, string tableName, string code, string name)
    {
        string query = $"INSERT INTO {tableName} (Code, Name) VALUES (@Code, @Name)";
        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Code", code);
            command.Parameters.AddWithValue("@Name", name);
            command.ExecuteNonQuery();
        }
    }
}