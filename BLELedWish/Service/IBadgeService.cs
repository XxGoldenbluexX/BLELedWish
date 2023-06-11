using BLELedWish.Model;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BLELedWish.Service
{
    public interface IBadgeService : INotifyPropertyChanged
    {

        public Task SendMessage(MessageLED message);

        public Task Connect(string address, int port);

        public Task Disconnect();

        public abstract string LastErrorMessage { get; }

    }
}
