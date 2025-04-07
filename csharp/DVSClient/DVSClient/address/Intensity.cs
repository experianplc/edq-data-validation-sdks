using DVSClient.Common;

namespace DVSClient.Address
{
    public enum Intensity
    {
        [EnumStringValue("Exact")]
        Exact,
        [EnumStringValue("Close")]
        Close,
        [EnumStringValue("Extensive")]
        Extensive
    }
}