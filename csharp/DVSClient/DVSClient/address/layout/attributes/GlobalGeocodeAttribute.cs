using DVSClient.Common;

namespace DVSClient.Address.Layout.Attributes
{
    public enum GlobalGeocodeAttribute
    {
        [EnumStringValue("latitude")]
        Latitude,
        [EnumStringValue("longitude")]
        Longitude,
        [EnumStringValue("match_level")]
        MatchLevel
    }
}