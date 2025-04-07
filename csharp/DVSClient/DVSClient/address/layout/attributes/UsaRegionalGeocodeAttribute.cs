using DVSClient.Common;

namespace DVSClient.Address.Layout.Attributes
{
    public enum UsaRegionalGeocodeAttribute
    {
        [EnumStringValue("latitude")]
        Latitude,
        [EnumStringValue("longitude")]
        Longitude,
        [EnumStringValue("match_level")]
        MatchLevel,
        [EnumStringValue("census_tract")]
        CensusTract,
        [EnumStringValue("census_block")]
        CensusBlock,
        [EnumStringValue("core_based_statistical_area")]
        CoreBasedStatisticalArea,
        [EnumStringValue("congressional_district_code")]
        CongressionalDistrictCode,
        [EnumStringValue("county_code")]
        CountyCode
    }
}