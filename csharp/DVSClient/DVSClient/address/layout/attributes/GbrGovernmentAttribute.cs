using DVSClient.Common;

namespace DVSClient.Address.Layout.Attributes
{
    public enum GbrGovernmentAttribute
    {
        [EnumStringValue("eer_code")]
        EerCode,
        [EnumStringValue("eer_code_pre_2011")]
        EerCodePre2011,
        [EnumStringValue("eer_name")]
        EerName,
        [EnumStringValue("gor_code")]
        GorCode,
        [EnumStringValue("gor_code_pre_2011")]
        GorCodePre2011,
        [EnumStringValue("gor_name")]
        GorName,
        [EnumStringValue("lea_code")]
        LeaCode,
        [EnumStringValue("lea_name")]
        LeaName,
        [EnumStringValue("la_code")]
        LaCode,
        [EnumStringValue("la_code_pre_2011")]
        LaCodePre2011,
        [EnumStringValue("la_name")]
        LaName,
        [EnumStringValue("ward_code")]
        WardCode,
        [EnumStringValue("ward_code_pre_2011")]
        WardCodePre2011,
        [EnumStringValue("ward_name")]
        WardName,
        [EnumStringValue("cens_out_area")]
        CensOutArea
    }
}