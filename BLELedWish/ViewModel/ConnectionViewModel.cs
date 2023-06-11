using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Navigation;
using BLELedWish.Service;

namespace BLELedWish.ViewModel
{
    internal partial class ConnectionViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool _isPopupOpen;

        [ObservableProperty]
        public string _errorMess;

        [ObservableProperty]
        public string _addr;

        [ObservableProperty]
        public string _port;

        public ConnectionViewModel() { 
            IsPopupOpen = true;    
        }

        [RelayCommand]
        private async void CloseError()
        {
            IsPopupOpen = false;
        }

        [RelayCommand]
        private async void Validate()
        {
            var nav = Ioc.Default.GetService<BLELedWish.Service.NavigationService>();
            nav.GoTo<MessageListViewModel>();
        }

    }
}
