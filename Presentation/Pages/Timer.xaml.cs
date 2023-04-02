using Presentation.Dependencies;
using Presentation.Interfaces;
using Services;
using Services.Interfaces;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.Pages
{
    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class Timer : Page, IPageSetup
    {
        private Stopwatch _timerWatch { get; set; }
        public Category CategoryPage;
        private UserInformation _userInfo;
        private IReportService _reportService;
        public ITimerService _timerService;

        public Timer()
        {
            _timerWatch = new Stopwatch();
            InitializeComponent();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (!_timerWatch.IsRunning)
            {
                MessageBox.Show("Timer is not running");
            }
            else
            {
                _timerWatch.Stop();
                var currentTime = DateTime.Now;
                CategoryPage.StartTime = currentTime.Subtract(_timerWatch.Elapsed);
                CategoryPage.TimeElapsed = _timerWatch.Elapsed;
                CategoryPage.EndTime = currentTime;
                //hack: empty the content on the window and replace with new content is the "navigation"
                var wnd = Window.GetWindow(this);
                wnd.Content = new { };
                wnd.Content = CategoryPage;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            CategoryPage = new Category();
            InitializeDependencies();
            rbTimeStarted.IsChecked = true;
            _timerWatch.Start();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var reportPage = new Reports();
            reportPage.InitalizeReport(_reportService);
            var wnd = Window.GetWindow(this);
            wnd.Content = new { };
            wnd.Content = reportPage;
        }

        private void InitializeDependencies()
        {
            CategoryPage.InitializeTimer(_timerService);
            CategoryPage.InitalizeReport(_reportService);
            CategoryPage.UserSetup(_userInfo);
        }

        public void InitializeTimer(ITimerService timerService)
        {
            _timerService = timerService;
        }

        public void InitalizeReport(IReportService reportService)
        {
            _reportService = reportService;
        }

        public void UserSetup(UserInformation userInfo)
        {
            _userInfo = userInfo;
        }
    }
}
