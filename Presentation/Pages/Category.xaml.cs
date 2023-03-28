using Presentation.Interfaces;
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
        public ITimerService TimerService;
        public TimeSpan TimeElapsed { get; set; }
        public DateTime StartTime { get; set; }
        public Category()
        {
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
                    //get all content and save to db
                    var timeInfo = new TimeInfo
                    {
                        firstName = "test",
                        lastName = "last",
                        taskType = nameFind,
                        timeElapsed = TimeElapsed,
                        start = StartTime,
                        amount = textBox.Text
                    };

                    var saved =  await TimerService.InsertNewTime(timeInfo);

                    if (saved)
                    {
                        MessageBox.Show("Data saved");
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

        public void InitializeTimer(ITimerService timerService)
        {
            TimerService = timerService;
        }

        public void IntializeReport(IReportService reportService)
        {
            throw new NotImplementedException();
        }
    }
}
