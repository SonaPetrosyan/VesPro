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
using Amazon.DynamoDBv2.DocumentModel;

namespace WindowsFormsApp4
{
    public partial class Inventory : Form
    {
        private int _parameter1;
        private int _restaurant;
        private int _update;
        private int _editor;
        private string _language;
        private SQLDatabaseHelper dbHelper;

        private DataTable Table_215 = new DataTable();

        private DataTable Table_211 = new DataTable();

        private DataTable Table_213 = new DataTable();

        private DataTable Table_111 = new DataTable();

        private DataTable Table_Inventory = new DataTable();

        private DataTable Table_Inventory215 = new DataTable();

        private DataTable Table_Department = new DataTable();

        private DataTable Table_Restaurant = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable Exist = new DataTable();

        private DataTable Table_Number = new DataTable();

        private DataTable Table_LastInventory = new DataTable();

        private DataTable Table_Action = new DataTable();

        private DataTable ControlsInventory = new DataTable();

        private DataTable Table_Composite = new DataTable();
        
        private DataView dataView;
        public Inventory(int ooperator, int restaurant, int update, int editor, string language)
        {
            _parameter1 = ooperator;
            _editor = editor;
            _restaurant = restaurant;
            _update = update;
            _language = language;
            InitializeComponent();

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            dateTimePicker1.Value = DateTime.Now;
               string query = $"SELECT * FROM Department WHERE Restaurant= '{_restaurant}' ";
            Table_Department =dbHelper.ExecuteQuery(query);
               DepartmentComboBox.DataSource = Table_Department.DefaultView;
               DepartmentComboBox.Text = "";
               DepartmentComboBox.DisplayMember = "Name";

            //string query2 = $"SELECT Code,Name,Eng,Rus,Unit,CostPrice FROM table_211 WHERE Restaurant= '{_restaurant}' ";
            string query2 = $"SELECT * FROM table_211 WHERE Restaurant= '{_restaurant}' ";
            Table_211 = dbHelper.ExecuteQuery(query2);
            Table_211.Columns.Add("Name", typeof(string));

            string query3 = $"SELECT * FROM table_213 WHERE Restaurant= '{_restaurant}' ";
            Table_213 = dbHelper.ExecuteQuery(query3);
            Table_213.Columns.Add("Name", typeof(string));

            string query4 = $"SELECT * FROM table_111 WHERE Restaurant= '{_restaurant}' ";
            Table_111 = dbHelper.ExecuteQuery(query4);
            Table_111.Columns.Add("Name", typeof(string));

            //string query3 = $"SELECT Code,Name,Eng,Rus,Unit FROM table_215 WHERE Restaurant= '{_restaurant}' ";
            string query5 = $"SELECT * FROM table_215 WHERE Restaurant= '{_restaurant}' ";
            Table_215 = dbHelper.ExecuteQuery(query5);
            Table_215.Columns.Add("Name", typeof(string));

            // if (_update == 1) // թարմացնում ենք են գույքագրումների աղյուսակները
            //  {
                //UpdateInventory_211();
                //UpdateInventory_213();
                //UpdateInventory_111();
            //  }
            string query6 = $"SELECT * FROM Inventory WHERE Restaurant='{_restaurant}'";
            Table_Inventory = dbHelper.ExecuteQuery(query6);
            Table_Inventory.Columns.Add("Name", typeof(string));

            var query7 = from row1 in Table_211.AsEnumerable()
                        join row2 in Table_Inventory.AsEnumerable()
                        on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                        from subRow2 in gj.DefaultIfEmpty()
                        select new
                        {
                            Row1 = row1,
                            Row2 = subRow2
                        };

            foreach (var item in query7)
            {
                if (item.Row1 != null && item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1[_language];
                }
            }

            var query8 = from row1 in Table_213.AsEnumerable()
                         join row2 in Table_Inventory.AsEnumerable()
                         on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                         from subRow2 in gj.DefaultIfEmpty()
                         select new
                         {
                             Row1 = row1,
                             Row2 = subRow2
                         };

            foreach (var item in query8)
            {
                if (item.Row1 != null && item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1[_language];
                }
            }
            var query9 = from row1 in Table_111.AsEnumerable()
                         join row2 in Table_Inventory.AsEnumerable()
                         on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                         from subRow2 in gj.DefaultIfEmpty()
                         select new
                         {
                             Row1 = row1,
                             Row2 = subRow2
                         };

            foreach (var item in query9)
            {
                if (item.Row1 != null && item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1[_language];
                }
            }

            string query10 = $"SELECT * FROM Inventory_215 WHERE Restaurant='{_restaurant}'";
            Table_Inventory215 = dbHelper.ExecuteQuery(query10);
            Table_Inventory215.Columns.Add("Name", typeof(string));
            var query11 = from row1 in Table_215.AsEnumerable()
                         join row2 in Table_Inventory215.AsEnumerable()
                         on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                         from subRow2 in gj.DefaultIfEmpty()
                         select new
                         {
                             Row1 = row1,
                             Row2 = subRow2
                         };

            foreach (var item in query11)
            {
                if (item.Row1 != null && item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1[_language];
                }
            }


            dataView = new DataView(Table_Inventory);
            dataView.RowFilter = $"(Groupp) LIKE '%{2111}%'";
            dataGridView1.DataSource = dataView;


            Table_Inventory.Columns.Add("Calcul", typeof(float));
            Table_Inventory.Columns.Add("Over", typeof(float));
            Table_Inventory.Columns.Add("Lack", typeof(float));

            foreach (DataRow row in Table_Inventory.Rows)
            {
                row["Calcul"] = 0;
                row["Over"] = Math.Max(0, (float.Parse(row["Actually1"].ToString()) + float.Parse(row["Act215_1"].ToString()) - float.Parse(row["Calcul"].ToString())));
                row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually1"].ToString()) - float.Parse(row["Act215_1"].ToString())));
            }

            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name";
            dataGridView1.Columns[2].DataPropertyName = "Unit";
            dataGridView1.Columns[3].DataPropertyName = "CostPrice";
            dataGridView1.Columns[4].DataPropertyName = "Actually1";
            dataGridView1.Columns[5].DataPropertyName = "act215_1";
            dataGridView1.Columns[6].DataPropertyName = "Calcul";
            dataGridView1.Columns[7].DataPropertyName = "Over";
            dataGridView1.Columns[8].DataPropertyName = "Lack";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 8)
                {
                    column.Visible = false;
                }

            }

