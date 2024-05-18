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
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Web.Services.Description;


namespace WindowsFormsApp4
{
    public partial class DeliveryOrder : Form
    {
        private string _ooperatorname;
        private int _ooperator;
        private int _holl;
        private string _nest;
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

        private DataTable Table_211 = new DataTable();

        private DataTable Table215 = new DataTable();

        private DataTable Table_Composite = new DataTable();   //ստանդարտ պատվերներն են

        private DataTable DeliveryGroupp = new DataTable();// ճաշերի խմբերն են 

        private DataTable tableforprint = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable AdditionGroups = new DataTable();   //հավելումների խմբերի աղյուսակն է։ 

        private DataTable AdditionNames = new DataTable();   //հավելումների խմբերի բովանդակությունն է։

        private DataTable TableNest = new DataTable();   // Սեղանների ֆայլն է։ սպասարկման և զեղչի տոկոսների համար։ և ընթացիկ
                                                         // <ocupied>,<forbidden>,<ticket>,<printed>,<taxprinted>,<person>,<tipmoney> դաշտերով։

        private DataTable Department = new DataTable();   // բաժինների ֆայլն է։։ 

        private DataTable TicketsOrdered = new DataTable(); // հաշիվների մասին տեղեկություններ են ։ 

        private DataTable CurrentOrder = new DataTable();    // ընթացիկ պատվերի աղյուսակն է։ Ստեղծվում է ծրագիր մտնելիս

        private DataTable Order = new DataTable();    // պատվերը տպելու համար է 

        private DataTable BillPrint = new DataTable();    // կտրոնը տպելու համար է 

        private DataTable Table_Restaurants = new DataTable();    // Ռեստորանների ցանկն է

        private DataTable TiketsDelivery = new DataTable();

        private DataTable ControlsOrder = new DataTable();

        private DataTable Table_Workplace = new DataTable();

        private DataView dataView;

