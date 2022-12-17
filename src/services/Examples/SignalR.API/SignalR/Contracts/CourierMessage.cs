using Newtonsoft.Json;

namespace SignalR.API.SignalR.Contracts
{
    public class CourierMessage
    {
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
