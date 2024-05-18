using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing.Printing;



namespace WindowsFormsApp4
{
    public partial class Workplace : Form
    {
        private int _restaurant;
        private int _editor;
        private int _holl;
        private string _language;
        private SQLDatabaseHelper dbHelper;

        private DataTable Resize = new DataTable();

        private DataTable Table_Workplace = new DataTable();

        private DataTable Table_Restaurant = new DataTable();
        private DataTable ControlsWorkplace = new DataTable();

        private DataView dataView;
        public Workplace(int restaurant, int editor, int holl, string language )
        {
            _restaurant = restaurant;
            _editor = editor;
            _holl = holl;
            _language = language;
            InitializeComponent();
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            string query = $"SELECT * FROM Workplace ";
            Table_Workplace = dbHelper.ExecuteQuery(query);
            Table_Workplace.Columns.Add("Add", typeof(int));
            dataView = new DataView(Table_Workplace);
            dataGridView1.DataSource = dataView;

            dataGridView1.Columns[0].DataPropertyName = "Number";
            dataGridView1.Columns[1].DataPropertyName = "Description";
            dataGridView1.Columns[2].DataPropertyName = "Billprint";
            dataGridView1.Columns[3].DataPropertyName = "Preprint";
            dataGridView1.Columns[4].DataPropertyName = "Taxprint";
            dataGridView1.Columns[5].DataPropertyName = "Printer1";
            dataGridView1.Columns[6].DataPropertyName = "Printer2";
            dataGridView1.Columns[7].DataPropertyName = "Printer3";
            dataGridView1.Columns[8].DataPropertyName = "Printer4";
            dataGridView1.Columns[9].DataPropertyName = "Printer5";
            dataGridView1.Columns[10].DataPropertyName = "Printer6";
            dataGridView1.Columns[11].DataPropertyName = "Printer7";
            dataGridView1.Columns[12].DataPropertyName = "Printer8";
            dataGridView1.Columns[13].DataPropertyName = "Printer9";
            dataGridView1.Columns[14].DataPropertyName = "Printer10";
            dataGridView1.Columns[15].DataPropertyName = "Printer11";
            dataGridView1.Columns[16].DataPropertyName = "Printer12";
            dataGridView1.Columns[17].DataPropertyName = "Printer13";
            dataGridView1.Columns[18].DataPropertyName = "Printer14";
            dataGridView1.Columns[19].DataPropertyName = "Printer15";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                string name = column.DataPropertyName;
                if (column.Index > 19)
                {
                    column.Visible = false;
                }

            }
            foreach (DataRow row in Table_Workplace.Rows)
            {
                row["Add"] = 0;
            }



                string query1 = $"SELECT * FROM Restaurants ";
            Table_Restaurant = dbHelper.ExecuteQuery(query1);
            foreach (DataRow row in Table_Restaurant.Rows)
            {
                row["Name"] = row[_language];
            }

            comboBoxRest.DataSource = Table_Restaurant.DefaultView;
            comboBoxRest.DisplayMember = "Name";
            Resize.Columns.Add("BeginWidth", typeof(decimal));
            Resize.Columns.Add("BeginHeight", typeof(decimal));
            Resize.Columns.Add("EndWidth", typeof(decimal));
            Resize.Columns.Add("EndHeight", typeof(decimal));
            Resize.Rows.Add(0, 0, 0, 0);
            connection.Close();

            if (_holl == 0)
            {
                button1.Enabled = false;
                savebutton.Enabled = false;
            }
            SetLanguage(_language);
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
            string query1 = $"SELECT * FROM ControlsWorkplace  ";
            ControlsWorkplace = dbHelper.ExecuteQuery(query1);
            foreach (Control control in this.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsWorkplace.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }
            foreach (Control control in panel1.Controls)
            {
                string columnName = control.Name.Trim();
                DataRow[] foundRows = ControlsWorkplace.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    control.Text = foundRows[0][_language].ToString();
                }
            }

