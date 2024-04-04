using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.CompilerServices;


namespace WindowsFormsApp4
{
    public static class Update_composits
    {
        static SQLDatabaseHelper dbHelper;

        static DataTable Table_215 = new DataTable();

        static DataTable Table_211 = new DataTable();

        static DataTable Table_Composition = new DataTable();

        static DataTable Table_Composite = new DataTable();

        static DataTable Օpening = new DataTable();// Table_215-ի բաղադրորթյուններն են կիսապատռասորաստուկները բացված




        public static void UpdateCost(string connectionString)//Opened-ը  ֆայլն է, որում կիսաֆաբրիկատները բացված են 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            //using //(SqlConnection connection = new SqlConnection(connectionString))
            //{

            connection.Open();
            string query1 = $"SELECT * FROM table_211 ";
            Table_211 = dbHelper.ExecuteQuery(query1);

            string query2 = $"SELECT * FROM composition";
            Table_Composition = dbHelper.ExecuteQuery(query2);

            string query3 = $"TRUNCATE TABLE composite";
            Table_Composite = dbHelper.ExecuteQuery(query3);

            string query4 = $"SELECT * FROM table_215 ";
            Table_215 = dbHelper.ExecuteQuery(query4);

            DataTable Opened = new DataTable();
            DataTable Temp = new DataTable();
            DataTable Temp1 = new DataTable();
            Opened = Table_Composition.Clone();
            Temp = Table_Composition.Clone();
            Temp1 = Table_Composition.Clone();
            string code_215 = "";
            string code_211 = "";
            foreach (DataRow row in Table_Composition.Rows)
            {
                DataRow newRow = Opened.NewRow();
                Opened.Rows.Add(newRow);
                for (int colIndex = 0; colIndex < Table_Composition.Columns.Count; colIndex++)
                {
                    string columnName = Table_Composition.Columns[colIndex].ColumnName;
                    newRow[columnName] = row[columnName];
                }
            }

            Opened.Columns.Add("Deleted", typeof(string));
            ReplaceFields.Replace(Opened, "Deleted", "0");
            bool T = true;
            int count = Opened.Rows.Count;
            string code = "";
            string code1 = "";
            while (T == true)
            {
                count = Opened.Rows.Count;
                foreach (DataRow row in Opened.Rows)
                {
                    //code = row["Code_211"].ToString();
                    code1 = row["Code_211"].ToString().Substring(0, 3);
                    //if (code1.ToString() == "215" && row["Deleted"].ToString() != "1")
                    if (code1 == "215" && row["Deleted"].ToString() != "1")
                    {
                        //code = row["Deleted"].ToString();
                        row["Deleted"] = "1";
                        code_215 = row["Code_215"].ToString();
                        code_211 = row["Code_211"].ToString();
                        float quantity = float.Parse(row["Quantity"].ToString());
                        string query = $"SELECT * FROM composition WHERE Code_215= '{code_211}' ";
                        Temp = dbHelper.ExecuteQuery(query);
                        foreach (DataRow row1 in Temp.Rows)
                        {
                            row1["Code_215"] = code_215;
                            row1["Quantity"] = float.Parse(row1["Quantity"].ToString()) * quantity;
                            DataRow newRow = Temp1.NewRow();
                            Temp1.Rows.Add(newRow);
                            for (int colIndex = 0; colIndex < Temp.Columns.Count; colIndex++)
                            {
                                string columnName = Temp.Columns[colIndex].ColumnName;
                                newRow[columnName] = row1[columnName];
                            }
                        }
                    }
                }
                int co1 = Temp1.Rows.Count;
                int co0 = Opened.Rows.Count;
                foreach (DataRow row2 in Temp1.Rows)
                {
                    code_215 = row2["Code_215"].ToString();
                    code_211 = row2["Code_211"].ToString();
                    DataRow[] foundRows1 = Opened.Select($"Code_215 = '{code_215}' and Code_211 = '{code_211}' ");
                    DataRow newRow = Opened.NewRow();
                    Opened.Rows.Add(newRow);
                    for (int colIndex = 0; colIndex < Temp.Columns.Count; colIndex++)
                    {
                        string columnName = Temp.Columns[colIndex].ColumnName;
                        newRow[columnName] = row2[columnName];
                    }
                    int co2 = Opened.Rows.Count;
                }

                Temp1 = new DataTable();
                Temp1 = Table_Composition.Clone();
                co1 = Temp1.Rows.Count;
                if (Opened.Rows.Count == count)
                {
                    T = false;
                    foreach (DataRow row in Opened.Select("Deleted = '1'"))
                    {
                        row.Delete();
                    }
                    Opened.AcceptChanges();
                }
            }
            foreach (DataRow row in Opened.Rows)//տեղադրում ենք գնման գները Table_211-ից
            {
                code_211 = row["Code_211"].ToString();
                DataRow[] foundRows1 = Table_211.Select($"Code = '{code_211}' ");
                foreach (DataRow row1 in foundRows1)
                {
                    row["CostPrice"] = float.Parse(row1["CostPrice"].ToString());
                }
                string pr = row["CostPrice"].ToString();
            }
            foreach (DataRow row2 in Table_Composition.Rows)//հաշվարկում ենք Table_Composition գնման գները Opened-ից
            {
                code_215 = row2["Code_215"].ToString();
                code_211 = row2["Code_211"].ToString();
                if (code_211.Substring(0, 3) == "211")
                {
                    DataRow[] foundRows1 = Table_211.Select($"Code = '{code_211}' ");
                    foreach (DataRow row1 in foundRows1)
                    {
                        if (row2["CostPrice"] != null && row1["CostPrice"] != null) row2["CostPrice"] = float.Parse(row1["CostPrice"].ToString());
                    }
                }
                else
                {
                    DataRow[] foundRows1 = Opened.Select($"Code_215 = '{code_211}' ");
                    float sum = 0;
                    foreach (DataRow row1 in foundRows1)
                    {
                        if (row1["CostPrice"] != DBNull.Value && row1["Quantity"] != DBNull.Value)
                        {
                            float costPrice;
                            float quantity;
                            if (float.TryParse(row1["CostPrice"].ToString(), out costPrice) && float.TryParse(row1["Quantity"].ToString(), out quantity))
                            {
                                sum += costPrice * quantity;
                            }
                        }
                    }
                    row2["CostPrice"] = sum;
                }
            }
            foreach (DataRow row2 in Table_215.Rows)//հաշվարկում ենք Table_215 գնման գները Opened-ից
            {
                code_215 = row2["Code"].ToString();

                DataRow[] foundRows1 = Opened.Select($"Code_215 = '{code_215}' ");
                float sum = 0;
                foreach (DataRow row1 in foundRows1)
                {
                    if (row1["CostPrice"] != DBNull.Value && row1["Quantity"] != DBNull.Value)
                    {
                        float costPrice;
                        float quantity;
                        if (float.TryParse(row1["CostPrice"].ToString(), out costPrice) && float.TryParse(row1["Quantity"].ToString(), out quantity))
                        {
                            sum += costPrice * quantity;
                        }
                    }
                }
                row2["CostPrice"] = sum;
            }


