using DVSClient.Common;

namespace DVSClient.Address.Layout.Attributes
{
    public enum GbrLocationCompleteAttribute
    {
        [EnumStringValue("latitude")]
        Latitude,
        [EnumStringValue("longitude")]
        Longitude,
        [EnumStringValue("match_level")]
        MatchLevel,
        [EnumStringValue("udprn")]
        Udprn,
        [EnumStringValue("uprn")]
        Uprn,
        [EnumStringValue("x_coordinate")]
        XCoordinate,
        [EnumStringValue("y_coordinate")]
        YCoordinate
    }
}