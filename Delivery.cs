using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WindowsFormsApp4
{
    public partial class Delivery : Form
    {
        private string _ooperatorname;
        private int _ooperator;
        private int _holl;
        private string _nest;
        private int _restaurant;
        private int _editor;
        private string _language;
        private string _Restaurantname;

        private SQLDatabaseHelper dbHelper;


        private DataTable TableSeans = new DataTable();  

        private DataTable Table_215 = new DataTable();   //Ճաշացուցակն է։ 

        private DataTable AdditionGroups = new DataTable();   //հավելումների խմբերի աղյուսակն է։ 

        private DataTable AdditionNames = new DataTable();   //հավելումների խմբերի բովանդակությունն է։

        private DataTable TableNest = new DataTable();   

        private DataTable Table_Composite = new DataTable();

        private DataTable Table_Actions = new DataTable();

        private DataTable Table_Delivery = new DataTable();   

        private DataTable CurrentOrder = new DataTable();

        private DataTable tableforprint = new DataTable();

        private DataTable Order = new DataTable();    // պատվերը տպելու համար է 

        private DataTable BillPrint = new DataTable();    // կտրոնը տպելու համար է 

        private DataTable Table_Restaurants = new DataTable();    // Ռեստորանների ցանկն է

        private DataTable ControlsOrder = new DataTable();

        private DataView dataView;
        public Delivery(string ooperatorname, int ooperator, int holl, string nest, int restaurant, string Restaurantname, int editor, string language)
        {
            InitializeComponent();
            InitForm();
            _ooperatorname = ooperatorname;
            _ooperator = ooperator;
            _nest = nest;
            _holl = holl;
            _restaurant = restaurant;
            _editor = editor; // եթե edit == 0 միայն դիտարկվում է;
            _language = language;
            _Restaurantname = Restaurantname;

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
            CurrentOrder.Columns.Add("NonComposite", typeof(string));

            //************************************

            Table_Delivery.Columns.Add("ticket", typeof(int));
            Table_Delivery.Columns.Add("date1", typeof(DateTime));



            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);





            connection.Open();

            string query1 = $"SELECT * FROM Table_215 WHERE  Restaurant='{_restaurant}'" +
               $" AND Existent != {3} AND Price5 != {0} AND DeliveryGroupp is not Null ORDER BY [Groupp] ";
            Table_215 = dbHelper.ExecuteQuery(query1);

            string query2 = $"SELECT * FROM Seans WHERE  Restaurant='{_restaurant}' AND Holl='{_holl}'  ";

           
            TableSeans = dbHelper.ExecuteQuery(query2);

            string query3 = $"SELECT * FROM TiketsDelivery WHERE Deleted=0 AND Done=0 AND Restaurant='{_restaurant}' ORDER BY DateOrder ";
            Table_Delivery = dbHelper.ExecuteQuery(query3);

            dataGridView1.DataSource = Table_Delivery;
            dataGridView1.Columns[0].DataPropertyName = "Ticket";  
            dataGridView1.Columns[1].DataPropertyName = "DateOrder";
            dataGridView1.Columns[2].DataPropertyName = "Telefon";
            dataGridView1.Columns[3].DataPropertyName = "Deleted";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }

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

        }


        public void InitForm()
        {

            decimal screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            decimal screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            //   Screen primaryScreen = Screen.PrimaryScreen;
            //   int screenWidth = primaryScreen.Bounds.Width;
            //   int screenHeigh = primaryScreen.Bounds.Height;
            decimal kw = screenWidth / this.Width;
            decimal kh = screenHeight / this.Height;
            foreach (Control control in this.Controls)
            {
                // Փոփոխվում են օբյեկների չափն ու տեղադրությունը ** Objects are resized and positioned
            //    control.Left = (int)(control.Left * (double)kw);
                control.Top = (int)(control.Top * (double)kh);
              //  control.Width = (int)(control.Width * (double)kw);
                control.Height = (int)(control.Height * (double)kh);
            }
            //dataGridView1.Columns[0].Width = (int)(dataGridView1.Columns[0].Width * 1.15);
            //dataGridView1.Columns[1].Width = (int)(dataGridView1.Columns[1].Width * 1.15);
            //dataGridView2.Columns[0].Width = (int)(dataGridView2.Columns[0].Width * 1.15);
            //dataGridView2.Columns[1].Width = (int)(dataGridView2.Columns[1].Width * 1.15);
            //dataGridView2.Columns[2].Width = (int)(dataGridView2.Columns[2].Width * 1.15);
            //dataGridView2.Columns[3].Width = (int)(dataGridView2.Columns[3].Width * 1.15);

            foreach (Control control in panel1.Controls)
            {
                //control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
              //  control.Top = (int)(control.Top * kh);
                //control.Left = (int)(control.Left * kw);
            }

            //this.Width = (int)screenWidth;
            this.Height = (int)screenHeight-20;
            this.Top = 0;
            this.Left = 0;
            /////////////////////////////////////////////// 
            //NestUpdate();

        }

        private void accept_Click(object sender, EventArgs e)
        {
            tableforprint = CurrentOrder.Clone();
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            //պատվերի կտրոնն ենք ձևավորում 
            foreach (DataRow row in CurrentOrder.Rows) 
            {
                DataRow newRow = tableforprint.NewRow();
                tableforprint.Rows.Add(newRow);
                for (int colIndex = 0; colIndex < CurrentOrder.Columns.Count; colIndex++)
                {
                    string columnName = CurrentOrder.Columns[colIndex].ColumnName;
                    newRow[columnName] = row[columnName];
                }
            }
            int tick=int.Parse(printbutton1.Tag.ToString() );//ֆիքսում ենք, որ ուղարկվել է պատրաստման
            string UpdateQuery1 = $"UPDATE TiketsDelivery SET Cooked = 1 WHERE Ticket = '{tick}' AND Restaurant='{_restaurant}' ";
            using (SqlCommand updatCommand = new SqlCommand(UpdateQuery1, connection))
                updatCommand.ExecuteNonQuery();
            connection.Close();
            string ticket = printbutton1.Tag.ToString();
            string nest = "9-1";
            string pers = "0";

            // տպվում են պատվերի կտրոնները համաատասխան տպիչների վրա
            printtocook.printingtocook(1, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(2, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(3, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(4, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(5, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(6, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(7, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(8, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(9, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(10, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(11, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(12, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(13, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(14, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);
            printtocook.printingtocook(15, Table_215, tableforprint, ticket, nest, pers, _Restaurantname, _ooperatorname, _language);

            string query = $"SELECT * FROM TiketsDelivery WHERE Deleted=0 AND Done=0 AND Restaurant='{_restaurant}' ORDER BY DateOrder ";
            Table_Delivery = dbHelper.ExecuteQuery(query);
            dataGridView1.DataSource = Table_Delivery;
            accept.Visible=false;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentOrder.Clear();
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView != null && e.RowIndex >= 0 && e.RowIndex <= dataGridView.Columns.Count)
            {
                object deleteValue = dataGridView.Rows[e.RowIndex].Cells["Deleted"].Value;
                if (dataGridView.Rows[e.RowIndex].Cells["Deleted"].Value.GetType() == typeof(int) && int.Parse(deleteValue.ToString()) == 0)
                {
                    dataGridView.Rows[e.RowIndex].Cells["Deleted"].Value = 0;
                }
            }
            object ticketValue = dataGridView.Rows[e.RowIndex].Cells["Ticket"].Value;
            object datetValue = dataGridView.Rows[e.RowIndex].Cells["DateOrder"].Value;
            object cookValue = dataGridView.Rows[e.RowIndex].Cells["cooked"].Value;
            DateTime date = DateTime.Parse(datetValue.ToString());
            int ticket = Convert.ToInt32(ticketValue);
            printbutton1.Tag = ticket.ToString();
            dataGridView2.Tag = datetValue.ToString();
            float total = 0;
            if (dataGridView.Rows[e.RowIndex].Cells["Deleted"].Value != DBNull.Value && Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Deleted"].Value) == 0)
            {
                foreach (DataRow row in TableSeans.Rows)
                {
                    if (int.Parse(row["Ticket"].ToString()) != ticket) continue;
                    DataRow newRow = CurrentOrder.NewRow();
                    CurrentOrder.Rows.Add(newRow);
                    newRow["code"] = row["code"];
                    newRow["quantity"] = row["quantity"];
                    newRow["price"] = row["price"];
                    newRow["salesamount"] = row["salesamount"];
                    newRow["date1"] = date;
                    newRow["service"] = 0;
                    newRow["discount"] = 0;
                    total = total + float.Parse(row["salesamount"].ToString());
                }
                amount.Text = total.ToString();
                label2.Visible = true;
                accept.Visible = true;
                printbutton1.Visible = true;
                cancel.Visible = true;
                if (Convert.ToInt32(cookValue) == 1) accept.Visible = false;

                var query = from row1 in Table_215.AsEnumerable()
                            join row2 in CurrentOrder.AsEnumerable()
                            on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
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
                        item.Row2["Free"] = item.Row1["Free"];
                        item.Row2["printer"] = item.Row1["printer"];
                        item.Row2["Department"] = item.Row1["Department"];
                        item.Row2["NonComposite"] = item.Row1["NonComposite"];
                        item.Row2["debet"] = "2211";
                        item.Row2["kredit"] = "2151";

                    }
                }
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            Save.Visible = true;

        }

        private void Save_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
           // DataGridView dataGridView = (DataGridView)sender;

            foreach (DataRow row in Table_Delivery.Rows)
            {
                if (int.Parse(row["Deleted"].ToString()) == 0) continue;
                if (row["Deleted"].GetType() == typeof(int) && int.Parse(row["Deleted"].ToString()) == 1)
                {
                    string UpdateQuery = $"UPDATE TiketsDelivery  SET Deleted = @Deleted  WHERE Ticket= @Ticket and Restaurant=@Rest ";
                    using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                    {
                        command.Parameters.AddWithValue("Deleted", 1);
                        command.Parameters.AddWithValue("@Ticket", row["ticket"]);
                        command.Parameters.AddWithValue("@Rest", _restaurant);
                        command.ExecuteNonQuery();
                    }
                }
                
            }
            string query = $"SELECT * FROM TiketsDelivery WHERE Deleted=0 AND Done=0 AND Restaurant='{_restaurant}' ORDER BY DateOrder ";
            Table_Delivery = dbHelper.ExecuteQuery(query);
            dataGridView1.DataSource = Table_Delivery;
            connection.Close();
            Save.Visible = false;

        }

        private void printbutton1_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            DateTime DateBegin = DateTime.Parse(dataGridView2.Tag.ToString());
            //ձևավորում ենք կտրոնի աղյուսակը
            connection.Close();
            BillPrint = CurrentOrder.Clone();
            foreach (DataRow row in CurrentOrder.Rows)
            {
                if (float.Parse(row["quantity"].ToString()) == 0) continue;
                DataRow newRow = BillPrint.NewRow();
                BillPrint.Rows.Add(newRow);
                for (int colIndex = 0; colIndex < CurrentOrder.Columns.Count; colIndex++)
                {
                    string columnName = CurrentOrder.Columns[colIndex].ColumnName;
                    newRow[columnName] = row[columnName];
                }
            }
            Translate.translation(Table_215, BillPrint, _language, "1");// տեղադրվում են անունները
            PrintingBill.PrintBill(printbutton1.Tag.ToString(), "9-1", "0", "0", 0, 0, DateBegin, DateTime.Now, BillPrint, _Restaurantname, _language);

            connection.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            int _ticket = int.Parse(printbutton1.Tag.ToString());
            string _nest = "9-1";
            string _amount = amount.Text;
            float _tipmoney = 0;
            int _person = 0;
            int _previous = 0;
            string connectionString = Properties.Settings.Default.CafeRestDB;
            Paiment.Release(connectionString, 1, _restaurant, _holl,
            _ticket, _nest, _amount, _previous, _person, _tipmoney);
            cancel.Visible = false;
            printbutton1.Visible = false;
            accept.Visible=false;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            string UpdateQuery = $"UPDATE TiketsDelivery  SET Done = 1  WHERE Ticket= @Ticket AND Nest=@nest AND Restaurant=@Rest ";
            using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
            {
                command.Parameters.AddWithValue("@Ticket", _ticket);
                command.Parameters.AddWithValue("@nest", _nest);
                command.Parameters.AddWithValue("@Rest", _restaurant);
                command.ExecuteNonQuery();
            }
            connection.Close();

        }
    }
}
