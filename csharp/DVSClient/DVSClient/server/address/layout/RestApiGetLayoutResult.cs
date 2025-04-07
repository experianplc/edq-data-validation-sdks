using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiGetLayoutResult
    {
        [JsonProperty("layout")]
        public RestApiGetLayoutLayout? Layout { get; set; }
    }
}
