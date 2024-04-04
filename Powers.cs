using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Powers : Form
    {
        private MySQLDatabaseHelper dbHelper;
        private DataTable dataTablePowers1;
        private DataTable dataTablePowers2;
        private DataTable dataTablePowers3;
        private DataTable dataTablePowers4;

        public Powers()
        {
            InitializeComponent();
            DataSynchronization();
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            string query = $"SELECT id, login, button11, button12, button13, button14, button15,button16,button17,button18,button19,button110 FROM powers1 WHERE 1 ";
            dataTablePowers1 = dbHelper.ExecuteQuery(query);
            dataGridView1.DataSource = dataTablePowers1;
            dataGridView1.Refresh();
            Savebutton.Tag = "1"; // Savebutton_Click ում օգտագործելու համար 
            dataGridView1.Visible = true;
            MySqlConnection connection = dbHelper.GetConnection();
            Button[] TabArray = new Button[1] { Tab1button };
            TabArray[0].BackColor = Color.Lime;

            string query2 = $"SELECT id, login, button21, button22, button23, button24, button25,button26,button27,button28,button29,button210 FROM powers2 WHERE 1 ";
            dataTablePowers2 = dbHelper.ExecuteQuery(query2);

            string query3 = $"SELECT id, login, button31, button32, button33, button34, button35,button36,button37,button38,button39,button310 FROM powers3 WHERE 1 ";
            dataTablePowers3 = dbHelper.ExecuteQuery(query3);

            string query4 = $"SELECT id, login, button41, button42, button43, button44, button45,button46,button47,button48,button49,button410 FROM powers4 WHERE 1 ";
            dataTablePowers4 = dbHelper.ExecuteQuery(query4);

            connection.Close();
        }
        private void DataSynchronization()//power1,power2,power3,power4 DB tabl-ները users-ով լրացնելու գործողություն է: Դրանք լիազորությունների ֆայլերն են 
        {
            dbHelper = new MySQLDatabaseHelper("localhost", "kafe_arm", "root", "");
            MySqlConnection connection = dbHelper.GetConnection();
            string query = "SELECT * FROM users WHERE 1 ";
            DataTable dataTableusers = dbHelper.ExecuteQuery(query);
            this.Text = "users.Rows.Count = " + dataTableusers.Rows.Count.ToString();

            foreach (DataRow row in dataTableusers.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string login = row["login"].ToString();

                //---------------------------------

                string selectTable1Query = $"SELECT id FROM powers1 WHERE id = {id}";
                DataTable dataTable1 = dbHelper.ExecuteQuery(selectTable1Query);
                this.Text = "powers1.Rows.Count = " + dataTable1.Rows.Count.ToString();
                connection.Open();
                if (dataTable1.Rows.Count == 0)
                {
                    string appendTable1Query = $"INSERT INTO powers1 (id) VALUES ({id})";
                    using (MySqlCommand appendTable1Command = new MySqlCommand(appendTable1Query, connection))
                    {
                        appendTable1Command.ExecuteNonQuery();
                    }
                }

                string updateTable1Query = $"UPDATE powers1 SET login = '{login}' WHERE id = {id}";
                using (MySqlCommand updateTable1Command = new MySqlCommand(updateTable1Query, connection))
                    updateTable1Command.ExecuteNonQuery();
                connection.Close();

                //---------------------------------

                string selectTable2Query = $"SELECT id FROM powers2 WHERE id = {id}";
                DataTable dataTable2 = dbHelper.ExecuteQuery(selectTable2Query);
                this.Text = "powers2.Rows.Count = " + dataTable2.Rows.Count.ToString();
                connection.Open();
                if (dataTable2.Rows.Count == 0)
                {
                    string appendTable2Query = $"INSERT INTO powers2 (id) VALUES ({id})";
                    using (MySqlCommand appendTable2Command = new MySqlCommand(appendTable2Query, connection))
                    {
                        appendTable2Command.ExecuteNonQuery();
                    }
                }

                string updateTable2Query = $"UPDATE powers2 SET login = '{login}' WHERE id = {id}";
                using (MySqlCommand updateTable2Command = new MySqlCommand(updateTable2Query, connection))
                    updateTable2Command.ExecuteNonQuery();
                connection.Close();

                //---------------------------------

                string selectTable3Query = $"SELECT id FROM powers3 WHERE id = {id}";
                DataTable dataTable3 = dbHelper.ExecuteQuery(selectTable3Query);
                this.Text = "powers3.Rows.Count = " + dataTable3.Rows.Count.ToString();
                connection.Open();
                if (dataTable3.Rows.Count == 0)
                {
                    string appendTable3Query = $"INSERT INTO powers3 (id) VALUES ({id})";
                    using (MySqlCommand appendTable3Command = new MySqlCommand(appendTable3Query, connection))
                    {
                        appendTable3Command.ExecuteNonQuery();
                    }
                }
                string updateTable3Query = $"UPDATE powers3 SET login = '{login}' WHERE id = {id}";
                using (MySqlCommand updateTable3Command = new MySqlCommand(updateTable3Query, connection))
                    updateTable3Command.ExecuteNonQuery();
                connection.Close();

                //---------------------------------

                string selectTable4Query = $"SELECT id FROM powers4 WHERE id = {id}";
                DataTable dataTable4 = dbHelper.ExecuteQuery(selectTable4Query);
                this.Text = "powers4.Rows.Count = " + dataTable4.Rows.Count.ToString();
                connection.Open();
                if (dataTable4.Rows.Count == 0)
                {
                    string appendTable4Query = $"INSERT INTO powers4 (id) VALUES ({id})";
                    using (MySqlCommand appendTable4Command = new MySqlCommand(appendTable4Query, connection))
                    {
                        appendTable4Command.ExecuteNonQuery();
                    }
                }
                string updateTable4Query = $"UPDATE powers4 SET login = '{login}' WHERE id = {id}";
                using (MySqlCommand updateTable4Command = new MySqlCommand(updateTable4Query, connection))
                    updateTable4Command.ExecuteNonQuery();
                connection.Close();

                //---------------------------------



            }
        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = dbHelper.GetConnection();
            connection.Open();
 
            //-------------------------------------

            if (Savebutton.Tag.ToString() == "1")//powers1-ն է խմբագրբում
            {
                foreach (DataRow row in dataTablePowers1.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    int b1 = Convert.ToInt32(row["button11"]);
                    int b2 = Convert.ToInt32(row["button12"]);
                    int b3 = Convert.ToInt32(row["button13"]);
                    int b4 = Convert.ToInt32(row["button14"]);
                    int b5 = Convert.ToInt32(row["button15"]);
                    int b6 = Convert.ToInt32(row["button16"]);
                    int b7 = Convert.ToInt32(row["button17"]);
                    int b8 = Convert.ToInt32(row["button18"]);
                    int b9 = Convert.ToInt32(row["button19"]);
                    int b10 = Convert.ToInt32(row["button110"]);
                    string query = $"UPDATE powers1 SET button11 = '{b1}',button12='{b2}',button13='{b3}',button14='{b4}',button15 = '{b5}',button16='{b6}',button17='{b7}',button18='{b8}',button19='{b9}',button110='{b10}' WHERE id = {id}";
                    using (MySqlCommand updatepowers1 = new MySqlCommand(query, connection))
                        updatepowers1.ExecuteNonQuery();
                    Savebutton.Visible = false;
                }
            }

            //--------------------------------------

            if (Savebutton.Tag.ToString() == "2")//powers2-ն է խմբագրբում
            {
                foreach (DataRow row in dataTablePowers2.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string log = row["login"].ToString();
                    string b1 = row["button21"].ToString();
                    string b2 = row["button22"].ToString();
                    string b3 = row["button23"].ToString();
                    string b4 = row["button24"].ToString();
                    string b5 = row["button25"].ToString();
                    string b6 = row["button26"].ToString();
                    string b7 = row["button27"].ToString();
                    string b8 = row["button28"].ToString();
                    string b9 = row["button29"].ToString();
                    string b10 = row["button210"].ToString();
                    string query = $"UPDATE powers2 SET button21 = '{b1}',button22='{b2}',button23='{b3}',button24='{b4}',button25 = '{b5}',button26='{b6}',button27='{b7}',button28='{b8}',button29='{b9}',button210='{b10}' WHERE id = {id}";
                    using (MySqlCommand updatepowers2 = new MySqlCommand(query, connection))
                        updatepowers2.ExecuteNonQuery();
                    Savebutton.Visible = false;
                }
            }

            //--------------------------------------

            if (Savebutton.Tag.ToString() == "3")//powers3-ն է խմբագրբում
            {
                foreach (DataRow row in dataTablePowers3.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string log = row["login"].ToString();
                    string b1 = row["button31"].ToString();
                    string b2 = row["button32"].ToString();
                    string b3 = row["button33"].ToString();
                    string b4 = row["button34"].ToString();
                    string b5 = row["button35"].ToString();
                    string b6 = row["button36"].ToString();
                    string b7 = row["button37"].ToString();
                    string b8 = row["button38"].ToString();
                    string b9 = row["button39"].ToString();
                    string b10 = row["button310"].ToString();
                    string query = $"UPDATE powers3 SET button31 = '{b1}',button32='{b2}',button33='{b3}',button34='{b4}',button35 = '{b5}',button36='{b6}',button37='{b7}',button38='{b8}',button39='{b9}',button310='{b10}' WHERE id = {id}";
                    using (MySqlCommand updatepowers3 = new MySqlCommand(query, connection))
                        updatepowers3.ExecuteNonQuery();
                    Savebutton.Visible = false;
                }
            }

            //--------------------------------------

            if (Savebutton.Tag.ToString() == "4")//powers4-ն է խմբագրբում
            {
                foreach (DataRow row in dataTablePowers4.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string log = row["login"].ToString();
                    string b1 = row["button41"].ToString();
                    string b2 = row["button42"].ToString();
                    string b3 = row["button43"].ToString();
                    string b4 = row["button44"].ToString();
                    string b5 = row["button45"].ToString();
                    string b6 = row["button46"].ToString();
                    string b7 = row["button47"].ToString();
                    string b8 = row["button48"].ToString();
                    string b9 = row["button49"].ToString();
                    string b10 = row["button410"].ToString();
                    string query = $"UPDATE powers4 SET button41 = '{b1}',button42='{b2}',button43='{b3}',button44='{b4}',button45 = '{b5}',button46='{b6}',button47='{b7}',button48='{b8}',button49='{b9}',button410='{b10}' WHERE id = {id}";
                    using (MySqlCommand updatepowers4 = new MySqlCommand(query, connection))
                        updatepowers4.ExecuteNonQuery();
                    Savebutton.Visible = false;
                }
            }
            //--------------------------------------
            connection.Close();
        }

        private void Tab1button_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (Savebutton.Visible && Savebutton.Tag != "1")
            {
                message.Text = "Պահպանե՞լ։ Կրկին սեղմեք՝ եթե ոչ";
                message.Visible = true;
                Savebutton.Tag = "1";
            }
            else
            {
                Button[] TabArray = new Button[4] { Tab1button, Tab2button, Tab3button, Tab4button };
                TabArray[0].BackColor = Color.White;
                TabArray[1].BackColor = Color.White;
                TabArray[2].BackColor = Color.White;
                TabArray[3].BackColor = Color.White;
                TabArray[0].BackColor = Color.Lime;
                Savebutton.Tag = "1";
                Savebutton.Visible = true;
                message.Visible = false;
                dataGridView1.DataSource = dataTablePowers1;
                dataGridView1.Refresh();


            }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast


        }

        private void Tab2button_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (Savebutton.Visible && Savebutton.Tag != "2")
            {
                message.Text = "Պահպանե՞լ։ Կրկին սեղմեք՝ եթե ոչ";
                message.Visible = true;
                Savebutton.Tag = "2";
            }
            else
            {
                Button[] TabArray = new Button[4] { Tab1button, Tab2button, Tab3button, Tab4button };
                TabArray[0].BackColor = Color.White;
                TabArray[1].BackColor = Color.White;
                TabArray[2].BackColor = Color.White;
                TabArray[3].BackColor = Color.White;
                TabArray[1].BackColor = Color.Lime;
                Savebutton.Tag = "2";
                Savebutton.Visible = true;
                message.Visible = false;
                dataGridView1.DataSource = dataTablePowers2;
                dataGridView1.Refresh();
            }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
        }

        private void Tab3button_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (Savebutton.Visible && Savebutton.Tag != "3")
            {
                message.Text = "Պահպանե՞լ։ Կրկին սեղմեք՝ եթե ոչ";
                message.Visible = true;
                Savebutton.Tag = "3";
            }
            else
            {
                Button[] TabArray = new Button[4] { Tab1button, Tab2button, Tab3button, Tab4button };
                TabArray[0].BackColor = Color.White;
                TabArray[1].BackColor = Color.White;
                TabArray[2].BackColor = Color.White;
                TabArray[3].BackColor = Color.White;
                TabArray[2].BackColor = Color.Lime;
                Savebutton.Tag = "3";
                Savebutton.Visible = true;
                message.Visible = false;
                dataGridView1.DataSource = dataTablePowers3;
                dataGridView1.Refresh();
            }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
        }

        private void Tab4button_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0252 // Possible unintended reference comparison; left hand side needs cast
            if (Savebutton.Visible && Savebutton.Tag != "4")
            {
                message.Text = "Պահպանե՞լ։ Կրկին սեղմեք՝ եթե ոչ";
                message.Visible = true;
                Savebutton.Tag = "4";
            }
            else
            {
                Button[] TabArray = new Button[4] { Tab1button, Tab2button, Tab3button, Tab4button };
                TabArray[0].BackColor = Color.White;
                TabArray[1].BackColor = Color.White;
                TabArray[2].BackColor = Color.White;
                TabArray[3].BackColor = Color.White;
                TabArray[3].BackColor = Color.Lime;
                Savebutton.Tag = "4";
                Savebutton.Visible = true;
                message.Visible = false;
                dataGridView1.DataSource = dataTablePowers4;
                dataGridView1.Refresh();
            }
#pragma warning restore CS0252 // Possible unintended reference comparison; left hand side needs cast
        }
    }
}

