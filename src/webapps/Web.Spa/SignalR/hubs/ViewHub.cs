using AspnetCore.React.Redux.Web.SignalR.handlers;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Transports;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCore.React.Redux.Web.Hubs
{
    public class ViewHub : Microsoft.AspNetCore.SignalR.Hub
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

            await this.Clients.All.SendAsync("viewCountUpdate", ViewCount);
        }


        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
       
        




    }
}
