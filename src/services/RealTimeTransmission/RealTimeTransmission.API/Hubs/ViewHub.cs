using Microsoft.AspNetCore.SignalR;
using RealTimeTransmission.API.MessageHandlers;
using System;
using System.Threading.Tasks;

namespace RealTimeTransmission.API.Hubs
{
    public class ViewHub : Hub
    {
        public int ViewCount { get; set; }

      
        /// <summary>
        /// Happens whenever the new connection occurs
        /// </summary>
        /// <returns>Asynchronous task</returns>
        public async override Task OnConnectedAsync()
        {
            ViewCount++;
            await this.Clients.All.SendAsync("viewCountUpdate", ViewCount);
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// Happens whenever the closing connection occurs
        /// </summary>
        /// <returns>Asynchronous task</returns>
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            ViewCount--;
            await this.Clients.All.SendAsync("viewCountUpdate", ViewCount);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
