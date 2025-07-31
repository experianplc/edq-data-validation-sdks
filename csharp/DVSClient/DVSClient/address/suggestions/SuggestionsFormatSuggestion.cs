using DVSClient.Address.Format;
using DVSClient.Server.Address.Suggestions;

namespace DVSClient.Address.Suggestions
{
    public class SuggestionsFormatSuggestion
    {
        public string? GlobalAddressKey { get; }
        public FormatAddress? Address { get; }
        public AddressFormatted? AddressFormatted { get; }
        public AddressComponents? Components { get; }
        public AddressMetadata? Metadata { get; }

        public SuggestionsFormatSuggestion(RestApiSuggestionsFormatSuggestion suggestion)
        {
            if (suggestion != null)
            {
                GlobalAddressKey = suggestion.GlobalAddressKey;
                Address = suggestion.Address != null ? new FormatAddress(suggestion.Address) : null;
                AddressFormatted = suggestion.AddressesFormatted != null ? new AddressFormatted(suggestion.AddressesFormatted.First()) : null;
                Components = suggestion.Components != null ? new AddressComponents(suggestion.Components) : null;
                Metadata = suggestion.Metadata != null ? new AddressMetadata(suggestion.Metadata) : null;
            }
            else
            {
                GlobalAddressKey = string.Empty;
                Address = null;
                AddressFormatted = null;
                Components = null;
                Metadata = null;
            }
        }
    }
}