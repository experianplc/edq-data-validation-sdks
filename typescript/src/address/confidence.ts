export enum Confidence {
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

export function lookupConfidence(str?: string): Confidence {
    if (str) {
        return Object.keys(Confidence).find(key => Confidence[key as keyof typeof Confidence] === str) as Confidence | Confidence.Unknown;    
    } else {
        return Confidence.Unknown;
    }
}
