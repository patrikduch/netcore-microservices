using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Catalog.API.Hubs
{
    public class ViewHub : Hub
    {
        public static int ViewCount { get; set; } = 0;

        public async Task NotifyWatching(string uId = "test", string token="tester")
        {
            await Clients.All.SendAsync("data", new { uId, token = token, });
        }

    }
}
