using DVSClient.Server.Address.Format;
using DVSClient.Server.Address.Search;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Validate
{
    public class RestApiAddressValidateResult
    {
        [JsonProperty("validation_detail")]
        public RestApiValidationDetail? ValidationDetail { get; set; }

        [JsonProperty("global_address_key")]
        public string? GlobalAddressKey { get; set; }

        [JsonProperty("more_results_available")]
        public bool? MoreResultsAvailable { get; set; }

        [JsonProperty("confidence")]
        public string? Confidence { get; set; }

        [JsonProperty("address")]
        public RestApiFormatAddress? Address { get; set; }

        [JsonProperty("addresses_formatted")]
        public IEnumerable<RestApiAddressFormatted>? AddressesFormatted { get; set; }

        [JsonProperty("components")]
        public RestApiAddressFormatComponents? Components { get; set; }

        [JsonProperty("suggestions_key")]
        public string? SuggestionsKey { get; set; }

        [JsonProperty("suggestions_prompt")]
        public string? SuggestionsPrompt { get; set; }

        [JsonProperty("suggestions")]
        public IEnumerable<RestApiSearchResultSuggestion>? Suggestions { get; set; }

        [JsonProperty("match_type")]
        public string? MatchType { get; set; }

        [JsonProperty("match_confidence")]
        public string? MatchConfidence { get; set; }

        [JsonProperty("match_info")]
        public MatchInfoFlags? MatchInfo { get; set; }

        public class MatchInfoFlags
        {
            [JsonProperty("postcode_action")]
            public string? PostcodeAction { get; set; }

            [JsonProperty("address_action")]
            public string? AddressAction { get; set; }

            [JsonProperty("generic_info")]
            public IEnumerable<string>? GenericInfo { get; set; }

            [JsonProperty("aus_info")]
            public IEnumerable<string>? AusInfo { get; set; }
        }
    }
}