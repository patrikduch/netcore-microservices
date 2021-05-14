using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Catalog.API.SignalR.Hubs
{
    public class TestHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
        public async Task SendNewPosition(CourierMessage message)
        {
            await Clients.All.SendAsync("ReceivedNewPosition", new CourierMessage { Uid = message.Uid, Token = message.Token });
        }

    }
}
