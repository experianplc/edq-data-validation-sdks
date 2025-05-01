using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupV2Result
    {
        [JsonProperty("more_results_available")]
        public bool MoreResultsAvailable { get; set; }
        [JsonProperty("confidence")]
        public string? Confidence { get; set; }
        [JsonProperty("suggestions_key")]
        public string? SuggestionsKey { get; set; }
        [JsonProperty("suggestions_prompt")]
        public string? SuggestionsPrompt { get; set; }
        [JsonProperty("suggestions")]
        public IEnumerable<RestApiAddressLookupSuggestion>? Suggestions { get; set; }
        [JsonProperty("addresses")]
        public IEnumerable<RestApiAddressLookupSuggestionV2>? Addresses { get; set; }
        [JsonProperty("addresses_formatted")]
        public IEnumerable<RestApiAddressLookupV2ResultAddressFormatted>? AddressesFormatted { get; set; }        

    }
}