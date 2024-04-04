
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace WindowsFormsApp4
{
    public partial class Additions : Form
    {
        private int _editor;

        private int _restaurant;

        private SQLDatabaseHelper dbHelper;

        private DataTable Tablte_Names = new DataTable();

        private DataTable Table_Groups = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable Exist = new DataTable(); 

        private DataTable Table_Rest = new DataTable(); 

        private DataView dataView;
        public Additions(int restaurant, int editor)
        {
            _editor = editor;
            _restaurant = restaurant;
            InitializeComponent();
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            string query1 = $"SELECT Id,Name_1,Name_2,Name_3,Number FROM AdditionNames ";
            Tablte_Names = dbHelper.ExecuteQuery(query1);
            dataGridView1.DataSource = Tablte_Names;
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].DataPropertyName = "Name_1";
            dataGridView1.Columns[2].DataPropertyName = "Name_2";
            dataGridView1.Columns[3].DataPropertyName = "Name_3";
            dataGridView1.Columns[4].DataPropertyName = "Number";
            dataGridView1.DataSource = Tablte_Names;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 4)
                {
                    column.Visible = false;
                }
            }

            string query2 = $"SELECT Id,Name_1,Name_2,Name_3 FROM AdditionGroups ";
            Table_Groups = dbHelper.ExecuteQuery(query2);
            dataGridView2.DataSource = Table_Groups;
            dataGridView2.Columns[0].DataPropertyName = "Id";
            dataGridView2.Columns[1].DataPropertyName = "Name_1";
            dataGridView2.Columns[2].DataPropertyName = "Name_2";
            dataGridView2.Columns[3].DataPropertyName = "Name_3";
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Index > 3)
                {
                    column.Visible = false;
                }
            }

            string query3 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query3);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = row["Name_1"].ToString();
            }

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            label2.Text = "";
            label3.Text = "";

            if (_editor == 0)
            {
                Savebutton1.Enabled = false;
                Savebutton2.Enabled = false;
            }
        }

        private void Additions_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void Additions_ResizeEnd(object sender, EventArgs e)
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

            foreach (Control control in panel1.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }

        }

        private void AddButton2_Click(object sender, EventArgs e)
        {
            Savebutton2.Visible = true;
            int id = 0;

            foreach (DataRow row in Table_Groups.Rows)
            {
                id = int.Parse(row["Id"].ToString());
                if (int.Parse(row["Id"].ToString()) > id) { id++; }
            }
            DataRow newRow = Table_Groups.NewRow();
            newRow["Id"] = id + 1;
            Table_Groups.Rows.Add(newRow);
            int lastRowIndex = Table_Groups.Rows.Count - 1;
            dataGridView2.CurrentCell = dataGridView2.Rows[lastRowIndex].Cells[0];
            dataGridView2.BeginEdit(true);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            label2.Text = dataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            label2.Tag = e.RowIndex.ToString();
            button1.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            label3.Text = dataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            label3.Tag = e.RowIndex.ToString();
            button1.Enabled = true;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton1.Visible = true;
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton2.Visible = true;
        }
        private void Savebutton1_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {

                    Exist = new DataTable();
                    int id = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    string name1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    string name2 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    string name3 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    int number = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    string query = $"SELECT * FROM AdditionNames WHERE Id = '{id}' ";
                    Exist = dbHelper.ExecuteQuery(query);
                    int count = Exist.Rows.Count;
                    if (count > 0)
                    {
                        string UpdateQuery = $"UPDATE AdditionNames  SET Name_1= @Name_1,Name_2= @Name_2,Name_3= @Name_3,Number= @Number,Restaurant= @Restaurant WHERE Id= '{id}'";
                        using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Name_1", name1);
                            command.Parameters.AddWithValue("@Name_2", name2);
                            command.Parameters.AddWithValue("@Name_3", name3);
                            command.Parameters.AddWithValue("@Number", number);
                            command.Parameters.AddWithValue("@Restaurant", _restaurant);
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string InsertQuery = $"INSERT INTO AdditionNames SET  ( Name_1 ,Name_2,Name_3,Restaurant ) VALUES (@Name_1 ,@Name_2, @Name_3, @Number,@Restaurant)";
                        using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Name_1", name1);
                            command.Parameters.AddWithValue("@Name_2", name2);
                            command.Parameters.AddWithValue("@Name_3", name3);
                            command.Parameters.AddWithValue("@Number", number);
                            command.Parameters.AddWithValue("@Restaurant", _restaurant);
                            command.ExecuteNonQuery();
                        }
                    }

                }
            }
            connection.Close();
            Savebutton1.Visible = false;
        }
        private void Savebutton2_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();

            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value != null)
                {

                    Exist = new DataTable();
                    int id = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    string name1 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    string name2 = dataGridView2.Rows[i].Cells[2].Value.ToString();
                    string name3 = dataGridView2.Rows[i].Cells[3].Value.ToString();
                    string query = $"SELECT * FROM AdditionGroups WHERE Id = '{id}' and Restaurant='{_restaurant}' ";
                    Exist = dbHelper.ExecuteQuery(query);
                    int count = Exist.Rows.Count;
                    if (count > 0)
                    {
                        string UpdateQuery = $"UPDATE AdditionGroups SET Name_1= @Name_1,Name_2= @Name_2,Name_3= @Name_3,Restaurant= @Restaurant WHERE Id= '{id}'";
                        using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Name_1", name1);
                            command.Parameters.AddWithValue("@Name_2", name2);
                            command.Parameters.AddWithValue("@Name_3", name3);
                            command.Parameters.AddWithValue("@Restaurant", _restaurant);
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string InsertQuery = $"INSERT INTO AdditionGroups ( Name_1 ,Name_2,Name_3,Restaurant ) VALUES (@Name_1 ,@Name_2,@Name_3, @Restaurant)";
                        using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Name_1", name1);
                            command.Parameters.AddWithValue("@Name_2", name2);
                            command.Parameters.AddWithValue("@Name_3", name3);
                            command.Parameters.AddWithValue("@Restaurant", _restaurant);
                            command.ExecuteNonQuery();
                        }
                    }

                }
            }
            connection.Close();
            Savebutton2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label2.Text.Length > 0 && label3.Text.Length > 0)
            {
                int rowindex = int.Parse(label3.Tag.ToString());
                dataGridView1.Rows[rowindex].Cells["Number"].Value = int.Parse(label2.Text);
                label3.Text = "";
                dataGridView1.Refresh();
                Savebutton1.Visible = true;
            }
        }


        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string txt = SearchBox.Text.Trim();
            dataView.RowFilter = $"(Name_1+Name_2+Name_3) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }

        private void AddButton1_Click(object sender, EventArgs e)
        {
            Savebutton1.Visible = true;
            int id = 0;

            foreach (DataRow row in Tablte_Names.Rows)
            {
                id = int.Parse(row["Id"].ToString());
                if (int.Parse(row["Id"].ToString()) > id) { id++; }
            }
            DataRow newRow = Tablte_Names.NewRow();
            newRow["Id"] = id + 1;
            newRow["Number"] = 0;
            Tablte_Names.Rows.Add(newRow);
            int lastRowIndex = Tablte_Names.Rows.Count - 1;
            dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
            dataGridView1.BeginEdit(true);
        }
    }

}

