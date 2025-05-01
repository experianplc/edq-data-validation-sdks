using DVSClient.Common;

namespace DVSClient.Email
{
    public enum EmailConfidence
    {
        [EnumStringValue("verified")]
        Verified,
        [EnumStringValue("undeliverable")]
        Undeliverable,
        [EnumStringValue("unreachable")]
        Unreachable,
        [EnumStringValue("illegitimate")]
        Illegitimate,
        [EnumStringValue("disposable")]
        Disposable,
        [EnumStringValue("unknown")]
        Unknown
    }
}
