using DVSClient.Address.Format;
using DVSClient.Address.Search;
using DVSClient.Common;
using DVSClient.Server.Address.Validate;

namespace DVSClient.Address.Validate
{
    public class ValidateResult
    {
        public ValidationDetail? ValidationDetail { get; }
        public string GlobalAddressKey { get; }
        public bool? MoreResultsAvailable { get; }
        public AddressConfidence? Confidence { get; }
        public Format.FormatAddress? Address { get; }
        public AddressFormatted? AddressFormatted { get; }
        public IEnumerable<SearchSuggestion> Suggestions { get; } = new List<SearchSuggestion>();
        public AddressComponents? Components { get; }
        public string SuggestionsPrompt { get; }
        public string SuggestionsKey { get; }
        public ValidateMatchType? MatchType { get; }
        public ValidateMatchConfidence? MatchConfidence { get; }
        //public MatchInfo MatchInfo { get; }
        public AddressMetadata? Metadata { get; }
        public AddressEnrichment? Enrichment { get; }
        public ValidateMatchInfo? MatchInfo { get; }

        public ValidateResult(RestApiAddressValidateResponse response)
        {
            var result = response.Result;
            var metadata = response.Metadata;
            var enrichment = response.Enrichment;

            if (result != null)
            {
                ValidationDetail = result.ValidationDetail != null ? new ValidationDetail(result.ValidationDetail) : null;
                GlobalAddressKey = result.GlobalAddressKey ?? string.Empty;
                MoreResultsAvailable = result.MoreResultsAvailable;
                Confidence = result.Confidence?.GetEnumValueFromJsonName<AddressConfidence>();
                Address = result.Address != null ? new Format.FormatAddress(result.Address) : null;
                AddressFormatted = result.AddressesFormatted != null && result.AddressesFormatted.Any()
                    ? new AddressFormatted(result.AddressesFormatted.ElementAt(0))
                    : null;
                SuggestionsKey = result.SuggestionsKey ?? string.Empty;
                SuggestionsPrompt = result.SuggestionsPrompt ?? string.Empty;
                Suggestions = result.Suggestions?.Select(s => new SearchSuggestion(s)).ToList() ?? new List<SearchSuggestion>();
                Components = result.Components != null ? new AddressComponents(result.Components) : null;
                MatchType = result.MatchType?.GetEnumValueFromJsonName<ValidateMatchType>();
                MatchConfidence = result.MatchConfidence?.GetEnumValueFromJsonName<ValidateMatchConfidence>();
                MatchInfo = result.MatchInfo != null ? new ValidateMatchInfo(result.MatchInfo) : null;
            }
            else
            {
                ValidationDetail = null;
                GlobalAddressKey = string.Empty;
                MoreResultsAvailable = false;
                Confidence = null;
                Address = null;
                AddressFormatted = null;
                SuggestionsKey = string.Empty;
                SuggestionsPrompt = string.Empty;
                Suggestions = new List<SearchSuggestion>();
                Components = null;
                MatchType = null;
                MatchConfidence = null;
                MatchInfo = null;
            }

            Metadata = metadata != null ? new AddressMetadata(metadata) : null;
            Enrichment = enrichment != null ? new AddressEnrichment(enrichment) : null;
        }
    }
}