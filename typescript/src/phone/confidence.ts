export enum Confidence {
    Verified = "Verified",
    Absent = "Absent",
    TeleserviceNotProvisioned = "Teleservice not provisioned",
    Unverified = "Unverified",
    NoCoverage = "No coverage",
    Unknown = "Unknown",
    Dead = "Dead"
}

export function lookupConfidence(str?: string): Confidence {
    if (str) {
        return Object.keys(Confidence).find(key => Confidence[key as keyof typeof Confidence] === str) as Confidence | Confidence.Unknown;    
    } else {
        return Confidence.Unknown;
    }
}