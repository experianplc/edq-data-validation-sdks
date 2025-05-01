export enum AddressAction {
    Unknown = "unknown",
    None = "none",
    Reformatted = "reformatted",
    Enhanced = "enhanced",
    Corrected = "corrected"
}

export function lookupAddressAction(str?: string): AddressAction {
    if (str) {
        return Object.keys(AddressAction).find(key => AddressAction[key as keyof typeof AddressAction] === str) as AddressAction | AddressAction.Unknown;
    } else {
        return AddressAction.Unknown;
    }
}
