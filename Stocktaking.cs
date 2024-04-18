using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Linq;




namespace WindowsFormsApp4
{
    public partial class Stocktaking : Form
    {

        private int _restaurant;

        private int _editor;

        private string _language;

        private DataTable Table_Department = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable Table_Action_215 = new DataTable();

        private DataTable Table_215 = new DataTable();

        private DataTable Table_Seans = new DataTable();

        private DataTable Seans_state = new DataTable();

        private DataTable Print_Seans = new DataTable();

        private DataTable Table_NestGroup = new DataTable();

        private DataTable ControlsStocktaking = new DataTable();

        private DataTable newNestGroup = new DataTable();

        private DataTable Table_SeansState = new DataTable();

        private DataTable Table_TicketsOrdered = new DataTable();

        private DataTable Print_TicketsOrder = new DataTable();

        private DataTable Table_Food = new DataTable();

        private DataTable CurrentOrder = new DataTable();

        private DataTable Table_Rest = new DataTable();


        private DataTable Table_Composite = new DataTable();

        private DataTable Table_Actions = new DataTable();

        private SQLDatabaseHelper dbHelper;

        private DateTime data1 = new DateTime();

        private DataView dataView;

        public Stocktaking(int restaurant, int editor, string language)
        {
            _restaurant = restaurant;
            _editor = editor;
            _language = language;
            InitializeComponent();

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            string query1 = $"SELECT * FROM SeansState Where Id='{_restaurant}' ";
            Table_SeansState = dbHelper.ExecuteQuery(query1);
            int sseans = 1;
            foreach (DataRow row in Table_SeansState.Rows)
            {
                sseans = int.Parse(row["Seans"].ToString());
            }
            numericUpDown1.Value = sseans;
            numericUpDown2.Value = sseans;
            radioButton6.Tag = sseans.ToString();

            string query4 = $"SELECT * FROM Table_215  WHERE Restaurant='{_restaurant}'";
            Table_215 = dbHelper.ExecuteQuery(query4);

            string query3 = $"SELECT * FROM Seans  WHERE  restaurant='{_restaurant}' ";
            Table_Seans = dbHelper.ExecuteQuery(query3);

            var query5 = from row1 in Table_Seans.AsEnumerable()  // տեղադրում ենք <Inholl> դաշտը, որպեսսզի որոշ սրահներից վաճառքի
                                                                  // դեպքում բաղադրիչները չհանվի բաժնից
                         join row2 in Table_215.AsEnumerable()
                         on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                         from subRow2 in gj.DefaultIfEmpty()
                         select new
                         {
                             Row1 = row1,
                             Row2 = subRow2
                         };

            foreach (var item in query5)
            {
                if (item.Row2 != null)
                {
                    item.Row1["NonComposite"] = item.Row2["NonComposite"];
                }
            }

            string query2 = $"SELECT DateBegin,Seans,Ticket,Nest,Costamount,Salesamount," +
                $"Delivery,Music,Service,Discount,Tipmoney,gid,cash,Nestgroup,Holl,Paid,cashless,Person,printed FROM TicketsOrdered WHERE Previous='{0}' AND Restaurant='{_restaurant}' ";
            Table_TicketsOrdered = dbHelper.ExecuteQuery(query2);


            Table_TicketsOrdered.Columns.Add("Total", typeof(float));
            Table_TicketsOrdered.Columns.Add("Paidamount", typeof(float));
            Table_TicketsOrdered.Columns.Add("profit", typeof(float));
            Table_TicketsOrdered.Columns.Add("password", typeof(string));
            foreach (DataRow row in Table_TicketsOrdered.Rows)
            {
                button2.Tag = row["seans"].ToString();
                row["Total"] = 0;
                row["Paidamount"] = 0;
                row["profit"] = 0;
                row["password"] = "";
            }
            //foreach (DataRow row in Table_TicketsOrdered.Rows)
            //{
            //    row["Total"] = 0;
            //    if (row["Costamount"] != DBNull.Value && row["Salesamount"] != DBNull.Value &&
            //        row["Service"] != DBNull.Value && row["Discount"] != DBNull.Value && row["Discount"] != DBNull.Value)
            //    {
            //        row["Total"] = float.Parse(row["Salesamount"].ToString()) +
            //        float.Parse(row["Service"].ToString()) - float.Parse(row["Discount"].ToString());
            //        row["profit"] = float.Parse(row["Total"].ToString()) - float.Parse(row["Costamount"].ToString());
            //    }
            //}


            dataGridView1.DataSource = Table_TicketsOrdered;
            dataView = new DataView(Table_TicketsOrdered);
            dataGridView1.Columns[0].DataPropertyName = "DateBegin";
            dataGridView1.Columns[1].DataPropertyName = "Seans";
            dataGridView1.Columns[2].DataPropertyName = "Ticket";
            dataGridView1.Columns[3].DataPropertyName = "Nest";
            dataGridView1.Columns[4].DataPropertyName = "Costamount";
            dataGridView1.Columns[5].DataPropertyName = "Salesamount";
            dataGridView1.Columns[6].DataPropertyName = "Delivery";
            dataGridView1.Columns[7].DataPropertyName = "Music";
            dataGridView1.Columns[8].DataPropertyName = "Service";
            dataGridView1.Columns[9].DataPropertyName = "Discount";
            dataGridView1.Columns[10].DataPropertyName = "Tipmoney";
            dataGridView1.Columns[11].DataPropertyName = "Total";
            dataGridView1.Columns[12].DataPropertyName = "Paidamount";
            dataGridView1.Columns[13].DataPropertyName = "cashless";
            dataGridView1.Columns[14].DataPropertyName = "profit";
            dataGridView1.Columns[15].DataPropertyName = "Person";
            dataGridView1.Columns[16].DataPropertyName = "Printed";


            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index > 16)
                {
                    column.Visible = false;
                }
            }

            string query7 = $"SELECT *  FROM NestGroup  ";
            Table_NestGroup = dbHelper.ExecuteQuery(query7);
            comboBox2.DataSource = Table_NestGroup.DefaultView;
            comboBox2.Text = "";
            comboBox2.DisplayMember = "Name";
            foreach (DataRow row in Table_NestGroup.Rows)
            {
                row["Name"] = row[_language];
            }
            string query = $"SELECT * FROM Department WHERE Restaurant= '{_restaurant}' ";
            Table_Department = dbHelper.ExecuteQuery(query);
            DepartmentComboBox.DataSource = Table_Department.DefaultView;
            DepartmentComboBox.Text = "";
            DepartmentComboBox.DisplayMember = "Name";


