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
        public Stopwatch _timerWatch { get; set; }
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
                var page = new Category(_timerWatch.Elapsed);
                NavigationService.Navigate(page);
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            rbTimeStarted.IsChecked = true;
            _timerWatch.Start();
        }
    }
}
