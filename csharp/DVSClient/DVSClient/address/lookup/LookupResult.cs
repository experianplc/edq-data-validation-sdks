using DVSClient.Address;
using DVSClient.Common;
using DVSClient.Server.Address.Lookup;

namespace DVSClient.address.lookup
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
    
        public LookupResult(RestApiAddressLookupV2Result response) 
        {
            MoreResultsAvailable = response.MoreResultsAvailable;
            Confidence = response.Confidence?.GetEnumValueFromJsonName<AddressConfidence>();
            SuggestionsKey = response.SuggestionsKey;
            SuggestionsPrompt = response.SuggestionsPrompt;
            Suggestions = response.Suggestions?.Select(s => new LookupSuggestion(s)).ToList();
            Addresses = response.Addresses?.Select(a => new LookupAddressSuggestionV2(a)).ToList();
            AddressesFormatted = response.AddressesFormatted?.Select(a => new LookupV2ResultAddressFormatted(a)).ToList();

        }
    }
}