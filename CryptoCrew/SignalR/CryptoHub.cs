using Microsoft.AspNet.SignalR;
using Owin;
using System;
using System.Reflection;
using System.Threading.Tasks;
using CryptoCrew.Authentication;

namespace CryptoCrew.SignalR
{
    public class CryptoHub : Hub
    {
        public void Send(string name, string message)
        {
            //string random = RandomString.generate(5, false);

            //string encrypted = StringEncryption.Encrypt(message);

            Clients.All.addMessage(name, message);
        }
        public override Task OnConnected()
        {
            //Program.MainForm.WriteToConsole("Client connected: " + Context.ConnectionId);
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stop)
        {
            //Program.MainForm.WriteToConsole("Client disconnected: " + Context.ConnectionId);
            return base.OnDisconnected(stop);
        }
    }
}