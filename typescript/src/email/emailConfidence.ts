export enum EmailConfidence {
    Verified = "verified",
    Undeliverable = "undeliverable",
    Unreachable = "unreachable",
    Illegitimate = "illegitimate",
    Disposable = "disposable",
    Unknown = "unknown"
};

export function lookupConfidence(str?: string): EmailConfidence {
    if (str) {
        return Object.keys(EmailConfidence).find(key => EmailConfidence[key as keyof typeof EmailConfidence] === str) as EmailConfidence | EmailConfidence.Unknown;    
    } else {
        return EmailConfidence.Unknown;
    }
}
