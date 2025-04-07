using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format
{
    public class AddressFormatted
    {
        internal string LayoutName { get; }
        internal bool? HasEnoughLines { get; }
        internal bool? HasTruncatedLines { get; }
        internal IDictionary<string, string> Address { get; }
        internal bool? HasMissingSubPremises { get; }
        internal IEnumerable<AddressFormattedLine> AddressLines { get; }

        public AddressFormatted(RestApiAddressFormatted result)
        {
            LayoutName = result.LayoutName ?? string.Empty;
            HasEnoughLines = result.NotEnoughLines.HasValue ? !result.NotEnoughLines.Value : null;
            HasTruncatedLines = result.HasTruncatedLines;
            Address = new Dictionary<string, string>();
            if (result.Address != null)
            {
                foreach (var entry in result.Address)
                {
                    Address[entry.Key] = entry.Value ?? string.Empty;
                }
            }
            HasMissingSubPremises = result.HasMissingSubPremises;
            AddressLines = result.AddressLines != null ? result.AddressLines.ToList().ConvertAll(line => new AddressFormattedLine(line)) : new List<AddressFormattedLine>();
        }
    }
}