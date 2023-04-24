using BLELedWish.ViewModel;
using System.Windows;

namespace BLELedWish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new HomeViewModel();
        }
    }
}