            //string query13 = $"SELECT Code,Unit,Act215_1,Act215_2,Act215_3,Act215_4,Act215_5 FROM inventory_215 WHERE Restaurant='{_restaurant}' ";
            //Table_Inventory215 = dbHelper.ExecuteQuery(query13);
            //Table_Inventory215.Columns.Add("Name", typeof(string));
            int co = Table_Inventory215.Rows.Count;
            dataView = new DataView(Table_Inventory215);
            dataGridView2.DataSource = dataView;
            dataGridView2.Columns[0].DataPropertyName = "Code";
            dataGridView2.Columns[1].DataPropertyName = "Name";
            dataGridView2.Columns[2].DataPropertyName = "Unit";
            dataGridView2.Columns[3].DataPropertyName = "Act215_1";
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }
            dataGridView2.Visible = false;
            if (radioButton1.Checked) dataGridView2.Visible = true;
            if (_editor == 0)//խմբագրելն արգելված է
            {
                dataGridView1.Enabled = false;
                dataGridView2.Enabled = false;
                button2.Enabled = false;
                button4.Enabled = false;
                execute.Enabled = false;
            }
            //************************** ֆորմայի սկզբնական չափերն են 
            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);
            //*****************************
            string SelectQuery = "SELECT * FROM actions WHERE Note='INVENTORY' ";//վերջին գույքագրման ամսաթվի համար է
            Table_LastInventory = dbHelper.ExecuteQuery(SelectQuery);
            int co1 = Table_LastInventory.Rows.Count;


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
            string query1 = $"SELECT * FROM ControlsInventory  ";
            ControlsInventory = dbHelper.ExecuteQuery(query1);
            foreach (Control control in panel1.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsInventory.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel2.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsInventory.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel3.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsInventory.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel4.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsInventory.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel5.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsInventory.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel6.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsInventory.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel8.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsInventory.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                string columnName = dataGridView1.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsInventory.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0 && columnName.IndexOf("215")<0)
                {
                    dataGridView1.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }

            }

            for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
            {
                string columnName = dataGridView2.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsInventory.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView2.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }
            }
            connection.Close();
        }


        private void UpdateInventory_211() // գույքագրման աղյուսակը ճշգրտում ենք։
                                           // Եթե նյութի կոդ է պակաս ավելացնում ենք։
                                           //ինքնարժեքներն  ենք նորացնում
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            string gr = "2111";
            foreach (DataRow row in Table_211.Rows)
            {
                string query = $"SELECT * FROM inventory WHERE Code = '{row["Code"]}' AND Restaurant = '{_restaurant}'  ";
                Exist = dbHelper.ExecuteQuery(query);
                int count = Exist.Rows.Count;
                if (count > 0)
                {

                    string InsertQuery = $"UPDATE inventory SET Unit=@Unit, CostPrice=@CostPrice, groupp=@groupp  WHERE Code=@Code AND Restaurant=@Restaurant";

                    using (SqlCommand updateCommand = new SqlCommand(InsertQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@Unit", row["Unit"].ToString());
                        updateCommand.Parameters.AddWithValue("@CostPrice", float.Parse(row["CostPrice"].ToString()));
                        updateCommand.Parameters.AddWithValue("@groupp", "2111");
                        updateCommand.Parameters.AddWithValue("@Code", row["Code"].ToString());
                        updateCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        updateCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    string InsertQuery = $"INSERT INTO inventory (Code, Unit, CostPrice, Restaurant, groupp," +
                        $"Actually1,Actually2,Actually3,Actually4,Actually5,Act215_1,Act215_2,Act215_3,Act215_4,Act215_5)" +
                        $" VALUES (@Code, @Unit, @CostPrice ,@Restaurant, @groupp," +
                        $"@Actually1,@Actually2,@Actually3,@Actually4,@Actually5,@Act215_1,@Act215_2,@Act215_3,@Act215_4,@Act215_5)";
                    using (SqlCommand insertCommand = new SqlCommand(InsertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Unit", row["Unit"].ToString());
                        insertCommand.Parameters.AddWithValue("@CostPrice", float.Parse(row["CostPrice"].ToString()));
                        insertCommand.Parameters.AddWithValue("@Code", row["Code"].ToString());
                        insertCommand.Parameters.AddWithValue("@groupp", "2111");
                        insertCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        insertCommand.Parameters.AddWithValue("@Actually1", 0);
                        insertCommand.Parameters.AddWithValue("@Actually2", 0);
                        insertCommand.Parameters.AddWithValue("@Actually3", 0);
                        insertCommand.Parameters.AddWithValue("@Actually4", 0);
                        insertCommand.Parameters.AddWithValue("@Actually5", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_1", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_2", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_3", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_4", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_5", 0);
                        insertCommand.ExecuteNonQuery();
                    }

                }
            }
            foreach (DataRow row in Table_215.Rows)
            {
                string query = $"SELECT * FROM inventory_215 WHERE Code = '{row["Code"]}' AND Restaurant = '{_restaurant}' ";
                Exist = dbHelper.ExecuteQuery(query);
                int count = Exist.Rows.Count;
                if (count == 0)
                {
                    string InsertQuery = $"INSERT INTO inventory_215 (Code,Unit,Restaurant) " +
                        $"VALUES (@Code,@Unit,@Restaurant)";
                    using (SqlCommand insertCommand = new SqlCommand(InsertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Code", row["Code"].ToString());
                        insertCommand.Parameters.AddWithValue("@Unit", row["Unit"].ToString());
                        insertCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            connection.Close();
        }

        private void UpdateInventory_213() // գույքագրման աղյուսակը ճշգրտում ենք։
                                           // Եթե տնտեսականի կոդ է պակաս ավելացնում ենք։
                                           //ինքնարժեքներն ենք նորացնում
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            string query2 = $"SELECT Code,Unit,CostPrice FROM table_213 WHERE Restaurant= '{_restaurant}' ";
            Table_213 = dbHelper.ExecuteQuery(query2);
            connection.Open();
            string gr = "2131";
            this.Text = Table_213.Rows.Count.ToString();
            foreach (DataRow row in Table_213.Rows)
            {
                string query = $"SELECT * FROM inventory WHERE Code = '{row["Code"]}' AND Restaurant = '{_restaurant}' AND Groupp = '{gr}' ";
                Exist = dbHelper.ExecuteQuery(query);
                int count = Exist.Rows.Count;
                if (count > 0)
                {

                    string InsertQuery = $"UPDATE Inventory SET Unit=@Unit, CostPrice=@CostPrice, groupp=@groupp  WHERE Code=@Code AND Restaurant=@Restaurant";

                    using (SqlCommand updateCommand = new SqlCommand(InsertQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@Unit", row["Unit"].ToString());
                        updateCommand.Parameters.AddWithValue("@CostPrice", float.Parse(row["CostPrice"].ToString()));
                        updateCommand.Parameters.AddWithValue("@Code", row["Code"].ToString());
                        updateCommand.Parameters.AddWithValue("@groupp", "2131");
                        updateCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        updateCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    string InsertQuery = $"INSERT INTO inventory (Code, Unit, CostPrice, Restaurant, groupp," +
                        $"Actually1,Actually2,Actually3,Actually4,Actually5,Act215_1,Act215_2,Act215_3,Act215_4,Act215_5)" +
                        $" VALUES (@Code, @Unit, @CostPrice ,@Restaurant, @groupp," +
                        $"@Actually1,@Actually2,@Actually3,@Actually4,@Actually5,@Act215_1,@Act215_2,@Act215_3,@Act215_4,@Act215_5)";
                    using (SqlCommand insertCommand = new SqlCommand(InsertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Unit", row["Unit"].ToString());
                        insertCommand.Parameters.AddWithValue("@CostPrice", float.Parse(row["CostPrice"].ToString()));
                        insertCommand.Parameters.AddWithValue("@Code", row["Code"].ToString());
                        insertCommand.Parameters.AddWithValue("@groupp", "2131");
                        insertCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        insertCommand.Parameters.AddWithValue("@Actually1", 0);
                        insertCommand.Parameters.AddWithValue("@Actually2", 0);
                        insertCommand.Parameters.AddWithValue("@Actually3", 0);
                        insertCommand.Parameters.AddWithValue("@Actually4", 0);
                        insertCommand.Parameters.AddWithValue("@Actually5", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_1", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_2", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_3", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_4", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_5", 0);

                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            connection.Close();
        }
        private void UpdateInventory_111() // գույքագրման աղյուսակը ճշգրտում ենք։
                                           // Եթե հիմնականի կոդ է պակաս ավելացնում ենք։
                                           //ինքնարժեքներն ու անվանումներն ենք նորացնում
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            string query2 = $"SELECT Code,Unit,CostPrice FROM table_111 WHERE Restaurant= '{_restaurant}' ";
            Table_111 = dbHelper.ExecuteQuery(query2);
            string gr = "1111";
            foreach (DataRow row in Table_111.Rows)
            {
                string query = $"SELECT * FROM inventory WHERE Code = '{row["Code"]}' AND Restaurant = '{_restaurant}' AND Groupp='{gr}' ";
                Exist = dbHelper.ExecuteQuery(query);
                int count = Exist.Rows.Count;
                if (count > 0)
                {

                    string InsertQuery = $"UPDATE inventory SET Unit=@Unit, CostPrice=@CostPrice, groupp=@groupp  WHERE Code=@Code AND Restaurant=@Restaurant";

                    using (SqlCommand updateCommand = new SqlCommand(InsertQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@Unit", row["Unit"].ToString());
                        updateCommand.Parameters.AddWithValue("@CostPrice", float.Parse(row["CostPrice"].ToString()));
                        updateCommand.Parameters.AddWithValue("@Code", row["Code"].ToString());
                        updateCommand.Parameters.AddWithValue("@groupp", "1111");
                        updateCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        updateCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    string InsertQuery = $"INSERT INTO inventory (Code, Unit, CostPrice, Restaurant, groupp," +
                        $"Actually1,Actually2,Actually3,Actually4,Actually5,Act215_1,Act215_2,Act215_3,Act215_4,Act215_5)" +
                        $" VALUES (@Code, @Unit, @CostPrice ,@Restaurant, @groupp," +
                        $"@Actually1,@Actually2,@Actually3,@Actually4,@Actually5,@Act215_1,@Act215_2,@Act215_3,@Act215_4,@Act215_5)";
                    using (SqlCommand insertCommand = new SqlCommand(InsertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Unit", row["Unit"].ToString());
                        insertCommand.Parameters.AddWithValue("@CostPrice", float.Parse(row["CostPrice"].ToString()));
                        insertCommand.Parameters.AddWithValue("@Code", row["Code"].ToString());
                        insertCommand.Parameters.AddWithValue("@groupp", "1111");
                        insertCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        insertCommand.Parameters.AddWithValue("@Actually1", 0);
                        insertCommand.Parameters.AddWithValue("@Actually2", 0);
                        insertCommand.Parameters.AddWithValue("@Actually3", 0);
                        insertCommand.Parameters.AddWithValue("@Actually4", 0);
                        insertCommand.Parameters.AddWithValue("@Actually5", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_1", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_2", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_3", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_4", 0);
                        insertCommand.Parameters.AddWithValue("@Act215_5", 0);

                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            connection.Close();
        }

        private void LastInventory(int parameter) //վերջին գույքագրած ամսաթիվն ենք որոշում
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            execute.BackColor = Color.Snow;
            execute.Enabled = true;
            DateTime last = DateTime.Parse("01-01-1900 00:00:00");

            int department = parameter;
            string inv = "INVENTORY";
            connection.Open();
            string SelectQuery = $"SELECT Date FROM actions  WHERE Note='{inv}' AND " +
            $"(DepartmentIn='{department}' OR DepartmentOut='{department}')  ORDER BY Date";
            Table_LastInventory = dbHelper.ExecuteQuery(SelectQuery);
            LastLabel.Text = "";
            foreach (DataRow row in Table_LastInventory.Rows)
            {
                if (radioButton1.Checked && row["code"].ToString().Substring(0, 3) != "211") continue;
                if (radioButton2.Checked && row["code"].ToString().Substring(0, 3) != "213") continue;
                if (radioButton3.Checked && row["code"].ToString().Substring(0, 3) != "111") continue;
                last = DateTime.Parse(row["Date"].ToString());
                LastLabel.Text = last.ToString();//"yyyy-MM-dd HH:mm:ss");

            }
            if (dateTimePicker1.Value <= last)
            {
                execute.BackColor = Color.Orange;
                execute.Enabled = false;
            }
            connection.Close();

        }
        private void Over_Lack() // ավելցուկն ու պակասորդն ենք հաշվարկում, երբ արդեն հաշվարկային մնացորդը հաշվվարկել ենք ենք
        {
            if (DepartmentComboBox.DataSource == Table_Department.DefaultView)
            {
                DataRow[] foundRows = Table_Department.Select($"Name = '{DepartmentComboBox.Text}' ");
                DepartmentIdBox.Text = foundRows[0]["Id"].ToString();
                if (DepartmentIdBox.Text == "1")
                {
                    dataGridView1.Columns[4].DataPropertyName = "Actually1";//նյութի առկա փաստացի մնացորդի սյունակն է բաժնում
                    dataGridView1.Columns[9].DataPropertyName = "Act215_1"; //նյութի  հաշվարկած մնացորդի սյունակն է պատրաստի ճաշերի մեջ

                    dataGridView2.Columns[3].DataPropertyName = "Act215_1"; // ճաշի առկա մնացորդի սյունյակն է

                    foreach (DataRow row in Table_Inventory.Rows)
                    {
                        row["Over"] = Math.Max(0, (float.Parse(row["Actually1"].ToString()) + float.Parse(row["Act215_1"].ToString()) - float.Parse(row["Calcul"].ToString())));
                        row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually1"].ToString()) - float.Parse(row["Act215_1"].ToString())));
                    }


                }

                if (DepartmentIdBox.Text == "2")
                {
                    dataGridView1.Columns[4].DataPropertyName = "Actually2";
                    dataGridView1.Columns[9].DataPropertyName = "Act215_2";

                    dataGridView2.Columns[3].DataPropertyName = "Act215_2";

                    foreach (DataRow row in Table_Inventory.Rows)
                    {
                        row["Over"] = Math.Max(0, (float.Parse(row["Actually2"].ToString()) + float.Parse(row["Act215_2"].ToString()) - float.Parse(row["Calcul"].ToString())));
                        row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually2"].ToString()) - float.Parse(row["Act215_2"].ToString())));
                    }
                }
                if (DepartmentIdBox.Text == "3")
                {
                    dataGridView1.Columns[4].DataPropertyName = "Actually3";
                    dataGridView1.Columns[9].DataPropertyName = "Act215_3";

                    foreach (DataRow row in Table_Inventory.Rows)
                    {
                        row["Over"] = Math.Max(0, (float.Parse(row["Actually3"].ToString()) + float.Parse(row["Act215_3"].ToString()) - float.Parse(row["Calcul"].ToString())));
                        row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually3"].ToString()) - float.Parse(row["Act215_3"].ToString())));
                    }
                }
                if (DepartmentIdBox.Text == "4")
                {
                    dataGridView1.Columns[4].DataPropertyName = "Actually4";
                    dataGridView1.Columns[9].DataPropertyName = "Act215_4";

                    foreach (DataRow row in Table_Inventory.Rows)
                    {
                        row["Over"] = Math.Max(0, (float.Parse(row["Actually4"].ToString()) + float.Parse(row["Act215_4"].ToString()) - float.Parse(row["Calcul"].ToString())));
                        row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually4"].ToString()) - float.Parse(row["Act215_4"].ToString())));
                    }
                }
                if (DepartmentIdBox.Text == "5")
                {
                    dataGridView1.Columns[4].DataPropertyName = "Actually5";
                    dataGridView1.Columns[9].DataPropertyName = "Act215_5";

                    foreach (DataRow row in Table_Inventory.Rows)
                    {
                        row["Over"] = Math.Max(0, (float.Parse(row["Actually5"].ToString()) + float.Parse(row["Act215_5"].ToString()) - float.Parse(row["Calcul"].ToString())));
                        row["Lack"] = Math.Max(0, (float.Parse(row["Calcul"].ToString()) - float.Parse(row["Actually5"].ToString()) - float.Parse(row["Act215_5"].ToString())));
                    }
                }
                LastInventory(int.Parse(DepartmentIdBox.Text));
            }

        }
        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
                DataRow[] foundRows = Table_Department.Select($"Name = '{DepartmentComboBox.Text}' ");
            if (foundRows.Length == 0) { return; }
                DepartmentIdBox.Text = foundRows[0]["Id"].ToString();
                calculation();

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton1.Visible = true;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string txt = SearchBox.Text.Trim();
            dataView = new DataView(Table_Inventory);
            dataView.RowFilter = $"(Code+Name) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }

        private void SearchBox1_TextChanged(object sender, EventArgs e)
        {
            string txt = SearchBox1.Text.Trim();
            dataView = new DataView(Table_Inventory215);
            dataView.RowFilter = $"(Code+Name) LIKE '%{txt}%'";
            dataGridView2.DataSource = dataView;
        }

        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down) && dataGridView1.Columns.Count > 0 && dataGridView1.RowCount > 0)
            {
                int desiredColumnIndex = 0;
                int desiredRowIndex = 0; // Index of the first row in the filtered data
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.HeaderText == "Exist")
                    {
                        desiredColumnIndex = column.Index;
                        this.Text = "column.Index=" + column.Index.ToString() + " column.DataPropertyName " + column.DataPropertyName;
                        dataGridView1.CurrentCell = dataGridView1.Rows[desiredRowIndex].Cells[desiredColumnIndex];
                        dataGridView1.BeginEdit(true);
                    }

                }


            }
        }

        private void SearchBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down) && dataGridView2.Columns.Count > 0 && dataGridView2.RowCount > 0)
            {
                int desiredColumnIndex = 0;
                int desiredRowIndex = 0; // Index of the first row in the filtered data
                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {
                    if (column.HeaderText == "Exist")
                    {
                        desiredColumnIndex = column.Index;
                        this.Text = "column.Index=" + column.Index.ToString() + " column.DataPropertyName " + column.DataPropertyName;
                        dataGridView2.CurrentCell = dataGridView2.Rows[desiredRowIndex].Cells[desiredColumnIndex];
                        dataGridView2.BeginEdit(true);
                    }

                }


            }
        }

        private void Inventory_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }

        }

        private void Inventory_ResizeEnd(object sender, EventArgs e)//ֆորմայի չափերն է փոփոխում
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
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.Width = (int)(column.Width * kw);
            }


            foreach (Control control in panel1.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel2.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel3.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel4.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel5.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel6.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
            foreach (Control control in panel8.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (button2.Text == "Զրոյացնել բաժինը")
            {
                button2.Text = "Զրոյացնել բաժինը ?";
                button2.BackColor = Color.Yellow;
            }
            else
            {
                foreach (DataRow row in Table_Inventory215.Rows)
                {
                    if (radioButton1.Checked)
                    {
                        if (DepartmentIdBox.Text == "1") row["Act215_1"] = 0;
                        if (DepartmentIdBox.Text == "2") row["Act215_2"] = 0;
                        if (DepartmentIdBox.Text == "3") row["Act215_3"] = 0;
                        if (DepartmentIdBox.Text == "4") row["Act215_4"] = 0;
                        if (DepartmentIdBox.Text == "5") row["Act215_5"] = 0;
                    }
                }
                this.Text = "DepartmentIdBox.Text = " + DepartmentIdBox.Text;
                foreach (DataRow row in Table_Inventory.Rows)
                {
                    if (DepartmentIdBox.Text == "1")
                    {
                        row["Act215_1"] = 0; row["Actually1"] = 0;
                    }

                    if (DepartmentIdBox.Text == "2")
                    {
                        row["Act215_2"] = 0; row["Actually2"] = 0;
                    }

                    if (DepartmentIdBox.Text == "3")
                    {
                        row["Act215_3"] = 0; row["Actually3"] = 0;
                    }

                    if (DepartmentIdBox.Text == "4")
                    {
                        row["Act215_4"] = 0; row["Actually4"] = 0;
                    }

                    if (DepartmentIdBox.Text == "5")
                    {
                        row["Act215_5"] = 0; row["Actually5"] = 0;
                    }

                }
                button2.Text = "Զրոյացնել բաժինը";
                button2.BackColor = Color.White;
                Savebutton1.Visible = true;
            }
        }


        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton1.Visible = true;
        }

        private void Savebutton1_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            connection.Open();
            foreach (DataRow row in Table_Inventory.Rows)
            {
                string UpdateQuery = $"UPDATE inventory SET  Actually1= '{row["Actually1"]}',Actually2= '{row["Actually2"]}'," +
                    $" Actually3= '{row["Actually3"]}',Actually4= '{row["Actually4"]}',Actually5= '{row["Actually5"]}'," +
                    $" Act215_1= '{row["Act215_1"]}',Act215_2= '{row["Act215_2"]}'," +
                    $"Act215_3= '{row["Act215_3"]}',Act215_4= '{row["Act215_4"]}',Act215_5= '{row["Act215_5"]}'" +
                    $" WHERE Code = '{row["Code"]}' AND Restaurant = '{_restaurant}'";
                using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                    updatCommand.ExecuteNonQuery();

            }
            if (dataGridView2.Visible == true)
            {
                foreach (DataRow row in Table_Inventory215.Rows)
                {
                    string UpdateQuery = $"UPDATE inventory_215 SET Act215_1= '{row["Act215_1"]}',Act215_2= '{row["Act215_2"]}'," +
                        $"Act215_3= '{row["Act215_3"]}',Act215_4= '{row["Act215_4"]}',Act215_5= '{row["Act215_5"]}'" +
                        $" WHERE Code = '{row["Code"]}' AND Restaurant = '{_restaurant}'";
                    using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                        updatCommand.ExecuteNonQuery();

                }
            }
            Savebutton1.Visible = false;
            connection.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0)
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0)
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void execute_Click(object sender, EventArgs e) //ձևակերպում ենք գույքագրման արդյունքները
                                                               //ավելցուկները հանում ենք, պակասորդները՝ ավելացնում
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            connection.Open();

            string query = $"SELECT Number FROM actions WHERE Restaurant=  {_restaurant}";
            Table_Number = dbHelper.ExecuteQuery(query);
            int number = 0;
            foreach (DataRow row in Table_Number.Rows)
            {
                if (int.Parse(row["Number"].ToString()) > number)
                {
                    number = int.Parse(row["Number"].ToString());
                }
            }
            number = number + 1;

            string note = "INVENTORY";
            string debet = "";
            string kredit = "";
            int departmentin = 0;
            int departmentout = 0;
            float quantity = 0;
            float costamount = 0;
            foreach (DataRow row in Table_Inventory.Rows)
            {
                debet = "";
                kredit = "";
                departmentin = 0;
                departmentout = 0;
                float over = float.Parse(row["Over"].ToString());
                float lack = float.Parse(row["Lack"].ToString());
                if (over == 0 && lack == 0) continue;
                if (over > 0)
                {
                    debet = row["Groupp"].ToString();
                    kredit = "6311";
                    departmentin = int.Parse(DepartmentIdBox.Text);
                    quantity = over;
                    costamount = quantity * float.Parse(row["Costprice"].ToString());

                }
                if (lack > 0)
                {
                    debet = "7166";
                    kredit = row["Groupp"].ToString();
                    departmentout = int.Parse(DepartmentIdBox.Text);
                    quantity = lack;
                    costamount = quantity * float.Parse(row["Costprice"].ToString());
                }
                string InsertQuery = $"INSERT INTO actions  (Number,Code,Date,DateOfEntry,DepartmentIn," +
                    $" DepartmentOut,Debet,Kredit,Quantity,CostAmount, Operator,Note, " +
                    $"RestaurantIn,RestaurantOut, Restaurant) VALUES  (@number, @code, @date, @dateofentry, @departmentin,@departmentout," +
                    $"  @debet, @kredit, @quantity, @costamount, @operator, @note, @restaurantin, @restaurantout, @restaurant)";
                using (SqlCommand updatCommand = new SqlCommand(InsertQuery, connection))
                {
                    updatCommand.Parameters.AddWithValue("@number", number);
                    updatCommand.Parameters.AddWithValue("@code", row["Code"]);
                    updatCommand.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    updatCommand.Parameters.AddWithValue("@dateofentry", DateTime.Now);
                    updatCommand.Parameters.AddWithValue("@departmentin", departmentin);
                    updatCommand.Parameters.AddWithValue("@departmentout", departmentout);
                    updatCommand.Parameters.AddWithValue("@debet", debet);
                    updatCommand.Parameters.AddWithValue("@kredit", kredit);
                    updatCommand.Parameters.AddWithValue("@quantity", quantity);
                    updatCommand.Parameters.AddWithValue("@costamount", costamount);
                    updatCommand.Parameters.AddWithValue("@operator", _parameter1);
                    updatCommand.Parameters.AddWithValue("@note", note);
                    updatCommand.Parameters.AddWithValue("@restaurantin", 0);
                    updatCommand.Parameters.AddWithValue("@restaurantout", 0);
                    updatCommand.Parameters.AddWithValue("@restaurant", _restaurant);

                    updatCommand.ExecuteNonQuery();
                }
            }
            connection.Close();
        }


        private void calculation()
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            connection.Open();
            execute.BackColor = Color.Snow;
            execute.Enabled = true;
            string deb = "";
            string code = "";
            float quantity = 0;
            float quant = 0;
            DateTime dateTime = dateTimePicker1.Value;
            int dep = int.Parse(DepartmentIdBox.Text);
            if (radioButton1.Checked) deb = "2111";
            if (radioButton2.Checked) deb = "2131";
            if (radioButton3.Checked) deb = "1111";
            foreach (DataRow row in Table_Inventory.Rows)
            {
                if (dep == 1) row["Act215_1"] = 0;
                if (dep == 2) row["Act215_2"] = 0;
                if (dep == 3) row["Act215_3"] = 0;
                if (dep == 4) row["Act215_4"] = 0;
                if (dep == 5) row["Act215_5"] = 0;
                quantity = 0;
                code = row["Code"].ToString();// այս կոդի հե
                string query = $"SELECT Quantity,Date FROM actions WHERE Restaurant=  '{_restaurant}' AND Debet='{deb}' AND DepartmentIn='{dep}'  AND Code='{code}'";
                Table_Action = dbHelper.ExecuteQuery(query);

                foreach (DataRow row1 in Table_Action.Rows)
                {
                    DateTime dat1 = DateTime.Parse(row1["Date"].ToString());
                    if (dat1 > dateTime) continue;
                    quantity = quantity + float.Parse(row1["Quantity"].ToString());
                }
                row["Calcul"] = quantity;

                string query1 = $"SELECT Quantity,Date FROM actions WHERE Restaurant=  '{_restaurant}' AND Kredit='{deb}' AND DepartmentOut='{dep}' AND Code='{code}'";
                Table_Action = dbHelper.ExecuteQuery(query1);
                quantity = 0;
                foreach (DataRow row1 in Table_Action.Rows)
                {
                    DateTime dat1 = DateTime.Parse(row1["Date"].ToString());
                    if (dat1 > dateTime) continue;
                    quantity = quantity + float.Parse(row1["Quantity"].ToString());
                }
                row["Calcul"] = float.Parse(row["Calcul"].ToString()) - quantity;
            }

            foreach (DataRow row in Table_Inventory215.Rows)
            {
                if (dep == 1)
                {
                    if (row["Act215_1"] == DBNull.Value) continue;
                    quant = float.Parse(row["Act215_1"].ToString());
                    if (quant == 0) continue;
                }
                if (dep == 2)
                {
                    if (row["Act215_2"] == DBNull.Value) continue;
                    quant = float.Parse(row["Act215_2"].ToString());
                    if (quant == 0) continue; 
                }
                if (dep == 3)
                {
                    if (row["Act215_3"] == DBNull.Value) continue;
                    quant = float.Parse(row["Act215_3"].ToString());
                    if (quant == 0) continue;
                }
                if (dep == 4)
                {
                    if (row["Act215_4"] == DBNull.Value) continue;
                    quant = float.Parse(row["Act215_4"].ToString());
                    if (quant == 0) continue;
                }
                if (dep == 5)
                {
                    if (row["Act215_5"] == DBNull.Value) continue;
                    quant = float.Parse(row["Act215_5"].ToString());
                    if (quant == 0) continue;
                }
                string query = $"SELECT Code_215,Code_211,Quantity FROM composite WHERE Code_215=  '{row["Code"]}' ";
                Table_Composite = dbHelper.ExecuteQuery(query);
                string code215 = row["Code"].ToString();
                float quan = 0;
                foreach (DataRow row1 in Table_Composite.Rows)
                {
                    string code_211 = row1["Code_211"].ToString();
                    float q = float.Parse(row1["Quantity"].ToString());
                    quan = quant * q;
                    DataRow[] foundRows = Table_Inventory.Select($"Code = '{row1["Code_211"]}' ");
                    string code211 = row1["Code_211"].ToString();
                    if (dep == 1) foundRows[0]["Act215_1"] = Math.Round(float.Parse(foundRows[0]["Act215_1"].ToString()) + quan, 5);
                    if (dep == 2) foundRows[0]["Act215_2"] = Math.Round(float.Parse(foundRows[0]["Act215_2"].ToString()) + quan, 5);
                    if (dep == 3) foundRows[0]["Act215_3"] = Math.Round(float.Parse(foundRows[0]["Act215_3"].ToString()) + quan, 5);
                    if (dep == 4) foundRows[0]["Act215_4"] = Math.Round(float.Parse(foundRows[0]["Act215_4"].ToString()) + quan, 5);
                    if (dep == 5) foundRows[0]["Act215_5"] = Math.Round(float.Parse(foundRows[0]["Act215_5"].ToString()) + quan, 5);
                }

            }
            Over_Lack();
            LastInventory(int.Parse(DepartmentIdBox.Text));
            connection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            calculation();
            LastInventory(int.Parse(DepartmentIdBox.Text));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            execute.Enabled = true;
            execute.BackColor = Color.White;
            DateTime last = DateTime.Parse(LastLabel.Text.Trim());
            if (last >= dateTimePicker1.Value)
            {
                execute.Enabled = false;
                execute.BackColor = Color.Orange;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (button4.BackColor == Color.Snow)
            {
                button4.Text = "Ջնջել ?";
                button4.BackColor = Color.Yellow;
            }
            else
            {
                int dep = int.Parse(DepartmentIdBox.Text);
                connection.Open();
                string query = "SELECT COLUMN_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'kafe_arm' AND TABLE_NAME = 'actions' AND COLUMN_NAME = 'Date'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    string columnType = (string)command.ExecuteScalar();

                    string dateFormat = "yyyy-MM-dd HH:mm:ss";

                    DateTime myDate = DateTime.ParseExact(LastLabel.Text, dateFormat, CultureInfo.InvariantCulture);

                    // Format myDate to match the datetime format expected by Sql
                    string formattedDate = myDate.ToString(dateFormat);

                    string DeleteQuery = $"DELETE FROM actions WHERE Date = '{formattedDate}' AND  Note = 'INVENTORY' AND (DepartmentIn='{dep}' OR DepartmentOut='{dep}')";
                    using (SqlCommand deleteCommand = new SqlCommand(DeleteQuery, connection))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }
                }
                connection.Close();
                button4.Text = "Ջնջել";
                button4.BackColor = Color.Snow;
            }
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            dataView = new DataView(Table_Inventory);
            dataView.RowFilter = $"(Groupp) LIKE '%{2131}%'";
            dataGridView1.DataSource = dataView;
            dataGridView2.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_Inventory);
            dataView.RowFilter = $"(Groupp) LIKE '%{1111}%'";
            dataGridView1.DataSource = dataView;
            dataGridView2.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_Inventory);
            dataView.RowFilter = $"(Groupp) LIKE '%{2111}%'";
            dataGridView1.DataSource = dataView;
            dataGridView2.Visible=true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            string query5 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}' ";
            Table_Restaurant = dbHelper.ExecuteQuery(query5);
            string restname = "";
            DataRow[] foundRows = Table_Restaurant.Select($"Id = '{_restaurant}' ");
            if (foundRows != null && foundRows.Length > 0) restname = foundRows[0]["Name"].ToString();

            dataView = new DataView(Table_Inventory);
            dataGridView1.DataSource = dataView;
            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name";
            dataGridView1.Columns[2].DataPropertyName = "Unit";
            dataGridView1.Columns[3].DataPropertyName = "CostPrice";
            dataGridView1.Columns[4].DataPropertyName = "Actually1";
            dataGridView1.Columns[5].DataPropertyName = "Act215_1";
            dataGridView1.Columns[6].DataPropertyName = "Calcul";
            dataGridView1.Columns[7].DataPropertyName = "Over";
            dataGridView1.Columns[8].DataPropertyName = "Lack";


            DataTable InventoryReport = new DataTable();
            InventoryReport.Columns.Add("Code", typeof(string));
            InventoryReport.Columns.Add("Name1", typeof(string));
            InventoryReport.Columns.Add("Unit", typeof(string));
            InventoryReport.Columns.Add("CostPrice", typeof(decimal));
            InventoryReport.Columns.Add("Actually", typeof(decimal));
            InventoryReport.Columns.Add("Act215", typeof(decimal));
            InventoryReport.Columns.Add("Calcul", typeof(decimal));
            InventoryReport.Columns.Add("Over", typeof(decimal));
            InventoryReport.Columns.Add("Lack", typeof(decimal));
            Decimal actually = 0;
            Decimal act215 = 0;
            decimal sumover = 0;
            decimal sumlack = 0;
            foreach (DataRow row in Table_Inventory.Rows)
            {
                if (int.Parse(DepartmentIdBox.Text) == 1)
                {
                    actually = decimal.Parse(row["Actually1"].ToString());
                    act215 = decimal.Parse(row["Act215_1"].ToString());
                }
                if (int.Parse(DepartmentIdBox.Text) == 2)
                {
                    actually = decimal.Parse(row["Actually2"].ToString());
                    act215 = decimal.Parse(row["Act215_2"].ToString());
                }
                if (int.Parse(DepartmentIdBox.Text) == 3)
                {
                    actually = decimal.Parse(row["Actually3"].ToString());
                    act215 = decimal.Parse(row["Act215_3"].ToString());
                }
                if (int.Parse(DepartmentIdBox.Text) == 4)
                {
                    actually = decimal.Parse(row["Actually4"].ToString());
                    act215 = decimal.Parse(row["Act215_4"].ToString());
                }
                if (int.Parse(DepartmentIdBox.Text) == 5)
                {
                    actually = decimal.Parse(row["Actually5"].ToString());
                    act215 = decimal.Parse(row["Act215_5"].ToString());
                }

                if (actually == 0 && act215 == 0 && decimal.Parse(row["Calcul"].ToString()) == 0) continue;

                DataRow newRow = InventoryReport.NewRow();
                InventoryReport.Rows.Add(newRow);
                newRow["Code"] = row["Code"];
                newRow["Name1"] = row["Name"];
                newRow["Unit"] = row["Unit"];
                newRow["CostPrice"] = decimal.Parse(row["CostPrice"].ToString());
                newRow["Actually"] = actually;
                newRow["Act215"] = act215;
                newRow["Calcul"] = decimal.Parse(row["Calcul"].ToString());
                newRow["Over"] = decimal.Parse(row["Over"].ToString());
                newRow["Lack"] = decimal.Parse(row["Lack"].ToString());
                sumover=sumover + decimal.Parse(row["Over"].ToString()) * decimal.Parse(row["CostPrice"].ToString());
                sumlack = sumlack + decimal.Parse(row["Lack"].ToString()) * decimal.Parse(row["CostPrice"].ToString());
            }
            DataRow newRow1 = InventoryReport.NewRow();
            InventoryReport.Rows.Add(newRow1);
            DataRow newRow2 = InventoryReport.NewRow();
            InventoryReport.Rows.Add(newRow2);
            newRow2["Over"] = Math.Round(sumover,0);
            newRow2["Lack"] = Math.Round(sumlack,0);


            string reportname = "";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            if (radioButton1.Checked) reportname = "Նյութեր";
            if (radioButton2.Checked) reportname = "Տնտեսական";
            if (radioButton3.Checked) reportname = "Հիմնական";
            parameters.Add("RestaurantName", restname);
            parameters.Add("time1", dateTimePicker1.Value);
            parameters.Add("ReportName", reportname);
            parameters.Add("department", DepartmentComboBox.Text);
            parameters.Add("Lastinventory", "վերջին գրանցած "+LastLabel.Text);


            string Report = FindFolder.Folder("Report")+ "\\InventoryReport.rdlc";

            ReportManager reportManager = new ReportManager();
             reportManager.PreviewReport("BillReport", Report, InventoryReport, parameters, null);
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string help = FindFolder.Folder("Help");
            string filePath = "";
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";
                richTextBox1.Height = this.Height - 50;
                richTextBox1.ReadOnly = true;
                filePath = help + "\\Inventory_" + _language+".txt";
                string fileContent = File.ReadAllText(filePath);
                richTextBox1.Text = fileContent;
                richTextBox1.Visible = true;
                richTextBox1.Top = 0;
                richTextBox1.Left = HelpButton.Width + 5;
                richTextBox1.Width = Savebutton1.Left;
                richTextBox1.Height=this.Height - 50;

            }
            else
            {
                richTextBox1.Visible = false;
                HelpButton.Text = "?";
            }
        }
    }
}

