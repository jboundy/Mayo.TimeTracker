using Presentation.Dependencies;
using Presentation.Interfaces;
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
        public ITimerService TimerService;

        public Category CategoryPage;
        private UserInformation _userInfo;

        public Timer()
        {
            _timerWatch = new Stopwatch();
            InitializeComponent();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            //todo: need to make once instance of a datetime object to keep the time synced
            // remove StartTime initialization and calculate start time when button stop is clicked
            if (!_timerWatch.IsRunning)
            {
                MessageBox.Show("Timer is not running");
            }
            else
            {
                _timerWatch.Stop();
                CategoryPage.TimeElapsed = _timerWatch.Elapsed;
                
                //hack: empty the content on the window and replace with new content is the "navigation"
                var wnd = Window.GetWindow(this);
                wnd.Content = new { };
                wnd.Content = CategoryPage;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            CategoryPage = new Category();
            CategoryPage.InitializeTimer(TimerService);
            CategoryPage.UserSetup(_userInfo);
            rbTimeStarted.IsChecked = true;
            _timerWatch.Start();
        }

        public void InitializeTimer(ITimerService timerService)
        {
            TimerService = timerService;
        }

        public void IntializeReport(IReportService reportService)
        {
            throw new NotImplementedException();
        }

        public void UserSetup(UserInformation userInfo)
        {
            _userInfo = userInfo;
        }
    }
}
