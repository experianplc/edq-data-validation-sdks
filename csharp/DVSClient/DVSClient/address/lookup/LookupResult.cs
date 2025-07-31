using DVSClient.Common;
using DVSClient.Server.Address.Lookup;

namespace DVSClient.Address.Lookup
{
    public class LookupResult
    {
        public bool MoreResultsAvailable { get; }
        public AddressConfidence? Confidence { get; }
        public string? SuggestionsKey { get; }
        public string? SuggestionsPrompt { get; }
        public IEnumerable<LookupSuggestion>? Suggestions { get; }
        public IEnumerable<LookupAddressSuggestionV2>? Addresses { get; }
        public IEnumerable<LookupV2ResultAddressFormatted>? AddressesFormatted { get; }
        public string? ReferenceId { get; }

        public LookupResult(RestApiAddressLookupV2Response response) 
        {
            var apiResult = response.Result;
            if (apiResult != null)
            {
                MoreResultsAvailable = apiResult.MoreResultsAvailable;
                Confidence = apiResult.Confidence?.GetEnumValueFromJsonName<AddressConfidence>();
                SuggestionsKey = apiResult.SuggestionsKey;
                SuggestionsPrompt = apiResult.SuggestionsPrompt;
                Suggestions = apiResult.Suggestions?.Select(s => new LookupSuggestion(s)).ToList();
                Addresses = apiResult.Addresses?.Select(a => new LookupAddressSuggestionV2(a)).ToList();
                AddressesFormatted = apiResult.AddressesFormatted?.Select(a => new LookupV2ResultAddressFormatted(a)).ToList();
            }
            else
            {
                MoreResultsAvailable = false;
                Confidence = null;
                SuggestionsKey = string.Empty;
                SuggestionsPrompt = string.Empty;
                Suggestions = new List<LookupSuggestion>();
                Addresses = new List<LookupAddressSuggestionV2>();
                AddressesFormatted = new List<LookupV2ResultAddressFormatted>();
            }

            ReferenceId = response.ReferenceId;
        }
    }
}