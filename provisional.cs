using Amazon.DynamoDBv2;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI.Relational;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;


namespace WindowsFormsApp4
{
    public partial class provisional : Form
    {

        private int _ooperator;
        private int _holl;
        private int _restaurant;

        private int Table_215_columnIndex;
        private MySQLDatabaseHelper dbHelper;
        //  private BindingSource bindingSource = new BindingSource(); // Create a BindingSource
        private BindingSource bindingSource = new BindingSource();

        private DataTable TableSeans = new DataTable();   //Ընթացիկ սեանսն է։ Ամեն դրամարկղ իր սեփական սեանսն ունի, տարբեր մյուս դրամարկղերից։

        private DataTable Table_215 = new DataTable();   //Ճաշացուցակն է։ 

        private DataTable Table_215_groups = new DataTable();// ճաշերի խմբերն են 


        private DataTable AdditionGroups = new DataTable();   //հավելումների խմբերի աղյուսակն է։ 

        private DataTable AdditionNames = new DataTable();   //հավելումների խմբերի բովանդակությունն է։

        private DataTable NestProvisional = new DataTable();   // Սեղանների ֆայլն է։ սպասարկման և զեղչի տոկոսների համար։ և ընթացիկ
                                                         // <ocupied>,<forbidden>,<ticket>,<printed>,<taxprinted>,<person>,<tipmoney> դաշտերով։

        private DataTable Department = new DataTable();   // բաժինների ֆայլն է։։ 

        private DataTable Ticket_Provisional = new DataTable(); // հաշիվների մասին տեղեկություններ են ։ 

        private DataTable SeansState = new DataTable();//Ընթացիկ սեանսի համարն է։։ 

        private DataTable Current_provisional = new DataTable();    // ընթացիկ պատվերի աղյուսակն է։ Ստեղծվում է ծրագիր մտնելիս

        private DataTable Table_Restaurants = new DataTable();    // Ռեստորանների ցանկն է


        private DataView dataView;

        public provisional(int ooperator, int holl, int restaurant)
        {

            InitializeComponent();
            InitForm();
            //  textBox1.Text = ooperator;
            _ooperator = ooperator;
            _holl = holl;
            _restaurant = restaurant;

            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");





            string query6 = $"SELECT * FROM `NestProvisional` WHERE `Holl`='{_holl}' AND `Restaurant`='{_restaurant}' ";
            NestProvisional = dbHelper.ExecuteQuery(query6);

            string query5 = $"SELECT * FROM `department` WHERE `Restaurant`='{_restaurant}' ";
            Department = dbHelper.ExecuteQuery(query5);



            string query1 = $"SELECT * FROM `table_215` WHERE  `Price`>0 AND `Restaurant`='{_restaurant}' ";
            Table_215 = dbHelper.ExecuteQuery(query1);



            string query2 = $"SELECT * FROM `AdditionGroups` WHERE  `Restaurant`='{_restaurant}' ";
            AdditionGroups = dbHelper.ExecuteQuery(query2);


            string query3 = $"SELECT * FROM `AdditionNames` WHERE  `Restaurant`='{_restaurant}' ";
            AdditionNames = dbHelper.ExecuteQuery(query3);


            string query4 = $"SELECT * FROM `table_215_groups` WHERE  `Restaurant`='{_restaurant}' ";
            Table_215_groups = dbHelper.ExecuteQuery(query4);


            string query7 = $"SELECT * FROM `ticket_provisional` WHERE  `Restaurant`='{_restaurant}' ";
            Ticket_Provisional = dbHelper.ExecuteQuery(query7);

            string query8 = $"SELECT * FROM `restaurants`";
            Table_Restaurants = dbHelper.ExecuteQuery(query8);
            DataRow[] foundRows1 = Table_Restaurants.Select($"Id = '{_restaurant}' ");
            this.Text = foundRows1[0]["Name_1"].ToString();
            int SeansState = 0;
            string query = "";
            query = $"SELECT * FROM `provisional` WHERE `Holl`='{_holl}' AND `Restaurant`='{_restaurant}' ";
            TableSeans = dbHelper.ExecuteQuery(query);

            query = $"SELECT * FROM `SeansState` WHERE `Restaurant`='{_restaurant}' ";
            SeansState = dbHelper.ExecuteQuery(query);
            if (SeansState.Rows.Count == 0)
            {
                query = $"INSERT SeansState SET `seans` = '{1}',`Restaurant`='{_restaurant}' ";
                SeansState = dbHelper.ExecuteQuery(query);
                SeansState = 1;
            }
            else
            {
                DataRow[] foundRows = SeansState.Select("seans >0 AND Restaurant ='" + _restaurant.ToString() + "'");
                SeansState = int.Parse(foundRows[0]["seans"].ToString());
            }
            Seans.Text = SeansState.ToString();


            dataGridView1.DataSource = Table_215;
            dataGridView1.Columns[0].DataPropertyName = "Name_1";
            dataGridView1.Columns[1].DataPropertyName = "Price";


            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.DataPropertyName != "Name_1" && column.DataPropertyName != "Price" && column.DataPropertyName != "Existent")
                {
                    column.Visible = false;
                }
            }

            Table_215_columnIndex = Table_215.Columns.IndexOf("Existent");//ճաշացուցակի գույների համար է
            //dataGridView1.Refresh();


