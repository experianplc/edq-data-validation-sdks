using System.Reflection;

namespace DVSClient.Address.Layout.Elements
{
    internal class Aus : CommonElements, IAddressElement
    {
        public static readonly AddressElement BuildingName2 = new AddressElement("buildingName2", "Building Name 2", "North Wing");
        public static readonly AddressElement BuildingName = new AddressElement("buildingName", "Building name", "Treasury Building");
        public static readonly AddressElement FlatUnitName = new AddressElement("flatUnitName", "Flat/unit name", "Flat 2");
        public static readonly AddressElement FlatUnitType = new AddressElement("flatUnitType", "Flat/unit type", "Flat");
        public static readonly AddressElement FlatUnitNumber = new AddressElement("flatUnitNumber", "Flat/unit number", "2");
        public static readonly AddressElement BuildingLevel = new AddressElement("buildingLevel", "Building level", "Level 7");
        public static readonly AddressElement BuildingLevelType = new AddressElement("buildingLevelType", "Building level type", "Level");
        public static readonly AddressElement BuildingLevelNumber = new AddressElement("buildingLevelNumber", "Building level number", "7");
        public static readonly AddressElement AllotmentNumber1 = new AddressElement("allotmentNumber1", "Allotment number", "Lot 16");
        public static readonly AddressElement AllotmentLot = new AddressElement("allotmentLot", "Allotment lot", "Lot");
        public static readonly AddressElement AllotmentNumber2 = new AddressElement("allotmentNumber2", "Allotment number", "16");
        public static readonly AddressElement SubbuildingNumber = new AddressElement("subbuildingNumber", "Sub-building number", "2a");
        public static readonly AddressElement SubbuildingNumberNumber = new AddressElement("subbuildingNumberNumber", "Sub-building number (number)", "2");
        public static readonly AddressElement SubbuildingNumberAlpha = new AddressElement("subbuildingNumberAlpha", "Sub-building number (alpha)", "a");
        public static readonly AddressElement BuildingNumber = new AddressElement("buildingNumber", "Building number", "1-26");
        public static readonly AddressElement BuildingNumberFirst = new AddressElement("buildingNumberFirst", "Building number (first)", "1");
        public static readonly AddressElement BuildingNumberLast = new AddressElement("buildingNumberLast", "Building number (last)", "26");
        public static readonly AddressElement AllPostalDeliveryTypes = new AddressElement("allPostalDeliveryTypes", "All postal delivery types", "");
        public static readonly AddressElement Type = new AddressElement("type", "Type", "PO Box");
        public static readonly AddressElement Number = new AddressElement("number", "Number", "87");
        public static readonly AddressElement PoBox = new AddressElement("poBox", "PO Box", "PO Box 65");
        public static readonly AddressElement GpoBox = new AddressElement("gpoBox", "GPO Box", "GPO Box M929");
        public static readonly AddressElement CarePo = new AddressElement("carePo", "Care PO", "Care PO");
        public static readonly AddressElement RoadsideMailBox = new AddressElement("roadsideMailBox", "Roadside Mail Box", "RMB 65");
        public static readonly AddressElement RoadsideDelivery = new AddressElement("roadsideDelivery", "Roadside Delivery", "RSD 21");
        public static readonly AddressElement CommunityMailAgent = new AddressElement("communityMailAgent", "Community Mail Agent", "CMA");
        public static readonly AddressElement CommunityPostalAgent = new AddressElement("communityPostalAgent", "Community Postal Agent", "CPA");
        public static readonly AddressElement PrivateBag = new AddressElement("privateBag", "Private Bag", "Private Bag 6060");
        public static readonly AddressElement LockedBag = new AddressElement("lockedBag", "Locked Bag", "Locked Bag 3");
        public static readonly AddressElement MailService = new AddressElement("mailService", "Mail Service", "MS 494");
        public static readonly AddressElement CommunityMailBag = new AddressElement("communityMailBag", "Community Mail Bag", "CMB 111");
        public static readonly AddressElement RoadsideMailService = new AddressElement("roadsideMailService", "Roadside Mail Service", "RMS 1600");
        public static readonly AddressElement Street = new AddressElement("street", "Street", "Tudor Court East");
        public static readonly AddressElement StreetName = new AddressElement("streetName", "Street name", "Tudor");
        public static readonly AddressElement StreetType = new AddressElement("streetType", "Street type", "Court");
        public static readonly AddressElement StreetTypeSuffix = new AddressElement("streetTypeSuffix", "Street type suffix", "East");
        public static readonly AddressElement Locality = new AddressElement("locality", "Locality", "Ayr");
        public static readonly AddressElement InvalidLocalityAlias = new AddressElement("invalidLocalityAlias", "Invalid Locality Alias", "Mt Kelly");
        public static readonly AddressElement BorderingLocality = new AddressElement("borderingLocality", "Bordering Locality", "Alderley");
        public static readonly AddressElement StateCode = new AddressElement("stateCode", "State code", "QLD");
        public static readonly AddressElement PostalCode = new AddressElement("postalCode", "Postal code", "4807");
        public static readonly AddressElement BorderingLocalityPostcode = new AddressElement("borderingLocalityPostcode", "Bordering Locality Postcode", "4051");
        public static readonly AddressElement DeliveryPointIdentifierDpidDid = new AddressElement("deliveryPointIdentifierDpidDid", "Delivery Point Identifier (DPID/DID)", "56729927");
        public static readonly AddressElement PrimaryPoint = new AddressElement("primaryPoint", "Primary Point", "R");
        public static readonly AddressElement StateName = new AddressElement("stateName", "State name", "Queensland");
        public static readonly AddressElement CountryName = new AddressElement("countryName", "Country name", "Australia");
        public static readonly AddressElement TwoCharacterIsoCountryCode = new AddressElement("twoCharacterIsoCountryCode", "Two character ISO country code", "AU");
        public static readonly AddressElement ThreeCharacterIsoCountryCode = new AddressElement("threeCharacterIsoCountryCode", "Three character ISO country code", "AUS");
        public static readonly AddressElement BarcodeSortPlanNumber = new AddressElement("barcodeSortPlanNumber", "3 digit Barcode Sort Plan (BSP) number for an address", "");
        public static readonly AddressElement ChangeOfAddressDate = new AddressElement("changeOfAddressDate", "Change of Address date", "");
        public static readonly AddressElement ChangeOfAddressFlag = new AddressElement("changeOfAddressFlag", "Change of Address flag", "3");
        public static readonly AddressElement Hin = new AddressElement("hin", "10 digit Household Identification Number", "");
        public static readonly AddressElement MosaicGroup = new AddressElement("mosaicGroup", "Mosaic group", "K");
        public static readonly AddressElement MosaicType = new AddressElement("mosaicType", "Mosaic group and type", "K39");
        public static readonly AddressElement MosaicElement = new AddressElement("mosaicElement", "Mosaic Element", "K39_1");
        public static readonly AddressElement HouseholdMosaicElement = new AddressElement("householdMosaicElement", "Household Mosaic Element", "K39_1");
        public static readonly AddressElement Affluence = new AddressElement("affluence", "Affluence band", "3");
        public static readonly AddressElement HouseholdIncome = new AddressElement("householdIncome", "Household Income band", "5");
        public static readonly AddressElement MaximumLengthOfResidence = new AddressElement("maximumLengthOfResidence", "Length of Residence band", "2");
        public static readonly AddressElement Relations = new AddressElement("relations", "Household Composition category", "2");
        public static readonly AddressElement HeadOfHouseholdAge = new AddressElement("headOfHouseholdAge", "Head of Household Age band", "11");
        public static readonly AddressElement Lifestage = new AddressElement("lifestage", "Lifestage band", "09");
        public static readonly AddressElement AdultsAtAddress = new AddressElement("adultsAtAddress", "Number of adults at the address", "3");
        public static readonly AddressElement PropensityForChildren0To10Years = new AddressElement("propensityForChildren0To10Years", "Propensity for Children 0-10 years", "02");
        public static readonly AddressElement PropensityForChildren11To18Years = new AddressElement("propensityForChildren11To18Years", "Propensity for Children 11-18 years", "05");
        public static readonly AddressElement F1ScoreFamilyComposition = new AddressElement("f1ScoreFamilyComposition", "Factors score for Family Composition", "-24255");
        public static readonly AddressElement F1PercentileFamilyComposition = new AddressElement("f1PercentileFamilyComposition", "Factors percentile for Family Composition", "13");
        public static readonly AddressElement F2ScoreProsperity = new AddressElement("f2ScoreProsperity", "Factors score for Prosperity", "-024255");
        public static readonly AddressElement F2PercentileProsperity = new AddressElement("f2PercentileProsperity", "Factors percentile for Prosperity", "13");
        public static readonly AddressElement F3ScoreDependants = new AddressElement("f3ScoreDependants", "Factors score for Dependants", "-24255");
        public static readonly AddressElement F3PercentileDependants = new AddressElement("f3PercentileDependants", "Factors percentile for Dependants", "13");
        public static readonly AddressElement F4ScoreCulturalDiversity = new AddressElement("f4ScoreCulturalDiversity", "Factors score for Cultural Diversity", "-24255");
        public static readonly AddressElement F4PercentileCulturalDiversity = new AddressElement("f4PercentileCulturalDiversity", "Factors percentile for Cultural Diversity", "13");
        public static readonly AddressElement F5ScoreHousingOwnership = new AddressElement("f5ScoreHousingOwnership", "Factors score for Housing Ownership", "-24255");
        public static readonly AddressElement F5PercentileHousingOwnership = new AddressElement("f5PercentileHousingOwnership", "Factors percentile for Housing Ownership", "13");
        public static readonly AddressElement F6ScoreMultiDwellings = new AddressElement("f6ScoreMultiDwellings", "Factors score for Multi Dwellings", "-24255");
        public static readonly AddressElement F6PercentileMultiDwellings = new AddressElement("f6PercentileMultiDwellings", "Factors percentile for Multi Dwellings", "13");
        public static readonly AddressElement GnafLatitude = new AddressElement("gnafLatitude", "Latitude of the address", "-37.36555450");
        public static readonly AddressElement GnafLongitude = new AddressElement("gnafLongitude", "Longitude of the address", "144.52962801");
        public static readonly AddressElement LocalGovernmentAreaCode = new AddressElement("localGovernmentAreaCode", "LGA code", "39299");
        public static readonly AddressElement LocalGovernmentAreaDescription = new AddressElement("localGovernmentAreaDescription", "Name of the Local Government Area", "Onkaparinga (C)");
        public static readonly AddressElement BusinessResidentialCode = new AddressElement("businessResidentialCode", "Premises type for the DPID", "R");
        public static readonly AddressElement Ausbar = new AddressElement("ausbar", "Standard address barcode for an address", "");
        public static readonly AddressElement MeshBlock = new AddressElement("meshblock", "11 digit meshblock code", "");
        public static readonly AddressElement MeshBlockLatitude = new AddressElement("meshblockLatitude", "Latitude of the Meshblock centroid", "-37.36647900");
        public static readonly AddressElement MeshBlockLongitude = new AddressElement("meshblockLongitude", "Longitude of the Meshblock centroid", "144.53153100");
        public static readonly AddressElement Sa1Code = new AddressElement("sa1Code", "7 digit SA1 code", "");
        public static readonly AddressElement Sa1Latitude = new AddressElement("sa1Latitude", "Latitude of the SA1 centroid", "-37.36647900");
        public static readonly AddressElement Sa1Longitude = new AddressElement("sa1Longitude", "Longitude of the SA1 centroid", "144.53153100");

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