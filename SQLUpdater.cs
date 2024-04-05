﻿using System;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json.Linq;

public static class SQLUpdater
{
    public static void SQLFromJson(string connectionString, string jsonFilePath, string Parameter,int Reestaurant)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            int _restaurant = Reestaurant;
            string parameter = Parameter;
            string jsonContent = File.ReadAllText(jsonFilePath);

            JObject json = JObject.Parse(jsonContent);
            JArray items = (JArray)json["items"];
            if (parameter == "215")
            {
                string query = $"TRUNCATE TABLE Inventory_215";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                string query1 = $"TRUNCATE TABLE Table_215";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.ExecuteNonQuery();
                }

                foreach (var item in items)
                {
                    string code = item["Code"].ToString().Trim();
                    string name1 = item["Name_1"].ToString();
                    string name2 = item["Name_2"].ToString();
                    string name3 = item["Name_3"].ToString();
                    string unit = item["Unit"].ToString();
                    bool semiprepared = bool.Parse(item["SemiPrepared"].ToString());
                    int printer = Convert.ToInt32(item["Printer"].ToString().Trim());
                    float price = Convert.ToSingle(item["Price"].ToString().Trim());
                    float price1 = Convert.ToSingle(item["Price1"].ToString().Trim());
                    float price2 = Convert.ToSingle(item["Price2"].ToString().Trim());
                    float price3 = Convert.ToSingle(item["Price3"].ToString().Trim());
                    float price4 = Convert.ToSingle(item["Price4"].ToString().Trim());
                    float price5 = Convert.ToSingle(item["Price5"].ToString().Trim());
                    float act1=0,act2=0,act3 = 0,act4 = 0,act5 = 0 ;
                    int department = Convert.ToInt32(item["Department"].ToString().Trim());
                    string inholl = item["InHoll"].ToString();
                    int restaurant = 1;
                    int existent = 0;
                    int groupp = Convert.ToInt32(item["Groupp"].ToString().Trim());
                    InsertRecord215(connection, "table_215", code, name1, name2, name3, unit, groupp, semiprepared, printer, price, price1, price2, price3, price4, price5, department, inholl,restaurant, existent);
                    InsertInventory215(connection, "Inventory_215", code, name1, name2, name3, unit, groupp, act1 , act2, act3, act4, act5, restaurant);

                }
                //**********************************************
                string jsonFilePath1 = "d:\\hayrik\\programmer\\json\\json_calc.json";
                string jsonContent1 = File.ReadAllText(jsonFilePath1);
                JObject json1 = JObject.Parse(jsonContent1);

                // Process each item in the 'items' array
                JArray items1 = (JArray)json1["items"];

