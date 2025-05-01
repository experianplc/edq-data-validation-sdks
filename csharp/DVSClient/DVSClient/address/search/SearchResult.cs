using DVSClient.Common;
using DVSClient.Server.Address.Search;

namespace DVSClient.Address.Search
{
    public class SearchResult
    {
        public bool MoreResultsAvailable { get; }
        public AddressConfidence? Confidence { get; }
        public string SuggestionsKey { get; }
        public string SuggestionsPrompt { get; }
        public IEnumerable<SearchSuggestion> Suggestions { get; } = new List<SearchSuggestion>();

        public SearchResult(RestApiAddressSearchResponse response)
        {
            var apiResult = response.Result;
            if (apiResult != null)
            {
                MoreResultsAvailable = apiResult.IsMoreResultsAvailable() ?? false;
                Confidence = apiResult.Confidence?.GetEnumValueFromJsonName<AddressConfidence>();
                SuggestionsKey = apiResult.SuggestionsKey ?? string.Empty;
                SuggestionsPrompt = apiResult.SuggestionsPrompt ?? string.Empty;
                Suggestions = apiResult.Suggestions?.Select(s => new SearchSuggestion(s)).ToList() ?? new List<SearchSuggestion>();
            }
            else
            {
                MoreResultsAvailable = false;
                Confidence = null;
                SuggestionsKey = string.Empty;
                SuggestionsPrompt = string.Empty;
                Suggestions = new List<SearchSuggestion>();
            }
        }
    }
}