using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TimeTrackerContext : DbContext
    {
        public TimeTrackerContext(DbContextOptions<TimeTrackerContext> options) : base(options)
        {

        }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TimeAlloted> TimeAllots { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
