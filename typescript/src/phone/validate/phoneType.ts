export enum PhoneType {
    Mobile = "Mobile",
    Landline = "Landline",
    MobileOrLandline = "Mobile or landline",
    TollFree = "Toll free",
    Premium = "Premium",
    SharedCost = "Shared cost",
    VoIP = "VoIP",
    StageAndScreen = "Stage and screen",
    Pager = "Pager",
    UniversalAccessNumber = "Universal access number",
    PersonalNumber = "Personal number",
    VoicemailOnly = "Voicemail only",
    BadFormat = "Bad format",
    Unknown = "Unknown"
}

export function lookupPhoneType(str?: string): PhoneType {
    if (str) {
        return Object.keys(PhoneType).find(key => PhoneType[key as keyof typeof PhoneType] === str) as PhoneType | PhoneType.Unknown;    
    } else {
        return PhoneType.Unknown;
    }
}
