using DVSClient.Common;
using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format
{
    public class AddressFormattedLine
    {
        internal string label { get; }
        internal string line { get; }
        internal bool hasOverflownToOtherLine { get; }
        internal bool isTruncated { get; }
        internal LineContent? lineContent { get; }

        public AddressFormattedLine(RestApiAddressFormattedLine result)
        {
            label = result.Label ?? string.Empty;
            line = result.Line ?? string.Empty;
            hasOverflownToOtherLine = result.HasOverflownToOtherLine ?? false;
            isTruncated = result.IsTruncated ?? false;
            lineContent = result.LineContent?.GetEnumValueFromJsonName<LineContent>();
        }
    }
}