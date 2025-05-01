export enum AddressConfidence {
    Unknown = "Unknown",
    VerifiedMatch = "Verified match",
    MultipleMatches = "Multiple matches",
    TooManyMatches = "Too many matches",
    InteractionRequired = "Interaction required",
    PremisesPartial = "Premises partial",
    StreetPartial = "Street partial",
    VerifiedPlace = "Verified place",
    VerifiedStreet = "Verified street",
    IncompleteAddress = "Incomplete address",
    InsufficientSearchTerms = "Insufficient search terms",
    NoMatches = "No matches"
}

export function lookupConfidence(str?: string): AddressConfidence {
    if (str) {
        return Object.keys(AddressConfidence).find(key => AddressConfidence[key as keyof typeof AddressConfidence] === str) as AddressConfidence | AddressConfidence.Unknown;    
    } else {
        return AddressConfidence.Unknown;
    }
}
