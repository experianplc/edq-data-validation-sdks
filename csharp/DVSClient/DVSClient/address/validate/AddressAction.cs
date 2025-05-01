using DVSClient.Common;

namespace DVSClient.Address.Validate
{
    public enum AddressAction
    {
        Unknown,
        [EnumStringValue("none")]
        None,
        [EnumStringValue("reformatted")]
        Reformatted,
        [EnumStringValue("enhanced")]
        Enhanced,
        [EnumStringValue("corrected")]
        Corrected,
    }
}