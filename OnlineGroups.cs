using System.Data.SqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class DeliveryGroups : Form
    {
        private int _restaurant;

        private int _editor;

        private string _language;

        private SQLDatabaseHelper dbHelper;

        private DataTable Tablte_215 = new DataTable();

        private DataTable Delivery_Group = new DataTable();

        private DataTable Resize = new DataTable();

        private DataTable ControlsFoodGroups = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private DataTable Exist = new DataTable();

        private DataView dataView;
        public DeliveryGroups(int editor, int restaurant, string language)
        {
            _editor = editor;

            _restaurant = restaurant;

            _language = language;

            InitializeComponent();

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);


            string query1 = $"SELECT * FROM table_215 WHERE Restaurant='{_restaurant}'";
            Tablte_215 = dbHelper.ExecuteQuery(query1);
            Tablte_215.Columns.Add("Changed", typeof(int));
            dataGridView1.DataSource = Tablte_215;
            dataGridView1.Columns[0].DataPropertyName = "Code";
            dataGridView1.Columns[1].DataPropertyName = _language;
            dataGridView1.Columns[2].DataPropertyName = "DeliveryGroupp";
            dataGridView1.DataSource = Tablte_215;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 2)
                {
                    column.Visible = false;
                }
            }
            foreach (DataRow row in Tablte_215.Rows)
            {
                row["Changed"] = 0;
            }

            string query2 = $"SELECT * FROM DeliveryGroupp WHERE Restaurant='{_restaurant}'";
            Delivery_Group = dbHelper.ExecuteQuery(query2);
            Delivery_Group.Columns.Add("Changed", typeof(int));
            dataGridView2.DataSource = Delivery_Group;
            dataGridView2.Columns[0].DataPropertyName = "DeliveryGroupp";
            dataGridView2.Columns[1].DataPropertyName = _language;
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Index > 1)
                {
                    column.Visible = false;
                }
            }
            foreach (DataRow row in Delivery_Group.Rows)
            {
                row["Changed"] = 0;
            }
            string query3 = $"SELECT * FROM Restaurants WHERE Id = '{_restaurant}'";
            Table_Rest = dbHelper.ExecuteQuery(query3);
            foreach (DataRow row in Table_Rest.Rows)
            {
                this.Text = row[_language].ToString();
            }

            Resize.Columns.Add("BeginWidth", typeof(decimal));
            Resize.Columns.Add("BeginHeight", typeof(decimal));
            Resize.Columns.Add("EndWidth", typeof(decimal));
            Resize.Columns.Add("EndHeight", typeof(decimal));
            Resize.Rows.Add(0, 0, 0, 0);

            label2.Text = "";
            label3.Text = "";

            if (_editor == 0)
            {
                Savebutton2.Enabled = false;
            }
            SetLanguage(_language);
        }

        private void SetLanguage(string lang)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            DataTable ControlsForm1 = new DataTable();
            string query1 = $"SELECT * FROM ControlsFoodGroups  ";
            ControlsFoodGroups = dbHelper.ExecuteQuery(query1);

            foreach (Control control in this.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsFoodGroups.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][lang].ToString();
                }
            }

            foreach (Control control in panel1.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsFoodGroups.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][lang].ToString();
                }
            }
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                string columnName = dataGridView1.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsFoodGroups.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView1.Columns[colIndex].HeaderText = foundRows[0][lang].ToString();
                }

            }
            for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
            {
                string columnName = dataGridView2.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsFoodGroups.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView2.Columns[colIndex].HeaderText = foundRows[0][lang].ToString();
                }

            }
            connection.Close();
        }

        private void DeliveryGroups_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void DeliveryGroups_ResizeEnd(object sender, EventArgs e)
        {
            decimal kw = 0;
            decimal kh = 0;
            foreach (DataRow row in Resize.Rows)
            {
                row["EndWidth"] = this.Width;
                row["EndHeight"] = this.Height;
                kw = decimal.Parse(row["EndWidth"].ToString()) / decimal.Parse(row["BeginWidth"].ToString());
                kh = decimal.Parse(row["EndHeight"].ToString()) / decimal.Parse(row["BeginHeight"].ToString());
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
            decimal Deliverygroupp = 0;

            foreach (DataRow row in Delivery_Group.Rows)
            {
                if (decimal.Parse(row["DeliveryGroupp"].ToString()) > Deliverygroupp) { Deliverygroupp = decimal.Parse(row["DeliveryGroupp"].ToString()); }
            }
            DataRow newRow = Delivery_Group.NewRow();
            newRow["DeliveryGroupp"] = Deliverygroupp + 1;
            newRow["Changed"] = 1;
            Delivery_Group.Rows.Add(newRow);
            int lastRowIndex = Delivery_Group.Rows.Count - 1;
            dataGridView2.CurrentCell = dataGridView2.Rows[lastRowIndex].Cells[1];
            dataGridView2.BeginEdit(true);
        }

        private void Savebutton2_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            foreach (DataRow row in Delivery_Group.Rows)
            {
                if (int.Parse(row["Changed"].ToString()) == 0) continue;
                Exist = new DataTable();
                int Deliverygroupp = int.Parse(row["DeliveryGroupp"].ToString());
                string name1 = row[_language].ToString();
                string query = $"SELECT * FROM DeliveryGroupp WHERE DeliveryGroupp = '{Deliverygroupp}' AND Restaurant='{_restaurant}'";
                Exist = dbHelper.ExecuteQuery(query);
                int count = Exist.Rows.Count;
                if (count > 0)
                {
                    string UpdateQuery = $"UPDATE DeliveryGroupp SET {_language}= @language WHERE DeliveryGroupp= @DeliveryGroupp ";
                    using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@language", name1);
                        command.Parameters.AddWithValue("@DeliveryGroupp", Deliverygroupp);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    string InsertQuery = $"INSERT INTO DeliveryGroupp (DeliveryGroupp,{_language},Restaurant) VALUES (@DeliveryGroupp, @language, @Restaurant)";
                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@DeliveryGroupp", Deliverygroupp);
                        command.Parameters.AddWithValue("@language", name1);
                        command.Parameters.AddWithValue("@Restaurant", _restaurant);
                        command.ExecuteNonQuery();
                    }
                }
            }
            foreach (DataRow row in Tablte_215.Rows)
            {
                if (int.Parse(row["Changed"].ToString()) == 0) continue;
                string code = row["Code"].ToString();
                int Deliverygroup = int.Parse(row["DeliveryGroupp"].ToString());
                string UpdateQuery = $"UPDATE table_215 SET DeliveryGroupp= '{Deliverygroup}' WHERE Code= '{code}' AND Restaurant='{_restaurant}' ";
                using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                    updatCommand.ExecuteNonQuery();

            }
            connection.Close();
            Savebutton2.Visible = false;
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
            if (e.RowIndex >= 0 && e.RowIndex <= dataGridView1.Rows.Count)
            {
                DataGridView dataGridView = (DataGridView)sender;
                dataGridView.Rows[e.RowIndex].Cells["Changed"].Value = 1;
            }
            Savebutton2.Visible = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dataGridView1.Rows.Count)
            {
                DataGridView dataGridView = (DataGridView)sender;
                DataGridViewCell currentCell = dataGridView.CurrentCell;
                label2.Text = dataGridView.Rows[e.RowIndex].Cells["DeliveryGroupp"].Value.ToString();
                label2.Tag = e.RowIndex.ToString();
                button1.Enabled = true;
            }
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex <= dataGridView2.Rows.Count)
            {
                DataGridView dataGridView = (DataGridView)sender;
                dataGridView.Rows[e.RowIndex].Cells["Changed"].Value = 1;
            }
            Savebutton2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label2.Text.Length > 0 && label3.Text.Length > 0)
            {
                DataRow[] foundRows = Tablte_215.Select($"TRIM(Code) = '{label3.Text}'");

                if (foundRows.Length > 0)
                {
                    foundRows[0]["DeliveryGroupp"] = label2.Text;
                    label3.Text = "";
                    Savebutton2.Visible = true;
                }
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Tablte_215);
            string txt = SearchBox.Text.Trim();
            dataView.RowFilter = $"(Code+{_language}) LIKE '%{txt}%'";
            dataGridView1.DataSource = dataView;
        }
        private HelpDialogForm helpDialogForm;
        private void HelpButton_Click(object sender, EventArgs e)
        {
            string help = FindFolder.Folder("Help");
            string filePath = "";
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";

                filePath = help + "\\DeliveryGroups_" + _language + ".txt";
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