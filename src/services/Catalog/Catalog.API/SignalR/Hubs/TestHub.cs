using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Catalog.API.SignalR.Hubs
{
    public class TestHub : Hub
    {
        public async Task SendNewPosition(CourierMessage message)
        {
            await Clients.All.SendAsync("ReceivedNewPosition", new CourierMessage { Uid = message.Uid, Token = message.Token });
        }

    }
}
