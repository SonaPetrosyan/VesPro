using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

public static class TableUpdater
{
    public static void UpdateTableFromJson(string connectionString, string jsonFilePath, string Parameter)
    {
        //       try
        //       {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string parameter = Parameter;//File.ReadAllText(Parameter);
            // Read JSON file
            string jsonContent = File.ReadAllText(jsonFilePath);
            JObject json = JObject.Parse(jsonContent);

            // Process each item in the 'items' array
            JArray items = (JArray)json["items"];
            if (parameter == "215")
            {
                string query = $"TRUNCATE TABLE table_215";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                    foreach (var item in items)
                {
                    string code = item["Code"].ToString().Trim();
                    string name1 = item["Name_1"].ToString();
                    string name2 = item["Name_2"].ToString();
                    string name3 = item["Name_3"].ToString();
                    string unit = item["Unit"].ToString();
                    int group = Convert.ToInt32(item["Group"].ToString().Trim());
                    bool semiprepared = bool.Parse(item["SemiPrepared"].ToString());
                    int printer = Convert.ToInt32(item["Printer"].ToString().Trim());
                    float price = Convert.ToSingle(item["Price"].ToString().Trim());
                    float price1 = Convert.ToSingle(item["Price1"].ToString().Trim());
                    float price2 = Convert.ToSingle(item["Price2"].ToString().Trim());
                    float price3 = Convert.ToSingle(item["Price3"].ToString().Trim());
                    float price4 = Convert.ToSingle(item["Price4"].ToString().Trim());
                    float price5 = Convert.ToSingle(item["Price5"].ToString().Trim());
                    int department = Convert.ToInt32(item["Department"].ToString().Trim());
                    string inholl = item["InHoll"].ToString();
                    InsertRecord215(connection, "table_215", code, name1, name2, name3, unit, group, semiprepared, printer, price, price1, price2, price3, price4, price5, department, inholl);
                }
 
                //**********************************************
                string jsonFilePath1 = "d:\\hayrik\\programmer\\json\\json_calc.json";
                string jsonContent1 = File.ReadAllText(jsonFilePath1);
                JObject json1 = JObject.Parse(jsonContent1);

                // Process each item in the 'items' array
                JArray items1 = (JArray)json1["items"];

                string query0 = $"TRUNCATE TABLE composition";
                using (MySqlCommand command = new MySqlCommand(query0, connection))
                    foreach (var item in items1)
                {
                    string code_215 = item["Code_215"].ToString().Trim();
                    string code_211 = item["Code_211"].ToString().Trim();
                    string name1 = item["Name_1"].ToString();
                    string note = item["Note"].ToString();
                    string unit = item["Unit"].ToString();
                    float coefficient = Convert.ToSingle(item["Coefficient"].ToString().Trim());
                    float quantity = Convert.ToSingle(item["Quantity"].ToString().Trim());
                    float bruto = Convert.ToSingle(item["Bruto"].ToString().Trim());
                    float neto = Convert.ToSingle(item["Neto"].ToString().Trim());
                    InsertRecordCalcul(connection, "composition", code_215, code_211, name1, note, unit, coefficient, quantity, bruto, neto);

                }

            }
            //***********************************
            if (parameter == "group")
            {
                string query = $"TRUNCATE TABLE food_groupp";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                foreach (var item in items)
                {
                    string name1 = item["Name_1"].ToString();
                    string name2 = item["Name_2"].ToString();
                    string name3 = item["Name_3"].ToString();
                    int group = Convert.ToInt32(item["Group"].ToString().Trim());
                    InsertRecordgroup(connection, "food_groupp", name1, name2, name3, group);
                }
            }

            if (parameter == "211")
            {
                string query = $"TRUNCATE TABLE table_211";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                foreach (var item in items)
                {
                    string code = item["Code"].ToString().Trim();
                    string name1 = item["Name_1"].ToString();
                    string name2 = item["Name_2"].ToString();
                    string name3 = item["Name_3"].ToString();
                    string unit = item["Unit"].ToString();
                    int group = Convert.ToInt32(item["Group"].ToString().Trim());
                    float price = Convert.ToSingle(item["Price"].ToString().Trim());
                    InsertRecord(connection, "table_211", code, name1, name2, name3, unit, price, group);
                 }
            }
            //***********************************
            if (parameter == "213")
            {
                string query = $"TRUNCATE TABLE table_213";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                foreach (var item in items)
                {
                    string code = item["Code"].ToString().Trim();
                    string name1 = item["Name_1"].ToString();
                    string name2 = item["Name_2"].ToString();
                    string name3 = item["Name_3"].ToString();
                    string unit = item["Unit"].ToString();
                    int group = Convert.ToInt32(item["Group"].ToString().Trim());
                    float price = Convert.ToSingle(item["Price"].ToString().Trim());
                    InsertRecord(connection, "table_213", code, name1, name2, name3, unit, price, group);
                }
            }

            //***********************************
            if (parameter == "111")
            {
                string query = $"TRUNCATE TABLE table_111";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                    foreach (var item in items)
                {
                    string code = item["Code"].ToString().Trim();
                    string name1 = item["Name_1"].ToString();
                    string name2 = item["Name_2"].ToString();
                    string name3 = item["Name_3"].ToString();
                    string unit = item["Unit"].ToString();
                    int group = Convert.ToInt32(item["Group"].ToString().Trim());
                    float price = Convert.ToSingle(item["Price"].ToString().Trim());
                    InsertRecord(connection, "table_111", code, name1, name2, name3, unit, price, group);
                }
            }
            //***********************************
            if (parameter == "addition")
            {
                string query = $"TRUNCATE TABLE AdditionGroups";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                    foreach (var item in items)
                    {
                        int number = int.Parse(item["Number"].ToString().Trim());
                        string name1 = item["Name_1"].ToString();
                        string name2 = item["Name_2"].ToString();
                        string name3 = item["Name_3"].ToString();

                        // Insert a new record if the code doesn't exist
                        InsertRecordaddgr(connection, "AdditionGroups", number, name1, name2, name3);
                    }

                string jsonFilePath1 = "d:\\hayrik\\programmer\\json\\addition_names.json";
                string jsonContent1 = File.ReadAllText(jsonFilePath1);
                JObject json1 = JObject.Parse(jsonContent1);

                // Process each item in the 'items' array
                JArray items1 = (JArray)json1["items"];
                string query1 = $"TRUNCATE TABLE AdditionNames";
                using (MySqlCommand command = new MySqlCommand(query1, connection))
                    foreach (var item in items1)
                    {
                        int number = int.Parse(item["Number"].ToString().Trim());
                        string name1 = item["Name_1"].ToString();
                        string name2 = item["Name_2"].ToString();
                        string name3 = item["Name_3"].ToString();

                        // Insert a new record if the code doesn't exist
                        InsertRecordaddgr(connection, "AdditionNames", number, name1, name2, name3);
                    }

            }

        }

    }


 




    private static void InsertRecordCalcul(MySqlConnection connection, string tableName, string code_215,
    string code_211, string name1, string note, string unit, float coefficient, float quantity, float bruto, float neto)
    {
         string query = $"INSERT INTO {tableName} (Code_215,Code_211, Name_1, Note, Unit, Coefficient, Quantity, Bruto,Neto) " +
                       $"VALUES (@Code_215, @Code_211, @Name1, @Note, @Unit, @Coefficient, @Quantity, @Bruto, @Neto)";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Code_215", code_215);
            command.Parameters.AddWithValue("@Code_211", code_211);
            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Note", note);
            command.Parameters.AddWithValue("@Coefficient", coefficient);
            command.Parameters.AddWithValue("@Unit", unit);
            command.Parameters.AddWithValue("@Quantity", quantity);
            command.Parameters.AddWithValue("@Bruto", bruto);
            command.Parameters.AddWithValue("@Neto", neto);
            command.ExecuteNonQuery();
        }
    }
    private static void InsertRecord215(MySqlConnection connection, string tableName, string code, string name1,
        string name2, string name3, string unit, int group,bool semiprepared, int printer, float price, float price1,
        float price2, float price3, float price4, float price5, int department, string inholl)
    {
        string query = $"INSERT INTO {tableName} (Code, Name_1, Name_2, Name_3, Unit, Group,SemiPrepared," +
            $" Printer, Price, Price1, Price2, Price3, Price4, Price5, Department, InHoll) VALUES (@Code, @Name1," +
            $" @Name2, @Name3, @Unit, @Group, @Printer, @Price, @Price1, @Price2, @Price3, @Price4, @Price5, @Department, @InHoll)";
        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Code", code);
            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Name2", name2);
            command.Parameters.AddWithValue("@Name3", name3);
            command.Parameters.AddWithValue("@Unit", unit);
            command.Parameters.AddWithValue("@Group", group);
            command.Parameters.AddWithValue("@SemiPrepared", semiprepared);
            command.Parameters.AddWithValue("@Printer", printer);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@Price1", price1);
            command.Parameters.AddWithValue("@Price2", price2);
            command.Parameters.AddWithValue("@Price3", price3);
            command.Parameters.AddWithValue("@Price4", price4);
            command.Parameters.AddWithValue("@Price5", price5);
            command.Parameters.AddWithValue("@Department", department);
            command.Parameters.AddWithValue("@InHoll", inholl);
            command.ExecuteNonQuery();
        }
    }

    private static void InsertRecord(MySqlConnection connection, string tableName, string code, string name1, string name2, string name3, string unit, float price, int group)
    {
        string query = $"INSERT INTO {tableName} (Code, Name_1, Name_2, Name_3, Unit, CostPrice, Group) " +
                       $"VALUES (@Code, @Name1, @Name2, @Name3, @Unit, @Price,@Group)";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Code", code);
            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Name2", name2);
            command.Parameters.AddWithValue("@Name3", name3);
            command.Parameters.AddWithValue("@Unit", unit);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@Group", group);
            command.ExecuteNonQuery();
        }
    }
    private static void InsertRecordgroup(MySqlConnection connection, string tableName,  string name1, string name2, string name3, int group)
    {
        string query = $"INSERT INTO {tableName} (Name_1, Name_2, Name_3, Group) " +
                       $"VALUES ( @Name1, @Name2, @Name3,@Group)";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Name2", name2);
            command.Parameters.AddWithValue("@Name3", name3);
            command.Parameters.AddWithValue("@Group", group);
            command.ExecuteNonQuery();
        }
    }
    private static void InsertRecordaddgr(MySqlConnection connection, string tableName, int number, string name1, string name2, string name3)
    {
        string query = $"INSERT INTO {tableName} (Number,Name_1, Name_2, Name_3) " +
                       $"VALUES (@Number, @Name1, @Name2, @Name3)";

        using (MySqlCommand command = new MySqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Name2", name2);
            command.Parameters.AddWithValue("@Name3", name3);
            command.Parameters.AddWithValue("@Number", number);
            command.ExecuteNonQuery();
        }
    }
}