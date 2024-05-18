using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public static class Paiment
    {

        public static void Release(string connectionString, int typofpaiment, int Rest, int holl,
            int ticket, string nest,string amount, int previous, int person, float tipmoney)
        {
            DataTable TableSeans = new DataTable();
            DataTable Table215 = new DataTable();
            DataTable Table_Composite = new DataTable();
            DataTable Table_Actions = new DataTable();
            DataTable TableNest = new DataTable();

            int _restaurant = Rest;
            int _tick = ticket;
            int _previous = previous;
            int _person = person;
            int _holl = holl;
            string _nest = nest;
            float _tipmoney=tipmoney;

            float PM = float.Parse(amount);//կանխիկ
            float CL = float.Parse(amount);//անկանխիկ
            if (typofpaiment == 1) CL = 0;
            if (typofpaiment == 2) PM = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            SQLDatabaseHelper dbHelper = new SQLDatabaseHelper(connectionString);
            DateTime dat = DateTime.Now;
            connection.Open();

            string query4 = $"SELECT * FROM Table_215  WHERE restaurant='{_restaurant}' ";
            Table215 = dbHelper.ExecuteQuery(query4);

            string query1 = $"SELECT * FROM Seans  WHERE Ticket='{_tick}' AND Nest='{_nest}' AND restaurant='{_restaurant}' ";
            TableSeans = dbHelper.ExecuteQuery(query1);

            TableSeans.Columns.Add("Department", typeof(int));
            TableSeans.Columns.Add("groupp", typeof(int));
            TableSeans.Columns.Add("free", typeof(int));
            TableSeans.Columns.Add("noncomposite", typeof(string));
            TableSeans.Columns.Add("name", typeof(string));
            var query0 = from row1 in Table215.AsEnumerable()
                         join row2 in TableSeans.AsEnumerable()
                         on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                         from subRow2 in gj.DefaultIfEmpty()
                         select new
                         {
                             Row1 = row1,
                             Row2 = subRow2
                         };

            foreach (var item in query0)
            {
                if (item.Row2 != null)
                {
                    item.Row2["groupp"] = item.Row1["groupp"];
                    item.Row2["free"] = item.Row1["free"];
                    item.Row2["Department"] = item.Row1["Department"];
                    item.Row2["noncomposite"] = item.Row1["noncomposite"];
                }
            }


            string query2 = $"SELECT * FROM Composite  WHERE restaurant='{_restaurant}' ";
            Table_Composite = dbHelper.ExecuteQuery(query2);
            string query3 = $"SELECT * FROM Actions where Id=0";
            Table_Actions = dbHelper.ExecuteQuery(query3);


            foreach (DataRow row in TableSeans.Rows)
            {
               //if (row["ticket"].ToString() != bill.Text || row["nest"].ToString() != nest.Text) continue;
                string noncomp = row["Holl"].ToString().Trim() + ",";
                if (row["NonComposite"].ToString().IndexOf(noncomp) >= 0) continue; //տվյալ սրահում չի բաղադրվում ճաշատեսակը

                string InsertQuery = $"INSERT INTO Actions_215 ( Code , DateOfEntry, Ticket, Paid," +
                    $"Nest ,Quantity , Price, Costamount, Salesamount, Service, Discount, Taxpaid, Restaurant, Holl, Operator)" +
                    $" values (@Code , @DateOfEntry, @Ticket, @Paid, @Nest ," +
                    $"@Quantity ,@Price, @Costamount, @Salesamount, @Service, @Discount, @Taxpaid, @Restaurant, @Holl, @Operator ) ";
                using (SqlCommand insertCommand = new SqlCommand(InsertQuery, connection))

                {
                    insertCommand.Parameters.AddWithValue("@Code", row["code"]);
                    insertCommand.Parameters.AddWithValue("@DateOfEntry", row["DateOfEntry"]);
                    insertCommand.Parameters.AddWithValue("@Ticket", row["ticket"]);
                    insertCommand.Parameters.AddWithValue("@Paid", row["paid"]);
                    insertCommand.Parameters.AddWithValue("@Nest", row["nest"]);
                    insertCommand.Parameters.AddWithValue("@Quantity", row["quantity"]);
                    insertCommand.Parameters.AddWithValue("@Price", row["price"]);
                    insertCommand.Parameters.AddWithValue("@Costamount", row["Costamount"]);
                    insertCommand.Parameters.AddWithValue("@Salesamount", row["salesamount"]);
                    insertCommand.Parameters.AddWithValue("@Service", row["Service"]);
                    insertCommand.Parameters.AddWithValue("@Discount", row["Discount"]);
                    insertCommand.Parameters.AddWithValue("@Taxpaid", row["taxpaid"]);
                    insertCommand.Parameters.AddWithValue("@Restaurant", _restaurant);
                    insertCommand.Parameters.AddWithValue("@Holl", row["holl"]);
                    insertCommand.Parameters.AddWithValue("@Operator", row["operator"]);

                    insertCommand.ExecuteNonQuery();
                }
            }
            foreach (DataRow row1 in TableSeans.Rows)
            {
                //if (row1["ticket"].ToString() != bill.Text || row1["nest"].ToString() != nest.Text) continue;

                DataRow[] foundRows1 = Table_Composite.Select($"Code_215 = {row1["Code"]}");
                if (foundRows1.Length > 0)
                {
                    foreach (DataRow row2 in foundRows1)
                    {
                        //   DataRow[] foundRows2 = Table_Actions.Select($"Code = {row2["Code_211"]} AND Code_215 = {row1["Code"]} AND DepartmentOut= {row1["DepartmentOut"]}");
                        //   if (foundRows2.Length == 0)
                        //   {
                        DataRow newRow = Table_Actions.NewRow();
                        Table_Actions.Rows.Add(newRow);

                        newRow["Date"] = row1["DateOfEntry"];
                        newRow["Ticket"] = row1["ticket"];
                        newRow["Nest"] = row1["nest"];
                        newRow["Code"] = row2["code_211"];
                        newRow["Code_215"] = row1["Code"];
                        newRow["Restaurant"] = row1["Restaurant"];
                        newRow["Quantity"] = float.Parse(row1["Quantity"].ToString()) * float.Parse(row2["Quantity"].ToString());
                        newRow["Costamount"] = float.Parse(newRow["Quantity"].ToString()) * float.Parse(row2["CostPrice"].ToString());
                        newRow["SalesAmount"] = row1["SalesAmount"];
                    }
                }



            }

            foreach (DataRow row3 in Table_Actions.Rows)
            {
                string InsertQuery1 = $"INSERT INTO Actions (Date,Ticket,Nest , Code, Code_215, Quantity , Costamount, Salesamount, DepartmentOut, Restaurant, debet, kredit )" +
                         $" values (@Date,@Ticket,@Nest, @Code, @code_215, @Quantity , @Costamount, @Salesamount, @DepartmentOut, @Restaurant, @debet, @kredit ) ";
                using (SqlCommand insertCommand = new SqlCommand(InsertQuery1, connection))

                {
                    insertCommand.Parameters.AddWithValue("@Date", row3["Date"]);
                    insertCommand.Parameters.AddWithValue("@Ticket", row3["Ticket"]);
                    insertCommand.Parameters.AddWithValue("@Nest", row3["Nest"]);
                    insertCommand.Parameters.AddWithValue("@Code", row3["Code"]);
                    insertCommand.Parameters.AddWithValue("@Code_215", row3["Code_215"]);
                    insertCommand.Parameters.AddWithValue("@Quantity", row3["Quantity"]);
                    insertCommand.Parameters.AddWithValue("@Costamount", row3["Costamount"]);
                    insertCommand.Parameters.AddWithValue("@Salesamount", 0);
                    insertCommand.Parameters.AddWithValue("@DepartmentOut", row3["DepartmentOut"]);
                    insertCommand.Parameters.AddWithValue("@Restaurant", row3["Restaurant"]);
                    insertCommand.Parameters.AddWithValue("@debet", "7111");
                    insertCommand.Parameters.AddWithValue("@kredit", "2111");
                    insertCommand.ExecuteNonQuery();
                }
            }

            string DeleteQuery = $"DELETE FROM seans   WHERE Nest= '{_nest}' AND Restaurant ='{_restaurant}'";
            using (SqlCommand deleteCommand = new SqlCommand(DeleteQuery, connection))
                deleteCommand.ExecuteNonQuery();



            string query = $"UPDATE TicketsOrdered SET Cash = @PM,Cashless = @CL,  Tipmoney = @Tipmoney, DateEnd = @DateEnd,Person = @Person,Paid=1,Holl=@Holl " +
                $" WHERE Ticket = @Ticket  AND Nest = @Nest  AND Restaurant =@Rest AND  Previous='{_previous}'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PM", PM);
                command.Parameters.AddWithValue("@CL", CL);
                command.Parameters.AddWithValue("@Tipmoney", _tipmoney);
                command.Parameters.AddWithValue("@DateEnd", dat);
                command.Parameters.AddWithValue("@Person", _person);
                command.Parameters.AddWithValue("@Ticket", _tick);
                command.Parameters.AddWithValue("@Nest", _nest);
                command.Parameters.AddWithValue("@Rest", _restaurant);
                command.Parameters.AddWithValue("@Holl", _holl);


                command.ExecuteNonQuery();
            }
            //////////////////////////////////////////////////////////////////////
            string UpdateQuery = $"UPDATE Tablenest SET Ocupied= 0,Printed= 0,Person= 0 ,Ticket= 0," +
                $"Taxprinted= 0,Tipmoney= 0  WHERE Nest= '{_nest}' AND Restaurant ='{_restaurant}' AND Previous='{_previous}'";
            using (SqlCommand updatCommand = new SqlCommand(UpdateQuery, connection))
                updatCommand.ExecuteNonQuery();


            string UpdateQuery0 = $"UPDATE Seans SET Paid= '1'  WHERE Nest= '{_nest}' AND Restaurant ='{_restaurant}'";
            using (SqlCommand updatCommand = new SqlCommand(UpdateQuery0, connection))
                updatCommand.ExecuteNonQuery();


            string selectquery = $"SELECT * FROM Tablenest WHERE Restaurant='{_restaurant}'   AND Previous='{_previous}'";//սեղանների աղյուսակը թարմացնում ենք
            TableNest = dbHelper.ExecuteQuery(selectquery);

            connection.Close();


            //*****************************************


            connection.Close();


        }


    }
}
