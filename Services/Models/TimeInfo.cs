using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public sealed class TimeInfo
    {
        public string taskType { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public TimeSpan timeElapsed { get; set; }
        public DateTime start { get; set; }
        public string amount { get; set; }
    }
}
