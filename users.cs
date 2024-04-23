
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class users : Form
    {
        private int _restaurant;

        private int _editor;

        private string _language;

        private DataTable dataTableusers = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private SQLDatabaseHelper dbHelper;

        private DataView dataView;

        public users(int restaurant, int editor, string language)
        {
            _restaurant = restaurant;

            _editor = editor;

            _language = language;

            InitializeComponent();
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            string query = $"SELECT Id,Login,Password,Passqart,Position,Name,Manager,orderer,editor,previous,observer,Workplace,Holl,Restaurant FROM users  ";
            dataTableusers = dbHelper.ExecuteQuery(query);
            dataGridView1.DataSource = dataTableusers;
            dataView = new DataView(dataTableusers);
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].DataPropertyName = "Login";
            dataGridView1.Columns[2].DataPropertyName = "Password";
            dataGridView1.Columns[3].DataPropertyName = "Passqart";
            dataGridView1.Columns[4].DataPropertyName = "Position";
            dataGridView1.Columns[5].DataPropertyName = "Name";
            dataGridView1.Columns[6].DataPropertyName = "Manager";
            dataGridView1.Columns[7].DataPropertyName = "orderer";
            dataGridView1.Columns[8].DataPropertyName = "editor";
            dataGridView1.Columns[9].DataPropertyName = "previous";
            dataGridView1.Columns[10].DataPropertyName = "observer";
            dataGridView1.Columns[11].DataPropertyName = "Workplace";
            dataGridView1.Columns[12].DataPropertyName = "Holl";
            dataGridView1.Columns[13].DataPropertyName = "Restaurant";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index > 13)
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
                newRow["orderer"] = 0;
                newRow["Manager"] = 0;
                newRow["Editor"] = 0;
                newRow["previous"] = 0;
                newRow["observer"] = 0;
                newRow["Password"] = "";
                newRow["Login"] = "";
                newRow["Workplace"] = 0;
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
                    String InsertQuery = $"INSERT INTO users (Login,Password,Passqart,Name,Position,Manager,editor,orderer,previous,Workplace,observer,Holl,Restaurant ) " +
                         $"VALUES (@Login,@Password,@Passqart,@Name,@Position,@Manager,@editor,@orderer,@previous,@Workplace,@observer,@Holl,@Restaurant )";     
                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Login", row["Login"]);
                        command.Parameters.AddWithValue("@Password", row["Password"]);
                        command.Parameters.AddWithValue("@Passqart", row["Passqart"]);
                        command.Parameters.AddWithValue("@Name", row["Name"]);
                        command.Parameters.AddWithValue("@Position", row["Position"]);
                        command.Parameters.AddWithValue("@Manager", row["Manager"]);
                        command.Parameters.AddWithValue("@editor", row["editor"]);
                        command.Parameters.AddWithValue("@orderer", row["orderer"]);
                        command.Parameters.AddWithValue("@previous", row["previous"]);
                        command.Parameters.AddWithValue("@observer", row["observer"]);
                        command.Parameters.AddWithValue("@Workplace", row["Workplace"]);
                        command.Parameters.AddWithValue("@Holl", row["Holl"]);
                        command.Parameters.AddWithValue("@Restaurant", row["Restaurant"]);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                   String updatequery = $"UPDATE users SET Login = @Login,Password=@Password," +
                              $"Passqart=@Passqart,editor=@editor,Name = @Name," +
                              $"Position=@Position,Manager=@Manager,orderer=@orderer,previous=@previous,Workplace=@Workplace,observer=@observer," +
                              $"Holl=@Holl,Restaurant = @Restaurant WHERE Id = @Id ";
                    using (SqlCommand command = new SqlCommand(updatequery, connection))
                    {
                        command.Parameters.AddWithValue("@Login", row["Login"]);
                        command.Parameters.AddWithValue("@Password", row["Password"]);
                        command.Parameters.AddWithValue("@Passqart", row["Passqart"]);
                        command.Parameters.AddWithValue("@Name", row["Name"]);
                        command.Parameters.AddWithValue("@Position", row["Position"]);
                        command.Parameters.AddWithValue("@Manager", row["Manager"]);
                        command.Parameters.AddWithValue("@editor", row["editor"]);
                        command.Parameters.AddWithValue("@orderer", row["orderer"]);
                        command.Parameters.AddWithValue("@previous", row["previous"]);
                        command.Parameters.AddWithValue("@Workplace", row["Workplace"]);
                        command.Parameters.AddWithValue("@observer", row["observer"]);
                        command.Parameters.AddWithValue("@Holl", row["Holl"]);
                        command.Parameters.AddWithValue("@Restaurant", row["Restaurant"]);
                        command.Parameters.AddWithValue("@Id", row["Id"]);
                        command.ExecuteNonQuery();
                    }
                }
            }
            SaveButton.Visible=false;
            connection.Close();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string help = FindFolder.Folder("Help");
            string filePath = "";
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";
                richTextBox1.Height = this.Height - 50;
                richTextBox1.Top = 0;
                richTextBox1.Left = HelpButton.Width+5;
                richTextBox1.Width = this.Width/2;
                richTextBox1.ReadOnly = true;
                richTextBox1.Visible = true;
                filePath = help+"\\User_"+_language+".txt";
                string fileContent = File.ReadAllText(filePath);
                richTextBox1.Text = fileContent;

            }
            else
            {
                richTextBox1.Visible = false;
                HelpButton.Text = "?";
            }
        }
    }
}
