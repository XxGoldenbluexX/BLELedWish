using BLELedWish.Mock;
using BLELedWish.Service;
using BLELedWish.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BLELedWish
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            ConfigureServices();

            InitializeComponent();
        }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static void ConfigureServices()
        {
            var services = new ServiceCollection();
            
            services.AddSingleton<NavigationService>();
            services.AddSingleton<IBadgeService,LEDService>();

            // View Models
            services.AddTransient<MessageListViewModel>();

            Ioc.Default.ConfigureServices(services.BuildServiceProvider());
        }

    }
}
