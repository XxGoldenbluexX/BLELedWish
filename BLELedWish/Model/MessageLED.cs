using CommunityToolkit.Mvvm.ComponentModel;

namespace BLELedWish.Model
{
    public class MessageLED : ObservableObject
    {

        private string _message;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private bool _selected;

        public bool Selected {
            get => _selected;
            set => SetProperty(ref _selected, value);
        }

    }
}
