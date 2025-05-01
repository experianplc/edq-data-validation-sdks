using DVSClient.Server.Address.Search;

namespace DVSClient.Address.Search
{
    public class SearchSuggestion
    {
        public string GlobalAddressKey { get; }
        public string Text { get; }
        public IEnumerable<IEnumerable<int>> Matched { get; }
        public string FormatUrl { get; }
        public string Dataset { get; }
        public IEnumerable<AdditionalAttribute> AdditionalAttributes { get; }

        public SearchSuggestion(RestApiSearchResultSuggestion suggestion)
        {
            GlobalAddressKey = suggestion.GlobalAddressKey ?? string.Empty;
            Text = suggestion.Text ?? string.Empty;
            Matched = suggestion.Matched ?? new List<IEnumerable<int>>();
            FormatUrl = suggestion.FormatUrl ?? string.Empty;
            Dataset = suggestion.Dataset ?? string.Empty;
            AdditionalAttributes = suggestion.AdditionalAttributes != null
                ? suggestion.AdditionalAttributes.Select(attr => new AdditionalAttribute(attr)).ToList()
                : new List<AdditionalAttribute>();
        }
    }
}