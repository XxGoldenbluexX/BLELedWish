using BLELedWish.ViewModel;
using CommunityToolkit.Mvvm.DependencyInjection;
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

            Ioc.Default.ConfigureServices(s => s);

        }

    }
}
