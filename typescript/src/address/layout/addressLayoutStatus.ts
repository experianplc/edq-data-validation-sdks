
export enum AddressLayoutStatus {
    CreationInProgress = "CreationInProgress",
    Completed = "Completed"
}

export function lookupAddressLayoutStatus(str?: string): AddressLayoutStatus | undefined {
    if (str) {
        return Object.keys(AddressLayoutStatus).find(key => AddressLayoutStatus[key as keyof typeof AddressLayoutStatus] === str) as AddressLayoutStatus | undefined;    
    } else {
        return undefined
    }
}