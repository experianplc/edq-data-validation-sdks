export enum ValidateMatchType {
    Unknown = "Unknown",
    Unprocessed = "unprocessed",
    Blank = "blank",
    Unmatched = "unmatched",
    PostalCodeMatchWithoutAddress = "post_code_no_address",
    MultipleMatchWithoutPostalCode = "multiple_no_post_code",
    MultipleMatchWithPostalCode = "multiple_with_post_code",
    PartialMatchWithoutPostalCode = "partial_no_post_code",
    PartialMatchWithPostalCode = "partial_with_post_code",
    FullMatchWithoutPostalCode = "full_no_post_code",
    FullMatchWithPostalCode = "full_with_post_code"
}

export function lookupMatchType(str?: string): ValidateMatchType {
    if (str) {
        return Object.keys(ValidateMatchType).find(key => ValidateMatchType[key as keyof typeof ValidateMatchType] === str) as ValidateMatchType | ValidateMatchType.Unknown;
    } else {
        return ValidateMatchType.Unknown;
    }
}