using System;
using System.Collections.Generic;
using System.Text;

namespace CSVMVP.Models
{
    public class CSVFile
    {
        public List<string> Headers { get; set; } = new List<string>();
        public List<Dictionary<string, string>> Records { get; set; } = new List<Dictionary<string, string>>();
        public int RecordCount { get; set; }
    }
}
