export enum GeocodeMatchLevel {
    Building = "building",
    PostalCode = "postal_code",
    District = "district",
    City = "city",
    County = "county",
    State = "state",
    Country = "country",
    Street = "street",
    Place = "place",
    AddressBlock = "addressBlock",
    Intersection = "intersection",
    Locality = "locality",
    Unknown = "Unknown"
}

export function lookupGeocodeMatchLevel(str?: string): GeocodeMatchLevel {
    if (str) {
        return Object.keys(GeocodeMatchLevel).find(key => GeocodeMatchLevel[key as keyof typeof GeocodeMatchLevel] === str) as GeocodeMatchLevel | GeocodeMatchLevel.Unknown;    
    } else {
        return GeocodeMatchLevel.Unknown;
    }
}