            string query6 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query6);
            foreach (DataRow row in Table_Rest.Rows)
            {
                row["Name"] = row[_language];
                this.Text = row["Name"].ToString();
            }


   

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            button2.Visible = false;

            dataGridView1.Width = this.Width;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;

            if (_editor == 0) button1.Enabled = false; button3.Enabled = false;

                dateTimePicker2.Value = DateTime.Now;

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
            string query1 = $"SELECT * FROM ControlsStocktaking  ";
            ControlsStocktaking = dbHelper.ExecuteQuery(query1);
            foreach (Control control in panel1.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsStocktaking.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel3.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsStocktaking.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel4.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsStocktaking.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            //foreach (Control control in panel5.Controls)
            //{
            //    string columnName = control.Name.Trim();
            //    DataRow[] foundRows = ControlsStocktaking.Select($"TRIM(Name) = '{columnName}'");
            //    if (foundRows.Length > 0)
            //    {
            //        control.Text = foundRows[0][_language].ToString();
            //    }
            //}
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                string columnName = dataGridView1.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsStocktaking.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView1.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }
            }

            for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
            {
                string columnName = dataGridView2.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsStocktaking.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView2.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }
            }
            connection.Close();
        }

        private void Stocktaking_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void Stocktaking_ResizeEnd(object sender, EventArgs e)
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
            richTextBox1.Top = dataGridView1.Top;
            richTextBox1.Height = dataGridView1.Height;
            richTextBox1.Width = panel3.Width;
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            float Costamount = 0, Salesamount = 0, Delivery = 0, Music = 0, Service = 0,
    Discount = 0, Total = 0, profit = 0, cashless = 0, Tipmoney = 0, Paidamount = 0, sumPaid = 0;
            int Person = 0;



            //******************************************* կտրոնով 
            if (radioButton1.Checked)
            {
                DataTable newinformation = new DataTable();
                newinformation = Table_TicketsOrdered.Clone();
                //DateTime data1 = dateTimePicker1.Value;
                int seans = 0;
                data1 = DateTime.Now;
                foreach (DataRow row in Table_TicketsOrdered.Rows)
                {
                    seans = int.Parse(row["Seans"].ToString());
                    if (row["DateBegin"] != DBNull.Value)
                    {
                        DateTime dateTime = (DateTime)row["DateBegin"];
                        data1 = dateTime;
                    }
                    if (radioButton7.Checked)
                    {
                        if (checkBox1.Checked && (data1 < dateTimePicker1.Value || data1 > dateTimePicker2.Value)) continue;
                        
                        if (checkBox2.Checked && (seans < numericUpDown1.Value || seans > numericUpDown2.Value)) continue;
                    }
                    else
                    {
                        if (seans != int.Parse(radioButton6.Tag.ToString())) continue;
                    }

                    if (numericUpDown3.Value > 0 && int.Parse(row["Holl"].ToString()) != numericUpDown3.Value)
                    {

                        continue;
                    }
                    if (comboBox2.SelectedIndex != 0 && int.Parse(row["Nestgroup"].ToString()) != comboBox2.SelectedIndex) continue;
                    DataRow newRow1 = newinformation.NewRow();
                    newinformation.Rows.Add(newRow1);
                    newRow1["total"] = 0;
                    newRow1["Paidamount"] = 0;
                    newRow1["DateBegin"] = (DateTime)row["DateBegin"];
                    newRow1["seans"] = decimal.Parse(row["seans"].ToString());
                    newRow1["ticket"] = decimal.Parse(row["ticket"].ToString());
                    newRow1["nest"] = row["nest"].ToString();
                    newRow1["costamount"] = float.Parse(row["costamount"].ToString());
                    newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    newRow1["service"] = float.Parse(row["service"].ToString());
                    newRow1["discount"] = float.Parse(row["discount"].ToString());
                    newRow1["delivery"] = float.Parse(row["delivery"].ToString());
                    newRow1["music"] = float.Parse(row["music"].ToString());
                    newRow1["cash"] = float.Parse(row["cash"].ToString());
                    newRow1["cashless"] = float.Parse(row["cashless"].ToString());
                    newRow1["tipmoney"] = float.Parse(row["tipmoney"].ToString());
                    newRow1["gid"] = float.Parse(row["gid"].ToString());
                    newRow1["person"] = decimal.Parse(row["person"].ToString());
                    newRow1["total"] = float.Parse(newRow1["salesamount"].ToString()) + float.Parse(newRow1["service"].ToString()) -
                       float.Parse(newRow1["discount"].ToString()) - float.Parse(newRow1["gid"].ToString());
                    newRow1["profit"] = float.Parse(newRow1["total"].ToString()) - float.Parse(newRow1["costamount"].ToString());

                    if (decimal.Parse(row["Paid"].ToString()) == 1)
                    {
                        newRow1["Paidamount"] = newRow1["Total"];
                        Paidamount = Paidamount + float.Parse(newRow1["Total"].ToString());
                    }

                    Costamount = Costamount + float.Parse(newRow1["costamount"].ToString());
                    Salesamount = Salesamount + float.Parse(newRow1["Salesamount"].ToString());
                    Delivery = Delivery + float.Parse(newRow1["Delivery"].ToString());
                    Music = Music + float.Parse(newRow1["Music"].ToString());
                    Service = Service + float.Parse(newRow1["Service"].ToString());
                    Discount = Discount + float.Parse(newRow1["Discount"].ToString());
                    Tipmoney = Tipmoney + float.Parse(newRow1["Tipmoney"].ToString());
                    Total = Total + float.Parse(newRow1["Total"].ToString());
                    cashless = cashless + float.Parse(newRow1["cashless"].ToString());
                    profit = profit + float.Parse(newRow1["profit"].ToString());
                    Person = Person + int.Parse(newRow1["Person"].ToString());
                    if (float.Parse(newRow1["paidamount"].ToString()) == 0)
                    {
                        button1.BackColor = Color.LightYellow;
                        button1.Enabled = false;
                    }

                }
                DataRow newRow2 = newinformation.NewRow();
                newinformation.Rows.Add(newRow2);
                DataRow newRow3 = newinformation.NewRow();
                newinformation.Rows.Add(newRow3);

                newRow3["Costamount"] = Costamount;
                newRow3["Salesamount"] = Salesamount;
                newRow3["Delivery"] = Delivery;
                newRow3["Music"] = Music;
                newRow3["Service"] = Service;
                newRow3["Discount"] = Discount;
                newRow3["Tipmoney"] = Tipmoney;
                newRow3["Paidamount"] = Paidamount;
                newRow3["Total"] = Total;
                newRow3["cashless"] = cashless;
                newRow3["profit"] = profit;
                newRow3["Person"] = Person;
                dataGridView1.DataSource = newinformation;
                dataGridView2.Visible = false;
                dataGridView1.Visible = true;
            }
            //********************************  ապրանքով 


            if (radioButton2.Checked || radioButton5.Checked)
            {
                Table_Food = new DataTable();
                Table_Food.Columns.Add("Code", typeof(int));
                Table_Food.Columns.Add("Name", typeof(string));
                Table_Food.Columns.Add("Quantity", typeof(decimal));
                Table_Food.Columns.Add("Costamount", typeof(float));
                Table_Food.Columns.Add("Salesamount", typeof(float));
                Table_Food.Columns.Add("Service", typeof(decimal));
                Table_Food.Columns.Add("Discount", typeof(decimal));
                Table_Food.Columns.Add("Profit", typeof(float));
                dataGridView2.Columns[0].DataPropertyName = "Code";
                dataGridView2.Columns[1].DataPropertyName = "Name";
                dataGridView2.Columns[2].DataPropertyName = "Quantity";
                dataGridView2.Columns[3].DataPropertyName = "Costamount";
                dataGridView2.Columns[4].DataPropertyName = "Salesamount";
                dataGridView2.Columns[5].DataPropertyName = "Service";
                dataGridView2.Columns[6].DataPropertyName = "Discount";
                dataGridView2.Columns[7].DataPropertyName = "Profit";

                foreach (DataGridViewColumn column in dataGridView2.Columns)
                {

                    if (column.Index > 7)
                    {
                        column.Visible = false;
                    }
                }
                int seans = 0;
                string code = "";
                DateTime data1 = DateTime.Now;
                foreach (DataRow row in Table_Action_215.Rows)
                {
                    data1 = (DateTime)row["DateOfEntry"];
                    seans = int.Parse(row["Seans"].ToString());
                    if (checkBox1.Checked && (data1 < dateTimePicker1.Value || data1 > dateTimePicker2.Value)) continue;
                    if (checkBox2.Checked && (seans < numericUpDown1.Value || seans > numericUpDown2.Value)) continue;
                    if (numericUpDown3.Value > 0 && int.Parse(row["Holl"].ToString()) != numericUpDown3.Value) continue;
                    if (comboBox2.SelectedIndex != 0 && int.Parse(row["Nestgroup"].ToString()) != comboBox2.SelectedIndex) continue;
                    if (radioButton5.Checked && float.Parse(row["Quantity"].ToString()) >= 0) continue; // մինուսները 
                    code = row["Code"].ToString();
                    DataRow[] foundRows = Table_Food.Select($"Code = '{code}' ");

                    Costamount = Costamount + float.Parse(row["Costamount"].ToString());
                    Salesamount = Salesamount + float.Parse(row["Salesamount"].ToString());
                    Service = Service + float.Parse(row["Service"].ToString());
                    Discount = Discount + float.Parse(row["Discount"].ToString());
                    profit = profit + float.Parse(row["Salesamount"].ToString()) + float.Parse(row["Service"].ToString()) -
                            float.Parse(row["Costamount"].ToString()) - float.Parse(row["Discount"].ToString());

                    if (foundRows.Length == 0)
                    {
                        DataRow newRow = Table_Food.NewRow();
                        Table_Food.Rows.Add(newRow);
                        newRow["Code"] = row["Code"];
                        newRow["Name"] = row["Name"];
                        newRow["Quantity"] = row["Quantity"];
                        newRow["Costamount"] = row["Costamount"];
                        newRow["Salesamount"] = row["Salesamount"];
                        newRow["Service"] = row["Service"];
                        newRow["Discount"] = row["Discount"];
                        newRow["Profit"] = float.Parse(row["Salesamount"].ToString()) + float.Parse(row["Service"].ToString()) -
                            float.Parse(row["Costamount"].ToString()) - float.Parse(row["Discount"].ToString());
                    }
                    else
                    {
                        foundRows[0]["Quantity"] = float.Parse(foundRows[0]["Quantity"].ToString()) + float.Parse(row["Quantity"].ToString());
                        foundRows[0]["Costamount"] = float.Parse(foundRows[0]["Salesamount"].ToString()) + float.Parse(row["Costamount"].ToString());
                        foundRows[0]["Salesamount"] = float.Parse(foundRows[0]["Salesamount"].ToString()) + float.Parse(row["Salesamount"].ToString());
                        foundRows[0]["Service"] = float.Parse(foundRows[0]["Service"].ToString()) + float.Parse(row["Service"].ToString());
                        foundRows[0]["Discount"] = float.Parse(foundRows[0]["Discount"].ToString()) + float.Parse(row["Discount"].ToString());
                        foundRows[0]["Profit"] = float.Parse(foundRows[0]["Salesamount"].ToString()) + float.Parse(foundRows[0]["Service"].ToString()) -
                            float.Parse(foundRows[0]["Costamount"].ToString()) - float.Parse(foundRows[0]["Discount"].ToString());
                    }

                }
                foreach (DataRow row in Table_Seans.Rows)
                {
                    data1 = (DateTime)row["DateOfEntry"];
                    seans = int.Parse(row["Seans"].ToString());
                    if (checkBox1.Checked && (data1 < dateTimePicker1.Value || data1 > dateTimePicker2.Value)) continue;
                    if (checkBox2.Checked && (seans < numericUpDown1.Value || seans > numericUpDown2.Value)) continue;
                    if (numericUpDown3.Value > 0 && int.Parse(row["Holl"].ToString()) != numericUpDown3.Value) continue;
                    if (comboBox2.SelectedIndex != 0 && int.Parse(row["Nestgroup"].ToString()) != comboBox2.SelectedIndex) continue;
                    if (radioButton5.Checked && float.Parse(row["Quantity"].ToString()) >= 0) continue; // մինուսները 
                    code = row["Code"].ToString();
                    DataRow[] foundRows = Table_Food.Select($"Code = '{code}' ");

                    Costamount = Costamount + float.Parse(row["Costamount"].ToString());
                    Salesamount = Salesamount + float.Parse(row["Salesamount"].ToString());
                    Service = Service + float.Parse(row["Service"].ToString());
                    Discount = Discount + float.Parse(row["Discount"].ToString());
                    profit = profit + float.Parse(row["Salesamount"].ToString()) + float.Parse(row["Service"].ToString()) -
                            float.Parse(row["Costamount"].ToString()) - float.Parse(row["Discount"].ToString());

                    if (foundRows.Length == 0)
                    {
                        DataRow newRow = Table_Food.NewRow();
                        Table_Food.Rows.Add(newRow);
                        newRow["Code"] = row["Code"];
                        newRow["Name"] = row["Name"];
                        newRow["Quantity"] = row["Quantity"];
                        newRow["Costamount"] = row["Costamount"];
                        newRow["Salesamount"] = row["Salesamount"];
                        newRow["Service"] = row["Service"];
                        newRow["Discount"] = row["Discount"];
                        newRow["Profit"] = float.Parse(row["Salesamount"].ToString()) + float.Parse(row["Service"].ToString()) -
                            float.Parse(row["Costamount"].ToString()) - float.Parse(row["Discount"].ToString());



                    }
                    else
                    {
                        foundRows[0]["Quantity"] = float.Parse(foundRows[0]["Quantity"].ToString()) + float.Parse(row["Quantity"].ToString());
                        foundRows[0]["Costamount"] = float.Parse(foundRows[0]["Salesamount"].ToString()) + float.Parse(row["Costamount"].ToString());
                        foundRows[0]["Salesamount"] = float.Parse(foundRows[0]["Salesamount"].ToString()) + float.Parse(row["Salesamount"].ToString());
                        foundRows[0]["Service"] = float.Parse(foundRows[0]["Service"].ToString()) + float.Parse(row["Service"].ToString());
                        foundRows[0]["Discount"] = float.Parse(foundRows[0]["Discount"].ToString()) + float.Parse(row["Discount"].ToString());
                        foundRows[0]["Profit"] = float.Parse(foundRows[0]["Salesamount"].ToString()) + float.Parse(foundRows[0]["Service"].ToString()) -
                            float.Parse(foundRows[0]["Costamount"].ToString()) - float.Parse(foundRows[0]["Discount"].ToString());
                    }

                }
                DataRow newRow1 = Table_Food.NewRow();
                Table_Food.Rows.Add(newRow1);
                DataRow newRow2 = Table_Food.NewRow();
                Table_Food.Rows.Add(newRow2);
                newRow2["Costamount"] = Costamount;
                newRow2["Salesamount"] = Salesamount;
                newRow2["Service"] = Service;
                newRow2["Discount"] = Discount;
                newRow2["profit"] = profit;
                dataGridView2.DataSource = Table_Food;
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;

            }

            //*********************************************  ամսով 

            if (radioButton3.Checked)
            {
                DataTable newinformation = new DataTable();
                newinformation = Table_TicketsOrdered.Clone();
                DateTime data1 = DateTime.Now;
                int month = 0;
                int year = 0;
                foreach (DataRow row in Table_TicketsOrdered.Rows)
                {
                    if (row["DateBegin"] != DBNull.Value)
                    {
                        data1 = (DateTime)row["DateBegin"];
                    }

                    if (checkBox1.Checked && (data1 < dateTimePicker1.Value || data1 > dateTimePicker2.Value)) continue;
                    if (numericUpDown3.Value > 0 && int.Parse(row["Holl"].ToString()) != numericUpDown3.Value) continue;
                    if (comboBox2.SelectedIndex != 0 && int.Parse(row["Nestgroup"].ToString()) != comboBox2.SelectedIndex) continue;
                    year = data1.Year;
                    month = data1.Month;
                    DataRow[] foundRows = newinformation.Select($"Seans = '{year}' and Ticket =  '{month}' ");
                    if (foundRows.Length == 0)
                    {
                        Paidamount = 0;
                        DataRow newRow = newinformation.NewRow();
                        newinformation.Rows.Add(newRow);
                        for (int colIndex = 0; colIndex < Table_TicketsOrdered.Columns.Count; colIndex++)
                        {
                            string columnName = Table_TicketsOrdered.Columns[colIndex].ColumnName;
                            newRow[columnName] = row[columnName];
                        }
                        if (int.Parse(row["Paid"].ToString()) == 1)
                        {
                            Paidamount = Paidamount + float.Parse(row["Total"].ToString());
                            newRow["Paidamount"] = float.Parse(row["Total"].ToString());
                            sumPaid = sumPaid + float.Parse(row["Total"].ToString());
                        }
                        newRow["Seans"] = year;
                        newRow["Ticket"] = month;
                        newRow["Nest"] = "";
                    }
                    else
                    {
                        foundRows[0]["Costamount"] = float.Parse(foundRows[0]["Costamount"].ToString()) + float.Parse(row["costamount"].ToString());
                        foundRows[0]["Salesamount"] = float.Parse(foundRows[0]["Salesamount"].ToString()) + float.Parse(row["Salesamount"].ToString());
                        foundRows[0]["Delivery"] = float.Parse(foundRows[0]["Delivery"].ToString()) + float.Parse(row["Delivery"].ToString());
                        foundRows[0]["Music"] = float.Parse(foundRows[0]["Music"].ToString()) + float.Parse(row["Music"].ToString());
                        foundRows[0]["Service"] = float.Parse(foundRows[0]["Service"].ToString()) + float.Parse(row["Service"].ToString());
                        foundRows[0]["Discount"] = float.Parse(foundRows[0]["Discount"].ToString()) + float.Parse(row["Discount"].ToString());
                        foundRows[0]["Tipmoney"] = float.Parse(foundRows[0]["Tipmoney"].ToString()) + float.Parse(row["Tipmoney"].ToString());
                        foundRows[0]["Total"] = float.Parse(foundRows[0]["Total"].ToString()) + float.Parse(row["Total"].ToString());
                        foundRows[0]["cashless"] = float.Parse(foundRows[0]["cashless"].ToString()) + float.Parse(row["cashless"].ToString());
                        foundRows[0]["profit"] = float.Parse(foundRows[0]["profit"].ToString()) + float.Parse(row["profit"].ToString());
                        foundRows[0]["Person"] = int.Parse(foundRows[0]["Person"].ToString()) + int.Parse(row["Person"].ToString());
                        if (int.Parse(row["Paid"].ToString()) == 1)
                        {
                            Paidamount = Paidamount + float.Parse(row["Total"].ToString());
                            foundRows[0]["Paidamount"] = Paidamount;
                            sumPaid = sumPaid + float.Parse(row["Total"].ToString());
                        }

                    }
                    Costamount = Costamount + float.Parse(row["costamount"].ToString());
                    Salesamount = Salesamount + float.Parse(row["Salesamount"].ToString());
                    Delivery = Delivery + float.Parse(row["Delivery"].ToString());
                    Music = Music + float.Parse(row["Music"].ToString());
                    Service = Service + float.Parse(row["Service"].ToString());
                    Discount = Discount + float.Parse(row["Discount"].ToString());
                    Total = Total + float.Parse(row["Total"].ToString());
                    cashless = cashless + float.Parse(row["cashless"].ToString());
                    profit = profit + float.Parse(row["profit"].ToString());
                    Person = Person + int.Parse(row["Person"].ToString());
                    Tipmoney = Tipmoney + int.Parse(row["Tipmoney"].ToString());

                }
                DataRow newRow1 = newinformation.NewRow();
                newinformation.Rows.Add(newRow1);
                DataRow newRow2 = newinformation.NewRow();
                newinformation.Rows.Add(newRow2);
                newRow2["Costamount"] = Costamount;
                newRow2["Salesamount"] = Salesamount;
                newRow2["Delivery"] = Delivery;
                newRow2["Music"] = Music;
                newRow2["Service"] = Service;
                newRow2["Discount"] = Discount;
                newRow2["Tipmoney"] = Tipmoney;
                newRow2["Paidamount"] = sumPaid;
                newRow2["Total"] = Total;
                newRow2["cashless"] = cashless;
                newRow2["profit"] = profit;
                newRow2["Person"] = Person;

                dataGridView1.DataSource = newinformation;
            }

            //**************************************  Օրերով

            if (radioButton4.Checked)
            {
                DataTable newinformation = new DataTable();
                newinformation = Table_TicketsOrdered.Clone();
                DateTime data1 = DateTime.Now;
                int month = 0;
                int year = 0;
                int hour = 0;
                int day = 0;
                string dey = "";
                foreach (DataRow row in Table_TicketsOrdered.Rows)
                {
                    if (row["DateBegin"] != DBNull.Value)
                    {
                        data1 = (DateTime)row["DateBegin"];
                    }

                    if (checkBox1.Checked && (data1 < dateTimePicker1.Value || data1 > dateTimePicker2.Value)) continue;
                    if (numericUpDown3.Value > 0 && int.Parse(row["Holl"].ToString()) != numericUpDown3.Value) continue;
                    if (comboBox2.SelectedIndex != 0 && int.Parse(row["Nestgroup"].ToString()) != comboBox2.SelectedIndex) continue;
                    year = data1.Year;
                    month = data1.Month;
                    hour = data1.Hour;
                    day = data1.Day;
                    if (day < 5) day = day - 1;
                    dey = day.ToString();
                    DataRow[] foundRows = newinformation.Select($"Seans = '{year}' and Ticket =  '{month}'  and Nest =  '{dey}' ");
                    if (foundRows.Length == 0)
                    {
                        Paidamount = 0;
                        DataRow newRow = newinformation.NewRow();
                        newinformation.Rows.Add(newRow);
                        for (int colIndex = 0; colIndex < Table_TicketsOrdered.Columns.Count; colIndex++)
                        {
                            string columnName = Table_TicketsOrdered.Columns[colIndex].ColumnName;
                            newRow[columnName] = row[columnName];
                        }
                        newRow["Seans"] = year;
                        newRow["Ticket"] = month;
                        newRow["Nest"] = dey;
                        if (int.Parse(row["Paid"].ToString()) == 1)
                        {
                            Paidamount = Paidamount + float.Parse(row["Total"].ToString());
                            newRow["Paidamount"] = float.Parse(row["Total"].ToString());
                            sumPaid = sumPaid + float.Parse(row["Total"].ToString());
                        }

                    }
                    else
                    {
                        foundRows[0]["Costamount"] = float.Parse(foundRows[0]["Costamount"].ToString()) + float.Parse(row["costamount"].ToString());
                        foundRows[0]["Salesamount"] = float.Parse(foundRows[0]["Salesamount"].ToString()) + float.Parse(row["Salesamount"].ToString());
                        foundRows[0]["Delivery"] = float.Parse(foundRows[0]["Delivery"].ToString()) + float.Parse(row["Delivery"].ToString());
                        foundRows[0]["Music"] = float.Parse(foundRows[0]["Music"].ToString()) + float.Parse(row["Music"].ToString());
                        foundRows[0]["Service"] = float.Parse(foundRows[0]["Service"].ToString()) + float.Parse(row["Service"].ToString());
                        foundRows[0]["Discount"] = float.Parse(foundRows[0]["Discount"].ToString()) + float.Parse(row["Discount"].ToString());
                        foundRows[0]["Tipmoney"] = float.Parse(foundRows[0]["Tipmoney"].ToString()) + float.Parse(row["Tipmoney"].ToString());
                        foundRows[0]["Total"] = float.Parse(foundRows[0]["Total"].ToString()) + float.Parse(row["Total"].ToString());
                        foundRows[0]["cashless"] = float.Parse(foundRows[0]["cashless"].ToString()) + float.Parse(row["cashless"].ToString());
                        foundRows[0]["profit"] = float.Parse(foundRows[0]["profit"].ToString()) + float.Parse(row["profit"].ToString());
                        foundRows[0]["Person"] = int.Parse(foundRows[0]["Person"].ToString()) + int.Parse(row["Person"].ToString());
                        if (int.Parse(row["Paid"].ToString()) == 1)
                        {
                            Paidamount = Paidamount + float.Parse(row["Total"].ToString());
                            foundRows[0]["Paidamount"] = Paidamount;
                            sumPaid = sumPaid + float.Parse(row["Total"].ToString());
                        }

                    }
                    //if (int.Parse(newRow["Paid"].ToString()) == 1) newRow["Paidamount"] = newRow["Total"];
                    Costamount = Costamount + float.Parse(row["costamount"].ToString());
                    Salesamount = Salesamount + float.Parse(row["Salesamount"].ToString());
                    Delivery = Delivery + float.Parse(row["Delivery"].ToString());
                    Music = Music + float.Parse(row["Music"].ToString());
                    Service = Service + float.Parse(row["Service"].ToString());
                    Discount = Discount + float.Parse(row["Discount"].ToString());
                    Total = Total + float.Parse(row["Total"].ToString());
                    cashless = cashless + float.Parse(row["cashless"].ToString());
                    profit = profit + float.Parse(row["profit"].ToString());
                    Person = Person + int.Parse(row["Person"].ToString());
                    Tipmoney = Tipmoney + float.Parse(row["Tipmoney"].ToString());
                }
                DataRow newRow1 = newinformation.NewRow();
                newinformation.Rows.Add(newRow1);
                DataRow newRow2 = newinformation.NewRow();
                newinformation.Rows.Add(newRow2);
                newRow2["Costamount"] = Costamount;
                newRow2["Salesamount"] = Salesamount;
                newRow2["Delivery"] = Delivery;
                newRow2["Music"] = Music;
                newRow2["Service"] = Service;
                newRow2["Discount"] = Discount;
                newRow2["Tipmoney"] = Tipmoney;
                newRow2["Paidamount"] = sumPaid;
                newRow2["Total"] = Total;
                newRow2["cashless"] = cashless;
                newRow2["profit"] = profit;
                newRow2["Person"] = Person;

                dataGridView1.DataSource = newinformation;
            }




        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox1.BackColor = Color.LightGreen;
            checkBox2.BackColor = panel1.BackColor;
            checkBox1.Checked = true;

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.BackColor = Color.LightGreen;
            checkBox1.BackColor = panel1.BackColor;
            checkBox2.Checked = true;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            radioButton1.BackColor = panel1.BackColor;
            radioButton2.BackColor = panel1.BackColor;
            radioButton3.BackColor = panel1.BackColor;
            radioButton4.BackColor = panel1.BackColor;
            radioButton5.BackColor = panel1.BackColor;
            radioButton1.BackColor = Color.LightGreen;
            dataGridView1.Width = this.Width;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            billBox.Visible = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            radioButton1.BackColor = panel1.BackColor;
            radioButton2.BackColor = panel1.BackColor;
            radioButton3.BackColor = panel1.BackColor;
            radioButton4.BackColor = panel1.BackColor;
            radioButton5.BackColor = panel1.BackColor;
            radioButton2.BackColor = Color.LightGreen;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView2.Left = 0;
            billBox.Visible = false;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioButton1.BackColor = panel1.BackColor;
            radioButton2.BackColor = panel1.BackColor;
            radioButton3.BackColor = panel1.BackColor;
            radioButton4.BackColor = panel1.BackColor;
            radioButton5.BackColor = panel1.BackColor;
            radioButton3.BackColor = Color.LightGreen;
            dataGridView1.Width = this.Width;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            billBox.Visible = false;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            radioButton1.BackColor = panel1.BackColor;
            radioButton2.BackColor = panel1.BackColor;
            radioButton3.BackColor = panel1.BackColor;
            radioButton4.BackColor = panel1.BackColor;
            radioButton5.BackColor = panel1.BackColor;
            radioButton4.BackColor = Color.LightGreen;
            dataGridView1.Width = this.Width;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            billBox.Visible = false;
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            radioButton1.BackColor = panel1.BackColor;
            radioButton2.BackColor = panel1.BackColor;
            radioButton3.BackColor = panel1.BackColor;
            radioButton4.BackColor = panel1.BackColor;
            radioButton5.BackColor = panel1.BackColor;
            radioButton5.BackColor = Color.LightGreen;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView2.Left = 0;
            billBox.Visible = false;
        }

        private void numericUpDown3_Click(object sender, EventArgs e)
        {
            label1.BackColor = panel1.BackColor;
            if (numericUpDown3.Value > 0) label1.BackColor = Color.LightGreen;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.BackColor = panel1.BackColor;
            if (comboBox2.SelectedIndex > 0) label2.BackColor = Color.LightGreen;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)//տպում ենք տվյալ տողի կտրոնը
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            if (radioButton1.Checked == false || billBox.Checked == false) return;

            CurrentOrder = new DataTable();
            CurrentOrder.Columns.Add("name", typeof(string));
            CurrentOrder.Columns.Add("price", typeof(float));
            CurrentOrder.Columns.Add("salesamount", typeof(float));
            CurrentOrder.Columns.Add("quantity", typeof(float));
            CurrentOrder.Columns.Add("service", typeof(float));
            CurrentOrder.Columns.Add("discount", typeof(float));
            CurrentOrder.Columns.Add("free", typeof(int));
            CurrentOrder.Columns.Add("code", typeof(string));
            // }

            decimal seans = 0, ticket = 0, Paid = 0;
            string nest = "", Gid = "";
            DateTime DateBegin = DateTime.Now, DateEnd = DateTime.Now;
            float Salesamount = 0, Service = 0, Discount = 0, Delivery = 0, Music = 0, Tipmoney = 0, Total = 0;

            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                if (dataGridView1.Rows[rowindex].Cells[colIndex].Value != DBNull.Value)
                {
                    if (dataGridView1.Columns[colIndex].DataPropertyName == "Seans")
                    {
                        seans = decimal.Parse(dataGridView1.Rows[rowindex].Cells[colIndex].Value.ToString());
                    }
                    if (dataGridView1.Columns[colIndex].DataPropertyName == "Ticket")
                    {
                        ticket = decimal.Parse(dataGridView1.Rows[rowindex].Cells[colIndex].Value.ToString());
                    }
                    if (dataGridView1.Columns[colIndex].DataPropertyName == "Nest")
                    {
                        nest = dataGridView1.Rows[rowindex].Cells[colIndex].Value.ToString();
                    }
                }
            }
            if (seans == int.Parse(radioButton6.Tag.ToString()))
            {
                string query = $"SELECT * FROM Seans Where Seans='{seans}' AND Ticket='{ticket}' AND Nest='{nest}' AND Restaurant='{_restaurant}' ";
                Print_Seans = dbHelper.ExecuteQuery(query);
            }
            else
            {
                string query = $"SELECT * FROM Actions_215 Where Seans='{seans}' AND Ticket='{ticket}' AND Nest='{nest}' AND Restaurant='{_restaurant}' ";
                Print_Seans = dbHelper.ExecuteQuery(query);

            }
            if (Print_Seans.Rows.Count > 0)
            {
                String code = "";
                foreach (DataRow row in Print_Seans.Rows)
                {
                    code = row["code"].ToString();
                    DataRow[] foundRows1 = CurrentOrder.Select($"Code = '{code}'");
                    if (foundRows1.Length > 0)
                    {
                        foundRows1[0]["quantity"] = float.Parse(foundRows1[0]["quantity"].ToString()) + float.Parse(row["quantity"].ToString());
                        foundRows1[0]["salesamount"] = float.Parse(foundRows1[0]["salesamount"].ToString()) + float.Parse(row["salesamount"].ToString());
                    }
                    else
                    {
                        DataRow newRow = CurrentOrder.NewRow();
                        CurrentOrder.Rows.Add(newRow);
                        newRow["code"] = row["Code"].ToString();
                        newRow["name"] = "";
                        newRow["price"] = float.Parse(row["Price"].ToString());
                        newRow["salesamount"] = float.Parse(row["Salesamount"].ToString());
                        newRow["quantity"] = float.Parse(row["Quantity"].ToString());
                        newRow["service"] = float.Parse(row["service"].ToString());
                        newRow["discount"] = float.Parse(row["discount"].ToString());
                        newRow["free"] = int.Parse(row["Free"].ToString());
                    }
                }
                //հեռացնում ենք 0 քանակով տողերը
                foreach (DataRow row in CurrentOrder.Rows.Cast<DataRow>().ToList())
                {
                    if (float.Parse(row["Quantity"].ToString()) == 0)
                    {
                        row.Delete();
                    }
                }
                //անուններն ենք տեղադրում 
                Translate.translation(Table_215, CurrentOrder, _language, "1");
            }
            string query1 = $"SELECT * FROM TicketsOrdered Where Seans='{seans}' AND Ticket='{ticket}' AND Nest='{nest}' AND Restaurant='{_restaurant}'  AND Previous='{0}'  ";
            Print_TicketsOrder = dbHelper.ExecuteQuery(query1);

            foreach (DataRow row in Print_TicketsOrder.Rows)
            {
                DateBegin = (DateTime)row["DateBegin"];
                DateEnd = DateTime.Parse(row["DateEnd"].ToString());
                Salesamount = float.Parse(row["Salesamount"].ToString());
                Service = float.Parse(row["Service"].ToString());
                Discount = float.Parse(row["Discount"].ToString());
                Gid = row["Gid"].ToString();
                Tipmoney = float.Parse(row["Tipmoney"].ToString());
                Paid = decimal.Parse(row["Paid"].ToString());
            }
            connection.Close();

            PrintingBill.PrintBill(ticket.ToString(), nest, Gid.ToString(), Tipmoney.ToString(), Paid, 1, DateBegin, DateEnd, CurrentOrder, "", _language);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            radioButton6.BackColor = Color.LightGreen;
            radioButton7.BackColor = panel3.BackColor;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            radioButton1.Focus();
            SendKeys.Send("{ENTER}");
            button2.Focus();
            SendKeys.Send("{ENTER}");
            button1.Visible = true;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            radioButton7.BackColor = Color.LightGreen;
            radioButton6.BackColor = panel3.BackColor;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            radioButton1.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (radioButton6.Checked)
            {
                button3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            string query0 = $"SELECT * FROM SeansState  WHERE Id='{_restaurant}' ";
            Table_Seans = dbHelper.ExecuteQuery(query0);

            string query1 = $"SELECT * FROM Seans  WHERE Previous='{0}' AND restaurant='{_restaurant}' ";
            Table_Seans = dbHelper.ExecuteQuery(query1);



            string query2 = $"SELECT * FROM Composite  WHERE restaurant='{_restaurant}' ";
            Table_Composite = dbHelper.ExecuteQuery(query2);
            string query3 = $"SELECT * FROM Actions  WHERE  Id=0 ";
            Table_Actions = dbHelper.ExecuteQuery(query3);
            connection.Open();
            foreach (DataRow row in Table_Seans.Rows)
            {
                string noncomp = row["Holl"].ToString().Trim() + ",";
                if (row["NonComposite"].ToString().IndexOf(noncomp) >= 0) continue; //տվյալ սրահում չի բաղադրվում ճաշատեսակը

                string InsertQuery = $"INSERT INTO Actions_215 ( Code , Groupp, DateOfEntry, Seans, Ticket, Paid," +
                    $"Nest ,Quantity , Price, Costamount, Salesamount, Service, Discount, Free, Taxpaid, Restaurant, Holl, Operator, Previous, DepartmentOut)" +
                    $" values (@Code , @Groupp, @DateOfEntry, @Seans, @Ticket, @Paid, @Nest ," +
                    $"@Quantity ,@Price, @Costamount, @Salesamount, @Service, @Discount, @Free, @Taxpaid, @Restaurant, @Holl, @Operator, @Previous, @Departmentout ) ";
                using (SqlCommand insertCommand = new SqlCommand(InsertQuery, connection))

                {
                    insertCommand.Parameters.AddWithValue("@Code", row["code"]);
                    insertCommand.Parameters.AddWithValue("@Groupp", row["groupp"]);
                    insertCommand.Parameters.AddWithValue("@DateOfEntry", row["DateOfEntry"]);
                    insertCommand.Parameters.AddWithValue("@Seans", row["seans"]);
                    insertCommand.Parameters.AddWithValue("@Ticket", row["ticket"]);
                    insertCommand.Parameters.AddWithValue("@Paid", row["paid"]);
                    insertCommand.Parameters.AddWithValue("@Nest", row["nest"]);
                    insertCommand.Parameters.AddWithValue("@Quantity", row["quantity"]);
                    insertCommand.Parameters.AddWithValue("@Price", row["price"]);
                    insertCommand.Parameters.AddWithValue("@Costamount", row["Costamount"]);
                    insertCommand.Parameters.AddWithValue("@Salesamount", row["salesamount"]);
                    insertCommand.Parameters.AddWithValue("@Service", row["Service"]);
                    insertCommand.Parameters.AddWithValue("@Discount", row["Discount"]);
                    insertCommand.Parameters.AddWithValue("@Departmentout", row["departmentout"]);
                    insertCommand.Parameters.AddWithValue("@Free", row["Free"]);
                    insertCommand.Parameters.AddWithValue("@Taxpaid", row["taxpaid"]);
                    insertCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                    insertCommand.Parameters.AddWithValue("@Holl", row["holl"]);
                    insertCommand.Parameters.AddWithValue("@Operator", row["operator"]);
                    insertCommand.Parameters.AddWithValue("@Previous", row["previous"]);

                    insertCommand.ExecuteNonQuery();
                }

                foreach (DataRow row1 in Table_Seans.Rows)
                {
                    DataRow[] foundRows1 = Table_Composite.Select($"Code_215 = '{row1["Code"]}' ");
                    if (foundRows1.Length > 0)
                    {
                        foreach (DataRow row2 in foundRows1)
                        {
                            DataRow[] foundRows2 = Table_Actions.Select($"Code = '{row2["Code_211"]}' AND Code_215 = '{row1["Code"]}' AND DepartmentOut= '{row1["DepartmentOut"]}'");
                            if (foundRows2.Length == 0)
                            {
                                DataRow newRow = Table_Actions.NewRow();
                                Table_Actions.Rows.Add(newRow);
                                newRow["Date"] = row1["DateOfEntry"]; newRow["seans"] = row1["seans"];
                                newRow["Code"] = row2["code_211"]; newRow["Code_215"] = row1["code"];
                                newRow["DepartmentOut"] = row1["DepartmentOut"]; newRow["Restaurant"] = row1["Restaurant"];
                                newRow["Quantity"] = float.Parse(row1["Quantity"].ToString()) * float.Parse(row2["Quantity"].ToString());
                                newRow["Costamount"] = float.Parse(newRow["Quantity"].ToString()) * float.Parse(row2["CostPrice"].ToString());
                                newRow["SalesAmount"] = row1["SalesAmount"];
                            }
                            else
                            {
                                foundRows2[0]["Quantity"] = float.Parse(foundRows2[0]["Quantity"].ToString()) +
                                    float.Parse(row1["Quantity"].ToString()) * float.Parse(row2["Quantity"].ToString());
                                foundRows2[0]["Costamount"] = float.Parse(foundRows2[0]["Costamount"].ToString()) +
                                    float.Parse(row1["Quantity"].ToString()) * float.Parse(row2["Quantity"].ToString()) *
                                    float.Parse(row2["CostPrice"].ToString());
                                foundRows2[0]["SalesAmount"] = float.Parse(foundRows2[0]["SalesAmount"].ToString()) +
                                    float.Parse(row1["SalesAmount"].ToString());
                            }
                        }
                    }
                }
                foreach (DataRow row3 in Table_Actions.Rows)
                {
                    string InsertQuery1 = $"INSERT INTO Actions (Date, seans,  Code, Code_215, Quantity , Costamount, Salesamount, DepartmentOut, Restaurant, debet, kredit )" +
                             $" values (@Date, @seans,  @Code, @code_215, @Quantity , @Costamount, @Salesamount, @DepartmentOut, @Restaurant, @debet, @kredit ) ";
                    using (SqlCommand insertCommand = new SqlCommand(InsertQuery1, connection))

                    {
                        insertCommand.Parameters.AddWithValue("@Date", row3["Date"]);
                        insertCommand.Parameters.AddWithValue("@Seans", row3["Seans"]);
                        insertCommand.Parameters.AddWithValue("@Code", row3["Code"]);
                        insertCommand.Parameters.AddWithValue("@Code_215", row3["Code_215"]);
                        insertCommand.Parameters.AddWithValue("@Quantity", row3["Quantity"]);
                        insertCommand.Parameters.AddWithValue("@Costamount", row3["Costamount"]);
                        insertCommand.Parameters.AddWithValue("@Salesamount", 0);
                        insertCommand.Parameters.AddWithValue("@DepartmentOut", row3["DepartmentOut"]);
                        insertCommand.Parameters.AddWithValue("@Restaurant", row3["Restaurant"]);
                        insertCommand.Parameters.AddWithValue("@debet", "7111" );
                        insertCommand.Parameters.AddWithValue("@kredit", "2111");
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            string DeleteQuery = $"DELETE FROM seans ";
            using (SqlCommand deleteCommand = new SqlCommand(DeleteQuery, connection))
                deleteCommand.ExecuteNonQuery();
            connection.Close();
            button1.Visible = false;
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string filePath = "";
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";
                richTextBox1.Height = this.Height - 50;
                richTextBox1.ReadOnly = true;

                if(_language=="Armenian") filePath = "D:\\hayrik\\sql\\help\\stocktaking_arm.txt";
                if (_language == "English") filePath = "D:\\hayrik\\sql\\help\\stocktaking_eng.txt";
                if (_language == "German") filePath = "D:\\hayrik\\sql\\help\\stocktaking_germ.txt";
                if (_language == "Espaniol") filePath = "D:\\hayrik\\sql\\help\\stocktaking_esp.txt";
                if (_language == "Russian") filePath = "D:\\hayrik\\sql\\help\\stocktaking_rus.txt";
                string fileContent = File.ReadAllText(filePath);
                richTextBox1.Text = fileContent;
                richTextBox1.Visible = true;
                richTextBox1.Top = dataGridView1.Top;
                this.Text = richTextBox1.Top.ToString();
                richTextBox1.Height = dataGridView1.Height;
                richTextBox1.Width = panel3.Width;
            }
            else
            {
                richTextBox1.Visible = false;
                HelpButton.Text = "?";
            }
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] foundRows = Table_Department.Select($"Name = '{DepartmentComboBox.Text}' ");
            if (foundRows.Length == 0) { return; }
            DepartmentIdBox.Text = foundRows[0]["Id"].ToString();

        }
    }
}