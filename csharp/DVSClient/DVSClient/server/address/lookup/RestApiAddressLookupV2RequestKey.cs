using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupV2RequestKey
    {
        
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("value")]
        public string? Value { get; set; }

    }
}