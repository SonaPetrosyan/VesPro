using System.Data;

namespace WindowsFormsApp4
{
   
        public class AppendFrom  // select table1; append from table2
        {
            public void AddRowsToTable(DataTable table1, DataTable table2)
            {
                // Ensure the structures (columns) of seans and Cur_order match
                if (StructureMatches(table1, table2))
                {
                    // Append rows from Cur_order to seans
                    foreach (DataRow row in table2.Rows)
                    {
                        table1.ImportRow(row); // Copy the rows from Cur_order to seans
                    }
                }
                else
                {
                    // Handle the case where the structures don't match (throw an exception, log an error, etc.)
                }
            }

            // Method to check if the structures (columns) of two DataTables match
            private bool StructureMatches(DataTable table1, DataTable table2)
            {
                if (table1.Columns.Count != table2.Columns.Count)
                {
                    return false; // Number of columns doesn't match
                }

                for (int i = 0; i < table1.Columns.Count; i++)
                {
                    if (table1.Columns[i].DataType != table2.Columns[i].DataType)
                    {
                        return false; // Data types of columns don't match
                    }
                }

                return true; // Structures (columns) match
            }
        }
    }



