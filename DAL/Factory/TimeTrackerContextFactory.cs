using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Factory
{
    public class TimeTrackerContextFactory : IDesignTimeDbContextFactory<TimeTrackerContext>
    {
        public TimeTrackerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TimeTrackerContext>();
            optionsBuilder.UseSqlite("Data Source=c:\\timetracker.db;Version=3;");
            return new TimeTrackerContext(optionsBuilder.Options);
        }
    }
}
