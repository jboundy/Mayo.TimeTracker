using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IReportService
    {
        string GenerateDailyProductivity(DateTime date);
    }
}
