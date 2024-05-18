
using Amazon.DynamoDBv2.Model;
using System;
using System.Data;

using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
namespace WindowsFormsApp4
{
    public static class Save
    {
        public static void UpdateTableFromDatatable(string connectionString, DataTable datatable, string Parameter, int Restaurant)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string parameter = Parameter;
                int _restaurant= Restaurant;
                //if (parameter == "215")
                //{
                //    foreach (DataRow row in datatable.Rows)
                //    {
                //        if (row["Changed"] != DBNull.Value && decimal.Parse(row["Changed"].ToString()) == 0) continue; //տողը փոփոխված չի
                //        string code = row["Code"].ToString().Trim();
                //        string arm = row["Armenian"].ToString();
                //        string eng = row["English"].ToString();
                //        string ger = row["German"].ToString();
                //        string esp = row["Espaniol"].ToString();
                //        string rus = row["Russian"].ToString();
                //        string unit = row["Unit"].ToString();
                //        string atg = row["ATG"].ToString();
                //        int existent= Convert.ToInt32(row["Existent"].ToString().Trim());
                //        int groupp = Convert.ToInt32(row["Groupp"].ToString().Trim());
                //        int semiprepared = int.Parse(row["SemiPrepared"].ToString());
                //        int printer = Convert.ToInt32(row["Printer"].ToString().Trim());
                //        decimal price = Convert.ToSingle(row["Price"].ToString().Trim());
                //        decimal price1 = Convert.ToSingle(row["Price1"].ToString().Trim());
                //        decimal price2 = Convert.ToSingle(row["Price2"].ToString().Trim());
                //        decimal price3 = Convert.ToSingle(row["Price3"].ToString().Trim());
                //        decimal price4 = Convert.ToSingle(row["Price4"].ToString().Trim());
                //        decimal price5 = Convert.ToSingle(row["Price5"].ToString().Trim());
                //        int department = Convert.ToInt32(row["Department"].ToString().Trim());
                //        string inholl = row["InHoll"].ToString();
                //        string non = row["NonComposite"].ToString();

                //        // Check if the code already exists in the table
                //        bool codeExists = CheckIfCodeExists(connection, "table_215", code);

                //        if (codeExists)
                //        {
                //            // Update the fields if the code exists
                //            UpdateFields215(connection, "table_215", code, arm, eng, ger, esp, rus, unit, groupp, semiprepared, printer, price, price1, price2, price3, price4, price5, department, inholl, atg, existent, non);

                //        }
                //        else
                //        {
                //            // Insert a new record if the code doesn't exist
                //            InsertRecord215(connection, "table_215", code, arm, eng, ger, esp, rus, unit, groupp, semiprepared, printer, price, price1, price2, price3, price4, price5, department, inholl, atg,non, _restaurant);

                //        }
                //    }
                //}
                if (parameter == "Composition")
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        if (row["Changed"] != DBNull.Value && decimal.Parse(row["Changed"].ToString()) == 0)
                        {
                            continue; //տողը փոփոխված չի
                        }

                        string code_215 = row["Code_215"].ToString().Trim();
                        string code_211 = row["Code_211"].ToString().Trim();
                       string unit = row["Unit"].ToString();
                        string note = row["Note"].ToString();
                        decimal coefficient = decimal.Parse(row["Coefficient"].ToString().Trim());
                        decimal quantity = decimal.Parse(row["Quantity"].ToString().Trim());
                        decimal bruto = decimal.Parse(row["Bruto"].ToString().Trim());
                        decimal neto = decimal.Parse(row["Neto"].ToString().Trim());