            foreach (DataRow row in Opened.Rows)
            {

                bool codeExists = CheckIfCodeExists(connection, "composite", row["Code_215"].ToString(), row["Code_211"].ToString());
                if (codeExists)
                {
                    string UpdateQuery = $"UPDATE composite SET Quantity = '{row["Quantity"]}'+Quantity,CostPrice='{row["CostPrice"]}'" +
                        $" WHERE Code_215 = '{row["Code_215"]}' AND Code_211='{row["Code_211"]}' ";
                    using (SqlCommand insertCommand = new SqlCommand(UpdateQuery, connection))
                        insertCommand.ExecuteNonQuery();


                    string query = $"UPDATE composite SET Quantity = @Quantity+ Quantity, CostPrice = @CostPrice WHERE Code_215 = @Code_215 AND Code_211 = @Code_211"  ;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        command.Parameters.AddWithValue("@CostPrice", row["CostPrice"]);
                        command.Parameters.AddWithValue("@Code_215", row["Code_215"]);
                        command.Parameters.AddWithValue("@Code_211", row["Code_211"]);
                        command.ExecuteNonQuery();
                    }


                }
                else
                {


                    string InsertQuery = $"INSERT INTU composite (Code_215, Code_211, Coefficient, Quantity, CostPrice, Bruto, Neto) " +
                           $"VALUES (@Code_215, @Code_211, @Coefficient, @Quantity, @CostPrice, @Bruto, @Neto)";
                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))

                        

                    {
                        command.Parameters.AddWithValue("@Code_215", row["Code_215"]);
                        command.Parameters.AddWithValue("@Code_211", row["Code_211"]);
                        command.Parameters.AddWithValue("@Coefficient", row["Coefficient"]);
                        command.Parameters.AddWithValue("@CostPrice", row["CostPrice"]);
                        command.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        command.Parameters.AddWithValue("@Bruto", row["Bruto"]);
                        command.Parameters.AddWithValue("@Neto", row["Neto"]);
                        command.ExecuteNonQuery();
                    }


                }
            }

            connection.Close();
            // }

        }
        private static bool CheckIfCodeExists(SqlConnection connection, string tableName, string code_215, string code_211)
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
    }
}