using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace DAL.Tests
{
    [TestClass]
    public class TimeAllotedTests
    {
        private TimeTrackerContext _context;

        public TimeAllotedTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TimeTrackerContext>();
            optionsBuilder.UseSqlite(@"Data Source=C:\timetracker.db;");
            _context = new TimeTrackerContext(optionsBuilder.Options);
        }

        [TestMethod]
        public void CanAddTime()
        {
            var model = new TimeAlloted
            {
                amount = 1.ToString(),
                elapsedTime = new TimeSpan(0,0,30),
                start = DateTime.Now,
                taskId = 1
            };

            _context.TimeAllots.Add(model);
            var saved =  _context.SaveChanges() == 1;

            Assert.IsTrue(saved);
        }

        [TestMethod]
        public void CanGetTimeById()
        {
            var record = _context.TimeAllots.Find(1);

            Assert.IsTrue(record?.id == 1);
        }

        [TestCleanup]
        public void CleanUpDb()
        {
            _context.Database.ExecuteSqlRaw("$delete from timealloted");
        }
    }
}