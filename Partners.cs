using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Partners : Form
    {
        private int _restaurant;

        private int _editor;

        private SQLDatabaseHelper dbHelper;

        private DataTable Table_Partners = new DataTable();
        
        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private DataView dataView;
        public Partners(int restaurant, int editor)
        {
            _restaurant = restaurant;
            _editor = editor;

            InitializeComponent();

            string connectionString = "Server=DESKTOP-L1SRCHN\\SQLEXPRESS;Database=CafeRest;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            string query1_0 = $"SELECT * FROM Partners WHERE Restaurant='{_restaurant}' ";
            Table_Partners = dbHelper.ExecuteQuery(query1_0);
            dataView = new DataView(Table_Partners);
            dataGridView1.DataSource = dataView;
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].DataPropertyName = "Name_1";
            dataGridView1.Columns[2].DataPropertyName = "Name_2";
            dataGridView1.Columns[3].DataPropertyName = "Name_3";
            dataGridView1.Columns[4].DataPropertyName = "Note";
            dataGridView1.Columns[5].DataPropertyName = "Groupp";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 5)
                {
                    column.Visible = false;
                }

            }

            string query7 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query7);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = this.Text+"  "+row["Name_1"].ToString();
            }

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            if (_editor == 0)
            {
                Addbutton.Enabled = false;
                Savebutton.Enabled = false;
            }

        }

        private void Partners_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void Partners_ResizeEnd(object sender, EventArgs e)
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

        private void Addbutton_Click(object sender, EventArgs e)
        {
            dataView = new DataView(Table_Partners);
            if (dataView.Count > 0)
            {
                // Use LINQ to find the maximum value in the "Code" column
                decimal maxId = dataView.Cast<DataRowView>().Max(row => (decimal)row["Id"]) + 1;


                DataRow newRow = Table_Partners.NewRow();
                newRow["Id"] = maxId;
                newRow["Name_1"] = "";
                newRow["Name_2"] = "";
                newRow["Name_3"] = "";
                newRow["Note"] = ""; 
                newRow["Groupp"] = 0;
                newRow["Restaurant"] = _restaurant;


                // Add the new row to the DataTable
                Table_Partners.Rows.Add(newRow);


                if (dataGridView1.Rows.Count > 0)
                {
                    int lastRowIndex = dataGridView1.Rows.Count - 2;
                    dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];
                    dataGridView1.BeginEdit(true);


                }
            }
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            DataTable Tp = new DataTable();
            string connectionString = "Server=DESKTOP-L1SRCHN\\SQLEXPRESS;Database=CafeRest;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            foreach (DataRow row in Table_Partners.Rows)
            {
                string query = $"SELECT * FROM Partners WHERE Id='{row["Id"]}' AND Restaurant='{_restaurant}' ";
                Tp = dbHelper.ExecuteQuery(query);
                if (Tp.Rows.Count > 0)
                {
                    string UpdateQuery = $"UPDATE Partners SET Name_1 = @Name_1, Name_2 = @Name_2, Name_3 = @Name_3, Note = @Note, Groupp = @Groupp  WHERE Id = @Id  ";
                    using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name_1", row["Name_1"]);
                        command.Parameters.AddWithValue("@Name_2", row["Name_2"]);
                        command.Parameters.AddWithValue("@Name_3", row["Name_3"]);
                        command.Parameters.AddWithValue("@Note", row["Note"]);
                        command.Parameters.AddWithValue("@Groupp", row["Groupp"]);
                        command.Parameters.AddWithValue("@Id", row["Id"]);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    string InsertQuery = $"INSERT INTO Partners (Name_1, Name_2, Name_3, Note, Groupp,  Restaurant) " +
       $"VALUES (@Name_1, @Name_2, @Name_3, @Note, @Groupp  @Restaurant)";
                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name_1", row["Name_1"]);
                        command.Parameters.AddWithValue("@Name_2", row["Name_2"]);
                        command.Parameters.AddWithValue("@Name_3", row["Name_3"]);
                        command.Parameters.AddWithValue("@Note", row["Note"]);
                        command.Parameters.AddWithValue("@Groupp", row["Groupp"]);
                        command.Parameters.AddWithValue("@Restaurant", _restaurant);
                        command.ExecuteNonQuery();
                    }
                }

            }
            connection.Close();
            Savebutton.Visible= false;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
                Savebutton.Visible = true;
        }
    }
}