using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupSuggestionPostalCode
    {
        [JsonProperty("full_name")]
        public string? FullName { get; set; }
        [JsonProperty("primary")]
        public string? Primary { get; set; }
        [JsonProperty("secondary")]
        public string? Secondary { get; set; }

   }
}
