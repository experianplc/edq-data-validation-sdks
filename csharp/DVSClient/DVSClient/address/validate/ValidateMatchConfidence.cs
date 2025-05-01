using DVSClient.Common;

namespace DVSClient.Address.Validate
{
    public enum ValidateMatchConfidence
    {
        Unknown,
        [EnumStringValue("none")]
        None,
        [EnumStringValue("medium")]
        Medium,
        [EnumStringValue("high")]
        High,
    }
}