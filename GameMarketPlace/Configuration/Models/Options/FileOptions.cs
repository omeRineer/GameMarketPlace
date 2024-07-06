using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Models.Options
{
    public class FileOptions
    {
        public string Assembly { get; set; }
        public string[] Extensions { get; set; }
        public string FilePath { get; set; }
        public string RequestPath { get; set; }
    }

}
