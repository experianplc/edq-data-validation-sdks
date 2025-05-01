using DVSClient.Common;

namespace DVSClient.address.lookup
{
    public enum LookupLocality
    {
        [EnumStringValue("postal_code")]
        PostalCode,
        
        [EnumStringValue("subdistrict")]
        Subdistrict,
        
        [EnumStringValue("district")]
        District,
        
        [EnumStringValue("town")]
        Town,
        
        [EnumStringValue("region")]
        Region,
        
        [EnumStringValue("subregion")]
        Subregion
    }
}