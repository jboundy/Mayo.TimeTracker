using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Factory
{
    public class TimeTrackerContextFactory : IDesignTimeDbContextFactory<TimeTrackerContext>
    {
        public TimeTrackerContext CreateDbContext(string[] args)
        {
            var connectionString = "";
            if (args.Any())
            {
                connectionString = args[0];
            }
            else
            {
                connectionString = @"Data Source=C:\timetracker.db;";
            }
            var optionsBuilder = new DbContextOptionsBuilder<TimeTrackerContext>();
            optionsBuilder.UseSqlite(connectionString);
            return new TimeTrackerContext(optionsBuilder.Options);
        }
    }
}
