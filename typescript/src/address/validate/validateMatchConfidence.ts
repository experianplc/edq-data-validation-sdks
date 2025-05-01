export enum ValidateMatchConfidence {
    Unknown = "unknown",
    None = "none",
    Medium = "medium",
    High = "high"
}

export function lookupMatchConfidence(str?: string): ValidateMatchConfidence {
    if (str) {
        return Object.keys(ValidateMatchConfidence).find(key => ValidateMatchConfidence[key as keyof typeof ValidateMatchConfidence] === str) as ValidateMatchConfidence | ValidateMatchConfidence.Unknown;
    } else {
        return ValidateMatchConfidence.Unknown;
    }
}
