using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Catalog.API.SignalR.Hubs
{
    public class TestHub : Hub
    {
        public async Task SendNewPosition(string uId, string token)
        {
            await Clients.All.SendAsync("ReceivedNewPosition", new CourierMessage { Uid = uId, Token = token });
        }

    }
}
