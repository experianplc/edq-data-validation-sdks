using DVSClient.Server.Address.Format;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Suggestions
{
    public class RestApiSuggestionsFormatSuggestion
    {
        [JsonProperty("global_address_key")]
        public string? GlobalAddressKey { get; set; }

        [JsonProperty("address")]
        public RestApiFormatAddress? Address { get; set; }

        [JsonProperty("addresses_formatted")]
        public IEnumerable<RestApiAddressFormatted>? AddressesFormatted { get; set; }

        [JsonProperty("components")]
        public RestApiAddressFormatComponents? Components { get; set; }

        [JsonProperty("metadata")]
        public RestApiAddressFormatMetadata? Metadata { get; set; }
    }
}