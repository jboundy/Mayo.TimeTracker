using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("TimeAlloted")]
    [PrimaryKey("id")]
    public class TimeAlloted
    {
        [Key]
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public TimeSpan elapsedTime { get; set; }
        public string? amount { get; set; }
        public ActivityTask ActivityTask { get; set; }
        public Person Person { get; set; }

    }
}
