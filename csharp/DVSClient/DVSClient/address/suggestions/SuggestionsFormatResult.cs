using DVSClient.Common;
using DVSClient.Server.Address.Suggestions;

namespace DVSClient.Address.Suggestions
{
    public class SuggestionsFormatResult
    {
        public bool MoreResultsAvailable { get; }
        public AddressConfidence? Confidence { get; }
        public IEnumerable<SuggestionsFormatSuggestion> Suggestions { get; }

        public SuggestionsFormatResult(RestApiSuggestionsFormatResponse response)
        {
            var result = response.Result;
            if (result != null)
            {
                MoreResultsAvailable = result.MoreResultsAvailable;
                Confidence = result.Confidence?.GetEnumValueFromJsonName<AddressConfidence>();
                Suggestions = result.Suggestions?.Select(s => new SuggestionsFormatSuggestion(s)).ToList() ?? new List<SuggestionsFormatSuggestion>();
            }
            else
            {
                MoreResultsAvailable = false;
                Confidence = null;
                Suggestions = new List<SuggestionsFormatSuggestion>();
            }
        }
    }
}