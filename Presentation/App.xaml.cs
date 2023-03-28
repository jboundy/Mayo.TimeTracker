using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services;
using Services.Interfaces;
using System.Windows;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host
               .CreateDefaultBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddSingleton<MainWindow>();
                   //services.AddSingleton<SuperheroContext>();
                   services.AddSingleton<ITimerService, TimerService>();
                   services.AddSingleton<IReportService, ReportService>();

                   IConfiguration configuration;

                   configuration = new ConfigurationBuilder()
                       .AddJsonFile(@"appsettings.json")
                       .Build();

                   services.AddDbContext<TimeTrackerContext>(options =>
                       options.UseSqlite(configuration.GetConnectionString("Default")));
               })
               .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            startupForm.Show();

            base.OnStartup(e);
        }
    }
}
