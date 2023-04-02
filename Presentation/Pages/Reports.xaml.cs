using Presentation.Dependencies;
using Presentation.Interfaces;
using Services.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Page, IPageSetup
    {
        private IReportService _reportService;

        public Reports()
        {
            InitializeComponent();
        }

        private void btnDaily_Click(object sender, RoutedEventArgs e)
        {
            var path = _reportService.GenerateDailyProductivity(DateTime.Now);
            MessageBox.Show($"Created file at path: {path}");
        }

        public void InitializeTimer(ITimerService timerService)
        {
            throw new System.NotImplementedException();
        }

        public void InitalizeReport(IReportService reportService)
        {
            _reportService = reportService;
        }

        public void UserSetup(UserInformation userInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}
