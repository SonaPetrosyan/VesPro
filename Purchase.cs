using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApp4
{
    public partial class Purchase : Form
    {
        private int _parameter1;
        private int _restaurant;
        private int _editor;
        private string _language;

        private SQLDatabaseHelper dbHelper;

        private DataTable Table_215 = new DataTable();

        private DataTable Table_211 = new DataTable();

        private DataTable Table_213 = new DataTable();

        private DataTable Table_111 = new DataTable();

        private DataTable Table_Actions = new DataTable();

        private DataTable Table_Department = new DataTable();

        private DataTable Table_Department_ = new DataTable();

        private DataTable Table_Partners = new DataTable();

        private DataTable Table_Outgo = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable ControlsPurchase = new DataTable();

        private DataTable Table_Number = new DataTable();

        private DataTable Table_Purchase;

        private DataView dataView;

        public Purchase(int ooperator, int restaurant, int editor, string language)
        {
            _parameter1 = ooperator;
            _restaurant = restaurant;
            _editor = editor;
            _language = language;
            InitializeComponent();

            dateTimePicker1.Value = DateTime.Now;
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            string query1 = $"SELECT * FROM table_211  ";
            Table_211 = dbHelper.ExecuteQuery(query1);
            Table_211.Columns.Add("Name", typeof(string));
            Table_211.Columns.Add("Quantity", typeof(float));
            Table_211.Columns.Add("Amount", typeof(float));
            Table_211.Columns.Add("Changed", typeof(int));
            foreach (DataRow row in Table_211.Rows)
            {
                row["Name"] = row[_language];
                row["Quantity"] = 0;
                row["Amount"] = 0;
                row["Changed"] = 0;
            }
            Table_Purchase = Table_211.Clone();
            Table_Purchase.Columns.Add("Number", typeof(int));
            Table_Purchase.Columns.Add("DepartmentIn", typeof(int));
            Table_Purchase.Columns.Add("DepartmentOut", typeof(int));
            Table_Purchase.Columns.Add("Debitor", typeof(int));
            Table_Purchase.Columns.Add("Kreditor", typeof(int));
            Table_Purchase.Columns.Add("Operator", typeof(int));
            Table_Purchase.Columns.Add("Debet", typeof(string));
            Table_Purchase.Columns.Add("CostAmount", typeof(float));
            Table_Purchase.Columns.Add("SalesAmount", typeof(float));
            Table_Purchase.Columns.Add("Kredit", typeof(string));
            Table_Purchase.Columns.Add("Date", typeof(DateTime));
            Table_Purchase.Columns.Add("DateOfEntry", typeof(DateTime));
            Table_Purchase.Columns.Add("RestaurantIn", typeof(int));
            Table_Purchase.Columns.Add("RestaurantOut", typeof(int));
            //      Table_Purchase.Columns.Add("Restaurant", typeof(int));
            Table_Purchase.Columns.Add("Note", typeof(string));

            dataView = new DataView(Table_211);
            dataGridView1.DataSource = dataView;

            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name";
            dataGridView1.Columns[2].DataPropertyName = "Unit";
            dataGridView1.Columns[3].DataPropertyName = "CostPrice";
            dataGridView1.Columns[4].DataPropertyName = "Quantity";
            dataGridView1.Columns[5].DataPropertyName = "Amount";

            dataGridView1.Columns[0].HeaderText = "Կոդ";
            dataGridView1.Columns[1].HeaderText = "Անվանում";
            dataGridView1.Columns[2].HeaderText = "Չ․մ";
            dataGridView1.Columns[3].HeaderText = "Վերջին գին";
            dataGridView1.Columns[4].HeaderText = "Քանակ";
            dataGridView1.Columns[5].HeaderText = "Գին";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                string name = column.DataPropertyName;
                if (column.Index > 5)
                {
                    column.Visible = false;
                }

            }
            dataView = new DataView(Table_Purchase);
            dataGridView2.DataSource = dataView;

            dataGridView2.Columns[0].DataPropertyName = "Code";
            dataGridView2.Columns[1].DataPropertyName = "Name";
            dataGridView2.Columns[2].DataPropertyName = "Unit";
            dataGridView2.Columns[3].DataPropertyName = "CostPrice";
            dataGridView2.Columns[4].DataPropertyName = "Quantity";
            dataGridView2.Columns[5].DataPropertyName = "Amount";

            dataGridView2.Columns[0].HeaderText = "Կոդ";
            dataGridView2.Columns[1].HeaderText = "Անվանում";
            dataGridView2.Columns[2].HeaderText = "Չ․մ";
            dataGridView2.Columns[3].HeaderText = "Վերջին գին";
            dataGridView2.Columns[4].HeaderText = "Քանակ";
            dataGridView2.Columns[5].HeaderText = "Գումար";

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Index > 5)
                {
                    column.Visible = false;
                }

            }

            string query2 = $"SELECT * FROM table_215  where Restaurant='{_restaurant}'  ";
            Table_215 = dbHelper.ExecuteQuery(query2);
            Table_215.Columns.Add("Name", typeof(string));
 //           Table_215.Columns.Add("Quantity", typeof(float));
            Table_215.Columns.Add("Amount", typeof(float));

            foreach (DataRow row in Table_215.Rows)
            {
                row["Name"] = row[_language];
                row["Quantity"] = 0;
                row["Amount"] = 0;
            }

  
            string query3 = $"SELECT * FROM table_213  where Restaurant='{_restaurant}'  ";
            Table_213 = dbHelper.ExecuteQuery(query3);
            Table_213.Columns.Add("Name", typeof(string));
            Table_213.Columns.Add("Quantity", typeof(float));
            Table_213.Columns.Add("Amount", typeof(float));
            Table_213.Columns.Add("Changed", typeof(int));
            foreach (DataRow row in Table_213.Rows)
            {
                row["Name"] = row[_language];
                row["Quantity"] = 0;
                row["Amount"] = 0;
                row["Changed"] = 0;
            }

   
            string query7 = $"SELECT * FROM table_111  where Restaurant='{_restaurant}'  ";
            Table_111 = dbHelper.ExecuteQuery(query7);
            Table_111.Columns.Add("Name", typeof(string));
            Table_111.Columns.Add("Quantity", typeof(float));
            Table_111.Columns.Add("Amount", typeof(float));
            Table_111.Columns.Add("Changed", typeof(int));
            foreach (DataRow row in Table_111.Rows)
            {
                row["Name"] = row[_language];
                row["Quantity"] = 0;
                row["Amount"] = 0;
                row["Changed"] = 0;
            }

            string query4 = $"SELECT * FROM department  where Restaurant='{_restaurant}' ";
            Table_Department = dbHelper.ExecuteQuery(query4);
            Table_Department_ = dbHelper.ExecuteQuery(query4);
            foreach (DataRow row in Table_Department.Rows)
            {
                row["Name"] = row[_language];
            }
            foreach (DataRow row in Table_Department_.Rows)
            {
                row["Name"] = row[_language];
            }
            DepartmentComboBox.DataSource = Table_Department.DefaultView;
            DepartmentComboBox.Text = "";
            DepartmentComboBox.DisplayMember = "Name";


            string query5 = $"SELECT * FROM partners where Restaurant='{_restaurant}' AND Groupp='{0}'  ";
            Table_Partners = dbHelper.ExecuteQuery(query5);
            foreach (DataRow row in Table_Partners.Rows)
            {
                row["Name"] = row[_language];
            }

            PartnersComboBox.DisplayMember = "Name";
            PartnersComboBox.DataSource = Table_Partners.DefaultView;
            PartnersComboBox.Text = "";

            string query6 = $"SELECT * FROM partners  where Restaurant='{_restaurant}' AND Groupp='{1}' ";
            Table_Outgo = dbHelper.ExecuteQuery(query6);
            foreach (DataRow row in Table_Outgo.Rows)
            {
                row["Name"] = row[_language];
            }
            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

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
            string query1 = $"SELECT * FROM ControlsPurchase  ";
            ControlsPurchase = dbHelper.ExecuteQuery(query1);
            foreach (Control control in panel1.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsPurchase.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel3.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsPurchase.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel4.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsPurchase.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel5.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsPurchase.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                string columnName = dataGridView1.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsPurchase.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView1.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }
            }

            for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
            {
                string columnName = dataGridView2.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsPurchase.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView2.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }
            }
            connection.Close();
        }



        private void PortnersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PartnersComboBox.DataSource == Table_Partners.DefaultView)
            {
                DataRow[] foundRows = Table_Partners.Select($"Name = '{PartnersComboBox.Text}' ");
                foreach (DataRow row in foundRows)
                {
                    PartnersIdBox.Text = row["Id"].ToString().Trim();
                }
                PartnersIdBox.BackColor = Color.White;
            }
            else
            {
                DataRow[] foundRows = Table_Department_.Select($"Name = '{PartnersComboBox.Text}' ");
                foreach (DataRow row in foundRows)
                {
                    PartnersIdBox.Text = row["Id"].ToString().Trim();
                }
                PartnersIdBox.BackColor = Color.White;
            }
            if (DepartmentIdBox.BackColor == Color.White)
            {
                dataGridView1.Enabled = true;
                SearchBox.Enabled = true;
            }
        }

        private void radioButton10_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[5].HeaderText = "Գումար";
        }

        private void radioButton9_Click(object sender, EventArgs e)
        {
              dataGridView1.Columns[5].HeaderText = "Գին";
        }

        private void InitForm()
        //Ֆորմայի չափսերը դարձնում ենք լիաէկրան
        {
            float screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            float screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            float kw = this.Width / screenWidth;
            float kh = this.Height / screenHeight;
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

        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down) && dataGridView1.Columns.Count > 0 && dataGridView1.RowCount > 0)
            {
                int desiredColumnIndex = 0;
                int desiredRowIndex = 0; // Index of the first row in the filtered data
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.HeaderText == "Քանակ")
                    {
                        desiredColumnIndex = column.Index;
                        dataGridView1.CurrentCell = dataGridView1.Rows[desiredRowIndex].Cells[desiredColumnIndex];
                        dataGridView1.BeginEdit(true);
                    }

                }


            }

        }
        private void SearchBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down) && dataGridView1.Columns.Count > 0 && dataGridView1.RowCount > 0)
            {
                int desiredColumnIndex = 0;
                int desiredRowIndex = 0; // Index of the first row in the filtered data
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.HeaderText == "Քանակ")
                    {
                        desiredColumnIndex = column.Index;
                        dataGridView1.CurrentCell = dataGridView1.Rows[desiredRowIndex].Cells[desiredColumnIndex];
                        dataGridView1.BeginEdit(true);
                    }

                }
            }
        }
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string txt = SearchBox.Text.Trim();
            if (dataGridView1.DataSource is DataView dataView && dataView.Table == Table_215)
            {
                int department = int.Parse(DepartmentIdBox.Text.Trim());
                dataView.RowFilter = $"Department = {department} AND Name LIKE '%{txt}%'";
                dataGridView1.DataSource = dataView;
            }
            if (dataGridView1.DataSource is DataView dataView1 && dataView1.Table == Table_211)
            {
                dataView = new DataView(Table_211);
                dataView.RowFilter = $"(Code+Name) LIKE '%{txt}%'";
                dataGridView1.DataSource = dataView;
            }
            if (dataGridView1.DataSource is DataView dataView2 && dataView2.Table == Table_213)
            {
                dataView = new DataView(Table_213);
                dataView.RowFilter = $"(Code+Name) LIKE '%{txt}%'";
                dataGridView1.DataSource = dataView;
            }
            if (dataGridView1.DataSource is DataView dataView3 && dataView3.Table == Table_111)
            {
                dataView = new DataView(Table_111);
                dataView.RowFilter = $"(Code+Name) LIKE '%{txt}%'";
                dataGridView1.DataSource = dataView;
            }
        }

        private void SearchBox_Enter(object sender, EventArgs e)
        {
            SearchBox.Text = "";
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            dataGridView.Rows[e.RowIndex].Cells["Amount"].Value = 0;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewCell currentCell = dgv.CurrentCell;

            if (currentCell != null )
            {
                int rowIndex = currentCell.RowIndex;
                int columnIndex = currentCell.ColumnIndex;
                object cellValue = dgv.CurrentCell.Value;

                string codevalue = "";
                string namevalue = "";
                float costprice = 0;
                float quantity = 0;
                string cname = "";
                float salesamount = 0;
                float costamount = 0;
                float amount = 0;
                int quantindex = 0;
                int amountindex = 0;
                string unitvalue = "";
                cname = dataGridView1.Columns[columnIndex].HeaderText;
                for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
                {
                    if (dataGridView1.Columns[colIndex].DataPropertyName == "Code") codevalue = dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    if (dataGridView1.Columns[colIndex].DataPropertyName == "Name") namevalue = dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    if (dataGridView1.Columns[colIndex].DataPropertyName == "Unit") unitvalue = dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    if (dataGridView1.Columns[colIndex].DataPropertyName == "CostPrice") costprice = float.Parse(dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString());
                    if (dataGridView1.Columns[colIndex].DataPropertyName == "Quantity")
                    {
                        quantity = float.Parse(dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString());
                        quantindex = colIndex;
                    }
                    if (dataGridView1.Columns[colIndex].DataPropertyName == "Amount")
                    {
                        amount = float.Parse(dataGridView1.Rows[rowIndex].Cells[colIndex].Value.ToString());
                        amountindex = colIndex;
                    }
                }
                //costamount = costprice * quantity;
                //amount = costamount;
                if (radioButton10.Checked && quantity !=0)
                {
                    costamount = amount;
                    costprice= amount / quantity;
                }
                if ((radioButton3.Checked || radioButton2.Checked || radioButton9.Checked) && !radioButton4.Checked)
                {
                    costamount = costprice * quantity;
                    amount = costamount;
                }
                if (radioButton4.Checked && radioButton10.Checked)
                {
                    salesamount = amount;

                }
                if (radioButton4.Checked && radioButton9.Checked)
                {
                    salesamount = costprice * quantity;
                    amount = salesamount;
                }

                int departmentin = 0;
                int departmentout = 0;
                int debitor = 0;
                int kreditor = 0;
                string debet = "";
                string kredit = "";
                string note = "";
                if (radioButton1.Checked)
                {
                    note = "purchased";
                    departmentin = int.Parse(DepartmentIdBox.Text);
                    kreditor = int.Parse(PartnersIdBox.Text);

                    if (dataGridView1.DataSource is DataView dataView && dataView.Table == Table_211 && quantity != 0)
                    {
                        debet = "2111";
                        kredit = "5211";
                        DataRow[] foundRows = Table_211.Select($"Code = '{codevalue}' ");
                        foundRows[0]["Changed"] = 1;
                        foundRows[0]["CostPrice"] = costprice;

                    }
                    if (dataGridView1.DataSource is DataView dataView1 && dataView1.Table == Table_213)
                    {
                        DataRow[] foundRows = Table_213.Select($"Code = '{codevalue}' ");
                        foundRows[0]["Changed"] = 1;
                        foundRows[0]["CostPrice"] = costprice;
                        debet = "2131";
                        kredit = "5211";
                    }
                    if (dataGridView1.DataSource is DataView dataView2 && dataView2.Table == Table_111)
                    {
                        DataRow[] foundRows = Table_111.Select($"Code = '{codevalue}' ");
                        foundRows[0]["Changed"] = 1;
                        foundRows[0]["CostPrice"] = costprice;
                        debet = "1111";
                        kredit = "5211";
                    }

                }
                if (radioButton2.Checked)
                {
                    note = "moved";
                    departmentin = int.Parse(DepartmentIdBox.Text);
                    departmentout = int.Parse(PartnersIdBox.Text);
                    if (dataGridView1.DataSource is DataView dataView && dataView.Table == Table_211)
                    {
                        debet = "2111";
                        kredit = "2111";
                    }
                    if (dataGridView1.DataSource is DataView dataView1 && dataView1.Table == Table_213)
                    {
                        debet = "2131";
                        kredit = "2131";
                    }
                    if (dataGridView1.DataSource is DataView dataView2 && dataView2.Table == Table_111)
                    {
                        debet = "1111";
                        kredit = "1111";
                    }
                }
                if (radioButton3.Checked)
                {
                    note = "spent";
                    debitor = int.Parse(PartnersIdBox.Text);
                    departmentout = int.Parse(PartnersIdBox.Text);
                                        
                    
                    if (dataGridView1.DataSource is DataView dataView && dataView.Table == Table_211)
                    {
                        debet = "7111";
                        kredit = "2111";
                    }
                    if (dataGridView1.DataSource is DataView dataView1 && dataView1.Table == Table_213)
                    {
                        debet = "7131";
                        kredit = "2131";
                    }
                    if (dataGridView1.DataSource is DataView dataView2 && dataView2.Table == Table_111)
                    {
                        debet = "7111";
                        kredit = "1111";
                    }
                }
                if (radioButton4.Checked)
                {
                    note = "sold";
                    departmentout = int.Parse(PartnersIdBox.Text);
                    debitor = int.Parse(DepartmentIdBox.Text);
                    if (dataGridView1.DataSource is DataView dataView && dataView.Table == Table_211)
                    {
                        debet = "2211";
                        kredit = "2111";
                    }
                    if (dataGridView1.DataSource is DataView dataView1 && dataView1.Table == Table_213)
                    {
                        debet = "2211";
                        kredit = "2131";
                    }
                    if (dataGridView1.DataSource is DataView dataView2 && dataView2.Table == Table_111)
                    {
                        debet = "2211";
                        kredit = "1111";
                    }
                    if (dataGridView1.DataSource is DataView dataView3 && dataView3.Table == Table_215)
                    {
                        debet = "2211";
                        kredit = "2151";
                    }
                }
                if (radioButton5.Checked)
                {
                    note = "fromnest";
                    departmentin = int.Parse(DepartmentIdBox.Text);
                    if (dataGridView1.DataSource is DataView dataView3 && dataView3.Table == Table_215)
                    {
                        debet = "2151";
                        kredit = "6111";
                    }
                }
                //  if (((radioButton1.Checked || radioButton4.Checked) && columnIndex == 5 && quantity != 0)
                //      || (!radioButton1.Checked && !radioButton4.Checked && columnIndex == 4))
                //  {
                float sum = 0;
                if ((radioButton10.Checked && amount !=0 && quantity != 0) ||
                    ((radioButton3.Checked || radioButton2.Checked || radioButton9.Checked) && quantity != 0))
                { 
                    DataRow newRow = Table_Purchase.NewRow();  
                    Table_Purchase.Rows.Add(newRow);
                    newRow["Code"] = codevalue;
                    newRow["Name"] = namevalue;
                    newRow["Unit"] = unitvalue;
                    newRow["Quantity"] = quantity;
                    newRow["CostPrice"] = costprice;
                    newRow["CostAmount"] = costamount;
                    newRow["Amount"] = amount;
                    newRow["SalesAmount"] = salesamount;
                    newRow["Operator"] = _parameter1;
                    newRow["Restaurant"] = _restaurant;
                    newRow["Debet"] = debet;
                    newRow["Kredit"] = kredit;
                    newRow["DepartmentIn"] = departmentin;
                    newRow["DepartmentOut"] = departmentout;
                    newRow["Kreditor"] = kreditor;
                    newRow["Debitor"] = debitor;
                    newRow["Note"] = note;
                    newRow["Date"] = dateTimePicker1.Value;
                    newRow["DateOfEntry"] = DateTime.Now;
                    newRow["RestaurantIn"] = 0;
                    newRow["RestaurantOut"] = 0;
                    newRow["Restaurant"] = 0;

                    //if (radioButton1.Checked && radioButton9.Checked)
                    //{
                    //    dataGridView1.Rows[rowIndex].Cells[3].Value = costprice;
                    //}
                    //if (radioButton1.Checked && radioButton10.Checked && quantity != 0)
                    //{
                    //    dataGridView1.Rows[rowIndex].Cells[3].Value = costamount / quantity;

                    //}

                    dataGridView1.Rows[rowIndex].Cells[ amountindex].Value = 0;
                    dataGridView1.Rows[rowIndex].Cells[quantindex].Value = 0;
                    SaveButton1.Visible = true;
                    SaveButton1.Enabled = true;
                    dgv.EndEdit();
                    if (checkBox1.Checked)
                    {
                        SearchBox.Focus();
                    }
                    foreach (DataRow row in Table_Purchase.Rows)
                    {
                        if (radioButton1.Checked) sum = sum + float.Parse(row["CostAmount"].ToString());
                        if (radioButton4.Checked) sum = sum + float.Parse(row["SalesAmount"].ToString());
                    }
                    SumBox.Text = sum.ToString();
                }
            }
        }



        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            radioButton5.Visible = false;
            panel1.Visible = true;
            dataGridView1.Columns[2].Width = 50;
            if (SaveButton1.Visible == true)
            {
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton11.Checked = false;
                if (panel3.Tag.ToString() == "radioButton6") radioButton6.Checked = true;
                if (panel3.Tag.ToString() == "radioButton7") radioButton7.Checked = true;
                if (panel3.Tag.ToString() == "radioButton8") radioButton8.Checked = true;
                if (panel3.Tag.ToString() == "radioButton11") radioButton11.Checked = true;
                SaveButton1.Enabled = false;
                SaveButton2.Visible = true;
                SaveButton3.Visible = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                DateLabel.Visible = false;
                SupplierLabel.Visible = false;
                PartnersIdBox.Visible = false;
                PartnersComboBox.Visible = false;
                dateTimePicker1.Visible = false;

                SumBox.Visible = false;
                DepartmentLabel.Visible = false;
                DepartmentIdBox.Visible = false;
                DepartmentComboBox.Visible = false;

                SearchBox.Visible = false;
                dataGridView1.Visible = false;
                dataGridView1.Enabled = false;
                dataGridView2.Visible = false;

                dataView = new DataView(Table_211);
                dataGridView1.DataSource = dataView;
                panel3.Tag = "radioButton6";
            }
        }
        private void radioButton7_Click(object sender, EventArgs e)
        {
            radioButton5.Visible = false;
            panel1.Visible = true;
            dataGridView1.Columns[2].Width = 50;
            if (SaveButton1.Visible == true)
            {
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton11.Checked = false;
                if (panel3.Tag.ToString() == "radioButton6") radioButton6.Checked = true;
                if (panel3.Tag.ToString() == "radioButton7") radioButton7.Checked = true;
                if (panel3.Tag.ToString() == "radioButton8") radioButton8.Checked = true;
                if (panel3.Tag.ToString() == "radioButton11") radioButton11.Checked = true;
                SaveButton1.Enabled = false;
                SaveButton2.Visible = true;
                SaveButton3.Visible = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                DateLabel.Visible = false;
                SupplierLabel.Visible = false;
                PartnersIdBox.Visible = false;
                PartnersComboBox.Visible = false;
                dateTimePicker1.Visible = false;

                SumBox.Visible = false;
                DepartmentLabel.Visible = false;
                DepartmentIdBox.Visible = false;
                DepartmentComboBox.Visible = false;

                SearchBox.Visible = false;
                dataGridView1.Visible = false;
                dataGridView1.Enabled = false;
                dataGridView2.Visible = false;
                dataView = new DataView(Table_213);
                dataGridView1.DataSource = dataView;
                panel3.Tag = "radioButton7";
            }
        }
        private void radioButton8_Click(object sender, EventArgs e)
        {

            if (SaveButton1.Visible == true)
            {
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton11.Checked = false;
                if (panel3.Tag.ToString() == "radioButton6") radioButton6.Checked = true;
                if (panel3.Tag.ToString() == "radioButton7") radioButton7.Checked = true;
                if (panel3.Tag.ToString() == "radioButton8") radioButton8.Checked = true;
                if (panel3.Tag.ToString() == "radioButton11") radioButton11.Checked = true;
                SaveButton1.Enabled = false;
                SaveButton2.Visible = true;
                SaveButton3.Visible = true;
            }
            else
            {
                radioButton5.Visible = true;
                dataGridView1.Columns[2].DataPropertyName = "Department";
                dataGridView1.Columns[2].HeaderText = "բաժ";
                dataGridView1.Columns[2].Width = 50;
                panel1.Visible = true;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                DateLabel.Visible = false;
                SupplierLabel.Visible = false;
                PartnersIdBox.Visible = false;
                PartnersComboBox.Visible = false;
                dateTimePicker1.Visible = false;

                DepartmentLabel.Visible = false;
                DepartmentIdBox.Visible = false;
                DepartmentComboBox.Visible = false;

                SumBox.Visible = false;
                SearchBox.Visible = false;
                dataGridView1.Visible = false;
                dataGridView1.Enabled = false;
                dataGridView2.Visible = false;
                dataView = new DataView(Table_215);
                dataGridView1.DataSource = dataView;
                panel3.Tag = "radioButton8";

            }
        }

        private void SaveButton3_Click(object sender, EventArgs e)
        {
            SaveButton1.Visible = false;
            SaveButton2.Visible = false;
            SaveButton3.Visible = false;
            SaveButton1.Enabled = true;
            //***********հեռացնում ենք Table_Purchase-ի տողերը 
            List<DataRow> rowsToRemove = new List<DataRow>();
            foreach (DataRow row in Table_Purchase.Rows)
            {
                rowsToRemove.Add(row);
            }
            foreach (DataRow rowToRemove in rowsToRemove)
            {
                Table_Purchase.Rows.Remove(rowToRemove);
            }

        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (SaveButton1.Visible == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                if (panel1.Tag.ToString() == "radioButton1") radioButton1.Checked = true;
                if (panel1.Tag.ToString() == "radioButton2") radioButton2.Checked = true;
                if (panel1.Tag.ToString() == "radioButton3") radioButton3.Checked = true;
                if (panel1.Tag.ToString() == "radioButton4") radioButton4.Checked = true;
                if (panel1.Tag.ToString() == "radioButton5") radioButton5.Checked = true;
                SaveButton1.Enabled = false;
                SaveButton2.Visible = true;
                SaveButton3.Visible = true;
            }
            else
            {
                panel1.Tag = "radioButton1";
                DateLabel.Visible = true;
                SupplierLabel.Visible = true;
                DataRow[] foundRows = ControlsPurchase.Select($"TRIM(Name) = 'SupplierLabel'");
                SupplierLabel.Text = foundRows[0][_language].ToString();
                PartnersIdBox.Visible = true;
                PartnersComboBox.Visible = true;
                PartnersComboBox.DisplayMember = "Name";
                PartnersComboBox.DataSource = Table_Partners.DefaultView;
                PartnersComboBox.Text = "";
                PartnersIdBox.Text = "";


                dateTimePicker1.Visible = true;

                DepartmentLabel.Visible = true;
                //DepartmentLabel.Text = "Բաժին +";
                DataRow[] foundRows1 = ControlsPurchase.Select($"TRIM(Name) = 'DepartmentLabel'");
                DepartmentLabel.Text = foundRows1[0][_language].ToString();
                DepartmentIdBox.Visible = true;
                DepartmentComboBox.Visible = true;
                DepartmentComboBox.DisplayMember = "Name";
                DepartmentComboBox.DataSource = Table_Department.DefaultView;

                checkBox1.Visible = true;
                SumBox.Visible = true;
                panel5.Visible = true;
                radioButton9.Visible = true;
                radioButton10.Visible = true;
                SearchBox.Visible = true;
                dataGridView1.Visible = true;
                dataGridView1.Enabled = false;
                dataGridView2.Visible = true;
                DepartmentIdBox.Text = "";
                DepartmentComboBox.Text = "";
                PartnersIdBox.BackColor = Color.Orange;
                DepartmentIdBox.BackColor = Color.Orange;
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {

            radioButton10.Checked = false;
            radioButton9.Checked = false;
            panel5.Visible = false;
            if (SaveButton1.Visible == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                if (panel1.Tag.ToString() == "radioButton1") radioButton1.Checked = true;
                if (panel1.Tag.ToString() == "radioButton2") radioButton2.Checked = true;
                if (panel1.Tag.ToString() == "radioButton3") radioButton3.Checked = true;
                if (panel1.Tag.ToString() == "radioButton4") radioButton4.Checked = true;
                if (panel1.Tag.ToString() == "radioButton5") radioButton5.Checked = true;
                SaveButton1.Enabled = false;
                SaveButton2.Visible = true;
                SaveButton3.Visible = true;
            }
            else
            {
                panel1.Tag = "radioButton2";
                DateLabel.Visible = true;
                SupplierLabel.Visible = true;
                //SupplierLabel.Text = "Բաժին -";
                DataRow[] foundRows1 = ControlsPurchase.Select($"TRIM(Name) = 'SupplierLabel'");
                SupplierLabel.Text = foundRows1[0][_language].ToString()+" -";
                PartnersIdBox.Visible = true;
                PartnersComboBox.Visible = true;
                PartnersComboBox.DisplayMember = "Name";
                PartnersComboBox.DataSource = Table_Department_.DefaultView;
                PartnersComboBox.Text = "";
                PartnersIdBox.Text = "";

                dateTimePicker1.Visible = true;

                DepartmentLabel.Visible = true;
                DataRow[] foundRows2 = ControlsPurchase.Select($"TRIM(Name) = 'SupplierLabel'");
                DepartmentLabel.Text = foundRows2[0][_language].ToString()+" +";
                DepartmentIdBox.Visible = true;
                DepartmentComboBox.Visible = true;
                DepartmentComboBox.DisplayMember = "Name";
                DepartmentComboBox.DataSource = Table_Department.DefaultView;
                DepartmentComboBox.Text = "";
                DepartmentIdBox.Text = "";

                checkBox1.Visible = true;
                SumBox.Visible = true;
                SearchBox.Visible = true;
                dataGridView1.Visible = true;
                dataGridView1.Enabled = false;
                dataGridView2.Visible = true;

                PartnersIdBox.BackColor = Color.Orange;
                DepartmentIdBox.BackColor = Color.Orange;
            }
        }
        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioButton10.Checked = false;
            radioButton9.Checked = false;
            panel5.Visible = false;
            if (SaveButton1.Visible == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                if (panel1.Tag.ToString() == "radioButton1") radioButton1.Checked = true;
                if (panel1.Tag.ToString() == "radioButton2") radioButton2.Checked = true;
                if (panel1.Tag.ToString() == "radioButton3") radioButton3.Checked = true;
                if (panel1.Tag.ToString() == "radioButton4") radioButton4.Checked = true;
                if (panel1.Tag.ToString() == "radioButton5") radioButton5.Checked = true;
                SaveButton1.Enabled = false;
                SaveButton2.Visible = true;
                SaveButton3.Visible = true;
            }
            else
            {
                panel1.Tag = "radioButton3";
                DateLabel.Visible = true;
                SupplierLabel.Visible = true;
                //SupplierLabel.Text = "Բաժին -";
                DataRow[] foundRows1 = ControlsPurchase.Select($"TRIM(Name) = 'SupplierLabel'");
                SupplierLabel.Text = foundRows1[0][_language].ToString()+" -";
                PartnersIdBox.Visible = true;
                PartnersComboBox.Visible = true;
                PartnersComboBox.DisplayMember = "Name";
                PartnersComboBox.DataSource = Table_Department_.DefaultView;
                PartnersComboBox.Text = "";
                PartnersIdBox.Text = "";

                dateTimePicker1.Visible = true;

                SumBox.Visible = true;
                DepartmentLabel.Visible = true;
                //DepartmentLabel.Text = "Ծախս";
                DataRow[] foundRows2 = ControlsPurchase.Select($"TRIM(Name) = 'DepartmentLabel'");
                DepartmentLabel.Text = foundRows2[0][_language].ToString() ;
                DepartmentIdBox.Visible = true;
                DepartmentComboBox.Visible = true;
                DepartmentComboBox.DisplayMember = "Name";
                DepartmentComboBox.DataSource = Table_Outgo.DefaultView;
                DepartmentIdBox.Text = "";
                DepartmentComboBox.Text = "";

                checkBox1.Visible = true;
                SearchBox.Visible = true;
                dataGridView1.Visible = true;
                dataGridView1.Enabled = false;
                dataGridView2.Visible = true;

                PartnersIdBox.BackColor = Color.Orange;
                DepartmentIdBox.BackColor = Color.Orange;
            }
        }
        private void radioButton4_Click(object sender, EventArgs e)
        {
            if (SaveButton1.Visible == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                if (panel1.Tag.ToString() == "radioButton1") radioButton1.Checked = true;
                if (panel1.Tag.ToString() == "radioButton2") radioButton2.Checked = true;
                if (panel1.Tag.ToString() == "radioButton3") radioButton3.Checked = true;
                if (panel1.Tag.ToString() == "radioButton4") radioButton4.Checked = true;
                if (panel1.Tag.ToString() == "radioButton5") radioButton5.Checked = true;
                SaveButton1.Enabled = false;
                SaveButton2.Visible = true;
                SaveButton3.Visible = true;
            }
            else
            {
                panel1.Tag = "radioButton4";
                DateLabel.Visible = true;
                SupplierLabel.Visible = true;
                //SupplierLabel.Text = "Բաժին -";
                DataRow[] foundRows2 = ControlsPurchase.Select($"TRIM(Name) = 'SupplierLabel'");
                SupplierLabel.Text = foundRows2[0][_language].ToString();
                PartnersIdBox.Visible = true;
                PartnersComboBox.Visible = true;
                PartnersComboBox.DisplayMember = "Name";
                PartnersComboBox.DataSource = Table_Department_.DefaultView;
                PartnersComboBox.Text = "";
                PartnersIdBox.Text = "";

                dateTimePicker1.Visible = true;

                DepartmentLabel.Visible = true;
                //DepartmentLabel.Text = "Պարտապան";
                DataRow[] foundRows3 = ControlsPurchase.Select($"TRIM(Name) = 'DepartmentLabel'");
                DepartmentLabel.Text = foundRows3[0][_language].ToString();
                DepartmentIdBox.Visible = true;
                DepartmentComboBox.Visible = true;
                DepartmentComboBox.DisplayMember = "Name";
                DepartmentComboBox.DataSource = Table_Partners.DefaultView;
                DepartmentIdBox.Text = "";
                DepartmentComboBox.Text = "";

                checkBox1.Visible = true;
                SumBox.Visible = true;
                panel5.Visible = true;
                radioButton9.Visible = true;
                radioButton10.Visible = true;
                SearchBox.Visible = true;
                dataGridView1.Visible = true;
                dataGridView1.Enabled = false;
                dataGridView2.Visible = true;
                if (radioButton9.Checked) dataGridView1.Columns[5].HeaderText = "Գին";
                if (radioButton10.Checked) dataGridView1.Columns[5].HeaderText = "Գումար";

                PartnersIdBox.BackColor = Color.Orange;
                DepartmentIdBox.BackColor = Color.Orange;
            }
        }
        private void radioButton5_Click(object sender, EventArgs e)
        {
            radioButton10.Checked = false;
            radioButton9.Checked = false;
            panel5.Visible = false;
            if (SaveButton1.Visible == true)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                if (panel1.Tag.ToString() == "radioButton1") radioButton1.Checked = true;
                if (panel1.Tag.ToString() == "radioButton2") radioButton2.Checked = true;
                if (panel1.Tag.ToString() == "radioButton3") radioButton3.Checked = true;
                if (panel1.Tag.ToString() == "radioButton4") radioButton4.Checked = true;
                if (panel1.Tag.ToString() == "radioButton5") radioButton5.Checked = true;
                SaveButton1.Enabled = false;
                SaveButton2.Visible = true;
                SaveButton3.Visible = true;
            }
            else
            {
                panel1.Tag = "radioButton5";
                DateLabel.Visible = true;
                SupplierLabel.Visible = true;
                //SupplierLabel.Text = "մուտք սեղանից";
                DataRow[] foundRows4 = ControlsPurchase.Select($"TRIM(Name) = 'SupplierLabel'");
                SupplierLabel.Text = foundRows4[0][_language].ToString();
                PartnersIdBox.Visible = false;
                PartnersComboBox.Visible = false;
                // PartnersComboBox.DisplayMember = "Name";
                // PartnersComboBox.DataSource = Table_Partners.DefaultView;
                PartnersComboBox.Text = "";
                PartnersIdBox.Text = "";
                PartnersIdBox.BackColor = Color.White;

                dateTimePicker1.Visible = true;

                DepartmentLabel.Visible = true;
                //DepartmentLabel.Text = "Բաժին +";
                DataRow[] foundRows5 = ControlsPurchase.Select($"TRIM(Name) = 'DepartmentLabel'");
                DepartmentLabel.Text = foundRows5[0][_language].ToString()+" +";
                DepartmentIdBox.Visible = true;
                DepartmentComboBox.Visible = true;
                DepartmentComboBox.DisplayMember = "Name";
                DepartmentComboBox.DataSource = Table_Department.DefaultView;

                checkBox1.Visible = true;
                SumBox.Visible = true;
                SearchBox.Visible = true;
                dataGridView1.Visible = true;
                dataGridView1.Enabled = false;
                dataGridView2.Visible = true;
                DepartmentIdBox.Text = "";
                DepartmentComboBox.Text = "";
                DepartmentIdBox.BackColor = Color.Orange;
                dataView = new DataView(Table_215);
            }
        }

        private void radioButton11_Click(object sender, EventArgs e)
        {
            radioButton5.Visible = false;
            panel1.Visible = true;
            dataGridView1.Columns[2].Width = 50;
            if (SaveButton1.Visible == true)
            {
                radioButton6.Checked = false;
                radioButton7.Checked = false;
                radioButton8.Checked = false;
                radioButton11.Checked = false;
                if (panel3.Tag.ToString() == "radioButton6") radioButton6.Checked = true;
                if (panel3.Tag.ToString() == "radioButton7") radioButton7.Checked = true;
                if (panel3.Tag.ToString() == "radioButton8") radioButton8.Checked = true;
                if (panel3.Tag.ToString() == "radioButton11") radioButton11.Checked = true;
                SaveButton1.Enabled = false;
                SaveButton2.Visible = true;
                SaveButton3.Visible = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                DateLabel.Visible = false;
                SupplierLabel.Visible = false;
                PartnersIdBox.Visible = false;
                PartnersComboBox.Visible = false;
                dateTimePicker1.Visible = false;

                DepartmentLabel.Visible = false;
                DepartmentIdBox.Visible = false;
                DepartmentComboBox.Visible = false;

                SearchBox.Visible = false;
                dataGridView1.Visible = false;
                dataGridView1.Enabled = false;
                dataGridView2.Visible = false;

                dataView = new DataView(Table_111);
                dataGridView1.DataSource = dataView;
                panel3.Tag = "radioButton11";
            }
        }

        private void Purchase_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }

        }

        private void Purchase_ResizeEnd(object sender, EventArgs e)
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
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DepartmentComboBox.DataSource == Table_Department.DefaultView)
            {

                DataRow[] foundRows = Table_Department.Select($"Name = '{DepartmentComboBox.Text}' ");
                DepartmentIdBox.Text = foundRows[0]["Id"].ToString();
            }
            if (DepartmentComboBox.DataSource == Table_Partners.DefaultView)
            {
                DataRow[] foundRows = Table_Partners.Select($"Name = '{DepartmentComboBox.Text}' ");
                DepartmentIdBox.Text = foundRows[0]["Id"].ToString();
            }
            if (DepartmentComboBox.DataSource == Table_Outgo.DefaultView)
            {
                DataRow[] foundRows = Table_Outgo.Select($"Name = '{DepartmentComboBox.Text}' ");
                DepartmentIdBox.Text = foundRows[0]["Id"].ToString();
            }
            if ((radioButton2.Checked) && DepartmentIdBox.Text == PartnersIdBox.Text)
            {
                PartnersIdBox.Text = "";
                DepartmentIdBox.Text = "";
                DepartmentIdBox.BackColor = Color.Orange;
                PartnersIdBox.BackColor = Color.Orange;
            }
            else
            {
                DepartmentIdBox.BackColor = Color.White;
            }
            if (PartnersIdBox.BackColor == Color.White)
            {
                dataGridView1.Enabled = true;
                SearchBox.Enabled = true;
            }

        }

        private void PartnersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PartnersComboBox.DataSource == Table_Department_.DefaultView)
            {
                DataRow[] foundRows = Table_Department_.Select($"Name = '{PartnersComboBox.Text}' ");
                PartnersIdBox.Text = foundRows[0]["Id"].ToString();
            }
            if (PartnersComboBox.DataSource == Table_Partners.DefaultView)
            {
                DataRow[] foundRows = Table_Partners.Select($"Name = '{PartnersComboBox.Text}' ");
                PartnersIdBox.Text = foundRows[0]["Id"].ToString();
            }

            if (radioButton2.Checked && PartnersIdBox.Text == DepartmentIdBox.Text)
            {
                PartnersIdBox.Text = "";
                DepartmentIdBox.Text = "";
                DepartmentIdBox.BackColor = Color.Orange;
                PartnersIdBox.BackColor = Color.Orange;
            }
            else
            {
                PartnersIdBox.BackColor = Color.White;
            }
            if (DepartmentIdBox.BackColor == Color.White)
            {
                dataGridView1.Enabled = true;
                SearchBox.Enabled = true;
            }
        }

        private void SaveButton1_Click(object sender, EventArgs e)
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
            foreach (DataRow row in Table_Purchase.Rows)
            {

                row["Number"] = number;
                string InsertQuery = $"INSERT INTO actions  (Number,Code,Date,DepartmentIn," +
                    $" DepartmentOut,Debitor, Kreditor,Debet,Kredit,Quantity,CostAmount,SalesAmount, Operator, " +
                    $"RestaurantIn,RestaurantOut, Restaurant, Note) VALUES  (@number, @code, @date, @departmentin,@departmentout," +
                    $" @debitor, @kreditor, @debet, @kredit, @quantity, @costamount, @salesamount, @operator, @restaurantin, @restaurantout, @restaurant, @note)";
                using (SqlCommand updatCommand = new SqlCommand(InsertQuery, connection))
                {
                    updatCommand.Parameters.AddWithValue("@number", row["Number"]);
                    updatCommand.Parameters.AddWithValue("@code", row["Code"]);
                    updatCommand.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    updatCommand.Parameters.AddWithValue("@departmentin", row["DepartmentIn"]);
                    updatCommand.Parameters.AddWithValue("@departmentout", row["DepartmentOut"]);
                    updatCommand.Parameters.AddWithValue("@debitor", row["Debitor"]);
                    updatCommand.Parameters.AddWithValue("@kreditor", row["Kreditor"]);
                    updatCommand.Parameters.AddWithValue("@debet", row["Debet"]);
                    updatCommand.Parameters.AddWithValue("@kredit", row["Kredit"]);
                    updatCommand.Parameters.AddWithValue("@quantity", row["Quantity"]);
                    updatCommand.Parameters.AddWithValue("@costamount", row["CostAmount"]);
                    updatCommand.Parameters.AddWithValue("@salesamount", row["SalesAmount"]);
                    updatCommand.Parameters.AddWithValue("@operator", _parameter1);
                    updatCommand.Parameters.AddWithValue("@restaurantin", row["RestaurantIn"]);
                    updatCommand.Parameters.AddWithValue("@restaurantout", row["RestaurantOut"]);
                    updatCommand.Parameters.AddWithValue("@restaurant", _restaurant);
                    updatCommand.Parameters.AddWithValue("@note", row["Note"]);
                    updatCommand.ExecuteNonQuery();
                }

            }

            if (radioButton1.Checked)
            {
                if (dataGridView1.DataSource is DataView dataView && dataView.Table == Table_211)
                {
                    Save.UpdateTableFromDatatable(connectionString, Table_211, "211_cost", _restaurant);
                }
                if (dataGridView1.DataSource is DataView dataView1 && dataView1.Table == Table_213)
                {
                    Save.UpdateTableFromDatatable(connectionString, Table_213, "213_cost", _restaurant);
                }
                if (dataGridView1.DataSource is DataView dataView2 && dataView2.Table == Table_111)
                {
                    Save.UpdateTableFromDatatable(connectionString, Table_111, "111_cost", _restaurant);
                }
            }

            //***********հեռացնում ենք Table_Purchase-ի տողերը 
            List<DataRow> rowsToRemove = new List<DataRow>();
            foreach (DataRow row in Table_Purchase.Rows)
            {
                rowsToRemove.Add(row);
            }
            foreach (DataRow rowToRemove in rowsToRemove)
            {
                Table_Purchase.Rows.Remove(rowToRemove);
            }
            SaveButton1.Visible = false;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Suppress the Enter key to prevent new line

                // Get the current cell
                DataGridViewCell currentCell = dataGridView1.CurrentCell;

                // Get the next cell
                DataGridViewCell nextCell = null;
                if (currentCell != null)
                {
                    int nextRowIndex = currentCell.RowIndex;
                    int nextColumnIndex = currentCell.ColumnIndex + 1;

                    // Check if we are at the last column
                    if (nextColumnIndex >= dataGridView1.ColumnCount)
                    {
                        nextColumnIndex = 0;
                        nextRowIndex++;
                    }

                    // Check if we are at the last row
                    if (nextRowIndex < dataGridView1.RowCount)
                    {
                        nextCell = dataGridView1[nextColumnIndex, nextRowIndex];
                    }
                }

                // Move to the next cell
                if (nextCell != null && nextCell.Visible && nextCell.ReadOnly == false)
                {
                    dataGridView1.CurrentCell = nextCell;
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0) // Check if cell value is 0
            {
                e.Value = ""; // Set cell value to empty string to hide 0
                e.FormattingApplied = true; // Indicate that the formatting is applied
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0) // Check if cell value is 0
            {
                e.Value = ""; // Set cell value to empty string to hide 0
                e.FormattingApplied = true; // Indicate that the formatting is applied
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string help = FindFolder.Folder("Help");
            string filePath = "";
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";
                richTextBox1.Top = 0;
                richTextBox1.Height = this.Height - 50;
                richTextBox1.Left = HelpButton.Width + 5;
                richTextBox1.Width = this.Width / 2;
                richTextBox1.ReadOnly = true;

                filePath = help + "\\Purchase_" + _language + ".txt";
                string fileContent = File.ReadAllText(filePath);
                richTextBox1.Text = fileContent;
                richTextBox1.Visible = true;
            }
            else
            {
                richTextBox1.Visible = false;
                HelpButton.Text = "?";
            }
        }
    }
}


