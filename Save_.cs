using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public static class Save_
    {
        public static void Save(DataTable DataTable, string SqlTable, int Rest)
        {
            int id = 0;
            DataTable Tp = new DataTable();
            DataTable Tpp = new DataTable();
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            foreach (DataRow row in DataTable.Rows)
            {
                if (int.Parse(row["Changed"].ToString()) == 0) continue;
                id = int.Parse(row["Id"].ToString());
                if (int.Parse(row["Dele"].ToString()) == 1)
                {
                  string dele = $"DELETE  FROM {SqlTable} WHERE Id={id} AND Restaurant='{Rest}' ";
                  Tp = dbHelper.ExecuteQuery(dele);
                  continue;
                }
                string query = $"SELECT * FROM {SqlTable} WHERE Id={id} AND Restaurant='{Rest}' ";
                Tpp = dbHelper.ExecuteQuery(query);
                if (Tpp.Rows.Count > 0)
                {
                    foreach (DataColumn column in DataTable.Columns)
                    {
                        string columnName = column.ColumnName;

                        if (columnName == "Id" || columnName == "Changed" || columnName == "Dele") continue;

                        string UpdateQuery = $"UPDATE {SqlTable} SET {columnName} = @Name  WHERE Id = @Id";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                            {
                                command.Parameters.AddWithValue("@Name", row[columnName]);
                                command.Parameters.AddWithValue("@Id", row["Id"]);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                else
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    string InsertQuery = $"INSERT INTO {SqlTable} (Code) VALUES (@Code)";
                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Code", int.Parse(row["Code"].ToString()));
                        command.ExecuteNonQuery();
                    }
                    int maxId = FindMaxID.MaxId(connectionString, SqlTable);
                    foreach (DataColumn column in DataTable.Columns)
                    {
                        string columnName = column.ColumnName;

                        if (columnName == "Id" || columnName == "Name1" || columnName == "Name2" || columnName == "Changed") continue;

                        string UpdateQuery = $"UPDATE {SqlTable} SET {columnName} = @Name  WHERE Id = @Id";
                        using (SqlConnection connection1 = new SqlConnection(connectionString))
                        {
                            if (connection1.State != ConnectionState.Open) { connection1.Open(); }
                            using (SqlCommand command = new SqlCommand(UpdateQuery, connection1))
                            {
                                command.Parameters.AddWithValue("@Name", row[columnName]);
                                command.Parameters.AddWithValue("@Id", maxId);
                                command.ExecuteNonQuery();
                            }
                            if (connection1.State == ConnectionState.Open) { connection1.Close(); }
                        }

                    }

                    connection.Close();
                }

            }

        }

    }
}
