using DVSClient.Common;

namespace DVSClient.Address.Validate
{
    public enum PostalCodeAction
    {
        Unknown,
        [EnumStringValue("none")]
        None,
        [EnumStringValue("ok")]
        Ok,
        [EnumStringValue("added")]
        Added,
        [EnumStringValue("corrected")]
        Corrected,
    }
}