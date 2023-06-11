using BLELedWish.Model;
using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLELedWish.Service
{
    public class BadgeService : IBadgeService
    {
        private TcpClient client;

        private string lastErrorMessage;

        public string LastErrorMessage => lastErrorMessage;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string address;

        private int port;

        public async Task<bool> Connect(string address, int port)
        {
            try
            {
                //client = new TcpClient();
                //await client.ConnectAsync(address, port);
                //client.Close();
                //client.Dispose();
                this.address = address;
                this.port = port;
                return true;
            }catch(Exception e)
            {
                SetLastError(e.Message);
            }
            return false;
        }

        public async Task<bool> Disconnect()
        {
            try
            {
                client.GetStream().Close();
                client.Dispose();
                SetLastError(string.Empty);
                return true;
            }
            catch (Exception e)
            {
                SetLastError(e.Message);
            }
            return false;
        }

        public async Task SendMessage(MessageLED message)
        {
            try
            {
                var msg = LEDService.CreateMessage(message.Message);
                var data = Encoding.ASCII.GetBytes(msg);

                using (client = new TcpClient()) {
                    await client.ConnectAsync(address, port);
                    await client.GetStream().WriteAsync(data, 0, data.Length);
                    await client.GetStream().FlushAsync();
                    client.GetStream().Close();
                }
                

                SetLastError(string.Empty);
            }
            catch(Exception e)
            {
                SetLastError(e.Message);
            }
        }
        private void SetLastError(string message)
        {
            lastErrorMessage = message;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(LastErrorMessage)));
        }
    }
}
