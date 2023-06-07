using BLELedWish.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace BLELedWish.ViewModel
{
    public partial class MessageListViewModel : ObservableObject
    {

        public MessageListViewModel()
        {
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
        private async void AddMessage()
        {
            messages.Add(new MessageLED());
        }

        [RelayCommand]
        private async void DeleteSelectedRow()
        {
            messages.Remove(SelectedMessage);
        }

    }
}