using Microsoft.AspNetCore.SignalR;
using SignalR_basic_.Interfaces;

namespace SignalR_basic_.Hubs
{
    public class MyHub:Hub<IMessageClient>
    {
        static List<string> clients=new List<string>();
        //public async Task Message(string message)
        //{

        //    await Clients.All.SendAsync("receiveMessage", message);
        //}
            public override async Task OnConnectedAsync()
        {
            //clients.Add(Context.ConnectionId);
            //await Clients.All.SendAsync("Clients", clients);
            //await Clients.All.SendAsync("UserJoined",Context.ConnectionId);
             await Clients.All.Clients(clients);
             await Clients.All.UserJoined(Context.ConnectionId);
            
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //clients.Remove(Context.ConnectionId);
            //await Clients.All.SendAsync("Clients", clients);
            //await Clients.All.SendAsync("UserLeaved", Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeaved(Context.ConnectionId);
        }
        
    }
}

