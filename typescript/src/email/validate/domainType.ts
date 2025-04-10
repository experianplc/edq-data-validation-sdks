export enum DomainType {
    Consumer = "consumer",
    Business = "business"
}

export function lookupDomainType(str?: string): DomainType | undefined {
    if (str) {
        return Object.keys(DomainType).find(key => DomainType[key as keyof typeof DomainType] === str) as DomainType | undefined;    
    } else {
        return undefined;
    }
}