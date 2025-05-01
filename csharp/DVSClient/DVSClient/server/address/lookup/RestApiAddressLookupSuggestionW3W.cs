using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupSuggestionW3W
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("description")]
        public string? Description { get; set; }

    }
}