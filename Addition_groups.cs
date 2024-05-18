using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Addition_groups : Form
    {
        private DataTable Addition_gr = new DataTable();
        private MySQLDatabaseHelper dbHelper;
        public Addition_groups()
        {
            InitializeComponent();
            InitializeComponent();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            string query = $"SELECT * FROM `Addition_groups` WHERE 1 ";
            Addition_gr = dbHelper.ExecuteQuery(query);
            dataGridView1.DataSource = Addition_gr;
            dataGridView1.Refresh();
            dataGridView1.Visible = true;
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "*******"+Addition_gr.Rows.Count.ToString();
            MySqlConnection connection = dbHelper.GetConnection();

            foreach (DataRow row in Addition_gr.Rows)
            {
                int id = Convert.ToInt32(row["group"]);
                string name_1 = row["name_1"].ToString();
                string name_2 = row["name_2"].ToString();
                string name_3 = row["name_3"].ToString();
                int deleted = Convert.ToInt32(row["deleted"]);
                if (id > 0)
                {
                    connection.Open();
                    //   string updateTable1Query = $"UPDATE users SET login = '{log}',password='{passw}',passqart='{passq}',position='{posi}',powers='{pow}',end='{end}' WHERE id = {id}";
                    string updateTable1Query = $"UPDATE Addition_groups SET `name_1` = '{name_1}',`name_2`='{name_2}',`name_3`='{name_3}',`deleted`='{deleted}' WHERE `group` = {id}";
                    using (MySqlCommand updateTable1Command = new MySqlCommand(updateTable1Query, connection))
                    updateTable1Command.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    connection.Open();
                    //   string updateTable1Query = $"UPDATE users SET login = '{log}',password='{passw}',passqart='{passq}',position='{posi}',powers='{pow}',end='{end}' WHERE id = {id}";
                    string updateTable1Query = $"INSERT Addition_groups SET `name_1` = '{name_1}',`name_2`='{name_2}',`name_3`='{name_3}',`deleted`='{deleted}'";
                    using (MySqlCommand updateTable1Command = new MySqlCommand(updateTable1Query, connection))
                    updateTable1Command.ExecuteNonQuery();
                    connection.Close();
                }
                this.Close();
            }
        }
    }
}

