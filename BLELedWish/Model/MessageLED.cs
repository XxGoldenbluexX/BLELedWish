using CommunityToolkit.Mvvm.ComponentModel;

namespace BLELedWish.Model
{
    public partial class MessageLED : ObservableObject, IMessageBadge
    {
        [ObservableProperty]
        private string message = string.Empty;

        // UNE IMAGE

    }
}
