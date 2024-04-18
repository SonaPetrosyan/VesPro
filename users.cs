
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class users : Form
    {
        private int _restaurant;

        private int _editor;

        private DataTable dataTableusers = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private SQLDatabaseHelper dbHelper;

        private DataView dataView;

        public users(int restaurant, int editor)
        {
            _restaurant = restaurant;

            _editor = editor;

            InitializeComponent();
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            string query = $"SELECT id,Login, Password, Passqart, Position, Name,editor,orderer,previous,observer, Holl,Restaurant,Workplace FROM users  ";
            dataTableusers = dbHelper.ExecuteQuery(query);
            dataGridView1.DataSource = dataTableusers;
            dataView = new DataView(dataTableusers);
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].DataPropertyName = "Login";
            dataGridView1.Columns[2].DataPropertyName = "Password";
            dataGridView1.Columns[3].DataPropertyName = "Passqart";
            dataGridView1.Columns[4].DataPropertyName = "Position";
            dataGridView1.Columns[5].DataPropertyName = "Name";
            dataGridView1.Columns[6].DataPropertyName = "orderer";
            dataGridView1.Columns[7].DataPropertyName = "editor";
            dataGridView1.Columns[8].DataPropertyName = "previous";
            dataGridView1.Columns[9].DataPropertyName = "observer";
            dataGridView1.Columns[10].DataPropertyName = "Holl";
            dataGridView1.Columns[11].DataPropertyName = "Restaurant";
            dataGridView1.Columns[12].DataPropertyName = "Workplace";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index > 12)
                {
                    column.Visible = false;
                }
            }


            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            string query1 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query1);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = row["Name"].ToString();
            }

            connection.Close();

            if(_editor ==0 ) SaveButton.Enabled = false;
        }




        public void PopulateDataTableUser()
        {

        }


        private void users_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void users_ResizeEnd(object sender, EventArgs e)
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
            foreach (Control control in panel1.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveButton.Visible = true;
        }

        private void SearchBox2_TextChanged(object sender, EventArgs e)
        {
            String txt = SearchBox2.Text;
            dataView = new DataView(dataTableusers);
            dataView.RowFilter = $"(Login+Password+Name) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (dataView.Count > 0)
            {
                int id = 0;
                int _holl = 0;
                int _restaurant = 0;
                foreach (DataRow row in dataTableusers.Rows)
                {
                    if (int.Parse(row["Holl"].ToString()) > 0) _holl = int.Parse(row["Holl"].ToString());
                    if (int.Parse(row["Restaurant"].ToString()) > 0) _restaurant = int.Parse(row["Restaurant"].ToString());
                    if (int.Parse(row["Id"].ToString()) >= id) id = int.Parse(row["Id"].ToString()) + 1;
                }
                DataRow newRow = dataTableusers.NewRow();
                dataTableusers.Rows.Add(newRow);
                newRow["Id"] = id;
                newRow["Holl"] = _holl;
                newRow["Restaurant"] = _restaurant;
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
            SaveButton.Visible = true;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            int count = 0;
            //SqlConnection connection = dbHelper.GetConnection();
            connection.Open();
            foreach (DataRow row in dataTableusers.Rows)
            {
                string query = $"SELECT COUNT(*) FROM users WHERE Id = @Id ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", row["Id"]);
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
                if (count == 0)
                {
                  String query1= $"INSERT INTO users (Login,Password,Passqart,Name,Position,editor,orderer,previous,observer,Holl,Restaurant ) " +
                            $"VALUES ('{row["Login"]}','{row["Password"]}','{row["Passqart"]}'," +
                            $"'{row["editor"]}','{row["orderer"]}','{row["previous"]}','{row["observer"]}','{row["Name"]}'," +
                            $"'{row["Position"]}','{row["Holl"]}','{row["Restaurant"]}') ";
                    using (SqlCommand insertCommand = new SqlCommand(query1, connection))
                        insertCommand.ExecuteNonQuery();
                }
                else
                {
                    int prev = 1, obs = 1, ord = 1, edit = 1;
                    this.Text = "previous " + row["previous"].ToString() + "observer " + row["observer"].ToString() + "orderer " + row["orderer"].ToString() + "editor " + row["editor"].ToString();
                    if (row["previous"].ToString().Length == 0) prev = 0;
                    if (row["editor"].ToString().Length == 0) edit = 0;
                    if (row["observer"].ToString().Length == 0) obs = 0;
                    if (row["orderer"].ToString().Length == 0) ord = 0;
                    String query1 = $"UPDATE users SET Login = '{row["Login"]}',Password='{row["Password"]}'," +
                              $"Passqart='{row["Passqart"]}',editor='{edit}',Name = '{row["Name"]}'," +
                              $"Position='{row["Position"]}',orderer='{ord}',previous='{prev}',observer='{obs}'," +
                              $"Holl='{row["Holl"]}',Restaurant = '{row["Restaurant"]}' WHERE Id = '{row["Id"]}' ";
                    using (SqlCommand insertCommand = new SqlCommand(query1, connection))
                        insertCommand.ExecuteNonQuery();
                }
            }
            SaveButton.Visible=false;
            connection.Close();
        }
    }
}
