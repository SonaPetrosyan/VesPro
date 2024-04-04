using System.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
namespace WindowsFormsApp4
{
    public partial class Materials : Form

    {
        private int _restaurant;

        private int _editor;

        private SQLDatabaseHelper dbHelper;

        private DataTable Table_211 = new DataTable();

        private DataTable Table_213 = new DataTable();

        private DataTable Table_111 = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();
        
        private DataView dataView;
        public Materials(int restaurant,int editor)
        {
            _restaurant = restaurant;
            _editor = editor;
            InitializeComponent();
            //InitForm();

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            string query1 = $"SELECT * FROM table_211";
            Table_211 = dbHelper.ExecuteQuery(query1);
            Table_211.Columns.Add("Changed", typeof(int));

            string query2 = $"SELECT * FROM table_213  ";
            Table_213 = dbHelper.ExecuteQuery(query2);
            Table_213.Columns.Add("Changed", typeof(int));

            string query3 = $"SELECT * FROM table_111  ";
            Table_111 = dbHelper.ExecuteQuery(query3);
            Table_111.Columns.Add("Changed", typeof(int));

            dataGridView1.DataSource = Table_211;
            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name_1";
            dataGridView1.Columns[2].DataPropertyName = "Name_2";
            dataGridView1.Columns[3].DataPropertyName = "Name_3";
            dataGridView1.Columns[4].DataPropertyName = "Unit";
            dataGridView1.Columns[5].DataPropertyName = "Group";
            dataGridView1.Columns[6].DataPropertyName = "CostPrice";
            dataView = new DataView(Table_211);
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index > 6)
                {
                    column.Visible = false;
                }
            }

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0,0,0,0);
            if (editor == 0)
            {
                AddButton.Enabled = false;
                SaveButton1.Enabled = false;
            }
            string query4 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query4);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = row["Name_1"].ToString();
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
            dataView.RowFilter = $"(Name_1+Name_2+Name_3+Code) LIKE '%{txt}%'";
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
                string query1 = $"SELECT * FROM table_211 ";
                Table_211 = dbHelper.ExecuteQuery(query1);
                Table_211.Columns.Add("Changed", typeof(int));// DB - ում ֆայլը խմբագրելու համար է
                dataView = new DataView(Table_211);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataView;
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[5].Visible = true;
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
                string query1 = $"SELECT * FROM table_213 ";

                Table_213 = dbHelper.ExecuteQuery(query1);

                Table_213.Columns.Add("Changed", typeof(int));// DB - ում ֆայլը խմբագրելու համար է
                dataView = new DataView(Table_213);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataView;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
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
                string query1 = $"SELECT * FROM table_111 ";
                Table_111 = dbHelper.ExecuteQuery(query1);
                Table_111.Columns.Add("Changed", typeof(int));// DB - ում ֆայլը խմբագրելու համար է
                dataView = new DataView(Table_111);
                dataGridView1.Visible = true;
                dataGridView1.DataSource = dataView;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (dataView.Count > 0)
            {
                string maxCode = dataView.Cast<DataRowView>().Max(row => (string)row["Code"]);
                int maxcode = Convert.ToInt32(maxCode) + 1;
                maxCode = maxcode.ToString();
                if (dataGridView1.DataSource is DataView dataView1 && dataView1.Table == Table_211)
                {
                    DataRow newRow = Table_211.NewRow();
                    newRow["Code"] = maxCode;
                    Table_211.Rows.Add(newRow);
                }
                if (dataGridView1.DataSource is DataView dataView2 && dataView2.Table == Table_213)
                {
                    DataRow newRow = Table_213.NewRow();
                    newRow["Code"] = maxCode;
                    Table_213.Rows.Add(newRow);
                }
                if (dataGridView1.DataSource is DataView dataView3 && dataView3.Table == Table_111)
                {
                    DataRow newRow = Table_111.NewRow();
                    newRow["Code"] = maxCode;
                    Table_111.Rows.Add(newRow);
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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

        private void SaveButton1_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            if (dataGridView1.DataSource== Table_211)
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
            SaveButton1.Visible=false;
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
            dataGridView1.Visible=false;
            radioButton1.Checked=false;
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
                control.Width = this.ClientSize.Width-50; 
                control.Height = this.ClientSize.Height-50;
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
                control.Height =(int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
        }


    }
}
