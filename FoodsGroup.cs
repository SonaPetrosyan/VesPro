using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class FoodsGroup : Form
    {
        private int _restaurant;

        private int _editor;

        private string _language;

        private SQLDatabaseHelper dbHelper;

        private DataTable Tablte_215 = new DataTable();

        private DataTable Food_Group = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private DataTable Exist = new DataTable();

        private DataView dataView;
        public FoodsGroup(int editor, int restaurant, string language)
        {
            _editor = editor;

            _restaurant = restaurant;

            _language = language;

            InitializeComponent();

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);


            string query1 = $"SELECT * FROM table_215 WHERE Restaurant='{_restaurant}'" ;
            Tablte_215 = dbHelper.ExecuteQuery(query1);
            Tablte_215.Columns.Add("Name", typeof(string));

            dataGridView1.DataSource = Tablte_215;
            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = "Name";
            dataGridView1.Columns[2].DataPropertyName = "Department";
            dataGridView1.Columns[3].DataPropertyName = "Free";
            dataGridView1.Columns[4].DataPropertyName = "Groupp";
            dataGridView1.DataSource = Tablte_215;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 4)
                {
                    column.Visible = false;
                }
            }
            foreach (DataRow row in Tablte_215.Rows)
            {
                row["Name"] = row[_language];
            }

            string query2 = $"SELECT * FROM FoodGroupp WHERE Restaurant='{_restaurant}'";
            Food_Group = dbHelper.ExecuteQuery(query2);
            dataGridView2.DataSource = Food_Group;
            dataGridView2.Columns[0].DataPropertyName = "Groupp";
            dataGridView2.Columns[1].DataPropertyName = "Name";
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Index > 1)
                {
                    column.Visible = false;
                }
            }
            foreach (DataRow row in Food_Group.Rows)
            {
                row["Name"] = row[_language];
            }
            string query3 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query3);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = row["Name"].ToString();
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
                Savebutton1.Enabled=false;
                Savebutton2.Enabled = false;
            }
        }

        private void FoodsGroup_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void FoodsGroup_ResizeEnd(object sender, EventArgs e)
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
            int groupp = 0;

            foreach (DataRow row in Food_Group.Rows)
            {
                groupp = int.Parse(row["Groupp"].ToString());
                if (int.Parse(row["Groupp"].ToString()) > groupp) { groupp++; }
            }
            DataRow newRow = Food_Group.NewRow();
            newRow["Groupp"] = groupp + 1;
            Food_Group.Rows.Add(newRow);
            int lastRowIndex = Food_Group.Rows.Count - 1;
            dataGridView2.CurrentCell = dataGridView2.Rows[lastRowIndex].Cells[1];
            dataGridView2.BeginEdit(true);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dataGridView1.Rows.Count)
            {
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewCell currentCell = dataGridView.CurrentCell;
                label2.Text = dataGridView.Rows[e.RowIndex].Cells["Groupp"].Value.ToString();
                label2.Tag = e.RowIndex.ToString();
                button1.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dataGridView1.Rows.Count)
            {
                    DataGridView dataGridView = (DataGridView)sender;
                    DataGridViewCell currentCell = dataGridView.CurrentCell;

                    label3.Text = dataGridView.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                    label3.Tag = e.RowIndex.ToString();
                    button1.Enabled = true;
                  
            }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton1.Visible = true;
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton2.Visible = true;
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
                    int groupp = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    string name1 = dataGridView2.Rows[i].Cells[1].Value.ToString();
                    string query = $"SELECT * FROM FoodGroupp WHERE Groupp = '{groupp}' AND Restaurant='{_restaurant}'";
                    Exist = dbHelper.ExecuteQuery(query);
                    int count = Exist.Rows.Count;
                    if (count > 0)
                    {
                        string UpdateQuery = $"UPDATE FoodGroupp SET {_language}= @language WHERE Groupp= @Groupp ";
                        using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@language", name1);
                            command.Parameters.AddWithValue("@Groupp", groupp);
                              command.ExecuteNonQuery();
                        }



                    }
                    else
                    {
                        string InsertQuery = $"INSERT INTO FoodGroupp SET (Groupp,{_language},Restaurant) VALUES (@Groupp, @language, @Restaurant)";
                        using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Groupp", groupp);
                            command.Parameters.AddWithValue("@language", name1);
                            command.Parameters.AddWithValue("@Restaurant", _restaurant);
                            command.ExecuteNonQuery();
                        }



                    }

                }
            }
            Savebutton2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label2.Text.Length > 0 && label3.Text.Length > 0)
            {
                int rowindex = int.Parse(label3.Tag.ToString());
                dataGridView1.Rows[rowindex].Cells["Groupp"].Value = int.Parse(label2.Text);
                label3.Text = "";
                dataGridView1.Refresh();
                Savebutton1.Visible = true;
            }
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
                    string code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    int free = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    int group = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                    string UpdateQuery = $"UPDATE table_215 SET Groupp= '{group}',Free= '{free}' WHERE Code= '{code}' AND Restaurant='{_restaurant}' ";
                    using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                    updatCommand.ExecuteNonQuery();
                }
            }
            Savebutton1.Visible=false;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Tablte_215);
            string txt = SearchBox.Text.Trim();
            dataView.RowFilter = $"(Code+Name) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }


    }
}