        public DeliveryOrder(string ooperatorname, int ooperator, int holl,string nest, int restaurant, int editor, int previous, int workplace, string language)
        {

            InitializeComponent();

            _ooperatorname = ooperatorname;
            _ooperator = ooperator;
            _holl = holl;
            _nest = nest;
            _restaurant = restaurant;
            _editor = editor; // եթե edit == 0 միայն դիտարկվում է;
            _previous = previous;
            _workplace = workplace;
            _language = language;
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();

            string query14 = $"SELECT *  FROM Table_211 WHERE Restaurant='{_restaurant}' ";
            Table_211 = dbHelper.ExecuteQuery(query14);


            string query13 = $"SELECT Code_215,Code_211  FROM Composite WHERE Restaurant='{_restaurant}' ";
            Table_Composite = dbHelper.ExecuteQuery(query13);
            Table_Composite.Columns.Add("Name", typeof(string));

            //********անուններն ենք տեղադրում
            var query = from row1 in Table_211.AsEnumerable()
                        join row2 in Table_Composite.AsEnumerable()
                        on row1.Field<string>("Code") equals row2.Field<string>("Code_211") into gj
                        from subRow2 in gj.DefaultIfEmpty()
                        select new
                        {
                            Row1 = row1,
                            Row2 = subRow2
                        };

            foreach (var item in query)
            {
                if (item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1[_language];

                }
            }

            string query1 = $"SELECT * FROM Table_215 WHERE  Restaurant='{_restaurant}'" +
                $" AND Existent != {3} AND Price5 != {0} AND DeliveryGroupp is not Null ORDER BY [Groupp] ";
            Table215 = dbHelper.ExecuteQuery(query1);
            Table_215 = Table215.Clone();
            Table_215.Columns.Add("Name", typeof(string));
            Table215.Columns.Add("Name", typeof(string));
            string inh = _holl.ToString() + ",";
            foreach (DataRow row in Table215.Rows) //տվյալ սրահի համար չնախատեսված ապրանքները հանում ենք
            {
                row["Price"] = row["Price5"];
                string inholl = row["inholl"].ToString();
                if (float.Parse(row["Price"].ToString()) == 0) continue;
                if ((row["inholl"].ToString().Trim() != "0" && row["inholl"].ToString().Trim() != string.Empty) && inholl.IndexOf(inh) < 0) continue;
                DataRow newRow = Table_215.NewRow();
                Table_215.Rows.Add(newRow);
                for (int colIndex = 0; colIndex < Table_215.Columns.Count; colIndex++)
                {
                    string columnName = Table_215.Columns[colIndex].ColumnName;
                    newRow[columnName] = row[columnName];
                }
            }
            Translate.translation(Table_215, Table215, _language, "1");

            string query2 = $"SELECT * FROM AdditionGroups WHERE  Restaurant='{_restaurant}' ";
            AdditionGroups = dbHelper.ExecuteQuery(query2);
            Translate.translation(AdditionGroups, AdditionGroups, _language, "2");

            string query3 = $"SELECT * FROM AdditionNames WHERE  Restaurant='{_restaurant}' ";
            AdditionNames = dbHelper.ExecuteQuery(query3);
            Translate.translation(AdditionNames, AdditionNames, _language, "2");

            string query4 = $"SELECT * FROM DeliveryGroupp WHERE  Restaurant='{_restaurant}' ";
            DeliveryGroupp = dbHelper.ExecuteQuery(query4);

            string query5 = $"SELECT * FROM Restaurants";
            Table_Restaurants = dbHelper.ExecuteQuery(query5);
            DataRow[] foundRows1 = Table_Restaurants.Select($"Id = '{_restaurant}' ");
            Restaurantname = "";
            if (foundRows1.Length > 0)
            {
                Restaurantname = foundRows1[0]["Name"].ToString();
                this.Text = Restaurantname;
            }

          //  string query6 = $"SELECT * FROM SeansOnline WHERE  Restaurant='{_restaurant}'  ";
          //  TableSeans = dbHelper.ExecuteQuery(query6);

            string query7 = $"SELECT * FROM TiketsDelivery WHERE  Restaurant='{_restaurant}'  ";
            TiketsDelivery = dbHelper.ExecuteQuery(query7);




            Translate.translation(Table215, Table_215, _language, "1");



            dataGridView1.DataSource = Table_215;
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.Columns[1].DataPropertyName = "Price";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index > 1)
                {
                    column.Visible = false;
                }

            }



