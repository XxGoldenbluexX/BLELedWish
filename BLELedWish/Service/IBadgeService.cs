using BLELedWish.Model;
using System.Threading.Tasks;

namespace BLELedWish.Service
{
    public interface IBadgeService
    {

        public Task SendMessage(IMessageBadge message);

    }
}
