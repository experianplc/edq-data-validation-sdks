
export enum LayoutStatus {
    CreationInProgress = "CreationInProgress",
    Completed = "Completed"
}

export function lookupAddressLayoutStatus(str?: string): LayoutStatus | undefined {
    if (str) {
        return Object.keys(LayoutStatus).find(key => LayoutStatus[key as keyof typeof LayoutStatus] === str) as LayoutStatus | undefined;    
    } else {
        return undefined
    }
}