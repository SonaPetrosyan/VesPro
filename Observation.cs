﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;



namespace WindowsFormsApp4
{
    public partial class Observation : Form
    {
        private int _restaurant;

        private int _editor;

        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private DataTable Actions = new DataTable();

        private DataTable Actions_215 = new DataTable();

        private DataTable Table_215 = new DataTable();

        private DataTable Table_211 = new DataTable();

        private DataTable Table_213 = new DataTable();

        private DataTable Table_Department = new DataTable();

        private DataTable Table_Department_ = new DataTable();

        private DataTable Table_111 = new DataTable();


        private DataTable TicketsOrdered = new DataTable();

        private DataView dataView;

        public Observation(int restaurant, int editor)
        {
            _restaurant = restaurant;
            _editor = editor;

            InitializeComponent();



            Loadd();

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            if (_editor == 0)
            {
                button2.Enabled=false;
            }
        }
        private void Loadd()
        {


            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            string query0 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query0);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = row["Name_1"].ToString();
            }

            string query1 = $"SELECT Code,Name_1 FROM Table_211  WHERE Restaurant='{_restaurant}'";
            Table_211 = dbHelper.ExecuteQuery(query1);

            string query2 = $"SELECT Code,Name_1 FROM Table_213  WHERE Restaurant='{_restaurant}'";
            Table_213 = dbHelper.ExecuteQuery(query1);

            string query3 = $"SELECT Code,Name_1 FROM Table_111  WHERE Restaurant='{_restaurant}'";
            Table_111 = dbHelper.ExecuteQuery(query3);

            string query4 = $"SELECT Code,Name_1 FROM Table_215  WHERE Restaurant='{_restaurant}'";
            Table_215 = dbHelper.ExecuteQuery(query4);

            string query5 = $"SELECT DateOfEntry,Seans,Ticket,Nest,Code,Quantity,Costamount,Salesamount,Service,Discount,Operator FROM Actions_215  WHERE Restaurant='{_restaurant}' AND Previous='{0}' ";
            Actions_215 = dbHelper.ExecuteQuery(query5);
            Actions_215.Columns.Add("Name", typeof(string));
            Actions_215.Columns.Add("Changed", typeof(decimal));
            Actions_215.Columns.Add("Dele", typeof(decimal));
            //**********************//Տեղադրում ենք անվանումները 
            var query6 = from row1 in Table_215.AsEnumerable()
                         join row2 in Actions_215.AsEnumerable()
                         on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                         from subRow2 in gj.DefaultIfEmpty()
                         select new
                         {
                             Row1 = row1,
                             Row2 = subRow2
                         };

            foreach (var item in query6)
            {
                if (item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1["Name_1"];
                }
            }
            //**********************************

            foreach (DataRow row in Actions_215.Rows)
            {
                row["Changed"] = 0;
                row["Dele"] = 0;
            }


