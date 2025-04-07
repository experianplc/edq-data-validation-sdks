using Newtonsoft.Json;

namespace DVSClient.Server.Address.Suggestions
{
    public class RestApiSuggestionsFormatResult
    {
        [JsonProperty("more_results_available")]
        public bool MoreResultsAvailable { get; set; }

        [JsonProperty("confidence")]
        public string? Confidence { get; set; }

        [JsonProperty("suggestions")]
        public IEnumerable<RestApiSuggestionsFormatSuggestion>? Suggestions { get; set; }
    }
}