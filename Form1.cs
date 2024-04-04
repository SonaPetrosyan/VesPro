using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {


        private int _ooperator;  //_ooperator-ը աշխատողի Id-ն է
        private int _holl;  //_holl-ը սրահի համարն է
        private int _restaurant;  //_restaurant-ը ռեստորանի համարն է
        private int _editor; // եթե _edit == 0 , ապա խմբագրելն արգելված է
        private int _orderer; // եթե _orderer == 1 , ապա պատվերի դաշտ կարող է մտնել
        private int _previous; // եթե _previous == 1 , ապա նախնական պատվերի դաշտ կարող է մտնել
        private int _observer; // եթե _observer == 0 , բացի պատվերից և նախնականից մնացած տեղերը արգելված են
        private int _workplace;//աշխատատեղ։ տպիչները որոշելու համար է

        private SQLDatabaseHelper dbHelper;

        private DataTable Table_215 = new DataTable();

        private DataTable Table_211 = new DataTable();

        private DataTable Table_Composition = new DataTable();

        private DataTable Table_Composite = new DataTable();

        private DataTable Table_Seans = new DataTable();

        private DataTable Օpening = new DataTable();// Table_215-ի բաղադրորթյուններն են կիսապատռասորաստուկները բացված

        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();
        public Form1(int opperator, int holl, int restaurant, int editor, int orderer, int previous, int observer, int workplace)
        {

            InitializeComponent();
            _ooperator = opperator;
            _holl = holl;
            _restaurant = restaurant;
            _editor = editor;
            _orderer = orderer;
            _previous = previous;
            _observer = observer;
            _workplace = workplace;
            string connectionString = Properties.Settings.Default.CafeRestDB; //  Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            Load();

        }


        private void Load()
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            string query1 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query1);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = row["Name_1"].ToString();
            }
            string query2 = $"SELECT * FROM SeansState WHERE Id='{_restaurant}' ";
            Table_Seans = dbHelper.ExecuteQuery(query2);
            foreach(DataRow row in Table_Seans.Rows)
            {
                if (decimal.Parse(row["state"].ToString()) == 0)
                {
                    string UpdateQuery = $"Update SeansState set Seans=Seans+1,state=1 where Id='{_restaurant}' ";
                    using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                        updatCommand.ExecuteNonQuery();
                }
            }
        }


        private void main11_Click(object sender, EventArgs e)
        {
            if (_orderer == 0 || _previous == 1) return;
            order orderInstance = new order(_ooperator, _holl, _restaurant, _editor, 0, _workplace);
            orderInstance.Show();
        }

        private void main45_Click(object sender, EventArgs e)
        {
            users user = new users(_restaurant, _editor);
            user.Show();
        }


        private void Updater_215_Click(object sender, EventArgs e)
        {
            string connectionString2 = Properties.Settings.Default.CafeRestDB;
            string jsonFilePath1 = "d:\\hayrik\\programmer\\json\\json_215.json";
            // Call the static method from another class
            SQLUpdater.SQLFromJson(connectionString2, jsonFilePath1, "215", _restaurant);
        }

        private void update_211_Click(object sender, EventArgs e)
        {
            string connectionString2 = Properties.Settings.Default.CafeRestDB;
            string jsonFilePath1 = "d:\\hayrik\\programmer\\json\\json_211.json";
            // Call the static method from another class
            SQLUpdater.SQLFromJson(connectionString2, jsonFilePath1, "211", _restaurant);

        }

        private void update213_Click(object sender, EventArgs e)
        {

            string connectionString2 = Properties.Settings.Default.CafeRestDB;
            string jsonFilePath1 = "d:\\hayrik\\programmer\\json\\json_213.json";
            // Call the static method from another class
            SQLUpdater.SQLFromJson(connectionString2, jsonFilePath1, "213", _restaurant);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            string connectionString2 = Properties.Settings.Default.CafeRestDB;
            string jsonFilePath1 = "d:\\hayrik\\programmer\\json\\json_111.json";
            // Call the static method from another class
            SQLUpdater.SQLFromJson(connectionString2, jsonFilePath1, "111", _restaurant);

        }
        private void group_Click(object sender, EventArgs e)
        {
            string connectionString2 = Properties.Settings.Default.CafeRestDB;
            string jsonFilePath1 = "d:\\hayrik\\programmer\\json\\group.json";
            // Call the static method from another class
            SQLUpdater.SQLFromJson(connectionString2, jsonFilePath1, "group", _restaurant);

        }
        private void button14_Click(object sender, EventArgs e)
        {
            string connectionString2 = Properties.Settings.Default.CafeRestDB;
            string jsonFilePath1 = "d:\\hayrik\\programmer\\json\\addition_groups.json";
            // Call the static method from another class
            SQLUpdater.SQLFromJson(connectionString2, jsonFilePath1, "addition", _restaurant);
        }
        private void main21_Click(object sender, EventArgs e)
        {
            Foods FoodsInstance = new Foods(_restaurant, _editor);
            FoodsInstance.Show();
        }

        private void main22_Click(object sender, EventArgs e)
        {
            Materials MaterialsInstance = new Materials(_restaurant, _editor);
            MaterialsInstance.Show();

        }

        private void main12_Click(object sender, EventArgs e)
        {
            if (_observer == 0 || _editor == 0) return;
            Purchase PurchaseInstance = new Purchase(_ooperator, _restaurant, _editor);
            PurchaseInstance.Show();
        }

        private void main23_Click(object sender, EventArgs e)
        {

        }



        private void main42_Click(object sender, EventArgs e)
        {
            Nest NestInstance = new Nest(_restaurant);
            NestInstance.Show();
        }

        private void main43_Click(object sender, EventArgs e)
        {
            FoodsGroup FoodsGroup = new FoodsGroup(_editor, _restaurant);
            FoodsGroup.Show();
        }

        private void main44_Click(object sender, EventArgs e)
        {
            Additions Additions = new Additions(_restaurant, _editor);
            Additions.Show();
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
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
            richTextBox1.Height = label8.Height+32;
        }

        private void main13_Click(object sender, EventArgs e)
        {
            if (_observer == 0) { return; }
            Inventory InventoryInstance = new Inventory(_ooperator, _restaurant, 0, _editor);
            InventoryInstance.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Call the static method from another class
            UpdateComposits();

            // Inventory InventoryInstance = new Inventory(_ooperator, _restaurant, 1);
            // InventoryInstance.Show();
        }

        private void main31_Click(object sender, EventArgs e)
        {
            GoodsMovement GoodsMovementInstance = new GoodsMovement(_restaurant);
            GoodsMovementInstance.Show();
        }

        private void main41_Click(object sender, EventArgs e)
        {
            Workplace WorkplaceInstance = new Workplace(_restaurant);
            WorkplaceInstance.Show();
        }

        private void main23_Click_1(object sender, EventArgs e)
        {
            Standart StandartInstance = new Standart(_restaurant, _editor);
            StandartInstance.Show();
        }

        private void UpdateComposits()
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            string query1 = $"SELECT * FROM table_211 WHERE Restaurant = '{_restaurant}'";
            Table_211 = dbHelper.ExecuteQuery(query1);

            string query2 = $"SELECT * FROM composition WHERE Restaurant = '{_restaurant}'";
            Table_Composition = dbHelper.ExecuteQuery(query2);

            string query3 = $"DELETE FROM composite WHERE Restaurant = '{_restaurant}'";
            Table_Composite = dbHelper.ExecuteQuery(query3);

            string query4 = $"SELECT * FROM table_215  WHERE Restaurant = '{_restaurant}'";
            Table_215 = dbHelper.ExecuteQuery(query4);

            DataTable Opened = new DataTable();
            DataTable Temp = new DataTable();
            DataTable Temp1 = new DataTable();
            Opened = Table_Composition.Clone();
            Temp = Table_Composition.Clone();
            Temp1 = Table_Composition.Clone();
            string code_215 = "";
            string code_211 = "";
            foreach (DataRow row in Table_Composition.Rows) // copies Table_Composition to Opened
            {

                DataRow newRow = Opened.NewRow();
                Opened.Rows.Add(newRow);
                for (int colIndex = 0; colIndex < Table_Composition.Columns.Count; colIndex++)
                {
                    string columnName = Table_Composition.Columns[colIndex].ColumnName;
                    newRow[columnName] = row[columnName];
                }
            }

            Opened.Columns.Add("Deleted", typeof(string));
            ReplaceFields.Replace(Opened, "Deleted", "0");
            bool T = true;
            int count = Opened.Rows.Count;
            string code = "";
            string code1 = "";
            int n = 0;
            while (T == true)

            {
                n = n + 1;
                count = Opened.Rows.Count;
                foreach (DataRow row in Opened.Rows)
                {
                    code1 = row["Code_211"].ToString().Substring(0, 3);
                    if (code1 == "215" && row["Deleted"].ToString() != "1")
                    {
                        row["Deleted"] = "1";
                        code_215 = row["Code_215"].ToString();
                        code_211 = row["Code_211"].ToString();
                        float quantity = float.Parse(row["Quantity"].ToString());
                        string query = $"SELECT * FROM composition WHERE Code_215= '{code_211}' AND Restaurant = '{_restaurant}' ";
                        Temp = dbHelper.ExecuteQuery(query);
                        foreach (DataRow row1 in Temp.Rows)
                        {
                            row1["Code_215"] = code_215;
                            row1["Quantity"] = float.Parse(row1["Quantity"].ToString()) * quantity;
                            DataRow newRow = Temp1.NewRow();
                            Temp1.Rows.Add(newRow);
                            for (int colIndex = 0; colIndex < Temp.Columns.Count; colIndex++)
                            {
                                string columnName = Temp.Columns[colIndex].ColumnName;
                                newRow[columnName] = row1[columnName];
                            }
                        }
                    }
                }
                int co1 = Temp1.Rows.Count;
                int co0 = Opened.Rows.Count;
                foreach (DataRow row2 in Temp1.Rows)
                {
                    code_215 = row2["Code_215"].ToString();
                    code_211 = row2["Code_211"].ToString();
                    // DataRow[] foundRows1 = Opened.Select($"Code_215 = '{code_215}' and Code_211 = '{code_211}' ");
                    DataRow newRow = Opened.NewRow();
                    Opened.Rows.Add(newRow);
                    for (int colIndex = 0; colIndex < Temp.Columns.Count; colIndex++)
                    {
                        string columnName = Temp.Columns[colIndex].ColumnName;
                        newRow[columnName] = row2[columnName];
                    }
                    int co2 = Opened.Rows.Count;

                }

                Temp1 = new DataTable();
                Temp1 = Table_Composition.Clone();
                co1 = Temp1.Rows.Count;
                if (Opened.Rows.Count == count)
                {
                    T = false;
                    foreach (DataRow row in Opened.Select("Deleted = '1'"))
                    {
                        row.Delete();
                    }
                    Opened.AcceptChanges();
                }
            }

            foreach (DataRow row in Opened.Rows)//տեղադրում ենք գնման գները Table_211-ից
            {
                code_211 = row["Code_211"].ToString();
                DataRow[] foundRows1 = Table_211.Select($"Code = '{code_211}' ");
                foreach (DataRow row1 in foundRows1)
                {
                    row["CostPrice"] = float.Parse(row1["CostPrice"].ToString());
                }
                string pr = row["CostPrice"].ToString();
            }
            foreach (DataRow row2 in Table_Composition.Rows)//հաշվարկում ենք Table_Composition գնման գները Opened-ից
            {
                code_215 = row2["Code_215"].ToString();
                code_211 = row2["Code_211"].ToString();
                if (code_211.Substring(0, 3) == "211")
                {
                    DataRow[] foundRows1 = Table_211.Select($"Code = '{code_211}' ");
                    foreach (DataRow row1 in foundRows1)
                    {
                        if (row2["CostPrice"] != null && row1["CostPrice"] != null) row2["CostPrice"] = float.Parse(row1["CostPrice"].ToString());
                    }
                }
                else
                {
                    DataRow[] foundRows1 = Opened.Select($"Code_215 = '{code_211}' ");
                    float sum = 0;
                    foreach (DataRow row1 in foundRows1)
                    {
                        if (row1["CostPrice"] != DBNull.Value && row1["Quantity"] != DBNull.Value)
                        {
                            float costPrice;
                            float quantity;
                            if (float.TryParse(row1["CostPrice"].ToString(), out costPrice) && float.TryParse(row1["Quantity"].ToString(), out quantity))
                            {
                                sum += costPrice * quantity;
                            }
                        }
                    }
                    row2["CostPrice"] = sum;
                }
            }

            int i = 0;
            foreach (DataRow row in Opened.Rows)
            {
                i = i + 1;
                string query10 = $"SELECT * FROM composite WHERE Code_215 = '{row["Code_215"]}' AND Code_211 = '{row["Code_211"]}' AND Restaurant = '{_restaurant}' ";
                Temp = dbHelper.ExecuteQuery(query10);
                count = Temp.Rows.Count;


                if (count > 0)
                {
                    string UpdateQuery = $"UPDATE composite SET Quantity = @Quantity+Quantity,CostPrice=@CostPrice" +
                        $" WHERE Code_215 = @Code_215 AND Code_211=@Code_211 AND Restaurant = '{_restaurant}'  ";
                    using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        command.Parameters.AddWithValue("@CostPrice", row["CostPrice"]);
                        command.Parameters.AddWithValue("@Code_215", row["Code_215"]);
                        command.Parameters.AddWithValue("@Code_211", row["Code_211"]);
                        command.ExecuteNonQuery();
                    }


                    string query = $"UPDATE composite SET Quantity = @Quantity+ Quantity, CostPrice = @CostPrice" +
                        $" WHERE Code_215 = @Code_215 AND Code_211 = @Code_211 AND Restaurant = '{_restaurant}'";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        command.Parameters.AddWithValue("@CostPrice", row["CostPrice"]);
                        command.Parameters.AddWithValue("@Code_215", row["Code_215"]);
                        command.Parameters.AddWithValue("@Code_211", row["Code_211"]);
                        command.ExecuteNonQuery();
                    }


                }
                else
                {
                    //if (connection.State != ConnectionState.Open) { connection.Open(); }
                    string InsertQuery = $"INSERT INTO composite (Code_215, Code_211, Coefficient, Quantity, CostPrice, Bruto, Neto, Restaurant) " +
                           $"VALUES (@Code_215, @Code_211, @Coefficient, @Quantity, @CostPrice, @Bruto, @Neto, @Restaurant)";
                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Code_215", row["Code_215"]);
                        command.Parameters.AddWithValue("@Code_211", row["Code_211"]);
                        command.Parameters.AddWithValue("@Coefficient", row["Coefficient"]);
                        command.Parameters.AddWithValue("@CostPrice", row["CostPrice"]);
                        command.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                        command.Parameters.AddWithValue("@Bruto", row["Bruto"]);
                        command.Parameters.AddWithValue("@Neto", row["Neto"]);
                        command.Parameters.AddWithValue("@Restaurant", _restaurant);
                        command.ExecuteNonQuery();
                    }


                }
                //connection.Close();
            }
            string query0 = $"SELECT * FROM composite WHERE Restaurant = '{_restaurant}' ";
            Temp = dbHelper.ExecuteQuery(query0);

            foreach (DataRow row2 in Temp.Rows)//հաշվարկում ենք Table_215 գնման գները Opened-ից
            {
                code_215 = row2["Code_215"].ToString();

                DataRow[] foundRows1 = Temp.Select($"Code_215 = '{code_215}' ");
                float sum = 0;
                foreach (DataRow row1 in foundRows1)
                {
                    if (row1["CostPrice"] != DBNull.Value && row1["Quantity"] != DBNull.Value)
                    {
                        float costPrice;
                        float quantity;
                        if (float.TryParse(row1["CostPrice"].ToString(), out costPrice) && float.TryParse(row1["Quantity"].ToString(), out quantity))
                        {
                            sum += costPrice * quantity;
                        }
                    }
                }
                string query = $"UPDATE Table_215 SET CostPrice = @CostPrice WHERE Code = '{code_215}' AND Restaurant = '{_restaurant}' ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CostPrice", sum);
                    command.ExecuteNonQuery();
                }
            }

        }

        private void main32_Click(object sender, EventArgs e)
        {
            Stocktaking StocktakingInstance = new Stocktaking(_restaurant, _editor);
            StocktakingInstance.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void main14_Click(object sender, EventArgs e)
        {
            if (_previous == 0) return;
            order orderInstance = new order(_ooperator, _holl, _restaurant, _editor, _previous, _workplace);
            orderInstance.Show();
        }

        private void main24_Click(object sender, EventArgs e)
        {
            Partners partnersInstance = new Partners(_restaurant, _editor);
            partnersInstance.Show();
        }

        private void main15_Click(object sender, EventArgs e)
        {
            Observation observationInstance = new Observation(_restaurant, _editor);
            observationInstance.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";
                richTextBox1.Height = this.Height - 50;
                richTextBox1.ReadOnly = true;

                string filePath = "D:\\hayrik\\sql\\help\\menu.txt";
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
