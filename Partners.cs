using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.ReportingServices.Diagnostics.Internal;

namespace WindowsFormsApp4
{
    public partial class Partners : Form
    {
        private int _restaurant;

        private int _editor;

        private string _language;

        private SQLDatabaseHelper dbHelper;

        private DataTable Table_Partners = new DataTable();
        
        private DataTable Resize = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private DataView dataView;
        public Partners(int restaurant, int editor, string language)
        {
            _restaurant = restaurant;
            _editor = editor;
            _language= language;

            InitializeComponent();

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            string query1_0 = $"SELECT * FROM Partners WHERE Restaurant='{_restaurant}' ";
            Table_Partners = dbHelper.ExecuteQuery(query1_0);
            dataView = new DataView(Table_Partners);
            dataGridView1.DataSource = dataView;
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].DataPropertyName = _language;
            dataGridView1.Columns[2].DataPropertyName = "Note";
            dataGridView1.Columns[3].DataPropertyName = "Groupp";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 3)
                {
                    column.Visible = false;
                }

            }

            string query7 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query7);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = this.Text+"  "+row["Name"].ToString();
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

                DataRow newRow = Table_Partners.NewRow();
                decimal maxId = dataView.Cast<DataRowView>().Max(row => (decimal)row["Id"]) + 1;
                foreach (DataColumn column in Table_Partners.Columns)
                {
                    string columnName = column.ColumnName;
                    if (Table_Partners.Columns[columnName].DataType == typeof(string)) newRow[columnName] = "";
                    if (Table_Partners.Columns[columnName].DataType == typeof(int)) newRow[columnName] = 0;
                    if (Table_Partners.Columns[columnName].DataType == typeof(float)) newRow[columnName] = 0;
                }

                newRow["Id"] = maxId;
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
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            foreach (DataRow row in Table_Partners.Rows)
            {
                string query = $"SELECT * FROM Partners WHERE Id='{row["Id"]}' AND Restaurant='{_restaurant}' ";
                Tp = dbHelper.ExecuteQuery(query);

                if (Tp.Rows.Count > 0)
                {
                    foreach (DataColumn column in Table_Partners.Columns)
                    {
                        string columnName = column.ColumnName;

                        if (columnName == "Id") continue;

                        string UpdateQuery = $"UPDATE Partners SET {columnName} = @Name  WHERE Id = @Id";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                            {
                                command.Parameters.AddWithValue("@Name", row[columnName]);
                                command.Parameters.AddWithValue("@Id", row["Id"]);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                else
                {
                    SqlConnection connection = new SqlConnection(connectionString);
                    connection.Open();
                    string InsertQuery = $"INSERT INTO Partners (Name) VALUES (@Name)";
                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", " ");
                        command.ExecuteNonQuery();
                    }
                    int maxid = FindMaxID.MaxId(connectionString, "Partners");

                    foreach (DataColumn column in Table_Partners.Columns)
                    {
                        string columnName = column.ColumnName;

                        if (columnName == "Id") continue;

                        string UpdateQuery = $"UPDATE Partners SET {columnName} = @Name  WHERE Id = @Id";
                        using (SqlConnection connection1 = new SqlConnection(connectionString))
                        {
                            if (connection1.State != ConnectionState.Open) { connection1.Open(); }
                            using (SqlCommand command = new SqlCommand(UpdateQuery, connection1))
                            {
                                command.Parameters.AddWithValue("@Name", row[columnName]);
                                command.Parameters.AddWithValue("@Id", maxid);
                                command.ExecuteNonQuery();
                            }
                            if (connection1.State == ConnectionState.Open) { connection1.Close(); }
                        }
                        
                    }
                    
                    connection.Close();
                }
                
            }
            
            Savebutton.Visible= false;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
                Savebutton.Visible = true;
        }
        private HelpDialogForm helpDialogForm;
        private void HelpButton_Click(object sender, EventArgs e)
        {
            string help = FindFolder.Folder("Help");
            string filePath = "";
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";              
                filePath = help + "\\Partners_" + _language + ".txt";
                string fileContent = File.ReadAllText(filePath);

                if (helpDialogForm == null)
                {
                    helpDialogForm = new HelpDialogForm();
                    helpDialogForm.FormClosed += (s, args) => helpDialogForm = null; // Reset the helpDialogForm reference when the form is closed
                }

                helpDialogForm.SetHelpContent(fileContent);
                helpDialogForm.Show();
            }
            else
            {
                HelpButton.Text = "?";
                helpDialogForm?.Close(); // Close the help dialog form if it's open
            }
        }
    }
}