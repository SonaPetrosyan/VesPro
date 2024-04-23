using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.ReportingServices.Diagnostics.Internal;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        private string _ooperatorname;
        private int _ooperator;  //_ooperator-ը աշխատողի Id-ն է
        private int _holl;  //_holl-ը սրահի համարն է
        private int _restaurant;  //_restaurant-ը ռեստորանի համարն է
        private int _manager; // եթե _manager == 1 , ապա կարող է խմբագրել ամենուրեք
        private int _editor; // եթե _edit == 0 , ապա խմբագրելն արգելված է
        private int _orderer; // եթե _orderer == 1 , ապա պատվերի դաշտ կարող է մտնել
        private int _previous; // եթե _previous == 1 , ապա նախնական պատվերի դաշտ կարող է մտնել
        private int _observer; // եթե _observer == 0 , բացի պատվերից և նախնականից մնացած տեղերը արգելված են
        private int _workplace;//աշխատատեղ։ տպիչները որոշելու համար է
        private string _language;//աշխատանքային լեզուն է։ որոշվում է user-ի ընտրած լեզվով


        private SQLDatabaseHelper dbHelper;

        private DataTable Table_215 = new DataTable();

        private DataTable Table_211 = new DataTable();

        private DataTable Table_Composition = new DataTable();

        private DataTable Table_Composite = new DataTable();

        private DataTable Table_Languages = new DataTable();

        private DataTable Table_Seans = new DataTable();

        private DataTable Օpening = new DataTable();// Table_215-ի բաղադրորթյուններն են կիսապատռասորաստուկները բացված

        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();
        public Form1(string opperatorname, int opperator, int holl, int restaurant,int manager,
            int editor, int orderer, int previous, int observer, int workplace, string language)
        {

            InitializeComponent();
            _ooperatorname = opperatorname;
            _ooperator = opperator;
            _holl = holl;
            _restaurant = restaurant;
            _manager = manager;
            _editor = editor;
            _orderer = orderer;
            _previous = previous;
            _observer = observer;
            _workplace = workplace;
            _language = language;
            string connectionString = Properties.Settings.Default.CafeRestDB; //  Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);
            Load();
            SetLanguage(_language);
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
                this.Text = row["Name"].ToString();
            }
            string query2 = $"SELECT * FROM SeansState WHERE Id='{_restaurant}' ";
            Table_Seans = dbHelper.ExecuteQuery(query2);
            foreach (DataRow row in Table_Seans.Rows)
            {
                if (decimal.Parse(row["state"].ToString()) == 0)
                {
                    string UpdateQuery = $"Update SeansState set Seans=Seans+1,state=1 where Id='{_restaurant}' ";
                    using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                        updatCommand.ExecuteNonQuery();
                }
            }
            string query3 = $"SELECT * FROM Languages";
            Table_Languages = dbHelper.ExecuteQuery(query3);
            string r = "";
            int i=1 ;
            foreach(DataRow row in Table_Languages.Rows)
            {
           
                 object value = Table_Languages.Rows[i-1]["Language"];
                string lang = value.ToString();
                r = lang;
                if (i == 1) radioButton1.Text = lang;
                if (i == 2) radioButton2.Text = lang;
                if (i == 3) radioButton3.Text = lang;
                if (i == 4) radioButton4.Text = lang;
                if (i == 5) radioButton5.Text = lang;
                i = i + 1;
            }

        }


        private void main11_Click(object sender, EventArgs e)
        {
            if (_orderer == 0) return;
            order orderInstance = new order(_ooperatorname, _ooperator, _holl, _restaurant, _editor, 0, _workplace, _language);
            orderInstance.Show();
        }

        private void main45_Click(object sender, EventArgs e)
        {
            if(_manager == 0) return;
            users user = new users(_restaurant, _manager, _language);
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
            if (_manager == 1) _editor = 1;
            Foods FoodsInstance = new Foods(_restaurant, _editor,_language);
            FoodsInstance.Show();
        }

        private void main22_Click(object sender, EventArgs e)
        {
            if (_manager == 1) _editor = 1;
            Materials MaterialsInstance = new Materials(_restaurant, _editor,_language);
            MaterialsInstance.Show();

        }

        private void main12_Click(object sender, EventArgs e)
        {
            if (_manager == 1) _editor = 1;
            if (_observer == 0 || _editor == 0) return;
            Purchase PurchaseInstance = new Purchase(_ooperator, _restaurant, _editor, _language);
            PurchaseInstance.Show();
        }

        private void main23_Click(object sender, EventArgs e)
        {

        }



        private void main42_Click(object sender, EventArgs e)
        {
            if (_manager == 1) _editor = 1;
            Nest NestInstance = new Nest(_restaurant,_language, _editor);
            NestInstance.Show();
        }

        private void main43_Click(object sender, EventArgs e)
        {
            if (_manager == 1) _editor = 1;
            FoodsGroup FoodsGroup = new FoodsGroup(_editor, _restaurant, _language);
            FoodsGroup.Show();
        }

        private void main44_Click(object sender, EventArgs e)
        {
            if (_manager == 1) _editor = 1;
            Additions Additions = new Additions(_restaurant, _editor, _language);
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
            richTextBox1.Height = label8.Height + 32;
        }

        private void main13_Click(object sender, EventArgs e)
        {
            if (_manager == 1) _editor = 1;
            Inventory InventoryInstance = new Inventory(_ooperator, _restaurant, 0, _editor, _language);
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
            GoodsMovement GoodsMovementInstance = new GoodsMovement(_restaurant,_language);
            GoodsMovementInstance.Show();
        }

        private void main41_Click(object sender, EventArgs e)
        {
            if (_manager == 1) _editor = 1;
            Workplace WorkplaceInstance = new Workplace(_restaurant, _editor, _holl, _language);
            WorkplaceInstance.Show();
        }

        private void main23_Click_1(object sender, EventArgs e)
        {
            if (_manager == 1) _editor = 1;
            Standart StandartInstance = new Standart(_restaurant, _editor, _language);
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
            Stocktaking StocktakingInstance = new Stocktaking(_restaurant, _editor, _language);
            StocktakingInstance.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void main14_Click(object sender, EventArgs e)
        {
            if (_previous == 0) return;
            order orderInstance = new order(_ooperatorname, _ooperator, _holl, _restaurant, _editor, _previous, _workplace,_language);
            orderInstance.Show();
        }

        private void main24_Click(object sender, EventArgs e)
        {
            Partners partnersInstance = new Partners(_restaurant, _editor, _language);
            partnersInstance.Show();
        }

        private void main15_Click(object sender, EventArgs e)
        {
            Observation observationInstance = new Observation(_restaurant, _editor, _language);
            observationInstance.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string help = FindFolder.Folder("Help");
            string filePath = "";
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";
                richTextBox1.Height = this.Height - 50;
                richTextBox1.Left = HelpButton.Width + 5;
                richTextBox1.Width = this.Width / 2;
                richTextBox1.ReadOnly = true;

                filePath = help + "\\Form1_" + _language + ".txt";
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



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            object value = Table_Languages.Rows[0]["Language"];
            string lang = value.ToString();
            ChangeLanguage(lang);
            button2.Text = lang;
            panel1.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            object value = Table_Languages.Rows[1]["Language"];
            string lang = value.ToString();
            ChangeLanguage(lang);
            button2.Text = lang;
            panel1.Visible = false;
        }
        //aaaa
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            object value = Table_Languages.Rows[2]["Language"];
            string lang = value.ToString();
            ChangeLanguage(lang);
            button2.Text = lang;
            panel1.Visible = false;
        }
        //aaa
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        { 
            object value = Table_Languages.Rows[3]["Language"];
            string lang = value.ToString();
            ChangeLanguage(lang);
            button2.Text = lang;
            panel1.Visible = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            object value = Table_Languages.Rows[4]["Language"];
            string lang = value.ToString();
            ChangeLanguage(lang);
            button2.Text = lang;
            panel1.Visible = false;
        }
        private void ChangeLanguage(string lang)
        {
            _language = lang;
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            string query = $"UPDATE Users SET Language = @Language WHERE Id = '{_ooperator}' AND Restaurant = '{_restaurant}' ";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Language", lang);
                command.ExecuteNonQuery();
            }
            connection.Close();
            SetLanguage(lang);

        }
        private void SetLanguage(string lang)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            DataTable ControlsForm1 = new DataTable();
            string query1 = $"SELECT * FROM ControlsForm1  ";
            ControlsForm1 = dbHelper.ExecuteQuery(query1);
            foreach (Control control in this.Controls)
            {
                DataRow[] foundRows = ControlsForm1.Select($"Name = '{control.Name}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            connection.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void main46_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
               //DataTable trans = new DataTable();
               //string query0 = $"SELECT trim(armenian) FROM Table_211 WHERE Restaurant = '{_restaurant}' ";
               //trans = dbHelper.ExecuteQuery(query0);
               //string filePath= "d:\\hayrik\\sql\\tanslation\\armenian_211.txt";
               //Translation.ExportDataTableToCsv(trans, filePath, ";");

            //DataTable german_211 = new DataTable();
            //german_211.Columns.Add("German", typeof(string));
            //string filePath1 = "d:\\hayrik\\sql\\tanslation\\german_211.txt";
            //Translation.AppendCsvToDataTable(german_211, filePath1, ";");
            //this.Text = german_211.Rows.Count.ToString();
            //int i = 1;
            //foreach (DataRow row in german_211.Rows)
            //{
            //    string query = $"UPDATE Table_211 SET German = @german WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@german", row["German"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}

            //DataTable english_211 = new DataTable();
            //english_211.Columns.Add("english", typeof(string));
            //string filePath2 = "d:\\hayrik\\sql\\tanslation\\english_211.txt";
            //Translation.AppendCsvToDataTable(english_211, filePath2, ";");
            //this.Text = english_211.Rows.Count.ToString();
            //i = 1;
            //foreach (DataRow row in english_211.Rows)
            //{
            //    string query = $"UPDATE Table_211 SET english = @english WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@english", row["english"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}

            //DataTable espaniol_211 = new DataTable();
            //espaniol_211.Columns.Add("espaniol", typeof(string));
            //string filePath3 = "d:\\hayrik\\sql\\tanslation\\espaniol_211.txt";
            //Translation.AppendCsvToDataTable(espaniol_211, filePath3, ";");
            //this.Text = espaniol_211.Rows.Count.ToString();
            //i = 1;
            //foreach (DataRow row in espaniol_211.Rows)
            //{
            //    string query = $"UPDATE Table_211 SET espaniol = @espaniol WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@espaniol", row["espaniol"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}

            //DataTable russian_211 = new DataTable();
            //russian_211.Columns.Add("russian", typeof(string));
            //string filePath4 = "d:\\hayrik\\sql\\tanslation\\russian_211.txt";
            //Translation.AppendCsvToDataTable(russian_211, filePath4, ";");
            //this.Text = russian_211.Rows.Count.ToString();
            //i = 1;
            //foreach (DataRow row in russian_211.Rows)
            //{
            //    string query = $"UPDATE Table_211 SET russian = @russian WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@russian", row["russian"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}

            //   DataTable trans = new DataTable();
            //   string query0 = $"SELECT armenian FROM Table_215 WHERE Restaurant = '{_restaurant}' ";
            //   trans = dbHelper.ExecuteQuery(query0);
            //   string filePath= "d:\\hayrik\\sql\\tanslation\\armenian_215.txt";
            //   Translation.ExportDataTableToCsv(trans, filePath, ";");
            
            //DataTable german_215 = new DataTable();
            //german_215.Columns.Add("German", typeof(string));
            //string filePath1 = "d:\\hayrik\\sql\\tanslation\\german_215.txt";
            //Translation.AppendCsvToDataTable(german_215, filePath1, ";");
            //int i = 1;
            //foreach (DataRow row in german_215.Rows)
            //{
            //    string query = $"UPDATE Table_215 SET German = @german WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@german", row["German"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}
            //DataTable Espaniol_215 = new DataTable();
            //Espaniol_215.Columns.Add("Espaniol", typeof(string));
            //string filePath2 = "d:\\hayrik\\sql\\tanslation\\Espaniol_215.txt";
            //Translation.AppendCsvToDataTable(Espaniol_215, filePath2, ";");
            //this.Text = Espaniol_215.Rows.Count.ToString();
            //i = 1;
            //foreach (DataRow row in Espaniol_215.Rows)
            //{
            //    string query = $"UPDATE Table_215 SET Espaniol = @Espaniol WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@Espaniol", row["Espaniol"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}

            //DataTable English_215 = new DataTable();
            //English_215.Columns.Add("English", typeof(string));
            //string filePath3 = "d:\\hayrik\\sql\\tanslation\\English_215.txt";
            //Translation.AppendCsvToDataTable(English_215, filePath3, ";");
            //this.Text = English_215.Rows.Count.ToString();
            //i = 1;
            //foreach (DataRow row in English_215.Rows)
            //{
            //    string query = $"UPDATE Table_215 SET English = @English WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@English", row["English"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}

            //DataTable Russian_215 = new DataTable();
            //Russian_215.Columns.Add("Russian", typeof(string));
            //string filePath4 = "d:\\hayrik\\sql\\tanslation\\Russian_215.txt";
            //Translation.AppendCsvToDataTable(Russian_215, filePath4, ";");
            //this.Text = Russian_215.Rows.Count.ToString();
            //i = 1;
            //foreach (DataRow row in Russian_215.Rows)
            //{
            //    string query = $"UPDATE Table_215 SET Russian = @Russian WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@Russian", row["Russian"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}

            //DataTable Foodgroup_esp = new DataTable();

            //string query0 = $"SELECT English FROM Foodgroupp WHERE Restaurant = '{_restaurant}' ";
            //Foodgroup_esp = dbHelper.ExecuteQuery(query0);

            //string filePath = "d:\\hayrik\\sql\\tanslation\\Foodgroup_esp.txt";
            //Translation.ExportDataTableToCsv(Foodgroup_esp, filePath, ";");

            //DataTable Foodgroup_germ = new DataTable();
            //Foodgroup_germ = dbHelper.ExecuteQuery(query0);
            //string filePath1 = "d:\\hayrik\\sql\\tanslation\\Foodgroup_germ.txt";
            //Translation.ExportDataTableToCsv(Foodgroup_germ, filePath1, ";");

            //DataTable AdditionNames_germ = new DataTable();
            //DataTable AdditionNames_esp = new DataTable();
            //DataTable AdditionNames_rus = new DataTable();
            //string query01 = $"SELECT English FROM AdditionNames WHERE Restaurant = '{_restaurant}' ";
            //AdditionNames_esp = dbHelper.ExecuteQuery(query01);
            //AdditionNames_germ = dbHelper.ExecuteQuery(query01);
            //AdditionNames_rus = dbHelper.ExecuteQuery(query01);

            //string filePath2 = "d:\\hayrik\\sql\\tanslation\\AdditionNames_germ.txt";
            //Translation.ExportDataTableToCsv(AdditionNames_germ, filePath2, ";");

            //string filePath3 = "d:\\hayrik\\sql\\tanslation\\AdditionNames_esp.txt";
            //Translation.ExportDataTableToCsv(AdditionNames_esp, filePath3, ";");

            //string filePath4 = "d:\\hayrik\\sql\\tanslation\\AdditionNames_rus.txt";
            //Translation.ExportDataTableToCsv(AdditionNames_rus, filePath4, ";");
            //return;
            //DataTable Foodgroup_esp = new DataTable();
            //Foodgroup_esp.Columns.Add("Espaniol", typeof(string));
            //string filePath1 = "d:\\hayrik\\sql\\tanslation\\Foodgroup_esp.txt";
            //Translation.AppendCsvToDataTable(Foodgroup_esp, filePath1, ";");
            //int i = 1;
            //foreach (DataRow row in Foodgroup_esp.Rows)
            //{
            //    string query = $"UPDATE Foodgroupp SET Espaniol = @Espaniol WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@Espaniol", row["Espaniol"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}

            ////return;
            //DataTable Foodgroup_germ = new DataTable();
            //Foodgroup_germ.Columns.Add("German", typeof(string));
            //string filePath2 = "d:\\hayrik\\sql\\tanslation\\Foodgroup_germ.txt";
            //Translation.AppendCsvToDataTable(Foodgroup_germ, filePath2, ";");
            //this.Text = Foodgroup_germ.Rows.Count.ToString();
            //i = 1;
            //foreach (DataRow row in Foodgroup_germ.Rows)
            //{
            //    string query = $"UPDATE Foodgroupp SET German = @German WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@German", row["German"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}
            ////return;

            //DataTable AdditionNames_germ = new DataTable();
            //AdditionNames_germ.Columns.Add("German", typeof(string));
            //string filePath3 = "d:\\hayrik\\sql\\tanslation\\AdditionNames_germ.txt";
            //Translation.AppendCsvToDataTable(AdditionNames_germ, filePath3, ";");
            //this.Text = AdditionNames_germ.Rows.Count.ToString();
            //i = 1;
            //foreach (DataRow row in AdditionNames_germ.Rows)
            //{
            //    string query = $"UPDATE AdditionNames SET German = @German WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@German", row["German"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}

            //DataTable AdditionNames_esp = new DataTable();
            //AdditionNames_esp.Columns.Add("Espaniol", typeof(string));
            //string filePath5 = "d:\\hayrik\\sql\\tanslation\\AdditionNames_esp.txt";
            //Translation.AppendCsvToDataTable(AdditionNames_esp, filePath5, ";");
            //this.Text = AdditionNames_esp.Rows.Count.ToString();
            //i = 1;
            //foreach (DataRow row in AdditionNames_esp.Rows)
            //{
            //    string query = $"UPDATE AdditionNames SET Espaniol = @Espaniol WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@Espaniol", row["Espaniol"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}

            //DataTable AdditionNames_rus = new DataTable();
            //AdditionNames_rus.Columns.Add("Russian", typeof(string));
            //string filePath6 = "d:\\hayrik\\sql\\tanslation\\AdditionNames_rus.txt";
            //Translation.AppendCsvToDataTable(AdditionNames_rus, filePath6, ";");
            //this.Text = AdditionNames_rus.Rows.Count.ToString();
            //i = 1;
            //foreach (DataRow row in AdditionNames_rus.Rows)
            //{
            //    string query = $"UPDATE AdditionNames SET Russian = @Russian WHERE Id = '{i}'  ";
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        command.Parameters.AddWithValue("@Russian", row["Russian"].ToString());
            //        command.ExecuteNonQuery();
            //    }
            //    i = i + 1;
            //}
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}