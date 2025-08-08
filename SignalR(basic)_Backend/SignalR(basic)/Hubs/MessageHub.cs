using Microsoft.AspNetCore.SignalR;

namespace SignalR_basic_.Hubs
{
    public class MessageHub:Hub
    {
        public async Task SendMessageAsync(string message,string groupName)
        {
            #region Caller
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion
            #region All
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion
            #region Other
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion


            #region AllExcept
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage",message);
            #endregion
            #region Client
            //await Clients.Client(connectionIds[0]).SendAsync("receiveMessage", message);
            #endregion
            #region Clients
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Group
            await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion
        }
        public override async Task OnConnectedAsync()
        {
           await Clients.Caller.SendAsync("getConnectionId",Context.ConnectionId);
        }
        public async Task AddGroup(string connectionId,string groupName)
        {
          await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
