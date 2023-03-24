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
        public Stopwatch TimerWatch { get; set; }
        public Timer()
        {
            InitializeComponent();
            TimerWatch = new Stopwatch();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            TimerWatch.Stop();
            var page = new Category(TimerWatch.Elapsed);
            NavigationService.Navigate(page);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            TimerWatch.Start();
        }
    }
}
