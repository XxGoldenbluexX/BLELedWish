using CommunityToolkit.Mvvm.ComponentModel;

namespace BLELedWish.Model
{
    public partial class MessageLED : ObservableObject, IMessageBadge
    {
        [ObservableProperty]
        private string message = "TEST";

        [ObservableProperty]
        private bool enabled = true;
    }
}