                        bool codeExists = CheckIfCodeExistsCalc(connection, "Composition", code_215, code_211);
                        if (codeExists)
                        {
                            // Update the fields if the code exists
                            UpdateFieldsCalcul(connection, "Composition", code_215, code_211, note, unit, coefficient, quantity, bruto, neto);
                        }
                        else
                        {
                            // Insert a new record if the code doesn't exist
                            InsertRecordCalcul(connection, "Composition", code_215, code_211,  note, unit, coefficient, quantity, bruto, neto, _restaurant);
                        }

                    }
                }
                //***********************************
                //if (parameter == "211")
                //{
                //    foreach (DataRow row in datatable.Rows)
                //    {
                //        if (row["Changed"] != DBNull.Value && decimal.Parse(row["Changed"].ToString()) == 0) continue;
                //        string code = row["Code"].ToString().Trim();
                //        string arm = row["Armenian"].ToString();
                //        string eng = row["English"].ToString();
                //        string ger = row["German"].ToString();
                //        string esp = row["Espaniol"].ToString();
                //        string rus = row["Russian"].ToString();
                //        string unit = row["Unit"].ToString();
                //        int groupp = Convert.ToInt32(row["Groupp"].ToString().Trim());
                //        decimal costprice = Convert.ToSingle(row["CostPrice"].ToString().Trim());
                //        bool codeExists = CheckIfCodeExists(connection, "table_211", code);

                //        if (codeExists)
                //        {
                //            UpdateFields(connection, "table_211", code, arm, eng, ger, esp, rus, unit, groupp, costprice);
                //        }
                //        else
                //        {
                //            InsertRecord(connection, "table_211", code, arm, eng, ger, esp, rus, unit, groupp, costprice, _restaurant);
                //        }
                //    }
                //}

                //***********************************
                if (parameter == "211_cost") //միայն գները
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        if (row["Changed"] != DBNull.Value && decimal.Parse(row["Changed"].ToString()) == 0) continue;
                        string code = row["Code"].ToString().Trim();
                        decimal costprice = decimal.Parse(row["CostPrice"].ToString().Trim());
                        UpdateFields_cost(connection, "table_211", code, costprice);
                        UpdateFieldscomposite(connection, "composite", code, costprice);
                    }
                }

                //***********************************
                //if (parameter == "111")
                //{
                //    foreach (DataRow row in datatable.Rows)
                //    {
                //        if (row["Changed"] != DBNull.Value && decimal.Parse(row["Changed"].ToString()) == 0) continue;
                //        string code = row["Code"].ToString().Trim();
                //        string arm = row["Armenian"].ToString();
                //        string eng = row["English"].ToString();
                //        string ger = row["German"].ToString();
                //        string esp = row["Espaniol"].ToString();
                //        string rus = row["Russian"].ToString();
                //        string unit = row["Unit"].ToString();
                //        int groupp = Convert.ToInt32(row["Groupp"].ToString().Trim());
                //        decimal costprice = Convert.ToSingle(row["CostPrice"].ToString().Trim());
                //        // Check if the code already exists in the table
                //        bool codeExists = CheckIfCodeExists(connection, "table_111", code);

                //        if (codeExists)
                //        {
                //            // Update the fields if the code exists
                //            UpdateFields(connection, "table_111", code, arm, eng, ger, esp, rus, unit, groupp, costprice);
                //        }
                //        else
                //        {
                //            // Insert a new record if the code doesn't exist
                //            InsertRecord(connection, "table_111", code, arm, eng, ger, esp, rus, unit, groupp, costprice, _restaurant);
                //        }
                //    }
                //}
                //***********************************
                if (parameter == "111_cost") //միայն գները
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        if (row["Changed"] != DBNull.Value && decimal.Parse(row["Changed"].ToString()) == 0) continue;
                        string code = row["Code"].ToString().Trim();
                        decimal costprice = decimal.Parse(row["CostPrice"].ToString().Trim());
                        bool codeExists = CheckIfCodeExists(connection, "table_111", code);
                        if (codeExists)
                        {
                            UpdateFields_cost(connection, "table_111", code, costprice);
                        }
                    }
                }
                //***********************************
                //if (parameter == "213")
                //{
                //    foreach (DataRow row in datatable.Rows)
                //    {
                //        if (row["Changed"] != DBNull.Value && decimal.Parse(row["Changed"].ToString()) == 0) continue;
                //        string code = row["Code"].ToString().Trim();
                //        string arm = row["Armenian"].ToString();
                //        string eng = row["English"].ToString();
                //        string ger = row["German"].ToString();
                //        string esp = row["Espaniol"].ToString();
                //        string rus = row["Russian"].ToString();
                //        string unit = row["Unit"].ToString();
                //        int groupp = Convert.ToInt32(row["Groupp"].ToString().Trim());
                //        decimal costprice = Convert.ToSingle(row["CostPrice"].ToString().Trim());
                //        // Check if the code already exists in the table
                //        bool codeExists = CheckIfCodeExists(connection, "table_213", code);

                //        if (codeExists)
                //        {
                //            // Update the fields if the code exists
                //            UpdateFields(connection, "table_213", code,  arm, eng, ger, esp, rus, unit, groupp, costprice);

                //        }
                //        else
                //        {
                //            // Insert a new record if the code doesn't exist
                //            InsertRecord(connection, "table_213", code, arm, eng, ger, esp, rus, unit, groupp, costprice, _restaurant);

                //        }
                //    }
                //    //***********************************
                //    if (parameter == "213_cost") //միայն գները
                //    {
                //        foreach (DataRow row in datatable.Rows)
                //        {
                //            if (row["Changed"] != DBNull.Value && decimal.Parse(row["Changed"].ToString()) == 0) continue;
                //            string code = row["Code"].ToString().Trim();
                //            decimal costprice = Convert.ToSingle(row["CostPrice"].ToString().Trim());
                //            bool codeExists = CheckIfCodeExists(connection, "table_213", code);
                //            if (codeExists)
                //            {
                //                UpdateFields_cost(connection, "table_213", code, costprice);
                //            }
                //        }
                //    }
                //}

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
                //        decimal quantity = Convert.ToSingle(row["Quantity"].ToString().Trim());
                //        decimal costamount = Convert.ToSingle(row["Costamount"].ToString().Trim());
                //        decimal salesamount = Convert.ToSingle(row["Salesamount"].ToString().Trim());
                //        DateTime accountingdate = Convert.ToDateTime(row["AccountingDate"]);
                //        DateTime dateofentry = Convert.ToDateTime(row["DateOfEntry"]);
                //        InsertRecordPurchase(connection, "Table_Purchase",number, code, quantity, costamount, salesamount, opperator, restaurant, debet,
                //            kredit, departmentin, departmentout, kreditor,debitor, accountingdate, dateofentry);
                //    }
                //}
            }
        }

        //private static void InsertRecordPurchase(SqlConnection connection, string tableName, int number, string code, decimal quantity, decimal costamount, 
        //    decimal salesamount, int opperator, int restaurant, string debet, string kredit, int departmentin, int departmentout,
        //    int kreditor, int debitor, DateTime accountingdate, DateTime dateofentry)
        //{
        //    string query = $"INSERT INTO actions (Number,Code, Quantity, CostAmount, SalesAmount, Operator, Restaurant, Debet," +
        //        $" Kredit, DepartmentIn, DepartmentOut, Kreditor, Debitor, AccountingDate, DateOfEntry) " +
        //                   $"VALUES (@number, @Code, @Quantity, @CostAmount, @SalesAmount, @Operator, @Restaurant, @Debet, @Kredit, " +
        //                   $" @DepartmentIn, @DepartmentOut, @Kreditor, @Debitor, @AccountingDate, @DateOfEntry)";

        //    using (SqlCommand command = new SqlCommand(query, connection))
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
        private static bool CheckIfCodeExists(SqlConnection connection, string tableName, string code)
        {
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE Code = @Code";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Code", code);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
        private static bool CheckIfCodeExistsCalc(SqlConnection connection, string tableName, string code_215, string code_211)
        {
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE Code_215 = @Code_215 AND Code_211 = @Code_211 ";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Code_215", code_215);
                command.Parameters.AddWithValue("@Code_211", code_211);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
        private static void UpdateFields215(SqlConnection connection, string tableName, string code, string arm,
                    string eng, string ger, string esp, string rus, string unit, int groupp, int semiprepared, int printer, decimal price, decimal price1, decimal price2,
                    decimal price3, decimal price4, decimal price5, int department, string inholl, string  atg, int existent, string non)
        {
            string query = $"UPDATE {tableName} SET Armenian = @Armenian, English = @English, German = @German,Espaniol=@Espaniol," +
                $" Russian = @Russian, Unit = @Unit, Groupp = @Groupp,SemiPrepared = @semiprepared, Printer = @Printer," +
                $" CostPrice = @Price, Price1 = @Price1, Price2 = @Price2, Price3 = @Price3, Price4 = @Price4," +
                $" Price5 = @Price5, Department = @Department, InHoll = @InHoll, ATG = @atg," +
                $" Existent = @existent,NonComposite=@NonComposite WHERE Code = @Code";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Armenian", arm);
                command.Parameters.AddWithValue("@English", eng);
                command.Parameters.AddWithValue("@German", ger);
                command.Parameters.AddWithValue("@Espaniol", esp);
                command.Parameters.AddWithValue("@Russian", rus);
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
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@atg", atg);
                command.Parameters.AddWithValue("@existent", existent);
                command.Parameters.AddWithValue("@NonComposite", non);
                command.ExecuteNonQuery();
            }
        }

        private static void UpdateFields(SqlConnection connection, string tableName, string code, string arm, string eng,
            string ger, string esp, string rus, string unit, int groupp, decimal costprice)
        {
            string query = $"UPDATE {tableName} SET Armenian = @Armenian, English = @English,German = @German," +
                $" Espaniol = @Espaniol, Russian = @Russian, Unit = @Unit, Groupp = @Groupp, CostPrice = @costprice" +
                $" WHERE Code = @Code";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Armenian", arm);
                command.Parameters.AddWithValue("@English", eng);
                command.Parameters.AddWithValue("@German", ger);
                command.Parameters.AddWithValue("@Espaniol", esp);
                command.Parameters.AddWithValue("@Russian", rus);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Groupp", groupp);
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@CostPrice", costprice);

                command.ExecuteNonQuery();
            }
        }

        private static void UpdateFields_cost(SqlConnection connection, string tableName, string code, decimal costprice)
        {
            string query = $"UPDATE {tableName} SET  CostPrice = @costprice WHERE Code = @Code";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@CostPrice", costprice);

                command.ExecuteNonQuery();
            }
        }


        private static void UpdateFieldscomposite(SqlConnection connection, string tableName, string code, decimal costprice)
        {
            string query = $"UPDATE {tableName} SET CostPrice = @costprice WHERE Code_211 = @Code";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@CostPrice", costprice);
                command.ExecuteNonQuery();
            }
            string query1 = $"UPDATE composition SET CostPrice = @costprice WHERE Code_211 = @Code";
            using (SqlCommand command = new SqlCommand(query1, connection))
            {
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@CostPrice", costprice);
                command.ExecuteNonQuery();
            }
        }
        private static void InsertRecord(SqlConnection connection, string tableName, string code, string arm, string eng, string ger, string esp, string rus, string unit, int groupp, decimal costprice, int restaurant)
        {
            string query = $"INSERT INTO {tableName} (Code, Armenian, English, German, Espaniol, Russian," +
                $" Unit, CostPrice, Groupp, Restaurant) " +
                           $"VALUES (@Code, @Armenian, @English, @German, @Espaniol, @Russian, @Unit, @CostPrice,@Groupp, @Restaurant)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Armenian", arm);
                command.Parameters.AddWithValue("@English", eng);
                command.Parameters.AddWithValue("@German", ger);
                command.Parameters.AddWithValue("@Espaniol", esp);
                command.Parameters.AddWithValue("@Russian", rus);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Groupp", groupp);
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@CostPrice", costprice);
                command.Parameters.AddWithValue("@Restaurant", restaurant);
                command.ExecuteNonQuery();
            }
        }
        private static void UpdateFieldsCalcul(SqlConnection connection, string tableName, string code_215,
                    string code_211, string note, string unit, decimal coefficient, decimal quantity, decimal bruto, decimal neto)
        {
            string query = $"UPDATE {tableName} SET Note = @Note, Unit = @Unit, " +
                $"Coefficient = @Coefficient, Quantity = @quantity, Bruto = @Bruto," +
                $" Neto = @Neto WHERE Code_215 = @Code_215 AND Code_211 = @Code_211 ";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Code_215", code_215);
                command.Parameters.AddWithValue("@Code_211", code_211);
                command.Parameters.AddWithValue("@Note", note);
                command.Parameters.AddWithValue("@Coefficient", coefficient);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Bruto", bruto);
                command.Parameters.AddWithValue("@Neto", neto);
                command.ExecuteNonQuery();
            }
        }

        private static void InsertRecordCalcul(SqlConnection connection, string tableName, string code_215,
                string code_211, string note, string unit, decimal coefficient, decimal quantity, decimal bruto, decimal neto, int restaurant)
        {
            string query = $"INSERT INTO {tableName} (Code_215,Code_211, Note, Unit, Coefficient, Quantity, Bruto, Neto, Restaurant) " +
                          $"VALUES (@Code_215, @Code_211, @Note, @Unit, @Coefficient, @Quantity, @Bruto, @Neto, @Restaurant)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Code_215", code_215);
                command.Parameters.AddWithValue("@Code_211", code_211);
                command.Parameters.AddWithValue("@Note", note);
                command.Parameters.AddWithValue("@Coefficient", coefficient);
                command.Parameters.AddWithValue("@Unit", unit);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@Bruto", bruto);
                command.Parameters.AddWithValue("@Neto", neto);
                command.Parameters.AddWithValue("@Restaurant", restaurant);
                command.ExecuteNonQuery();
            }
        }
        private static void InsertRecord215(SqlConnection connection, string tableName, string code, string arm,
                    string eng, string ger, string esp, string rus, string unit, int groupp, int semiprepared, int printer, decimal price, decimal price1,
                    decimal price2, decimal price3, decimal price4, decimal price5, int department, string inholl, string atg,string non, int restaurant)
        {
            string query = $"INSERT INTO {tableName} (Code, Armenian, English,German,Espaniol, Russian, Unit, Groupp,SemiPrepared," +
                $" Printer, Price, Price1, Price2, Price3, Price4, Price5, Department, InHoll, ATG,NonComposite,Restaurant)" +
                $" VALUES (@Code, @English, @German, @Espaniol, @Russian, @Unit, @Groupp, @Printer, @Price," +
                $" @Price1, @Price2, @Price3, @Price4, @Price5, @Department, @InHoll,@Atg,@NonComposite,  @restaurant)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Code", code);
                command.Parameters.AddWithValue("@Armenian", arm);
                command.Parameters.AddWithValue("@English", eng);
                command.Parameters.AddWithValue("@German", ger);
                command.Parameters.AddWithValue("@Espaniol", esp);
                command.Parameters.AddWithValue("@Russian", rus);
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
                command.Parameters.AddWithValue("@Atg", atg);
                command.Parameters.AddWithValue("@NonComposite", non);
                command.Parameters.AddWithValue("@restaurant", restaurant);
                command.ExecuteNonQuery();
            }
        }


    }
}

