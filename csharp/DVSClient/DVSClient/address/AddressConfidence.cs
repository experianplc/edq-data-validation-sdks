using DVSClient.Common;

namespace DVSClient.Address
{
    public enum AddressConfidence
    {
        [EnumStringValue("Unknown")]
        Unknown,
        [EnumStringValue("Verified match")]
        VerifiedMatch,
        [EnumStringValue("Multiple matches")]
        MultipleMatches,
        [EnumStringValue("Too many matches")]
        TooManyMatches,
        [EnumStringValue("Interaction required")]
        InteractionRequired,
        [EnumStringValue("Premises partial")]
        PremisesPartial,
        [EnumStringValue("Street partial")]
        StreetPartial,
        [EnumStringValue("Verified place")]
        VerifiedPlace,
        [EnumStringValue("Verified street")]
        VerifiedStreet,
        [EnumStringValue("Incomplete address")]
        IncompleteAddress,
        [EnumStringValue("Insufficient search terms")]
        InsufficientSearchTerms,
        [EnumStringValue("No matches")]
        NoMatches
    }
}