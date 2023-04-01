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
            var person = new Person { id = 1, firstname = "Justin", lastname = "Boundy" };
            var activities = GetAcitivites();
            var datetime = DateTime.Now;
            var model = new TimeAlloted
            {
                id = 1,
                amount = 1.ToString(),
                elapsedTime = new TimeSpan(0,0,30),
                start = DateTime.Now.AddMinutes(-1),
                end = datetime,
                Person = person,
                ActivityTask = activities.First()
            };

            var saved = false;
            try
            {
                _context.TimeAllots.Add(model);
                saved = _context.SaveChanges() == 1;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }


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

        private List<ActivityTask> GetAcitivites()
        {
            return new List<ActivityTask> {new ActivityTask { id = 1, type = "ClaimScrubber" },
                new ActivityTask { id = 2, type = "Correspondence" },
                new ActivityTask { id = 3, type = "CBR" },
                new ActivityTask { id = 4, type = "Education" },
                new ActivityTask { id = 5, type = "Emails" },
                new ActivityTask { id = 6, type = "ErrorChecks" },
                new ActivityTask { id = 7, type = "FollowDenial" },
                new ActivityTask { id = 8, type = "RmindersBillingInqu" },
                new ActivityTask { id = 9, type = "Meetings" },
                new ActivityTask { id = 10, type = "Reports" },
                new ActivityTask { id = 11, type = "Rycan" },
                new ActivityTask { id = 12, type = "SpecialProjects" },
                new ActivityTask { id = 13, type = "Training" },
                new ActivityTask { id = 14, type = "SystemIssues" },
                new ActivityTask { id = 15, type = "Break" },
                new ActivityTask { id = 16, type = "Other" }
            };
        }
    }
}