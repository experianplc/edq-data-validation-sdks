using DVSClient.Server.Address.Lookup;

namespace DVSClient.Address.Lookup
{
    public class LookupAddressSuggestionV2
    {
        public string? Text { get; }
        public IEnumerable<int>? Matched { get; }
        public string? GlobalAddressKey { get; }
        public string? Format { get; }
        public string? Dataset { get; }
        public IEnumerable<string>? Names { get; }
        public string? Uprn { get; }

        public LookupAddressSuggestionV2(RestApiAddressLookupSuggestionV2 response)
        {
            Text = response.Text;
            Matched = response.Matched;
            GlobalAddressKey = response.GlobalAddressKey;
            Format = response.Format;
            Dataset = response.Dataset;
            Names = response.Names;
            Uprn = response.Uprn;
        }
    }
}