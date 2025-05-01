using DVSClient.Common;

namespace DVSClient.Phone
{
    public enum PhoneConfidence
    {
        [EnumStringValue("Verified")]
        Verified,
        [EnumStringValue("Absent")]
        Absent,
        [EnumStringValue("Teleservice not provisioned")]
        TeleserviceNotProvisioned,
        [EnumStringValue("Unverified")]
        Unverified,
        [EnumStringValue("No coverage")]
        NoCoverage,
        [EnumStringValue("Unknown")]
        Unknown,
        [EnumStringValue("Dead")]
        Dead
    }
}
