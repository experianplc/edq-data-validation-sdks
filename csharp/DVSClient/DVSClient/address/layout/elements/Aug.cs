using System.Reflection;

namespace DVSClient.Address.Layout.Elements
{
    internal class Aug : CommonElements, IAddressElement
    {
        public static readonly AddressElement BuildingName = new AddressElement("buildingName", "Building name", "Treasury Building");
        public static readonly AddressElement FlatUnitName = new AddressElement("flatUnitName", "Flat/Unit name", "Flat 2");
        public static readonly AddressElement FlatUnitType = new AddressElement("flatUnitType", "Flat/Unit type", "Flat");
        public static readonly AddressElement FlatUnitNumber = new AddressElement("flatUnitNumber", "Flat/unit number", "2");
        public static readonly AddressElement SubBuildingNumber = new AddressElement("subBuildingNumber", "Sub-building number", "5a");
        public static readonly AddressElement SubBuildingNumberNumber = new AddressElement("subBuildingNumberNumber", "Sub-building number (number)", "5");
        public static readonly AddressElement SubBuildingNumberAlpha = new AddressElement("subBuildingNumberAlpha", "Sub-building number (alpha)", "a");
        public static readonly AddressElement BuildingLevel = new AddressElement("buildingLevel", "Building level", "Level 7");
        public static readonly AddressElement BuildingLevelType = new AddressElement("buildingLevelType", "Building level type", "Level");
        public static readonly AddressElement BuildingLevelNumber = new AddressElement("buildingLevelNumber", "Building level number", "7");
        public static readonly AddressElement BuildingNumber = new AddressElement("buildingNumber", "Building number", "1-131");
        public static readonly AddressElement BuildingNumberFirst = new AddressElement("buildingNumberFirst", "Building number (first)", "1");
        public static readonly AddressElement BuildingNumberLast = new AddressElement("buildingNumberLast", "Building number (last)", "131");
        public static readonly AddressElement AllotmentNumber1 = new AddressElement("allotmentNumber1", "Allotment number", "Lot 16");
        public static readonly AddressElement AllotmentLot = new AddressElement("allotmentLot", "Allotment lot", "Lot");
        public static readonly AddressElement AllotmentNumber2 = new AddressElement("allotmentNumber2", "Allotment number", "16");
        public static readonly AddressElement Street = new AddressElement("street", "Street", "Tudor Court East");
        public static readonly AddressElement StreetName = new AddressElement("streetName", "Street name", "Tudor");
        public static readonly AddressElement StreetType = new AddressElement("streetType", "Street type", "Court");
        public static readonly AddressElement StreetTypeSuffix = new AddressElement("streetTypeSuffix", "Street type suffix", "East");
        public static readonly AddressElement PrivateStreet = new AddressElement("privateStreet", "Private Street", "Private Street");
        public static readonly AddressElement Locality = new AddressElement("locality", "Locality", "Ayr");
        public static readonly AddressElement BorderingLocality = new AddressElement("borderingLocality", "Bordering Locality", "Mt Kelly");
        public static readonly AddressElement StateCode = new AddressElement("stateCode", "State code", "QLD");
        public static readonly AddressElement StateName = new AddressElement("stateName", "State Name", "Queensland");
        public static readonly AddressElement Postcode = new AddressElement("postcode", "Postcode", "4807");
        public static readonly AddressElement CountryName = new AddressElement("countryName", "Country Name", "Australia");
        public static readonly AddressElement TwoCharacterIsoCountryCode = new AddressElement("twoCharacterIsoCountryCode", "Two character country code", "AU");
        public static readonly AddressElement ThreeCharacterIsoCountryCode = new AddressElement("threeCharacterIsoCountryCode", "Three character country code", "AUS");
        public static readonly AddressElement GeocodeLevelCode = new AddressElement("geocodeLevelCode", "This is the geocode level code", "2");
        public static readonly AddressElement GeocodeLevelDescription = new AddressElement("geocodeLevelDescription", "This is the geocode level description", "Street level geocode only");
        public static readonly AddressElement GeocodeTypeCode = new AddressElement("geocodeTypeCode", "This is the geocode type code", "LB");
        public static readonly AddressElement GeocodeTypeDescription = new AddressElement("geocodeTypeDescription", "This is the geocode type description", "Letterbox");
        public static readonly AddressElement AddressLevelLongitude = new AddressElement("addressLevelLongitude", "The address-level longitude in degrees", "");
        public static readonly AddressElement AddressLevelLatitude = new AddressElement("addressLevelLatitude", "The address-level latitude in degrees", "");
        public static readonly AddressElement AddressLevelElevation = new AddressElement("addressLevelElevation", "The address-level elevation", "");
        public static readonly AddressElement AddressLevelPlanimetricAccuracy = new AddressElement("addressLevelPlanimetricAccuracy", "The address-level planimetric accuracy", "");
        public static readonly AddressElement AddressLevelBoundaryExtent = new AddressElement("addressLevelBoundaryExtent", "The address-level boundary extent", "");
        public static readonly AddressElement AddressLevelGeocodeReliabilityCode = new AddressElement("addressLevelGeocodeReliabilityCode", "The address-level geocode reliability code", "2");
        public static readonly AddressElement AddressLevelGeocodeReliabilityDescription = new AddressElement("addressLevelGeocodeReliabilityDescription", "The address-level geocode reliability description", "Geocode accuracy sufficient to place centroid within address site boundary");
        public static readonly AddressElement StreetLevelLongitude = new AddressElement("streetLevelLongitude", "The street-level longitude in degrees", "");
        public static readonly AddressElement StreetLevelLatitude = new AddressElement("streetLevelLatitude", "The street-level latitude in degrees", "");
        public static readonly AddressElement StreetLevelPlanimetricAccuracy = new AddressElement("streetLevelPlanimetricAccuracy", "The street-level planimetric accuracy", "");
        public static readonly AddressElement StreetLevelBoundaryExtent = new AddressElement("streetLevelBoundaryExtent", "The street-level boundary extent", "");
        public static readonly AddressElement StreetLevelGeocodeReliabilityCode = new AddressElement("streetLevelGeocodeReliabilityCode", "The street-level geocode reliability code", "4");
        public static readonly AddressElement StreetLevelGeocodeReliabilityDescription = new AddressElement("streetLevelGeocodeReliabilityDescription", "The street-level geocode reliability description", "Geocode accuracy sufficient to associate address site with a unique road feature");
        public static readonly AddressElement LocalityLevelLongitude = new AddressElement("localityLevelLongitude", "The locality-level longitude in degrees", "");
        public static readonly AddressElement LocalityLevelLatitude = new AddressElement("localityLevelLatitude", "The locality-level latitude in degrees", "");
        public static readonly AddressElement LocalityLevelPlanimetricAccuracy = new AddressElement("localityLevelPlanimetricAccuracy", "The locality-level planimetric accuracy", "");
        public static readonly AddressElement LocalityLevelGeocodeReliabilityCode = new AddressElement("localityLevelGeocodeReliabilityCode", "The locality-level geocode reliability code", "5");
        public static readonly AddressElement LocalityLevelGeocodeReliabilityDescription = new AddressElement("localityLevelGeocodeReliabilityDescription", "The locality-level geocode reliability description", "Geocode accuracy sufficient to associate address site with a unique locality or neighbourhood");
        public static readonly AddressElement Longitude = new AddressElement("longitude", "The highest-level longitude in degrees", "");
        public static readonly AddressElement Latitude = new AddressElement("latitude", "The highest-level latitude in degrees", "");
        public static readonly AddressElement Elevation = new AddressElement("elevation", "The highest-level elevation", "");
        public static readonly AddressElement PlanimetricAccuracy = new AddressElement("planimetricAccuracy", "The highest-level planimetric accuracy", "");
        public static readonly AddressElement BoundaryExtent = new AddressElement("boundaryExtent", "The highest-level boundary extent", "");
        public static readonly AddressElement GeocodeReliabilityCode = new AddressElement("geocodeReliabilityCode", "The highest-level geocode reliability code", "");
        public static readonly AddressElement GeocodeReliabilityDescription = new AddressElement("geocodeReliabilityDescription", "The highest-level geocode reliability description", "");
        public static readonly AddressElement GnafPid = new AddressElement("gnafPid", "Persistent identifier of an address", "GANSW716798454");
        public static readonly AddressElement GnafAddressTypeCode = new AddressElement("gnafAddressTypeCode", "This is the address type code", "R/RMB");
        public static readonly AddressElement GnafAddressTypeDescription = new AddressElement("gnafAddressTypeDescription", "This is the address type description", "Rural Roadside Mail Box");
        public static readonly AddressElement StreetPid = new AddressElement("streetPid", "This is a unique street persistent identifier", "");
        public static readonly AddressElement LocalityPid = new AddressElement("localityPid", "This is a unique locality persistent identifier", "");
        public static readonly AddressElement ConfidenceLevelCode = new AddressElement("confidenceLevelCode", "This is the confidence level code", "2");
        public static readonly AddressElement ConfidenceLevelDescription = new AddressElement("confidenceLevelDescription", "This is the confidence level descriptor", "All three contributors have supplied an identical address");
        public static readonly AddressElement MeshBlockId2021 = new AddressElement("2021MeshBlockId", "The 2021 version of the Mesh Block ID", "");
        public static readonly AddressElement MeshBlockCode2021 = new AddressElement("2021MeshBlockCode", "The 11-digit 2021 version of the Mesh Block Code", "");
        public static readonly AddressElement MeshBlockMatchCode2021 = new AddressElement("2021MeshBlockMatchCode", "The code for the level of matching to 2021 Mesh Blocks", "");
        public static readonly AddressElement MeshBlockMatchDescription2021 = new AddressElement("2021MeshBlockMatchDescription", "The description of the 2021 Mesh Block match level", "");
        public static readonly AddressElement MeshBlockId2016 = new AddressElement("2016MeshBlockId", "The 2016 version of the MeshBlock ID", "");
        public static readonly AddressElement MeshBlockCode2016 = new AddressElement("2016MeshBlockCode", "The 11-digit 2016 version of the MeshBlock Code", "");
        public static readonly AddressElement MeshBlockMatchCode2016 = new AddressElement("2016MeshBlockMatchCode", "The code for the level of matching to 2016 Mesh Blocks", "");
        public static readonly AddressElement MeshBlockMatchDescription2016 = new AddressElement("2016MeshBlockMatchDescription", "The description of the 2016 Mesh Block match level", "");
        public static readonly AddressElement ComplexAddressTypeCode = new AddressElement("complexAddressTypeCode", "Returns the Address Type", "P");
        public static readonly AddressElement PrimaryAddressPid = new AddressElement("primaryAddressPid", "This element will only be populated if the input address is a secondary address", "");
        public static readonly AddressElement AddressJoinTypeCode = new AddressElement("addressJoinTypeCode", "Returns the Join Type Code", "");
        public static readonly AddressElement GnafLegalParcelIdentifier = new AddressElement("gnafLegalParcelIdentifier", "The Legal Parcel Id field", "");
        public static readonly AddressElement CollectorDistrictId = new AddressElement("collectorDistrictId", "This is a unique Collector District persistent identifier", "");
        public static readonly AddressElement CollectorDistrictCode = new AddressElement("collectorDistrictCode", "This is the Collector District Code", "");
        public static readonly AddressElement CommonwealthElectoralBoundaryId = new AddressElement("commonwealthElectoralBoundaryId", "This is a unique Commonwealth Electoral Boundary persistent identifier", "");
        public static readonly AddressElement CommonwealthElectoralBoundaryName = new AddressElement("commonwealthElectoralBoundaryName", "This is the Commonwealth Electoral Boundary name", "");
        public static readonly AddressElement LocalGovernmentAreaId = new AddressElement("localGovernmentAreaId", "This is a Local Government Area persistent identifier", "");
        public static readonly AddressElement LocalGovernmentAreaName = new AddressElement("localGovernmentAreaName", "This is the Local Government Area name", "");
        public static readonly AddressElement StatisticalLocalAreaId = new AddressElement("statisticalLocalAreaId", "This is a Statistical Local Area persistent identifier", "");
        public static readonly AddressElement StatisticalLocalAreaCode = new AddressElement("statisticalLocalAreaCode", "This is a Statistical Local Area code", "");
        public static readonly AddressElement StatisticalLocalAreaName = new AddressElement("statisticalLocalAreaName", "This is a Statistical Local Area name", "");
        public static readonly AddressElement StateElectoralBoundaryId = new AddressElement("stateElectoralBoundaryId", "This is a State Electoral Boundary persistent identifier", "");
        public static readonly AddressElement StateElectoralBoundaryName = new AddressElement("stateElectoralBoundaryName", "This is a State Electoral Boundary name", "");
        public static readonly AddressElement StateElectoralEffectiveStart = new AddressElement("stateElectoralEffectiveStart", "This is the date that the electorate becomes effective", "");
        public static readonly AddressElement StateElectoralEffectiveEnd = new AddressElement("stateElectoralEffectiveEnd", "This is the end date when electorate is no longer in effect", "");
        public static readonly AddressElement StateElectoralNewBoundaryId = new AddressElement("stateElectoralNewBoundaryId", "This is the State Electoral Boundary identifier for new electorate", "");
        public static readonly AddressElement StateElectoralNewBoundaryName = new AddressElement("stateElectoralNewBoundaryName", "This is the State Electoral Boundary name for new electorate", "");
        public static readonly AddressElement StateElectoralNewEffectiveStart = new AddressElement("stateElectoralNewEffectiveStart", "This is the start date that the new electorate will become effective", "");
        public static readonly AddressElement StateElectoralNewEffectiveEnd = new AddressElement("stateElectoralNewEffectiveEnd", "This is the end date when the new electorate will no longer be in effect", "");
        public static readonly AddressElement MosaicGroup = new AddressElement("mosaicGroup", "Mosaic Group", "K");
        public static readonly AddressElement MosaicType = new AddressElement("mosaicType", "Mosaic Group and Type", "K39");
        public static readonly AddressElement MosaicSegmentCode = new AddressElement("mosaicSegmentCode", "Mosaic Segment", "A01_3");
        public static readonly AddressElement Factor1Score = new AddressElement("factor1Score", "Factors score", "-24255");
        public static readonly AddressElement Factor1Percentile = new AddressElement("factor1Percentile", "Factors percentile", "13");
        public static readonly AddressElement Factor2Score = new AddressElement("factor2Score", "Factors score", "-024255");
        public static readonly AddressElement Factor2Percentile = new AddressElement("factor2Percentile", "Factors percentile", "13");
        public static readonly AddressElement Factor3Score = new AddressElement("factor3Score", "Factors score", "-24255");
        public static readonly AddressElement Factor3Percentile = new AddressElement("factor3Percentile", "Factors percentile", "13");
        public static readonly AddressElement Factor4Score = new AddressElement("factor4Score", "Factors score", "-24255");
        public static readonly AddressElement Factor4Percentile = new AddressElement("factor4Percentile", "Factors percentile", "13");
        public static readonly AddressElement Factor5Score = new AddressElement("factor5Score", "Factors score", "-24255");
        public static readonly AddressElement Factor5Percentile = new AddressElement("factor5Percentile", "Factors percentile", "13");
        public static readonly AddressElement LengthOfResidence = new AddressElement("lengthOfResidence", "The code representing the Length of Residence band", "2");
        public static readonly AddressElement HeadOfHouseholdAge = new AddressElement("headOfHouseholdAge", "The code representing the Age band", "11");
        public static readonly AddressElement PropensityForChildren0To10Years = new AddressElement("propensityForChildren0To10Years", "Double digit code representing the band", "02");
        public static readonly AddressElement PropensityForChildren11To18Years = new AddressElement("propensityForChildren11To18Years", "Double digit code representing the band", "02");
        public static readonly AddressElement AdultsAtAddress = new AddressElement("adultsAtAddress", "An estimate of the number of adults at the address", "3");
        public static readonly AddressElement HouseholdComposition = new AddressElement("householdComposition", "Single digit code representing the Household Composition band", "2");
        public static readonly AddressElement Lifestage = new AddressElement("lifestage", "2-digit code representing the Lifestage band", "09");
        public static readonly AddressElement HouseholdIncome = new AddressElement("householdIncome", "Single digit code representing the Household Income band", "5");
        public static readonly AddressElement Affluence = new AddressElement("affluence", "Single digit code representing the Affluence band", "3");
        public static readonly AddressElement RiskInsight = new AddressElement("riskInsight", "Code representing the Risk Insight band", "7");
        public static readonly AddressElement CreditDemand = new AddressElement("creditDemand", "Code representing the Credit Demand band", "7");

        private string elementName { get; set; }
        private string description { get; set; }
        private string example { get; set; }

        public Aug(string elementName, string description, string example)
        {
            this.elementName = elementName;
            this.description = description;
            this.example = example;
        }

        public static IAddressElement? GetElement(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Type addressElementType = typeof(Aug);
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