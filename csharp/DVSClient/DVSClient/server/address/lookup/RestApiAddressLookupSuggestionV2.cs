using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupSuggestionV2
    {
        [JsonProperty("text")]
        public string? Text { get; set; }
        [JsonProperty("matched")]
        public IEnumerable<int>? Matched { get; set; }
        [JsonProperty("global_address_key")]
        public string? GlobalAddressKey { get; set; }
        [JsonProperty("format")]
        public string? Format { get; set; }
        [JsonProperty("dataset")]
        public string? Dataset { get; set; }
        [JsonProperty("names")]
        public IEnumerable<string>? Names { get; set; }
        [JsonProperty("uprn")]
        public string? Uprn { get; set; }


    }
}