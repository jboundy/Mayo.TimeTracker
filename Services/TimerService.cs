using DAL;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class TimerService : ITimerService
    {
        private TimeTrackerContext _context;

        public TimerService(TimeTrackerContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertNewTime(TimeInfo model)
        {
            var newModel = new TimeAlloted
            {
                start = DateTime.Now.AddMinutes(-30),
                end = DateTime.Now,
                amount = model.timeElapsed.ToString(),
                taskId = 1
            };

            _context.TimeAllots.Add(newModel);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
