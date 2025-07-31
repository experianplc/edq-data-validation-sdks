using DVSClient.Common;

namespace DVSClient.Address
{
    public enum Intensity
    {
        [EnumStringValue("Close")]
        Close,
        [EnumStringValue("Exact")]
        Exact,
        [EnumStringValue("Extensive")]
        Extensive
    }
}