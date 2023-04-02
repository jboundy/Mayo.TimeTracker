using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("TimeAlloted")]
    public class TimeAlloted
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public double elapsedTime { get; set; }
        public string? amount { get; set; }
        public ActivityTask ActivityTask { get; set; }
        public Person Person { get; set; }

    }
}
