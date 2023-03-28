using Microsoft.EntityFrameworkCore;

namespace DAL.Seed
{
    public class ActivityTaskSeeder
    {
        private readonly ModelBuilder modelBuilder;
        public ActivityTaskSeeder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            modelBuilder.Entity<ActivityTask>().HasData(
                new ActivityTask { id = 1, type = "ClaimScrubber" },
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
            );

        }
    }
}
