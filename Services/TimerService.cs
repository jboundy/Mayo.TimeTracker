using DAL;
using Services.Interfaces;
using Services.Models;
using System.Threading.Tasks;

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
            if(task != null)
            {
                var newModel = new TimeAlloted
                {
                    start = model.start,
                    elapsedTime = model.timeElapsed,
                    taskId = task.id,
                    amount = model.amount
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
