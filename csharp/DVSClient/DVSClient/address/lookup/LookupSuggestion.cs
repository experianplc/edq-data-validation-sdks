using DVSClient.Server.Address.Lookup;

namespace DVSClient.Address.Lookup
{
    public class LookupSuggestion
    {
        public LookupSuggestionLocality? Locality { get; }
        public LookupSuggestionPostalCode? PostalCode { get; }
        public string? PostalCodeKey { get; }
        public string? LocalityKey { get; }
        public LookupSuggestionWhat3Words? What3Words { get; }

        public LookupSuggestion(RestApiAddressLookupSuggestion response)
        {
            Locality = response.Locality != null ? new LookupSuggestionLocality(response.Locality) : null;            
            PostalCode = response.PostalCode != null ? new LookupSuggestionPostalCode(response.PostalCode) : null;
            PostalCodeKey = response.PostalCodeKey;
            LocalityKey = response.LocalityKey;
            What3Words = response.What3words != null ? new LookupSuggestionWhat3Words(response.What3words) : null;
        }
    }

    public class LookupSuggestionLocality
    {
        public LookupLocalityItem? Region { get; }
        public LookupLocalityItem? SubRegion { get; }
        public LookupLocalityItem? Town { get; }
        public LookupLocalityItem? District { get; }
        public LookupLocalityItem? SubDistrict { get; }

        public LookupSuggestionLocality(RestApiAddressLookupSuggestionLocality response)
        {
            Region = response.Region != null ? new LookupLocalityItem(response.Region) : null;
            SubRegion = response.SubRegion != null ? new LookupLocalityItem(response.SubRegion) : null;
            Town = response.Town != null ? new LookupLocalityItem(response.Town) : null;
            District = response.District != null ? new LookupLocalityItem(response.District) : null;
            SubDistrict = response.SubDistrict != null ? new LookupLocalityItem(response.SubDistrict) : null;
        }
    }

    public class LookupSuggestionPostalCode
    {
        public string? FullName { get; }
        public string? Primary { get; }
        public string? Secondary { get; }

        public LookupSuggestionPostalCode(RestApiAddressLookupSuggestionPostalCode response)
        {
            FullName = response.FullName;
            Primary = response.Primary;
            Secondary = response.Secondary;
        }
    }

    public class LookupSuggestionWhat3Words
    {
        public string? Name { get; }
        public string? Description { get; }

        public LookupSuggestionWhat3Words(RestApiAddressLookupSuggestionW3W response)
        {
            Name = response.Name;
            Description = response.Description;
        }
    }

    
}