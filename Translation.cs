using System;
using System.Data;
using System.IO;
using System.Linq;

public static class Translation
{
    public static void ExportDataTableToCsv(DataTable dataTable, string filePath, string delimiter)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write column headers
            writer.WriteLine(string.Join(delimiter, dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName)));

            // Write data rows
            foreach (DataRow row in dataTable.Rows)
            {
                writer.WriteLine(string.Join(delimiter, row.ItemArray));
            }
        }
    }

    public static void AppendCsvToDataTable(DataTable dataTable, string filePath, string delimiter)
    {
        string[] lines = File.ReadAllLines(filePath);

        // Skip first line (header)
        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(new[] { delimiter }, StringSplitOptions.None);
            dataTable.Rows.Add(values);
        }
    }

    static DataTable GetDataTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("f1", typeof(string)); // Add columns as needed
        // Add data rows to table
        return table;
    }
}

