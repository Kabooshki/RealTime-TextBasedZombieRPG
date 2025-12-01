using ConsoleTables;
using System;
using System.Collections.Generic;

public class TextTable {
   public TextTable(string[] columns, string[][] rows) {
       var table = new ConsoleTable(new ConsoleTableOptions 
            {
                Columns = columns,
                EnableCount = false
            });
       foreach (string[] row in rows){
           table.AddRow(row);
       } 
       table.Write();
       Console.WriteLine();
   } 
}
