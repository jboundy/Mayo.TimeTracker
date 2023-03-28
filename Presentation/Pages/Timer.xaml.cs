using Services.Interfaces;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Presentation.Pages
{
    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class Timer : Page
    {
        private Stopwatch _timerWatch { get; set; }

        private Category _catPage;

        public Timer()
        {
            InitializeComponent();
            _timerWatch = new Stopwatch();
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
                _catPage.TimeElapsed = _timerWatch.Elapsed;
                NavigationService.Navigate(_catPage);
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            rbTimeStarted.IsChecked = true;
            _catPage.StartTime = DateTime.Now;
            _timerWatch.Start();
        }
    }
}
