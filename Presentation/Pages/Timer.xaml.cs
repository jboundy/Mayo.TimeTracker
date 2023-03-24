using System;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.Pages
{
    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class Timer : Page
    {
        public Timer()
        {
            InitializeComponent();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {

            var buttonClicked = e.OriginalSource as NavButton;

            NavigationService.Navigate(buttonClicked.NavUri);
        }
    }
}
