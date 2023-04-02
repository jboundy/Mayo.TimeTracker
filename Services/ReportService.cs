using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Services.Interfaces;
using Services.Models;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Text.Json;

namespace Services
{
    public class ReportService : IReportService
    {
        private TimeTrackerContext _context;

        public ReportService(TimeTrackerContext context)
        {
            _context = context;
        }

        public string GenerateDailyProductivity(DateTime date)
        {
            var beginningDate = date.Date;
            var endingDate = date.Date.AddDays(1).AddTicks(-1);
            var reportData = _context.TimeAlloted.Where(x => x.start >= beginningDate && x.end <= endingDate)
                .Include(nav => nav.ActivityTask)
                .Include(nav => nav.Person)
                .ToList();

            var jsonObject = BuildJsonObject(reportData);
            return ExportToJsonFile(jsonObject);
        }

        private string ExportToJsonFile<T>(List<T> jsonData)
        {
            var guid = Guid.NewGuid();
            var jsonDocument = JsonSerializer.Serialize(jsonData);
            File.WriteAllText($"C:\\rawdata-{guid}.json", jsonDocument);
            return $"C:\\rawdata-{guid}.json";
        }

        private List<ProductivitySchema> BuildJsonObject(List<TimeAlloted> dataSet)
        {
            return dataSet.Select(x => new ProductivitySchema
            {
                PersonName = $"{x.Person.firstname} {x.Person.lastname}",
                Date = x.start.Date.ToString("M/d/yyyy"),
                TaskDescription = x.ActivityTask.type,
                Duration = x.elapsedTime.ToString(),
                DescriptionInfo = x.amount,
                EndTime = x.end.ToString("h:mm:ss tt"),
                StartTime = x.start.ToString("h:mm:ss tt"),

            })
            .ToList();
        }
    }
}
