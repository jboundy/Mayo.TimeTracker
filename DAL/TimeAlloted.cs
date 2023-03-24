using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TimeAlloted
    {
        public int id { get; set; }
        public int taskId { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public string? amount { get; set; }

    }
}
