﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using static Mysqlx.Notice.SessionStateChanged.Types;

namespace WindowsFormsApp4
{
    public static class Save
    {
        public static void UpdateTableFromDatatable(string connectionString, DataTable datatable, string Parameter)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string parameter = Parameter;

                if (parameter == "215")
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        string code = row["Code"].ToString().Trim();
                        string name1 = row["Name_1"].ToString();
                        string name2 = row["Name_2"].ToString();
                        string name3 = row["Name_3"].ToString();
                        string unit = row["Unit"].ToString();
                        int group = Convert.ToInt32(row["Group"].ToString().Trim());
                        bool semiprepared = bool.Parse(row["SemiPrepared"].ToString());
                        int printer = Convert.ToInt32(row["Printer"].ToString().Trim());
                        float price = Convert.ToSingle(row["Price"].ToString().Trim());
                        float price1 = Convert.ToSingle(row["Price1"].ToString().Trim());
                        float price2 = Convert.ToSingle(row["Price2"].ToString().Trim());
                        float price3 = Convert.ToSingle(row["Price3"].ToString().Trim());
                        float price4 = Convert.ToSingle(row["Price4"].ToString().Trim());
                        float price5 = Convert.ToSingle(row["Price5"].ToString().Trim());
                        int department = Convert.ToInt32(row["Department"].ToString().Trim());
                        string inholl = row["InHoll"].ToString();

                        // Check if the code already exists in the table
                        bool codeExists = CheckIfCodeExists(connection, "table_215", code);