            dataGridView3.DataSource = Table_Composite;
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
            CurrentOrder.Columns.Add("standart", typeof(decimal));
            CurrentOrder.Columns.Add("date1", typeof(DateTime));
            CurrentOrder.Columns.Add("date2", typeof(DateTime));
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
            dataGridView2.Columns[2].DataPropertyName = "quantity";
            dataGridView2.Columns[3].DataPropertyName = "salesamount";

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                 if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }
            //   dataGridView2.Columns[4].DataPropertyName = "current";
            //bindingSource.DataSource = CurrentOrder;
            connection.Close();

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            SetLanguage(_language);
            InitForm();
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
            string query1 = $"SELECT * FROM ControlsOnlineOrder  ";
            ControlsOrder = dbHelper.ExecuteQuery(query1);
            foreach (Control control in this.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsOrder.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel2.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsOrder.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel5.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsOrder.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel6.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsOrder.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                string columnName = dataGridView1.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsOrder.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0 && columnName.IndexOf("215") < 0)
                {
                    dataGridView1.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }

            }

            for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
            {
                string columnName = dataGridView2.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsOrder.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView2.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }
            }
            connection.Close();
        }

        private void InitForm()
        {
            
            Button[] groupArray = new System.Windows.Forms.Button[30] { group1, group2, group3, group4, group5, group6, group7, group8, group9, group10,
                group11, group12, group13, group14, group15, group16, group17, group18, group19, group20,
                group21, group22, group23, group24, group25, group26, group27,group28, group29, group30 };
            for (int j = 0; j < 30; j++)
            {
                groupArray[j].Visible = false;
                groupArray[j].Tag = "0";
            }
            dataView = new DataView(Table_215);
            dataGridView1.DataSource = dataView;
            int i = -1;
            int k = 0;
            int gr = 0;
            foreach (DataRow row in Table_215.Rows)
            {
                gr = int.Parse(row["DeliveryGroupp"].ToString());
                
                DataRow[] foundRows = DeliveryGroupp.Select($"DeliveryGroupp = '{gr}' ");
                if (foundRows.Length > 0)
                {
                    if (i < 29)
                    {
                        k = 0;
                        for (int j = 0; j < 29; j++)
                        {
                            if (foundRows[0]["DeliveryGroupp"].ToString() == groupArray[j].Tag.ToString()) k = 1;
                        }
                        if (k == 1) continue; // տվյալ խմբի կոճակը արդեն ֆիքսել ու ձևավորել ենք
                        i++;
                        groupArray[i].Text = foundRows[0][_language].ToString();
                        groupArray[i].Tag = foundRows[0]["DeliveryGroupp"].ToString();
                        groupArray[i].Visible = true;
                    }
                }

            }
            decimal screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            decimal screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            decimal kw = screenWidth / this.Width;
            decimal kh = screenHeight / this.Height;
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

            foreach (Control control in panel2.Controls)
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
            this.Width = (int)screenWidth;
            this.Height = (int)screenHeight;
            this.Top = 0;
            this.Left = 0;


        }


        private void DeliveryOrder_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void DeliveryOrder_ResizeEnd(object sender, EventArgs e)
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
            foreach (Control control in panel2.Controls)
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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string image = "";
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



                if (codeValue != null )
                {
                    string code = codeValue.ToString().Trim();
                    pictureBox1.Tag = code;
                    string path = FindFolder.Folder("Images");
                    image = path + "\\" + code + ".jpg";
                    if (!File.Exists(image))
                    {
                        image = path+"\\blank.jpg";
                    }

                    pictureBox1.Image = Image.FromFile(image);
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

                    DataRow[] foundRows = CurrentOrder.Select($"Code = {code} OR Quantity={0}");  // Locate for current = true

                    
                    if (foundRows.Length == 0) //Ապրանքը առկա է
                    {
                        DataRow newRow = CurrentOrder.NewRow(); // Append the new row to the CurrentOrder և լրացնում է ընտրվածով
                        CurrentOrder.Rows.Add(newRow);
                        dataGridView2.Tag = CurrentOrder.Rows.Count;
                        newRow["current"] = 1;
                        newRow["accepted"] = false;
                        newRow["id"] = CurrentOrder.Rows.Count;
                        newRow["code"] = code;
                        newRow["nest"] = _nest;
                        newRow["groupp"] = groupp;
                        newRow["name"] = name;
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
                    else
                    {
                        DataRow[] foundRows1 = CurrentOrder.Select($"Quantity = {0}");
                        if (foundRows1.Length > 0)
                        {
                            foundRows1[0]["accepted"] = false;
                            foundRows1[0]["id"] = CurrentOrder.Rows.Count;
                            foundRows1[0]["code"] = code;
                            foundRows1[0]["nest"] = _nest;
                            foundRows1[0]["groupp"] = groupp;
                            foundRows1[0]["name"] = name;
                            foundRows1[0]["price"] = price;
                            foundRows1[0]["costprice"] = costprice;
                            foundRows1[0]["quantity"] = 0;
                            foundRows1[0]["department"] = department;
                            foundRows1[0]["salesamount"] = 0;
                            foundRows1[0]["printer"] = printer;
                            foundRows1[0]["qanak"] = "";
                            foundRows1[0]["debet"] = "2211";
                            foundRows1[0]["kredit"] = "2151";
                            foundRows1[0]["free"] = free;
                        }
                    }

                    dataView = new DataView(Table_Composite);
                    dataView.RowFilter = $"Code_215 = {code} ";//բաժինը և խումբը ընտրվածներն են
                    dataGridView3.DataSource = dataView;

                }

            }
        }

        private void GroupClick(object groupp)
        {
            this.Text = groupp.ToString();
            Button[] groupArray = new System.Windows.Forms.Button[30] { group1, group2, group3, group4, group5, group6, group7, group8, group9, group10,
                group11, group12, group13, group14, group15, group16, group17, group18, group19, group20,
                group21, group22, group23, group24, group25, group26, group27,group28, group29, group30 };
            for (int i = 0; i < 29; i++)
            {
                groupArray[i].BackColor = Color.White;
                if (groupArray[i].Tag == groupp)
                {
                    groupArray[i].BackColor = Color.LightGreen;
                }
            }
            int gr=int.Parse(groupp.ToString());
            dataView = new DataView(Table_215);
            dataView.RowFilter = $"DeliveryGroupp = {gr} ";//բաժինը և խումբը ընտրվածներն են
            dataGridView1.DataSource = dataView;
        }

        private void group1_Click(object sender, EventArgs e)
        {

            GroupClick(group1.Tag);
        }

        private void group2_Click(object sender, EventArgs e)
        {
            GroupClick(group2.Tag);
        }

        private void group3_Click(object sender, EventArgs e)
        {
            GroupClick(group3.Tag);
        }

        private void group4_Click(object sender, EventArgs e)
        {
            GroupClick(group4.Tag);
        }

        private void group5_Click(object sender, EventArgs e)
        {
            GroupClick(group5.Tag);
        }

        private void group6_Click(object sender, EventArgs e)
        {
            GroupClick(group6.Tag);
        }

        private void group7_Click(object sender, EventArgs e)
        {
            GroupClick(group7.Tag);
        }

        private void group8_Click(object sender, EventArgs e)
        {
            GroupClick(group8.Tag);
        }

        private void group9_Click(object sender, EventArgs e)
        {
            GroupClick(group9.Tag);
        }

        private void group10_Click(object sender, EventArgs e)
        {
            GroupClick(group10.Tag);
        }

        private void group11_Click(object sender, EventArgs e)
        {
            GroupClick(group11.Tag);
        }

        private void group12_Click(object sender, EventArgs e)
        {
            GroupClick(group12.Tag);
        }

        private void group13_Click(object sender, EventArgs e)
        {
            GroupClick(group13.Tag);
        }

        private void group14_Click(object sender, EventArgs e)
        {
            GroupClick(group14.Tag);
        }

        private void group15_Click(object sender, EventArgs e)
        {
            GroupClick(group15.Tag);
        }

        private void group16_Click(object sender, EventArgs e)
        {
            GroupClick(group16.Tag);
        }

        private void group17_Click(object sender, EventArgs e)
        {
            GroupClick(group17.Tag);
        }

        private void group18_Click(object sender, EventArgs e)
        {
            GroupClick(group18.Tag);
        }

        private void group19_Click(object sender, EventArgs e)
        {
            GroupClick(group19.Tag);
        }

        private void group20_Click(object sender, EventArgs e)
        {
            GroupClick(group20.Tag);
        }

        private void group21_Click(object sender, EventArgs e)
        {
            GroupClick(group21.Tag);
        }

        private void group22_Click(object sender, EventArgs e)
        {
            GroupClick(group22.Tag);
        }

        private void group23_Click(object sender, EventArgs e)
        {
            GroupClick(group23.Tag);
        }

        private void group24_Click(object sender, EventArgs e)
        {
            GroupClick(group24.Tag);
        }

        private void group25_Click(object sender, EventArgs e)
        {
            GroupClick(group25.Tag);
        }

        private void group26_Click(object sender, EventArgs e)
        {
            GroupClick(group26.Tag);
        }

        private void group27_Click(object sender, EventArgs e)
        {
            GroupClick(group27.Tag);
        }

        private void group28_Click(object sender, EventArgs e)
        {
            GroupClick(group28.Tag);
        }

        private void group29_Click(object sender, EventArgs e)
        {
            GroupClick(group29.Tag);
        }

        private void group30_Click(object sender, EventArgs e)
        {
            GroupClick(group30.Tag);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string cd = pictureBox1.Tag.ToString();
            DataRow[] foundRows = CurrentOrder.Select($"code = '{cd}'");
            if (foundRows.Length > 0)
            {
                foundRows[0]["quantity"] = float.Parse(foundRows[0]["quantity"].ToString()) + 0.5;
                foundRows[0]["Salesamount"] = float.Parse(foundRows[0]["quantity"].ToString()) * float.Parse(foundRows[0]["price"].ToString());
            }
            sum();
        }
        private void sum()
        {
            float am = 0;
            foreach (DataRow row in CurrentOrder.Rows)
            {
                am = am + float.Parse(row["Salesamount"].ToString());
            }
            amount.Text = am.ToString();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string cd = pictureBox1.Tag.ToString();
            DataRow[] foundRows = CurrentOrder.Select($"code = '{cd}'");
            if (foundRows.Length > 0)
            {
                foundRows[0]["quantity"] =float.Parse(foundRows[0]["quantity"].ToString()) + 1;
                foundRows[0]["Salesamount"] = float.Parse(foundRows[0]["quantity"].ToString()) * float.Parse(foundRows[0]["price"].ToString());
            }
            sum();
            button6.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cd = pictureBox1.Tag.ToString();
            DataRow[] foundRows = CurrentOrder.Select($"code = '{cd}'");
            if (foundRows.Length > 0)
            {
                foundRows[0]["quantity"] = Math.Max(0, float.Parse(foundRows[0]["quantity"].ToString()) - 1);
                foundRows[0]["Salesamount"] = float.Parse(foundRows[0]["quantity"].ToString()) * float.Parse(foundRows[0]["price"].ToString());
            }
            sum();
            button6.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cd = pictureBox1.Tag.ToString();
            DataRow[] foundRows = CurrentOrder.Select($"code = '{cd}'");
            if (foundRows.Length > 0)
            {
                foundRows[0]["quantity"] = Math.Max(0, float.Parse(foundRows[0]["quantity"].ToString()) - 0.5);
                foundRows[0]["Salesamount"] = float.Parse(foundRows[0]["quantity"].ToString()) * float.Parse(foundRows[0]["price"].ToString());
            }
            sum();
        }  

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore non-numeric characters
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim().Length < 9)
            {
                label6.Visible = true;
            }
            else
            {
                this.Text = "                                                                              Ձեր պատվերը ընդունված է։ Մատուցողը կմոտենա Ձեզ";
                this.Text = "                                                                              Ձեր պատվերը ընդունված է։ Մեր աշխատակիցը կզանգի Ձեզ";
                string connectionString = Properties.Settings.Default.CafeRestDB;
                SqlConnection connection = new SqlConnection(connectionString);
                SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
                if (connection.State == ConnectionState.Closed) connection.Open();
                int tick = 1;
                if (label8.Text == "0")
                {


                    foreach (DataRow row in TiketsDelivery.Rows)
                    {
                        if (int.Parse(row["Restaurant"].ToString()) != _restaurant) continue;
                        if (int.Parse(row["Ticket"].ToString()) >= tick) tick = int.Parse(row["Ticket"].ToString()) + 1;
                    }
                    label8.Text = tick.ToString();
                    string InsertQuery = $"INSERT INTO TiketsDelivery ( Ticket, Telefon, Addres, DateOrder,Cooked,Deleted,Done,Restaurant)" +
                        $" values( @Ticket, @Telefon, @Addres, @DateOrder,@Cooked,@Deleted,@Done,@Restaurant)";
                    using (SqlCommand insertCommand = new SqlCommand(InsertQuery, connection))

                    {
                        insertCommand.Parameters.AddWithValue("@Ticket", tick);
                        insertCommand.Parameters.AddWithValue("@Telefon", textBox2.Text);
                        insertCommand.Parameters.AddWithValue("@Addres", textBox1.Text);
                        insertCommand.Parameters.AddWithValue("@DateOrder", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@Deleted", 0);
                        insertCommand.Parameters.AddWithValue("@Done", 0);
                        insertCommand.Parameters.AddWithValue("@Cooked", 0);
                        insertCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        insertCommand.ExecuteNonQuery();

                    }
                }
                else
                {
                    tick = int.Parse(label8.Text);
                }
                label8.Visible = true;
                if (connection.State == ConnectionState.Closed) connection.Open();
                float delivery = 0;
                float music = 0;
                float cost = 0;
                foreach (DataRow row in CurrentOrder.Rows)  // չգրանցված պատվերները գրանցվում են  Seans - ում
                {
                    bool accepted = bool.Parse(row["accepted"].ToString());

                    if (accepted == true || float.Parse(row["Quantity"].ToString()) == 0)
                    {
                        continue; // Skip the loop if conditions are met
                    }
                    //    cost = cost + float.Parse(row["costamount"].ToString());
                    string name = row["name"].ToString();
                    int groupp = int.Parse(row["groupp"].ToString());
                    if (groupp == 291)
                    {
                        delivery = delivery + float.Parse(row["salesamount"].ToString());
                    }
                    if (groupp == 292) music = music + float.Parse(row["salesamount"].ToString());

                    string InsertQuery = $"INSERT INTO Seans ( Code,  Ticket,DateOfEntry," +
                        $" Quantity  , Price, Salesamount, State,Service,Discount, Paid, nest , Holl, Restaurant)" +
                        $" values (@Code , @Ticket, @DateOfEntry, @Quantity ,@Price, @Salesamount," +
                        $" @State,@Service,@Discount, @Paid, @nest, @Holl, @Restaurant)";
                    using (SqlCommand insertCommand = new SqlCommand(InsertQuery, connection))

                    {
                        insertCommand.Parameters.AddWithValue("@Code", row["code"]);
                        insertCommand.Parameters.AddWithValue("@Ticket", tick);
                        insertCommand.Parameters.AddWithValue("@DateOfEntry", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@Quantity", row["quantity"]);
                        insertCommand.Parameters.AddWithValue("@Price", row["price"]);
                        insertCommand.Parameters.AddWithValue("@Service", 0);
                        insertCommand.Parameters.AddWithValue("@Discount", 0);
                        insertCommand.Parameters.AddWithValue("@Salesamount", row["salesamount"]);
                        insertCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                        insertCommand.Parameters.AddWithValue("@Paid", 0);
                        insertCommand.Parameters.AddWithValue("@Holl", _holl);
                        insertCommand.Parameters.AddWithValue("@nest", _nest);
                        insertCommand.Parameters.AddWithValue("@State", 1);
                        insertCommand.ExecuteNonQuery();
                    }
                    row["accepted"] = true;

                }
                connection.Close();
                button6.Visible = false;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label6.Visible=false;
        }

        private HelpDialogForm helpDialogForm;
        private void HelpButton_Click(object sender, EventArgs e)
        {
            string help = FindFolder.Folder("Help");
            string filePath = "";

                filePath = help + "\\OnlineOrder_" + _language + ".txt";
                string fileContent = File.ReadAllText(filePath);

                if (helpDialogForm == null)
                {
                    helpDialogForm = new HelpDialogForm();
                    helpDialogForm.FormClosed += (s, args) => helpDialogForm = null; // Reset the helpDialogForm reference when the form is closed
                }

                helpDialogForm.SetHelpContent(fileContent);
                helpDialogForm.Show();

        }
    }
    }


