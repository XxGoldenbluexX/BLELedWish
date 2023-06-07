using CommunityToolkit.Mvvm.ComponentModel;

namespace BLELedWish.Model
{
    public partial class MessageLED : ObservableObject
    {

        [ObservableProperty]
        private string message;

        [ObservableProperty]
        private bool selected;
    }
}
