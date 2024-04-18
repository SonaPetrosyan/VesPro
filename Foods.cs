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

        private DataTable EnterCell = new DataTable();

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

            string connectionString = "Server=DESKTOP-L1SRCHN\\SQLEXPRESS;Database=CafeRest;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);


            string query1 = $"SELECT * FROM Table_211 ";
            Table_211 = dbHelper.ExecuteQuery(query1);

            if (_editor == 0)
            {
                SaveButton.Enabled = false;
                AddButton.Enabled = false;
            }



            string code = "կոդ", name = "անվանում", dep = "բաժ․", unit = "չափ", pr = "գին", pr1 = "գին1", pr2 = "գին2", pr3 = "գին3", pr4 = "գին4", pr5 = "գին5",
    print = "տպիչ", semi = "Կ․Պ", inh = "սրահ", nonc = "չբաղադրվող",quant="քանակ";
            label4.Text = "Լեզու";
            label2.Text = "բաղադրիչ նյութեր";
            label1.Text = "կիսապատրաստուկ";
            if (_language == "English")
            {
                code = "code"; name = "name"; dep = "depart."; unit = "size"; pr = "price";
                pr1 = "price1"; pr2 = "price2"; pr3 = "price3"; pr4 = "price4"; pr5 = "price5";
                print = "printer"; semi = "S.P"; inh = "hall"; nonc = "non-composite"; quant = "quantity";
                label4.Text = "Language";
                label2.Text = "ingredients";
                label1.Text = "semi-prepared";
            }
            if (_language == "German")
            {
                code = "code"; name = "name"; dep = "Abteilung"; unit = "Größe"; pr = "Preis";
                pr1 = "Preis1"; pr2 = "Preis2"; pr3 = "Preis3"; pr4 = "Preis4"; pr5 = "Preis5";
                print = "Drucker"; semi = "Halb"; inh = "Halle"; nonc = "nicht zusammengesetzt"; quant = "Menge";
                label4.Text = "Sprache";
                label2.Text = "Zutaten";
                label1.Text = "semi-prepared";
            }
            if (_language == "Espaniol")
            {
                code = "código"; name = "nombre"; dep = "depart."; unit = "tamaño"; pr = "precio";
                pr1 = "precio1"; pr2 = "precio2"; pr3 = "precio3"; pr4 = "precio4"; pr5 = "precio5";
                print = "impresora"; semi = "semipr."; inh = "sala"; nonc = "no compuesto"; quant = "cantidad";
                label4.Text = "Idioma";
                label2.Text = "ingredientes";
                label1.Text = "semipreparado";
            }
            if (_language == "Russian")
            {
                code = "код"; name = "имя"; dep = "отдел"; unit = "размер"; pr = "цена";
                pr1 = "цена1"; pr2 = "цена2"; pr3 = "цена3"; pr4 = "цена4"; pr5 = "цена5";
                print = "принтер"; semi = "полуф."; inh = "зал"; nonc = "некомпозитный";quant = "кол_во";
                label4.Text = "Язык";
                label2.Text = "ингредиенты";
                label1.Text = "полуготовый";
            }

            //*******************dataGridView4 - ն ենք կառուցում
            string query1_0 = $"SELECT Code,Unit,Armenian,English,Russian,German,Espaniol,CostPrice FROM table_211  ";
            Table_211_Component = dbHelper.ExecuteQuery(query1_0);
            Table_211_Component.Columns.Add("quantity", typeof(float));
            dataView = new DataView(Table_211_Component);
            //Translate.translation(Table_211_Component, Table_211_Component, _language, "2");

            dataView = new DataView(Table_211_Component);
            dataGridView4.DataSource = dataView;
            dataGridView4.Columns[1].DataPropertyName = "Code";
            dataGridView4.Columns[0].DataPropertyName = _language;
            dataGridView4.Columns[2].DataPropertyName = "Unit";
            dataGridView4.Columns[3].DataPropertyName = "Quantity";
            
            foreach (DataGridViewColumn column in dataGridView4.Columns)
            {
                if (column.DataPropertyName == "Code") column.HeaderText= code;
                if (column.DataPropertyName == _language) column.HeaderText = name;
                if (column.DataPropertyName == "Unit") column.HeaderText = unit;
                if (column.DataPropertyName == "Quantity") column.HeaderText = quant;
                if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }

            //******************* dataGridView3-ն ենք կառուցում





            string query2_0 = $"SELECT Code,Unit,Quantity,CostPrice,Armenian,English,Russian,German,Espaniol FROM table_215 WHERE SemiPrepared=1 ";
            Table_215_Semi = dbHelper.ExecuteQuery(query2_0);
           //Translate.translation(Table_215_Semi, Table_215_Semi, _language, "2");
            Table_215_Semi.Columns.Add("quantity", typeof(float));
            dataView = new DataView(Table_215_Semi);
            dataGridView3.DataSource = dataView;
            dataGridView3.Columns[1].DataPropertyName = "Code";
            dataGridView3.Columns[0].DataPropertyName = _language;
            dataGridView3.Columns[2].DataPropertyName = "Unit";
            dataGridView3.Columns[3].DataPropertyName = "Quantity";

            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                if (column.DataPropertyName == "Code") column.HeaderText = code;
                if (column.DataPropertyName == _language) column.HeaderText = name;
                if (column.DataPropertyName == "Unit") column.HeaderText = unit;
                if (column.DataPropertyName == "Quantity") column.HeaderText = quant;
                if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }



            //*******************  dataGridView1-ն ենք կառուցում
            string query3 = $"SELECT Code,Armenian,English,German,Espaniol,Russian,Unit,Department,SemiPrepared," +
                $"Price,Price1,Price2,Price3,Price4,Price5,Printer,ATG,InHoll,Costprice,Groupp,Restaurant,NonComposite,Existent FROM table_215  ";
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
            dataGridView1.Columns[4].DataPropertyName = "Price";
            dataGridView1.Columns[5].DataPropertyName = "Price1";
            dataGridView1.Columns[6].DataPropertyName = "Price2";
            dataGridView1.Columns[7].DataPropertyName = "Price3";
            dataGridView1.Columns[8].DataPropertyName = "Price4";
            dataGridView1.Columns[9].DataPropertyName = "Price5";
            dataGridView1.Columns[10].DataPropertyName = "Printer";
            dataGridView1.Columns[11].DataPropertyName = "SemiPrepared";
            dataGridView1.Columns[12].DataPropertyName = "ATG";
            dataGridView1.Columns[13].DataPropertyName = "InHoll";
            dataGridView1.Columns[14].DataPropertyName = "NonComposite";
            


            // dataGridView1.Columns[15].DataPropertyName = "Engish";
            //  dataGridView1.Columns[16].DataPropertyName = "Russian";
            dataGridView1.Columns[0].ReadOnly = true;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.DataPropertyName == "Code") column.HeaderText = code;
                if (column.DataPropertyName == "Name") column.HeaderText = name;
                if (column.DataPropertyName == "Unit") column.HeaderText = unit;
                if (column.DataPropertyName == "Department") column.HeaderText = dep;
                if (column.DataPropertyName == "Price") column.HeaderText = pr;
                if (column.DataPropertyName == "Price1") column.HeaderText = pr1;
                if (column.DataPropertyName == "Price2") column.HeaderText = pr2;
                if (column.DataPropertyName == "Price3") column.HeaderText = pr3;
                if (column.DataPropertyName == "Price4") column.HeaderText = pr4;
                if (column.DataPropertyName == "Price5") column.HeaderText = pr5;
                if (column.DataPropertyName == "Printer") column.HeaderText = print;
                if (column.DataPropertyName == "SemiPrepared") column.HeaderText = semi;
                if (column.DataPropertyName == "InHoll") column.HeaderText = inh;
                if (column.DataPropertyName == "NonComposite") column.HeaderText = nonc;
                if (column.Index > 14)
                {
                    column.Visible = false;
                }
            }
            //dataGridView1.Columns[15].Visible = false;
           // dataGridView1.Columns[16].Visible = false;

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
                    if (_language == "Armenian") item.Row2["Name"] = item.Row1["Armenian"];
                    if (_language == "English") item.Row2["Name"] = item.Row1["English"];
                    if (_language == "German") item.Row2["Name"] = item.Row1["German"];
                    if (_language == "Russian") item.Row2["Name"] = item.Row1["Russian"];
                    if (_language == "Espaniol") item.Row2["Name"] = item.Row1["Espaniol"];
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
                    if (_language == "Armenian") item.Row2["Name"] = item.Row1["Armenian"];
                    if (_language == "English") item.Row2["Name"] = item.Row1["English"];
                    if (_language == "German") item.Row2["Name"] = item.Row1["German"];
                    if (_language == "Russian") item.Row2["Name"] = item.Row1["Russian"];
                    if (_language == "Espaniol") item.Row2["Name"] = item.Row1["Espaniol"];
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

            //dataGridView2.Columns[1].HeaderText = name;
            //dataGridView2.Columns[2].HeaderText = unit;
            //dataGridView2.Columns[3].HeaderText = pr;
            //dataGridView2.Columns[4].HeaderText = quant;

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {

                if (column.Index > 7)
                {
                    column.Visible = false;
                }

            }
            //string connectionString = "Server=localhost;Database=kafe_arm;User ID=root;Password='';CharSet = utf8mb4;";

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);


            string query5 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query5);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = row["Name"].ToString();
            }



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
                // Use LINQ to find the maximum value in the "Code" column
                string maxCode = dataView.Cast<DataRowView>().Max(row => (string)row["Code"]);
                int maxcode = Convert.ToInt32(maxCode) + 1;
                maxCode = maxcode.ToString();

                DataRow newRow = Table_215.NewRow();
                Table_215.Rows.Add(newRow);
                newRow["Code"] = maxCode;
                newRow["Armenian"] = "";
                newRow["English"] = "";
                newRow["German"] = "";
                newRow["Russian"] = "";
                newRow["Espaniol"] = "";
                newRow["Department"] = 0;
                newRow["SemiPrepared"] = 0;
                newRow["costprice"] = 0;
                newRow["Price"] = 0;
                newRow["Price1"] = 0;
                newRow["Price2"] = 0;
                newRow["Price3"] = 0;
                newRow["Price4"] = 0;
                newRow["Price5"] = 0;
                newRow["Printer"] = 0;
                newRow["ATG"] = "";
                newRow["Restaurant"] = _restaurant;
                newRow["Inholl"] = ""; 
                newRow["NonComposite"] = "";
                newRow["Changed"] = 1;
                newRow["Existent"] = 0;
                newRow["groupp"] = 0;

                // Add the new row to the DataTable



                if (dataGridView1.Rows.Count > 0)
                {
                    // Set the focus to the last row
                    int lastRowIndex = dataGridView1.Rows.Count - 2;
                    // dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0]; // Assuming you want to set focus to the first column of the last row
                    // dataGridView1.BeginEdit(true); // If you want to start editing the cell immediately

                    //for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
                    //{
                    //    if (dataGridView1.Columns[colIndex].Visible)
                    //    {
                    //        dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[colIndex];
                    //        dataGridView1.BeginEdit(true);
                    //        break;
                    //    }
                    //}
                    dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[2];
                    dataGridView1.BeginEdit(true);
                    SaveButton.Visible = true;

                }
            }

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)//***************
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            object codeValue = dataGridView.Rows[e.RowIndex].Cells["Code"].Value;
            object priceValue = dataGridView.Rows[e.RowIndex].Cells["Price1"].Value;
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
            dataView.RowFilter = $"(Code+Name) LIKE '%{txt}%'";
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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab || e.KeyChar == (char)Keys.Down)
            //{
            //    int desiredRowIndex = 0; // Index of the first row in the filtered data
            //    int desiredColumnIndex = 0; // Index of the first column

            //    if (dataGridView1.Rows.Count > 0)
            //    {
            //        dataGridView1.Columns[0].ReadOnly = true;
            //        // Check if the first column is visible
            //        if (dataGridView1.Columns[desiredColumnIndex].Visible)
            //        {
            //            dataGridView1.CurrentCell = dataGridView1.Rows[desiredRowIndex].Cells[desiredColumnIndex];
            //            dataGridView1.BeginEdit(true);
            //        }
            //        else
            //        {
            //            // Find the first visible column and set the CurrentCell
            //            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            //            {
            //                if (dataGridView1.Columns[colIndex].Visible)
            //                {
            //                    dataGridView1.CurrentCell = dataGridView1.Rows[desiredRowIndex].Cells[colIndex];
            //                    dataGridView1.BeginEdit(true);
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}
        }


        private void radioButton1_Click(object sender, EventArgs e)
        {
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                if (dataGridView1.Columns[colIndex].DataPropertyName == _language)
                {
                    dataGridView1.Columns[colIndex].DataPropertyName = "Armenian";
                }
            }
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = true;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[1].DataPropertyName = "Armenian";
            dataGridView1.Refresh();
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
            string connectionString = "Server=DESKTOP-L1SRCHN\\SQLEXPRESS;Database=CafeRest;Integrated Security=True;";
            Save.UpdateTableFromDatatable(connectionString, Table_215, "215", _restaurant);
            Save.UpdateTableFromDatatable(connectionString, Table_Composition, "Composition", _restaurant);


            //SqlConnection connection = new SqlConnection(connectionString);
            //SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            //connection.Open();
            //DataRow[] foundRows1 = Table_215.Select($"Changed = '{1}'");
            //if (foundRows1.Length > 0)
            //{
            //    foreach (DataRow row in foundRows1)
            //    {
            //        string code = row["Code"].ToString();
            //        int printer = int.Parse(row["Printer"].ToString());
            //        int department = int.Parse(row["Department"].ToString());
            //        float price = float.Parse(row["Price"].ToString());
            //        float price1 = float.Parse(row["Price1"].ToString());
            //        float price2 = float.Parse(row["Price2"].ToString());
            //        float price3 = float.Parse(row["Price3"].ToString());
            //        float price4 = float.Parse(row["Price4"].ToString());
            //        float price5 = float.Parse(row["Price5"].ToString());
            //        string atg = row["Atg"].ToString();
            //        string inholl = row["Inholl"].ToString();
            //        int semiprepared = int.Parse(row["SemiPrepared"].ToString());
            //        string Arm = row["Armenian"].ToString();
            //        string Ger = row["German"].ToString();
            //        string Esp = row["Espaniol"].ToString();
            //        string Eng = row["English"].ToString();
            //        string Rus = row["Russian"].ToString();
            //        string unit = row["Unit"].ToString(); 
            //        string Non = row["NonComposite"].ToString();




            //        string UpdateQuery = $"UPDATE table_215 SET Armenian= @Arm,English= @Eng,German= @Germ," +
            //            $"Russian= @Rus,Espaniol=@esp,Unit=@unit, Printer=@printer, Department=@department," +
            //            $" Price=@price, Price1=@price1,Price2=@price2,Price3=@price3,Price4=@price4," +
            //            $"Price5=@price5, Atg=@atg, Inholl=@inholl," +
            //            $"SemiPrepared=@semiPrepared,NonComposite=@Non  WHERE Code = @code ";
            //        using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
            //        {
            //            command.Parameters.AddWithValue("@Armenian", Arm);
            //            command.Parameters.AddWithValue("@English", Eng);
            //            command.Parameters.AddWithValue("@German", Ger);
            //            command.Parameters.AddWithValue("@Espaniol", Esp);
            //            command.Parameters.AddWithValue("@Russian", Rus);
            //            command.Parameters.AddWithValue("@Unit", unit);
            //            command.Parameters.AddWithValue("@Printer", printer);
            //            command.Parameters.AddWithValue("@Department", department);
            //            command.Parameters.AddWithValue("@Price", price);
            //            command.Parameters.AddWithValue("@Price1", price1);
            //            command.Parameters.AddWithValue("@Price2", price2);
            //            command.Parameters.AddWithValue("@Price3", price3);
            //            command.Parameters.AddWithValue("@Price4", price4);
            //            command.Parameters.AddWithValue("@Price5", price5);
            //            command.Parameters.AddWithValue("@Atg", atg);
            //            command.Parameters.AddWithValue("@Inholl", inholl);
            //            command.Parameters.AddWithValue("@SemiPrepared", semiprepared);
            //            command.Parameters.AddWithValue("@Code", code);
            //            command.Parameters.AddWithValue("@NonComposite", Non);
            //            command.ExecuteNonQuery();
            //        }


              //      SaveButton.Visible = false;


                //}

           // }
          //  connection.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string xm = "<NewDataSet>";
            string IsP = "1";
            foreach (DataRow row in Table_215.Rows)
            {
                if (row["Unit"].ToString() == "հատ") IsP = "0";
                xm = xm + "<Report>";
                xm = xm + "<CodeSort>" + row["Code"].ToString().Substring(3) + "</CodeSort>";
                xm = xm + "<Code>" + row["Code"].ToString().Substring(3) + "</Code>";
                xm = xm + "<GoodName>" + row["Name"].ToString() + "</GoodName>";
                xm = xm + "<PriceOut>" + row["Price1"].ToString() + "</PriceOut>";
                xm = xm + "<SellByDate>100</SellByDate>";
                xm = xm + "<IsPiece>" + IsP + "</IsPiece></Report>";
            }
            xm = xm + "</NewDataSet>";
            string connectionString = "Server=DESKTOP-L1SRCHN\\SQLEXPRESS;Database=CafeRest;Integrated Security=True;";
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

        private void HelpButton_Click(object sender, EventArgs e)
        {
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";
                richTextBox1.Height = this.Height - 50;
                richTextBox1.ReadOnly = true;
                string filePath = "D:\\hayrik\\sql\\help\\Foods_arm.txt";
                if (_language == "Armenian") filePath = "D:\\hayrik\\sql\\help\\Foods_arm.txt";
                if (_language == "English") filePath = "D:\\hayrik\\sql\\help\\Foods_eng.txt";
                if (_language == "German") filePath = "D:\\hayrik\\sql\\help\\Foods_ger.txt";
                if (_language == "Espaniol") filePath = "D:\\hayrik\\sql\\help\\Foods_esp.txt";
                if (_language == "Russian") filePath = "D:\\hayrik\\sql\\help\\Foods_rus.txt";
                string fileContent = File.ReadAllText(filePath);
                richTextBox1.Text = fileContent;
                richTextBox1.Visible = true;
                richTextBox1.Top = 0;
                richTextBox1.Left = 0;
                richTextBox1.Width = HelpButton.Left - 5;
                richTextBox1.Height = this.Height - 20;
            }
            else
            {
                richTextBox1.Visible = false;
                HelpButton.Text = "?";
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the current cell
            DataGridViewCell currentCell = dataGridView1.CurrentCell;
            //dataGridView1.Tag = currentCell.RowIndex.ToString();
            button2.Tag = currentCell.ColumnIndex.ToString();// ֆիքսում ենք ընթացիկ բջիջի ինդեքսները
            checkedListBox1.Tag=currentCell.RowIndex.ToString();

            if (currentCell != null && (currentCell.ColumnIndex == 20 || currentCell.ColumnIndex == 23))
            {
                checkedListBox1.Visible = true;
                button2.Visible = true;
            }
            this.Text = button2.Tag.ToString() + " , " + dataGridView1.Columns[currentCell.ColumnIndex].DataPropertyName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowindex = int.Parse(checkedListBox1.Tag.ToString());
            int colindex = int.Parse(button2.Tag.ToString());
            dataGridView1.Rows[rowindex].Cells[colindex].Value = "";
            string val = "";
            for (int i = 0; i < 10; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    val = val + (i+1).ToString() + ",";
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
                if (dataGridView1.Columns[colIndex].DataPropertyName == "Armenian" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "English" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "German" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "Espaniol" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "Russian" )
                {
                    dataGridView1.Columns[colIndex].DataPropertyName = comboBox1.SelectedItem.ToString();
                }
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}