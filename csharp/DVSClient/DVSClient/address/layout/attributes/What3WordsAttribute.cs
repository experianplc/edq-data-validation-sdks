using DVSClient.Common;

namespace DVSClient.Address.Layout.Attributes
{
    public enum What3WordsAttribute
    {
        [EnumStringValue("latitude")]
        Latitude,
        [EnumStringValue("longitude")]
        Longitude,
        [EnumStringValue("name")]
        Name,
        [EnumStringValue("description")]
        Description
    }
}