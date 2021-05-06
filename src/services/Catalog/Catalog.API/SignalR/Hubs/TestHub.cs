using Catalog.API.SignalR.Handlers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Catalog.API.SignalR.Hubs
{
    public class TestHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            TestHandler.ConnectedIds.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            TestHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendNewPosition(CourierMessage message)
        {
            await Clients.All.SendAsync("ReceivedNewPosition", new CourierMessage { Uid = message.Uid, Token = message.Token });
        }

    }
}
