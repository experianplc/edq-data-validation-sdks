import { AddressElement } from "./addressElement";

export namespace GbrAddressElements {
    export const Empty: AddressElement = { elementName: "empty", description: "Empty line", example: "" };
    export const CompanyName: AddressElement = { elementName: "companyName", description: "Company/organisation name assigned", example: "" };
    export const Department: AddressElement = { elementName: "department", description: "Departments within an organisation that are postally addressable", example: "" };
    export const StreetNumber: AddressElement = { elementName: "streetNumber", description: "Street/Building number", example: "" };
    export const BuildingLevel: AddressElement = { elementName: "buildingLevel", description: "Building level", example: "" };
    export const BuildingGroup: AddressElement = { elementName: "buildingGroup", description: "Building group", example: "" };
    export const BuildingGroupName: AddressElement = { elementName: "buildingGroupName", description: "Building group name", example: "" };
    export const BuildingGroupDesc: AddressElement = { elementName: "buildingGroupDesc", description: "Building group description", example: "" };
    export const Extension: AddressElement = { elementName: "extension", description: "Building extension", example: "" };
    export const ExtensionAlt: AddressElement = { elementName: "extensionAlt", description: "Building extension alternative information", example: "" };
    export const ExtensionAltName: AddressElement = { elementName: "extensionAltName", description: "Building extension alternative name", example: "" };
    export const ExtensionNumber: AddressElement = { elementName: "extensionNumber", description: "Building extension number", example: "" };
    export const SubBuildingType: AddressElement = { elementName: "subBuildingType", description: "Sub building type", example: "" };
    export const SubBuildingNumber: AddressElement = { elementName: "subBuildingNumber", description: "Sub building number", example: "" };
    export const PoBox: AddressElement = { elementName: "poBox", description: "PO Box / Delivery service full 1", example: "" };
    export const PoBoxType: AddressElement = { elementName: "poBoxType", description: "PO Box type", example: "" };
    export const PoBoxNumber: AddressElement = { elementName: "poBoxNumber", description: "PO Box number", example: "" };
    export const Box: AddressElement = { elementName: "box", description: "Box", example: "" };
    export const BoxType: AddressElement = { elementName: "boxType", description: "Box type", example: "" };
    export const BoxNumber: AddressElement = { elementName: "boxNumber", description: "Box number", example: "" };
    export const StreetPrimary: AddressElement = { elementName: "streetPrimary", description: "Street primary", example: "" };
    export const StreetPreDirectionalPrimary: AddressElement = { elementName: "streetPreDirectionalPrimary", description: "Street pre directional primary", example: "" };
    export const StreetNamePrimary: AddressElement = { elementName: "streetNamePrimary", description: "Street name primary", example: "" };
    export const StreetTypePrimary: AddressElement = { elementName: "streetTypePrimary", description: "Street type primary", example: "" };
    export const StreetPostDirectionalPrimary: AddressElement = { elementName: "streetPostDirectionalPrimary", description: "Street post directional primary", example: "" };
    export const StreetSecondary: AddressElement = { elementName: "streetSecondary", description: "Street secondary", example: "" };
    export const StreetNameSecondary: AddressElement = { elementName: "streetNameSecondary", description: "Street name secondary", example: "" };
    export const StreetTypeSecondary: AddressElement = { elementName: "streetTypeSecondary", description: "Street type secondary", example: "" };
    export const Region: AddressElement = { elementName: "region", description: "Region", example: "" };
    export const RegionAlt: AddressElement = { elementName: "regionAlt", description: "Region alternative information", example: "" };
    export const State: AddressElement = { elementName: "state", description: "State", example: "" };
    export const StateAbbreviation: AddressElement = { elementName: "stateAbbreviation", description: "State abbreviation", example: "" };
    export const County: AddressElement = { elementName: "county", description: "County", example: "" };
    export const Town: AddressElement = { elementName: "town", description: "Town", example: "" };
    export const PreferredTown: AddressElement = { elementName: "preferredTown", description: "Preferred town name", example: "" };
    export const LocalityL1: AddressElement = { elementName: "localityL1", description: "Locality L1", example: "" };
    export const LocalityL2: AddressElement = { elementName: "localityL2", description: "Locality L2", example: "" };
    export const LocalityL3: AddressElement = { elementName: "localityL3", description: "Locality L3", example: "" };
    export const Postcode: AddressElement = { elementName: "postcode", description: "Postcode", example: "" };
    export const PostcodeAlt1: AddressElement = { elementName: "postcodeAlt1", description: "Postcode alternative information 1", example: "" };
    export const PostcodeAlt2: AddressElement = { elementName: "postcodeAlt2", description: "Postcode alternative information 2", example: "" };
    export const Country: AddressElement = { elementName: "country", description: "Country", example: "" };
    export const CountryCode: AddressElement = { elementName: "countryCode", description: "Country code", example: "" };
    export const Retained: AddressElement = { elementName: "retained", description: "Retained", example: "" };

    export function getElementByName(elementName: string): AddressElement | undefined {
        return Object.values(GbrAddressElements)
            .filter((element): element is AddressElement => typeof element === "object" && "elementName" in element)
            .find((element) => element.elementName === elementName);
    }
}