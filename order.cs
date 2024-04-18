using System.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Microsoft.ReportingServices.Diagnostics.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using ReportPrinter;
using System.Collections.Generic;


namespace WindowsFormsApp4
{
    public partial class order : Form
    {
        private string _ooperatorname;
        private int _ooperator;
        private int _holl;
        private int _restaurant;
        private int _editor;
        private int _previous;
        private int _workplace;
        private string _language;
        private int existent;
        private int Current_columnIndex;
        private string Restaurantname;

        private SQLDatabaseHelper dbHelper;

        private BindingSource bindingSource = new BindingSource();

        private DataTable TableSeans = new DataTable();   //Ընթացիկ սեանսն է։ Ամեն դրամարկղ իր սեփական սեանսն ունի, տարբեր մյուս դրամարկղերից։

        private DataTable TablePrevious = new DataTable(); //Նախնական պատվերներն են 

        private DataTable Table_215 = new DataTable();   //Ճաշացուցակն է։ 

        private DataTable Table215 = new DataTable();

        private DataTable TableStandart = new DataTable();   //ստանդարտ պատվերներն են

        private DataTable FoodGroupp = new DataTable();// ճաշերի խմբերն են 

        private DataTable tableforprint = new DataTable(); 
        
        private DataTable AdditionGroups = new DataTable();   //հավելումների խմբերի աղյուսակն է։ 

        private DataTable AdditionNames = new DataTable();   //հավելումների խմբերի բովանդակությունն է։

        private DataTable TableNest = new DataTable();   // Սեղանների ֆայլն է։ սպասարկման և զեղչի տոկոսների համար։ և ընթացիկ
                                                         // <ocupied>,<forbidden>,<ticket>,<printed>,<taxprinted>,<person>,<tipmoney> դաշտերով։

        private DataTable Department = new DataTable();   // բաժինների ֆայլն է։։ 

        private DataTable TicketsOrdered = new DataTable(); // հաշիվների մասին տեղեկություններ են ։ 

        private DataTable Seans_State = new DataTable();//Ընթացիկ սեանսի համարն է։։ 

        private DataTable CurrentOrder = new DataTable();    // ընթացիկ պատվերի աղյուսակն է։ Ստեղծվում է ծրագիր մտնելիս

        private DataTable Order = new DataTable();    // պատվերը տպելու համար է 

        private DataTable BillPrint = new DataTable();    // կտրոնը տպելու համար է 

        private DataTable Table_Restaurants = new DataTable();    // Ռեստորանների ցանկն է

        private DataTable Table_Workplace = new DataTable();

        private DataView dataView;

        public order(string ooperatorname, int ooperator, int holl, int restaurant, int editor, int previous, int workplace, string language)
        {

            InitializeComponent();
            InitForm();
            _ooperatorname = ooperatorname;
            _ooperator = ooperator;
            _holl = holl;
            _restaurant = restaurant;
            _editor = editor; // եթե edit == 0 միայն դիտարկվում է;
            _previous = previous;
            _workplace = workplace;
            _language = language;
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();

            string query11 = $"SELECT * FROM Workplace WHERE Id='{_workplace}' ";
            Table_Workplace = dbHelper.ExecuteQuery(query11);

            string query6 = $"SELECT * FROM TableNest WHERE Holl='{_holl}' AND Restaurant ='{_restaurant}' and Previous='{_previous}' ";
            TableNest = dbHelper.ExecuteQuery(query6);




            string query5 = $"SELECT * FROM Department WHERE Restaurant='{_restaurant}' ";
            Department = dbHelper.ExecuteQuery(query5);
            foreach (DataRow row in Department.Rows)
            {
                row["Name"] = row[_language].ToString();
            }

            string query1 = $"SELECT * FROM Table_215 WHERE  Restaurant='{_restaurant}' ORDER BY [Groupp] ";
            Table215 = dbHelper.ExecuteQuery(query1);
            Table_215 = Table215.Clone();
            Table_215.Columns.Add("Name", typeof(string));
            Table215.Columns.Add("Name", typeof(string));
            string inh = _holl.ToString() + ",";
            foreach (DataRow row in Table215.Rows) //տվյալ սրահի համար չնախատեսված ապրանքները հանում ենք
            {
                if (_holl == 1) row["Price"] = row["Price1"];
                if (_holl == 2) row["Price"] = row["Price2"];
                if (_holl == 3) row["Price"] = row["Price3"];
                if (_holl == 4) row["Price"] = row["Price4"];
                if (_holl == 5) row["Price"] = row["Price5"];
                string inholl = row["inholl"].ToString();
                if (float.Parse(row["Price"].ToString()) == 0 ) continue;
                if ((row["inholl"].ToString().Trim() != "0" && row["inholl"].ToString().Trim() != string.Empty) && inholl.IndexOf(inh) < 0) continue;
                DataRow newRow = Table_215.NewRow();
                Table_215.Rows.Add(newRow);
                for (int colIndex = 0; colIndex < Table_215.Columns.Count; colIndex++)
                {
                    string columnName = Table_215.Columns[colIndex].ColumnName;
                    newRow[columnName] = row[columnName];
                }
            }
            Translate.translation(Table_215,Table215, _language, "1");

            string query2 = $"SELECT * FROM AdditionGroups WHERE  Restaurant='{_restaurant}' ";
            AdditionGroups = dbHelper.ExecuteQuery(query2);
            Translate.translation(AdditionGroups, AdditionGroups, _language, "2");

            string query3 = $"SELECT * FROM AdditionNames WHERE  Restaurant='{_restaurant}' ";
            AdditionNames = dbHelper.ExecuteQuery(query3);
            Translate.translation(AdditionNames, AdditionNames, _language, "2");

            string query4 = $"SELECT * FROM FoodGroupp WHERE  Restaurant='{_restaurant}' ";
            FoodGroupp = dbHelper.ExecuteQuery(query4);
            foreach (DataRow row in FoodGroupp.Rows)
            {
                row["Name"] = row[_language].ToString();
            }

            string query7 = $"SELECT * FROM TicketsOrdered WHERE  Restaurant='{_restaurant}' AND Previous='{_previous}' ";
            TicketsOrdered = dbHelper.ExecuteQuery(query7);

            string query8 = $"SELECT * FROM Restaurants";
            Table_Restaurants = dbHelper.ExecuteQuery(query8);
            DataRow[] foundRows1 = Table_Restaurants.Select($"Id = '{_restaurant}' ");
            Restaurantname = "";
            if (foundRows1.Length > 0)
            {
                Restaurantname = foundRows1[0]["Name"].ToString();
                this.Text = Restaurantname;
                if (_previous == 1) this.Text = this.Text + " - նախնական պատվեր";
            }

            int seans_state = 0;

            string query10 = $"SELECT * FROM SeansState WHERE Id='{_restaurant}' ";
            Seans_State = dbHelper.ExecuteQuery(query10);
            DataRow[] foundRows = Seans_State.Select($"id = '{_restaurant}'");
            if (foundRows.Length > 0) seans_state = int.Parse(foundRows[0]["Seans"].ToString());


            if (_previous == 0)
            {
                string query9 = $"SELECT * FROM seans WHERE Holl='{_holl}' AND Restaurant='{_restaurant}'  ";
                TableSeans = dbHelper.ExecuteQuery(query9);
                Seans.Text = seans_state.ToString();
            }
            else
            {
                string query9 = $"SELECT * FROM Previous_215 WHERE Holl='{_holl}' AND Restaurant='{_restaurant}'  ";
                TableSeans = dbHelper.ExecuteQuery(query9);
                Seans.Text = seans_state.ToString();
            }
           // TableSeans.Columns.Add("name", typeof(string));

            Translate.translation(Table215, Table_215,  _language, "1");



            dataGridView1.DataSource = Table_215;
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[1].DataPropertyName = "Price";


            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.DataPropertyName != "Name" && column.DataPropertyName != "Price" && column.DataPropertyName != "Existent")
                {
                    column.Visible = false;
                }
            }

            existent = Table_215.Columns.IndexOf("Existent");//ճաշացուցակի գույների համար է


