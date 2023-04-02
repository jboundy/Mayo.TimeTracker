using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("ActivityTask")]
    public class ActivityTask
    {
        public int id { get; set; }
        public string type { get; set; }
    }
}
