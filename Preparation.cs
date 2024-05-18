using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System.Xml.Linq;

namespace WindowsFormsApp4
{
    public partial class Preparation : Form
    {
        private int _restaurant;

        private int _editor;

        private string _language;

        private DataTable Resize = new DataTable();

        private DataTable Table_215 = new DataTable();

        private DataTable Table_Seans = new DataTable();

        private DataTable Seans_state = new DataTable();

        private DataTable ControlsPreparation = new DataTable();

        private DataTable Table_SeansState = new DataTable();

        private DataTable Table_TicketsOrdered = new DataTable();

        private DataTable Table_Food = new DataTable();

        private DataTable Table_Rest = new DataTable();

        private SQLDatabaseHelper dbHelper;

        private DataView dataView;
        public Preparation(int restaurant, int editor, string language)
        {
            _restaurant = restaurant;
            _editor = editor;
            _language = language;

            InitializeComponent();

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);

            string query1 = $"SELECT * FROM Table_215  WHERE Restaurant={_restaurant}";
            Table_215 = dbHelper.ExecuteQuery(query1);

            Update_Table_Seans();


            dataGridView1.Columns[0].DataPropertyName = "Given";
            dataGridView1.Columns[1].DataPropertyName = "DateOfEntry";
            dataGridView1.Columns[2].DataPropertyName = "Ticket";
            dataGridView1.Columns[3].DataPropertyName = "Nest";
            dataGridView1.Columns[4].DataPropertyName = "Name";
            dataGridView1.Columns[5].DataPropertyName = "Quantity";
            dataGridView1.Columns[6].DataPropertyName = "Preparing";
            dataGridView1.Columns[7].DataPropertyName = "Prepared";



            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index > 7)
                {
                    column.Visible = false;
                }
            }
            Resize.Columns.Add("BeginWidth", typeof(float));
            Resize.Columns.Add("BeginHeight", typeof(float));
            Resize.Columns.Add("EndWidth", typeof(float));
            Resize.Columns.Add("EndHeight", typeof(float));
            Resize.Rows.Add(0, 0, 0, 0);

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataView = new DataView(Table_Seans);
            int printer = int.Parse(numericUpDown1.Value.ToString());
            if (printer > 0)
            {
                dataView.RowFilter = $"Printer = {printer}";
            }
            dataGridView1.DataSource = dataView;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Update_Table_Seans();
        }
        private void Update_Table_Seans()
        {
            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            string query3 = $"SELECT DateOfEntry,Ticket,Nest,Quantity,Holl,Code,State FROM Seans WHERE Paid={0} And State>0 AND Restaurant={_restaurant} ORDER BY DateOfEntry ";
            Table_Seans = dbHelper.ExecuteQuery(query3);
            Table_Seans.Columns.Add("Given", typeof(int));
            Table_Seans.Columns.Add("Name", typeof(string));
            Table_Seans.Columns.Add("Preparing", typeof(int));
            Table_Seans.Columns.Add("Prepared", typeof(int));
            Table_Seans.Columns.Add("Printer", typeof(int));
            Table_Seans.Columns.Add("Changed", typeof(int));
            foreach (DataRow row in Table_Seans.Rows)
            {
                row["Preparing"] = 0;
                row["Prepared"] = 0;
                row["Given"] = 0;
                row["Changed"] = 0;
                if (int.Parse(row["State"].ToString()) == 2) row["Preparing"] = 1;
                if (int.Parse(row["State"].ToString()) == 3) row["Prepared"] = 1;
            }

            var query4 = from row1 in Table_Seans.AsEnumerable()  // տեղադրում ենք <NonComposite> դաշտը, որպեսսզի որոշ սրահներից վաճառքի
                                                                  // դեպքում բաղադրիչները չհանվի բաժնից
                         join row2 in Table_215.AsEnumerable()
                         on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                         from subRow2 in gj.DefaultIfEmpty()
                         select new
                         {
                             Row1 = row1,
                             Row2 = subRow2
                         };

            foreach (var item in query4)
            {
                if (item.Row2 != null)
                {
                    item.Row1["Name"] = item.Row2[_language];
                    item.Row1["Printer"] = item.Row2["Printer"];
                }
            }
            dataGridView1.DataSource = Table_Seans;
            dataView = new DataView(Table_Seans);
            int printer = int.Parse(numericUpDown1.Value.ToString());
            if (printer > 0)
            {
                dataView.RowFilter = $"Printer = {printer}";
            }
            dataGridView1.DataSource = dataView;
        }



        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            numericUpDown1.Focus();
            SendKeys.Send("{ENTER}");

            string connectionString = Properties.Settings.Default.CafeRestDB;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            DataGridView dataGridView = (DataGridView)sender;
            if (e.RowIndex >= 0)
            {
                dataGridView.Rows[e.RowIndex].Cells["Changed"].Value = 1;
            }
            foreach (DataRow row in Table_Seans.Rows)
            {
                if (int.Parse(row["Changed"].ToString()) == 0) continue;
                int state = 1;
                this.Text = row["Preparing"].GetType().ToString();
     
                if (row["Preparing"].GetType() == typeof(int) && int.Parse(row["Preparing"].ToString()) == 1) state = 2;
                if (row["Prepared"].GetType() == typeof(int) && int.Parse(row["Prepared"].ToString()) == 1) state = 3;
                if (row["Given"].GetType() == typeof(int) && int.Parse(row["Given"].ToString()) == 1) state = 0;
                int ticket = int.Parse(row["ticket"].ToString());
                string nest = row["nest"].ToString();
                string code = row["Code"].ToString();
                string UpdateQuery = $"UPDATE Seans  SET State = @state  WHERE Ticket= @Ticket and Nest=@Nest and Code=@Code ";
                using (SqlCommand command = new SqlCommand(UpdateQuery, connection))
                {
                    command.Parameters.AddWithValue("@state", state);
                    command.Parameters.AddWithValue("@Ticket", ticket);
                    command.Parameters.AddWithValue("@Nest", nest);
                    command.Parameters.AddWithValue("@Code", code);
                    command.ExecuteNonQuery();
                }

            }
            connection.Close();
        }

        private void Preparation_ResizeBegin(object sender, EventArgs e)
        {
            foreach (DataRow row in Resize.Rows)
            {
                row["BeginWidth"] = this.Width;
                row["BeginHeight"] = this.Height;
            }

        }

        private void Preparation_ResizeEnd(object sender, EventArgs e)
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
    }
}

