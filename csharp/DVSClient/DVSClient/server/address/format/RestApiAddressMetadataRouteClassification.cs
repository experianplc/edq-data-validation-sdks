using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiAddressMetadataRouteClassification
    {
        [JsonProperty("carrier_route")]
        public string? CarrierRoute { get; set; }

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("elot")]
        public string? Elot { get; set; }
    }
}