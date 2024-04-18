using System.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Xml.Linq;
using System.Windows.Media.Media3D;
namespace WindowsFormsApp4
{
    public partial class Materials : Form

    {
        private int _restaurant;

        private int _editor;

        private string _language;

        private SQLDatabaseHelper dbHelper;

        private DataTable Table_211 = new DataTable();

        private DataTable Table_213 = new DataTable();

        private DataTable Table_111 = new DataTable();

        private DataTable Table_215 = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private DataView dataView;
        public Materials(int restaurant, int editor, string language)
        {
            _restaurant = restaurant;
            _editor = editor;
            _language = language;

            InitializeComponent();
            //InitForm();
            string code = "կոդ", name = "անվանում", unit = "չափ", pr = "գին", gr = "խումբ";
            radioButton1.Text = "Նյութ"; radioButton2.Text = "Սպասք";
            radioButton3.Text = "Հիմնական"; radioButton4.Text = "Սնունդ";
            label2.Text = "լեզու"; label4.Text = "լեզու"; 

            if (_language == "English")
            {
                code = "Code"; name = "Name"; unit = "Unit"; pr = "last price"; gr = "Group";
                radioButton1.Text = "Material"; radioButton2.Text = "Dishes";
                radioButton3.Text = "Basic"; radioButton4.Text = "Food";
                label2.Text = "Language"; label4.Text = "Language";
            }
            if (_language == "German")
            {
                code = "Code"; name = "Name"; unit = "Einheit"; pr = "letzter Preis"; gr = "Gruppe"; 
                radioButton1.Text = "Material"; radioButton2.Text = "Gerichte";
                radioButton3.Text = "Grundlegend"; radioButton4.Text = "Essen";
                label2.Text = "Sprache"; label4.Text = "Sprache";
            }
            if (_language == "Espaniol")
            {
                code = "Código"; name = "Nombre"; unit = "Unidad"; pr = "último precio"; gr = "Grupo";
                radioButton1.Text = "Material"; radioButton2.Text = "Platos";
                radioButton3.Text = "Básico"; radioButton4.Text = "Comida";
                label2.Text = "Idioma"; label4.Text = "Idioma";
            }
            if (_language == "Russian")
            {
                code = "Код"; name = "Наименоваие"; unit = "Единица"; pr = "последняя цена"; gr = "Группа";
                radioButton1.Text = "Материал"; radioButton2.Text = "Посуда";
                radioButton3.Text = "Основные"; radioButton4.Text = "Еда";
                label2.Text = "Язык"; label4.Text = "Язык";
            }



            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            string query1 = $"SELECT Code,Armenian,English,Unit,Groupp,CostPrice,German,Espaniol,Russian FROM table_211";
            Table_211 = dbHelper.ExecuteQuery(query1);
            Table_211.Columns.Add("Changed", typeof(int));

            string query2 = $"SELECT Code,Armenian,English,Unit,Groupp,CostPrice,German,Espaniol,Russian FROM table_213  ";
            Table_213 = dbHelper.ExecuteQuery(query2);
            Table_213.Columns.Add("Changed", typeof(int));

            string query3 = $"SELECT Code,Armenian,English,Unit,Groupp,CostPrice,German,Espaniol,Russian FROM table_111  ";
            Table_111 = dbHelper.ExecuteQuery(query3);
            Table_111.Columns.Add("Changed", typeof(int));

            string query4 = $"SELECT Code,Armenian,English,Unit,Groupp,CostPrice,German,Espaniol,Russian FROM table_215  ";
            Table_215 = dbHelper.ExecuteQuery(query4);
            Table_215.Columns.Add("Changed", typeof(int));
            dataView = new DataView(Table_211);
            dataGridView1.DataSource = dataView;
            
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.DataPropertyName == "Code") column.HeaderText = code;
                if (column.DataPropertyName == "Armenian") column.HeaderText = name;
                if (column.DataPropertyName == "English") column.HeaderText = name;
                if (column.DataPropertyName == "Unit") column.HeaderText = unit;
                if (column.DataPropertyName == "Groupp") column.HeaderText = gr;
                if (column.DataPropertyName == "CostPrice") column.HeaderText = pr;
                if (column.Index > 5)
                {
                    column.Visible = false;
                }
            }

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);
            if (editor == 0)
            {
                AddButton.Enabled = false;
                SaveButton1.Enabled = false;
            }
            string query5 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query5);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = row["Name"].ToString();
            }


        }


        private void InitForm()
        //Ֆորմայի չափսերը դարձնում ենք լիաէկրան
        {
            float screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            float screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            float kw = screenWidth / this.Width;
            float kh = screenHeight / this.Height;
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
        }

        private void SearchBox2_TextChanged(object sender, EventArgs e)
        {
            String txt = SearchBox2.Text;
            if (dataGridView1.DataSource is DataView dataView1 && dataView1.Table == Table_211)
            {
                dataView = new DataView(Table_211);
            }
            if (dataGridView1.DataSource is DataView dataView2 && dataView2.Table == Table_213)
            {
                dataView = new DataView(Table_213);
            }
            if (dataGridView1.DataSource is DataView dataView3 && dataView3.Table == Table_111)
            {
                dataView = new DataView(Table_111);
            }
            if (dataGridView1.DataSource is DataView dataView4 && dataView4.Table == Table_215)
            {
                dataView = new DataView(Table_111);
            }
            dataView.RowFilter = $"(Name+Eng+Rus+Code) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }



        private void SearchBox2_Enter(object sender, EventArgs e)
        {
            SearchBox2.Text = "";
        }

        private void SearchBox1_Enter(object sender, EventArgs e)
        {
            SearchBox2.Text = "";
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (SaveButton1.Visible)
            {
                SaveButton2.Visible = true; SaveButton3.Visible = true;


            }
            else
            {
                dataView = new DataView(Table_211);
                dataGridView1.DataSource = dataView;
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (SaveButton1.Visible)
            {
                SaveButton2.Visible = true; SaveButton3.Visible = true;
            }
            else
            {
                dataView = new DataView(Table_213);
                dataGridView1.DataSource = dataView;
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (SaveButton1.Visible)
            {
                SaveButton2.Visible = true; SaveButton3.Visible = true;
            }
            else
            {
                dataView = new DataView(Table_111);
                dataGridView1.DataSource = dataView;
            }
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (SaveButton1.Visible)
            {
                SaveButton2.Visible = true; SaveButton3.Visible = true;
            }
            else
            {
                dataView = new DataView(Table_215);
                dataGridView1.DataSource = dataView;
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (dataView.Count > 0)
            {
                string maxCode = dataView.Cast<DataRowView>().Max(row => (string)row["Code"]);
                int maxcode = Convert.ToInt32(maxCode) + 1;
                maxCode = maxcode.ToString();
                if ( dataView.Table == Table_211)
                {
                    DataRow newRow = Table_211.NewRow();
                    newRow["Code"] = maxCode;
                    Table_211.Rows.Add(newRow);
                    SaveButton1.Visible = true;
                }
                if (dataView.Table == Table_213)
                {
                    DataRow newRow = Table_213.NewRow();
                    newRow["Code"] = maxCode;
                    Table_213.Rows.Add(newRow);
                    SaveButton1.Visible = true;
                }
                if (dataView.Table == Table_111)
                {
                    DataRow newRow = Table_111.NewRow();
                    newRow["Code"] = maxCode;
                    Table_111.Rows.Add(newRow);
                    SaveButton1.Visible = true;
                }
                if (dataView.Table == Table_215)
                {
                    DataRow newRow = Table_215.NewRow();
                    newRow["Code"] = maxCode;
                    Table_215.Rows.Add(newRow);
                    SaveButton1.Visible = true;
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    int lastRowIndex = dataGridView1.Rows.Count - 2;
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



        private void SaveButton1_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (dataGridView1.DataSource == Table_211)
            {

                Save.UpdateTableFromDatatable(connectionString, Table_211, "211", _restaurant);
            }
            if (dataGridView1.DataSource == Table_213)
            {
                Save.UpdateTableFromDatatable(connectionString, Table_213, "213", _restaurant);
            }
            if (dataGridView1.DataSource == Table_111)
            {
                Save.UpdateTableFromDatatable(connectionString, Table_111, "111", _restaurant);
            }
            if (dataGridView1.DataSource == Table_215)
            {
                Save.UpdateTableFromDatatable(connectionString, Table_215, "215", _restaurant);
            }
            SaveButton1.Visible = false;
        }

        private void SaveButton3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton1.PerformClick();
            }
            if (radioButton2.Checked)
            {
                radioButton2.PerformClick();
            }
            if (radioButton3.Checked)
            {
                radioButton3.PerformClick();
            }
            // dataGridView1.Visible=false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            SaveButton1.Visible = false;
            SaveButton2.Visible = false;
            SaveButton3.Visible = false;
        }

        private void Materials_Resize(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.Width = this.ClientSize.Width - 50;
                control.Height = this.ClientSize.Height - 50;
            }
            // Adjust the size of a TextBox based on the new size of the form
            //textBox1.Width = this.ClientSize.Width - 50;
        }

        private void Materials_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }

        }

        private void Materials_ResizeEnd(object sender, EventArgs e)
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
            foreach (Control control in panel2.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                if (dataGridView1.Columns[colIndex].DataPropertyName == "Armenian" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "English" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "German" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "Espaniol" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "Russian")
                {
                    dataGridView1.Columns[colIndex].DataPropertyName = comboBox1.SelectedItem.ToString();
                    break;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count - 1; colIndex++)
            {
                if (dataGridView1.Columns[colIndex].DataPropertyName == "Armenian" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "English" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "German" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "Espaniol" ||
                    dataGridView1.Columns[colIndex].DataPropertyName == "Russian")
                {
                    dataGridView1.Columns[colIndex+1].DataPropertyName = comboBox2.SelectedItem.ToString();
                    break;
                }
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                dataGridView.Rows[e.RowIndex].Cells["Changed"].Value = 1;
                SaveButton1.Visible = true;
            }
            SaveButton1.BackColor = Color.LightGreen;
            SaveButton1.Visible = true;
        }

        private void radioButton4_Click_1(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (SaveButton1.Visible)
            {
                SaveButton2.Visible = true; SaveButton3.Visible = true;


            }
            else
            {
                dataGridView1.DataSource = Table_215;
            }
        }
    }
}
