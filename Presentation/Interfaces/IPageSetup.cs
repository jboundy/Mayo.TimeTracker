﻿using Microsoft.Extensions.Caching.Memory;
using Presentation.Dependencies;
using Services.Interfaces;

namespace Presentation.Interfaces
{
    public interface IPageSetup
    {
        void InitializeTimer(ITimerService timerService);
        void InitalizeReport(IReportService reportService);
        void UserSetup(UserInformation userInfo);
    }
}
