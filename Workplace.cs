﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing.Printing;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp4
{
    public partial class Workplace : Form
    {
        private int _restaurant;

        private SQLDatabaseHelper dbHelper;

        private DataTable Resize = new DataTable();

        private DataTable Table_Workplace = new DataTable();

        private DataTable Table_Restaurant = new DataTable();

        private DataView dataView;
        public Workplace(int restaurant)
        {
            _restaurant = restaurant;
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
            dataGridView1.Columns[2].DataPropertyName = "Power";
            dataGridView1.Columns[3].DataPropertyName = "Billprint";
            dataGridView1.Columns[4].DataPropertyName = "Preprint";
            dataGridView1.Columns[5].DataPropertyName = "Taxprint";
            dataGridView1.Columns[6].DataPropertyName = "Printer1";
            dataGridView1.Columns[7].DataPropertyName = "Printer2";
            dataGridView1.Columns[8].DataPropertyName = "Printer3";
            dataGridView1.Columns[9].DataPropertyName = "Printer4";
            dataGridView1.Columns[10].DataPropertyName = "Printer5";
            dataGridView1.Columns[11].DataPropertyName = "Printer6";
            dataGridView1.Columns[12].DataPropertyName = "Printer7";
            dataGridView1.Columns[13].DataPropertyName = "Printer8";
            dataGridView1.Columns[14].DataPropertyName = "Printer9";
            dataGridView1.Columns[15].DataPropertyName = "Printer10";
            dataGridView1.Columns[16].DataPropertyName = "Printer11";
            dataGridView1.Columns[17].DataPropertyName = "Printer12";
            dataGridView1.Columns[18].DataPropertyName = "Printer13";
            dataGridView1.Columns[19].DataPropertyName = "Printer14";
            dataGridView1.Columns[20].DataPropertyName = "Printer15";

            //  dataGridView1.Columns[0].HeaderText = "Կոդ";
            //  dataGridView1.Columns[1].HeaderText = "Անվանում";
            //  dataGridView1.Columns[2].HeaderText = "Չ․մ";
            //  dataGridView1.Columns[3].HeaderText = "Վերջին գին";
            //  dataGridView1.Columns[4].HeaderText = "Քանակ";
            //  dataGridView1.Columns[5].HeaderText = "Գին";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                string name = column.DataPropertyName;
                if (column.Index > 20)
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

            comboBoxRest.DataSource = Table_Restaurant.DefaultView;
            comboBoxRest.DisplayMember = "Name_1";
            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);
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
            if (currentCell != null && currentCell.ColumnIndex == 5)
            {
                powerbox.Visible = true;
                label3.Visible = true;
            }
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



        private void powerbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row = int.Parse(dataGridView1.Tag.ToString());
            int column = int.Parse(getprinterbox.Tag.ToString());
            dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[column];
            dataGridView1.CurrentCell.Value = powerbox.SelectedItem;
            powerbox.Visible = false;
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
                        $"Power=@Power,Billprint=@Billprint,Preprint=@Preprint,Taxprint=@Taxprint," +
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
                        command.Parameters.AddWithValue("@Power", row["Power"]);
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

                    string InsertQuery = $"INSERT INTO Workplace (Restaurant, Holl, Number,Description, Power,Billprint, Preprint, Taxprint, Printer1" +
                        $", Printer2, Printer3, Printer4, Printer5, Printer6, Printer7, Printer8, Printer9, Printer10, " +
                        $"Printer11, Printer12, Printer13, Printer14, Printer15) " +
           $"VALUES (@Restaurant, @Holl, @Number,@Description, @Power, @Preprint, @Taxprint, @Printer1, @Printer2," +
           $" @Printer3, @Printer4, @Printer5, @Printer6, @Printer7, @Printer8, @Printer9, @Printer10," +
           $"@Printer11, @Printer12, @Printer13, @Printer14, @Printer15)";
                    using (SqlCommand command = new SqlCommand(InsertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Restaurant", row["Restaurant"]);
                        command.Parameters.AddWithValue("@Holl", row["Holl"]);
                        command.Parameters.AddWithValue("@Number", row["Number"]);
                        command.Parameters.AddWithValue("@Description", row["Description"]);
                        command.Parameters.AddWithValue("@Power", row["Power"]);
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


    }
}