                string query0 = $"TRUNCATE TABLE composition";
                using (SqlCommand command = new SqlCommand(query0, connection))
                {
                    command.ExecuteNonQuery();
                }
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
                        int restaurant = 1;
                        InsertRecordCalcul(connection, "Composition", code_215, code_211, name1, note, unit, coefficient, quantity, bruto, neto,restaurant);

                    }

            }

            if (parameter == "group")
            {
                int restaurant = 1;
                string query = $"TRUNCATE TABLE FoodGroupp";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                foreach (var item in items)
                    {
                         string name1 = item["Name_1"].ToString();
                        string name2 = item["Name_2"].ToString();
                        string name3 = item["Name_3"].ToString();
                        int groupp = Convert.ToInt32(item["Groupp"].ToString().Trim());
                        InsertRecordgroup(connection, "FoodGroupp", name1, name2, name3, groupp, restaurant);
                    }
            }

            if (parameter == "211")
            {
                string query = $"TRUNCATE TABLE Inventory";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                string query1 = $"TRUNCATE TABLE Table_211";
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.ExecuteNonQuery();
                }

                foreach (var item in items)
                    {
                        string code = item["Code"].ToString().Trim();
                        string name1 = item["Name_1"].ToString();
                        string name2 = item["Name_2"].ToString();
                        string name3 = item["Name_3"].ToString();
                        string unit = item["Unit"].ToString();
                        int groupp = Convert.ToInt32(item["Groupp"].ToString().Trim());
                        float price = Convert.ToSingle(item["Price"].ToString().Trim());
                    float actually1 = 0, actually2 = 0, actually3 = 0, actually4 = 0, actually5 = 0,
                        act215_1 = 0, act215_2 = 0, act215_3 = 0, act215_4 = 0, act215_5 = 0;
                        int restaurant = 1;
                        InsertRecord(connection, "Table_211", code, name1, name2, name3, unit, price, groupp,restaurant);
                        InsertRecordInventory(connection, "Inventory", code, name1, name2, name3, unit, price, restaurant,
                            actually1,actually2, actually3, actually4, actually5, act215_1, act215_2, act215_3, act215_4, act215_5);
                }
            }
            //***********************************
            if (parameter == "213")
            {
                string query = $"TRUNCATE TABLE Table_213";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                foreach (var item in items)
                    {
                        string code = item["Code"].ToString().Trim();
                        string name1 = item["Name_1"].ToString();
                        string name2 = item["Name_2"].ToString();
                        string name3 = item["Name_3"].ToString();
                        string unit = item["Unit"].ToString();
                        int groupp = Convert.ToInt32(item["Groupp"].ToString().Trim());
                        float price = Convert.ToSingle(item["Price"].ToString().Trim());
                        int restaurant = 1;
                        InsertRecord(connection, "Table_213", code, name1, name2, name3, unit, price, groupp,restaurant);
                    }
            }

            //***********************************
            if (parameter == "111")
            {
                string query = $"TRUNCATE TABLE Table_111";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                foreach (var item in items)
                    {
                        string code = item["Code"].ToString().Trim();
                        string name1 = item["Name_1"].ToString();
                        string name2 = item["Name_2"].ToString();
                        string name3 = item["Name_3"].ToString();
                        string unit = item["Unit"].ToString();
                        int groupp = Convert.ToInt32(item["Groupp"].ToString().Trim());
                        float price = Convert.ToSingle(item["Price"].ToString().Trim());
                        int restaurant = 1;
                        InsertRecord(connection, "Table_111", code, name1, name2, name3, unit, price, groupp, restaurant);
                    }
            }
            //***********************************
            if (parameter == "addition")
            {
                string query = $"TRUNCATE TABLE AdditionGroups";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
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
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    command.ExecuteNonQuery();
                }

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
    private static void InsertRecord(SqlConnection connection, string tableName,  string code, string name1,
        string name2, string name3, string unit, float price, int groupp,int restaurant)
    {
        string query = $"INSERT INTO {tableName} ( Code, Name_1, Name_2, Name_3, Unit, CostPrice, Groupp,Restaurant) " +
                       $"VALUES (@Code, @Name1, @Name2, @Name3, @Unit, @Price,@Groupp,@Restaurant)";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Code", code);
            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Name2", name2);
            command.Parameters.AddWithValue("@Name3", name3);
            command.Parameters.AddWithValue("@Unit", unit);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@Groupp", groupp);
            command.Parameters.AddWithValue("@Restaurant", 1);
            command.ExecuteNonQuery();
        }
    }
    
    private static void InsertRecordInventory(SqlConnection connection, string tableName, string code, string name1,
        string name2, string name3, string unit, float price,  int restaurant,
        float actually1, float actually2, float actually3, float actually4, float actually5,
        float act215_1, float act215_2, float act215_3, float act215_4, float act215_5)
    {
        string query = $"INSERT INTO {tableName} ( Code, Name_1, Name_2, Name_3, Unit, CostPrice,Restaurant," +
                       $"Actually1,Actually2,Actually3,Actually4,Actually5," +
                       $"Act215_1, Act215_2, Act215_3, Act215_4, Act215_5) " +
                       $"VALUES (@Code, @Name1, @Name2, @Name3, @Unit, @Price,@Restaurant," +
                       $" @Actually1, @Actually2, @Actually3, @Actually4, @Actually5," +
                       $" @Act215_1, @Act215_2, @Act215_3, @Act215_4, @Act215_5)";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Code", code);
            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Name2", name2);
            command.Parameters.AddWithValue("@Name3", name3);
            command.Parameters.AddWithValue("@Unit", unit);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@Restaurant", 1);
            command.Parameters.AddWithValue("@Actually1", actually1);
            command.Parameters.AddWithValue("@Actually2", actually2);
            command.Parameters.AddWithValue("@Actually3", actually3);
            command.Parameters.AddWithValue("@Actually4", actually4);
            command.Parameters.AddWithValue("@Actually5", actually5);
            command.Parameters.AddWithValue("@Act215_1", act215_1);
            command.Parameters.AddWithValue("@Act215_2", act215_2);
            command.Parameters.AddWithValue("@Act215_3", act215_3);
            command.Parameters.AddWithValue("@Act215_4", act215_4);
            command.Parameters.AddWithValue("@Act215_5", act215_5);

            command.ExecuteNonQuery();
        }
    }
    private static void InsertRecordgroup(SqlConnection connection, string tableName, string name1, string name2, string name3, int groupp,int restaurant)
    {
        string query = $"INSERT INTO {tableName} (Name_1, Name_2, Name_3, Groupp, Restaurant) " +
                       $"VALUES (@Name1, @Name2, @Name3,@Groupp,@Restaurant)";

        using (SqlCommand command = new SqlCommand(query, connection))
        {

            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Name2", name2);
            command.Parameters.AddWithValue("@Name3", name3);
            command.Parameters.AddWithValue("@Groupp", groupp);
            command.Parameters.AddWithValue("@Restaurant", restaurant);
            command.ExecuteNonQuery();
        }
    }

    private static void InsertRecordaddgr(SqlConnection connection, string tableName, int number, string name1, string name2, string name3)
    {
        string query = $"INSERT INTO {tableName} (Number,Name_1, Name_2, Name_3) " +
                       $"VALUES (@Number, @Name1, @Name2, @Name3)";

        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Number", number);
            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Name2", name2);
            command.Parameters.AddWithValue("@Name3", name3);

            command.ExecuteNonQuery();
        }
    }
    private static void InsertRecordCalcul(SqlConnection connection, string tableName, string code_215,
     string code_211, string name1, string note, string unit, float coefficient, float quantity, float bruto, float neto, int restaurant)
    {
        string query = $"INSERT INTO {tableName} (Code_215,Code_211, Name_1, Note, Unit, Coefficient, Quantity, Bruto,Neto,Restaurant) " +
                      $"VALUES (@Code_215, @Code_211, @Name1, @Note, @Unit, @Coefficient, @Quantity, @Bruto, @Neto,@Restaurant)";

        using (SqlCommand command = new SqlCommand(query, connection))
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
            command.Parameters.AddWithValue("@Restaurant", 1);
            command.ExecuteNonQuery();
        }
    }
    private static void InsertRecord215(SqlConnection connection, string tableName,  string code, string name1,
    string name2, string name3, string unit, int groupp, bool semiprepared, int printer, float price, float price1,
    float price2, float price3, float price4, float price5, int department, string inholl, int restaurant, int existent)
    {
        string query = $"INSERT INTO {tableName} (Code, Name_1, Name_2, Name_3, Unit, Groupp, SemiPrepared," +
            $" Printer, Price, Price1, Price2, Price3, Price4, Price5, Department, InHoll,Restaurant,Existent) VALUES (@Code, @Name1," +
            $" @Name2, @Name3, @Unit, @Groupp,@SemiPrepared, @Printer, @Price, @Price1, @Price2, @Price3, @Price4, @Price5, @Department, @InHoll, @Restaurant,@Existent)";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Code", code);
            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Name2", name2);
            command.Parameters.AddWithValue("@Name3", name3);
            command.Parameters.AddWithValue("@Unit", unit);
            command.Parameters.AddWithValue("@Groupp", groupp);
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
            command.Parameters.AddWithValue("@Restaurant", restaurant);
            command.Parameters.AddWithValue("@Existent", restaurant);
            command.ExecuteNonQuery();
        }
    }

    private static void InsertInventory215(SqlConnection connection, string tableName, string code, string name1,
string name2, string name3, string unit, int groupp, float act1, float act2, float act3, float act4, float act5, int restaurant)
    {
        string query = $"INSERT INTO {tableName} (Code, Name_1, Name_2, Name_3, Unit, Groupp, " +
            $" Act215_1, Act215_2, Act215_3, Act215_4, Act215_5, Restaurant) VALUES (@Code, @Name1," +
            $" @Name2, @Name3, @Unit, @Groupp,@Act215_1, @Act215_2, @Act215_3, @Act215_4, @Act215_5, @Restaurant)";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Code", code);
            command.Parameters.AddWithValue("@Name1", name1);
            command.Parameters.AddWithValue("@Name2", name2);
            command.Parameters.AddWithValue("@Name3", name3);
            command.Parameters.AddWithValue("@Unit", unit);
            command.Parameters.AddWithValue("@Groupp", groupp);
            command.Parameters.AddWithValue("@Act215_1", act1);
            command.Parameters.AddWithValue("@Act215_2", act2);
            command.Parameters.AddWithValue("@Act215_3", act3);
            command.Parameters.AddWithValue("@Act215_4", act4);
            command.Parameters.AddWithValue("@Act215_5", act5);
            command.Parameters.AddWithValue("@Restaurant", restaurant);
            command.ExecuteNonQuery();
        }
    }
    // Define other helper methods as needed for inserting/updating records
}