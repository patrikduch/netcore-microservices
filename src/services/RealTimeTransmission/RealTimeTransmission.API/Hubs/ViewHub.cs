using Microsoft.AspNetCore.SignalR;
using RealTimeTransmission.API.MessageHandlers;
using System;
using System.Threading.Tasks;

namespace RealTimeTransmission.API.Hubs
{
    public class ViewHub : Hub
    {
        public int ViewCount { get; set; }

        public override Task OnConnectedAsync()
        {

            UserHandler.ConnectedIds.Add(Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public async Task NotifyWatching()
        {
            ViewCount = UserHandler.ConnectedIds.Count;

            await this.Clients.All.SendAsync("viewCountUpdate", 1);
        }


        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
