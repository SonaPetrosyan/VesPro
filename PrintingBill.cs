using ReportPrinter;
using System;
using System.Collections.Generic;
using System.Data;

namespace WindowsFormsApp4
{
    public static class PrintingBill
    {
        public static void PrintBill(string bill, string nest,  string gid,
            string TipMoney, decimal paid, decimal previous, DateTime DateBegin, DateTime DateEnd, DataTable dataTable, string restaurantname, string language)
        {
            bill= bill.Trim(); nest= nest.Trim(); 
            gid=gid.Trim(); TipMoney= TipMoney.Trim();
            //        DataTable CurrentOrder = new DataTable("CurrentOrder");

            DataTable BillReport = new DataTable();
            BillReport.Columns.Add("code", typeof(string));
            BillReport.Columns.Add("name", typeof(string));
            BillReport.Columns.Add("price", typeof(float));
            BillReport.Columns.Add("quantity", typeof(float));
            BillReport.Columns.Add("salesamount", typeof(float));


            string code = "";
            float sales = 0;
            float Total = 0;
            float service = 0;
            float discount = 0;
            string Sum = "Գումար", Disc = "- զեղչ %", Gid = "- Գիդ", TipM = "+ թեյավճար", Tot = "Ընդամենը",
                Comm = "Ընդամենը: Կրկնօրինակ է։ Չվաճարե՛լ։ ", Paid = "Վճարված է ";
            if (language == "English")
            { 
                Sum = "Amount"; Disc = "- discount %"; Gid = "- Gid"; TipM = "+ tip"; Tot = "Total";
                Comm = "Total. Duplicate. dont Pai. "; Paid = "Paid ";
            }
            if (language == "Espaniol")
            {
                Sum = "Cantidad"; Disc = "- % de descuento"; Gid = "- Gid"; TipM = "+ propina"; Tot = "Total";
                Comm = "Total. Duplicado. No pagar."; Paid = "Pagado ";
            }
            if (language == "Russian")
            {
                Sum = "Сумма"; Disc = "- скидка %"; Gid = "- Гид"; TipM = "+ чаевые"; Tot = "Итого";
                Comm = "Итого. Дубликат. Не оплатить."; Tot = "Оплачено";
            }
            if (language == "German")
            {
                Sum = "Betrag"; Disc = "- Rabatt %"; Gid = "- Gid"; TipM = "+ Spitze"; Tot = "Gesamt";
                Comm = "Gesamt. Duplikat. Nicht bezahlen. "; Tot = "Bezahlt";
            }

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
                sales = sales + float.Parse(row["salesamount"].ToString());
            }
            DataRow newRow1 = BillReport.NewRow();
            BillReport.Rows.Add(newRow1);
            DataRow newRow2 = BillReport.NewRow();
            BillReport.Rows.Add(newRow2);
            newRow2["name"] = Sum; newRow2["salesamount"] = sales;//"Գումար"
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
                newRow4["name"] = Disc; newRow4["salesamount"] = discount;//"- զեղչ %"
                Total = Total - discount;
            }
            if (gid.Length > 0 && gid != "0")
            {
                DataRow newRow5 = BillReport.NewRow();
                BillReport.Rows.Add(newRow5);
                newRow5["name"] = Gid; newRow5["salesamount"] = float.Parse(gid);//"- Գիդ"
                Total = Total - float.Parse(gid);

            }
            DataRow newRow6 = BillReport.NewRow();
            BillReport.Rows.Add(newRow6);
            foreach (DataRow row in dataTable.Rows)
            {
                if (int.Parse(row["Free"].ToString()) != 1) continue;//  հետո տպում  ենք սպասարկման կամ զեղչից ազատները
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
                sales = sales + float.Parse(row["salesamount"].ToString());
            }


         //   if (TipMoney.Length > 0 && TipMoney != "0")
         //   {
                DataRow newRow7 = BillReport.NewRow();
                BillReport.Rows.Add(newRow7);
                newRow7["name"] = TipM; newRow7["salesamount"] = float.Parse(TipMoney);//"+ թեյավճար"
            Total = Total + float.Parse(TipMoney);
         //   }
            DataRow newRow8 = BillReport.NewRow();
            BillReport.Rows.Add(newRow8);

            DataRow newRow9 = BillReport.NewRow();
            BillReport.Rows.Add(newRow9);
            newRow9["name"] = Tot; newRow9["salesamount"] = Total;//"Ընդամենը"
            if ( previous == 1) newRow9["name"] =Comm;//"Ընդամենը: Կրկնօրինակ է։ Չվաճարե՛լ։ "
            if (paid == 1)
            {
                DataRow newRow11 = BillReport.NewRow();
                BillReport.Rows.Add(newRow11);
                newRow11["name"] = Paid; newRow11["salesamount"] = Total;//"Վճարված է "
            }


                Dictionary<string, object> parameters = new Dictionary<string, object>();
            string DoNotPai = "";
            parameters.Add("RestaurantName", restaurantname);
            parameters.Add("Bill", bill);
            parameters.Add("Nest", nest);
            parameters.Add("DateBegin", DateBegin);
            parameters.Add("DateEnd", DateEnd);

            string Report = FindFolder.Folder("Report")+ "\\BillReport.rdlc";

            ReportManager reportManager = new ReportManager();
            reportManager.PreviewReport("BillReport", Report, BillReport, parameters, null);
        }
    }
}