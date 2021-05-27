using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace RealTimeTransmission.API.Hubs
{
    public class ViewHub : Hub<IViewHub>
    {
        public int ViewCount { get; set; } = 0;

        /// <summary>
        /// Happens whenever the new connection occurs
        /// </summary>
        /// <returns>Asynchronous task</returns>
        public async override Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// Happens whenever the closing connection occurs
        /// </summary>
        /// <returns>Asynchronous task</returns>
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// Notify users about total visitor count.
        /// </summary>
        /// <returns></returns>
        public async Task NotifyWatching()
        {
            ViewCount++;
            await Clients.All.ViewCountUpdate(ViewCount);
        }

    }
}
