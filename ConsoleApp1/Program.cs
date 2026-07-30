using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            
            var JsonPathFile = Path.ChangeExtension(path, ".json");
            
            //i took all the lines
            string[] lines = File.ReadAllLines(path);
            
            //i extracted the header
            string[] headers = lines[0].Split(',');

            var records = new List<Dictionary<string, string>>();
        
            // i loop throught those lines and in the end save them to records
            for (int i = 1; i < lines.Length; i++)
            {
                var row = new Dictionary<string, string>();
                
                string[] values = lines[i].Split(',');

                for (int j = 0; j < headers.Length; j++)
                {
                    row[headers[j]] = values[j];
                }
                
                records.Add(row);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("[");
            
            // next i can iterate thru each record take the rows
            //and append the rows into the stringBuilder in respects of JSON format?
            
            for (int i = 0; i < records.Count; i++)
            {
                var rows = records[i];
                
                sb.AppendLine("  {");

                int k = 0; 
                    
                foreach (var keyValuePair in rows)
                {
                    string key = keyValuePair.Key;
                    string value = keyValuePair.Value;

                    sb.Append($"    \"{key}\": \"{value}\"");

                    //ill need tracker
 
                    
                    if (k < rows.Count - 1)
                    {
                        sb.AppendLine(",");
                    }
                    else
                    {
                        sb.AppendLine();
                    }

                    k++;
                }

                if (i < records.Count - 1)
                {
                    sb.AppendLine("  },");
                }
                else sb.AppendLine("  }");

            }

            sb.AppendLine("]");
            File.WriteAllText(JsonPathFile, sb.ToString());
        }
    }
}