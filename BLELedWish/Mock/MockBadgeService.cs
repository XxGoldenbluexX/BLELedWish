using BLELedWish.Model;
using BLELedWish.Service;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BLELedWish.Mock
{
    public class MockBadgeService : IBadgeService
    {
        public async Task SendMessage(IMessageBadge message)
        {
            await Task.Delay(10000);
            Trace.WriteLine("Sent");
        }
    }
}
