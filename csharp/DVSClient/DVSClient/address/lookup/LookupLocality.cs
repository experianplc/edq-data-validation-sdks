using DVSClient.Common;

namespace DVSClient.Address.Lookup
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