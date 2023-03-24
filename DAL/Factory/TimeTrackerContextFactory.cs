using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Factory
{
    public class TimeTrackerContextFactory : IDesignTimeDbContextFactory<TimeTrackerContext>
    {
        public TimeTrackerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TimeTrackerContext>();
//todo: add whatever dbcontextbuilder option conneciton thingy here
            return new TimeTrackerContext(optionsBuilder.Options);
        }
    }
}
