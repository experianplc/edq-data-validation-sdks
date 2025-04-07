using DVSClient.Common;

namespace DVSClient.Address.Layout.Attributes
{
    public enum GbrBusinessAttribute
    {
        [EnumStringValue("urn")]
        Urn,
        [EnumStringValue("commercial_mosaic")]
        CommercialMosaic,
        [EnumStringValue("registration")]
        Registration,
        [EnumStringValue("phone")]
        Phone,
        [EnumStringValue("number_of_employees")]
        NumberOfEmployees,
        [EnumStringValue("location")]
        Location,
        [EnumStringValue("standard_industry_classification")]
        StandardIndustryClassification,
        [EnumStringValue("non_limited_company_key")]
        NonLimitedCompanyKey
    }
}