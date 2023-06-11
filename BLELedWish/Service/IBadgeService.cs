using BLELedWish.Model;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BLELedWish.Service
{
    public interface IBadgeService : INotifyPropertyChanged
    {

        public Task SendMessage(MessageLED message);

        public Task<bool> Connect(string address, int port);

        public Task<bool> Disconnect();

        public abstract string LastErrorMessage { get; }

    }
}
