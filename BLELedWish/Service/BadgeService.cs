using BLELedWish.Model;
using System;
using System.ComponentModel;
using System.Net;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task Connect(string address, int port)
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(address, port);
                lastErrorMessage = string.Empty;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(LastErrorMessage)));
            }catch(Exception e)
            {
                lastErrorMessage = e.Message;
            }
            
        }

        public async Task Disconnect()
        {
            try
            {
                client.GetStream().Close();
                client.Dispose();
                lastErrorMessage = string.Empty;
            }
            catch (Exception e)
            {
                lastErrorMessage = e.Message;
            }
        }

        public async Task SendMessage(MessageLED message)
        {
            try
            {
                var msg = LEDService.CreateMessage(message.Message);
                var data = Encoding.ASCII.GetBytes(msg);
                await client.GetStream().WriteAsync(data, 0, data.Length);
            }catch(Exception e)
            {
                lastErrorMessage = e.Message;
            }
        }
    }
}
