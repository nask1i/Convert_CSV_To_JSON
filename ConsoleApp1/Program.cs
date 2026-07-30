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
            
            string[] lines = File.ReadAllLines(path);
            
            string[] headers = lines[0].Split(',');

            // var records = new List<Dictionary<string, string>>();
        
            //////////////////
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[");
            
            //////////////////
            
            for (int i = 1; i < lines.Length; i++)
            {
                
                int k = 0; 
                
                // var row = new Dictionary<string, string>();
                sb.AppendLine("  {");
                
                string[] values = lines[i].Split(',');

                for (int j = 0; j < headers.Length; j++)
                {
                    // row[headers[j]] = values[j];
                    string key = headers[j];
                    string value = values[j];
                    
                    sb.Append($"    \"{key}\": \"{value}\"");
                    
                    if (k < headers.Length - 1)
                    {
                        sb.AppendLine(",");
                    }
                    else
                    {
                        sb.AppendLine();
                    }
                    
                    k++;
                }
                
                if (i < lines.Length - 1)
                {
                    sb.AppendLine("  },");
                }
                else sb.AppendLine("  }");
                
            }
            
            // StringBuilder sb = new StringBuilder();

            // sb.AppendLine("[");

            sb.AppendLine("]");
            
            File.WriteAllText(JsonPathFile, sb.ToString());
        }
    }
}