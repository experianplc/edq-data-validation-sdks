using System.Reflection;

namespace DVSClient.Address.Layout.Elements
{
    public class Aus : IAddressElement
    {
        public static readonly Aus BuildingName2 = new Aus("buildingName2", "Building Name 2", "North Wing");
        public static readonly Aus BuildingName = new Aus("buildingName", "Building name", "Treasury Building");
        public static readonly Aus FlatUnitName = new Aus("flatUnitName", "Flat/unit name", "Flat 2");
        public static readonly Aus FlatUnitType = new Aus("flatUnitType", "Flat/unit type", "Flat");
        public static readonly Aus FlatUnitNumber = new Aus("flatUnitNumber", "Flat/unit number", "2");
        public static readonly Aus BuildingLevel = new Aus("buildingLevel", "Building level", "Level 7");
        public static readonly Aus BuildingLevelType = new Aus("buildingLevelType", "Building level type", "Level");
        public static readonly Aus BuildingLevelNumber = new Aus("buildingLevelNumber", "Building level number", "7");
        public static readonly Aus AllotmentNumber1 = new Aus("allotmentNumber1", "Allotment number", "Lot 16");
        public static readonly Aus AllotmentLot = new Aus("allotmentLot", "Allotment lot", "Lot");
        public static readonly Aus AllotmentNumber2 = new Aus("allotmentNumber2", "Allotment number", "16");
        public static readonly Aus SubbuildingNumber = new Aus("subbuildingNumber", "Sub-building number", "2a");
        public static readonly Aus SubbuildingNumberNumber = new Aus("subbuildingNumberNumber", "Sub-building number (number)", "2");
        public static readonly Aus SubbuildingNumberAlpha = new Aus("subbuildingNumberAlpha", "Sub-building number (alpha)", "a");
        public static readonly Aus BuildingNumber = new Aus("buildingNumber", "Building number", "1-26");
        public static readonly Aus BuildingNumberFirst = new Aus("buildingNumberFirst", "Building number (first)", "1");
        public static readonly Aus BuildingNumberLast = new Aus("buildingNumberLast", "Building number (last)", "26");
        public static readonly Aus AllPostalDeliveryTypes = new Aus("allPostalDeliveryTypes", "All postal delivery types", "");
        public static readonly Aus Type = new Aus("type", "Type", "PO Box");
        public static readonly Aus Number = new Aus("number", "Number", "87");
        public static readonly Aus PoBox = new Aus("poBox", "PO Box", "PO Box 65");
        public static readonly Aus GpoBox = new Aus("gpoBox", "GPO Box", "GPO Box M929");
        public static readonly Aus CarePo = new Aus("carePo", "Care PO", "Care PO");
        public static readonly Aus RoadsideMailBox = new Aus("roadsideMailBox", "Roadside Mail Box", "RMB 65");
        public static readonly Aus RoadsideDelivery = new Aus("roadsideDelivery", "Roadside Delivery", "RSD 21");
        public static readonly Aus CommunityMailAgent = new Aus("communityMailAgent", "Community Mail Agent", "CMA");
        public static readonly Aus CommunityPostalAgent = new Aus("communityPostalAgent", "Community Postal Agent", "CPA");
        public static readonly Aus PrivateBag = new Aus("privateBag", "Private Bag", "Private Bag 6060");
        public static readonly Aus LockedBag = new Aus("lockedBag", "Locked Bag", "Locked Bag 3");
        public static readonly Aus MailService = new Aus("mailService", "Mail Service", "MS 494");
        public static readonly Aus CommunityMailBag = new Aus("communityMailBag", "Community Mail Bag", "CMB 111");
        public static readonly Aus RoadsideMailService = new Aus("roadsideMailService", "Roadside Mail Service", "RMS 1600");
        public static readonly Aus Street = new Aus("street", "Street", "Tudor Court East");
        public static readonly Aus StreetName = new Aus("streetName", "Street name", "Tudor");
        public static readonly Aus StreetType = new Aus("streetType", "Street type", "Court");
        public static readonly Aus StreetTypeSuffix = new Aus("streetTypeSuffix", "Street type suffix", "East");
        public static readonly Aus Locality = new Aus("locality", "Locality", "Ayr");
        public static readonly Aus InvalidLocalityAlias = new Aus("invalidLocalityAlias", "Invalid Locality Alias", "Mt Kelly");
        public static readonly Aus BorderingLocality = new Aus("borderingLocality", "Bordering Locality", "Alderley");
        public static readonly Aus StateCode = new Aus("stateCode", "State code", "QLD");
        public static readonly Aus PostalCode = new Aus("postalCode", "Postal code", "4807");
        public static readonly Aus BorderingLocalityPostcode = new Aus("borderingLocalityPostcode", "Bordering Locality Postcode", "4051");
        public static readonly Aus DeliveryPointIdentifierDpidDid = new Aus("deliveryPointIdentifierDpidDid", "Delivery Point Identifier (DPID/DID)", "56729927");
        public static readonly Aus PrimaryPoint = new Aus("primaryPoint", "Primary Point", "R");
        public static readonly Aus StateName = new Aus("stateName", "State name", "Queensland");
        public static readonly Aus CountryName = new Aus("countryName", "Country name", "Australia");
        public static readonly Aus TwoCharacterIsoCountryCode = new Aus("twoCharacterIsoCountryCode", "Two character ISO country code", "AU");
        public static readonly Aus ThreeCharacterIsoCountryCode = new Aus("threeCharacterIsoCountryCode", "Three character ISO country code", "AUS");
        public static readonly Aus BarcodeSortPlanNumber = new Aus("barcodeSortPlanNumber", "3 digit Barcode Sort Plan (BSP) number for an address", "");
        public static readonly Aus ChangeOfAddressDate = new Aus("changeOfAddressDate", "Change of Address date", "");
        public static readonly Aus ChangeOfAddressFlag = new Aus("changeOfAddressFlag", "Change of Address flag", "3");
        public static readonly Aus Hin = new Aus("hin", "10 digit Household Identification Number", "");
        public static readonly Aus MosaicGroup = new Aus("mosaicGroup", "Mosaic group", "K");
        public static readonly Aus MosaicType = new Aus("mosaicType", "Mosaic group and type", "K39");
        public static readonly Aus MosaicElement = new Aus("mosaicElement", "Mosaic Element", "K39_1");
        public static readonly Aus HouseholdMosaicElement = new Aus("householdMosaicElement", "Household Mosaic Element", "K39_1");
        public static readonly Aus Affluence = new Aus("affluence", "Affluence band", "3");
        public static readonly Aus HouseholdIncome = new Aus("householdIncome", "Household Income band", "5");
        public static readonly Aus MaximumLengthOfResidence = new Aus("maximumLengthOfResidence", "Length of Residence band", "2");
        public static readonly Aus Relations = new Aus("relations", "Household Composition category", "2");
        public static readonly Aus HeadOfHouseholdAge = new Aus("headOfHouseholdAge", "Head of Household Age band", "11");
        public static readonly Aus Lifestage = new Aus("lifestage", "Lifestage band", "09");
        public static readonly Aus AdultsAtAddress = new Aus("adultsAtAddress", "Number of adults at the address", "3");
        public static readonly Aus PropensityForChildren0To10Years = new Aus("propensityForChildren0To10Years", "Propensity for Children 0-10 years", "02");
        public static readonly Aus PropensityForChildren11To18Years = new Aus("propensityForChildren11To18Years", "Propensity for Children 11-18 years", "05");
        public static readonly Aus F1ScoreFamilyComposition = new Aus("f1ScoreFamilyComposition", "Factors score for Family Composition", "-24255");
        public static readonly Aus F1PercentileFamilyComposition = new Aus("f1PercentileFamilyComposition", "Factors percentile for Family Composition", "13");
        public static readonly Aus F2ScoreProsperity = new Aus("f2ScoreProsperity", "Factors score for Prosperity", "-024255");
        public static readonly Aus F2PercentileProsperity = new Aus("f2PercentileProsperity", "Factors percentile for Prosperity", "13");
        public static readonly Aus F3ScoreDependants = new Aus("f3ScoreDependants", "Factors score for Dependants", "-24255");
        public static readonly Aus F3PercentileDependants = new Aus("f3PercentileDependants", "Factors percentile for Dependants", "13");
        public static readonly Aus F4ScoreCulturalDiversity = new Aus("f4ScoreCulturalDiversity", "Factors score for Cultural Diversity", "-24255");
        public static readonly Aus F4PercentileCulturalDiversity = new Aus("f4PercentileCulturalDiversity", "Factors percentile for Cultural Diversity", "13");
        public static readonly Aus F5ScoreHousingOwnership = new Aus("f5ScoreHousingOwnership", "Factors score for Housing Ownership", "-24255");
        public static readonly Aus F5PercentileHousingOwnership = new Aus("f5PercentileHousingOwnership", "Factors percentile for Housing Ownership", "13");
        public static readonly Aus F6ScoreMultiDwellings = new Aus("f6ScoreMultiDwellings", "Factors score for Multi Dwellings", "-24255");
        public static readonly Aus F6PercentileMultiDwellings = new Aus("f6PercentileMultiDwellings", "Factors percentile for Multi Dwellings", "13");
        public static readonly Aus GnafLatitude = new Aus("gnafLatitude", "Latitude of the address", "-37.36555450");
        public static readonly Aus GnafLongitude = new Aus("gnafLongitude", "Longitude of the address", "144.52962801");
        public static readonly Aus LocalGovernmentAreaCode = new Aus("localGovernmentAreaCode", "LGA code", "39299");
        public static readonly Aus LocalGovernmentAreaDescription = new Aus("localGovernmentAreaDescription", "Name of the Local Government Area", "Onkaparinga (C)");
        public static readonly Aus BusinessResidentialCode = new Aus("businessResidentialCode", "Premises type for the DPID", "R");
        public static readonly Aus Ausbar = new Aus("ausbar", "Standard address barcode for an address", "");
        public static readonly Aus MeshBlock = new Aus("meshblock", "11 digit meshblock code", "");
        public static readonly Aus MeshBlockLatitude = new Aus("meshblockLatitude", "Latitude of the Meshblock centroid", "-37.36647900");
        public static readonly Aus MeshBlockLongitude = new Aus("meshblockLongitude", "Longitude of the Meshblock centroid", "144.53153100");
        public static readonly Aus Sa1Code = new Aus("sa1Code", "7 digit SA1 code", "");
        public static readonly Aus Sa1Latitude = new Aus("sa1Latitude", "Latitude of the SA1 centroid", "-37.36647900");
        public static readonly Aus Sa1Longitude = new Aus("sa1Longitude", "Longitude of the SA1 centroid", "144.53153100");

        private string elementName { get; set; }
        private string description { get; set; }
        private string example { get; set; }

        public Aus(string elementName, string description, string example)
        {
            this.elementName = elementName;
            this.description = description;
            this.example = example;
        }

        public static IAddressElement? GetElement(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Type addressElementType = typeof(Aus);
                FieldInfo? addressElementProperty = addressElementType.GetField(name);

                if (addressElementProperty != null)
                {
                    return (IAddressElement?)addressElementProperty.GetValue(name);
                }
            }

            return null;
        }

        public string GetElementName()
        {
            return elementName;
        }
    }
}