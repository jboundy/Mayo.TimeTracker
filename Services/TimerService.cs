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
            var task = _context.Tasks.FirstOrDefault(x => x.type == model.taskType);
            var person = _context.People.FirstOrDefault(x => x.firstname == model.firstName && x.lastname == model.lastName);
            var lastRecord = _context.TimeAllots.OrderBy(x => x.id).Select(x => x.id).FirstOrDefault();
            if(task != null && person != null)
            {
                var newModel = new TimeAlloted
                {
                    id = lastRecord == 0 ? 1 : lastRecord + 1,
                    start = model.start,
                    end = model.end,
                    elapsedTime = model.timeElapsed,
                    amount = model.amount,
                    Person = person,
                    ActivityTask = task
                };
                _context.TimeAllots.Add(newModel);
                var saved = await _context.SaveChangesAsync() == 1;
                if (saved)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
