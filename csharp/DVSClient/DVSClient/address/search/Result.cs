using DVSClient.Common;
using DVSClient.Server.Address.Search;

namespace DVSClient.Address.Search
{
    public class Result
    {
        public bool MoreResultsAvailable { get; }
        public Confidence? Confidence { get; }
        public string SuggestionsKey { get; }
        public string SuggestionsPrompt { get; }
        public IEnumerable<Suggestion> Suggestions { get; } = new List<Suggestion>();

        public Result(RestApiAddressSearchResponse response)
        {
            var apiResult = response.Result;
            if (apiResult != null)
            {
                MoreResultsAvailable = apiResult.IsMoreResultsAvailable() ?? false;
                Confidence = apiResult.Confidence?.GetEnumValueFromJsonName<Confidence>();
                SuggestionsKey = apiResult.SuggestionsKey ?? string.Empty;
                SuggestionsPrompt = apiResult.SuggestionsPrompt ?? string.Empty;
                Suggestions = apiResult.Suggestions?.Select(s => new Suggestion(s)).ToList() ?? new List<Suggestion>();
            }
            else
            {
                MoreResultsAvailable = false;
                Confidence = null;
                SuggestionsKey = string.Empty;
                SuggestionsPrompt = string.Empty;
                Suggestions = new List<Suggestion>();
            }
        }
    }
}