            dataGridView3.DataSource = AdditionNames;
            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.Columns[0].DataPropertyName = "Name";

            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                string name = column.DataPropertyName;
                if (column.Index > 0)
                {
                    column.Visible = false;
                }

            }

            //// տպելու աղուսակը
            Order.Columns.Add("name", typeof(string));
            Order.Columns.Add("price", typeof(float));
            Order.Columns.Add("quantity", typeof(float));
            Order.Columns.Add("salesamount", typeof(float));

            //// Կազմավորվում է պատվերի աղյուսակը



            CurrentOrder.Columns.Add("name", typeof(string));
            CurrentOrder.Columns.Add("price", typeof(float));
            CurrentOrder.Columns.Add("costprice", typeof(float));
            CurrentOrder.Columns.Add("qanak", typeof(string));
            CurrentOrder.Columns.Add("salesamount", typeof(float));
            CurrentOrder.Columns.Add("costamount", typeof(float));
            CurrentOrder.Columns.Add("service", typeof(float));
            CurrentOrder.Columns.Add("discount", typeof(float));
            CurrentOrder.Columns.Add("printer", typeof(int));
            CurrentOrder.Columns.Add("groupp", typeof(int));
            CurrentOrder.Columns.Add("code", typeof(string));
            CurrentOrder.Columns.Add("quantity", typeof(float));
            CurrentOrder.Columns.Add("standart", typeof(float));
            CurrentOrder.Columns.Add("date1", typeof(DateTime));
            CurrentOrder.Columns.Add("date2", typeof(DateTime));
            CurrentOrder.Columns.Add("seans", typeof(int));
            CurrentOrder.Columns.Add("ticket", typeof(int));
            CurrentOrder.Columns.Add("nest", typeof(string));
            CurrentOrder.Columns.Add("printed", typeof(bool));
            CurrentOrder.Columns.Add("taxpaid", typeof(bool));
            CurrentOrder.Columns.Add("accepted", typeof(bool));
            CurrentOrder.Columns.Add("current", typeof(int));
            CurrentOrder.Columns.Add("debet", typeof(string));
            CurrentOrder.Columns.Add("kredit", typeof(string));
            CurrentOrder.Columns.Add("Department", typeof(decimal));
            CurrentOrder.Columns.Add("id", typeof(int));
            CurrentOrder.Columns.Add("free", typeof(int));


            dataGridView2.DataSource = CurrentOrder;
            dataGridView2.Columns[0].DataPropertyName = "name";
            dataGridView2.Columns[1].DataPropertyName = "Price";
            dataGridView2.Columns[2].DataPropertyName = "qanak";
            dataGridView2.Columns[3].DataPropertyName = "salesamount";
            //   dataGridView2.Columns[4].DataPropertyName = "current";
            //bindingSource.DataSource = CurrentOrder;
            connection.Close();

            if (_editor == 0)
            {
                dataGridView1.Enabled = false; dataGridView2.Enabled = false; remove.Enabled = false; tab69.Enabled = false;
                radioButton1.Enabled = false; radioButton2.Enabled = false; radioButton3.Enabled = false; TipMoney.Enabled = false;
                numericUpDown3.Enabled = false;
            }
        }

        private void group1_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group1.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group2_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group2.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }
        private void group3_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group3.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group4_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group4.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group5_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group5.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group6_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group6.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group7_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group7.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group8_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group8.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group9_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group9.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group10_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group10.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group11_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group11.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group12_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group12.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group13_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group13.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group14_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group14.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group15_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group15.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group16_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group16.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group17_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group17.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group18_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group18.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group19_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group19.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group20_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group20.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group21_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group21.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group22_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group22.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group23_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group23.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group24_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group24.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group25_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group25.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group26_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group26.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group27_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group27.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group28_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group28.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group29_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group29.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void group30_Click(object sender, EventArgs e)
        {
            GroupClick.Tag = group30.Tag;
            GroupClick.Focus();
            SendKeys.Send("{ENTER}");
        }
        private bool DoesButtonExist(string buttonName)
        {
            // Check if the button with the specified name exists in the form's Controls collection
            return Controls.ContainsKey(buttonName);
        }
        private void order_Load(object sender, EventArgs e)
        {

            dataGridView3.Width = dataGridView1.Left - 5;
            dataGridView3.Columns[0].Width = 0;
            dataGridView3.Columns[1].Width = dataGridView3.Width;
            System.Windows.Forms.Button[] tabArray = new System.Windows.Forms.Button[70] { tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13,
                tab14, tab15, tab16, tab17, tab18, tab19, tab20, tab21, tab22, tab23, tab24, tab25, tab26, tab27, tab28, tab29, tab30,
                tab31, tab32, tab33, tab34, tab35, tab36, tab37, tab38, tab39, tab40, tab41, tab42, tab43, tab44, tab45, tab46, tab47,
                tab48, tab49, tab50, tab51, tab52, tab53, tab54, tab55, tab56, tab57, tab58, tab59, tab60, tab61, tab62, tab63, tab64,
                tab65, tab66, tab67, tab68, tab69, tab70 };
            for (int i = 0; i < 68; i++)
            {
                tabArray[i].Enabled = true;
                tabArray[i].Text = _holl.ToString().Trim() + '-' + (i + 1).ToString(); //_holl-ը դրամարկղի համարն է։ Սեղանների տեքտերը դրանից կաղված փոխվում են
                DataRow[] foundRows = TableNest.Select("Nest = '" + tabArray[i].Text + "'");
                bool T = foundRows.Length == 0;
                if (T == true) tabArray[i].Enabled = false;
            }
            System.Windows.Forms.Button[] additionArray = new System.Windows.Forms.Button[20] { addition1, addition2, addition3, addition4, addition5, addition6, addition7, addition8, addition9,
                addition10, addition11, addition12, addition13, addition14, addition15, addition16, addition17, addition18, addition19, addition20 };
            for (int i = 0; i < 20; i++)
            {
                additionArray[i].Visible = false;
            }
            int j = 0;
            foreach (DataRow row in AdditionGroups.Rows)//Հավելումների կոճակների անուններն ենք տեղադրում
            {
                if (DoesButtonExist(additionArray[j].Name))
                {
                    additionArray[j].Tag = row["Id"].ToString();
                    additionArray[j].Text = row["Name"].ToString();
                    additionArray[j].Visible = true;
                }
                j += 1;
            }
            System.Windows.Forms.Button[] departmentArray = new System.Windows.Forms.Button[5] { department1, department2, department3, department4, department5 };
            j = -1;

            foreach (DataRow row in Department.Rows)//բաժինների կոճակների անուններն ենք տեղադրում
            {
                j++;
                if (DoesButtonExist(departmentArray[j].Name))
                {
                    departmentArray[j].Text = row["Name"].ToString();
                    departmentArray[j].Visible = true;
                }

            }

            this.command.Left = this.Width + 5;
            this.DepartmentClick.Left = this.Width + 5;
            this.GroupClick.Left = this.Width + 5;
            this.AdditionClick.Left = this.Width + 5;

            //NestUpdate();
        }


        private void department1_Click(object sender, EventArgs e)
        {
            this.DepartmentClick.Tag = "1";
            this.DepartmentClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void department2_Click(object sender, EventArgs e)
        {
            this.DepartmentClick.Tag = "2";
            this.DepartmentClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void department3_Click(object sender, EventArgs e)
        {
            this.DepartmentClick.Tag = "3";
            this.DepartmentClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void department4_Click(object sender, EventArgs e)
        {
            this.DepartmentClick.Tag = "4";
            this.DepartmentClick.Focus();
            SendKeys.Send("{ENTER}");
        }
        private void department5_Click(object sender, EventArgs e)
        {
            this.DepartmentClick.Tag = "5";
            this.DepartmentClick.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {

                dataGridView1.Tag = "inorder";// հայտանիշ է թվերը դնելու համար command կոճակի մեջ օգտագործելու 
                DataGridView dataGridView = (DataGridView)sender;
                object codeValue = dataGridView.Rows[e.RowIndex].Cells["code"].Value;
                object nameValue = dataGridView.Rows[e.RowIndex].Cells["name"].Value;
                object printerValue = dataGridView.Rows[e.RowIndex].Cells["printer"].Value;
                object priceValue = dataGridView.Rows[e.RowIndex].Cells["price"].Value;
                object costpriceValue = dataGridView.Rows[e.RowIndex].Cells["costprice"].Value;
                object quantValue = dataGridView.Rows[e.RowIndex].Cells["quantity"].Value;
                object accValue = dataGridView.Rows[e.RowIndex].Cells["accepted"].Value;
                object idValue = dataGridView.Rows[e.RowIndex].Cells["id"].Value;
                object freeValue = dataGridView.Rows[e.RowIndex].Cells["free"].Value;
                object grouppValue = dataGridView.Rows[e.RowIndex].Cells["groupp"].Value;
                int qan = Convert.ToInt32(quantValue);
                bool acc = bool.Parse(accValue.ToString());
                int groupp=int.Parse(grouppValue.ToString());
                if (qan > 0)
                {
                    number_enter.Tag = qan.ToString();  // մինուսը հսկելու համար է
                }
                else
                {
                    number_enter.Tag = "0";
                }
                if (!acc)
                {
                    dataGridView3.Tag = idValue.ToString();//հավելումի համար ֆիքսում ենք տողի id-ն
                }
                if (acc)
                {
                    int printer = int.Parse(printerValue.ToString());
                    string code = codeValue.ToString();
                    string name = nameValue.ToString();
                    float price = float.Parse(priceValue.ToString());
                    float costprice = float.Parse(costpriceValue.ToString());
                    int free = int.Parse(freeValue.ToString());

                    DataRow[] foundRows1 = CurrentOrder.Select($"code = '{code}' and accepted='false'");
                    if (foundRows1.Length > 0)
                    {
                        foreach (DataRow row in foundRows1)
                        {
                            row["current"] = 1;
                            row["quantity"] = 0;
                            row["salesamount"] = 0;
                            row["costamount"] = 0;
                            row["costprice"] = costprice;
                            row["qanak"] = "-";
                        }
                    }
                    else
                    {
                        DataRow[] foundRows = CurrentOrder.Select("current = 1");

                        // If no records are found where current = true, append a blank record
                        if (foundRows.Length == 0)
                        {
                            DataRow newRow = CurrentOrder.NewRow();
                            CurrentOrder.Rows.Add(newRow);
                            newRow["seans"] = int.Parse(Seans.Text);
                            newRow["ticket"] = bill.Text;
                            newRow["nest"] = nest.Text;
                            newRow["groupp"] = groupp;
                            newRow["current"] = 1;
                            newRow["accepted"] = false;
                            newRow["id"] = CurrentOrder.Rows.Count;
                            dataGridView2.Tag = CurrentOrder.Rows.Count;
                            newRow["code"] = code;
                            newRow["name"] = name;
                            newRow["costprice"] = costprice;
                            newRow["price"] = price;
                            newRow["quantity"] = 0;
                            newRow["salesamount"] = 0;
                            newRow["costamount"] = 0;
                            newRow["printer"] = printer;
                            newRow["free"] = free;
                            newRow["qanak"] = "-";
                            dataGridView2.BeginEdit(true);
                        }
                        else
                        {
                            foreach (DataRow row in foundRows)
                            {
                                // Update the fields if a matching record is found
                                row["code"] = code;
                                row["name"] = name;
                                row["price"] = price;
                                row["costprice"] = costprice;
                                row["quantity"] = 0;
                                row["salesamount"] = 0;
                                row["costamount"] = 0;
                                row["printer"] = printer;
                            }
                        }
                    }
                    // dataGridView2.Refresh();

                }

            }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e) // պատվերի տողին հավելում ենք ավելացնում
        {
            object nameValue = dataGridView3.Rows[e.RowIndex].Cells["Name"].Value;
            string Name = nameValue.ToString();
            int id = int.Parse(dataGridView3.Tag.ToString());
            DataRow[] foundRows = CurrentOrder.Select($"id = '{id}'");
            if (foundRows.Length > -1)
            {
                foreach (DataRow row in foundRows)
                {
                    row["Name"] = row["Name"] + " | " + Name;
                }
            }
            dataGridView3.Visible = false;
        }
        private void NestUpdate()
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (_previous == 0)
            {
                string query = $"SELECT * FROM Seans WHERE Holl='{_holl}' AND Restaurant='{_restaurant}'"; //սեանսի աղյուսակը թարմացնում ենք
                TableSeans = dbHelper.ExecuteQuery(query);
            }
            else
            {
                string query = $"SELECT * FROM Previous_215 WHERE Holl='{_holl}' AND Restaurant='{_restaurant}'"; //սեանսի աղյուսակը թարմացնում ենք
                TableSeans = dbHelper.ExecuteQuery(query);
            }
            TableSeans.Columns.Add("name", typeof(string));
            Translate.translation(Table215, TableSeans, _language, "1");

            string query1 = $"SELECT * FROM tablenest WHERE Restaurant='{_restaurant}' and Previous='{_previous}' ";//սեղանների աղյուսակը թարմացնում ենք
            TableNest = dbHelper.ExecuteQuery(query1);
            query1 = $"SELECT * FROM TicketsOrdered WHERE Restaurant='{_restaurant}' and Holl='{_holl}'  AND Previous='{_previous}'";//հաշիվների աղյուսակը թարմացնում ենք
            TicketsOrdered = dbHelper.ExecuteQuery(query1);
            int tick = 1;
            numericUpDown3.Value = 0;
            foreach (DataRow row in TicketsOrdered.Rows)
            {
                if (row["Nest"].ToString() == nest.Text && int.Parse(row["Paid"].ToString()) == 0)
                {
                    tick = int.Parse(row["Ticket"].ToString());
                    numericUpDown3.Value = int.Parse(row["Person"].ToString());
                    break;
                }
                if (int.Parse(row["Ticket"].ToString()) >= tick) tick = int.Parse(row["Ticket"].ToString()) + 1;
            }
            bill.Text = tick.ToString();
            System.Windows.Forms.Button[] tabArray = new System.Windows.Forms.Button[62] { tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13,
                tab14, tab15, tab16, tab17, tab18, tab19, tab20, tab21, tab22, tab23, tab24, tab25, tab26, tab27, tab28, tab29,
                tab30, tab31, tab32, tab33, tab34, tab35, tab36, tab37, tab38, tab39, tab40, tab41, tab42, tab43, tab44, tab45,
                tab46, tab47, tab48, tab49, tab50, tab51, tab52, tab53, tab54, tab55, tab56, tab57, tab58, tab59, tab60, tab61, tab62 };
            CurrentOrder.Clear();
            tab62.ForeColor = Color.Black;
            dataGridView1.Enabled = true;
            string table_clicked = command.Text;
            for (int i = 0; i < 61; i++)
            {

                tabArray[i].ForeColor = Color.Black;
                tabArray[i].BackColor = System.Drawing.SystemColors.ButtonFace;
                DataRow[] foundRows = TableNest.Select("Nest = '" + tabArray[i].Text + "'");
                if (foundRows.Length > 0)
                {

                    string ServiseValue = foundRows[0]["Service"].ToString();
                    string DiscountValue = foundRows[0]["Discount"].ToString();
                    string OcupiedValue = foundRows[0]["Ocupied"].ToString();
                    string ForbiddenValue = foundRows[0]["Forbidden"].ToString();
                    string PrintedValue = foundRows[0]["Printed"].ToString();
                    string nestt = foundRows[0]["Nest"].ToString().Trim();
                    tabArray[i].Tag = "+" + ServiseValue + " -" + DiscountValue;
                    if (OcupiedValue == "1") tabArray[i].ForeColor = Color.Red;// զբաղվածի գույնը կարմիր է դարձնում
                    if (PrintedValue == "1")
                    {
                        tabArray[i].ForeColor = Color.Orange;// տպածի գույնը դեղին է դարձնում
                        dataGridView1.Enabled = true;
                    }
                    if (ForbiddenValue == "1")
                    {
                        tabArray[i].ForeColor = Color.BlueViolet;// արգելվածի գույնը կապույտ է դարձնում
                    }
                    if (nestt == nest.Text)
                    {
                        //numericUpDown3.Value = int.Parse(foundRows[0]["Person"].ToString());
                        TipMoney.Text = foundRows[0]["Tipmoney"].ToString();
                        tabArray[i].BackColor = Color.LightGreen;
                        if (PrintedValue == "1" || ForbiddenValue == "1")
                        {
                            dataGridView1.Enabled = false; //տպածի և արգելվածի  վրա փոփոխությունն արգելված է
                            dataGridView2.Enabled = false;
                        }

                    }
                }
            }
            foreach (DataRow row in TableSeans.Rows)
            {
                if (row["Nest"].ToString() != nest.Text || row["Paid"].ToString() == "1") continue;
                string seansCode = row["Code"].ToString();

                DataRow[] foundRows = CurrentOrder.Select("Code = '" + seansCode + "'");
                if (foundRows.Length == 0)
                {
                    DataRow[] foundRows1 = Table_215.Select("Code = '" + seansCode + "'");
                    int printer = int.Parse(foundRows1[0]["Printer"].ToString());
                    DataRow newRow = CurrentOrder.NewRow();
                    newRow["code"] = row["code"];
                    newRow["nest"] = row["nest"];
                    newRow["seans"] = row["seans"];
                    newRow["ticket"] = row["ticket"];
                    newRow["name"] = row["name"];
                    newRow["groupp"] = row["groupp"];
                    newRow["costprice"] = row["costprice"];
                    newRow["price"] = row["price"];
                    newRow["quantity"] = row["quantity"];
                    newRow["qanak"] = row["quantity"].ToString();
                    newRow["salesamount"] = row["salesamount"];
                    newRow["costamount"] = row["costamount"];
                    newRow["service"] = row["service"];
                    newRow["discount"] = row["discount"];
                    newRow["free"] = row["free"];
                    newRow["printer"] = printer;
                    newRow["taxpaid"] = row["taxpaid"];
                    newRow["id"] = 0;
                    newRow["current"] = 0;
                    newRow["accepted"] = true;
                    //  bill.Text = row["ticket"].ToString();
                    CurrentOrder.Rows.Add(newRow);
                }
                else
                {
                    foreach (DataRow foundRow in foundRows)
                    {
                        // Update quantity and amount in current_dir based on seans table values
                        foundRow["quantity"] = float.Parse(foundRow["quantity"].ToString()) + float.Parse(row["quantity"].ToString());
                        foundRow["salesamount"] = float.Parse(foundRow["salesamount"].ToString()) + float.Parse(row["salesamount"].ToString());
                        foundRow["costamount"] = float.Parse(foundRow["costamount"].ToString()) + float.Parse(row["costamount"].ToString());
                        foundRow["service"] = float.Parse(foundRow["service"].ToString()) + float.Parse(row["service"].ToString());
                        foundRow["discount"] = float.Parse(foundRow["discount"].ToString()) + float.Parse(row["discount"].ToString());
                        foundRow["qanak"] = foundRow["quantity"].ToString();
                    }
                }
            }
        }

        private void command_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            System.Windows.Forms.Button[] tabArray = new System.Windows.Forms.Button[62] { tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12,
                tab13, tab14, tab15, tab16, tab17, tab18, tab19, tab20, tab21, tab22, tab23, tab24, tab25, tab26, tab27,
                tab28, tab29, tab30, tab31, tab32, tab33, tab34, tab35, tab36, tab37, tab38, tab39, tab40, tab41, tab42,
                tab43, tab44, tab45, tab46, tab47, tab48, tab49, tab50, tab51, tab52, tab53, tab54, tab55, tab56, tab57, tab58, tab59, tab60, tab61, tab62 };

            if ((command.Text + "          ").IndexOf("tab") >= 0)//սեղանի կոճակն է սեղմած
            {
                TipMoney.Enabled = true;
                PartnersComboBox.Enabled = true;
                ShtrichCode.BackColor = Color.White;
                numericUpDown3.BackColor = Color.White;
                TipMoney.BackColor = Color.White;
                ManagerBox.BackColor = Color.White;
                numericUpDown2.BackColor = Color.White;
                string table_clicked = command.Text;
                service.Tag = "0";
                discount.Tag = "0";
                string forbidden = "0";
                DataRow[] foundRows0 = TableNest.Select($"Nest = '{nest.Text}' ");

                if (foundRows0 != null)
                {
                    forbidden = foundRows0[0]["forbidden"].ToString();
                    service.Tag = foundRows0[0]["service"].ToString();   // սպասարկման տոկոս
                    discount.Tag = foundRows0[0]["discount"].ToString(); // զեղչի տոկոս
                    TipMoney.Text = foundRows0[0]["TipMoney"].ToString(); //թեյավճարը
                }
                if (remove.BackColor == Color.Green && forbidden == "0") //Տեղափոխում է։ նաև ստուգում է, որ ազատ լինի սեղանը
                {
                    if (nest.ForeColor == Color.Black)
                    {
                        int seans = int.Parse(Seans.Text);
                        string r1 = this.nest.Text;
                        string r2 = remove.Tag.ToString();
                        string r3 = bill.Text;
                        string r8 = TipMoney.Text;
                        //dbHelper = new SqlDatabaseHelper("localhost", "kafe_arm", "root", "");
                        //SqlConnection connection = dbHelper.GetConnection();
                        connection.Open();
                        string UpdateQuery = $"UPDATE TicketsOrdered SET  Nest= '{r1}' WHERE Nest= '{r2}' AND Ticket = '{r3}' AND Seans = '{seans}'  AND Previous='{_previous}' ";
                        using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();

                        DataRow[] foundRows = TableNest.Select("nest = '" + r2 + "'");
                        string r4 = foundRows[0]["printed"].ToString();
                        string r5 = foundRows[0]["taxprinted"].ToString();
                        string r6 = foundRows[0]["ticket"].ToString();
                        string r7 = foundRows[0]["person"].ToString();
                        UpdateQuery = $"UPDATE TableNest SET Ocupied= '0',Printed= '0',Person= '{0}',Ticket= '{0}',Tipmoney= '{0}'  WHERE Nest= '{r2}' AND Previous='{_previous}'";
                        using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();
                        UpdateQuery = $"UPDATE Tablenest SET Ocupied= '1',Printed= '{r4}',Person= '{r7}',Ticket= '{r6}',Tipmoney='{r8}'  WHERE Nest= '{r1}' AND Previous='{_previous}'";
                        using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();

                        UpdateQuery = $"UPDATE Seans SET Nest= '{r1}'  WHERE Nest= '{r2}' AND Ticket = '{r6}' ";
                        using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();
                        connection.Close();
                        remove.BackColor = Color.White;
                        remove.Visible = false;
                    }
                    else
                    {
                        this.nest.Text = remove.Tag.ToString();
                        this.command.Text = remove.Tag.ToString();
                    }

                }
                NestUpdate();

                this.number_enter.Focus();

                command.Text = "Enter";
                dataGridView1.Tag = "inorder";
                SendKeys.Send("{ENTER}");
                dataGridView2.Refresh();
            }


            if (command.Text == "number" && dataGridView1.Tag.ToString() == "inorder")//պատվերի ընթացքի մեջ ենք և թիվ ենք սեղմել
            {
                foreach (DataRow row in CurrentOrder.Rows)
                {

                    if (int.Parse(row["current"].ToString()) == 1)//.ToString() == dataGridView2.Tag.ToString())
                    {
                        float inspector = float.Parse(number_enter.Tag.ToString()) + float.Parse((((string)row["qanak"]).Trim() + command.Tag));// 

                        if (inspector < 0) //քանակից ավել մինուս չի թողնում 
                        {
                            break;
                        }
                        if (!(row["qanak"].ToString().IndexOf(".") >= 0 && command.Tag.ToString() == "."))  // որպեսզի երկու կետ չդրվի
                        {
                            row["qanak"] = ((string)row["qanak"]).Trim() + command.Tag;
                            dataGridView2.Refresh();
                        }
                    }
                }
            }

            System.Windows.Forms.Button[] groupArray = new System.Windows.Forms.Button[30] { group1, group2, group3, group4, group5, group6, group7, group8, group9, group10,
                group11, group12, group13, group14, group15, group16, group17, group18, group19, group20,
                group21, group22, group23, group24, group25, group26, group27,group28, group29, group30 };

            if ((command.Text.ToString() + "          ").IndexOf("tab") >= 0)//սեղանի կոճակն է սեղմած
            {
                int filterValue = int.Parse(command.Text.Substring(3));
                //սեղանների կոճակների գույներն է մաքրում ու ներկում համապատասխանը  
                for (int i = 0; i < 61; i++)
                {
                    if (tabArray[i].Enabled == false) continue;
                    tabArray[i].BackColor = Color.WhiteSmoke;
                }
                tabArray[filterValue - 1].BackColor = Color.GreenYellow;
            }

            if (ManagerBox.BackColor == Color.LightGreen && command.Text == "number")
            {
                ManagerBox.Text = ManagerBox.Text + command.Tag.ToString();
            }
            if (numericUpDown3.BackColor == Color.LightGreen && command.Text == "number")
            {
                numericUpDown3.Text = numericUpDown3.Text + command.Tag.ToString();
            }
            if (TipMoney.BackColor == Color.LightGreen && command.Text == "number")
            {
                TipMoney.Text = TipMoney.Text + command.Tag.ToString();
            }
            if (numericUpDown2.BackColor == Color.LightGreen && command.Text == "number")
            {
                numericUpDown2.Text = numericUpDown2.Text + command.Tag.ToString();
            }
        }
        private void tab1_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab1.Text)
            {
                this.nest.Text = tab1.Text;
                nest.ForeColor = tab1.ForeColor;
                this.command.Text = tab1.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab2_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab2.Text)
            {
                this.nest.Text = tab2.Text;
                nest.ForeColor = tab2.ForeColor;
                this.command.Text = tab2.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab3_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab3.Text)
            {
                this.nest.Text = tab3.Text;
                nest.ForeColor = tab3.ForeColor;
                this.command.Text = tab3.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab4_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab4.Text)
            {
                this.nest.Text = tab4.Text;
                nest.ForeColor = tab4.ForeColor;
                this.command.Text = tab4.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab5_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab5.Text)
            {
                this.nest.Text = tab5.Text;
                nest.ForeColor = tab5.ForeColor;
                this.command.Text = tab5.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab6_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab6.Text)
            {
                this.nest.Text = tab6.Text;
                nest.ForeColor = tab6.ForeColor;
                this.command.Text = tab6.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab7_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab7.Text)
            {
                this.nest.Text = tab7.Text;
                nest.ForeColor = tab7.ForeColor;
                this.command.Text = tab7.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab8_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab8.Text)
            {
                this.nest.Text = tab8.Text;
                nest.ForeColor = tab8.ForeColor;
                this.command.Text = tab8.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab9_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab9.Text)
            {
                this.nest.Text = tab9.Text;
                nest.ForeColor = tab9.ForeColor;
                this.command.Text = tab9.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab10_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab10.Text)
            {
                this.nest.Text = tab10.Text;
                nest.ForeColor = tab10.ForeColor;
                this.command.Text = tab10.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab11_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab11.Text)
            {
                this.nest.Text = tab11.Text;
                nest.ForeColor = tab11.ForeColor;
                this.command.Text = tab11.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab12_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab12.Text)
            {
                this.nest.Text = tab12.Text;
                nest.ForeColor = tab12.ForeColor;
                this.command.Text = tab12.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab13_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab13.Text)
            {
                this.nest.Text = tab13.Text;
                nest.ForeColor = tab13.ForeColor;
                this.command.Text = tab13.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab14_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab14.Text)
            {
                this.nest.Text = tab14.Text;
                nest.ForeColor = tab14.ForeColor;
                this.command.Text = tab14.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab15_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab15.Text)
            {
                this.nest.Text = tab15.Text;
                nest.ForeColor = tab15.ForeColor;
                this.command.Text = tab15.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab16_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab16.Text)
            {
                this.nest.Text = tab16.Text;
                nest.ForeColor = tab16.ForeColor;
                this.command.Text = tab16.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab17_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab17.Text)
            {
                this.nest.Text = tab17.Text;
                nest.ForeColor = tab17.ForeColor;
                this.command.Text = tab17.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab18_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab18.Text)
            {
                this.nest.Text = tab18.Text;
                nest.ForeColor = tab18.ForeColor;
                this.command.Text = tab18.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab19_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab19.Text)
            {
                this.nest.Text = tab19.Text;
                nest.ForeColor = tab19.ForeColor;
                this.command.Text = tab19.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab20_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab20.Text)
            {
                this.nest.Text = tab20.Text;
                nest.ForeColor = tab20.ForeColor;
                this.command.Text = tab20.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab21_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab21.Text)
            {
                this.nest.Text = tab21.Text;
                nest.ForeColor = tab21.ForeColor;
                this.command.Text = tab21.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab22_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab22.Text)
            {
                this.nest.Text = tab22.Text;
                nest.ForeColor = tab22.ForeColor;
                this.command.Text = tab22.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab23_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab23.Text)
            {
                this.nest.Text = tab23.Text;
                nest.ForeColor = tab23.ForeColor;
                this.command.Text = tab23.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab24_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab24.Text)
            {
                this.nest.Text = tab24.Text;
                nest.ForeColor = tab24.ForeColor;
                this.command.Text = tab24.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab25_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab25.Text)
            {
                this.nest.Text = tab25.Text;
                nest.ForeColor = tab25.ForeColor;
                this.command.Text = tab25.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab26_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab26.Text)
            {
                this.nest.Text = tab26.Text;
                nest.ForeColor = tab26.ForeColor;
                this.command.Text = tab26.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab27_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab27.Text)
            {
                this.nest.Text = tab27.Text;
                nest.ForeColor = tab27.ForeColor;
                this.command.Text = tab27.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab28_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab28.Text)
            {
                this.nest.Text = tab28.Text;
                nest.ForeColor = tab28.ForeColor;
                this.command.Text = tab28.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab29_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab29.Text)
            {
                this.nest.Text = tab29.Text;
                nest.ForeColor = tab29.ForeColor;
                this.command.Text = tab29.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab30_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab30.Text)
            {
                this.nest.Text = tab30.Text;
                nest.ForeColor = tab30.ForeColor;
                this.command.Text = tab30.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab31_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab31.Text)
            {
                this.nest.Text = tab31.Text;
                nest.ForeColor = tab31.ForeColor;
                this.command.Text = tab31.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab32_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab32.Text)
            {
                this.nest.Text = tab32.Text;
                nest.ForeColor = tab32.ForeColor;
                this.command.Text = tab32.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab33_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab33.Text)
            {
                this.nest.Text = tab33.Text;
                nest.ForeColor = tab33.ForeColor;
                this.command.Text = tab33.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab34_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab34.Text)
            {
                this.nest.Text = tab34.Text;
                nest.ForeColor = tab34.ForeColor;
                this.command.Text = tab34.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab35_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab35.Text)
            {
                this.nest.Text = tab35.Text;
                nest.ForeColor = tab35.ForeColor;
                this.command.Text = tab35.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab36_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab36.Text)
            {
                this.nest.Text = tab36.Text;
                nest.ForeColor = tab36.ForeColor;
                this.command.Text = tab36.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab37_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab37.Text)
            {
                this.nest.Text = tab37.Text;
                nest.ForeColor = tab37.ForeColor;
                this.command.Text = tab37.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab38_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab38.Text)
            {
                this.nest.Text = tab38.Text;
                nest.ForeColor = tab38.ForeColor;
                this.command.Text = tab38.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab39_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab39.Text)
            {
                this.nest.Text = tab39.Text;
                nest.ForeColor = tab39.ForeColor;
                this.command.Text = tab39.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab40_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab40.Text)
            {
                this.nest.Text = tab40.Text;
                nest.ForeColor = tab40.ForeColor;
                this.command.Text = tab40.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab41_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab41.Text)
            {
                this.nest.Text = tab41.Text;
                this.command.Text = tab41.Name;
                nest.ForeColor = tab41.ForeColor;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab42_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab42.Text)
            {
                this.nest.Text = tab42.Text;
                nest.ForeColor = tab42.ForeColor;
                this.command.Text = tab42.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab43_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab43.Text)
            {
                this.nest.Text = tab43.Text;
                nest.ForeColor = tab43.ForeColor;
                this.command.Text = tab43.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab44_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab44.Text)
            {
                this.nest.Text = tab44.Text;
                nest.ForeColor = tab44.ForeColor;
                this.command.Text = tab44.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab45_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab45.Text)
            {
                this.nest.Text = tab45.Text;
                nest.ForeColor = tab45.ForeColor;
                this.command.Text = tab45.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab46_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab46.Text)
            {
                this.nest.Text = tab46.Text;
                nest.ForeColor = tab46.ForeColor;
                this.command.Text = tab46.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab47_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab47.Text)
            {
                this.nest.Text = tab47.Text;
                nest.ForeColor = tab47.ForeColor;
                this.command.Text = tab47.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab48_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab48.Text)
            {
                this.nest.Text = tab48.Text;
                nest.ForeColor = tab48.ForeColor;
                this.command.Text = tab48.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab49_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab49.Text)
            {
                this.nest.Text = tab49.Text;
                nest.ForeColor = tab49.ForeColor;
                this.command.Text = tab49.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab50_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab50.Text)
            {
                this.nest.Text = tab50.Text;
                nest.ForeColor = tab50.ForeColor;
                this.command.Text = tab50.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab51_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab51.Text)
            {
                this.nest.Text = tab51.Text;
                nest.ForeColor = tab51.ForeColor;
                this.command.Text = tab51.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab52_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab52.Text)
            {
                this.nest.Text = tab52.Text;
                nest.ForeColor = tab52.ForeColor;
                this.command.Text = tab52.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab53_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab53.Text)
            {
                this.nest.Text = tab53.Text;
                nest.ForeColor = tab53.ForeColor;
                this.command.Text = tab53.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab54_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab54.Text)
            {
                this.nest.Text = tab54.Text;
                nest.ForeColor = tab54.ForeColor;
                this.command.Text = tab54.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab55_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab55.Text)
            {
                this.nest.Text = tab55.Text;
                nest.ForeColor = tab55.ForeColor;
                this.command.Text = tab55.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab56_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab56.Text)
            {
                this.nest.Text = tab56.Text;
                nest.ForeColor = tab56.ForeColor;
                this.command.Text = tab56.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab57_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab57.Text)
            {
                this.nest.Text = tab57.Text;
                nest.ForeColor = tab57.ForeColor;
                this.command.Text = tab57.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab58_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab58.Text)
            {
                this.nest.Text = tab58.Text;
                nest.ForeColor = tab58.ForeColor;
                this.command.Text = tab58.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab59_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab59.Text)
            {
                this.nest.Text = tab59.Text;
                nest.ForeColor = tab59.ForeColor;
                this.command.Text = tab59.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab60_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab60.Text)
            {
                this.nest.Text = tab60.Text;
                nest.ForeColor = tab60.ForeColor;
                this.command.Text = tab60.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab61_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab61.Text)
            {
                this.nest.Text = tab61.Text;
                nest.ForeColor = tab61.ForeColor;
                this.command.Text = tab61.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab62_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab62.Text)
            {
                this.nest.Text = tab62.Text;
                nest.ForeColor = tab62.ForeColor;
                this.command.Text = tab62.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab63_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab63.Text)
            {
                this.nest.Text = tab63.Text;
                nest.ForeColor = tab63.ForeColor;
                this.command.Text = tab63.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab64_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab64.Text)
            {
                this.nest.Text = tab64.Text;
                nest.ForeColor = tab64.ForeColor;
                this.command.Text = tab64.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab65_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab65.Text)
            {
                this.nest.Text = tab65.Text;
                nest.ForeColor = tab65.ForeColor;
                this.command.Text = tab65.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab66_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab66.Text)
            {
                this.nest.Text = tab66.Text;
                nest.ForeColor = tab66.ForeColor;
                this.command.Text = tab66.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab67_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab67.Text)
            {
                this.nest.Text = tab67.Text;
                nest.ForeColor = tab67.ForeColor;
                this.command.Text = tab67.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void tab68_Click(object sender, EventArgs e)
        {
            if (this.nest.Text != tab68.Text)
            {
                this.nest.Text = tab68.Text;
                nest.ForeColor = tab68.ForeColor;
                this.command.Text = tab68.Name;
                this.command.Focus();
                SendKeys.Send("{ENTER}");
            }
        }
        private void tab70_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Button[] tabArray = new System.Windows.Forms.Button[70] { tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13, tab14, tab15,
                tab16, tab17, tab18, tab19, tab20, tab21, tab22, tab23, tab24, tab25, tab26, tab27, tab28, tab29, tab30, tab31, tab32, tab33,
                tab34, tab35, tab36, tab37, tab38, tab39, tab40, tab41, tab42, tab43, tab44, tab45, tab46, tab47, tab48, tab49, tab50,
                tab51, tab52, tab53, tab54, tab55, tab56, tab57, tab58, tab59, tab60, tab61, tab62, tab63, tab64, tab65, tab66, tab67, tab68, tab69, tab70  };
            if (tab70.Text == "=>")
            {
                for (int i = 0; i < 68; i++)
                {
                    tabArray[i].Enabled = true;
                    tabArray[i].Text = _holl.ToString().Trim() + '-' + (i + 69).ToString();
                    DataRow[] foundRows = TableNest.Select("nest = '" + tabArray[i].Text + "'");
                    bool T = foundRows.Length == 0;
                    if (T == true) tabArray[i].Enabled = false;

                }
                tab70.Text = "<=";

            }
            else
            {
                for (int i = 0; i < 68; i++)
                {
                    tabArray[i].Enabled = true;
                    tabArray[i].Text = _holl.ToString().Trim() + '-' + (i + 1).ToString();
                    DataRow[] foundRows = TableNest.Select("nest = '" + tabArray[i].Text + "'");
                    bool T = foundRows.Length == 0;
                    if (T == true) tabArray[i].Enabled = false;

                }
                tab70.Text = "=>";
            }
            this.nest.Text = "";
            this.command.Text = "";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number5_Click(object sender, EventArgs e)
        {
            command.Tag = "5";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
            number_enter.BackColor = Color.LightGreen;
        }

        private void number0_Click(object sender, EventArgs e)
        {
            command.Tag = "0";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
            number_enter.BackColor = Color.LightGreen;
        }

        private void number6_Click(object sender, EventArgs e)
        {
            command.Tag = "6";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
            number_enter.BackColor = Color.LightGreen;
        }

        private void number1_Click(object sender, EventArgs e)
        {
            command.Tag = "1";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
            number_enter.BackColor = Color.LightGreen;
        }

        private void number7_Click(object sender, EventArgs e)
        {
            command.Tag = "7";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
            number_enter.BackColor = Color.LightGreen;
        }

        private void number2_Click(object sender, EventArgs e)
        {
            command.Tag = "2";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
            number_enter.BackColor = Color.LightGreen;
        }

        private void number8_Click(object sender, EventArgs e)
        {
            command.Tag = "8";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
            number_enter.BackColor = Color.LightGreen;
        }

        private void number3_Click(object sender, EventArgs e)
        {
            command.Tag = "3";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
            number_enter.BackColor = Color.LightGreen;
        }

        private void number9_Click(object sender, EventArgs e)
        {
            command.Tag = "9";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
            number_enter.BackColor = Color.LightGreen;
        }

        private void number4_Click(object sender, EventArgs e)
        {
            command.Tag = "4";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
            number_enter.BackColor = Color.LightGreen;
        }

        private void number_point_Click(object sender, EventArgs e)
        {
            command.Tag = ".";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number_enter_Click(object sender, EventArgs e)
        {
            if (numericUpDown3.BackColor == Color.LightGreen) // անձերի թիվն է դնում
            {
                string connectionString = Properties.Settings.Default.CafeRestDB;
                SqlConnection connection = new SqlConnection(connectionString);
                SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
                if (connection.State == ConnectionState.Closed) connection.Open();
                string UpdateQuery1 = $"UPDATE TicketsOrdered SET Person = '{int.Parse(numericUpDown3.Text)}'" +
    $"  WHERE Seans = '{Seans.Text}' AND Nest = '{nest.Text}' AND Ticket = '{int.Parse(bill.Text)}' AND Restaurant='{_restaurant}' ";
                using (SqlCommand updatCommand = new SqlCommand(UpdateQuery1, connection))
                    updatCommand.ExecuteNonQuery();
                connection.Close();
            }

            if (TipMoney.BackColor == Color.LightGreen)// թեյավճարն է դնում
            {
                string connectionString = Properties.Settings.Default.CafeRestDB;
                SqlConnection connection = new SqlConnection(connectionString);
                SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
                if (connection.State == ConnectionState.Closed) connection.Open();
                string UpdateQuery1 = $"UPDATE TicketsOrdered SET Tipmoney = '{float.Parse(TipMoney.Text)}'" +
    $"  WHERE Seans = '{Seans.Text}' AND Nest = '{nest.Text}' AND Ticket = '{int.Parse(bill.Text)}' AND Restaurant='{_restaurant}' ";
                using (SqlCommand updatCommand = new SqlCommand(UpdateQuery1, connection))
                    updatCommand.ExecuteNonQuery();

                string UpdateQuery2 = $"UPDATE TableNest SET Tipmoney = '{float.Parse(TipMoney.Text)}'" +
                    $"  WHERE  Nest = '{nest.Text}' AND Ticket = '{int.Parse(bill.Text)}' AND Restaurant='{_restaurant}' ";
                using (SqlCommand updatCommand = new SqlCommand(UpdateQuery2, connection))
                    updatCommand.ExecuteNonQuery();

                connection.Close();
            }

            DataRow[] foundRows0 = TableNest.Select($"Nest = '{nest.Text}' ");
            string forbidden = "0";
            if (foundRows0 != null)
            {
                forbidden = foundRows0[0]["forbidden"].ToString();
            }
            if (numericUpDown2.BackColor == Color.LightGreen || numericUpDown1.BackColor == Color.LightGreen)
            {
                StandartOrder();
                dataGridView1.Tag = "";
            }
            number_enter.BackColor = Color.White;
            ShtrichCode.BackColor = Color.White;
            numericUpDown3.BackColor = Color.White;
            TipMoney.BackColor = Color.White;
            ManagerBox.BackColor = Color.White;
            numericUpDown1.BackColor = Color.White;
            numericUpDown2.BackColor = Color.White;

            if (dataGridView1.Tag.ToString() == "inorder")//պատվերի ընթացքի մեջ ենք և "Enter" ենք սեղմել
            {
                float a_m = 0;
                float w_t = 0;
                float d_q = 0;
                bool acc = false;
                accept.Visible = false;
                printbutton1.Visible = false;
                printbutton2.Visible = false;
                cancel.Visible = false;
                foreach (DataRow row in CurrentOrder.Rows)
                {


                    //if (row["id"].ToString() == dataGridView2.Tag.ToString())
                    if (int.Parse(row["current"].ToString()) == 1 && row["qanak"].ToString().Length > 0 && row["qanak"].ToString() != "-")
                    {

                        acc = true;
                        row["quantity"] = float.Parse(row["qanak"].ToString());
                        row["salesamount"] = float.Parse(row["quantity"].ToString()) * float.Parse(row["price"].ToString());
                        row["costamount"] = float.Parse(row["quantity"].ToString()) * float.Parse(row["costprice"].ToString());
                        if (int.Parse(row["free"].ToString()) == 0)
                        {
                            row["service"] = float.Parse(row["salesamount"].ToString()) * float.Parse(service.Tag.ToString()) * 0.01;
                            row["discount"] = float.Parse(row["salesamount"].ToString()) * float.Parse(discount.Tag.ToString()) * 0.01;
                        }
                        else
                        {
                            row["service"] = 0;
                            row["discount"] = 0;
                        }
                        row["current"] = 0;
                        dataGridView2.Tag = "none";
                        dataGridView2.Refresh();
                    }
                    a_m += float.Parse(row["quantity"].ToString()) * float.Parse(row["price"].ToString());//սեղանի գումարը 
                    if (service.Tag != null && row["service"].ToString().Length > 0)
                    {
                        w_t += float.Parse(row["service"].ToString());
                    }
                    if (discount.Tag != null && row["discount"].ToString().Length > 0)
                    {
                        d_q += float.Parse(row["discount"].ToString());
                    }

                }
                amount.Text = a_m.ToString();
                service.Text = w_t.ToString();
                discount.Text = d_q.ToString();
                total.Text = (float.Parse(amount.Text) + float.Parse(service.Text) - float.Parse(discount.Text)).ToString();
                remove.Visible = false;
                if (forbidden == "0")  //սեղանը արգելված չէ
                {

                    dataGridView1.Enabled = true;//տպած սեղանին փոփոխություն չի թույլատրվում
                    dataGridView2.Enabled = true;
                    if (acc)
                    {
                        accept.Visible = true;
                    }

                    if (a_m > 0)
                    {
                        if (nest.ForeColor != Color.Black) // արդեն նստած սեղան է
                        {
                            printbutton1.Visible = true;
                            printbutton2.Visible = true;
                            remove.Visible = true;
                        }
                        if (nest.ForeColor == Color.Orange) // եթե տպած է, մարելու կոճակը երևում է
                        {
                            cancel.Visible = true;
                            dataGridView1.Enabled = false;//տպած սեղանին փոփոխություն չի թույլատրվում
                            dataGridView2.Enabled = false;
                            remove.Visible = false;
                        }
                    }

                }
                else  //սեղանը արգելված է
                {
                    dataGridView1.Enabled = false;
                    dataGridView2.Enabled = false;
                }
            }
            if (numericUpDown3.BackColor == Color.LightGreen) numericUpDown3.BackColor = Color.Wheat;
            if (ManagerBox.BackColor == Color.LightGreen) ManagerBox.BackColor = Color.Wheat;
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in CurrentOrder.Rows)
            {
                if (row["id"].ToString() == dataGridView2.Tag.ToString())
                {
                    int L = row["qanak"].ToString().Length;
                    if (L > 0 && row["qanak"].ToString() != "-")
                    {
                        row["qanak"] = row["qanak"].ToString().Substring(0, L - 1); //աջից մեկ սիմվոլ ենք հեռացնում
                        dataGridView2.Refresh();
                    }
                }
            }
        }

        private void accept_Click(object sender, EventArgs e)
        {
            tableforprint = CurrentOrder.Clone();
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (connection.State == ConnectionState.Closed) connection.Open();
            int tick = 1;

            foreach (DataRow row in TicketsOrdered.Rows)
            {
                if (int.Parse(row["Restaurant"].ToString()) != _restaurant ||
                    int.Parse(row["Holl"].ToString()) != _holl) continue;
                if (int.Parse(row["Paid"].ToString()) == 0 && row["Nest"].ToString() == nest.Text)
                {
                    tick = int.Parse(row["Ticket"].ToString());
                    break;
                }
                if (int.Parse(row["Ticket"].ToString()) >= tick) tick = int.Parse(row["Ticket"].ToString()) + 1;
            }
            bill.Text = tick.ToString();
            int seans_state = int.Parse(Seans.Text);
            int person = 0;
            if (numericUpDown3.Value.ToString().Length > 0) person = int.Parse(numericUpDown3.Value.ToString());
            float tipmoney = 0;
            if (TipMoney.Text.Length > 0) tipmoney = float.Parse(TipMoney.Text);
            int group = 0;
            decimal gidd = 0;
            if (gid.Text.Length > 0)
            {
                gidd = decimal.Parse(gid.Text);
            }

            DataRow[] foundRows0 = TableNest.Select($"Nest = '{nest.Text}' ");
            if (foundRows0 != null)
            {
                group = int.Parse(foundRows0[0]["groupp"].ToString());   // սեղանի խումբն է
            }
            if (connection.State == ConnectionState.Closed) connection.Open();
            float delivery = 0;
            float music = 0;
            float cost = 0;
            float cash = 0;
            float cashless = 0;
            foreach (DataRow row in CurrentOrder.Rows)  // չգրանցված պատվերները գրանցվում են  Seans - ում
            {
                cost = cost + float.Parse(row["costamount"].ToString());
                string name = row["name"].ToString();
                bool accepted = bool.Parse(row["accepted"].ToString());
                int groupp = int.Parse(row["groupp"].ToString());

                if (groupp == 291)
                {
                    delivery = delivery + float.Parse(row["salesamount"].ToString());
                }
                if (groupp == 292) music = music + float.Parse(row["salesamount"].ToString());
                if (accepted == true)
                {

                    continue; // Skip the loop if conditions are met
                }

                //պատվերի կտրոնն ենք ձևավորում 

                DataRow newRow = tableforprint.NewRow();
                tableforprint.Rows.Add(newRow);
                for (int colIndex = 0; colIndex < CurrentOrder.Columns.Count; colIndex++)
                {
                    string columnName = CurrentOrder.Columns[colIndex].ColumnName;
                    newRow[columnName] = row[columnName];
                }


                if (_previous == 0)
                {
                    string InsertQuery = $"INSERT INTO Seans ( Code, Groupp, DateOfEntry, Seans, Ticket, Paid," +
                        $"Nest ,Quantity ,Costprice , Price, Costamount, Salesamount, Service, Discount, Free, Taxpaid, Restaurant, Holl, Operator, DepartmentOut)" +
                        $" values (@Code , @Groupp, @DateOfEntry, @Seans, @Ticket, @Paid, @Nest ," +
                        $"@Quantity,@Costprice ,@Price, @Costamount, @Salesamount, @Service, @Discount, @Free, @Taxpaid, @Restaurant, @Holl, @Operator, @Department ) ";
                    using (SqlCommand insertCommand = new SqlCommand(InsertQuery, connection))

                    {
                        insertCommand.Parameters.AddWithValue("@Code", row["code"]);
                        insertCommand.Parameters.AddWithValue("@Groupp", groupp);
                        insertCommand.Parameters.AddWithValue("@DateOfEntry", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@Seans", Seans.Text);
                        insertCommand.Parameters.AddWithValue("@Ticket", tick);
                        insertCommand.Parameters.AddWithValue("@Paid", 0);
                        insertCommand.Parameters.AddWithValue("@Nest", nest.Text);
                        insertCommand.Parameters.AddWithValue("@Quantity", row["quantity"]);
                        insertCommand.Parameters.AddWithValue("@Costprice", row["Costprice"]);
                        insertCommand.Parameters.AddWithValue("@Price", row["price"]);
                        insertCommand.Parameters.AddWithValue("@Costamount", row["Costamount"]);
                        insertCommand.Parameters.AddWithValue("@Salesamount", row["salesamount"]);
                        insertCommand.Parameters.AddWithValue("@Service", row["Service"]);
                        insertCommand.Parameters.AddWithValue("@Discount", row["Discount"]);
                        insertCommand.Parameters.AddWithValue("@Department", row["department"]);
                        insertCommand.Parameters.AddWithValue("@Free", row["Free"]);
                        insertCommand.Parameters.AddWithValue("@Taxpaid", 0);
                        insertCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        insertCommand.Parameters.AddWithValue("@Holl", _holl);
                        insertCommand.Parameters.AddWithValue("@Operator", _ooperator);

                        insertCommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    string InsertQuery = $"INSERT INTO Previous_215 ( Code, Groupp, DateOfEntry, Seans, Ticket, Paid," +
    $"Nest ,Quantity ,Costprice, Price, Costamount, Salesamount, Service, Discount, Free, Taxpaid, Restaurant, Holl, Operator,  DepartmentOut)" +
    $" values (@Code, @Groupp, @DateOfEntry, @Seans, @Ticket, @Paid, @Nest ," +
    $"@Quantity,@Costprice ,@Price, @Costamount, @Salesamount, @Service, @Discount, @Free, @Taxpaid, @Restaurant, @Holl, @Operator, @Department ) ";
                    using (SqlCommand insertCommand = new SqlCommand(InsertQuery, connection))

                    {
                        insertCommand.Parameters.AddWithValue("@Code", row["code"]);
                        insertCommand.Parameters.AddWithValue("@Groupp", groupp);
                        insertCommand.Parameters.AddWithValue("@DateOfEntry", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@Seans", Seans.Text);
                        insertCommand.Parameters.AddWithValue("@Ticket", tick);
                        insertCommand.Parameters.AddWithValue("@Paid", 0);
                        insertCommand.Parameters.AddWithValue("@Nest", nest.Text);
                        insertCommand.Parameters.AddWithValue("@Quantity", row["quantity"]);
                        insertCommand.Parameters.AddWithValue("@Costprice", row["Costprice"]);
                        insertCommand.Parameters.AddWithValue("@Price", row["price"]);
                        insertCommand.Parameters.AddWithValue("@Costamount", row["Costamount"]);
                        insertCommand.Parameters.AddWithValue("@Salesamount", row["salesamount"]);
                        insertCommand.Parameters.AddWithValue("@Service", row["Service"]);
                        insertCommand.Parameters.AddWithValue("@Discount", row["Discount"]);
                        insertCommand.Parameters.AddWithValue("@Department", row["department"]);
                        insertCommand.Parameters.AddWithValue("@Free", row["Free"]);
                        insertCommand.Parameters.AddWithValue("@Taxpaid", 0);
                        insertCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        insertCommand.Parameters.AddWithValue("@Holl", _holl);
                        insertCommand.Parameters.AddWithValue("@Operator", _ooperator);

                        insertCommand.ExecuteNonQuery();
                    }
                }
            }

            DataRow[] foundRowsTI = TicketsOrdered.Select($"Nest= '{nest.Text}' AND Ticket= '{tick}' AND" +
                $" Seans = '{seans_state}' AND Restaurant = '{_restaurant}' AND Holl = '{_holl}' ");

            if (foundRowsTI.Length == 0)
            {
                string InsertQuery = $"INSERT INTO TicketsOrdered  (Seans,Nest,DateBegin,DateEnd,Ticket," +
                    $"SalesAmount,Costamount,Delivery,Music,Cash,Cashless,Service,Discount,Paid,Person,Tipmoney,Nestgroup,Holl,Restaurant,Gid,Previous) VALUES  (@seans, @nest, @DateBegin, @DateEnd," +
                    $" @ticket,@salesamount,@Costamount,@delivery,@music,@cash,@cashless, @service, @discount,@paid, @person,@tipmoney,@group,@holl, @restaurant,@gid,@Previous)";
                using (SqlCommand updatCommand = new SqlCommand(InsertQuery, connection))

                {
                    updatCommand.Parameters.AddWithValue("@seans", seans_state);
                    updatCommand.Parameters.AddWithValue("@nest", nest.Text);
                    updatCommand.Parameters.AddWithValue("@DateBegin", DateTime.Now);
                    updatCommand.Parameters.AddWithValue("@DateEnd", DateTime.Now);
                    updatCommand.Parameters.AddWithValue("@ticket", tick);
                    updatCommand.Parameters.AddWithValue("@salesamount", int.Parse(amount.Text));
                    updatCommand.Parameters.AddWithValue("@costamount", cost);
                    updatCommand.Parameters.AddWithValue("@delivery", delivery);
                    updatCommand.Parameters.AddWithValue("@music", music);
                    updatCommand.Parameters.AddWithValue("@cash", 0);
                    updatCommand.Parameters.AddWithValue("@cashless", 0);
                    updatCommand.Parameters.AddWithValue("@service", int.Parse(service.Text));
                    updatCommand.Parameters.AddWithValue("@discount", int.Parse(discount.Text));
                    updatCommand.Parameters.AddWithValue("@paid", 0);
                    updatCommand.Parameters.AddWithValue("@person", person);
                    updatCommand.Parameters.AddWithValue("@tipmoney", tipmoney);
                    updatCommand.Parameters.AddWithValue("@group", group);
                    updatCommand.Parameters.AddWithValue("@holl", _holl);
                    updatCommand.Parameters.AddWithValue("@restaurant", _restaurant);
                    updatCommand.Parameters.AddWithValue("@gid", gidd);
                    updatCommand.Parameters.AddWithValue("@Previous", _previous);
                    updatCommand.ExecuteNonQuery();
                }

            }
            else
            {

                string UpdateQuery1 = $"UPDATE TicketsOrdered SET SalesAmount = '{float.Parse(amount.Text)}',CostAmount= '{cost}'," +
                    $"Service= '{float.Parse(service.Text)}',Discount='{float.Parse(discount.Text)}' , Gid= '{gidd}', " +
                    $"Delivery='{delivery}',Music='{music}',Person= '{person}',Tipmoney = '{tipmoney}'" +
                    $"  WHERE Seans = '{Seans.Text}' AND Nest = '{nest.Text}' AND Ticket = '{tick}' AND Restaurant='{_restaurant}' ";
                using (SqlCommand updatCommand = new SqlCommand(UpdateQuery1, connection))
                    updatCommand.ExecuteNonQuery();
            }

            string UpdateQuery2 = $"UPDATE TableNest SET Ocupied= '1',Printed= '0',Person = '{person}',Ticket = '{tick}'," +
                $"Tipmoney= '{float.Parse(TipMoney.Text)}'  WHERE Nest = '{nest.Text}' AND Restaurant = '{_restaurant}' AND Holl = '{_holl}' AND Previous = '{_previous}'";
            using (SqlCommand updatCommand = new SqlCommand(UpdateQuery2, connection))
                updatCommand.ExecuteNonQuery();

            dataGridView2.Refresh();

            string query = $"SELECT * FROM TableNest WHERE Restaurant='{_restaurant}'  AND Holl = '{_holl}'  AND Previous = '{_previous}'";//սեղանների աղյուսակը թարմացնում ենք
            TableNest = dbHelper.ExecuteQuery(query);
            NestUpdate();
            connection.Close();

            // տպվում են պատվերի կտրոնները համաատասխան տպիչների վրա
            print(1); print(2); print(3); print(4); print(5);
            print(6); print(7); print(8); print(9); print(10);
            print(11); print(12); print(13); print(14); print(15);

            printbutton1.Visible = true;
            printbutton2.Visible = true;
            accept.Visible = false;

        }

        private void print(int printer1)
        {


            Translate.translation(Table215, tableforprint, _language, "3");
            int p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0, p8 = 0, p9 = 0, p10 = 0, p11 = 0, p12 = 0, p13 = 0, p14 = 0, p15 = 0;

            DataTable Order = new DataTable();
            Order.Columns.Add("name", typeof(string));
            Order.Columns.Add("price", typeof(float));
            Order.Columns.Add("quantity", typeof(float));
            Order.Columns.Add("salesamount", typeof(float));

            foreach (DataRow row in tableforprint.Rows)
            {
                //****************************** ստուգում ենք որ տպիչի վրա կա տպելիք
                if (int.Parse(row["printer"].ToString()) == 1) p1 = 1;
                if (int.Parse(row["printer"].ToString()) == 2) p2 = 1;
                if (int.Parse(row["printer"].ToString()) == 3) p3 = 1;
                if (int.Parse(row["printer"].ToString()) == 4) p4 = 1;
                if (int.Parse(row["printer"].ToString()) == 5) p5 = 1;
                if (int.Parse(row["printer"].ToString()) == 6) p6 = 1;
                if (int.Parse(row["printer"].ToString()) == 7) p7 = 1;
                if (int.Parse(row["printer"].ToString()) == 8) p8 = 1;
                if (int.Parse(row["printer"].ToString()) == 9) p9 = 1;
                if (int.Parse(row["printer"].ToString()) == 10) p10 = 1;
                if (int.Parse(row["printer"].ToString()) == 11) p11 = 1;
                if (int.Parse(row["printer"].ToString()) == 12) p12 = 1;
                if (int.Parse(row["printer"].ToString()) == 13) p13 = 1;
                if (int.Parse(row["printer"].ToString()) == 14) p14 = 1;
                if (int.Parse(row["printer"].ToString()) == 15) p15 = 1;
                //******************************************
                if (int.Parse(row["printer"].ToString()) != printer1 || float.Parse(row["quantity"].ToString()) == 0) continue;
                DataRow newRow = Order.NewRow();
                Order.Rows.Add(newRow);
                newRow["name"] = row["name"];
                newRow["quantity"] = float.Parse(row["quantity"].ToString());
                newRow["price"] = float.Parse(row["price"].ToString());
                newRow["salesamount"] = float.Parse(row["salesamount"].ToString());
            }

            if (Order.Rows.Count > 0)
            {
                DataRow newRow0 = Order.NewRow();
                Order.Rows.Add(newRow0);
                newRow0["name"] = "=======================";
                if (p1 == 1 && printer1 != 1)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 1 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p2 == 1 && printer1 != 2)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 2 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p3 == 1 && printer1 != 3)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 3 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p4 == 1 && printer1 != 4)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 4 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p5 == 1 && printer1 != 5)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 5 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p6 == 1 && printer1 != 6)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 6 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p7 == 1 && printer1 != 7)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 7 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p8 == 1 && printer1 != 8)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 8 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p9 == 1 && printer1 != 9)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 9 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p10 == 1 && printer1 != 10)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 10 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p11 == 1 && printer1 != 11)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 11 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p12 == 1 && printer1 != 12)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 12 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p13 == 1 && printer1 != 13)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 13 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p14 == 1 && printer1 != 14)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 14 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p15 == 1 && printer1 != 15)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 15 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                string reportname = "";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("nest", nest.Text);
                parameters.Add("person", numericUpDown3.Value.ToString());
                parameters.Add("restaurant", Restaurantname);
                parameters.Add("operator", _ooperatorname);
                parameters.Add("ticket", bill.Text);

                ReportManager reportManager = new ReportManager();
                reportManager.PreviewReport("BillReport", $"d:\\hayrik\\sql\\windowsformsapp4\\OrderReport.rdlc", Order, parameters, null);
            }



        }
        private void printbutton1_Click(object sender, EventArgs e)
        {
            ////////////////////////////////
            //  տպում է կտրոնը 
            ////////////////////////////////
            BillReport(1);
        }
        private void printbutton2_Click(object sender, EventArgs e)
        {
            ////////////////////////////////
            //  տպում է նախահաշիվը
            ////////////////////////////////
            BillReport(2);
        }
        private void BillReport(int parameter)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            int previous = 1;  //նախահաշիվ է 
            if (parameter == 1)
            {
                previous = 0;

                cancel.Visible = true;
                dataGridView1.Enabled = false;//տպած սեղանին փոփոխություն չի թույլատրվում
                remove.Visible = false;
                string nst = nest.Text;

                string UpdateQuery = $"UPDATE TableNest SET Printed= '1'  WHERE Nest= '{nest.Text}' AND Restaurant='1'  AND Previous = '{_previous}'";
                using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                    updatCommand.ExecuteNonQuery();
                string selectquery = $"SELECT * FROM TableNest WHERE Restaurant='{_restaurant}'  AND Previous = '{_previous}'";//սեղանների աղյուսակը թարմացնում ենք
                TableNest = dbHelper.ExecuteQuery(selectquery);

            }
            DateTime DateBegin = DateTime.Now;
            if (_previous == 0)
            {
                string selectquery1 = $"SELECT * FROM seans  WHERE Nest= '{nest.Text}' AND Ticket='{bill.Text}' And seans='{Seans.Text}' AND Restaurant='{_restaurant}' ";//սեղանների աղյուսակը թարմացնում ենք
                TableSeans = dbHelper.ExecuteQuery(selectquery1);
            }
            else
            {
                string selectquery1 = $"SELECT * FROM Previous_215  WHERE Nest= '{nest.Text}' AND Ticket='{bill.Text}' And seans='{Seans.Text}' AND Restaurant='{_restaurant}' ";//սեղանների աղյուսակը թարմացնում ենք
                TableSeans = dbHelper.ExecuteQuery(selectquery1);
            }
            foreach (DataRow row in TableSeans.Rows)
            {
                DateBegin = DateTime.Parse(row["DateOfEntry"].ToString());
                break;
            }
            //ձևավորում ենք կտրոնի աղյուսակը
            connection.Close();
            BillPrint = CurrentOrder.Clone();
            foreach(DataRow row in CurrentOrder.Rows)
            {if (float.Parse(row["quantity"].ToString()) == 0) continue;
                DataRow newRow = BillPrint.NewRow();
                BillPrint.Rows.Add(newRow);
                for (int colIndex = 0; colIndex < CurrentOrder.Columns.Count; colIndex++)
                {
                    string columnName = CurrentOrder.Columns[colIndex].ColumnName;
                    newRow[columnName] = row[columnName];
                }
            }
            Translate.translation(Table215, BillPrint, _language, "1");
            PrintingBill.PrintBill(bill.Text, nest.Text, gid.Text, TipMoney.Text, 0, previous, DateBegin, DateTime.Now, BillPrint, Restaurantname, _language);

        }

        private void forbidden_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            //բազայում տվյալ ապրանքի exist դաշտը դարձնել "0" դատարկ
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectTable2Query = $"SELECT * FROM Table_215 WHERE code = {radioButton1.Tag}  AND Restaurant='{_restaurant}'";
            SqlCommand selectTable2Command = new SqlCommand(selectTable2Query, connection);
            object result = selectTable2Command.ExecuteScalar();
            if (result != null)
            {
                // Record found in Table2, update the name
                string updateTable2Query = $"UPDATE Table_215 SET Existent = 0 WHERE code = {radioButton1.Tag} AND Restaurant='{_restaurant}'";
                SqlCommand updateTable2Command = new SqlCommand(updateTable2Query, connection);
                updateTable2Command.ExecuteNonQuery();
            }
            DataRow[] foundRows = Table_215.Select($"Code = '{radioButton1.Tag}' AND Restaurant ='{_restaurant}'");
            if (foundRows.Length > 0) foundRows[0]["Existent"] = 0;
            connection.Close();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //բազայում տվյալ ապրանքի exist դաշտը դարձնել "3" ։ ապրանքը արգելել
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectTable2Query = $"SELECT * FROM Table_215 WHERE code = {radioButton1.Tag} AND Restaurant ='{_restaurant}'";
            SqlCommand selectTable2Command = new SqlCommand(selectTable2Query, connection);
            object result = selectTable2Command.ExecuteScalar();
            if (result != null)
            {
                // Record found in Table2, update the name
                string updateTable2Query = $"UPDATE Table_215 SET Existent = '3' WHERE Code = {radioButton1.Tag}  AND Restaurant ='{_restaurant}'";
                SqlCommand updateTable2Command = new SqlCommand(updateTable2Query, connection);
                updateTable2Command.ExecuteNonQuery();
            }
            DataRow[] foundRows = Table_215.Select($"Code = '{radioButton1.Tag}' AND Restaurant ='{_restaurant}'");
            if(foundRows.Length>0) foundRows[0]["Existent"] = 3;

            connection.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //բազայում տվյալ ապրանքի exist դաշտը դարձնել "2" ։ Աշխատել որ վաճառվի
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectTable2Query = $"SELECT * FROM Table_215 WHERE Code = {radioButton1.Tag} AND Restaurant ='{_restaurant}'";
            SqlCommand selectTable2Command = new SqlCommand(selectTable2Query, connection);
            object result = selectTable2Command.ExecuteScalar();
            if (result != null)
            {
                // Record found in Table2, update the name
                string updateTable2Query = $"UPDATE Table_215 SET Existent = '2' WHERE Code = {radioButton1.Tag} AND Restaurant ='{_restaurant}'";
                SqlCommand updateTable2Command = new SqlCommand(updateTable2Query, connection);
                updateTable2Command.ExecuteNonQuery();
            }
            DataRow[] foundRows = Table_215.Select($"Code = {radioButton1.Tag} AND Restaurant ='{_restaurant}'");
            if (foundRows.Length > 0) foundRows[0]["Existent"] = 2;
            connection.Close();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (remove.BackColor == Color.Green)
            {
                remove.BackColor = Color.White;
                remove.Visible = false;
                return;
            }
            if (amount.Text.Length != 0 && float.Parse(amount.Text) > 0)
            {
                remove.BackColor = Color.Green;
                remove.Tag = nest.Text;
            }
        }
        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //return;
            Current_columnIndex = CurrentOrder.Columns.IndexOf("Current");
            if (e.RowIndex > 0 && e.ColumnIndex <= dataGridView2.ColumnCount) // Check for a specific column index and ignore the header row
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                string cur = row.Cells[Current_columnIndex].Value.ToString();
                if (cur == "1") // Change the condition as per your requirement
                {

                    // Change the row color to, for example, LightGreen
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {

                    // Reset the default colors if the condition doesn't match
                    row.DefaultCellStyle.BackColor = dataGridView2.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = dataGridView2.DefaultCellStyle.ForeColor;
                }

            }

        }

        private void departmentclick_Click(object sender, EventArgs e)
        {
            Button[] groupArray = new System.Windows.Forms.Button[30] { group1, group2, group3, group4, group5, group6, group7, group8, group9, group10,
                group11, group12, group13, group14, group15, group16, group17, group18, group19, group20,
                group21, group22, group23, group24, group25, group26, group27,group28, group29, group30 };
            for (int j = 0; j < 30; j++)
            {
                groupArray[j].Visible = false;
                groupArray[j].Tag = "0";
            }
            string dep = DepartmentClick.Tag.ToString();
            department1.BackColor = Color.White;
            department2.BackColor = Color.White;
            department3.BackColor = Color.White;
            department4.BackColor = Color.White;
            if (dep == "1")
            {
                department1.BackColor = Color.LimeGreen;
            }
            if (dep == "2")
            {
                department2.BackColor = Color.LimeGreen;
            }
            if (dep == "3")
            {
                department3.BackColor = Color.LimeGreen;
            }
            if (dep == "4")
            {
                department4.BackColor = Color.LimeGreen;
            }
            dataView = new DataView(Table_215);
            dataView.RowFilter = "Department = " + dep;




            dataGridView1.DataSource = dataView;
            int i = -1;
            int k = 0;
            foreach (DataRowView rowView in dataView)//տվյալ բաժնի խմբերի կոճակներն ենք կարգավորում

            {
                if (i < 29)
                {
                    DataRow row = rowView.Row;
                    DataRow[] matchingRows = FoodGroupp.Select($"Groupp = {row["Groupp"]}");
                    if (matchingRows.Length > 0)
                    {
                        k = 0;
                        for (int j = 0; j < 29; j++)
                        {
                            if (matchingRows[0]["Groupp"].ToString() == groupArray[j].Tag.ToString()) k = 1;
                        }
                        if (k == 1) continue; // տվյալ խմբի կոճակը արդեն ֆիքսել ու ձևավորել ենք
                        i++;
                        groupArray[i].Text = matchingRows[0]["Name"].ToString();
                        groupArray[i].Tag = matchingRows[0]["Groupp"].ToString();
                        groupArray[i].Visible = true;
                    }
                }

            }
        }

        private void GroupClick_Click(object sender, EventArgs e)
        {
            Button[] groupArray = new System.Windows.Forms.Button[30] { group1, group2, group3, group4, group5, group6, group7, group8, group9, group10,
                group11, group12, group13, group14, group15, group16, group17, group18, group19, group20,
                group21, group22, group23, group24, group25, group26, group27,group28, group29, group30 };
            for (int i = 0; i < 29; i++)
            {
                groupArray[i].BackColor = Color.White;
                if (groupArray[i].Tag == GroupClick.Tag)
                {
                    groupArray[i].BackColor = Color.LightGreen;
                }
            }

            dataView = new DataView(Table_215);
            dataView.RowFilter = $"Department = " + DepartmentClick.Tag.ToString() + " AND Groupp = " + GroupClick.Tag.ToString();//բաժինը և խումբը ընտրվածներն են
            dataGridView1.DataSource = dataView;
        }

        private void addition1_Click(object sender, EventArgs e)
        {
            if (addition1.BackColor == Color.LightGreen)
            {
                addition1.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                AdditionClick.Tag = "1";
                AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition2_Click(object sender, EventArgs e)
        {
            if (addition2.BackColor == Color.LightGreen)
            {
                addition2.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                AdditionClick.Tag = "2";
                AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition3_Click(object sender, EventArgs e)
        {
            if (this.addition3.BackColor == Color.LightGreen)
            {
                this.addition3.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "3";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition4_Click(object sender, EventArgs e)
        {
            if (this.addition4.BackColor == Color.LightGreen)
            {
                this.addition4.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "4";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition5_Click(object sender, EventArgs e)
        {
            if (this.addition5.BackColor == Color.LightGreen)
            {
                this.addition5.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "5";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition6_Click(object sender, EventArgs e)
        {
            if (this.addition6.BackColor == Color.LightGreen)
            {
                this.addition6.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "6";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition7_Click(object sender, EventArgs e)
        {
            if (this.addition7.BackColor == Color.LightGreen)
            {
                this.addition7.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "7";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition8_Click(object sender, EventArgs e)
        {
            if (this.addition8.BackColor == Color.LightGreen)
            {
                this.addition8.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "8";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition9_Click(object sender, EventArgs e)
        {
            if (this.addition9.BackColor == Color.LightGreen)
            {
                this.addition9.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "9";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition10_Click(object sender, EventArgs e)
        {
            if (this.addition10.BackColor == Color.LightGreen)
            {
                this.addition10.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "10";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition11_Click(object sender, EventArgs e)
        {
            if (this.addition11.BackColor == Color.LightGreen)
            {
                this.addition11.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "11";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition12_Click(object sender, EventArgs e)
        {
            if (this.addition12.BackColor == Color.LightGreen)
            {
                this.addition12.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "12";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition13_Click(object sender, EventArgs e)
        {
            if (this.addition13.BackColor == Color.LightGreen)
            {
                this.addition13.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "13";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition14_Click(object sender, EventArgs e)
        {
            if (this.addition14.BackColor == Color.LightGreen)
            {
                this.addition14.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "14";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition15_Click(object sender, EventArgs e)
        {
            if (this.addition15.BackColor == Color.LightGreen)
            {
                this.addition15.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "15";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition16_Click(object sender, EventArgs e)
        {
            if (this.addition16.BackColor == Color.LightGreen)
            {
                this.addition16.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "16";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition17_Click(object sender, EventArgs e)
        {
            if (this.addition17.BackColor == Color.LightGreen)
            {
                this.addition17.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "17";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition18_Click(object sender, EventArgs e)
        {
            if (this.addition18.BackColor == Color.LightGreen)
            {
                this.addition18.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "18";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition19_Click(object sender, EventArgs e)
        {
            if (this.addition19.BackColor == Color.LightGreen)
            {
                this.addition19.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "19";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition20_Click(object sender, EventArgs e)
        {
            if (this.addition20.BackColor == Color.LightGreen)
            {
                this.addition20.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "20";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void AdditionClick_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button[] buttonArray = new System.Windows.Forms.Button[20] { addition1, addition2, addition3, addition4, addition5, addition6, addition7, addition8, addition9, addition10,
                addition11, addition12, addition13, addition14, addition15, addition16, addition17, addition18, addition19, addition20 };
            for (int j = 0; j < 19; j++)
            {
                buttonArray[j].BackColor = Color.White;
                if (j == int.Parse(AdditionClick.Tag.ToString()) - 1) buttonArray[j].BackColor = Color.LightGreen;
            }
            dataGridView3.Visible = false;
            int number = int.Parse(AdditionClick.Tag.ToString());
            dataView = new DataView(AdditionNames);
            dataView.RowFilter = "Number = " + number;
            dataGridView3.DataSource = dataView;
            dataGridView3.Width = dataGridView1.Left - 5;
            dataGridView3.Columns[0].Width = dataGridView3.Width;
            if (int.Parse(AdditionClick.Tag.ToString()) >= 0)
            {
                dataGridView3.Visible = true;
            }
        }

        private void numericUpDown3_Enter(object sender, EventArgs e)
        {
            command.Text = "number";
            dataGridView1.Tag = "none";
            ShtrichCode.BackColor = Color.White;
            numericUpDown3.BackColor = Color.White;
            TipMoney.BackColor = Color.White;
            ManagerBox.BackColor = Color.White;
            numericUpDown1.BackColor = Color.White;
            numericUpDown2.BackColor = Color.White;
            numericUpDown3.BackColor = Color.LightGreen;
            numericUpDown3.Text = "";
        }

        private void ManagerBox_Enter(object sender, EventArgs e)
        {
            command.Text = "number";
            dataGridView1.Tag = "none";
            ShtrichCode.BackColor = Color.White;
            numericUpDown3.BackColor = Color.White;
            TipMoney.BackColor = Color.White;
            ManagerBox.BackColor = Color.White;
            numericUpDown1.BackColor = Color.White;
            numericUpDown2.BackColor = Color.White;
            ManagerBox.BackColor = Color.LightGreen;
            ManagerBox.Text = "";
        }


        private void ShtrichCode_Enter(object sender, EventArgs e)
        {
            command.Text = "number";
            dataGridView1.Tag = "none";
            ShtrichCode.BackColor = Color.White;
            numericUpDown3.BackColor = Color.White;
            TipMoney.BackColor = Color.White;
            ManagerBox.BackColor = Color.White;
            numericUpDown1.BackColor = Color.White;
            numericUpDown2.BackColor = Color.White;
            ShtrichCode.BackColor = Color.LightGreen;
            ShtrichCode.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                float costprice = 0;
                dataGridView1.Tag = "inorder";// հայտանիշ է թվերը դնելու համար command կոճակի մեջ օգտագործելու 
                DataGridView dataGridView = (DataGridView)sender;
                object codeValue = dataGridView.Rows[e.RowIndex].Cells["code"].Value;
                object printerValue = dataGridView.Rows[e.RowIndex].Cells["printer"].Value;
                object priceValue = dataGridView.Rows[e.RowIndex].Cells["price"].Value;
                object costpriceValue = dataGridView.Rows[e.RowIndex].Cells["costprice"].Value;
                object existValue = dataGridView.Rows[e.RowIndex].Cells["existent"].Value;
                object nameValue = dataGridView.Rows[e.RowIndex].Cells["Name"].Value;
                object grouppValue = dataGridView.Rows[e.RowIndex].Cells["Groupp"].Value;
                object freeValue = dataGridView.Rows[e.RowIndex].Cells["Free"].Value;
                object departmentvalue = dataGridView.Rows[e.RowIndex].Cells["Department"].Value;

                int printer = int.Parse(printerValue.ToString());
                int groupp = int.Parse(grouppValue.ToString());
                string exist = existValue.ToString();
                int free = int.Parse(freeValue.ToString());
                decimal department = decimal.Parse(departmentvalue.ToString());

                if (codeValue != null)//տողերի գույները փոփոխելու համար ենք օգտագործելու
                {
                    radioButton1.Tag = codeValue.ToString();
                    radioButton2.Tag = codeValue.ToString();
                    radioButton3.Tag = codeValue.ToString();
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                }

                if (codeValue != null && nest.Text.IndexOf("-") >= 0)
                {
                    string code = codeValue.ToString();
                    string name = nameValue.ToString();
                    float price = float.Parse(priceValue.ToString());
                    if (costpriceValue != DBNull.Value)
                    {
                        costprice = float.Parse(costpriceValue.ToString());
                    }
                    else
                    {
                        costprice = 0;
                    }

                    DataRow[] foundRows = CurrentOrder.Select("current = 1");  // Locate for current = true

                    // If no records are found where current = true, append a blank record
                    if (foundRows.Length == 0 && exist != "3") //Ապրանքը առկա է
                    {
                        DataRow newRow = CurrentOrder.NewRow(); // Append the new row to the CurrentOrder և լրացնում է ընտրվածով
                        CurrentOrder.Rows.Add(newRow);
                        dataGridView2.Tag = CurrentOrder.Rows.Count;
                        newRow["current"] = 1;
                        newRow["accepted"] = false;
                        newRow["id"] = CurrentOrder.Rows.Count;
                        newRow["code"] = code;
                        newRow["groupp"] = groupp;
                        newRow["name"] = name;
                        newRow["nest"] = nest.Text;
                        newRow["price"] = price;
                        newRow["costprice"] = costprice;
                        newRow["quantity"] = 0;
                        newRow["department"] = department;
                        newRow["salesamount"] = 0;
                        newRow["printer"] = printer;
                        newRow["qanak"] = "";
                        newRow["debet"] = "2211";
                        newRow["kredit"] = "2151";
                        newRow["free"] = free;// եթե 0 է, ապա սպասարկման և զեղչի տոկոսներ չեն կիրառվում

                        dataGridView3.Tag = newRow["id"].ToString();//հավելումի համար ֆիքսում ենք տողի id-ն
                        if (dataGridView2.Rows.Count > 0)
                        {
                            int lastRowIndex = dataGridView2.Rows.Count - 1;
                            for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
                            {
                                if (dataGridView2.Columns[colIndex].Visible)
                                {
                                    dataGridView2.CurrentCell = dataGridView2.Rows[lastRowIndex].Cells[colIndex];
                                    dataGridView2.BeginEdit(true);
                                    break;
                                }
                            }
                        }
                    }


                    foreach (DataRow row in CurrentOrder.Rows)//ընթացիկ տողը փոխարինում է նոր ընտրվածով
                    {
                        if (row["current"].ToString().ToLower() == "1")
                        {
                            row["code"] = code;
                            row["name"] = name;
                            row["price"] = price;
                            row["costprice"] = costprice;
                            row["quantity"] = 0;
                            row["salesamount"] = 0;
                            row["printer"] = printer;
                            row["groupp"] = groupp;
                            row["free"] = free;
                            row["qanak"] = "";
                            row["department"] = department;

                        }
                    }
                    dataGridView2.Refresh();

                }

            }
        }
        private void ShtrichCode_Leave(object sender, EventArgs e)
        {
            if (ShtrichCode.Text == string.Empty)
            {
                ShtrichCode.Text = "barcode";
            }
            else
            {
                if (ShtrichCode.Text.Length >= 14)
                {
                    string code = "215" + ShtrichCode.Text.Substring(4, 3);
                    float kol = (float.Parse(ShtrichCode.Text.Substring(9, 4))) / 1000;
                    DataRow[] foundRows = Table_215.Select($"Code = '{code}'  AND Restaurant ='{_restaurant}'");
                    if (foundRows.Length > 0)
                    {

                    }
                }
            }
        }

        private void ManagerBox_Leave(object sender, EventArgs e)
        {
            if (ManagerBox.Text == string.Empty) ManagerBox.Text = "manager";
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Paiment(1);
        }
        private void cancel2_Click(object sender, EventArgs e)
        {
            Paiment(2);
        }
        private void Paiment(int typofpaiment)
        {
            float PM = float.Parse(amount.Text);//կանխիկ
            float CL = float.Parse(amount.Text);//անկանխիկ
            if (typofpaiment == 1) CL = 0;
            if (typofpaiment == 2) PM = 0;
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            int seans_state = int.Parse(Seans.Text);
            int tick = int.Parse(bill.Text);
            DateTime dat = DateTime.Now;
            connection.Open();
            string query = $"UPDATE TicketsOrdered SET Cash = @PM,Cashless = @CL,  Tipmoney = @Tipmoney, DateEnd = @DateEnd,Person = @Person,Paid=1,Holl=@Holl " +
                $" WHERE Seans = @Seans AND Ticket = @Ticket  AND Nest = @Nest  AND Restaurant =@Rest AND  Previous='{_previous}'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PM", PM);
                command.Parameters.AddWithValue("@CL", CL);
                command.Parameters.AddWithValue("@Tipmoney", float.Parse(TipMoney.Text));
                command.Parameters.AddWithValue("@DateEnd", dat);
                command.Parameters.AddWithValue("@Person", numericUpDown3.Text);
                command.Parameters.AddWithValue("@Seans", seans_state);
                command.Parameters.AddWithValue("@Ticket", tick);
                command.Parameters.AddWithValue("@Nest", nest.Text);
                command.Parameters.AddWithValue("@Rest", _restaurant);
                command.Parameters.AddWithValue("@Holl", _holl);


                command.ExecuteNonQuery();
            }
            //////////////////////////////////////////////////////////////////////
            string UpdateQuery = $"UPDATE Tablenest SET Ocupied= 0,Printed= 0,Person= 0 ,Ticket= 0," +
                $"Taxprinted= 0,Tipmoney= 0  WHERE Nest= '{nest.Text}' AND Restaurant ='{_restaurant}' AND Previous='{_previous}'";
            using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                updatCommand.ExecuteNonQuery();


            string UpdateQuery0 = $"UPDATE Seans SET Paid= '1'  WHERE Nest= '{nest.Text}' AND Restaurant ='{_restaurant}'";
            using (SqlCommand updatCommand = new SqlCommand(UpdateQuery0, connection))
                updatCommand.ExecuteNonQuery();

            dataGridView2.Refresh();

            string selectquery = $"SELECT * FROM Tablenest WHERE Restaurant='{_restaurant}'   AND Previous='{_previous}'";//սեղանների աղյուսակը թարմացնում ենք
            TableNest = dbHelper.ExecuteQuery(selectquery);
            NestUpdate();
            connection.Close();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > 0 && e.RowIndex < dataGridView1.Rows.Count && e.ColumnIndex > 0 && e.ColumnIndex <= dataGridView1.ColumnCount) // Check for a specific column index and ignore the header row
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                var exist = row.Cells[existent].Value.ToString();
                if (exist == "2") // Change the condition as per your requirement
                {

                    // Change the row color to, for example, LightGreen
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    if (exist == "3") // Change the condition as per your requirement
                    {

                        // Change the row color to, for example, LightGreen
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        // Reset the default colors if the condition doesn't match
                        row.DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                        row.DefaultCellStyle.ForeColor = dataGridView1.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }


        private void PartnersComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            StandartOrder();
        }
        private void StandartOrder()
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            CurrentOrder.Clear();
            string l = PartnersComboBox.Text;
            if (PartnersComboBox.Text.Trim().Length == 0)
            {
                CurrentOrder.Clear();
            }
            else
            {
                int num = int.Parse(PartnersComboBox.Text);
                string query = $"SELECT * FROM Standart_215 WHERE Number='{num}' AND Restaurant ='{_restaurant}' ";
                TableStandart = dbHelper.ExecuteQuery(query);
                if (TableStandart.Rows.Count == 0)
                {
                    CurrentOrder.Clear();
                }
                else
                {
                    int id = 0;
                    float a_m = 0, w_t = 0, d_q = 0;
                    foreach (DataRow row in TableStandart.Rows)
                    {
                        DataRow[] foundRows = Table_215.Select($"code = '{row["code"]}' and Restaurant ='{_restaurant}'");//կոդը ճաշացուցակում
                        id = id + 1;
                        DataRow newRow = CurrentOrder.NewRow();
                        CurrentOrder.Rows.Add(newRow);
                        newRow["accepted"] = false;
                        newRow["current"] = 0;
                        newRow["id"] = id;
                        newRow["code"] = row["code"];
                        newRow["name"] = foundRows[0]["Name"];
                        newRow["price"] = foundRows[0]["price"];
                        newRow["quantity"] = float.Parse(row["Quantity"].ToString()) * float.Parse(numericUpDown2.Value.ToString());
                        newRow["salesamount"] = float.Parse(foundRows[0]["price"].ToString()) * float.Parse(newRow["Quantity"].ToString());
                        newRow["costamount"] = float.Parse(foundRows[0]["costprice"].ToString()) * float.Parse(newRow["Quantity"].ToString());
                        newRow["printer"] = foundRows[0]["printer"];
                        newRow["qanak"] = newRow["Quantity"].ToString();

                        newRow["service"] = float.Parse(newRow["salesamount"].ToString()) * float.Parse(service.Tag.ToString()) * 0.01;
                        newRow["discount"] = float.Parse(newRow["salesamount"].ToString()) * float.Parse(discount.Tag.ToString()) * 0.01;

                        a_m += float.Parse(newRow["Quantity"].ToString()) * float.Parse(foundRows[0]["price"].ToString());//սեղանի գումարը 
                        if (service.Tag != null && newRow["service"].ToString().Length > 0)
                        {
                            w_t += float.Parse(newRow["service"].ToString());
                        }
                        if (discount.Tag != null && newRow["discount"].ToString().Length > 0)
                        {
                            d_q += float.Parse(newRow["discount"].ToString());
                        }

                    }
                    amount.Text = a_m.ToString();
                    float gidd = 0;
                    if (numericUpDown1.Value > 0)
                    {
                        float un = a_m / (float)numericUpDown2.Value;
                        gidd = un * (float)numericUpDown1.Value;
                        gid.Text = gidd.ToString();
                        gid.Visible = true;
                    }
                    service.Text = w_t.ToString();
                    discount.Text = d_q.ToString();
                    total.Text = (float.Parse(amount.Text) + float.Parse(service.Text) - float.Parse(discount.Text) - gidd).ToString();
                    accept.Visible = true;
                }

            }
        }

        private void numericUpDown2_Enter(object sender, EventArgs e)
        {
            ShtrichCode.BackColor = Color.White;
            numericUpDown3.BackColor = Color.White;
            TipMoney.BackColor = Color.White;
            ManagerBox.BackColor = Color.White;
            numericUpDown2.BackColor = Color.LightGreen;
            number_enter.BackColor = Color.LightGreen;
        }

        private void tab2_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab2.Text;
            int left = tab2.Left;
            int top = e.Y + tab2.Top + tab2.Height;
            legenda(nest, left, top);
        }

        private void legenda(string nest, int left, int top)
        {
            legend.Left = left;
            legend.Top = top;
            DataRow[] foundRows = TableNest.Select($"Nest = '{nest}' ");
            if (foundRows.Length > 0)
            {
                legend.Text = "+ " + foundRows[0]["service"].ToString() + " - " + foundRows[0]["discount"].ToString();
                legend.Visible = true;
            }
        }

        private void tab9_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab9.Text;
            int left = tab9.Left;
            int top = e.Y + tab9.Top + tab9.Height;
            legenda(nest, left, top);
        }

        private void tab1_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab1.Text;
            int left = tab1.Left;
            int top = e.Y + tab1.Top + tab1.Height;
            legenda(nest, left, top);
        }

        private void tab8_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab8.Text;
            int left = tab8.Left;
            int top = e.Y + tab8.Top + tab8.Height;
            legenda(nest, left, top);
        }

        private void tab3_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab3.Text;
            int left = tab3.Left;
            int top = e.Y + tab3.Top + tab3.Height;
            legenda(nest, left, top);
        }

        private void tab4_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab4.Text;
            int left = tab4.Left;
            int top = e.Y + tab4.Top + tab4.Height;
            legenda(nest, left, top);
        }

        private void tab5_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab5.Text;
            int left = tab5.Left;
            int top = e.Y + tab5.Top + tab5.Height;
            legenda(nest, left, top);
        }

        private void tab6_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab6.Text;
            int left = tab6.Left;
            int top = e.Y + tab6.Top + tab6.Height;
            legenda(nest, left, top);
        }

        private void tab7_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab7.Text;
            int left = tab7.Left;
            int top = e.Y + tab7.Top + tab7.Height;
            legenda(nest, left, top);
        }

        private void tab10_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab10.Text;
            int left = tab10.Left;
            int top = e.Y + tab10.Top + tab10.Height;
            legenda(nest, left, top);
        }

        private void tab11_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab11.Text;
            int left = tab11.Left;
            int top = e.Y + tab11.Top + tab11.Height;
            legenda(nest, left, top);
        }

        private void tab12_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab12.Text;
            int left = tab12.Left;
            int top = e.Y + tab12.Top + tab12.Height;
            legenda(nest, left, top);
        }

        private void tab13_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab13.Text;
            int left = tab13.Left;
            int top = e.Y + tab13.Top + tab13.Height;
            legenda(nest, left, top);
        }

        private void tab14_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab14.Text;
            int left = tab14.Left;
            int top = e.Y + tab14.Top + tab14.Height;
            legenda(nest, left, top);
        }

        private void tab15_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab15.Text;
            int left = tab15.Left;
            int top = e.Y + tab15.Top + tab15.Height;
            legenda(nest, left, top);
        }

        private void tab16_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab16.Text;
            int left = tab16.Left;
            int top = e.Y + tab16.Top + tab16.Height;
            legenda(nest, left, top);
        }

        private void tab17_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab17.Text;
            int left = tab17.Left;
            int top = e.Y + tab17.Top + tab17.Height;
            legenda(nest, left, top);
        }

        private void tab18_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab18.Text;
            int left = tab18.Left;
            int top = e.Y + tab18.Top + tab18.Height;
            legenda(nest, left, top);
        }

        private void tab19_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab19.Text;
            int left = tab19.Left;
            int top = e.Y + tab19.Top + tab19.Height;
            legenda(nest, left, top);
        }

        private void tab20_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab20.Text;
            int left = tab20.Left;
            int top = e.Y + tab20.Top + tab20.Height;
            legenda(nest, left, top);
        }

        private void tab21_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab21.Text;
            int left = tab21.Left;
            int top = e.Y + tab21.Top + tab21.Height;
            legenda(nest, left, top);
        }

        private void tab22_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab22.Text;
            int left = tab22.Left;
            int top = e.Y + tab22.Top + tab22.Height;
            legenda(nest, left, top);
        }

        private void tab23_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab23.Text;
            int left = tab23.Left;
            int top = e.Y + tab23.Top + tab23.Height;
            legenda(nest, left, top);
        }

        private void tab24_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab24.Text;
            int left = tab24.Left;
            int top = e.Y + tab24.Top + tab24.Height;
            legenda(nest, left, top);
        }

        private void tab25_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab25.Text;
            int left = tab25.Left;
            int top = e.Y + tab25.Top + tab25.Height;
            legenda(nest, left, top);
        }

        private void tab26_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab26.Text;
            int left = tab26.Left;
            int top = e.Y + tab26.Top + tab26.Height;
            legenda(nest, left, top);
        }

        private void tab27_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab27.Text;
            int left = tab27.Left;
            int top = e.Y + tab27.Top + tab27.Height;
            legenda(nest, left, top);
        }

        private void tab28_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab28.Text;
            int left = tab28.Left;
            int top = e.Y + tab28.Top + tab28.Height;
            legenda(nest, left, top);
        }

        private void tab29_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab29.Text;
            int left = tab29.Left;
            int top = e.Y + tab29.Top + tab29.Height;
            legenda(nest, left, top);
        }

        private void tab30_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab30.Text;
            int left = tab30.Left;
            int top = e.Y + tab30.Top + tab30.Height;
            legenda(nest, left, top);
        }

        private void tab31_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab31.Text;
            int left = tab31.Left;
            int top = e.Y + tab31.Top + tab31.Height;
            legenda(nest, left, top);
        }

        private void tab32_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab32.Text;
            int left = tab32.Left;
            int top = e.Y + tab32.Top + tab32.Height;
            legenda(nest, left, top);
        }

        private void tab33_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab33.Text;
            int left = tab33.Left;
            int top = e.Y + tab33.Top + tab33.Height;
            legenda(nest, left, top);
        }

        private void tab34_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab34.Text;
            int left = tab34.Left;
            int top = e.Y + tab34.Top + tab34.Height;
            legenda(nest, left, top);
        }

        private void tab35_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab35.Text;
            int left = tab35.Left;
            int top = e.Y + tab35.Top + tab35.Height;
            legenda(nest, left, top);
        }

        private void tab36_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab36.Text;
            int left = tab36.Left;
            int top = e.Y + tab36.Top + tab36.Height;
            legenda(nest, left, top);
        }

        private void tab37_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab37.Text;
            int left = tab37.Left;
            int top = e.Y + tab37.Top + tab37.Height;
            legenda(nest, left, top);
        }

        private void tab38_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab38.Text;
            int left = tab38.Left;
            int top = e.Y + tab38.Top + tab38.Height;
            legenda(nest, left, top);
        }

        private void tab39_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab39.Text;
            int left = tab39.Left;
            int top = e.Y + tab39.Top + tab39.Height;
            legenda(nest, left, top);
        }

        private void tab40_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab40.Text;
            int left = tab40.Left;
            int top = e.Y + tab40.Top + tab40.Height;
            legenda(nest, left, top);
        }

        private void tab41_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab41.Text;
            int left = tab41.Left;
            int top = e.Y + tab41.Top + tab41.Height;
            legenda(nest, left, top);
        }

        private void tab42_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab42.Text;
            int left = tab42.Left;
            int top = e.Y + tab42.Top + tab42.Height;
            legenda(nest, left, top);
        }

        private void tab43_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab43.Text;
            int left = tab43.Left;
            int top = e.Y + tab43.Top + tab43.Height;
            legenda(nest, left, top);
        }

        private void tab44_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab44.Text;
            int left = tab44.Left;
            int top = e.Y + tab44.Top + tab44.Height;
            legenda(nest, left, top);
        }



        private void tab46_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab46.Text;
            int left = tab46.Left;
            int top = e.Y + tab46.Top + tab46.Height;
            legenda(nest, left, top);
        }

        private void tab47_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab47.Text;
            int left = tab47.Left;
            int top = e.Y + tab47.Top + tab47.Height;
            legenda(nest, left, top);
        }

        private void tab48_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab48.Text;
            int left = tab48.Left;
            int top = e.Y + tab48.Top + tab48.Height;
            legenda(nest, left, top);
        }

        private void tab49_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab49.Text;
            int left = tab49.Left;
            int top = e.Y + tab49.Top + tab49.Height;
            legenda(nest, left, top);
        }

        private void tab50_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab50.Text;
            int left = tab50.Left;
            int top = e.Y + tab50.Top + tab50.Height;
            legenda(nest, left, top);
        }

        private void tab51_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab51.Text;
            int left = tab51.Left;
            int top = e.Y + tab51.Top + tab51.Height;
            legenda(nest, left, top);
        }

        private void tab52_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab52.Text;
            int left = tab52.Left;
            int top = e.Y + tab52.Top + tab52.Height;
            legenda(nest, left, top);
        }

        private void tab53_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab53.Text;
            int left = tab53.Left;
            int top = e.Y + tab53.Top + tab53.Height;
            legenda(nest, left, top);
        }

        private void tab54_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab54.Text;
            int left = tab54.Left;
            int top = e.Y + tab54.Top + tab54.Height;
            legenda(nest, left, top);
        }

        private void tab55_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab55.Text;
            int left = tab55.Left;
            int top = e.Y + tab55.Top + tab55.Height;
            legenda(nest, left, top);
        }

        private void tab56_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab56.Text;
            int left = tab56.Left;
            int top = e.Y + tab56.Top + tab56.Height;
            legenda(nest, left, top);
        }

        private void tab57_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab57.Text;
            int left = tab57.Left;
            int top = e.Y + tab57.Top + tab57.Height;
            legenda(nest, left, top);
        }

        private void tab58_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab58.Text;
            int left = tab58.Left;
            int top = e.Y + tab58.Top + tab58.Height;
            legenda(nest, left, top);
        }

        private void tab59_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab59.Text;
            int left = tab59.Left;
            int top = e.Y + tab59.Top + tab59.Height;
            legenda(nest, left, top);
        }

        private void tab60_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab60.Text;
            int left = tab60.Left;
            int top = e.Y + tab60.Top + tab60.Height;
            legenda(nest, left, top);
        }

        private void tab61_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab61.Text;
            int left = tab61.Left;
            int top = e.Y + tab61.Top + tab61.Height;
            legenda(nest, left, top);
        }

        private void tab62_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab62.Text;
            int left = tab62.Left;
            int top = e.Y + tab62.Top + tab62.Height;
            legenda(nest, left, top);
        }

        private void tab63_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab63.Text;
            int left = tab63.Left;
            int top = e.Y + tab63.Top + tab63.Height;
            legenda(nest, left, top);
        }

        private void tab64_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab64.Text;
            int left = tab64.Left;
            int top = e.Y + tab64.Top + tab64.Height;
            legenda(nest, left, top);
        }

        private void tab65_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab65.Text;
            int left = tab65.Left;
            int top = e.Y + tab65.Top + tab65.Height;
            legenda(nest, left, top);
        }

        private void tab66_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab66.Text;
            int left = tab66.Left;
            int top = e.Y + tab66.Top + tab66.Height;
            legenda(nest, left, top);
        }

        private void tab67_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab67.Text;
            int left = tab67.Left;
            int top = e.Y + tab67.Top + tab67.Height;
            legenda(nest, left, top);
        }

        private void tab68_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab68.Text;
            int left = tab68.Left;
            int top = e.Y + tab68.Top + tab68.Height;
            legenda(nest, left, top);
        }

        private void tab45_MouseMove(object sender, MouseEventArgs e)
        {
            string nest = tab45.Text;
            int left = tab45.Left;
            int top = e.Y + tab45.Top + tab45.Height;
            legenda(nest, left, top);
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            number_enter.BackColor = Color.LightGreen;
            numericUpDown1.BackColor = Color.LightGreen;
        }

        private void numericUpDown3_Leave(object sender, EventArgs e)
        {
            if (numericUpDown3.Text == string.Empty) numericUpDown3.Text = "0";
        }

        private void TipMoney_Leave(object sender, EventArgs e)
        {
            if (TipMoney.Text == string.Empty) numericUpDown3.Text = "";
        }

        private void TipMoney_Enter(object sender, EventArgs e)
        {
            command.Text = "number";
            dataGridView1.Tag = "none";
            ShtrichCode.BackColor = Color.White;
            numericUpDown3.BackColor = Color.White;
            TipMoney.BackColor = Color.White;
            ManagerBox.BackColor = Color.White;
            numericUpDown1.BackColor = Color.White;
            numericUpDown2.BackColor = Color.White;
            TipMoney.BackColor = Color.LightGreen;
            TipMoney.Text = "";
        }

        private void numericUpDown3_Enter_1(object sender, EventArgs e)
        {
            command.Text = "number";
            dataGridView1.Tag = "none";
            ShtrichCode.BackColor = Color.White;
            numericUpDown3.BackColor = Color.White;
            TipMoney.BackColor = Color.White;
            ManagerBox.BackColor = Color.White;
            numericUpDown1.BackColor = Color.White;
            numericUpDown2.BackColor = Color.White;
            numericUpDown3.BackColor = Color.LightGreen;
            numericUpDown3.Text = "";
        }

        private void tab69_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            string Nest = nest.Text;
            string forbidden = "0";
            int forb = 0;
            DataRow[] foundRows0 = TableNest.Select($"Nest = '{nest.Text}' ");
            if (foundRows0 != null)
            {
                forbidden = foundRows0[0]["forbidden"].ToString();
            }
            if (forbidden == "0") forb = 1;
            string UpdateQuery = $"UPDATE TableNest SET  Forbidden= '{forb}' WHERE Nest= '{Nest}' and Previous='{_previous}' ";
            using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
               updatCommand.ExecuteNonQuery();
            connection.Close();
            NestUpdate();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";
                richTextBox1.ReadOnly = true;

                string filePath = "D:\\hayrik\\sql\\help\\Order.txt";
                string fileContent = File.ReadAllText(filePath);
                richTextBox1.Text = fileContent;
                richTextBox1.Visible = true;
                richTextBox1.Top = 0;
                richTextBox1.Left = 0;
                richTextBox1.Width = HelpButton.Left - 10;
                richTextBox1.Height = this.Height - 20;

            }
            else
            {
                richTextBox1.Visible = false;
                HelpButton.Text = "?";
            }
        }
