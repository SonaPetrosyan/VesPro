using ReportPrinter;
using System;
using System.Collections.Generic;
using System.Data;

namespace WindowsFormsApp4
{
    public static class PrintingBill
    {
        public static void PrintBill(string bill, string nest,  string gid,
            string TipMoney, decimal paid, decimal pevious, DateTime DateBegin, DateTime DateEnd, DataTable dataTable)
        {
            bill= bill.Trim(); nest= nest.Trim(); 
            gid=gid.Trim(); TipMoney= TipMoney.Trim();
            //        DataTable CurrentOrder = new DataTable("CurrentOrder");

            DataTable BillReport = new DataTable();
            BillReport.Columns.Add("code", typeof(string));
            BillReport.Columns.Add("name", typeof(string));
            BillReport.Columns.Add("price", typeof(decimal));
            BillReport.Columns.Add("quantity", typeof(decimal));
            BillReport.Columns.Add("salesamount", typeof(decimal));


            string code = "";
            decimal sales = 0;
            float Total = 0;
            float service = 0;
            float discount = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (int.Parse(row["Free"].ToString()) == 1) continue;// սկզբում տպում ենք սպասարկման կամ զեղչի ենթակաները
                code = row["code"].ToString();
                DataRow[] foundRows = BillReport.Select($"Code = '{code}'");
                if (foundRows.Length == 0)
                {
                    DataRow newRow = BillReport.NewRow();
                    BillReport.Rows.Add(newRow);
                    newRow["code"] = row["code"]; newRow["name"] = row["name"]; newRow["price"] = row["price"];
                    newRow["quantity"] = row["quantity"]; newRow["salesamount"] = row["salesamount"];
                    service = service + float.Parse(row["service"].ToString());
                    discount = discount + float.Parse(row["discount"].ToString());
                    Total = Total + float.Parse(row["salesamount"].ToString());
                }
                else
                {
                    foundRows[0]["quantity"] = float.Parse(foundRows[0]["quantity"].ToString()) + float.Parse(row["quantity"].ToString());
                    foundRows[0]["salesamount"] = float.Parse(foundRows[0]["salesamount"].ToString()) + float.Parse(row["salesamount"].ToString());
                    service = service + float.Parse(row["service"].ToString());
                    discount = discount + float.Parse(row["discount"].ToString());
                    Total = Total + float.Parse(row["salesamount"].ToString());

                }
                sales = sales + decimal.Parse(row["salesamount"].ToString());
            }
            DataRow newRow1 = BillReport.NewRow();
            BillReport.Rows.Add(newRow1);
            DataRow newRow2 = BillReport.NewRow();
            BillReport.Rows.Add(newRow2);
            newRow2["name"] = "Գումար"; newRow2["salesamount"] = sales;
            if ( service != 0)
            {
                DataRow newRow3 = BillReport.NewRow();
                BillReport.Rows.Add(newRow3);
                newRow3["name"] = "+  %"; newRow3["salesamount"] = service;
                Total = Total + service;
            }
            if (discount != 0)
            {
                DataRow newRow4 = BillReport.NewRow();
                BillReport.Rows.Add(newRow4);
                newRow4["name"] = "- զեղչ %"; newRow4["salesamount"] = discount;
                Total = Total - discount;
            }
            if (gid.Length > 0 && gid != "0")
            {
                DataRow newRow5 = BillReport.NewRow();
                BillReport.Rows.Add(newRow5);
                newRow5["name"] = "- Գիդ"; newRow5["salesamount"] = float.Parse(gid);
                Total = Total - float.Parse(gid);

            }
            DataRow newRow6 = BillReport.NewRow();
            BillReport.Rows.Add(newRow6);
           
            foreach (DataRow row in dataTable.Rows)
            {
                if (int.Parse(row["Free"].ToString()) != 1) continue;//  հետո ենք սպասարկման կամ զեղչից ազատները
                code = row["code"].ToString();
                DataRow[] foundRows = BillReport.Select($"Code = '{code}'");
                if (foundRows.Length == 0)
                {
                    DataRow newRow = BillReport.NewRow();
                    BillReport.Rows.Add(newRow);
                    newRow["code"] = row["code"]; newRow["name"] = row["name"]; newRow["price"] = row["price"];
                    newRow["quantity"] = row["quantity"]; newRow["salesamount"] = row["salesamount"];
                    Total = Total + float.Parse(row["salesamount"].ToString());
                }
                else
                {
                    foundRows[0]["quantity"] = float.Parse(foundRows[0]["quantity"].ToString()) + float.Parse(row["quantity"].ToString());
                    foundRows[0]["salesamount"] = float.Parse(foundRows[0]["salesamount"].ToString()) + float.Parse(row["salesamount"].ToString());
                    Total=Total+ float.Parse(row["salesamount"].ToString());

                }
                sales = sales + decimal.Parse(row["salesamount"].ToString());
            }


         //   if (TipMoney.Length > 0 && TipMoney != "0")
         //   {
                DataRow newRow10 = BillReport.NewRow();
                BillReport.Rows.Add(newRow10);
                DataRow newRow7 = BillReport.NewRow();
                BillReport.Rows.Add(newRow7);
                newRow7["name"] = "+ թեյավճար"; newRow7["salesamount"] = float.Parse(TipMoney);
                Total = Total + float.Parse(TipMoney);
         //   }
            DataRow newRow8 = BillReport.NewRow();
            BillReport.Rows.Add(newRow8);

            DataRow newRow9 = BillReport.NewRow();
            BillReport.Rows.Add(newRow9);
            newRow9["name"] = "Ընդամենը"; newRow9["salesamount"] = Total;
            if ( pevious == 1) newRow9["name"] = "Ընդամենը: Կրկնօրինակ է։ Չվաճարե՛լ։ ";
            if (paid == 1)
            {
                DataRow newRow11 = BillReport.NewRow();
                BillReport.Rows.Add(newRow11);
                newRow10["name"] = "Վճարված է "; newRow10["salesamount"] = Total ;
            }
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string DoNotPai = "";
            parameters.Add("RestaurantName", "Պանդոկ Երևան");
            parameters.Add("Bill", bill);
            parameters.Add("Nest", nest);
            parameters.Add("DateBegin", DateBegin);
            parameters.Add("DateEnd", DateEnd);
            //if (paid == 1 || pevious == 1) DoNotPai = "Կրկնօրինակ է։ Չվաճարե՛լ։ ";
            //if (DoNotPai.Length > 0)
            //{
            //    DataRow newRow11 = BillReport.NewRow();
            //    BillReport.Rows.Add(newRow11);
            //    newRow11["name"] = DoNotPai;
            //}


            ReportManager reportManager = new ReportManager();
            reportManager.PreviewReport("BillReport", $"d:\\hayrik\\sql\\windowsformsapp4\\BillReport.rdlc", BillReport, parameters, null);

        }
    }
}