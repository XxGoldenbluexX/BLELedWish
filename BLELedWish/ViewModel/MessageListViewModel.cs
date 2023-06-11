using BLELedWish.Model;
using BLELedWish.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace BLELedWish.ViewModel {
    public partial class MessageListViewModel : ObservableObject {

        [ObservableProperty]
        public bool _isPopupOpen;


        public MessageListViewModel() {
            messages.CollectionChanged += FilterMessages;
        }

        private void FilterMessages(object sender, NotifyCollectionChangedEventArgs e)
        {
            FilteredMessage = new ObservableCollection<MessageLED>(messages.Where(m => m.Message.Contains(filterText)));
        }

        private ObservableCollection<MessageLED> messages = new();

        private string filterText = string.Empty;

        [ObservableProperty] // La version de Visual Studio à l'IUT est trop vieille pour la génération de code
        private ObservableCollection<MessageLED> filteredMessage;

        [ObservableProperty]
        private MessageLED selectedMessage;

        [RelayCommand]
        private async void SendSelectedMessage()
        {
            await Ioc.Default.GetService<IBadgeService>()?.SendMessage(SelectedMessage);
        }

        [RelayCommand]
        private async void OpenModif()
        {
            IsPopupOpen = true;
        }

        [RelayCommand]
        private async void CloseModif()
        {
            IsPopupOpen = false;
        }

        [RelayCommand]
        private async void AddMessage()
        {
            messages.Add(new MessageLED());
        }

        [RelayCommand]
        private async void DeleteSelectedMessage()
        {
            messages.Remove(SelectedMessage);
        }

    }
}