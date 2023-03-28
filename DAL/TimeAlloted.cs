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
        public DateTime start { get; set; }
        public TimeSpan elapsedTime { get; set; }
        public string? amount { get; set; }
        public int taskId { get; set; }
        public ActivityTask ActivityTask { get; set; }

    }
}
