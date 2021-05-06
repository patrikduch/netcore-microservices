using Newtonsoft.Json;

namespace Catalog.API.SignalR
{
    public class CourierMessage
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
