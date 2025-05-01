using DVSClient.Server.Address.Lookup;

namespace DVSClient.Address.Lookup
{
    public class LookupLocalityItem
    {
        public string Name { get; }
        public string Code { get; }
        public string Description { get; }

        public LookupLocalityItem(RestApiAddressLookupLocalityItem response)
        {
            Name = response.Name??"";
            Code = response.Code??"";
            Description = response.Description??"";
        }
    }
}