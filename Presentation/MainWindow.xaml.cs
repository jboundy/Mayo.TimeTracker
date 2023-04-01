using Microsoft.Extensions.Caching.Memory;
using Presentation.Dependencies;
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
        private UserInformation _userInfo;

        public MainWindow(ITimerService timerService, IReportService reportService, UserInformation userInfo)
        {
            InitializeComponent();
            _timerService = timerService;
            _reportService = reportService;
            _userInfo = userInfo;
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(_userInfo.FirstName == null || _userInfo.LastName == null){
                bLogin.Visibility = Visibility.Visible;
            }
            else
            {
                btnOk_Click(sender, e);
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var timerPageView = new Timer();
            timerPageView.InitializeTimer(_timerService);
            _userInfo.FirstName = tbFirst.Text;
            _userInfo.LastName = tbLast.Text;
            timerPageView.UserSetup(_userInfo);
            this.Content = timerPageView;

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