                        if (codeExists)
                        {
                            // Update the fields if the code exists
                            UpdateFields215(connection, "table_215", code, name1, name2, name3, unit, group, semiprepared, printer, price, price1, price2, price3, price4, price5, department, inholl);

                        }
                        else
                        {
                            // Insert a new record if the code doesn't exist
                            InsertRecord215(connection, "table_215", code, name1, name2, name3, unit, group, semiprepared, printer, price, price1, price2, price3, price4, price5, department, inholl);

                        }
                    }
                }
                //***********************************
                if (parameter == "211")
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        if (int.Parse(row["Changed"].ToString()) == 0) continue;
                        string code = row["Code"].ToString().Trim();
                        string name1 = row["Name_1"].ToString();
                        string name2 = row["Name_2"].ToString();
                        string name3 = row["Name_3"].ToString();
                        string unit = row["Unit"].ToString();
                        int group = Convert.ToInt32(row["Group"].ToString().Trim());
                        float costprice = Convert.ToSingle(row["CostPrice"].ToString().Trim());
                        bool codeExists = CheckIfCodeExists(connection, "table_211", code);

                        if (codeExists)
                        {
                            UpdateFields(connection, "table_211", code, name1, name2, name3, unit, group, costprice);
                        }
                        else
                        {
                            InsertRecord(connection, "table_211", code, name1, name2, name3, unit, group, costprice);
                        }
                    }
                }

                //***********************************
                if (parameter == "211_cost") //միայն գները
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        if (int.Parse(row["Changed"].ToString()) == 0) continue;
                        string code = row["Code"].ToString().Trim();
                        float costprice = Convert.ToSingle(row["CostPrice"].ToString().Trim());
                        UpdateFields_cost(connection, "table_211", code, costprice);
                        UpdateFieldscomposite(connection, "composite", code, costprice);
                    }
                }

                //***********************************
                if (parameter == "111")
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        if (int.Parse(row["Changed"].ToString()) == 0) continue;
                        string code = row["Code"].ToString().Trim();
                        string name1 = row["Name_1"].ToString();
                        string name2 = row["Name_2"].ToString();
                        string name3 = row["Name_3"].ToString();
                        string unit = row["Unit"].ToString();
                        int group = Convert.ToInt32(row["Group"].ToString().Trim());
                        float costprice = Convert.ToSingle(row["CostPrice"].ToString().Trim());
                        // Check if the code already exists in the table
                        bool codeExists = CheckIfCodeExists(connection, "table_111", code);

                        if (codeExists)
                        {
                            // Update the fields if the code exists
                            UpdateFields(connection, "table_111", code, name1, name2, name3, unit, group, costprice);
                        }
                        else
                        {
                            // Insert a new record if the code doesn't exist
                            InsertRecord(connection, "table_111", code, name1, name2, name3, unit, group, costprice);
                        }
                    }
                }
                //***********************************
                if (parameter == "111_cost") //միայն գները
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        if (int.Parse(row["Changed"].ToString()) == 0) continue;
                        string code = row["Code"].ToString().Trim();
                        float costprice = Convert.ToSingle(row["CostPrice"].ToString().Trim());
                        bool codeExists = CheckIfCodeExists(connection, "table_111", code);
                        if (codeExists)
                        {
                            UpdateFields_cost(connection, "table_111", code, costprice);
                        }
                    }
                }
                //***********************************
                if (parameter == "213")
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        if (int.Parse(row["Changed"].ToString()) == 0) continue;
                        string code = row["Code"].ToString().Trim();
                        string name1 = row["Name_1"].ToString();
                        string name2 = row["Name_2"].ToString();
                        string name3 = row["Name_3"].ToString();
                        string unit = row["Unit"].ToString();
                        int group = Convert.ToInt32(row["Group"].ToString().Trim());
                        float costprice = Convert.ToSingle(row["CostPrice"].ToString().Trim());
                        // Check if the code already exists in the table
                        bool codeExists = CheckIfCodeExists(connection, "table_213", code);

                        if (codeExists)
                        {
                            // Update the fields if the code exists
                            UpdateFields(connection, "table_213", code, name1, name2, name3, unit, group, costprice);

                        }
                        else
                        {
                            // Insert a new record if the code doesn't exist
                            InsertRecord(connection, "table_213", code, name1, name2, name3, unit, group, costprice);

                        }
                    }
                    //***********************************
                    if (parameter == "213_cost") //միայն գները
                    {
                        foreach (DataRow row in datatable.Rows)
                        {
                            if (int.Parse(row["Changed"].ToString()) == 0) continue;
                            string code = row["Code"].ToString().Trim();
                            float costprice = Convert.ToSingle(row["CostPrice"].ToString().Trim());
                            bool codeExists = CheckIfCodeExists(connection, "table_213", code);
                            if (codeExists)
                            {
                                UpdateFields_cost(connection, "table_213", code, costprice);
                            }
                        }
                    }
                }

                //if (parameter == "Table_Purchase") // actions ֆայլում ավելացնում ենք գործողությունները
                //{
                //    foreach (DataRow row in datatable.Rows)
                //    {
                //        string code = row["Code"].ToString().Trim();
                //        string kredit = row["Kredit"].ToString();
                //        string debet = row["Debet"].ToString();
                //        int number = int.Parse(row["Number"].ToString());
                //        int opperator = int.Parse(row["Operator"].ToString());
                //        int restaurant = int.Parse(row["Restaurant"].ToString());
                //        int departmentin = int.Parse(row["DepartmentIn"].ToString());
                //        int departmentout = int.Parse(row["DepartmentOut"].ToString());
                //        int kreditor = Convert.ToInt32(row["Kreditor"].ToString().Trim());
                //        int debitor = Convert.ToInt32(row["Debitor"].ToString().Trim());  
                //        float quantity = Convert.ToSingle(row["Quantity"].ToString().Trim());
                //        float costamount = Convert.ToSingle(row["Costamount"].ToString().Trim());
                //        float salesamount = Convert.ToSingle(row["Salesamount"].ToString().Trim());
                //        DateTime accountingdate = Convert.ToDateTime(row["AccountingDate"]);
                //        DateTime dateofentry = Convert.ToDateTime(row["DateOfEntry"]);
                //        InsertRecordPurchase(connection, "Table_Purchase",number, code, quantity, costamount, salesamount, opperator, restaurant, debet,
                //            kredit, departmentin, departmentout, kreditor,debitor, accountingdate, dateofentry);
                //    }
                //}
            }
        }

        //private static void InsertRecordPurchase(MySqlConnection connection, string tableName, int number, string code, float quantity, float costamount, 
        //    float salesamount, int opperator, int restaurant, string debet, string kredit, int departmentin, int departmentout,
        //    int kreditor, int debitor, DateTime accountingdate, DateTime dateofentry)
        //{
        //    string query = $"INSERT INTO actions (`Number`,`Code`, `Quantity`, `CostAmount`, `SalesAmount`, `Operator`, `Restaurant`, `Debet`," +
        //        $" `Kredit`, `DepartmentIn`, `DepartmentOut`, `Kreditor`, `Debitor`, `AccountingDate`, `DateOfEntry`) " +
        //                   $"VALUES (@number, @Code, @Quantity, @CostAmount, @SalesAmount, @Operator, @Restaurant, @Debet, @Kredit, " +
        //                   $" @DepartmentIn, @DepartmentOut, @Kreditor, @Debitor, @AccountingDate, @DateOfEntry)";

        //    using (MySqlCommand command = new MySqlCommand(query, connection))
        //    {
        //        command.Parameters.AddWithValue("@Number", number);
        //        command.Parameters.AddWithValue("@Code", code);
        //          command.Parameters.AddWithValue("@Quantity", quantity);
        //        command.Parameters.AddWithValue("@CostAmount", costamount);
        //        command.Parameters.AddWithValue("@SalesAmount", salesamount);
        //        command.Parameters.AddWithValue("@Operator", opperator);
        //        command.Parameters.AddWithValue("@Restaurant", restaurant);
        //        command.Parameters.AddWithValue("@Debet", debet);
        //        command.Parameters.AddWithValue("@Kredit", kredit);
        //        command.Parameters.AddWithValue("@DepartmentIn", departmentin);
        //        command.Parameters.AddWithValue("@DepartmentOut", departmentout);
        //        command.Parameters.AddWithValue("@Kreditor", kreditor);
        //        command.Parameters.AddWithValue("@Debitor", debitor);
        //        command.Parameters.AddWithValue("@AccountingDate", accountingdate);
        //        command.Parameters.AddWithValue("@DateOfEntry", dateofentry);
        //        command.ExecuteNonQuery();
        //    }
        //}
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
        private static bool CheckIfCodeExistsCalc(MySqlConnection connection, string tableName, string code_215, string code_211)
        {
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE Code_215 = @Code_215 AND Code_211 = @Code_211 ";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Code_215", code_215);
                command.Parameters.AddWithValue("@Code_211", code_211);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
        private static void UpdateFields215(MySqlConnection connection, string tableName, string code, string name1,
                    string name2, string name3, string unit, int group, bool semiprepared, int printer, float price, float price1, float price2,
                    float price3, float price4, float price5, int department, string inholl)
        {
            string query = $"UPDATE {tableName} SET Name_1 = @Name1, Name_2 = @Name2, Name_3 = @Name3, Unit = @Unit," +
                $" `Group` = @Group,`SemiPrepared` = @semiprepared, Printer = @Printer, CostPrice = @Price, Price1 = @Price1, Price2 = @Price2, Price3 = @Price3," +
                $" Price4 = @Price4, Price5 = @Price5, Department = @Department, InHoll = @InHoll WHERE Code = @Code";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
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
                command.Parameters.AddWithValue("@Code", code);
                command.ExecuteNonQuery();
            }
        }

        private static void UpdateFields(MySqlConnection connection, string tableName, string code, string name1, string name2, string name3, string unit, int group, float costprice)
        {
            string query = $"UPDATE {tableName} SET `Name_1` = @Name1, `Name_2` = @Name2, `Name_3` = @Name3, `Unit` = @Unit, `Group` = @Group, `CostPrice` = @costprice WHERE `Code` = @Code";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name1", name1);
                command.Parameters.AddWithValue("@Name2", name2);
                command.Parameters.AddWithValue("@Name3", name3);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Group", group);
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@CostPrice", costprice);

                command.ExecuteNonQuery();
            }
        }

        private static void UpdateFields_cost(MySqlConnection connection, string tableName, string code, float costprice)
        {
            string query = $"UPDATE {tableName} SET  `CostPrice` = @costprice WHERE `Code` = @Code";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@CostPrice", costprice);

                command.ExecuteNonQuery();
            }
        }


        private static void UpdateFieldscomposite(MySqlConnection connection, string tableName, string code, float costprice)
        {
            string query = $"UPDATE {tableName} SET `CostPrice` = @costprice WHERE `Code_211` = @Code";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@CostPrice", costprice);
                command.ExecuteNonQuery();
            }
            string query1 = $"UPDATE composition SET `CostPrice` = @costprice WHERE `Code_211` = @Code";
            using (MySqlCommand command = new MySqlCommand(query1, connection))
            {
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@CostPrice", costprice);
                command.ExecuteNonQuery();
            }
        }
        private static void InsertRecord(MySqlConnection connection, string tableName, string code, string name1, string name2, string name3, string unit, int group, float costprice)
        {
            string query = $"INSERT INTO {tableName} (`Code`, `Name_1`, `Name_2`, `Name_3`, `Unit`, `CostPrice`, `Group`) " +
                           $"VALUES (@Code, @Name1, @Name2, @Name3, @Unit, @CostPrice,@Group)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name1", name1);
                command.Parameters.AddWithValue("@Name2", name2);
                command.Parameters.AddWithValue("@Name3", name3);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Group", group);
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@CostPrice", costprice);
                command.ExecuteNonQuery();
            }
        }
        //connection, "composition", code_215, code_211, name1, note, unit, coefficient, quantity, bruto, neto
        private static void UpdateFieldsCalcul(MySqlConnection connection, string tableName, string code_215,
                    string code_211, string name1, string note, string unit, float coefficient, float quantity, float bruto, float neto)
        {
            string query = $"UPDATE {tableName} SET `Name_1` = @Name1, `Note` = @Note, `Unit` = @Unit, " +
                $"`Coefficient` = @Coefficient, `Quantity` = @quantity, `Bruto` = @Bruto, `Neto` = @Neto WHERE `Code_215` = @Code_215 AND `Code_211` = @Code_211 ";
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

        private static void InsertRecordCalcul(MySqlConnection connection, string tableName, string code_215,
                string code_211, string name1, string note, string unit, float coefficient, float quantity, float bruto, float neto)
        {
            string query = $"INSERT INTO {tableName} (`Code_215`,`Code_211`, `Name_1`, `Note`, `Unit`, `Coefficient`, `Quantity`, `Bruto`,`Neto`) " +
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
                    string name2, string name3, string unit, int group, bool semiprepared, int printer, float price, float price1,
                    float price2, float price3, float price4, float price5, int department, string inholl)
        {
            string query = $"INSERT INTO {tableName} (Code, Name_1, Name_2, Name_3, Unit, `Group`,`SemiPrepared`," +
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


    }
}

