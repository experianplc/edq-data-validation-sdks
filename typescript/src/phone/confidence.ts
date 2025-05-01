export enum PhoneConfidence {
    Verified = "Verified",
    Absent = "Absent",
    TeleserviceNotProvisioned = "Teleservice not provisioned",
    Unverified = "Unverified",
    NoCoverage = "No coverage",
    Unknown = "Unknown",
    Dead = "Dead"
}

export function lookupConfidence(str?: string): PhoneConfidence {
    if (str) {
        return Object.keys(PhoneConfidence).find(key => PhoneConfidence[key as keyof typeof PhoneConfidence] === str) as PhoneConfidence | PhoneConfidence.Unknown;    
    } else {
        return PhoneConfidence.Unknown;
    }
}