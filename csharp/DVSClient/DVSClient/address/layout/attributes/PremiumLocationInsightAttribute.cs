using DVSClient.Common;

namespace DVSClient.Address.Layout.Attributes
{
    public enum PremiumLocationInsightAttribute
    {
        [EnumStringValue("geocodes")]
        Geocodes,
        [EnumStringValue("geocodes_building_xy")]
        GeocodesBuildingXy,
        [EnumStringValue("geocodes_access")]
        GeocodesAccess,
        [EnumStringValue("time")]
        Time
    }
}