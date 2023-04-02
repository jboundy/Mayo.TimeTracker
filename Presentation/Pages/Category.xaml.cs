using Presentation.Dependencies;
using Presentation.Interfaces;
using Presentation.Pages;
using Services.Interfaces;
using Services.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : Page, IPageSetup
    {

        public TimeSpan TimeElapsed { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; internal set; }
        private ITimerService _timerService;
        private UserInformation _userInfo;
        private Timer _timerPage;
        private IReportService _reportService;

        public Category()
        {
            _timerPage = new Timer();
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var checkedValue = ControlGrid.Children.OfType<RadioButton>()
                        .FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);

            if(checkedValue != null)
            {
                var content = checkedValue.Content;
                var nameFind = checkedValue.Name.Remove(0, 2);
                var textBox = ControlGrid.Children.OfType<TextBox>()
                            .FirstOrDefault(t => t.Name == $"tb{nameFind}");

                if(textBox != null)
                {
                    var timeInfo = new TimeInfo
                    {
                        firstName = _userInfo.FirstName,
                        lastName = _userInfo.LastName,
                        taskType = nameFind,
                        timeElapsed = TimeElapsed,
                        start = StartTime,
                        end = EndTime,
                        amount = textBox.Text
                    };

                    var saved =  await _timerService.InsertNewTime(timeInfo);

                    if (saved)
                    {
                        MessageBox.Show("Data saved");
                        //hack: empty the content on the window and replace with new content is the "navigation"
                        var wnd = Window.GetWindow(this);
                        wnd.Content = new { };
                        InitializeDependencies();
                        wnd.Content = _timerPage;
                    }
                }
                else
                {
                    MessageBox.Show("Input for category has no data");
                }
            }
            else
            {
                MessageBox.Show("No category has been selected");
            }
        }

        private void InitializeDependencies()
        {
            _timerPage.InitializeTimer(_timerService);
            _timerPage.InitalizeReport(_reportService);
            _timerPage.UserSetup(_userInfo);
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
