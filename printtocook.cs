using ReportPrinter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public static class printtocook
    {
        public static void printingtocook(int printer1, DataTable Table215,
            DataTable tableforprint,string ticket, string nest,string person,
            string Restname,string ooperator, string lang)
        {
            Translate.translation(Table215, tableforprint, lang, "3");
            int p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0, p8 = 0, p9 = 0, p10 = 0, p11 = 0, p12 = 0, p13 = 0, p14 = 0, p15 = 0;

            DataTable Order = new DataTable();
            Order.Columns.Add("name", typeof(string));
            Order.Columns.Add("price", typeof(float));
            Order.Columns.Add("quantity", typeof(float));
            Order.Columns.Add("salesamount", typeof(float));

            foreach (DataRow row in tableforprint.Rows)
            {
                //****************************** ստուգում ենք որ տպիչի վրա կա տպելիք
                if (int.Parse(row["printer"].ToString()) == 1) p1 = 1;
                if (int.Parse(row["printer"].ToString()) == 2) p2 = 1;
                if (int.Parse(row["printer"].ToString()) == 3) p3 = 1;
                if (int.Parse(row["printer"].ToString()) == 4) p4 = 1;
                if (int.Parse(row["printer"].ToString()) == 5) p5 = 1;
                if (int.Parse(row["printer"].ToString()) == 6) p6 = 1;
                if (int.Parse(row["printer"].ToString()) == 7) p7 = 1;
                if (int.Parse(row["printer"].ToString()) == 8) p8 = 1;
                if (int.Parse(row["printer"].ToString()) == 9) p9 = 1;
                if (int.Parse(row["printer"].ToString()) == 10) p10 = 1;
                if (int.Parse(row["printer"].ToString()) == 11) p11 = 1;
                if (int.Parse(row["printer"].ToString()) == 12) p12 = 1;
                if (int.Parse(row["printer"].ToString()) == 13) p13 = 1;
                if (int.Parse(row["printer"].ToString()) == 14) p14 = 1;
                if (int.Parse(row["printer"].ToString()) == 15) p15 = 1;
                //******************************************
                if (int.Parse(row["printer"].ToString()) != printer1 || float.Parse(row["quantity"].ToString()) == 0) continue;
                DataRow newRow = Order.NewRow();
                Order.Rows.Add(newRow);
                newRow["name"] = row["name"];
                newRow["quantity"] = float.Parse(row["quantity"].ToString());
                newRow["price"] = float.Parse(row["price"].ToString());
                newRow["salesamount"] = float.Parse(row["salesamount"].ToString());
            }

            if (Order.Rows.Count > 0)
            {
                DataRow newRow0 = Order.NewRow();
                Order.Rows.Add(newRow0);
                newRow0["name"] = "=======================";
                if (p1 == 1 && printer1 != 1)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 1 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p2 == 1 && printer1 != 2)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 2 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p3 == 1 && printer1 != 3)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 3 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p4 == 1 && printer1 != 4)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 4 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p5 == 1 && printer1 != 5)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 5 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p6 == 1 && printer1 != 6)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 6 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p7 == 1 && printer1 != 7)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 7 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p8 == 1 && printer1 != 8)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 8 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p9 == 1 && printer1 != 9)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 9 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p10 == 1 && printer1 != 10)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 10 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p11 == 1 && printer1 != 11)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 11 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p12 == 1 && printer1 != 12)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 12 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p13 == 1 && printer1 != 13)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 13 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p14 == 1 && printer1 != 14)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 14 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                if (p15 == 1 && printer1 != 15)
                {
                    DataRow newRow = Order.NewRow();
                    Order.Rows.Add(newRow);
                    newRow["name"] = "=======================";
                    foreach (DataRow row in tableforprint.Rows)
                    {
                        if (int.Parse(row["printer"].ToString()) != 15 || float.Parse(row["quantity"].ToString()) == 0) continue;
                        DataRow newRow1 = Order.NewRow();
                        Order.Rows.Add(newRow1);
                        newRow1["name"] = row["name"];
                        newRow1["quantity"] = float.Parse(row["quantity"].ToString());
                        newRow1["price"] = float.Parse(row["price"].ToString());
                        newRow1["salesamount"] = float.Parse(row["salesamount"].ToString());
                    }

                }
                string reportname = "";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("nest", nest);
                parameters.Add("person", person.ToString());
                parameters.Add("restaurant", Restname);
                parameters.Add("operator", ooperator);
                parameters.Add("ticket", ticket);
              //  this.Text = nest.Text + "," + numericUpDown3.Value.ToString() + "," + Restaurantname + "," + _ooperatorname + "," + bill.Text;
                string Report = FindFolder.Folder("Report") + "\\OrderReport.rdlc";
                ReportManager reportManager = new ReportManager();
                reportManager.PreviewReport("BillReport", Report, Order, parameters, null);
            }
        }
    }
}
