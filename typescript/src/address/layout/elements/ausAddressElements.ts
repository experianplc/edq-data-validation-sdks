import { AddressElement } from "./addressElement";

export namespace AusAddressElements {
    
    export const BuildingName2: AddressElement = { elementName: "buildingName2", description: "Building Name 2", example: "North Wing" };
    export const BuildingName: AddressElement = { elementName: "buildingName", description: "Building name", example: "Treasury Building" };
    export const FlatUnitName: AddressElement = { elementName: "flatUnitName", description: "Flat/unit name", example: "Flat 2" };
    export const FlatUnitType: AddressElement = { elementName: "flatUnitType", description: "Flat/unit type", example: "Flat" };
    export const FlatUnitNumber: AddressElement = { elementName: "flatUnitNumber", description: "Flat/unit number", example: "2" };
    export const BuildingLevel: AddressElement = { elementName: "buildingLevel", description: "Building level", example: "Level 7" };
    export const BuildingLevelType: AddressElement = { elementName: "buildingLevelType", description: "Building level type", example: "Level" };
    export const BuildingLevelNumber: AddressElement = { elementName: "buildingLevelNumber", description: "Building level number", example: "7" };
    export const AllotmentNumber1: AddressElement = { elementName: "allotmentNumber1", description: "Allotment number", example: "Lot 16" };
    export const AllotmentLot: AddressElement = { elementName: "allotmentLot", description: "Allotment lot", example: "Lot" };
    export const AllotmentNumber2: AddressElement = { elementName: "allotmentNumber2", description: "Allotment number", example: "16" };
    export const SubbuildingNumber: AddressElement = { elementName: "subbuildingNumber", description: "Sub-building number", example: "2a" };
    export const SubbuildingNumberNumber: AddressElement = { elementName: "subbuildingNumberNumber", description: "Sub-building number (number)", example: "2" };
    export const SubbuildingNumberAlpha: AddressElement = { elementName: "subbuildingNumberAlpha", description: "Sub-building number (alpha)", example: "a" };
    export const BuildingNumber: AddressElement = { elementName: "buildingNumber", description: "Building number", example: "1-26" };
    export const BuildingNumberFirst: AddressElement = { elementName: "buildingNumberFirst", description: "Building number (first)", example: "1" };
    export const BuildingNumberLast: AddressElement = { elementName: "buildingNumberLast", description: "Building number (last)", example: "26" };
    export const AllPostalDeliveryTypes: AddressElement = { elementName: "allPostalDeliveryTypes", description: "All postal delivery types", example: "" };
    export const Type: AddressElement = { elementName: "type", description: "Type", example: "PO Box" };
    export const Number: AddressElement = { elementName: "number", description: "Number", example: "87" }; //NOSONAR
    export const PoBox: AddressElement = { elementName: "poBox", description: "PO Box", example: "PO Box 65" };
    export const GpoBox: AddressElement = { elementName: "gpoBox", description: "GPO Box", example: "GPO Box M929" };
    export const CarePo: AddressElement = { elementName: "carePo", description: "Care PO", example: "Care PO" };
    export const RoadsideMailBox: AddressElement = { elementName: "roadsideMailBox", description: "Roadside Mail Box", example: "RMB 65" };
    export const RoadsideDelivery: AddressElement = { elementName: "roadsideDelivery", description: "Roadside Delivery", example: "RSD 21" };
    export const CommunityMailAgent: AddressElement = { elementName: "communityMailAgent", description: "Community Mail Agent", example: "CMA" };
    export const CommunityPostalAgent: AddressElement = { elementName: "communityPostalAgent", description: "Community Postal Agent", example: "CPA" };
    export const PrivateBag: AddressElement = { elementName: "privateBag", description: "Private Bag", example: "Private Bag 6060" };
    export const LockedBag: AddressElement = { elementName: "lockedBag", description: "Locked Bag", example: "Locked Bag 3" };
    export const MailService: AddressElement = { elementName: "mailService", description: "Mail Service", example: "MS 494" };
    export const CommunityMailBag: AddressElement = { elementName: "communityMailBag", description: "Community Mail Bag", example: "CMB 111" };
    export const RoadsideMailService: AddressElement = { elementName: "roadsideMailService", description: "Roadside Mail Service", example: "RMS 1600" };
    export const Street: AddressElement = { elementName: "street", description: "Street", example: "Tudor Court East" };
    export const StreetName: AddressElement = { elementName: "streetName", description: "Street name", example: "Tudor" };
    export const StreetType: AddressElement = { elementName: "streetType", description: "Street type", example: "Court" };
    export const StreetTypeSuffix: AddressElement = { elementName: "streetTypeSuffix", description: "Street type suffix", example: "East" };
    export const Locality: AddressElement = { elementName: "locality", description: "Locality", example: "Ayr" };
    export const InvalidLocalityAlias: AddressElement = { elementName: "invalidLocalityAlias", description: "Invalid Locality Alias", example: "Mt Kelly" };
    export const BorderingLocality: AddressElement = { elementName: "borderingLocality", description: "Bordering Locality", example: "Alderley" };
    export const StateCode: AddressElement = { elementName: "stateCode", description: "State code", example: "QLD" };
    export const PostalCode: AddressElement = { elementName: "postalCode", description: "Postal code", example: "4807" };
    export const BorderingLocalityPostcode: AddressElement = { elementName: "borderingLocalityPostcode", description: "Bordering Locality Postcode", example: "4051" };
    export const DeliveryPointIdentifierDpidDid: AddressElement = { elementName: "deliveryPointIdentifierDpidDid", description: "Delivery Point Identifier (DPID/DID)", example: "56729927" };
    export const PrimaryPoint: AddressElement = { elementName: "primaryPoint", description: "Primary Point", example: "R" };
    export const StateName: AddressElement = { elementName: "stateName", description: "State name", example: "Queensland" };
    export const CountryName: AddressElement = { elementName: "countryName", description: "Country name", example: "Australia" };
    export const TwoCharacterIsoCountryCode: AddressElement = { elementName: "twoCharacterIsoCountryCode", description: "Two character ISO country code", example: "AU" };
    export const ThreeCharacterIsoCountryCode: AddressElement = { elementName: "threeCharacterIsoCountryCode", description: "Three character ISO country code", example: "AUS" };
    export const BarcodeSortPlanNumber: AddressElement = { elementName: "barcodeSortPlanNumber", description: "3 digit Barcode Sort Plan (BSP) number for an address", example: "" };
    export const ChangeOfAddressDate: AddressElement = { elementName: "changeOfAddressDate", description: "Change of Address date", example: "" };
    export const ChangeOfAddressFlag: AddressElement = { elementName: "changeOfAddressFlag", description: "Change of Address flag", example: "3" };
    export const Hin: AddressElement = { elementName: "hin", description: "10 digit Household Identification Number", example: "" };
    export const MosaicGroup: AddressElement = { elementName: "mosaicGroup", description: "Mosaic group", example: "K" };
    export const MosaicType: AddressElement = { elementName: "mosaicType", description: "Mosaic group and type", example: "K39" };
    export const MosaicElement: AddressElement = { elementName: "mosaicElement", description: "Mosaic Element", example: "K39_1" };
    export const HouseholdMosaicElement: AddressElement = { elementName: "householdMosaicElement", description: "Household Mosaic Element", example: "K39_1" };
    export const Affluence: AddressElement = { elementName: "affluence", description: "Affluence band", example: "3" };
    export const HouseholdIncome: AddressElement = { elementName: "householdIncome", description: "Household Income band", example: "5" };
    export const MaximumLengthOfResidence: AddressElement = { elementName: "maximumLengthOfResidence", description: "Length of Residence band", example: "2" };
    export const Relations: AddressElement = { elementName: "relations", description: "Household Composition category", example: "2" };
    export const HeadOfHouseholdAge: AddressElement = { elementName: "headOfHouseholdAge", description: "Head of Household Age band", example: "11" };
    export const Lifestage: AddressElement = { elementName: "lifestage", description: "Lifestage band", example: "09" };
    export const AdultsAtAddress: AddressElement = { elementName: "adultsAtAddress", description: "Number of adults at the address", example: "3" };
    export const PropensityForChildren0To10Years: AddressElement = { elementName: "propensityForChildren0To10Years", description: "Propensity for Children 0-10 years", example: "02" };
    export const PropensityForChildren11To18Years: AddressElement = { elementName: "propensityForChildren11To18Years", description: "Propensity for Children 11-18 years", example: "05" };
    export const F1ScoreFamilyComposition: AddressElement = { elementName: "f1ScoreFamilyComposition", description: "Factors score for Family Composition", example: "-24255" };
    export const F1PercentileFamilyComposition: AddressElement = { elementName: "f1PercentileFamilyComposition", description: "Factors percentile for Family Composition", example: "13" };
    export const F2ScoreProsperity: AddressElement = { elementName: "f2ScoreProsperity", description: "Factors score for Prosperity", example: "-024255" };
    export const F2PercentileProsperity: AddressElement = { elementName: "f2PercentileProsperity", description: "Factors percentile for Prosperity", example: "13" };
    export const F3ScoreDependants: AddressElement = { elementName: "f3ScoreDependants", description: "Factors score for Dependants", example: "-24255" };
    export const F3PercentileDependants: AddressElement = { elementName: "f3PercentileDependants", description: "Factors percentile for Dependants", example: "13" };
    export const F4ScoreCulturalDiversity: AddressElement = { elementName: "f4ScoreCulturalDiversity", description: "Factors score for Cultural Diversity", example: "-24255" };
    export const F4PercentileCulturalDiversity: AddressElement = { elementName: "f4PercentileCulturalDiversity", description: "Factors percentile for Cultural Diversity", example: "13" };
    export const F5ScoreHousingOwnership: AddressElement = { elementName: "f5ScoreHousingOwnership", description: "Factors score for Housing Ownership", example: "-24255" };
    export const F5PercentileHousingOwnership: AddressElement = { elementName: "f5PercentileHousingOwnership", description: "Factors percentile for Housing Ownership", example: "13" };
    export const F6ScoreMultiDwellings: AddressElement = { elementName: "f6ScoreMultiDwellings", description: "Factors score for Multi Dwellings", example: "-24255" };
    export const F6PercentileMultiDwellings: AddressElement = { elementName: "f6PercentileMultiDwellings", description: "Factors percentile for Multi Dwellings", example: "13" };
    export const GnafLatitude: AddressElement = { elementName: "gnafLatitude", description: "Latitude of the address", example: "-37.36555450" };
    export const GnafLongitude: AddressElement = { elementName: "gnafLongitude", description: "Longitude of the address", example: "144.52962801" };
    export const LocalGovernmentAreaCode: AddressElement = { elementName: "localGovernmentAreaCode", description: "LGA code", example: "39299" };
    export const LocalGovernmentAreaDescription: AddressElement = { elementName: "localGovernmentAreaDescription", description: "Name of the Local Government Area", example: "Onkaparinga (C)" };
    export const BusinessResidentialCode: AddressElement = { elementName: "businessResidentialCode", description: "Premises type for the DPID", example: "R" };
    export const Ausbar: AddressElement = { elementName: "ausbar", description: "Standard address barcode for an address", example: "" };
    export const MeshBlock: AddressElement = { elementName: "meshblock", description: "11 digit meshblock code", example: "" };
    export const MeshBlockLatitude: AddressElement = { elementName: "meshblockLatitude", description: "Latitude of the Meshblock centroid", example: "-37.36647900" };
    export const MeshBlockLongitude: AddressElement = { elementName: "meshblockLongitude", description: "Longitude of the Meshblock centroid", example: "144.53153100" };
    export const Sa1Code: AddressElement = { elementName: "sa1Code", description: "7 digit SA1 code", example: "" };
    export const Sa1Latitude: AddressElement = { elementName: "sa1Latitude", description: "Latitude of the SA1 centroid", example: "-37.36647900" };
    export const Sa1Longitude: AddressElement = { elementName: "sa1Longitude", description: "Longitude of the SA1 centroid", example: "144.53153100" };

    export function getElementByName(elementName: string): AddressElement | undefined {
        return Object.values(AusAddressElements)
            .filter((element): element is AddressElement => typeof element === "object" && "elementName" in element)
            .find((element) => element.elementName === elementName);
    }
}