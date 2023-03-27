using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Person
    {
        public int id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }
        public List<TimeAlloted> activities { get; set; }
    }
}
