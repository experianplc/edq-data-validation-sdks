using DVSClient.Common;
using DVSClient.Server.Address.Suggestions;

namespace DVSClient.Address.Suggestions
{
    public class Result
    {
        public bool MoreResultsAvailable { get; }
        public Confidence? Confidence { get; }
        public IEnumerable<Suggestion> Suggestions { get; }

        public Result(RestApiSuggestionsFormatResponse response)
        {
            var result = response.Result;
            if (result != null)
            {
                MoreResultsAvailable = result.MoreResultsAvailable;
                Confidence = result.Confidence?.GetEnumValueFromJsonName<Confidence>();
                Suggestions = result.Suggestions?.Select(s => new Suggestion(s)).ToList() ?? new List<Suggestion>();
            }
            else
            {
                MoreResultsAvailable = false;
                Confidence = null;
                Suggestions = new List<Suggestion>();
            }
        }
    }
}