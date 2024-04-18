using System;
using System.Data;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

public static class Translate
{
    public static void translation(DataTable Table1, DataTable Table2, string language, string mode )
    {
        if (mode=="1")
        {
            var query = from row1 in Table1.AsEnumerable()
                        join row2 in Table2.AsEnumerable()
                        on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                        from subRow2 in gj.DefaultIfEmpty()
                        select new
                        {
                            Row1 = row1,
                            Row2 = subRow2
                        };

            foreach (var item in query)
            {
                if (item.Row2 != null)
                {
                    if (language == "Armenian") item.Row2["Name"] = item.Row1["Armenian"];
                    if (language == "English") item.Row2["Name"] = item.Row1["English"];
                    if (language == "German") item.Row2["Name"] = item.Row1["German"];
                    if (language == "Russian") item.Row2["Name"] = item.Row1["Russian"];
                    if (language == "Espaniol") item.Row2["Name"] = item.Row1["Espaniol"];
                }
            }
        }
        if (mode == "2")
        {
            foreach (DataRow row in Table1.Rows)
            {
                if (language == "Armenian") row["Name"] = row["Armenian"];
                if (language == "English") row["Name"] = row["English"];
                if (language == "German") row["Name"] = row["German"];
                if (language == "Russian") row["Name"] = row["Russian"];
                if (language == "Espaniol") row["Name"] = row["Espaniol"];
            }

        }
        if (mode == "3")
        {
            var query = from row1 in Table1.AsEnumerable()
                        join row2 in Table2.AsEnumerable()
                        on row1.Field<string>("Code") equals row2.Field<string>("Code") into gj
                        from subRow2 in gj.DefaultIfEmpty()
                        select new
                        {
                            Row1 = row1,
                            Row2 = subRow2
                        };

            foreach (var item in query)
            {
                if (item.Row2 != null)
                {
                    item.Row2["Name"] = item.Row1["Armenian"];
                    
                }
            }
        }
    }
}