//        private void translate(DataTable Table1, DataTable Table2)
//        {
//            if (Table1.Columns.Contains("code"))
//            {
//                var query = from row1 in Table1.AsEnumerable()
//                            join row2 in Table2.AsEnumerable()
//                            on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
//                            from subRow2 in gj.DefaultIfEmpty()
//                            select new
//                            {
//                                Row1 = row1,
//                                Row2 = subRow2
//                            };

//                foreach (var item in query)
//                {
//                    if (item.Row2 != null)
//                    {
//                        if (_language == "Armenian") item.Row2["Name"] = item.Row1["Armenian"];
//                        if (_language == "English") item.Row2["Name"] = item.Row1["English"];
//                        if (_language == "German") item.Row2["Name"] = item.Row1["German"];
//                        if (_language == "Russian") item.Row2["Name"] = item.Row1["Russian"];
//                        if (_language == "Espaniol") item.Row2["Name"] = item.Row1["Espaniol"];
//                    }
//                }
//            }
//            else
//            {

//                foreach(DataRow row in  Table1.Rows)
//                {
//                    if (_language == "Armenian") row["Name"] = row["Armenian"];
//                    if (_language == "English") row["Name"] = row["English"];
//                    if (_language == "German") row["Name"] = row["German"];
//                    if (_language == "Russian") row["Name"] = row["Russian"];
//                    if (_language == "Espaniol") row["Name"] = row["Espaniol"];
//                }

//            }
//        }

        private void dataGridView1_MouseEnter(object sender, EventArgs e)
        {
            legend.Visible=false;
        }
    }
}