using DVSClient.Common;

namespace DVSClient.Address.Layout.Attributes
{
    public enum GbrHealthAttribute
    {
        [EnumStringValue("ward_code")]
        WardCode,
        [EnumStringValue("ward_code_2011")]
        WardCode2011,
        [EnumStringValue("ward_name")]
        WardName,
        [EnumStringValue("ccg_code")]
        CcgCode,
        [EnumStringValue("ccg_name")]
        CcgName,
        [EnumStringValue("doh_code")]
        DohCode
    }
}