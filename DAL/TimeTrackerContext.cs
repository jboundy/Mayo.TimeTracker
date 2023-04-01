using DAL.Seed;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TimeTrackerContext : DbContext
    {
        public TimeTrackerContext(DbContextOptions<TimeTrackerContext> options) : base(options)
        {

        }
        public virtual DbSet<ActivityTask> Tasks { get; set; }
        public virtual DbSet<TimeAlloted> TimeAllots { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ActivityTask>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<TimeAlloted>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Person>()
                .Property(e => e.id)
                .ValueGeneratedOnAdd();
            new ActivityTaskSeeder(modelBuilder).Seed();
            new PersonSeeder(modelBuilder).Seed();
        }
    }
}
