using DVSClient.Common;

namespace DVSClient.Address.Lookup
{
    public enum LookupType
    {
        [EnumStringValue("postal_code")]
        PostalCode,
        
        [EnumStringValue("locality")]
        Locality,
        
        [EnumStringValue("udprn")]
        Udprn,
        
        [EnumStringValue("mpan")]
        Mpan,
        
        [EnumStringValue("mprn")]
        Mprn,
        
        [EnumStringValue("what3words")]
        What3Words
    }
}