using CSVMVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVMVP.Services
{
    public class CSVService
    {
        public CSVFile GetCSVFileFromFileContents(string fileContents)
        {
            var csv = new CSVFile();

            string[] rows = null;
            if(fileContents.Contains(Environment.NewLine))
            {
                rows = fileContents.Split(Environment.NewLine);
            }
            else
            {
                rows = fileContents.Split("\n");
            }

            var isHeader = true;
            foreach(var row in rows)
            {
                if(String.IsNullOrEmpty(row))
                {
                    continue;
                }
                if(isHeader)
                {
                    csv.Headers = row.Split(',').ToList();
                    isHeader = false;
                }
                else
                {
                    var record = new Dictionary<string, string>();
                    var rowValues = row.Split(",");
                    for(var i = 0; i < csv.Headers.Count; i++)
                    {
                        record.Add(csv.Headers[i], rowValues[i]);
                    }
                    csv.Records.Add(record);
                }
            }

            csv.RecordCount = csv.Records.Count;

            return csv;
        }
    }
}
