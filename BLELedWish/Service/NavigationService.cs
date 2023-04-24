using CommunityToolkit.Mvvm.DependencyInjection;

namespace BLELedWish.Service
{
    public class NavigationService
    {
        private MainWindow window;

        public void Setup(MainWindow window)
        {
            this.window = window;
        }

        public void GoTo<T>() where T : class
        {
            var vm = Ioc.Default.GetService<T>();
            window.DataContext = vm;
        }

    }
}
