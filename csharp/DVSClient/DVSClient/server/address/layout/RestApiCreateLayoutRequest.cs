using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class RestApiCreateLayoutRequest
    {
        [JsonProperty("layout")]
        public RestApiAddressLayout? Layout { get; set; }

        public static RestApiCreateLayoutRequest Using(Common.Configuration configuration)
        {
            return new RestApiCreateLayoutRequest();
        }
    }
}