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
            //todo: figure out how to not make 3 trips to the datbase to get necessary info. 
            //ideas: We should be able to extract the person record at startup and pass the user into the method here

            var task = _context.Tasks.FirstOrDefault(x => x.type == model.taskType);
            var person = _context.People.FirstOrDefault(x => x.firstname == model.firstName && x.lastname == model.lastName);
            var lastRecord = _context.TimeAlloted.OrderBy(x => x.id).Select(x => x.id).LastOrDefault();
            if(task != null && person != null)
            {
                var time = TimeSpan.FromMinutes(model.timeElapsed.TotalMinutes);
                var calculatedElapsedTime = Math.Round(time.TotalHours, 2);
                var newModel = new TimeAlloted
                {
                    id = lastRecord == 0 ? 1 : lastRecord + 1,
                    start = model.start,
                    end = model.end,
                    elapsedTime = calculatedElapsedTime,
                    amount = model.amount,
                    Person = person,
                    ActivityTask = task
                };
                _context.TimeAlloted.Add(newModel);
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
