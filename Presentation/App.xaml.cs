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
               .Build();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var services = new ServiceCollection();
            IConfiguration configuration;

            configuration = new ConfigurationBuilder()
                .AddJsonFile(@"appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<TimeTrackerContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("Default")));

            services.AddSingleton<TimeTrackerContext>();
            services.AddSingleton<ITimerService, TimerService>();
            services.AddSingleton<IReportService, ReportService>();

            services.AddTransient<MainWindow>();

            var serviceProvider = services.BuildServiceProvider();

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }
    }
}
