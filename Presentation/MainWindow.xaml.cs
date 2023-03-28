using Presentation.Interfaces;
using Presentation.Pages;
using Services.Interfaces;
using System.Windows;


namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ITimerService _timerService;
        public IReportService _reportService;
        public MainWindow(ITimerService timerService, IReportService reportService)
        {
            InitializeComponent();
            _timerService = timerService;
            _reportService = reportService;
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var timerPageView = new Timer();
            timerPageView.InitializeTimer(_timerService);
            this.Content = timerPageView;
        }
    }
}
