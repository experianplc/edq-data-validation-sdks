using System.Reflection;

namespace DVSClient.Address.Layout.Elements
{
    public class Aug : IAddressElement
    {
        public static readonly Aug BuildingName = new Aug("buildingName", "Building name", "Treasury Building");
        public static readonly Aug FlatUnitName = new Aug("flatUnitName", "Flat/Unit name", "Flat 2");
        public static readonly Aug FlatUnitType = new Aug("flatUnitType", "Flat/Unit type", "Flat");
        public static readonly Aug FlatUnitNumber = new Aug("flatUnitNumber", "Flat/unit number", "2");
        public static readonly Aug SubBuildingNumber = new Aug("subBuildingNumber", "Sub-building number", "5a");
        public static readonly Aug SubBuildingNumberNumber = new Aug("subBuildingNumberNumber", "Sub-building number (number)", "5");
        public static readonly Aug SubBuildingNumberAlpha = new Aug("subBuildingNumberAlpha", "Sub-building number (alpha)", "a");
        public static readonly Aug BuildingLevel = new Aug("buildingLevel", "Building level", "Level 7");
        public static readonly Aug BuildingLevelType = new Aug("buildingLevelType", "Building level type", "Level");
        public static readonly Aug BuildingLevelNumber = new Aug("buildingLevelNumber", "Building level number", "7");
        public static readonly Aug BuildingNumber = new Aug("buildingNumber", "Building number", "1-131");
        public static readonly Aug BuildingNumberFirst = new Aug("buildingNumberFirst", "Building number (first)", "1");
        public static readonly Aug BuildingNumberLast = new Aug("buildingNumberLast", "Building number (last)", "131");
        public static readonly Aug AllotmentNumber1 = new Aug("allotmentNumber1", "Allotment number", "Lot 16");
        public static readonly Aug AllotmentLot = new Aug("allotmentLot", "Allotment lot", "Lot");
        public static readonly Aug AllotmentNumber2 = new Aug("allotmentNumber2", "Allotment number", "16");
        public static readonly Aug Street = new Aug("street", "Street", "Tudor Court East");
        public static readonly Aug StreetName = new Aug("streetName", "Street name", "Tudor");
        public static readonly Aug StreetType = new Aug("streetType", "Street type", "Court");
        public static readonly Aug StreetTypeSuffix = new Aug("streetTypeSuffix", "Street type suffix", "East");
        public static readonly Aug PrivateStreet = new Aug("privateStreet", "Private Street", "Private Street");
        public static readonly Aug Locality = new Aug("locality", "Locality", "Ayr");
        public static readonly Aug BorderingLocality = new Aug("borderingLocality", "Bordering Locality", "Mt Kelly");
        public static readonly Aug StateCode = new Aug("stateCode", "State code", "QLD");
        public static readonly Aug StateName = new Aug("stateName", "State Name", "Queensland");
        public static readonly Aug Postcode = new Aug("postcode", "Postcode", "4807");
        public static readonly Aug CountryName = new Aug("countryName", "Country Name", "Australia");
        public static readonly Aug TwoCharacterIsoCountryCode = new Aug("twoCharacterIsoCountryCode", "Two character country code", "AU");
        public static readonly Aug ThreeCharacterIsoCountryCode = new Aug("threeCharacterIsoCountryCode", "Three character country code", "AUS");
        public static readonly Aug GeocodeLevelCode = new Aug("geocodeLevelCode", "This is the geocode level code", "2");
        public static readonly Aug GeocodeLevelDescription = new Aug("geocodeLevelDescription", "This is the geocode level description", "Street level geocode only");
        public static readonly Aug GeocodeTypeCode = new Aug("geocodeTypeCode", "This is the geocode type code", "LB");
        public static readonly Aug GeocodeTypeDescription = new Aug("geocodeTypeDescription", "This is the geocode type description", "Letterbox");
        public static readonly Aug AddressLevelLongitude = new Aug("addressLevelLongitude", "The address-level longitude in degrees", "");
        public static readonly Aug AddressLevelLatitude = new Aug("addressLevelLatitude", "The address-level latitude in degrees", "");
        public static readonly Aug AddressLevelElevation = new Aug("addressLevelElevation", "The address-level elevation", "");
        public static readonly Aug AddressLevelPlanimetricAccuracy = new Aug("addressLevelPlanimetricAccuracy", "The address-level planimetric accuracy", "");
        public static readonly Aug AddressLevelBoundaryExtent = new Aug("addressLevelBoundaryExtent", "The address-level boundary extent", "");
        public static readonly Aug AddressLevelGeocodeReliabilityCode = new Aug("addressLevelGeocodeReliabilityCode", "The address-level geocode reliability code", "2");
        public static readonly Aug AddressLevelGeocodeReliabilityDescription = new Aug("addressLevelGeocodeReliabilityDescription", "The address-level geocode reliability description", "Geocode accuracy sufficient to place centroid within address site boundary");
        public static readonly Aug StreetLevelLongitude = new Aug("streetLevelLongitude", "The street-level longitude in degrees", "");
        public static readonly Aug StreetLevelLatitude = new Aug("streetLevelLatitude", "The street-level latitude in degrees", "");
        public static readonly Aug StreetLevelPlanimetricAccuracy = new Aug("streetLevelPlanimetricAccuracy", "The street-level planimetric accuracy", "");
        public static readonly Aug StreetLevelBoundaryExtent = new Aug("streetLevelBoundaryExtent", "The street-level boundary extent", "");
        public static readonly Aug StreetLevelGeocodeReliabilityCode = new Aug("streetLevelGeocodeReliabilityCode", "The street-level geocode reliability code", "4");
        public static readonly Aug StreetLevelGeocodeReliabilityDescription = new Aug("streetLevelGeocodeReliabilityDescription", "The street-level geocode reliability description", "Geocode accuracy sufficient to associate address site with a unique road feature");
        public static readonly Aug LocalityLevelLongitude = new Aug("localityLevelLongitude", "The locality-level longitude in degrees", "");
        public static readonly Aug LocalityLevelLatitude = new Aug("localityLevelLatitude", "The locality-level latitude in degrees", "");
        public static readonly Aug LocalityLevelPlanimetricAccuracy = new Aug("localityLevelPlanimetricAccuracy", "The locality-level planimetric accuracy", "");
        public static readonly Aug LocalityLevelGeocodeReliabilityCode = new Aug("localityLevelGeocodeReliabilityCode", "The locality-level geocode reliability code", "5");
        public static readonly Aug LocalityLevelGeocodeReliabilityDescription = new Aug("localityLevelGeocodeReliabilityDescription", "The locality-level geocode reliability description", "Geocode accuracy sufficient to associate address site with a unique locality or neighbourhood");
        public static readonly Aug Longitude = new Aug("longitude", "The highest-level longitude in degrees", "");
        public static readonly Aug Latitude = new Aug("latitude", "The highest-level latitude in degrees", "");
        public static readonly Aug Elevation = new Aug("elevation", "The highest-level elevation", "");
        public static readonly Aug PlanimetricAccuracy = new Aug("planimetricAccuracy", "The highest-level planimetric accuracy", "");
        public static readonly Aug BoundaryExtent = new Aug("boundaryExtent", "The highest-level boundary extent", "");
        public static readonly Aug GeocodeReliabilityCode = new Aug("geocodeReliabilityCode", "The highest-level geocode reliability code", "");
        public static readonly Aug GeocodeReliabilityDescription = new Aug("geocodeReliabilityDescription", "The highest-level geocode reliability description", "");
        public static readonly Aug GnafPid = new Aug("gnafPid", "Persistent identifier of an address", "GANSW716798454");
        public static readonly Aug GnafAddressTypeCode = new Aug("gnafAddressTypeCode", "This is the address type code", "R/RMB");
        public static readonly Aug GnafAddressTypeDescription = new Aug("gnafAddressTypeDescription", "This is the address type description", "Rural Roadside Mail Box");
        public static readonly Aug StreetPid = new Aug("streetPid", "This is a unique street persistent identifier", "");
        public static readonly Aug LocalityPid = new Aug("localityPid", "This is a unique locality persistent identifier", "");
        public static readonly Aug ConfidenceLevelCode = new Aug("confidenceLevelCode", "This is the confidence level code", "2");
        public static readonly Aug ConfidenceLevelDescription = new Aug("confidenceLevelDescription", "This is the confidence level descriptor", "All three contributors have supplied an identical address");
        public static readonly Aug MeshBlockId2021 = new Aug("2021MeshBlockId", "The 2021 version of the Mesh Block ID", "");
        public static readonly Aug MeshBlockCode2021 = new Aug("2021MeshBlockCode", "The 11-digit 2021 version of the Mesh Block Code", "");
        public static readonly Aug MeshBlockMatchCode2021 = new Aug("2021MeshBlockMatchCode", "The code for the level of matching to 2021 Mesh Blocks", "");
        public static readonly Aug MeshBlockMatchDescription2021 = new Aug("2021MeshBlockMatchDescription", "The description of the 2021 Mesh Block match level", "");
        public static readonly Aug MeshBlockId2016 = new Aug("2016MeshBlockId", "The 2016 version of the MeshBlock ID", "");
        public static readonly Aug MeshBlockCode2016 = new Aug("2016MeshBlockCode", "The 11-digit 2016 version of the MeshBlock Code", "");
        public static readonly Aug MeshBlockMatchCode2016 = new Aug("2016MeshBlockMatchCode", "The code for the level of matching to 2016 Mesh Blocks", "");
        public static readonly Aug MeshBlockMatchDescription2016 = new Aug("2016MeshBlockMatchDescription", "The description of the 2016 Mesh Block match level", "");
        public static readonly Aug ComplexAddressTypeCode = new Aug("complexAddressTypeCode", "Returns the Address Type", "P");
        public static readonly Aug PrimaryAddressPid = new Aug("primaryAddressPid", "This element will only be populated if the input address is a secondary address", "");
        public static readonly Aug AddressJoinTypeCode = new Aug("addressJoinTypeCode", "Returns the Join Type Code", "");
        public static readonly Aug GnafLegalParcelIdentifier = new Aug("gnafLegalParcelIdentifier", "The Legal Parcel Id field", "");
        public static readonly Aug CollectorDistrictId = new Aug("collectorDistrictId", "This is a unique Collector District persistent identifier", "");
        public static readonly Aug CollectorDistrictCode = new Aug("collectorDistrictCode", "This is the Collector District Code", "");
        public static readonly Aug CommonwealthElectoralBoundaryId = new Aug("commonwealthElectoralBoundaryId", "This is a unique Commonwealth Electoral Boundary persistent identifier", "");
        public static readonly Aug CommonwealthElectoralBoundaryName = new Aug("commonwealthElectoralBoundaryName", "This is the Commonwealth Electoral Boundary name", "");
        public static readonly Aug LocalGovernmentAreaId = new Aug("localGovernmentAreaId", "This is a Local Government Area persistent identifier", "");
        public static readonly Aug LocalGovernmentAreaName = new Aug("localGovernmentAreaName", "This is the Local Government Area name", "");
        public static readonly Aug StatisticalLocalAreaId = new Aug("statisticalLocalAreaId", "This is a Statistical Local Area persistent identifier", "");
        public static readonly Aug StatisticalLocalAreaCode = new Aug("statisticalLocalAreaCode", "This is a Statistical Local Area code", "");
        public static readonly Aug StatisticalLocalAreaName = new Aug("statisticalLocalAreaName", "This is a Statistical Local Area name", "");
        public static readonly Aug StateElectoralBoundaryId = new Aug("stateElectoralBoundaryId", "This is a State Electoral Boundary persistent identifier", "");
        public static readonly Aug StateElectoralBoundaryName = new Aug("stateElectoralBoundaryName", "This is a State Electoral Boundary name", "");
        public static readonly Aug StateElectoralEffectiveStart = new Aug("stateElectoralEffectiveStart", "This is the date that the electorate becomes effective", "");
        public static readonly Aug StateElectoralEffectiveEnd = new Aug("stateElectoralEffectiveEnd", "This is the end date when electorate is no longer in effect", "");
        public static readonly Aug StateElectoralNewBoundaryId = new Aug("stateElectoralNewBoundaryId", "This is the State Electoral Boundary identifier for new electorate", "");
        public static readonly Aug StateElectoralNewBoundaryName = new Aug("stateElectoralNewBoundaryName", "This is the State Electoral Boundary name for new electorate", "");
        public static readonly Aug StateElectoralNewEffectiveStart = new Aug("stateElectoralNewEffectiveStart", "This is the start date that the new electorate will become effective", "");
        public static readonly Aug StateElectoralNewEffectiveEnd = new Aug("stateElectoralNewEffectiveEnd", "This is the end date when the new electorate will no longer be in effect", "");
        public static readonly Aug MosaicGroup = new Aug("mosaicGroup", "Mosaic Group", "K");
        public static readonly Aug MosaicType = new Aug("mosaicType", "Mosaic Group and Type", "K39");
        public static readonly Aug MosaicSegmentCode = new Aug("mosaicSegmentCode", "Mosaic Segment", "A01_3");
        public static readonly Aug Factor1Score = new Aug("factor1Score", "Factors score", "-24255");
        public static readonly Aug Factor1Percentile = new Aug("factor1Percentile", "Factors percentile", "13");
        public static readonly Aug Factor2Score = new Aug("factor2Score", "Factors score", "-024255");
        public static readonly Aug Factor2Percentile = new Aug("factor2Percentile", "Factors percentile", "13");
        public static readonly Aug Factor3Score = new Aug("factor3Score", "Factors score", "-24255");
        public static readonly Aug Factor3Percentile = new Aug("factor3Percentile", "Factors percentile", "13");
        public static readonly Aug Factor4Score = new Aug("factor4Score", "Factors score", "-24255");
        public static readonly Aug Factor4Percentile = new Aug("factor4Percentile", "Factors percentile", "13");
        public static readonly Aug Factor5Score = new Aug("factor5Score", "Factors score", "-24255");
        public static readonly Aug Factor5Percentile = new Aug("factor5Percentile", "Factors percentile", "13");
        public static readonly Aug LengthOfResidence = new Aug("lengthOfResidence", "The code representing the Length of Residence band", "2");
        public static readonly Aug HeadOfHouseholdAge = new Aug("headOfHouseholdAge", "The code representing the Age band", "11");
        public static readonly Aug PropensityForChildren0To10Years = new Aug("propensityForChildren0To10Years", "Double digit code representing the band", "02");
        public static readonly Aug PropensityForChildren11To18Years = new Aug("propensityForChildren11To18Years", "Double digit code representing the band", "02");
        public static readonly Aug AdultsAtAddress = new Aug("adultsAtAddress", "An estimate of the number of adults at the address", "3");
        public static readonly Aug HouseholdComposition = new Aug("householdComposition", "Single digit code representing the Household Composition band", "2");
        public static readonly Aug Lifestage = new Aug("lifestage", "2-digit code representing the Lifestage band", "09");
        public static readonly Aug HouseholdIncome = new Aug("householdIncome", "Single digit code representing the Household Income band", "5");
        public static readonly Aug Affluence = new Aug("affluence", "Single digit code representing the Affluence band", "3");
        public static readonly Aug RiskInsight = new Aug("riskInsight", "Code representing the Risk Insight band", "7");
        public static readonly Aug CreditDemand = new Aug("creditDemand", "Code representing the Credit Demand band", "7");

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