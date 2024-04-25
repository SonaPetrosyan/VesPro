using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Media.Media3D;
using System.Reflection.Emit;


namespace WindowsFormsApp4
{
    public partial class Foods : Form
    {
        private int _restaurant;

        private int _editor;

        private string _language;

        private SQLDatabaseHelper dbHelper;

        private DataTable Table_215 = new DataTable();   //Ճաշացուցակն է։

        private DataTable Table_215_Semi = new DataTable();// ճաշերի կիսապատրաստուկներն են

        private DataTable Table_211 = new DataTable();// նյութերն են  

        private DataTable Table_211_Component = new DataTable();// բաղադրիրների ֆայլն է։ Table_211-ի կլոնն է

        private DataTable Resize = new DataTable();

        private DataTable Tab_Language = new DataTable();

        private DataTable EnterCell = new DataTable();

        private DataTable ControlsFoods = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private DataView dataView;

        private DataTable Table_Composition = new DataTable();



        public int TextBox_KeyPress { get; private set; }

        public Foods(int restaurant, int editor, string language)
        {
            _editor = editor;
            _restaurant = restaurant;
            _language = language;

            InitializeComponent();
            //InitForm();


            EnterCell.Columns.Add("value", typeof(string));
            EnterCell.Columns.Add("type", typeof(string));
            EnterCell.Rows.Add("", "");

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);


            string query1 = $"SELECT * FROM Table_211 ";
            Table_211 = dbHelper.ExecuteQuery(query1);

            if (_editor == 0)
            {
                SaveButton.Enabled = false;
                AddButton.Enabled = false;
            }


            //*******************dataGridView4 - ն ենք կառուցում
            string query1_0 = $"SELECT Code,Unit,CostPrice FROM table_211  ";
            Table_211_Component = dbHelper.ExecuteQuery(query1_0);
            Table_211_Component.Columns.Add("Name", typeof(string));
            Table_211_Component.Columns.Add("quantity", typeof(float));
            

            dataView = new DataView(Table_211_Component);
            //Translate.translation(Table_211_Component, Table_211_Component, _language, "2");

            dataView = new DataView(Table_211_Component);
            dataGridView4.DataSource = dataView;
            dataGridView4.Columns[0].DataPropertyName = "Code";
            dataGridView4.Columns[1].DataPropertyName = "Name";
            dataGridView4.Columns[2].DataPropertyName = "Unit";
            dataGridView4.Columns[3].DataPropertyName = "Quantity";

            
            foreach (DataGridViewColumn column in dataGridView4.Columns)
            {
                if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }
            //անուններն ենք տեղադրում
            var query0 = from row1 in Table_211.AsEnumerable()
                        join row2 in Table_211_Component.AsEnumerable()
                        on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                        from subRow2 in gj.DefaultIfEmpty()
                        select new
                        {
                            Row1 = row1,
                            Row2 = subRow2
                        };

            foreach (var item in query0)
            {
                if (item.Row2 != null )
                {
                    item.Row2["Name"] = item.Row1[_language];
                    item.Row2["Costprice"] = item.Row1["Costprice"];
                }
            }


 


            //*******************  dataGridView1-ն ենք կառուցում
             string query3 = $"SELECT * FROM table_215  ";
            Table_215 = dbHelper.ExecuteQuery(query3);
            //Table_215.Columns.Add("Name", typeof(string));
            Table_215.Columns.Add("Changed", typeof(decimal));// DB - ում ֆայլը խմբագրելու համար է
            foreach (DataRow row in Table_215.Rows)
            {
                row["Changed"] = 0;
                //row["Unit"] = "բաժ";
            }
            dataView = new DataView(Table_215);

