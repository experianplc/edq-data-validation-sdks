export enum PostalCodeAction {
    Unknown = "unknown",
    None = "none",
    Ok = "ok",
    Added = "added",
    Corrected = "corrected"
}

export function lookupPostalCodeAction(str?: string): PostalCodeAction {
    if (str) {
        return Object.keys(PostalCodeAction).find(key => PostalCodeAction[key as keyof typeof PostalCodeAction] === str) as PostalCodeAction | PostalCodeAction.Unknown;
    } else {
        return PostalCodeAction.Unknown;
    }
}