            dataGridView3.DataSource = AdditionNames;
            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.Columns[0].DataPropertyName = "Name_1";

            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                string name = column.DataPropertyName;
                if (column.Index > 0)
                {
                    column.Visible = false;
                }

            }

            //// Կազմավորվում է պատվերի աղյուսակը



            Current_provisional.Columns.Add("name", typeof(string));
            Current_provisional.Columns.Add("price", typeof(float));
            Current_provisional.Columns.Add("qanak", typeof(string));
            Current_provisional.Columns.Add("salesamount", typeof(float));

            Current_provisional.Columns.Add("service", typeof(float));
            Current_provisional.Columns.Add("discount", typeof(float));
            Current_provisional.Columns.Add("printer", typeof(int));

            Current_provisional.Columns.Add("code", typeof(string));
            Current_provisional.Columns.Add("quantity", typeof(float));
            Current_provisional.Columns.Add("date1", typeof(DateTime));
            Current_provisional.Columns.Add("date2", typeof(DateTime));
            Current_provisional.Columns.Add("seans", typeof(int));
            Current_provisional.Columns.Add("ticket", typeof(int));
            Current_provisional.Columns.Add("nest", typeof(string));
            Current_provisional.Columns.Add("printed", typeof(bool));
            Current_provisional.Columns.Add("paid", typeof(bool));
            Current_provisional.Columns.Add("taxpaid", typeof(bool));
            Current_provisional.Columns.Add("accepted", typeof(bool));
            Current_provisional.Columns.Add("current", typeof(bool));
            Current_provisional.Columns.Add("debet", typeof(string));
            Current_provisional.Columns.Add("kredit", typeof(string));
            Current_provisional.Columns.Add("id", typeof(int));


            dataGridView2.DataSource = Current_provisional;
            dataGridView2.Columns[0].DataPropertyName = "name";
            dataGridView2.Columns[1].DataPropertyName = "Price";
            dataGridView2.Columns[2].DataPropertyName = "qanak";
            dataGridView2.Columns[3].DataPropertyName = "salesamount";
            //bindingSource.DataSource = Current_provisional;


        }
        public void InitForm()
        {

            float screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            float screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            //   Screen primaryScreen = Screen.PrimaryScreen;
            //   int screenWidth = primaryScreen.Bounds.Width;
            //   int screenHeigh = primaryScreen.Bounds.Height;
            float kw = screenWidth / this.Width;
            float kh = screenHeight / this.Height;
            foreach (Control control in this.Controls)
            {
                // Փոփոխվում են օբյեկների չափն ու տեղադրությունը ** Objects are resized and positioned
                control.Left = (int)(control.Left * (double)kw);
                control.Top = (int)(control.Top * (double)kh);
                control.Width = (int)(control.Width * (double)kw);
                control.Height = (int)(control.Height * (double)kh);
            }
            dataGridView1.Columns[0].Width = (int)(dataGridView1.Columns[0].Width * 1.15);
            dataGridView1.Columns[1].Width = (int)(dataGridView1.Columns[1].Width * 1.15);
            dataGridView2.Columns[0].Width = (int)(dataGridView2.Columns[0].Width * 1.15);
            dataGridView2.Columns[1].Width = (int)(dataGridView2.Columns[1].Width * 1.15);
            dataGridView2.Columns[2].Width = (int)(dataGridView2.Columns[2].Width * 1.15);
            dataGridView2.Columns[3].Width = (int)(dataGridView2.Columns[3].Width * 1.15);

            this.Width = (int)screenWidth;
            this.Height = (int)screenHeight;
            this.Top = 0;
            this.Left = 0;
            /////////////////////////////////////////////// 
            //NestUpdate();

        }
        public provisional(int restaurant)
        {
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
        private void provisional_Load(object sender, EventArgs e)
        {

            dataGridView3.Width = dataGridView1.Left - 5;
            dataGridView3.Columns[0].Width = 0;
            dataGridView3.Columns[1].Width = dataGridView3.Width;
            Button[] tabArray = new Button[61] { tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13, tab14, tab15, tab16, tab17, tab18, tab19, tab20, tab21, tab22, tab23, tab24, tab25, tab26, tab27, tab28, tab29, tab30, tab31, tab32, tab33, tab34, tab35, tab36, tab37, tab38, tab39, tab40, tab41, tab42, tab43, tab44, tab45, tab46, tab47, tab48, tab49, tab50, tab51, tab52, tab53, tab54, tab55, tab56, tab57, tab58, tab59, tab60, tab61 }
            ;
            for (int i = 0; i < 61; i++)
            {
                tabArray[i].Text = _holl.ToString().Trim() + '-' + (i + 1).ToString(); //_holl-ը դրամարկղի համարն է։ Սեղանների տեքտերը դրանից կաղված փոխվում են
                DataRow[] foundRows = NestProvisional.Select("nest = '" + tabArray[i].Text + "'");
                bool T = foundRows.Length == 0;
                if (T == true) tabArray[i].Enabled = false;
            }
            Button[] additionArray = new Button[20] { addition1, addition2, addition3, addition4, addition5, addition6, addition7, addition8, addition9, addition10, addition11, addition12, addition13, addition14, addition15, addition16, addition17, addition18, addition19, addition20 };
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
                    additionArray[j].Text = row["Name_1"].ToString();
                    additionArray[j].Visible = true;
                }
                j += 1;
            }
            Button[] departmentArray = new Button[5] { department1, department2, department3, department4, department5 };
            j = -1;

            foreach (DataRow row in Department.Rows)//բաժինների կոճակների անուններն ենք տեղադրում
            {
                if (row.Field<bool>("alloved") == false)
                {
                    continue;
                }
                j++;
                if (DoesButtonExist(departmentArray[j].Name))
                {
                    departmentArray[j].Text = row["Name_1"].ToString();
                    departmentArray[j].Visible = true;
                }

            }

            this.command.Left = this.Width + 5;
            this.DepartmentClick.Left = this.Width + 5;
            this.GroupClick.Left = this.Width + 5;
            this.AdditionClick.Left = this.Width + 5;

            NestUpdate();
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

                dataGridView1.Tag = "inprovisional";// հայտանիշ է թվերը դնելու համար command կոճակի մեջ օգտագործելու 
                DataGridView dataGridView = (DataGridView)sender;
                object codeValue = dataGridView.Rows[e.RowIndex].Cells["code"].Value;
                object nameValue = dataGridView.Rows[e.RowIndex].Cells["name"].Value;
                object printerValue = dataGridView.Rows[e.RowIndex].Cells["printer"].Value;
                object priceValue = dataGridView.Rows[e.RowIndex].Cells["price"].Value;
                object quantValue = dataGridView.Rows[e.RowIndex].Cells["quantity"].Value;
                object accValue = dataGridView.Rows[e.RowIndex].Cells["accepted"].Value;
                object idValue = dataGridView.Rows[e.RowIndex].Cells["id"].Value;
                int qan = Convert.ToInt32(quantValue);
                bool acc = bool.Parse(accValue.ToString());
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


                    DataRow[] foundRows1 = Current_provisional.Select($"code = '{code}' and accepted='false'");
                    if (foundRows1.Length > 0)
                    {
                        foreach (DataRow row in foundRows1)
                        {
                            row["current"] = true;
                            row["quantity"] = 0;
                            row["salesamount"] = 0;
                            row["qanak"] = "-";
                        }
                    }
                    else
                    {
                        DataRow[] foundRows = Current_provisional.Select("current = true");

                        // If no records are found where current = true, append a blank record
                        if (foundRows.Length == 0)
                        {
                            DataRow newRow = Current_provisional.NewRow();
                            Current_provisional.Rows.Add(newRow);
                            newRow["current"] = true;
                            newRow["accepted"] = false;
                            newRow["id"] = Current_provisional.Rows.Count;
                            dataGridView2.Tag = Current_provisional.Rows.Count;
                            newRow["code"] = code;
                            newRow["name"] = name;
                            newRow["price"] = price;
                            newRow["quantity"] = 0;
                            newRow["salesamount"] = 0;
                            newRow["printer"] = printer;
                            newRow["qanak"] = "-";
                            //  newRow["debet"] = "2211";
                            //  newRow["kredit"] = "2151";
                        }
                        else
                        {
                            foreach (DataRow row in foundRows)
                            {
                                // Update the fields if a matching record is found
                                row["code"] = code;
                                row["name"] = name;
                                row["price"] = price;
                                row["quantity"] = 0;
                                row["salesamount"] = 0;
                                row["printer"] = printer;
                            }
                        }
                    }
                    dataGridView2.Refresh();

                }

            }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e) // պատվերի տողին հավելում ենք ավելացնում
        {
            object nameValue = dataGridView3.Rows[e.RowIndex].Cells["Name_1"].Value;
            string Name_1 = nameValue.ToString();
            int id = int.Parse(dataGridView3.Tag.ToString());
            DataRow[] foundRows = Current_provisional.Select($"id = '{id}'");
            if (foundRows.Length > -1)
            {
                foreach (DataRow row in foundRows)
                {
                    row["Name"] = row["Name"] + " | " + Name_1;
                }
            }
            dataGridView3.Visible = false;
        }
        private void NestUpdate()
        {


            string query = $"SELECT * FROM `provisional` WHERE `Holl`='{_holl}' AND `Restaurant`='{_restaurant}' "; //սեանսի աղյուսակը թարմացնում ենք
            TableSeans = dbHelper.ExecuteQuery(query);


            query = $"SELECT * FROM `NestProvisional` WHERE `Restaurant`='{_restaurant}' ";//սեղանների աղյուսակը թարմացնում ենք
            NestProvisional = dbHelper.ExecuteQuery(query);

            query = $"SELECT * FROM `ticket_provisional` WHERE `Restaurant`='{_restaurant}' ";//հաշիվների աղյուսակը թարմացնում ենք
            Ticket_Provisional = dbHelper.ExecuteQuery(query);
            int tick = 1;

            foreach (DataRow row in Ticket_Provisional.Rows)
            {
                if (row["Nest"].ToString() == nest.Text && int.Parse(row["PaidMoney"].ToString()) == 0)
                {
                    tick = int.Parse(row["Ticket"].ToString());
                    ManagerBox.Text = row["Note"].ToString();
                    break;
                }
                if (int.Parse(row["Ticket"].ToString()) >= tick) tick = int.Parse(row["Ticket"].ToString()) + 1;
            }
            bill.Text = tick.ToString();

            Button[] tabArray = new Button[62] { tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13, tab14, tab15, tab16, tab17, tab18, tab19, tab20, tab21, tab22, tab23, tab24, tab25, tab26, tab27, tab28, tab29, tab30, tab31, tab32, tab33, tab34, tab35, tab36, tab37, tab38, tab39, tab40, tab41, tab42, tab43, tab44, tab45, tab46, tab47, tab48, tab49, tab50, tab51, tab52, tab53, tab54, tab55, tab56, tab57, tab58, tab59, tab60, tab61, tab62 };
            //  amount.Text = "";
            //  service.Text = "";
            //  discount.Text = "";
            //  total.Text = "";
            //  TipMoney.Text = "";
            Current_provisional.Clear();
            forbidden.ForeColor = Color.Black;
            dataGridView1.Enabled = true;
            string table_clicked = command.Text;
            for (int i = 0; i < 61; i++)// զբաղվածի գույնը կարմիր է դարձնում, տպածի գույնը նարինջի
            {

                tabArray[i].ForeColor = Color.Black;
                tabArray[i].BackColor = System.Drawing.SystemColors.ButtonFace;
                DataRow[] foundRows = NestProvisional.Select("Nest = '" + tabArray[i].Text + "'");
                if (foundRows.Length > 0)
                {

                    string ServiseValue = foundRows[0]["Service"].ToString();
                    string DiscountValue = foundRows[0]["Discount"].ToString();
                    string OcupiedValue = foundRows[0]["Ocupied"].ToString();
                    string ForbiddenValue = foundRows[0]["Forbidden"].ToString();
                    string PrindedValue = foundRows[0]["Printed"].ToString();
                    tabArray[i].Tag = "+" + ServiseValue + " -" + DiscountValue;
                    if (OcupiedValue == "True") tabArray[i].ForeColor = Color.Red;// զբաղվածի գույնը կարմիր է դարձնում
                    if (PrindedValue == "True")
                    {
                        tabArray[i].ForeColor = Color.Orange;// տպածի գույնը դեղին է դարձնում
                        dataGridView1.Enabled = true;
                    }
                    if (ForbiddenValue == "True")
                    {
                        tabArray[i].ForeColor = Color.BlueViolet;// արգելվածի գույնը կապույտ է դարձնում
                    }
                    if (foundRows[0]["Nest"].ToString() == nest.Text)
                    {
                        PersonBox.Text = foundRows[0]["person"].ToString();
                        //              bill.Text = foundRows[0]["ticket"].ToString();
                        TipMoney.Text = foundRows[0]["tipmoney"].ToString();
                        tabArray[i].BackColor = Color.Green;
                        if (PrindedValue == "True" || ForbiddenValue == "True")
                        {
                            dataGridView1.Enabled = false; //տպածի և արգելվածի  վրա փոփոխությունն արգելված է
                        }

                    }
                }
            }
            foreach (DataRow row in TableSeans.Rows)
            {
                if (row["nest"].ToString() != nest.Text || bool.Parse(row["paid"].ToString()) == true) continue;
                string seansCode = row["code"].ToString();
                DataRow[] foundRows = Current_provisional.Select("code = '" + seansCode + "'");
                if (foundRows.Length == 0)
                {
                    DataRow newRow = Current_provisional.NewRow();
                    newRow["code"] = row["code"];
                    newRow["nest"] = row["nest"];
                    newRow["seans"] = row["seans"];
                    newRow["ticket"] = row["ticket"];
                    newRow["name"] = row["name"];
                    //   newRow["date1"] = row["date1"];
                    //   newRow["date2"] = row["date2"];
                    newRow["price"] = row["price"];
                    newRow["quantity"] = row["quantity"];
                    newRow["qanak"] = row["qanak"];
                    newRow["salesamount"] = row["salesamount"];
                    newRow["service"] = row["service"];
                    newRow["discount"] = row["discount"];
                    newRow["printer"] = row["printer"];
                    //   newRow["printed"] = row["printed"];
                    newRow["taxpaid"] = row["taxpaid"];
                    newRow["id"] = 0;
                    newRow["current"] = false;
                    newRow["accepted"] = true;
                    //  bill.Text = row["ticket"].ToString();
                    Current_provisional.Rows.Add(newRow);
                }
                else
                {
                    foreach (DataRow foundRow in foundRows)
                    {
                        // Update quantity and amount in current_dir based on seans table values
                        foundRow["quantity"] = float.Parse(foundRow["quantity"].ToString()) + float.Parse(row["quantity"].ToString());
                        foundRow["salesamount"] = float.Parse(foundRow["salesamount"].ToString()) + float.Parse(row["salesamount"].ToString());
                        foundRow["service"] = float.Parse(foundRow["service"].ToString()) + float.Parse(row["service"].ToString());
                        foundRow["discount"] = float.Parse(foundRow["discount"].ToString()) + float.Parse(row["discount"].ToString());
                        foundRow["qanak"] = foundRow["quantity"].ToString();
                    }
                }
            }
        }

        private void command_Click(object sender, EventArgs e)
        {

            Button[] tabArray = new Button[62] { tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13, tab14, tab15, tab16, tab17, tab18, tab19, tab20, tab21, tab22, tab23, tab24, tab25, tab26, tab27, tab28, tab29, tab30, tab31, tab32, tab33, tab34, tab35, tab36, tab37, tab38, tab39, tab40, tab41, tab42, tab43, tab44, tab45, tab46, tab47, tab48, tab49, tab50, tab51, tab52, tab53, tab54, tab55, tab56, tab57, tab58, tab59, tab60, tab61, tab62 };
            if ((command.Text + "          ").IndexOf("tab") >= 0)//սեղանի կոճակն է սեղմած
            {
                //              NestUpdate();
                ManagerBox.BackColor = Color.NavajoWhite;
                PersonBox.BackColor = Color.NavajoWhite;
                TipMoney.BackColor = Color.NavajoWhite;
                string table_clicked = command.Text;
                if (remove.BackColor == Color.Green) //Տեղափոխում է։ նաև ստուգում է, որ ազատ լինի սեղանը
                {
                    if (nest.ForeColor == Color.Black)
                    {
                        int seans = int.Parse(Seans.Text);
                        string r1 = this.nest.Text;
                        string r2 = remove.Tag.ToString();
                        string r3 = bill.Text;
                        string r8 = TipMoney.Text;
                        dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
                        MySqlConnection connection = dbHelper.GetConnection();
                        connection.Open();
                        string UpdateQuery = $"UPDATE `ticket_provisional` SET  `Nest`= '{r1}' WHERE `Nest`= '{r2}' and `Ticket` = '{r3}' and `Seans` = '{seans}'  ";
                        using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();

                        DataRow[] foundRows = NestProvisional.Select("nest = '" + r2 + "'");
                        string r4 = foundRows[0]["printed"].ToString();
                        string r5 = foundRows[0]["taxprinted"].ToString();
                        string r6 = foundRows[0]["ticket"].ToString();
                        string r7 = foundRows[0]["person"].ToString();
                        UpdateQuery = $"UPDATE `NestProvisional` SET `Ocupied`= '0',`Printed`= '0',`Person`= '{0}',`Ticket`= '{0}',`Tipmoney`= '{0}'  WHERE `Nest`= '{r2}'";
                        using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();
                        UpdateQuery = $"UPDATE `NestProvisional` SET `Ocupied`= '1',`Printed`= '{r4}',`Person`= '{r7}',`Ticket`= '{r6}',`Tipmoney`='{r8}'  WHERE `Nest`= '{r1}'";
                        using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();

                        UpdateQuery = $"UPDATE `provisional` SET `Nest`= '{r1}'  WHERE `Nest`= '{r2}' and `Ticket` = '{r6}' and `Paid`='0' ";
                        using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
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

                //command.Text = "Enter";
                dataGridView1.Tag = "inprovisional";
                SendKeys.Send("{ENTER}");
                //dataGridView2.Refresh();
            }


            if (command.Text == "number" && dataGridView1.Tag.ToString() == "inprovisional")//պատվերի ընթացքի մեջ ենք և թիվ ենք սեղմել
            {
                foreach (DataRow row in Current_provisional.Rows)
                {

                    if (bool.Parse(row["current"].ToString()) == true)//.ToString() == dataGridView2.Tag.ToString())
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

            Button[] groupArray = new Button[30] { group1, group2, group3, group4, group5, group6, group7, group8, group9, group10,
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
            if (PersonBox.BackColor == Color.LightGreen && command.Text == "number")
            {
                PersonBox.Text = PersonBox.Text + command.Tag.ToString();
            }
            if (TipMoney.BackColor == Color.LightGreen && command.Text == "number")
            {
                TipMoney.Text = TipMoney.Text + command.Tag.ToString();
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

        //private void tab62_Click(object sender, EventArgs e)
        //{
        //    if (this.nest.Text != tab62.Text)
        //    {
        //        this.nest.Text = tab62.Text;
        //        nest.ForeColor = tab62.ForeColor;
        //        this.command.Text = tab62.Name;
        //        this.command.Focus();
        //        SendKeys.Send("{ENTER}");
        //    }
        //}
        private void tab62_Click(object sender, EventArgs e)
        {

            Button[] tabArray = new Button[62] { tab1, tab2, tab3, tab4, tab5, tab6, tab7, tab8, tab9, tab10, tab11, tab12, tab13, tab14, tab15, tab16, tab17, tab18, tab19, tab20, tab21, tab22, tab23, tab24, tab25, tab26, tab27, tab28, tab29, tab30, tab31, tab32, tab33, tab34, tab35, tab36, tab37, tab38, tab39, tab40, tab41, tab42, tab43, tab44, tab45, tab46, tab47, tab48, tab49, tab50, tab51, tab52, tab53, tab54, tab55, tab56, tab57, tab58, tab59, tab60, tab61, tab62 };
            if (tabArray[61].Text == "=>")
            {
                for (int i = 0; i < 61; i++)
                {
                    tabArray[i].Enabled = true;
                    tabArray[i].Text = _holl.ToString().Trim() + '-' + (i + 61).ToString();
                    DataRow[] foundRows = NestProvisional.Select("nest = '" + tabArray[i].Text + "'");
                    bool T = foundRows.Length == 0;
                    if (T == true) tabArray[i].Enabled = false;

                }
                tabArray[61].Text = "<=";

            }
            else
            {
                for (int i = 0; i < 61; i++)
                {
                    tabArray[i].Enabled = true;
                    tabArray[i].Text = _holl.ToString().Trim() + '-' + (i + 1).ToString();
                    DataRow[] foundRows = NestProvisional.Select("nest = '" + tabArray[i].Text + "'");
                    bool T = foundRows.Length == 0;
                    if (T == true) tabArray[i].Enabled = false;

                }
                tabArray[61].Text = "=>";
            }
            this.nest.Text = tab62.Text;
            this.command.Text = tab62.Name;
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number5_Click(object sender, EventArgs e)
        {
            command.Tag = "5";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number0_Click(object sender, EventArgs e)
        {
            command.Tag = "0";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number6_Click(object sender, EventArgs e)
        {
            command.Tag = "6";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number1_Click(object sender, EventArgs e)
        {
            command.Tag = "1";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number7_Click(object sender, EventArgs e)
        {
            command.Tag = "7";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number2_Click(object sender, EventArgs e)
        {
            command.Tag = "2";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number8_Click(object sender, EventArgs e)
        {
            command.Tag = "8";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number3_Click(object sender, EventArgs e)
        {
            command.Tag = "3";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number9_Click(object sender, EventArgs e)
        {
            command.Tag = "9";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void number4_Click(object sender, EventArgs e)
        {
            command.Tag = "4";
            command.Text = "number";
            this.command.Focus();
            SendKeys.Send("{ENTER}");
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
            ManagerBox.BackColor = Color.NavajoWhite;
            PersonBox.BackColor = Color.NavajoWhite;
            TipMoney.BackColor = Color.NavajoWhite;
            if (dataGridView1.Tag.ToString() == "inprovisional")//պատվերի ընթացքի մեջ ենք և "Enter" ենք սեղմել
            {
                float a_m = 0;
                float w_t = 0;
                float d_q = 0;
                bool acc = false;
                accept.Visible = false;
                printbutton2.Visible = false;
                cancel.Visible = false;
                foreach (DataRow row in Current_provisional.Rows)
                {


                    //if (row["id"].ToString() == dataGridView2.Tag.ToString())
                    if (bool.Parse(row["current"].ToString()) == true && row["qanak"].ToString().Length > 0 && row["qanak"].ToString() != "-")
                    {

                        acc = true;
                        row["quantity"] = float.Parse(row["qanak"].ToString());
                        row["salesamount"] = float.Parse(row["quantity"].ToString()) * float.Parse(row["price"].ToString());
                        row["service"] = float.Parse(row["salesamount"].ToString()) * float.Parse(service.Tag.ToString()) * 0.01;
                        row["discount"] = float.Parse(row["salesamount"].ToString()) * float.Parse(discount.Tag.ToString()) * 0.01;
                        row["current"] = false;
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
                if (acc)
                {
                    accept.Visible = true;
                }
                remove.Visible = false;
                if (a_m > 0)
                {
                    if (nest.ForeColor != Color.Black) // արդեն նստած սեղան է
                    {   cancel.Visible = true;
                        printbutton2.Visible = true;
                        remove.Visible = false;
                    }
                }
            }
            if (PersonBox.BackColor == Color.LightGreen) PersonBox.BackColor = Color.Wheat;
            if (ManagerBox.BackColor == Color.LightGreen) ManagerBox.BackColor = Color.Wheat;
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in Current_provisional.Rows)
            {
                if (row["id"].ToString() == dataGridView2.Tag.ToString())
                {
                    int L = row["qanak"].ToString().Length;
                    if (L > 0)
                    {
                        row["qanak"] = row["qanak"].ToString().Substring(0, L - 1); //աջից մել սիմվոլ ենք հեռացնում
                        dataGridView2.Refresh();
                    }
                }
            }
        }

        private void accept_Click(object sender, EventArgs e)
        {
            //dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            MySqlConnection connection = dbHelper.GetConnection();
            if (connection.State == ConnectionState.Closed) connection.Open();
            int tick = 1;

            foreach (DataRow row in Ticket_Provisional.Rows)
            {
                if (row["Nest"].ToString() == nest.Text && int.Parse(row["PaidMoney"].ToString()) == 0)
                {
                    tick = int.Parse(row["Ticket"].ToString());
      //              ManagerBox.Text = row["Note"].ToString();
                    break;
                }
                if (int.Parse(row["Ticket"].ToString()) >= tick) tick = int.Parse(row["Ticket"].ToString()) + 1;
            }

            int SeansState = int.Parse(Seans.Text);

            if (connection.State == ConnectionState.Closed) connection.Open();
            foreach (DataRow row in Current_provisional.Rows)  // չգրանցված պատվերները գռանցվում են  provisional - ում
            {

                bool accepted = Convert.ToBoolean(row["accepted"]); // Get accepted value
                if (accepted)
                {
                    continue; // Skip the loop if conditions are met
                }
                string InsertQuery = $"INSERT provisional SET `Code` = '{row["code"]}',`Name`='{row["name"]}',`Seans`='{SeansState}',`Ticket`='{tick}'," +
                    $"`Nest` = '{nest.Text}',`Quantity` = '{row["quantity"]}',`Qanak`='{row["qanak"]}',`Price`='{row["price"]}',`Salesamount`='{row["salesamount"]}'," +
                    $"`Service` = '{row["service"]}',`Discount`='{row["discount"]}',`Printer`='{row["printer"]}',`Paid`='0',`Taxpaid`='0',`Holl`='{_holl}',`Restaurant`='{_restaurant}' ";//,`date1`='{row["date1"]}',`date2`='{row["date2"]}',`printer`='{row["printer"]}'
                using (MySqlCommand insertCommand = new MySqlCommand(InsertQuery, connection))
                    insertCommand.ExecuteNonQuery();
            }


            DataRow[] foundRowsTI = Ticket_Provisional.Select($"`Nest`= '{nest.Text}' AND `Ticket`= '{tick}' AND `Seans` = '{SeansState}' ");

            if (foundRowsTI.Length == 0)
            {
                string InsertQuery = $"INSERT INTO `ticket_provisional`  (`Seans`,`Nest`,`DadaBegin`,`DataEnd`,`Ticket`," +
                    $"`Salesamount`,`Service`,`Discount`,`Person`,`Note`,`Restaurant`) VALUES  (@seans, @nest, @databegin, @dataend," +
                    $" @ticket,@salesamount, @service, @discount, @person, @note, @restaurant)";
                using (MySqlCommand updatCommand = new MySqlCommand(InsertQuery, connection))
                {
                    updatCommand.Parameters.AddWithValue("@seans", SeansState);
                    updatCommand.Parameters.AddWithValue("@nest", nest.Text);
                    updatCommand.Parameters.AddWithValue("@databegin", DateTime.Now);
                    updatCommand.Parameters.AddWithValue("@dataend", DateTime.Now);
                    updatCommand.Parameters.AddWithValue("@ticket", tick);
                    updatCommand.Parameters.AddWithValue("@salesamount", int.Parse(amount.Text));
                    updatCommand.Parameters.AddWithValue("@service", int.Parse(service.Text));
                    updatCommand.Parameters.AddWithValue("@discount", int.Parse(discount.Text));
                    updatCommand.Parameters.AddWithValue("@person", int.Parse(PersonBox.Text));
                    updatCommand.Parameters.AddWithValue("@note", ManagerBox.Text);
                    updatCommand.Parameters.AddWithValue("@restaurant", _restaurant);
                    updatCommand.ExecuteNonQuery();
                }

            }

            string UpdateQuery = $"UPDATE `ticket_provisional` SET `salesamount`= '{int.Parse(amount.Text)}'," +
                $"`Service`= '{int.Parse(service.Text)}',`Discount`='{int.Parse(discount.Text)}' ," +
                $"`Person`= '{int.Parse(PersonBox.Text)}',`Tipmoney`= '{int.Parse(TipMoney.Text)}',`Note`= '{ManagerBox.Text}'" +
                $"  WHERE `Seans` = '{SeansState}' AND `Nest`= '{nest.Text}' AND `Ticket`= '{tick}'";
            using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                updatCommand.ExecuteNonQuery();


            UpdateQuery = $"UPDATE `NestProvisional` SET `Ocupied`= '1',`Printed`= '0',`Person`= '{PersonBox.Text}',`Ticket`= '{tick}'," +
                $"`Tipmoney`= '{int.Parse(TipMoney.Text)}'  WHERE `Nest`= '{nest.Text}'";
            using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                updatCommand.ExecuteNonQuery();

            dataGridView2.Refresh();

            string query = $"SELECT * FROM `NestProvisional` WHERE `Restaurant`='{_restaurant}' ";//սեղանների աղյուսակը թարմացնում ենք
            NestProvisional = dbHelper.ExecuteQuery(query);
            NestUpdate();
            connection.Close();

            // ստեղծվում են Cur_provisional_1 ․․․ Cur_provisional_15  ները պրինտերի համարներով որոշվող խոհանոցներում տպելու համար
            DataTable Cur_provisional_1 = Current_provisional.Clone();
            var filteredRows1 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 1);

            DataTable Cur_provisional_2 = Current_provisional.Clone();
            var filteredRows2 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 2);

            DataTable Cur_provisional_3 = Current_provisional.Clone();
            var filteredRows3 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 3);

            DataTable Cur_provisional_4 = Current_provisional.Clone();
            var filteredRows4 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 4);

            DataTable Cur_provisional_5 = Current_provisional.Clone();
            var filteredRows5 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 5);

            DataTable Cur_provisional_6 = Current_provisional.Clone();
            var filteredRows6 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 6);

            DataTable Cur_provisional_7 = Current_provisional.Clone();
            var filteredRows7 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 7);

            DataTable Cur_provisional_8 = Current_provisional.Clone();
            var filteredRows8 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 8);

            DataTable Cur_provisional_9 = Current_provisional.Clone();
            var filteredRows9 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 9);

            DataTable Cur_provisional_10 = Current_provisional.Clone();
            var filteredRows10 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 10);

            DataTable Cur_provisional_11 = Current_provisional.Clone();
            var filteredRows11 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 11);

            DataTable Cur_provisional_12 = Current_provisional.Clone();
            var filteredRows12 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 12);

            DataTable Cur_provisional_13 = Current_provisional.Clone();
            var filteredRows13 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 13);

            DataTable Cur_provisional_14 = Current_provisional.Clone();
            var filteredRows14 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 14);

            DataTable Cur_provisional_15 = Current_provisional.Clone();
            var filteredRows15 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 15);

            DataTable Cur_provisional_16 = Current_provisional.Clone();
            var filteredRows16 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 16);

            DataTable Cur_provisional_17 = Current_provisional.Clone();
            var filteredRows17 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 17);

            DataTable Cur_provisional_18 = Current_provisional.Clone();
            var filteredRows18 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 18);

            DataTable Cur_provisional_19 = Current_provisional.Clone();
            var filteredRows19 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 19);

            DataTable Cur_provisional_20 = Current_provisional.Clone();
            var filteredRows20 = Current_provisional.AsEnumerable()
     .Where(row => row.Field<bool>("accepted") == false && row.Field<int>("quantity") > 0 && row.Field<int>("printer") == 20);
            // տպվում են պատվերի կտրոնները համաատասխան տպիչների վրա
            printbutton2.Visible = true;
            accept.Visible = false;

        }





        private void printbutton1_Click(object sender, EventArgs e)
        {
            ////////////////////////////////
            //  տպում է կտրոնը 
            ////////////////////////////////

            MySqlConnection connection = dbHelper.GetConnection();
            cancel.Visible = true;
            dataGridView1.Enabled = false;//տպած սեղանին փոփոխություն չի թույլատրվում
            remove.Visible = false;
            string nst = nest.Text;
            connection.Open();
            string UpdateQuery = $"UPDATE `NestProvisional` SET `Printed`= '1'  WHERE `Nest`= '{nest.Text}' AND `Restaurant`='1' ";
            using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                updatCommand.ExecuteNonQuery();
            string selectquery = $"SELECT * FROM `NestProvisional` WHERE `Restaurant`='{_restaurant}' ";//սեղանների աղյուսակը թարմացնում ենք
            NestProvisional = dbHelper.ExecuteQuery(selectquery);
            connection.Close();

        }


        private void forbidden_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            string forb = "0";
            connection.Open();
            DataRow[] matchingRows = NestProvisional.Select($"Nest = '{nest.Text}'");
            if (matchingRows.Length > 0)
            {
                forb = matchingRows[0]["forbidden"].ToString();
            }
            if (forb == "True")  // եթե սեղանը արգելված է ՝ թույլատրել
            {
                forbidden.ForeColor = Color.Black;
                dataGridView1.Enabled = true;
                string UpdateQuery = $"UPDATE `NestProvisional` SET `Forbidden`= ''  WHERE `Nest`= '{nest.Text}' AND `Restaurant`='{_restaurant}'";
                using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                    updatCommand.ExecuteNonQuery();
            }
            else// եթե սեղանը  թույլատրած է՝ արգելել
            {

                forbidden.ForeColor = Color.Red;
                dataGridView1.Enabled = false;
                string UpdateQuery = $"UPDATE `NestProvisional` SET `Forbidden`= '1'  WHERE `Nest`= '{nest.Text}' AND `Restaurant`='{_restaurant}'";
                using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                    updatCommand.ExecuteNonQuery();
            }

            string query = $"SELECT * FROM `NestProvisional` WHERE  AND `Restaurant`='{_restaurant}' ";//սեղանների աղյուսակը թարմացնում ենք
            NestProvisional = dbHelper.ExecuteQuery(query);
            connection.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            //բազայում տվյալ ապրանքի exist դաշտը դարձնել "" դատարկ
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectTable2Query = $"SELECT * FROM Table_215 WHERE code = {radioButton1.Tag}  AND `Restaurant`='{_restaurant}'";
            MySqlCommand selectTable2Command = new MySqlCommand(selectTable2Query, connection);
            object result = selectTable2Command.ExecuteScalar();
            if (result != null)
            {
                // Record found in Table2, update the name
                string updateTable2Query = $"UPDATE Table_215 SET existent = '' WHERE code = {radioButton1.Tag} AND `Restaurant`='{_restaurant}'";
                MySqlCommand updateTable2Command = new MySqlCommand(updateTable2Query, connection);
                updateTable2Command.ExecuteNonQuery();
            }
            DataRow[] foundRows = Table_215.Select($"Code = '{radioButton1.Tag}' AND Restaurant ='{_restaurant}'");
            foundRows[0]["existent"] = 0;
            connection.Close();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //բազայում տվյալ ապրանքի exist դաշտը դարձնել "3" ։ ապրանքը արգելել
            MySqlConnection connection = dbHelper.GetConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectTable2Query = $"SELECT * FROM Table_215 WHERE code = {radioButton1.Tag} AND Restaurant ='{_restaurant}'";
            MySqlCommand selectTable2Command = new MySqlCommand(selectTable2Query, connection);
            object result = selectTable2Command.ExecuteScalar();
            if (result != null)
            {
                // Record found in Table2, update the name
                string updateTable2Query = $"UPDATE Table_215 SET existent = '3' WHERE code = {radioButton1.Tag}  AND Restaurant ='{_restaurant}'";
                MySqlCommand updateTable2Command = new MySqlCommand(updateTable2Query, connection);
                updateTable2Command.ExecuteNonQuery();
            }
            DataRow[] foundRows = Table_215.Select($"Code = '{radioButton1.Tag}' AND Restaurant ='{_restaurant}'");
            foundRows[0]["existent"] = 3;

            connection.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //բազայում տվյալ ապրանքի exist դաշտը դարձնել "2" ։ Աշխատել որ վաճառվի
            MySqlConnection connection = dbHelper.GetConnection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            string selectTable2Query = $"SELECT * FROM Table_215 WHERE code = {radioButton1.Tag} AND Restaurant ='{_restaurant}'";
            MySqlCommand selectTable2Command = new MySqlCommand(selectTable2Query, connection);
            object result = selectTable2Command.ExecuteScalar();
            if (result != null)
            {
                // Record found in Table2, update the name
                string updateTable2Query = $"UPDATE Table_215 SET existent = '2' WHERE code = {radioButton1.Tag} AND Restaurant ='{_restaurant}'";
                MySqlCommand updateTable2Command = new MySqlCommand(updateTable2Query, connection);
                updateTable2Command.ExecuteNonQuery();
            }
            DataRow[] foundRows = Table_215.Select($"Code = {radioButton1.Tag} AND Restaurant ='{_restaurant}'");
            foundRows[0]["existent"] = 2;
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
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Check for a specific column index and ignore the header row
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                string curr = row.Cells[20].Value.ToString();
                string acc = row.Cells[19].Value.ToString();

                if (curr == "True") // Change the condition as per your requirement
                {

                    // Change the row color to, for example, LightGreen
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    if (acc == "False") // Change the condition as per your requirement
                    {

                        // Change the row color to, for example, LightGreen
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
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



        private void GroupClick_Click(object sender, EventArgs e)
        {
            dataView = new DataView(Table_215);
            dataView.RowFilter = $"department = " + DepartmentClick.Tag.ToString() + " AND Groupp= " + GroupClick.Tag.ToString();//բաժինը և խումբը ընտրվածներն են

            dataGridView1.DataSource = dataView;
        }

        private void addition1_Click(object sender, EventArgs e)
        {
            if (this.addition1.BackColor == Color.LightGreen)
            {
                this.addition1.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "1";
                this.AdditionClick.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void addition2_Click(object sender, EventArgs e)
        {
            if (this.addition2.BackColor == Color.LightGreen)
            {
                this.addition2.BackColor = Color.White;
                dataGridView3.Visible = false;
            }
            else
            {
                this.AdditionClick.Tag = "2";
                this.AdditionClick.Focus();
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
            Button[] buttonArray = new Button[20] { addition1, addition2, addition3, addition4, addition5, addition6, addition7, addition8, addition9, addition10,
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

        private void PersonBox_Enter(object sender, EventArgs e)
        {
            command.Text = "number";
            dataGridView1.Tag = "none";
            PersonBox.BackColor = Color.White;
            TipMoney.BackColor = Color.White;
            ManagerBox.BackColor = Color.White;
            PersonBox.BackColor = Color.LightGreen;
            PersonBox.Text = "";
        }

        private void ManagerBox_Enter(object sender, EventArgs e)
        {
            command.Text = "number";
            dataGridView1.Tag = "none";
            PersonBox.BackColor = Color.White;
            TipMoney.BackColor = Color.White;
            ManagerBox.BackColor = Color.LightGreen;
            ManagerBox.Text = "";
        }

        private void TipMoney_Click(object sender, EventArgs e)
        {
            command.Text = "number";
            dataGridView1.Tag = "none";
            PersonBox.BackColor = Color.White;
            ManagerBox.BackColor = Color.White;
            TipMoney.BackColor = Color.LightGreen;
            TipMoney.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.Tag = "inprovisional";// հայտանիշ է թվերը դնելու համար command կոճակի մեջ օգտագործելու 
            DataGridView dataGridView = (DataGridView)sender;
            object codeValue = dataGridView.Rows[e.RowIndex].Cells["code"].Value;
            object printerValue = dataGridView.Rows[e.RowIndex].Cells["printer"].Value;
            object priceValue = dataGridView.Rows[e.RowIndex].Cells["price"].Value;
            object existValue = dataGridView.Rows[e.RowIndex].Cells["existent"].Value;
            object nameValue = dataGridView.Rows[e.RowIndex].Cells["Name_1"].Value;
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
                int printer = int.Parse(printerValue.ToString());
                string exist = existValue.ToString();
                DataRow[] foundRows = Current_provisional.Select("current = true");  // Locate for current = true

                // If no records are found where current = true, append a blank record
                if (foundRows.Length == 0 && exist != "3") //Ապրանքը առկա է
                {
                    DataRow newRow = Current_provisional.NewRow(); // Append the new row to the Current_provisional և լրացնում է ընտրվածով
                    Current_provisional.Rows.Add(newRow);
                    newRow["current"] = true;
                    newRow["accepted"] = false;
                    newRow["id"] = Current_provisional.Rows.Count;
                    dataGridView2.Tag = Current_provisional.Rows.Count;
                    newRow["code"] = code;
                    newRow["name"] = name;
                    newRow["nest"] = nest.Text;
                    newRow["price"] = price;
                    newRow["quantity"] = 0;
                    newRow["salesamount"] = 0;
                    newRow["printer"] = printer;
                    newRow["qanak"] = "";
                    newRow["debet"] = "2211";
                    newRow["kredit"] = "2151";
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


                foreach (DataRow row in Current_provisional.Rows)//ընթացիկ տողը փոխարինում է նոր ընտրվածով
                {
                    if (row["current"].ToString().ToLower() == "true")
                    {
                        row["code"] = code;
                        row["name"] = name;
                        row["price"] = price;
                        row["quantity"] = 0;
                        row["salesamount"] = 0;
                        row["printer"] = printer;
                        row["qanak"] = "";
                    }
                }
                dataGridView2.Refresh();

            }

        }



        private void ManagerBox_Leave(object sender, EventArgs e)
        {
            if (ManagerBox.Text == string.Empty) ManagerBox.Text = "պատվիրատու";
            ManagerBox.BackColor = Color.White;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            MySqlConnection connection = dbHelper.GetConnection();
            int SeansState = int.Parse(Seans.Text);
            int tick = int.Parse(bill.Text);
            DateTime dat = DateTime.Now;
            connection.Open();
            string query = $"UPDATE `ticket_provisional` SET `PaidMoney` = @PaidMoney, `Tipmoney` = @Tipmoney, `DataEnd` = @DataEnd" +
                $" WHERE `Seans` = @Seans AND `Ticket` = @Ticket  AND `Nest` = @Nest  AND `Restaurant` =@Rest ";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PaidMoney", int.Parse(amount.Text));
                command.Parameters.AddWithValue("@Tipmoney", int.Parse(TipMoney.Text));
                command.Parameters.AddWithValue("@DataEnd", dat);
                command.Parameters.AddWithValue("@Seans", SeansState);
                command.Parameters.AddWithValue("@Ticket", tick);
                command.Parameters.AddWithValue("@Nest", nest.Text);
                command.Parameters.AddWithValue("@Rest", _restaurant);


                command.ExecuteNonQuery();
            }
            //////////////////////////////////////////////////////////////////////
            string UpdateQuery = $"UPDATE `NestProvisional` SET `Ocupied`= '0',`Printed`= '0',`Person`= '0',`Ticket`= ''," +
                $"`Taxprinted`= '0',`Tipmoney`= '0'  WHERE `Nest`= '{nest.Text}' AND Restaurant ='{_restaurant}' ";
            using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery, connection))
                updatCommand.ExecuteNonQuery();


            string UpdateQuery0 = $"UPDATE `provisional` SET `Paid`= '1'  WHERE `Nest`= '{nest.Text}' AND Restaurant ='{_restaurant}'";
            using (MySqlCommand updatCommand = new MySqlCommand(UpdateQuery0, connection))
                updatCommand.ExecuteNonQuery();

            dataGridView2.Refresh();

            string selectquery = $"SELECT * FROM `NestProvisional` WHERE `Restaurant`='{_restaurant}'";//սեղանների աղյուսակը թարմացնում ենք
            NestProvisional = dbHelper.ExecuteQuery(selectquery);
            NestUpdate();
            connection.Close();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (e.RowIndex > 0 && e.ColumnIndex >= 0) // Check for a specific column index and ignore the header row
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                string exis = row.Cells[Table_215_columnIndex].Value.ToString();
                //  this.Text= "row.Cells[Table_215_columnIndex].Value.ToString()="+row.Cells[Table_215_columnIndex].Value.ToString();
                if (exis == "2") // Change the condition as per your requirement
                {

                    // Change the row color to, for example, LightGreen
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    if (exis == "3") // Change the condition as per your requirement
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

        private void number_delete_Click(object sender, EventArgs e)
        {

        }

        private void open_nest_Click(object sender, EventArgs e)
        {

        }

        private void printbutton2_Click(object sender, EventArgs e)
        {

        }

        private void DepartmentClick_Click(object sender, EventArgs e)
        {
            Button[] groupArray = new Button[30] { group1, group2, group3, group4, group5, group6, group7, group8, group9, group10,
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
            dataView.RowFilter = "department = " + dep;




            dataGridView1.DataSource = dataView;
            int i = -1;
            int k = 0;
            foreach (DataRowView rowView in dataView)//տվյալ բաժնի խմբերի կոճակներն ենք կարգավորում

            {
                if (i < 29)
                {
                    DataRow row = rowView.Row;
                    DataRow[] matchingRows = Table_215_groups.Select($"Groupp= {row["Groupp"]}");
                    if (matchingRows.Length > 0)
                    {
                        k = 0;
                        for (int j = 0; j < 29; j++)
                        {
                            if (matchingRows[0]["Groupp"].ToString() == groupArray[j].Tag.ToString()) k = 1;
                        }
                        if (k == 1) continue;
                        i++;
                        groupArray[i].Text = matchingRows[0]["Name_1"].ToString(); // սա էլ կախված է լեզվի ընտրությունից։ պետք է մշակել
                        groupArray[i].Tag = matchingRows[0]["Groupp"].ToString();
                        groupArray[i].Visible = true;
                    }
                }

            }

        }

        private void PersonBox_Leave(object sender, EventArgs e)
        {
            PersonBox.BackColor = Color.White;
        }


    }
}