            dataGridView1.DataSource = dataView;
            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = _language;
            dataGridView1.Columns[2].DataPropertyName = "Unit";
            dataGridView1.Columns[3].DataPropertyName = "Department";
            dataGridView1.Columns[4].DataPropertyName = "SemiPrepared";
            dataGridView1.Columns[5].DataPropertyName = "Printer";
            dataGridView1.Columns[6].DataPropertyName = "Price";
            dataGridView1.Columns[7].DataPropertyName = "Price1";
            dataGridView1.Columns[8].DataPropertyName = "Price2";
            dataGridView1.Columns[9].DataPropertyName = "Price3";
            dataGridView1.Columns[10].DataPropertyName = "Price4";
            dataGridView1.Columns[11].DataPropertyName = "Price5";
            dataGridView1.Columns[12].DataPropertyName = "ATG";
            dataGridView1.Columns[13].DataPropertyName = "InHoll";
            dataGridView1.Columns[14].DataPropertyName = "NonComposite";
             dataGridView1.Columns[0].ReadOnly = true;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 14)
                {
                    column.Visible = false;
                }
            }

            //*******************  dataGridView2-ն ենք կառուցում

            string query4 = $"SELECT * FROM Composition ";
            Table_Composition = dbHelper.ExecuteQuery(query4);
            Table_Composition.Columns.Add("Name", typeof(string));
            Table_Composition.Columns.Add("Changed", typeof(decimal));// DB - ում ֆայլը խմբագրելու համար է

         //*********************տեղադրում ենք անվանումները 
            var query = from row1 in Table_211.AsEnumerable()
                        join row2 in Table_Composition.AsEnumerable()
                        on row1.Field<string>("Code") equals row2.Field<string>("Code_211") into gj
                        from subRow2 in gj.DefaultIfEmpty()
                        select new
                        {
                            Row1 = row1,
                            Row2 = subRow2
                        };

            foreach (var item in query)
            {
                if (item.Row2 != null && item.Row2["Code_211"].ToString().IndexOf("211")==0)
                {
                    item.Row2["Name"] = item.Row1[_language];
                    item.Row2["Costprice"] = item.Row1["Costprice"];
                }
            }

            var query2 = from row1 in Table_215.AsEnumerable()
                        join row2 in Table_Composition.AsEnumerable()
                        on row1.Field<string>("Code") equals row2.Field<string>("Code_211") into gj
                        from subRow2 in gj.DefaultIfEmpty()
                        select new
                        {
                            Row1 = row1,
                            Row2 = subRow2
                        };

            foreach (var item in query2)
            {
                if (item.Row2 != null && item.Row2["Code_211"].ToString().IndexOf("215") == 0)
                {
                    item.Row2["Name"] = item.Row1[_language];
                    item.Row2["Costprice"] = item.Row1["Costprice"];
                }
           }

            //***********************************************
            dataView = new DataView(Table_Composition);

            dataGridView2.DataSource = dataView;

            dataGridView2.Columns[0].DataPropertyName = "Code_211";
            dataGridView2.Columns[1].DataPropertyName = "Name";
            dataGridView2.Columns[2].DataPropertyName = "Unit";
            dataGridView2.Columns[3].DataPropertyName = "CostPrice";
            dataGridView2.Columns[4].DataPropertyName = "Quantity";
            dataGridView2.Columns[5].DataPropertyName = "Neto";
            dataGridView2.Columns[6].DataPropertyName = "Bruto";
            dataGridView2.Columns[7].DataPropertyName = "Note";



            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {

                if (column.Index > 7)
                {
                    column.Visible = false;
                }

            }

            //******************* dataGridView3-ն ենք կառուցում





            string query2_0 = $"SELECT Code,Unit,CostPrice FROM table_215 WHERE SemiPrepared=1 ";
            Table_215_Semi = dbHelper.ExecuteQuery(query2_0);
            Table_215_Semi.Columns.Add("Name", typeof(string));
            Table_215_Semi.Columns.Add("Quantity", typeof(float));


            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }
            //անուններն ենք տեղադրում
            var query01 = from row1 in Table_215.AsEnumerable()
                          join row2 in Table_215_Semi.AsEnumerable()
                          on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                          from subRow2 in gj.DefaultIfEmpty()
                          select new
                          {
                              Row1 = row1,
                              Row2 = subRow2
                          };
            int i = 0;
            foreach (var item in query01)
            {
                i = i + 1;
                if (item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1[_language];
                    item.Row2["Costprice"] = item.Row1["Costprice"];
                }
            }

            dataView = new DataView(Table_215_Semi);
            dataGridView3.DataSource = dataView;
            dataGridView3.Columns[0].DataPropertyName = "Code";
            dataGridView3.Columns[1].DataPropertyName = "Name";
            dataGridView3.Columns[2].DataPropertyName = "Unit";
            dataGridView3.Columns[3].DataPropertyName = "Quantity";

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);


            string query5 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query5);
            foreach (DataRow row in Table_Rest.Rows)
            {
               // this.Text = row["Name"].ToString();
            }

            string query6 = $"SELECT * FROM Languages";
            Tab_Language = dbHelper.ExecuteQuery(query6);

            SetLanguage(_language);
        }

        private void SetLanguage(string lang)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            DataTable ControlsForm1 = new DataTable();
            string query1 = $"SELECT * FROM ControlsFoods  ";
            ControlsFoods = dbHelper.ExecuteQuery(query1);

            foreach (Control control in this.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsFoods.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][lang].ToString();
                }
            }

            foreach (Control control in panel1.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsFoods.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][lang].ToString();
                }
            }
            foreach (Control control in panel2.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsFoods.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][lang].ToString();
                }
            }
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                string columnName = dataGridView1.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsFoods.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView1.Columns[colIndex].HeaderText = foundRows[0][lang].ToString();
                }

            }
            for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
            {
                string columnName = dataGridView2.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsFoods.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView2.Columns[colIndex].HeaderText = foundRows[0][lang].ToString();
                }

            }
            for (int colIndex = 0; colIndex < dataGridView3.Columns.Count; colIndex++)
            {
                string columnName = dataGridView3.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsFoods.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView3.Columns[colIndex].HeaderText = foundRows[0][lang].ToString();
                }

            }
            for (int colIndex = 0; colIndex < dataGridView4.Columns.Count; colIndex++)
            {
                string columnName = dataGridView4.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsFoods.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView4.Columns[colIndex].HeaderText = foundRows[0][lang].ToString();
                }

            }
            connection.Close();
        }




        private void Foods_Load(object sender, EventArgs e)
        {
              
        }

        private void SearchBox_Enter(object sender, EventArgs e)
        {
            SearchBox.Text = string.Empty;
            SearchBox.BackColor = Color.LightGreen;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ReadOnly == true)
            {
                dataGridView1.ReadOnly = false;
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView2.Enabled = true;
                dataGridView3.Enabled = true;
                dataGridView4.Enabled = true;
                AddButton.Visible = true;
            }
            else
            {
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.ReadOnly = true;
                dataGridView2.Enabled = false;
                dataGridView3.Enabled = false;
                dataGridView4.Enabled = false;
                AddButton.Visible = false;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            dataView = new DataView(Table_215);
            if (dataView.Count > 0)
            {
                DataRow newRow = Table_215.NewRow();
                Table_215.Rows.Add(newRow);
                foreach (DataColumn column in Table_215.Columns)
                {
                    string columnName = column.ColumnName;
                    if (Table_215.Columns[columnName].DataType == typeof(string))
                    {
                        newRow[columnName] = "";
                    }
                    else
                    {
                        if (Table_215.Columns[columnName].DataType == typeof(int))
                        {
                            newRow[columnName] = 0;
                        }
                        else
                        {
                            if (Table_215.Columns[columnName].DataType == typeof(decimal))
                            {
                                newRow[columnName] = 0;
                            }
                            else
                            {
                                    newRow[columnName] = 0;
                            }
                        }
                    }
                }
                string maxCode = dataView.Cast<DataRowView>().Max(row => (string)row["Code"]);
                int maxcode = Convert.ToInt32(maxCode) + 1;
                maxCode = maxcode.ToString();
                newRow["Code"] = maxCode;
               // newRow["Price"] = 0;
               // newRow["CostPrice"] = 0;
                newRow["Restaurant"] = _restaurant;
                newRow["Changed"] = 1;


                // Add the new row to the DataTable
                


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

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)//***************
        {
            DataGridView dataGridView = (DataGridView)sender;
        //    DataGridViewCell currentCell = dataGridView.CurrentCell;
            object codeValue = dataGridView.Rows[e.RowIndex].Cells["Code"].Value;

            object priceValue = dataGridView.Rows[e.RowIndex].Cells["price"].Value;

            object costValue = dataGridView.Rows[e.RowIndex].Cells["Costprice"].Value;
            string code_25 = codeValue.ToString().Trim();
            float price = float.Parse(priceValue.ToString());
            float costprice = float.Parse(costValue.ToString());
            this.dataGridView4.Tag = code_25;
            textBox2.Text = "";
            textBox1.Text = "";
            textBox1.Text = costprice.ToString();
            if (costprice != 0)
            {
                textBox2.Text = (price / costprice * 100).ToString();
            }
            dataView = new DataView(Table_Composition);
            dataView.RowFilter = $"Code_215 LIKE '%{code_25}%'";//dataGridView2 ֆիլտռւմ ենք dataGridView1-ի code_215 -ով
            dataGridView2.DataSource = dataView;

        }

        private void dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewCell currentCell = dgv.CurrentCell;

            if (currentCell != null)
            {
                int rowIndex = currentCell.RowIndex;
                int columnIndex = currentCell.ColumnIndex;
                object cellValue = dgv.CurrentCell.Value;

                string codevalue = "";
                string namevalue = "";
                float costprice = 0;

                for (int colIndex = 0; colIndex < Table_215_Semi.Columns.Count; colIndex++)
                {
                    if (dataGridView3.Columns[colIndex].DataPropertyName == "Code")
                    {
                        codevalue = dataGridView3.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    }
                    if (dataGridView3.Columns[colIndex].DataPropertyName == "Name")
                    {
                        namevalue = dataGridView3.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    }
                    if (dataGridView3.Columns[colIndex].DataPropertyName == "CostPrice")
                    {
                        costprice = float.Parse(dataGridView3.Rows[rowIndex].Cells[colIndex].Value.ToString());
                    }
                }

                string cname = dataGridView3.Columns[columnIndex].DataPropertyName;
                if (cellValue != null && cellValue.ToString() != string.Empty && cname == "Quantity" && float.Parse(cellValue.ToString()) > 0)
                {

                    DataRow newRow = Table_Composition.NewRow();
                    Table_Composition.Rows.Add(newRow);
                    newRow["Code_215"] = dataGridView4.Tag.ToString();
                    newRow["Code_211"] = codevalue;
                    newRow["Name"] = namevalue;
                    newRow["Quantity"] = dgv.CurrentCell.Value;
                    newRow["CostPrice"] = costprice;
                    newRow["Changed"] = 1;

                    dgv.CurrentCell.Value = 0;
                    dgv.EndEdit();

                }
                int lastRowIndex = Math.Min(0, Table_Composition.Rows.Count - 2);
                for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
                {
                    if (dataGridView2.Columns[colIndex].Visible)
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[lastRowIndex].Cells[colIndex];
                        dataGridView2.BeginEdit(true);
                        break;
                    }
                }
                SearchBox3.Focus();
            }
        }





        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_215);
            string txt = SearchBox.Text.Trim();
            dataView.RowFilter = $"(Code+{_language}) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }
        private void SearchBox3_TextChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_215_Semi);
            string txt = SearchBox3.Text.Trim();
            dataView.RowFilter = $"(Code+Name) LIKE '%{txt}%'";
            dataGridView3.DataSource = dataView;
        }
        private void SearchBox4_TextChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_211_Component);
            string txt = SearchBox4.Text.Trim();
            dataView.RowFilter = $"(Code+Name) LIKE '%{txt}%'";
            dataGridView4.DataSource = dataView;
        }

        private void SearchBox4_Enter(object sender, EventArgs e)
        {
            SearchBox4.Text = "";
        }

        private void SearchBox3_Enter(object sender, EventArgs e)
        {
            SearchBox3.Text = "";
        }

         private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {

                dataGridView.Rows[e.RowIndex].Cells["Changed"].Value = 1;
                SaveButton.Visible = true;

            }
            SaveButton.BackColor = Color.LightGreen;
            SaveButton.Visible = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            Save_.Save(Table_215, "Table_215", _restaurant);
            Save.UpdateTableFromDatatable(connectionString, Table_Composition, "Composition", _restaurant);
        }

        private void Foods_FormClosing(object sender, FormClosingEventArgs e)
        {
            return;
        }


        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {


        }
        private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewCell currentCell = dgv.CurrentCell;

            if (currentCell != null)
            {
                int rowIndex = currentCell.RowIndex;
                int columnIndex = currentCell.ColumnIndex;
                object cellValue = dgv.CurrentCell.Value;

                string codevalue = "";
                string namevalue = "";
                float costprice = 0;

                for (int colIndex = 0; colIndex < Table_211_Component.Columns.Count; colIndex++)
                {
                    if (dataGridView4.Columns[colIndex].DataPropertyName == "Code")
                    {
                        codevalue = dataGridView4.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    }
                    if (dataGridView4.Columns[colIndex].DataPropertyName == "Name")
                    {
                        namevalue = dataGridView4.Rows[rowIndex].Cells[colIndex].Value.ToString();
                    }
                    if (dataGridView4.Columns[colIndex].DataPropertyName == "CostPrice")
                    {
                        costprice = float.Parse(dataGridView4.Rows[rowIndex].Cells[colIndex].Value.ToString());
                    }
                }

                string cname = dataGridView4.Columns[columnIndex].DataPropertyName;
                if (cellValue != null && cellValue.ToString() != string.Empty && cname == "Quantity" && float.Parse(cellValue.ToString()) > 0)
                {

                    DataRow newRow = Table_Composition.NewRow();
                    Table_Composition.Rows.Add(newRow);
                    newRow["Code_215"] = dataGridView4.Tag.ToString();
                    newRow["Code_211"] = codevalue;
                    newRow["Name"] = namevalue;
                    newRow["Quantity"] = dgv.CurrentCell.Value;
                    newRow["CostPrice"] = costprice;
                    newRow["Changed"] = 1;

                    dgv.CurrentCell.Value = 0;
                    dgv.EndEdit();


                }
                int lastRowIndex = Math.Min(0, Table_Composition.Rows.Count - 2);
                for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
                {
                    if (dataGridView2.Columns[colIndex].Visible)
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[lastRowIndex].Cells[colIndex];
                        dataGridView2.BeginEdit(true);
                        break;
                    }
                }
                SearchBox4.Focus();
            }
        }

        private void Foods_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void Foods_ResizeEnd(object sender, EventArgs e)
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
            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                column.Width = (int)(column.Width * kw);
            }
            foreach (DataGridViewColumn column in dataGridView4.Columns)
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
            richTextBox1.Top = 0;
            richTextBox1.Left = dataGridView3.Left;
            richTextBox1.Width = dataGridView3.Width;
            richTextBox1.Height = this.Height - 20;
        }

        private void SearchBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down) && dataGridView3.Columns.Count > 0 && dataGridView3.RowCount > 0)
            {
                int desiredColumnIndex = 0;
                int desiredRowIndex = 0; // Index of the first row in the filtered data
                foreach (DataGridViewColumn column in dataGridView3.Columns)
                {
                    if (column.DataPropertyName == "Quantity")
                    {
                        desiredColumnIndex = column.Index;
                        dataGridView3.CurrentCell = dataGridView3.Rows[desiredRowIndex].Cells[desiredColumnIndex];
                        if (dataGridView3.CurrentCell != null) dataGridView3.BeginEdit(true);

                    }

                }


            }
        }
        private void SearchBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down) && dataGridView4.Columns.Count > 0 && dataGridView4.RowCount > 0)
            {
                int desiredColumnIndex = 0;
                int desiredRowIndex = 0; // Index of the first row in the filtered data
                foreach (DataGridViewColumn column in dataGridView4.Columns)
                {
                    if (column.DataPropertyName == "Quantity")
                    {
                        desiredColumnIndex = column.Index;
                        dataGridView4.CurrentCell = dataGridView4.Rows[desiredRowIndex].Cells[desiredColumnIndex];
                        if (dataGridView4.CurrentCell != null) dataGridView4.BeginEdit(true);
                    }

                }


            }
        }

        private void button1_Click(object sender, EventArgs e)//Xml է սարքում շտրիխ կոդի համար 
        {
            string xm = "<NewDataSet>";
            string IsP = "1";
            foreach (DataRow row in Table_215.Rows)
            {
                if (row["Unit"].ToString() == "հատ") IsP = "0";
                xm = xm + "<Report>";
                xm = xm + "<CodeSort>" + row["Code"].ToString().Substring(3) + "</CodeSort>";
                xm = xm + "<Code>" + row["Code"].ToString().Substring(3) + "</Code>";
                xm = xm + "<GoodName>" + row[_language].ToString() + "</GoodName>";
                xm = xm + "<PriceOut>" + row["Price1"].ToString() + "</PriceOut>";
                xm = xm + "<SellByDate>100</SellByDate>";
                xm = xm + "<IsPiece>" + IsP + "</IsPiece></Report>";
            }
            xm = xm + "</NewDataSet>";
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            string query = $"TRUNCATE TABLE Weigher";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }

            string query1 = $"INSERT INTO Weigher (Json_data) VALUES (@xm)";
            using (SqlCommand command = new SqlCommand(query1, connection))
            {
                command.Parameters.AddWithValue("@xm", xm);
                command.ExecuteNonQuery();
            }
            button1.Visible = false;
            connection.Close();
        }
        private HelpDialogForm helpDialogForm;

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string help = FindFolder.Folder("Help");
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";
                richTextBox1.Height = this.Height - 50;
                richTextBox1.ReadOnly = true;
                string filePath = help + "\\Foods_"+_language+".txt";
                string fileContent = File.ReadAllText(filePath);

                if (helpDialogForm == null)
                {
                    helpDialogForm = new HelpDialogForm();
                    helpDialogForm.FormClosed += (s, args) => helpDialogForm = null; // Reset the helpDialogForm reference when the form is closed
                }

                helpDialogForm.SetHelpContent(fileContent);
                helpDialogForm.Show();
            }
            else
            {
                HelpButton.Text = "?";
                helpDialogForm?.Close(); // Close the help dialog form if it's open
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the current cell
            DataGridViewCell currentCell = dataGridView1.CurrentCell;
            //dataGridView1.Tag = currentCell.RowIndex.ToString();
            button2.Tag = currentCell.ColumnIndex.ToString();// ֆիքսում ենք ընթացիկ բջիջի ինդեքսները
            checkedListBox1.Tag=currentCell.RowIndex.ToString();

            if (currentCell != null && (currentCell.ColumnIndex == 21 || currentCell.ColumnIndex == 22))
            {
                checkedListBox1.Visible = true;
                button2.Visible = true;
            }
           // this.Text = button2.Tag.ToString() + " , " + dataGridView1.Columns[currentCell.ColumnIndex].DataPropertyName+
           //     " v= "+ dataGridView1.Columns[currentCell.ColumnIndex].ValueType;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowindex = int.Parse(checkedListBox1.Tag.ToString());
            int colindex = int.Parse(button2.Tag.ToString());
            dataGridView1.Rows[rowindex].Cells[colindex].Value = "";
            string val = "";
            for (int i = 1; i < 10; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    val = val + i.ToString() + ",";
                }
            }
            dataGridView1.Rows[rowindex].Cells[colindex].Value =val;
            checkedListBox1.Visible=false;
            button2.Visible=false;

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell currentCell = dataGridView1.CurrentCell;
            button2.Tag = currentCell.ColumnIndex.ToString();// ֆիքսում ենք ընթացիկ բջիջի ինդեքսները
            checkedListBox1.Tag = currentCell.RowIndex.ToString();
            dataGridView1.Rows[currentCell.RowIndex].Cells["Changed"].Value = 1;
            SaveButton.Visible = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                DataRow[] foundRows = Tab_Language.Select($"Language = {dataGridView1.Columns[colIndex].DataPropertyName}");
            }
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


    }
}