using DVSClient.Common;

namespace DVSClient.Address.Format
{
    public enum GeocodeMatchLevel
    {
        [EnumStringValue("building")]
        Building,
        [EnumStringValue("postal_code")]
        PostalCode,
        [EnumStringValue("district")]
        District,
        [EnumStringValue("city")]
        City,
        [EnumStringValue("county")]
        County,
        [EnumStringValue("state")]
        State,
        [EnumStringValue("country")]
        Country,
        [EnumStringValue("street")]
        Street,
        [EnumStringValue("place")]
        Place,
        [EnumStringValue("addressBlock")]
        AddressBlock,
        [EnumStringValue("intersection")]
        Intersection,
        [EnumStringValue("locality")]
        Locality
    }
}