            dataGridView1.DataSource = Actions_215;
            dataView = new DataView(Actions_215);
            dataGridView1.Columns[0].DataPropertyName = "DateOfEntry";
            dataGridView1.Columns[1].DataPropertyName = "Seans";
            dataGridView1.Columns[2].DataPropertyName = "Ticket";
            dataGridView1.Columns[3].DataPropertyName = "Nest";
            dataGridView1.Columns[4].DataPropertyName = "Code";
            dataGridView1.Columns[5].DataPropertyName = "Name";
            dataGridView1.Columns[6].DataPropertyName = "Quantity";
            dataGridView1.Columns[7].DataPropertyName = "Costamount";
            dataGridView1.Columns[8].DataPropertyName = "Salesamount";
            dataGridView1.Columns[9].DataPropertyName = "Service";
            dataGridView1.Columns[10].DataPropertyName = "Discount";
            dataGridView1.Columns[11].DataPropertyName = "Operator";
            dataGridView1.Columns[12].DataPropertyName = "Dele";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index > 12)
                {
                    column.Visible = false;
                }
            }

            string query7 = $"SELECT Date,Number,Code,Quantity,Costamount,Salesamount,DepartmentIn,DepartmentOut, Debitor, Kreditor,Code_215, Note,Debet,Kredit  FROM Actions  WHERE Restaurant='{_restaurant}'";
            Actions = dbHelper.ExecuteQuery(query7);
            Actions.Columns.Add("Name", typeof(string));
            Actions.Columns.Add("Changed", typeof(decimal));
            Actions.Columns.Add("Dele", typeof(decimal));
            foreach (DataRow row in Actions.Rows)
            {
                row["Changed"] = 0;
                row["Dele"] = 0;
            }

            //****************************************************************** Տեղադրում ենք անվանումները 
            var query8 = from row1 in Table_211.AsEnumerable()
                         join row2 in Actions.AsEnumerable()
                         on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                         from subRow2 in gj.DefaultIfEmpty()
                         select new
                         {
                             Row1 = row1,
                             Row2 = subRow2
                         };

            foreach (var item in query8)
            {
                if (item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1["Name_1"];
                }
            }
            //******
            var query9 = from row1 in Table_213.AsEnumerable()
                         join row2 in Actions.AsEnumerable()
                         on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                         from subRow2 in gj.DefaultIfEmpty()
                         select new
                         {
                             Row1 = row1,
                             Row2 = subRow2
                         };

            foreach (var item in query9)
            {
                if (item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1["Name_1"];
                }
            }
            //******
            var query10 = from row1 in Table_111.AsEnumerable()
                          join row2 in Actions.AsEnumerable()
                          on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                          from subRow2 in gj.DefaultIfEmpty()
                          select new
                          {
                              Row1 = row1,
                              Row2 = subRow2
                          };

            foreach (var item in query10)
            {
                if (item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1["Name_1"];
                }
            }
            //*************************************************************************


            // Date,Number,Code,Quantity,Costamount,Salesamount,DepartmentIn,DepartmentOut, Debitor, Kreditor,Code_215, Note
            dataGridView2.DataSource = Actions;
            dataView = new DataView(Actions);
            dataGridView2.Columns[0].DataPropertyName = "Date";
            dataGridView2.Columns[1].DataPropertyName = "Number";
            dataGridView2.Columns[2].DataPropertyName = "Code";
            dataGridView2.Columns[3].DataPropertyName = "Name";
            dataGridView2.Columns[4].DataPropertyName = "Quantity";
            dataGridView2.Columns[5].DataPropertyName = "Costamount";
            dataGridView2.Columns[6].DataPropertyName = "Salesamount";
            dataGridView2.Columns[7].DataPropertyName = "DepartmentIn";
            dataGridView2.Columns[8].DataPropertyName = "DepartmentOut";
            dataGridView2.Columns[9].DataPropertyName = "Debitor";
            dataGridView2.Columns[10].DataPropertyName = "Kreditor";
            dataGridView2.Columns[11].DataPropertyName = "Code_215";
            dataGridView2.Columns[12].DataPropertyName = "Note";
            dataGridView2.Columns[13].DataPropertyName = "Dele";
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {

                if (column.Index > 13)
                {
                    column.Visible = false;
                }
            }


            string query11 = $"SELECT DateBegin,Seans,Ticket,Nest,Costamount,Salesamount," +
    $"Delivery,Music,Service,Discount,Tipmoney,Person,cashless,Nestgroup,Holl,Payd FROM TicketsOrdered  WHERE Previous='{0}' ";

            string query12 = $"SELECT * FROM department  where Restaurant='{_restaurant}' ";
            Table_Department = dbHelper.ExecuteQuery(query12);
            DataRow newRow = Table_Department.NewRow();
            Table_Department.Rows.Add(newRow);
            newRow["Name_1"] = "";
            newRow["Id"] = 0;
            comboBox1.DataSource = Table_Department.DefaultView;
            comboBox1.DisplayMember = "Name_1";
            comboBox1.Text = "";

            string query13 = $"SELECT * FROM department  where Restaurant='{_restaurant}' ";
            Table_Department_ = dbHelper.ExecuteQuery(query13);
            DataRow newRow1 = Table_Department_.NewRow();
            Table_Department_.Rows.Add(newRow1);
            newRow1["Id"] = 0;
            comboBox2.DataSource = Table_Department_.DefaultView;
            comboBox2.DisplayMember = "Name_1";
            comboBox2.Text = "";
        }

        private void Observation_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void Observation_ResizeEnd(object sender, EventArgs e)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string note = "";
            if (radioButton1.Checked)
            {
                string filterExpression = $"DateOfEntry >= #{dateTimePicker1.Value}# AND DateOfEntry <= #{dateTimePicker2.Value}#";
                if (textBox1.Text.Length > 0)
                {
                    decimal seans = decimal.Parse(textBox1.Text);
                    filterExpression = filterExpression + $" AND Seans= '{seans}' ";
                }
                if (textBox2.Text.Length > 0)
                {
                    decimal ticket = decimal.Parse(textBox2.Text);
                    filterExpression = filterExpression + $" AND Ticket= '{ticket}' ";
                }
                if (textBox3.Text.Length > 0)
                {
                    string nest = textBox2.Text;
                    filterExpression = filterExpression + $" AND Nest= '{nest}' ";
                }

                if (filterExpression != null)
                {
                    float quantity = 0;
                    float costamount = 0;
                    float salesamount = 0;
                    float service= 0;
                    float discount = 0;
                    DataRow[] filteredRows = Actions_215.Select(filterExpression);
                    DataTable filteredTable = Actions_215.Clone(); // Cloning the structure of table1
                    foreach (DataRow row in filteredRows)
                    {
                        quantity = quantity + float.Parse(row["Quantity"].ToString());
                        costamount = costamount + float.Parse(row["costamount"].ToString());
                        salesamount = salesamount + float.Parse(row["salesamount"].ToString());
                        service = service + float.Parse(row["service"].ToString());
                        discount = discount + float.Parse(row["discount"].ToString());

                        filteredTable.ImportRow(row);
                    }
                    DataRow newRow1 = filteredTable.NewRow();
                    filteredTable.Rows.Add(newRow1);
                    DataRow newRow2 = filteredTable.NewRow();
                    filteredTable.Rows.Add(newRow2);
                    newRow2["Quantity"] = quantity;
                    newRow2["costamount"] = costamount;
                    newRow2["salesamount"] = salesamount;
                    newRow2["service"] = service;
                    newRow2["discount"] = discount;
                    // Set the DataSource of DataGridView to the filtered table
                    dataGridView1.DataSource = filteredTable;
                    dataGridView1.Visible = true;

                    dataGridView1.Top = button2.Top + button2.Height + 5;
                    dataGridView1.Height = this.Height - dataGridView1.Top - 50;
                    button3.Visible = true;
                }

            }
            if (!radioButton1.Checked)
            {
                string filterExpression = $"Date >= #{dateTimePicker1.Value}# AND Date <= #{dateTimePicker2.Value}#";
                if (textBox5.Text.Length > 0 && !radioButton12.Checked)
                {
                    string code = textBox5.Text;
                    filterExpression = filterExpression + $" AND Code='{code}' ";
                }
                if (radioButton9.Checked)
                {
                    note= "purchased";
                    filterExpression = filterExpression + $" AND Note= '{note}' ";
                }
                if (radioButton5.Checked)
                {
                    note = "moved";
                    filterExpression = filterExpression + $" AND Note= '{note}' ";
                }
                if (radioButton3.Checked)
                {
                    note = "sold";
                    filterExpression = filterExpression + $" AND Note= '{note}' ";
                }
                if (radioButton4.Checked)
                {
                    note = "spent";
                    filterExpression = filterExpression + $" AND Note= '{note}' ";
                }
                if (radioButton4.Checked)
                {
                    note = "inventory";
                    filterExpression = filterExpression + $" AND Note= '{note}' ";
                }
                if (radioButton10.Checked)
                {
                    note = "fromnest";
                    filterExpression = filterExpression + $" AND Note= '{note}' ";
                }
                if (radioButton6.Checked)
                {
                    filterExpression = filterExpression + $" AND (Debet = '2111' OR Kredit = '2111')";
                }
                if (radioButton7.Checked)
                {
                    filterExpression = filterExpression + $" AND (Debet = '2131' OR Kredit = '2131')";
                }
                if (radioButton11.Checked)
                {
                    filterExpression = filterExpression + $" AND (Debet = '1111' OR Kredit = '1111')";
                }
                if (radioButton12.Checked)
                {
                    if (textBox5.Text.Length > 0)
                    {
                        string code = textBox5.Text;
                        filterExpression = filterExpression + $" AND Code_215='{code}' ";
                    }
                    note = "materialcost";
                    filterExpression = filterExpression + $" AND Note= '{note}' ";
                }
                if (radioButton17.Checked)
                {
                    if (DepartmentIdBox.Text != "0")
                    {
                        decimal depin = decimal.Parse(DepartmentIdBox.Text);
                        filterExpression = filterExpression + $" AND DepartmentIn='{depin}' ";
                    }
                    if (textBox4.Text != "0")
                    {
                        decimal depout = decimal.Parse(textBox4.Text);
                        filterExpression = filterExpression + $" AND DepartmentOut='{depout}' ";
                    }
                }
                if (radioButton16.Checked)
                {
                    if (DepartmentIdBox.Text != "0" && textBox4.Text != "0")
                    {
                        decimal depin = decimal.Parse(DepartmentIdBox.Text);
                        filterExpression = filterExpression + $" AND (DepartmentIn='{depin}' ";
                        decimal depout = decimal.Parse(textBox4.Text);
                        filterExpression = filterExpression + $" OR DepartmentOut='{depout}' ) ";
                    }
                    else
                    {
                        if (DepartmentIdBox.Text != "0")
                        {
                            decimal depin = decimal.Parse(DepartmentIdBox.Text);
                            filterExpression = filterExpression + $" AND DepartmentIn='{depin}' ";
                        }
                        if (textBox4.Text != "0")
                        {
                            decimal depout = decimal.Parse(textBox4.Text);
                            filterExpression = filterExpression + $" AND DepartmentOut='{depout}' ";
                        }
                    }
                }
                if (filterExpression != null)
                {
                    float quantity = 0;
                    float costamount = 0;
                    float salesamount = 0;

                    DataRow[] filteredRows = Actions.Select(filterExpression);
                    DataTable filteredTable = Actions.Clone(); // Cloning the structure of table1
                    foreach (DataRow row in filteredRows)  // Set the DataSource of DataGridView to the filtered table
                    {
                        quantity = quantity + float.Parse(row["Quantity"].ToString());
                        costamount = costamount + float.Parse(row["costamount"].ToString());
                        salesamount = salesamount + float.Parse(row["salesamount"].ToString());

                        filteredTable.ImportRow(row);
                    }

                    DataRow newRow1 = filteredTable.NewRow();
                    filteredTable.Rows.Add(newRow1);
                    DataRow newRow2 = filteredTable.NewRow();
                    filteredTable.Rows.Add(newRow2);
                    newRow2["Quantity"] = quantity;
                    newRow2["costamount"] = costamount;
                    newRow2["salesamount"] = salesamount;

                    dataGridView2.DataSource = filteredTable;

                    dataGridView2.Visible = true;
                    dataGridView2.Top = button2.Top + button2.Height + 5;
                    dataGridView2.Height = this.Height - dataGridView2.Top - 50;
                    button3.Visible = true;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = false;
            button3.Visible=false;
            button2.Visible = false;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            button2.Visible = true;
        }

        private void dataGridView2_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            button2.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] foundRows = Table_Department.Select($"Name_1 = '{comboBox2.Text}' ");
            DepartmentIdBox.Text = foundRows[0]["Id"].ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] foundRows = Table_Department.Select($"Name_1 = '{comboBox1.Text}' ");
            textBox4.Text = foundRows[0]["Id"].ToString();
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = string.Empty;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = string.Empty;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = string.Empty;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = radioButton1.Checked;
            textBox2.Enabled = radioButton1.Checked;
            textBox3.Enabled = radioButton1.Checked;
        }
    }
}