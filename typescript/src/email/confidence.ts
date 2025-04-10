export enum Confidence {
    Verified = "verified",
    Undeliverable = "undeliverable",
    Unreachable = "unreachable",
    Illegitimate = "illegitimate",
    Disposable = "disposable",
    Unknown = "unknown"
};

export function lookupConfidence(str?: string): Confidence {
    if (str) {
        return Object.keys(Confidence).find(key => Confidence[key as keyof typeof Confidence] === str) as Confidence | Confidence.Unknown;    
    } else {
        return Confidence.Unknown;
    }
}
