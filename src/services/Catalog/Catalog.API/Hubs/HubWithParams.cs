using Catalog.API.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace Catalog.API.Hubs
{
    public class HubWithParams : Hub
    {
        public CourierMessage NotifyWatching(string uId, string token)
        {

            return new CourierMessage
            {
                Token = token,
                Uid = uId
            };
        }
    }
}
