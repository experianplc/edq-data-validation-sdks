using DVSClient.Common;

namespace DVSClient.address.lookup
{
    public enum LookupPostalCode
    {
        [EnumStringValue("postal_code")]
        PostalCode, // Locality information is retrieved based on a supplied postal code.

        [EnumStringValue("subdistrict")]
        Subdistrict, // Locality information is retrieved based on a supplied subdistrict.

        [EnumStringValue("district")]
        District, // Locality information is retrieved based on a supplied district.

        [EnumStringValue("town")]
        Town, // Locality information is retrieved based on a supplied town.

        [EnumStringValue("region")]
        Region, // Locality information is retrieved based on a supplied region.

        [EnumStringValue("subregion")]
        Subregion // Locality information is retrieved based on a supplied subregion.
    }
}