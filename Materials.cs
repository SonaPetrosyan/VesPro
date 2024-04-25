using System.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using ReportPrinter;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace WindowsFormsApp4
{
    public partial class Materials : Form

    {
        private int _restaurant;

        private int _editor;

        private string _language;

        private SQLDatabaseHelper dbHelper;

        private DataTable Table_211 = new DataTable();

        private DataTable Table_213 = new DataTable();

        private DataTable Languages = new DataTable();

        private DataTable Table_111 = new DataTable();

        private DataTable Table_215 = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private DataTable ControlsMaterials = new DataTable();

        private DataView dataView;
        public Materials(int restaurant, int editor, string language)
        {
            _restaurant = restaurant;
            _editor = editor;
            _language = language;

            InitializeComponent();


            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            string query1 = $"SELECT * FROM table_211 ";
            Table_211 = dbHelper.ExecuteQuery(query1);
            Table_211.Columns.Add("Name1", typeof(string));
            Table_211.Columns.Add("Name2", typeof(string));
            Table_211.Columns.Add("Changed", typeof(int));
            foreach (DataRow row1 in Table_211.Rows)
            {
                row1["Name1"] = row1[_language];
                row1["Name2"] = row1[_language];
                row1["Changed"] = 0;
            }

            string query2 = $"SELECT * FROM table_213  ";
            Table_213 = dbHelper.ExecuteQuery(query2);
            Table_213.Columns.Add("Name1", typeof(string));
            Table_213.Columns.Add("Name2", typeof(string));
            Table_213.Columns.Add("Changed", typeof(int));
            foreach (DataRow row1 in Table_213.Rows)
            {
                row1["Name1"] = row1[_language];
                row1["Name2"] = row1[_language];
                row1["Changed"] = 0;
            }

            string query3 = $"SELECT * FROM table_111  ";
            Table_111 = dbHelper.ExecuteQuery(query3);
            Table_111.Columns.Add("Name1", typeof(string));
            Table_111.Columns.Add("Name2", typeof(string));
            Table_111.Columns.Add("Changed", typeof(int));
            int id = 1;
            foreach (DataRow row1 in Table_111.Rows)
            {
                row1["Name1"] = row1[_language];
                row1["Name2"] = row1[_language];
                row1["Changed"] = 0;
                if (int.Parse(row1["id"].ToString()) > id) id = int.Parse(row1["id"].ToString());
            }

            string query4 = $"SELECT * FROM table_215  ";
            Table_215 = dbHelper.ExecuteQuery(query4);
            Table_215.Columns.Add("Name1", typeof(string));
            Table_215.Columns.Add("Name2", typeof(string));
            Table_215.Columns.Add("Changed", typeof(int));
            foreach (DataRow row1 in Table_215.Rows)
            {
                row1["Name1"] = row1[_language];
                row1["Name2"] = row1[_language];
                row1["Changed"] = 0;
            }

            dataView = new DataView(Table_211);
            dataGridView1.DataSource = dataView;


            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name1";
            dataGridView1.Columns[2].DataPropertyName = "Name2";
            dataGridView1.Columns[3].DataPropertyName = "Unit";
            dataGridView1.Columns[4].DataPropertyName = "Groupp";
            dataGridView1.Columns[5].DataPropertyName = "CostPrice";



            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if(column.Index>5)

                {
                    
                    column.Visible = false;
                }
            }


            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);
            if (_editor == 0)
            {
                AddButton.Enabled = false;
                SaveButton1.Enabled = false;
            }
            string query5 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query5);
            foreach (DataRow row in Table_Rest.Rows)
            {
               // this.Text = row["Name"].ToString();
            }

            string query6 = $"SELECT * FROM Languages";
            Languages = dbHelper.ExecuteQuery(query6);
            if (Languages.Rows.Count > 0)
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                foreach (DataRow row in Languages.Rows)
                {
                    comboBox1.Items.Add(row["Language"]);
                    comboBox2.Items.Add(row["Language"]);
                }
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                if (Languages.Rows.Count > 1) comboBox2.SelectedIndex = 1;
            }

            SetLanguage(_language);
        }

        private void SetLanguage(string lang)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            string rb = "";
            string rbt = "";
            connection.Open();
            DataTable ControlsForm1 = new DataTable();
            string query1 = $"SELECT * FROM ControlsMaterials  ";
            ControlsMaterials = dbHelper.ExecuteQuery(query1);

            foreach (Control control in this.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsMaterials.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }

            foreach (Control control in panel1.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsMaterials.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel2.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsMaterials.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                string columnName = dataGridView1.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsMaterials.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0 )
                {
                    dataGridView1.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }

            }
            connection.Close();
        }



        private void SearchBox2_TextChanged(object sender, EventArgs e)
        {
            String txt = SearchBox2.Text;
            if (dataGridView1.DataSource is DataView dataView1 && dataView1.Table == Table_211)
            {
                dataView = new DataView(Table_211);
            }
            if (dataGridView1.DataSource is DataView dataView2 && dataView2.Table == Table_213)
            {
                dataView = new DataView(Table_213);
            }
            if (dataGridView1.DataSource is DataView dataView3 && dataView3.Table == Table_111)
            {
                dataView = new DataView(Table_111);
            }
            if (dataGridView1.DataSource is DataView dataView4 && dataView4.Table == Table_215)
            {
                dataView = new DataView(Table_215);
            }
            dataView.RowFilter = $"(Name1+Name2+Code) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }



        private void SearchBox2_Enter(object sender, EventArgs e)
        {
            SearchBox2.Text = "";
        }

        private void SearchBox1_Enter(object sender, EventArgs e)
        {
            SearchBox2.Text = "";
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (SaveButton1.Visible)
            {
                SaveButton2.Visible = true; SaveButton3.Visible = true;


            }
            else
            {
                dataView = new DataView(Table_211);
                dataGridView1.DataSource = dataView;
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (SaveButton1.Visible)
            {
                SaveButton2.Visible = true; SaveButton3.Visible = true;
            }
            else
            {
                dataView = new DataView(Table_213);
                dataGridView1.DataSource = dataView;
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (SaveButton1.Visible)
            {
                SaveButton2.Visible = true; SaveButton3.Visible = true;
            }
            else
            {
                dataView = new DataView(Table_111);
                dataGridView1.DataSource = dataView;
            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (SaveButton1.Visible)
            {
                SaveButton2.Visible = true; SaveButton3.Visible = true;
            }
            else
            {
                dataView = new DataView(Table_215);
                dataGridView1.DataSource = dataView;
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {

            string connectionString = Properties.Settings.Default.CafeRestDB;
            if (dataView.Count > 0)
            {
                string maxCode = dataView.Cast<DataRowView>().Max(row => (string)row["Code"]);
                int maxcode = Convert.ToInt32(maxCode) + 1;
                maxCode = maxcode.ToString();
                if ( dataView.Table == Table_211)
                {
                    int maxId = FindMaxID.MaxId(connectionString, "Table_211") +1;
                    DataRow newRow = Table_211.NewRow();
                    Table_211.Rows.Add(newRow);
                    foreach (DataColumn column in Table_211.Columns)
                    {
                        string columnName = column.ColumnName;
                        if (Table_211.Columns[columnName].DataType == typeof(string)) newRow[columnName] = "";
                        if (Table_211.Columns[columnName].DataType == typeof(int)) newRow[columnName] = 0;
                        if (Table_211.Columns[columnName].DataType == typeof(float)) newRow[columnName] = 0;
                        if (Table_211.Columns[columnName].DataType == typeof(decimal)) newRow[columnName] = 0;
                    }
                    newRow["Id"] = maxId;
                    newRow["Code"] = maxCode;
                    newRow["Restaurant"] = _restaurant;
                    newRow["Changed"] = 1;
                    SaveButton1.Visible = true;
                }
                if (dataView.Table == Table_213)  
                {
                    int maxId = FindMaxID.MaxId(connectionString, "Table_213") + 1;
                    DataRow newRow = Table_213.NewRow();
                    Table_213.Rows.Add(newRow);
                    foreach (DataColumn column in Table_213.Columns)
                    {
                        string columnName = column.ColumnName;
                        if (Table_213.Columns[columnName].DataType == typeof(string)) newRow[columnName] = "";
                        if (Table_213.Columns[columnName].DataType == typeof(int)) newRow[columnName] = 0;
                        if (Table_213.Columns[columnName].DataType == typeof(float)) newRow[columnName] = 0;
                        if (Table_213.Columns[columnName].DataType == typeof(decimal)) newRow[columnName] = 0;
                    }
                    newRow["Id"] = maxId;
                    newRow["Code"] = maxCode;
                    newRow["Restaurant"] = _restaurant;
                    newRow["Changed"] = 1;
                    SaveButton1.Visible = true;
                }
                if (dataView.Table == Table_111)
                {
                    int maxId = FindMaxID.MaxId(connectionString, "Table_111") + 1;
                    DataRow newRow = Table_111.NewRow();
                    Table_111.Rows.Add(newRow);
                    foreach (DataColumn column in Table_111.Columns)
                    {
                        string columnName = column.ColumnName;
                        if (Table_111.Columns[columnName].DataType == typeof(string)) newRow[columnName] = "";
                        if (Table_111.Columns[columnName].DataType == typeof(int)) newRow[columnName] = 0;
                        if (Table_111.Columns[columnName].DataType == typeof(float)) newRow[columnName] = 0;
                        if (Table_111.Columns[columnName].DataType == typeof(decimal)) newRow[columnName] = 0;
                    }
                    newRow["Id"] = maxId;
                    newRow["Code"] = maxCode;
                    newRow["Restaurant"] = _restaurant;
                    newRow["Changed"] = 1;
                    SaveButton1.Visible = true;
                }
                if (dataView.Table == Table_215)
                {
                    int maxId = FindMaxID.MaxId(connectionString, "Table_215") + 1;
                    DataRow newRow = Table_215.NewRow();
                    Table_215.Rows.Add(newRow);
                    foreach (DataColumn column in Table_215.Columns)
                    {
                        string columnName = column.ColumnName;
                        if (Table_215.Columns[columnName].DataType == typeof(string)) newRow[columnName] = "";
                        if (Table_215.Columns[columnName].DataType == typeof(int)) newRow[columnName] = 0;
                        if (Table_215.Columns[columnName].DataType == typeof(float)) newRow[columnName] = 0;
                        if (Table_215.Columns[columnName].DataType == typeof(decimal)) newRow[columnName] = 0;
                    }
                    newRow["Id"] = maxId;
                    newRow["Code"] = maxCode;
                    newRow["Restaurant"] = _restaurant;
                    newRow["Changed"] = 1;
                    SaveButton1.Visible = true;
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    int lastRowIndex = dataGridView1.Rows.Count - 1;
                    for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
                    {
                        if (dataGridView1.Columns[colIndex].Visible)
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[colIndex];
                            dataGridView1.BeginEdit(true);
                            break;
                        }
                    }
                }
            }
        }



        private void SaveButton1_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            if (dataView.Table == Table_211)
            {
                Save(Table_211, "Table_211");

                // Save.UpdateTableFromDatatable(connectionString, Table_211, "211", _restaurant);
            }
            if (dataView.Table == Table_213)
            {
                Save(Table_213, "Table_213");
                // Save.UpdateTableFromDatatable(connectionString, Table_213, "213", _restaurant);
            }
            if (dataView.Table == Table_111)
            {
                Save(Table_111, "Table_111");
                //  Save.UpdateTableFromDatatable(connectionString, Table_111, "111", _restaurant);
            }
            if (dataView.Table == Table_215)
            {
                Save(Table_215, "Table_215");
                // Save.UpdateTableFromDatatable(connectionString, Table_215, "215", _restaurant);
            }
            SaveButton1.Visible = false;
        }

        private void Save(DataTable DataTable, string SqlTable)
        {
            int id = 0;
            DataTable Tp = new DataTable();
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            foreach (DataRow row in DataTable.Rows)
            {
                if (int.Parse(row["Changed"].ToString()) == 0) continue;
                id = int.Parse(row["Id"].ToString());
                this.Text=this.Text + ", " + id.ToString()+ " - " + row["Restaurant"].ToString();
                string query = $"SELECT * FROM {SqlTable} WHERE Id={id} AND Restaurant='{_restaurant}' ";
                Tp = dbHelper.ExecuteQuery(query);
                this.Text = this.Text + " * " + Tp.Rows.Count.ToString();
                 if (Tp.Rows.Count > 0)
                {
                    foreach (DataColumn column in DataTable.Columns)
                    {
                        string columnName = column.ColumnName;

                        if (columnName == "Id" || columnName == "Name1" || columnName == "Name2" || columnName == "Changed") continue;

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
                    int maxId=FindMaxID.MaxId( connectionString, SqlTable);
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
            private void SaveButton3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton1.PerformClick();
            }
            if (radioButton2.Checked)
            {
                radioButton2.PerformClick();
            }
            if (radioButton3.Checked)
            {
                radioButton3.PerformClick();
            }
            // dataGridView1.Visible=false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            SaveButton1.Visible = false;
            SaveButton2.Visible = false;
            SaveButton3.Visible = false;
        }

        private void Materials_Resize(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Width = this.ClientSize.Width - 50;
                control.Height = this.ClientSize.Height - 50;
            }
            // Adjust the size of a TextBox based on the new size of the form
            //textBox1.Width = this.ClientSize.Width - 50;
        }

        private void Materials_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }

        }

        private void Materials_ResizeEnd(object sender, EventArgs e)
        {
            float kw = 0;
            float kh = 0;
            foreach (DataRow row in Resize.Rows)
            {
                row["EndWidth"] = this.Width;
                row["EndHeight"] = this.Height;
                kw = float.Parse(row["EndWidth"].ToString()) / float.Parse(row["BeginWidth"].ToString());
                kh = float.Parse(row["EndHeight"].ToString()) / float.Parse(row["BeginHeight"].ToString());
            }
            foreach (Control control in this.Controls)
            {
                control.Left = (int)(control.Left * (double)kw);
                control.Top = (int)(control.Top * (double)kh);
                control.Width = (int)(control.Width * (double)kw);
                control.Height = (int)(control.Height * (double)kh);
            }
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = (int)(column.Width * kw);
            }
            foreach (Control control in panel2.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (DataRow row1 in Table_211.Rows)
            {
                row1["Name1"] = row1[comboBox1.SelectedItem.ToString()];
            }
            foreach (DataRow row1 in Table_213.Rows)
            {
                row1["Name1"] = row1[comboBox1.SelectedItem.ToString()];
            }
            foreach (DataRow row1 in Table_111.Rows)
            {
                row1["Name1"] = row1[comboBox1.SelectedItem.ToString()];
            }
            foreach (DataRow row1 in Table_215.Rows)
            {
                row1["Name1"] = row1[comboBox1.SelectedItem.ToString()];
            }
            //  for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            //  {
            //      if (dataGridView1.Columns[colIndex].DataPropertyName == "_language" )
            //      {
            //          dataGridView1.Columns[colIndex].DataPropertyName = comboBox1.SelectedItem.ToString();
            //          break;
            //      }
            //  }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow row1 in Table_211.Rows)
            {
                row1["Name2"] = row1[comboBox2.SelectedItem.ToString()];
            }
            foreach (DataRow row1 in Table_213.Rows)
            {
                row1["Name2"] = row1[comboBox2.SelectedItem.ToString()];
            }
            foreach (DataRow row1 in Table_111.Rows)
            {
                row1["Name2"] = row1[comboBox2.SelectedItem.ToString()];
            }
            foreach (DataRow row1 in Table_215.Rows)
            {
                row1["Name2"] = row1[comboBox2.SelectedItem.ToString()];
            }
            //for (int colIndex = 0; colIndex < dataGridView1.Columns.Count - 1; colIndex++)
            //{
            //    if (dataGridView1.Columns[colIndex].DataPropertyName == _language )
            //    {
            //        dataGridView1.Columns[colIndex+1].DataPropertyName = comboBox2.SelectedItem.ToString();
            //        break;
            //    }
            //}
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView1.Rows[e.RowIndex].Cells["Name1"].Value != null)
            {
                dataGridView1.Rows[e.RowIndex].Cells[comboBox1.SelectedItem.ToString()].Value = dataGridView1.Rows[e.RowIndex].Cells["Name1"].Value;
          
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["Name2"].Value != null)
            {
                dataGridView1.Rows[e.RowIndex].Cells[comboBox2.SelectedItem.ToString()].Value = dataGridView1.Rows[e.RowIndex].Cells["Name2"].Value;
            }
            if (e.RowIndex >= 0)
            {
                dataGridView.Rows[e.RowIndex].Cells["Changed"].Value = 1;
                SaveButton1.Visible = true;
            }
            SaveButton1.BackColor = Color.LightGreen;
            SaveButton1.Visible = true;
        }


    }
}
