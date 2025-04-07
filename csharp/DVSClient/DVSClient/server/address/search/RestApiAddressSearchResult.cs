using Newtonsoft.Json;

namespace DVSClient.Server.Address.Search
{
    public class RestApiAddressSearchResult
    {
        [JsonProperty("more_results_available")]
        public bool? MoreResultsAvailable { get; set; }

        [JsonProperty("confidence")]
        public string? Confidence { get; set; }

        [JsonProperty("suggestions_key")]
        public string? SuggestionsKey { get; set; }

        [JsonProperty("suggestions_prompt")]
        public string? SuggestionsPrompt { get; set; }

        [JsonProperty("suggestions")]
        public IEnumerable<RestApiSearchResultSuggestion>? Suggestions { get; set; }

        public bool? IsMoreResultsAvailable()
        {
            return MoreResultsAvailable;
        }
    }
}