            for (int colIndex = 0; colIndex < dataGridView1.Columns.Count; colIndex++)
            {
                string columnName = dataGridView1.Columns[colIndex].DataPropertyName.Trim();
                DataRow[] foundRows = ControlsWorkplace.Select($"TRIM(Name) = '{columnName}'");
                if (foundRows.Length > 0)
                {
                    dataGridView1.Columns[colIndex].HeaderText = foundRows[0][_language].ToString();
                }
            }

            connection.Close();
        }

        private void Workplace_ResizeBegin(object sender, EventArgs e)
        {

            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }

        }

        private void Workplace_ResizeEnd(object sender, EventArgs e)
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

            foreach (Control control in panel1.Controls)
            {
                control.Width = (int)(control.Width * kw);
                control.Height = (int)(control.Height * kh);
                control.Top = (int)(control.Top * kh);
                control.Left = (int)(control.Left * kw);
            }
        }

        private void Workplace_Load(object sender, EventArgs e)
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                getprinterbox.Items.Add(printer);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count= Table_Workplace.Rows.Count;
            int rest = comboBoxRest.SelectedIndex + 1;
            int holl = (int)HollUpDown.Value;
            int num = 0;
            DataRow[] foundRows = Table_Workplace.Select($"Restaurant = '{rest}' and Holl = '{holl}' ");
            num = foundRows.Length + 1;
            DataRow newRow = Table_Workplace.NewRow();
            Table_Workplace.Rows.Add(newRow);
            newRow["Id"] = count + 1;
            newRow["Number"]=num;
            newRow["Restaurant"] = rest;
            newRow["Holl"] = holl;
            newRow["Add"] = 1;
            savebutton.Visible = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the current cell
            DataGridViewCell currentCell = dataGridView1.CurrentCell;
            dataGridView1.Tag = currentCell.RowIndex.ToString();// ֆիքսում ենք ընթացիկ բջիջի ինդեքսները
            getprinterbox.Tag = currentCell.ColumnIndex.ToString();
            // Get the next cell
            this.Text = getprinterbox.Tag.ToString();
            if (currentCell != null && currentCell.ColumnIndex > 5) 
            {
                getprinterbox.Visible = true;
            }
            
        }

        private void getprinterbox_Click(object sender, EventArgs e)
        {
            int row= int.Parse(dataGridView1.Tag.ToString());
            int column = int.Parse(getprinterbox.Tag.ToString());
            dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[column];
            dataGridView1.CurrentCell.Value= getprinterbox.SelectedItem.ToString();
            getprinterbox.Visible= false;
            savebutton.Visible = true;
        }



        private void savebutton_Click(object sender, EventArgs e)
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();

            foreach (DataRow row in Table_Workplace.Rows)
            {
                if (row["Add"] == null || int.Parse(row["Add"].ToString()) != 1)
                {
                    string UpdateQuery = $"UPDATE Workplace SET Number = @Number,Description=@Description," +
                        $"Billprint=@Billprint,Preprint=@Preprint,Taxprint=@Taxprint," +
                        $"Printer1=@Printer1,Printer2=@Printer2," +
                        $"Printer3=@Printer3,Printer4=@Printer4,Printer5=@Printer5," +
                        $"Printer6=@Printer6,Printer7=@Printer7,Printer8=@Printer8," +
                        $"Printer9=@Printer9,Printer10=@Printer10,Printer11=@Printer11," +
                        $"Printer12=@Printer12,Printer13=@Printer13,Printer14=@Printer14," +
                        $"Printer15=@Printer15 WHERE Id = '{row["id"]}'  ";
                    using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Number", row["Number"]);
                        command.Parameters.AddWithValue("@Description", row["Description"]);
                        command.Parameters.AddWithValue("@Billprint", row["Billprint"]);
                        command.Parameters.AddWithValue("@Preprint", row["Preprint"]);
                        command.Parameters.AddWithValue("@Taxprint", row["Taxprint"]);
                        command.Parameters.AddWithValue("@Printer1", row["Printer1"]);
                        command.Parameters.AddWithValue("@Printer2", row["Printer2"]);
                        command.Parameters.AddWithValue("@Printer3", row["Printer3"]);
                        command.Parameters.AddWithValue("@Printer4", row["Printer4"]);
                        command.Parameters.AddWithValue("@Printer5", row["Printer5"]);
                        command.Parameters.AddWithValue("@Printer6", row["Printer6"]);
                        command.Parameters.AddWithValue("@Printer7", row["Printer7"]);
                        command.Parameters.AddWithValue("@Printer8", row["Printer8"]);
                        command.Parameters.AddWithValue("@Printer9", row["Printer9"]);
                        command.Parameters.AddWithValue("@Printer10", row["Printer10"]);
                        command.Parameters.AddWithValue("@Printer11", row["Printer11"]);
                        command.Parameters.AddWithValue("@Printer12", row["Printer12"]);
                        command.Parameters.AddWithValue("@Printer13", row["Printer13"]);
                        command.Parameters.AddWithValue("@Printer14", row["Printer14"]);
                        command.Parameters.AddWithValue("@Printer15", row["Printer15"]);
                        command.ExecuteNonQuery();
                    }
                }
                else
                {

                    string InsertQuery = $"INSERT INTO Workplace (Restaurant, Holl, Number,Description,Billprint, Preprint, Taxprint, Printer1" +
                        $", Printer2, Printer3, Printer4, Printer5, Printer6, Printer7, Printer8, Printer9, Printer10, " +
                        $"Printer11, Printer12, Printer13, Printer14, Printer15) " +
           $"VALUES (@Restaurant, @Holl, @Number,@Description,@Billprint,@Preprint, @Taxprint, @Printer1, @Printer2," +
           $" @Printer3, @Printer4, @Printer5, @Printer6, @Printer7, @Printer8, @Printer9, @Printer10," +
           $"@Printer11, @Printer12, @Printer13, @Printer14, @Printer15)";
                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Restaurant", row["Restaurant"]);
                        command.Parameters.AddWithValue("@Holl", row["Holl"]);
                        command.Parameters.AddWithValue("@Number", row["Number"]);
                        command.Parameters.AddWithValue("@Description", row["Description"]);
                        command.Parameters.AddWithValue("@Billprint", row["Billprint"]);
                        command.Parameters.AddWithValue("@Preprint", row["Preprint"]);
                        command.Parameters.AddWithValue("@Taxprint", row["Taxprint"]);
                        command.Parameters.AddWithValue("@Printer1", row["Printer1"]);
                        command.Parameters.AddWithValue("@Printer2", row["Printer2"]);
                        command.Parameters.AddWithValue("@Printer3", row["Printer3"]);
                        command.Parameters.AddWithValue("@Printer4", row["Printer4"]);
                        command.Parameters.AddWithValue("@Printer5", row["Printer5"]);
                        command.Parameters.AddWithValue("@Printer6", row["Printer6"]);
                        command.Parameters.AddWithValue("@Printer7", row["Printer7"]);
                        command.Parameters.AddWithValue("@Printer8", row["Printer8"]);
                        command.Parameters.AddWithValue("@Printer9", row["Printer9"]);
                        command.Parameters.AddWithValue("@Printer10", row["Printer10"]);
                        command.Parameters.AddWithValue("@Printer11", row["Printer11"]);
                        command.Parameters.AddWithValue("@Printer12", row["Printer12"]);
                        command.Parameters.AddWithValue("@Printer13", row["Printer13"]);
                        command.Parameters.AddWithValue("@Printer14", row["Printer14"]);
                        command.Parameters.AddWithValue("@Printer15", row["Printer15"]);
                        command.ExecuteNonQuery();
                    }
                }
            }
            connection.Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            savebutton.Visible = true;
        }
        private HelpDialogForm helpDialogForm;

        private void HelpButton_Click(object sender, EventArgs e)
        {
            string help = FindFolder.Folder("Help");
            string filePath = "";
            if (HelpButton.Text == "?")
            {
                HelpButton.Text = "X";              
                filePath = help+"\\Workplace_"+_language+".txt";
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

        private void HollUpDown_ValueChanged(object sender, EventArgs e)
        {
            int rest = comboBoxRest.SelectedIndex + 1;
            int holl = (int)HollUpDown.Value;
            int num = 0;
            dataView = new DataView(Table_Workplace);
            dataView.RowFilter = ($"Restaurant = '{rest}' and Holl = '{holl}' ");
            dataGridView1.DataSource = dataView;
        }
    }
}
