using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Navigation;
using BLELedWish.Service;
using System;

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

        [RelayCommand]
        private async void CloseError()
        {
            IsPopupOpen = false;
        }

        [RelayCommand]
        private async void Validate()
        {
            int portInt;
            var badge = Ioc.Default.GetService<IBadgeService>();
            if (Int32.TryParse(Port, out portInt))
            {
                if(!await badge.Connect(Addr, portInt))
                {
                    ErrorMess = badge.LastErrorMessage;
                    IsPopupOpen = true;
                }
                else
                {
                    var nav = Ioc.Default.GetService<BLELedWish.Service.NavigationService>();
                    nav.GoTo<MessageListViewModel>();
                }
            }
            else
            {
                ErrorMess = "Le port n'est pas valide";
                IsPopupOpen = true;
            }

        }

    }
}
