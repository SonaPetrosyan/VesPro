using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{


    public partial class Login : Form
    {
        private SQLDatabaseHelper dbHelper;

        public Login()
        {
            InitializeComponent();
            // Initialize the DatabaseHelper with your SQL Server credentials

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Close the database connection when the form is closing
          //  dbHelper.CloseConnection();
        }

        private void loginfield_Enter(object sender, EventArgs e)
        {
            loginfield.Text = "";
            loginfield.BackColor = Color.White;
            buttonlogin.Enabled = false;
        }

        private void loginfield_Leave(object sender, EventArgs e)
        {
            if (loginfield.Text.Length == 0)
            {
                loginfield.BackColor = Color.RosyBrown;
            }
        }

        private void passfield_Enter(object sender, EventArgs e)
        {
            buttonlogin.Enabled = false;
            passfield.Text = "";
            passfield.BackColor = Color.White;
        }

        private void passfield_Leave(object sender, EventArgs e)

        {
            if (passfield.Text.Length == 0)
            {
                passfield.BackColor = Color.RosyBrown;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            loginfield.Text = "";
            loginfield.Focus();
            buttonlogin.Enabled = false;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            passfield.Text = "";
            passfield.Focus();
            buttonlogin.Enabled = false;
        }

        private void loginfield_TextChanged(object sender, EventArgs e)
        {
            if (loginfield.Text.Length > 0 && passfield.Text.Length > 0)
            {
                buttonlogin.Enabled = true;
            }
        }

        private void passfield_TextChanged(object sender, EventArgs e)
        {
            if (loginfield.Text.Length > 0 && passfield.Text.Length > 0)
            {
                buttonlogin.Enabled = true;
            }
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            connection.Open();
            string log = loginfield.Text;
            string pass = passfield.Text;

            string query = $"SELECT * FROM Users WHERE Login = '{log}' AND Password = '{pass}' ";
            DataTable Table_Login = dbHelper.ExecuteQuery(query);
            string q = Table_Login.Rows.Count.ToString();

            string oօperatorname = "";
            int opperator = 0;
            int holl = 0;
            int restaurant = 0;
            int editor = 0;
            int manager = 0;
            int previous = 0;
            int orderer = 0;
            int observer = 0;
            int workplace = 0;
            string lang = "Armenian";
            string restaurantname = "";
            if (Table_Login.Rows.Count > 0) //user - ը գոյություն ունի
            {
                foreach (DataRow row in Table_Login.Rows)//ստուգում ենք լիազորությունը
                {
                    oօperatorname = row["name"].ToString();
                    opperator = Convert.ToInt32(row["Id"]);// աշխատակցի Id-ն
                    holl = Convert.ToInt32(row["Holl"]);//Սրահի համարը
                    restaurant = Convert.ToInt32(row["Restaurant"]);//ռեստորանի համարը
                    if (row["Manager"] != DBNull.Value) manager = Convert.ToInt32(row["Manager"]);//կառավարիչ
                    if (row["Editor"] != DBNull.Value) editor = Convert.ToInt32(row["Editor"]); //խմբագրող
                    if (row["orderer"] != DBNull.Value) orderer = Convert.ToInt32(row["orderer"]);//պատվիրող
                    if (row["previous"] != DBNull.Value) previous = Convert.ToInt32(row["previous"]);//նախնական
                    if (row["observer"] != DBNull.Value) observer = Convert.ToInt32(row["observer"]);//դիտորդ
                    if (row["Workplace"] != DBNull.Value) workplace = Convert.ToInt32(row["observer"]);//աշխատատեղ
                    if (row["Language"] != DBNull.Value) lang = row["Language"].ToString();//աշխատանքային լեզու
                    oօperatorname = row["Name"].ToString();
                    opperator = int.Parse(row["Id"].ToString());
                }
                connection.Close();
                if (manager + editor + orderer + previous + observer > 0)
                {
                    Form1 form1 = new Form1(oօperatorname, opperator, holl, restaurant, restaurantname, manager, editor, orderer, previous, observer, workplace, lang);
                    form1.Show();
                }
                else
                {
                    message.Text = "Լիազորություններ չունեք";
                    message.Visible = true;
                }
            }
            else //user - ը գոյություն չունի
            {
                message.Text = "Անվան կամ գաղտնագրի սխալ";
                int porc = int.Parse(message.Tag.ToString()) - 1;
                if (porc == 0)
                {
                    connection.Close();
                    this.Close();
                }
                string mnac = porc.ToString();
                message.Tag = mnac;
                message.Text = "Անվան կամ գաղտնագրի սխալ։ Ունեք եւս " + mnac + " փորձ";
                message.Visible = true;
            }



            // Bind the DataTable to a DataGridView
            //   dataGridView.DataSource = dataTable;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
