using BLELedWish.Model;
using System.Collections.ObjectModel;

namespace BLELedWish.ViewModel
{
    public class HomeViewModel
    {

        public HomeViewModel()
        {
            Messages = new ObservableCollection<MessageLED>();

            for (int i = 0; i < 8; i++)
            {
                Messages.Add(new MessageLED() { Message = $"Message {i}" });
            }
        }

        public ObservableCollection<MessageLED> Messages { get; set; }

    }
}