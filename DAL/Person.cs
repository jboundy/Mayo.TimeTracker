using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL
{
    [Table("Person")]
    public class Person
    {
        public int id { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }
    }
}
