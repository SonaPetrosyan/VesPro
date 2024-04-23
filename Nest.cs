using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp4
{
    public partial class Nest : Form
    {
        private int _restaurant;
        private string _language;
        private int _editor;
        private SQLDatabaseHelper dbHelper;
        private DataTable Nest_1 = new DataTable();
        private DataTable Nest_Group = new DataTable();
        private DataTable Resize = new DataTable();
        private DataTable Exist = new DataTable();
        private DataTable ControlsNestGroupp = new DataTable();
        private DataTable Table_Rest = new DataTable();
        private DataView dataView;
        public Nest(int restaurant, string language, int editor)
        {
            _restaurant = restaurant;
            _language = language;
            _editor= editor;
            InitializeComponent();

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);


            string query1 = $"SELECT Nest,Service,Discount,Groupp,Holl," +
                $"Restaurant,Ocupied,Forbidden,Printed,Taxprinted,Ticket," +
                $"Person,Tipmoney FROM Tablenest WHERE Holl='{numericUpDown1.Value}' AND Restaurant='{_restaurant}' ";
            Nest_1 = dbHelper.ExecuteQuery(query1);
            dataGridView1.DataSource = Nest_1;
            dataGridView1.Columns[0].DataPropertyName = "Nest";
            dataGridView1.Columns[1].DataPropertyName = "Service";
            dataGridView1.Columns[2].DataPropertyName = "Discount";
            dataGridView1.Columns[3].DataPropertyName = "Groupp";
            dataGridView1.DataSource = Nest_1;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index > 3)
                {
                    column.Visible = false;
                }
            }

            string query11 = $"SELECT* FROM NestGroup  ";
            Nest_Group = dbHelper.ExecuteQuery(query11);



            dataGridView2.DataSource = Nest_Group;
            dataGridView2.Columns[0].DataPropertyName = "Groupp";
            dataGridView2.Columns[1].DataPropertyName = "Name";
            foreach(DataRow row in Nest_Group.Rows)
            {
                row["Name"] = row[_language];
            }
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Index > 1)
                {
                    column.Visible = false;
                }
            }

            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

            label2.Text = "";
            label3.Text = "";
            Load();
            SetLanguage(_language);
            if (_editor == 0)
            {
                Savebutton1.Enabled=false;
                Savebutton2.Enabled=false;
            }
        }
        private void SetLanguage(string lang)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            string rb = "";
            string rbt = "";
            connection.Open();
            DataTable ControlsForm1 = new DataTable();
            string query1 = $"SELECT * FROM ControlsNestGroupp  ";
            ControlsNestGroupp = dbHelper.ExecuteQuery(query1);
            foreach (Control control in this.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsNestGroupp.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel1.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsNestGroupp.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                string columnName = dataGridView1.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsNestGroupp.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView1.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }
            }

            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                string columnName = dataGridView1.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsNestGroupp.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView1.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }
            }

            for (int colIndex = 0; colIndex < dataGridView2.Columns.Count; colIndex++)
            {
                string columnName = dataGridView2.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsNestGroupp.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView2.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }
            }
            connection.Close();
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
                this.Text = row["Name"].ToString()+"  Seats";
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            if (Savebutton1.Visible)
            {
                numericUpDown1.Value = int.Parse(numericUpDown1.Tag.ToString());
                DontsaveButton.Visible = true;
            }
            else
            {
                int prev = 0;
                if (checkBox1.Checked) prev = 1;
                string query1 = $"SELECT Nest,Service,Discount,Groupp,Holl," +
                $"Restaurant,Ocupied,Forbidden,Printed,Taxprinted,Ticket," +
                $"Person,Tipmoney FROM Tablenest WHERE Holl='{numericUpDown1.Value}'" +
                $" AND Restaurant='{_restaurant}' and Previous='{prev}' ";
                Nest_1 = dbHelper.ExecuteQuery(query1);
                dataGridView1.DataSource = Nest_1;
            }
        }

        private void Nest_ResizeBegin(object sender, EventArgs e)
        {

            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }
        }

        private void Nest_ResizeEnd(object sender, EventArgs e)
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



        }

        private void Addbutton1_Click(object sender, EventArgs e)
        {
            Savebutton1.Visible = true;
            int nest = 0;
            string s = "";
            int prev = 0;
            if (checkBox1.Checked) prev = 1;
            foreach (DataRow row in Nest_1.Rows)
            {
                s = row["Nest"].ToString() + "   ";
                if (int.Parse(s.Substring(2, 3)) > nest) { nest++; }
            }
            string l = numericUpDown1.Value.ToString() + "-" + (nest + 1).ToString();
            DataRow newRow = Nest_1.NewRow();
            newRow["Nest"] = l; newRow["Service"] = 0; newRow["Discount"] = 0; newRow["Groupp"] = 1;newRow["Ocupied"] = 0; newRow["Forbidden"] = 0; newRow["Printed"] = 0; newRow["Taxprinted"] = 0;
            newRow["Ticket"] = 0; newRow["Person"] = 0; newRow["Tipmoney"] = 0;
            newRow["Holl"] = numericUpDown1.Value; newRow["Restaurant"] = _restaurant;
            Nest_1.Rows.Add(newRow);

            int lastRowIndex = Nest_1.Rows.Count - 1;
            dataGridView1.CurrentCell = dataGridView1.Rows[lastRowIndex].Cells[0];

            dataGridView1.BeginEdit(true);

        }

        private void Savebutton1_Click(object sender, EventArgs e)
        {
            int prev = 0;
            if (checkBox1.Checked) prev = 1;
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {

                    Exist = new DataTable();
                    string nest = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    float service = float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    float discount = float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    int groupp = int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                    int holl = int.Parse(numericUpDown1.Value.ToString());

                    string query = $"SELECT * FROM TableNest WHERE Nest = '{nest}' AND Holl='{holl}'  AND Restaurant='{_restaurant}' AND Previous='{prev}'";
                    Exist = dbHelper.ExecuteQuery(query);
                    int count = Exist.Rows.Count;
                    if (count > 0)
                    {
                        string UpdateQuery = $"UPDATE TableNest SET Service= '{service}',Discount= '{discount}',Groupp= '{groupp}'" +
                            $" WHERE Nest= '{nest}' AND Holl= '{holl}' AND Restaurant='{_restaurant}' AND Previous='{prev}'";
                        using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                            updatCommand.ExecuteNonQuery();

                    }
                    else
                    {
                        string InsertQuery = $"INSERT INTO TableNest (Nest ,Holl ,Service ,Discount ,Groupp,Restaurant," +
                            $"Ocupied,Forbidden,Printed,Taxprinted,Ticket,Person,Tipmoney,Previous )" +
                            $" VALUES ('{nest}','{holl}','{service}','{discount}','{groupp}','{_restaurant}'," +
                            $"'{0}','{0}','{0}','{0}','{0}','{0}','{0}','{0}')";
                        using (SqlCommand updatCommand = new SqlCommand(InsertQuery, connection))
                            updatCommand.ExecuteNonQuery();
                    }
                }
            }
            Savebutton1.Visible = false;
            DontsaveButton.Visible = false;
            connection.Close();
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton1.Visible = true;
        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            if (Savebutton1.Visible) { return; }
        }

        private void DontsaveButton_Click(object sender, EventArgs e)
        {
            DontsaveButton.Visible = false;
            Savebutton1.Visible = false;
            button1.Enabled = false;
        }

        private void AddButton2_Click(object sender, EventArgs e)
        {
            Savebutton2.Visible = true;
            int groupp = 0;

            foreach (DataRow row in Nest_Group.Rows)
            {
                groupp = int.Parse(row["Groupp"].ToString());
                if (int.Parse(row["Groupp"].ToString()) > groupp) { groupp++; }
            }
            DataRow newRow = Nest_Group.NewRow();
            newRow["Groupp"] = groupp+1;
            Nest_Group.Rows.Add(newRow);
            int lastRowIndex = Nest_Group.Rows.Count - 1;
            dataGridView2.CurrentCell = dataGridView2.Rows[lastRowIndex].Cells[0];
            dataGridView2.BeginEdit(true);
        }

        private void Savebutton2_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value != null)
                {

                    Exist = new DataTable();
                    int groupp = int.Parse(dataGridView2.Rows[i].Cells[0].Value.ToString());
                    string name = dataGridView2.Rows[i].Cells[1].Value.ToString();

                    string query = $"SELECT * FROM NestGroup WHERE Groupp = '{groupp}' ";
                    Exist = dbHelper.ExecuteQuery(query);
                    int count = Exist.Rows.Count;
                    if (count > 0)
                    {
                        string UpdateQuery = $"UPDATE NestGroup SET {_language} = @language WHERE Groupp= @groupp";
                        using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@language", name);
                            command.Parameters.AddWithValue("@groupp", groupp);
                            command.ExecuteNonQuery();
                        }



                    }
                    else
                    {
                        string InsertQuery = $"INSERT INTO NestGroup (Groupp ,{_language} ) Values (@groupp,@language) ";
                        using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@language", name);
                            command.Parameters.AddWithValue("@groupp", groupp);
                            command.ExecuteNonQuery();
                        }
                    }

                }
                
            }
            connection.Close();
            Savebutton2.Visible = false;
        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Savebutton2.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            label3.Text = dataGridView.Rows[e.RowIndex].Cells["Nest"].Value.ToString();
            label3.Tag = e.RowIndex.ToString();
            button1.Enabled = true;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            label2.Text = dataGridView.Rows[e.RowIndex].Cells["Groupp"].Value.ToString();
            label2.Tag = e.RowIndex.ToString();
            button1.Enabled = true;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0) // Check if cell value is 0
            {
                e.Value = ""; // Set cell value to empty string to hide 0
                e.FormattingApplied = true; // Indicate that the formatting is applied
            }
        }
    }
}