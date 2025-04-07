using Newtonsoft.Json;

namespace DVSClient.Server.Address.Search
{
    public class RestApiSearchResultSuggestion
    {
        [JsonProperty("global_address_key")]
        public string? GlobalAddressKey { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("matched")]
        public IEnumerable<IEnumerable<int>>? Matched { get; set; }

        [JsonProperty("format")]
        public string? FormatUrl { get; set; }

        [JsonProperty("dataset")]
        public string? Dataset { get; set; }

        [JsonProperty("additional_attributes")]
        public IEnumerable<RestApiSearchResultAdditionalAttribute>? AdditionalAttributes { get; set; }
    }
}
