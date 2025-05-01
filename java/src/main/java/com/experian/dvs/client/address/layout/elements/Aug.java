package com.experian.dvs.client.address.layout.elements;

public enum Aug implements AddressElement {

    BUILDING_NAME("buildingName", "Building name", "Treasury Building"),
    FLAT_UNIT_NAME("flatUnitName", "Flat/Unit name", "Flat 2"),
    FLAT_UNIT_TYPE("flatUnitType", "Flat/Unit type", "Flat"),
    FLAT_UNIT_NUMBER("flatUnitNumber", "Flat/unit number", "2"),
    SUB_BUILDING_NUMBER("subBuildingNumber", "Sub-building number", "5a"),
    SUB_BUILDING_NUMBER_NUMBER("subBuildingNumberNumber", "Sub-building number (number)", "5"),
    SUB_BUILDING_NUMBER_ALPHA("subBuildingNumberAlpha", "Sub-building number (alpha)", "a"),
    BUILDING_LEVEL("buildingLevel", "Building level", "Level 7"),
    BUILDING_LEVEL_TYPE("buildingLevelType", "Building level type", "Level"),
    BUILDING_LEVEL_NUMBER("buildingLevelNumber", "Building level number", "7"),
    BUILDING_NUMBER("buildingNumber", "Building number", "1-131"),
    BUILDING_NUMBER_FIRST("buildingNumberFirst", "Building number (first)", "1"),
    BUILDING_NUMBER_LAST("buildingNumberLast", "Building number (last)", "131"),
    ALLOTMENT_NUMBER_1("allotmentNumber1", "Allotment number", "Lot 16"),
    ALLOTMENT_LOT("allotmentLot", "Allotment lot", "Lot"),
    ALLOTMENT_NUMBER_2("allotmentNumber2", "Allotment number", "16"),
    STREET("street", "Street", "Tudor Court East"),
    STREET_NAME("streetName", "Street name", "Tudor"),
    STREET_TYPE("streetType", "Street type", "Court"),
    STREET_TYPE_SUFFIX("streetTypeSuffix", "Street type suffix", "East"),
    PRIVATE_STREET("privateStreet", "Private Street", "Private Street"),
    LOCALITY("locality", "Locality", "Ayr"),
    BORDERING_LOCALITY("borderingLocality", "Bordering Locality", "Mt Kelly"),
    STATE_CODE("stateCode", "State code", "QLD"),
    STATE_NAME("stateName", "State Name", "Queensland"),
    POSTCODE("postcode", "Postcode", "4807"),
    COUNTRY_NAME("countryName", "Country Name", "Australia"),
    TWO_CHARACTER_ISO_COUNTRY_CODE("twoCharacterIsoCountryCode", "Two character country code", "AU"),
    THREE_CHARACTER_ISO_COUNTRY_CODE("threeCharacterIsoCountryCode", "Three character country code", "AUS"),
    GEOCODE_LEVEL_CODE("geocodeLevelCode", "This is the geocode level code", "2"),
    GEOCODE_LEVEL_DESCRIPTION("geocodeLevelDescription", "This is the geocode level description", "Street level geocode only"),
    GEOCODE_TYPE_CODE("geocodeTypeCode", "This is the geocode type code", "LB"),
    GEOCODE_TYPE_DESCRIPTION("geocodeTypeDescription", "This is the geocode type description", "Letterbox"),
    ADDRESS_LEVEL_LONGITUDE("addressLevelLongitude", "The address-level longitude in degrees", ""),
    ADDRESS_LEVEL_LATITUDE("addressLevelLatitude", "The address-level latitude in degrees", ""),
    ADDRESS_LEVEL_ELEVATION("addressLevelElevation", "The address-level elevation", ""),
    ADDRESS_LEVEL_PLANIMETRIC_ACCURACY("addressLevelPlanimetricAccuracy", "The address-level planimetric accuracy", ""),
    ADDRESS_LEVEL_BOUNDARY_EXTENT("addressLevelBoundaryExtent", "The address-level boundary extent", ""),
    ADDRESS_LEVEL_GEOCODE_RELIABILITY_CODE("addressLevelGeocodeReliabilityCode", "The address-level geocode reliability code", "2"),
    ADDRESS_LEVEL_GEOCODE_RELIABILITY_DESCRIPTION("addressLevelGeocodeReliabilityDescription", "The address-level geocode reliability description", "GlobalGeocodeAttribute accuracy sufficient to place centroid within address site boundary"),
    STREET_LEVEL_LONGITUDE("streetLevelLongitude", "The street-level longitude in degrees", ""),
    STREET_LEVEL_LATITUDE("streetLevelLatitude", "The street-level latitude in degrees", ""),
    STREET_LEVEL_PLANIMETRIC_ACCURACY("streetLevelPlanimetricAccuracy", "The street-level planimetric accuracy", ""),
    STREET_LEVEL_BOUNDARY_EXTENT("streetLevelBoundaryExtent", "The street-level boundary extent", ""),
    STREET_LEVEL_GEOCODE_RELIABILITY_CODE("streetLevelGeocodeReliabilityCode", "The street-level geocode reliability code", "4"),
    STREET_LEVEL_GEOCODE_RELIABILITY_DESCRIPTION("streetLevelGeocodeReliabilityDescription", "The street-level geocode reliability description", "GlobalGeocodeAttribute accuracy sufficient to associate address site with a unique road feature"),
    LOCALITY_LEVEL_LONGITUDE("localityLevelLongitude", "The locality-level longitude in degrees", ""),
    LOCALITY_LEVEL_LATITUDE("localityLevelLatitude", "The locality-level latitude in degrees", ""),
    LOCALITY_LEVEL_PLANIMETRIC_ACCURACY("localityLevelPlanimetricAccuracy", "The locality-level planimetric accuracy", ""),
    LOCALITY_LEVEL_GEOCODE_RELIABILITY_CODE("localityLevelGeocodeReliabilityCode", "The locality-level geocode reliability code", "5"),
    LOCALITY_LEVEL_GEOCODE_RELIABILITY_DESCRIPTION("localityLevelGeocodeReliabilityDescription", "The locality-level geocode reliability description", "GlobalGeocodeAttribute accuracy sufficient to associate address site with a unique locality or neighbourhood"),
    LONGITUDE("longitude", "The highest-level longitude in degrees", ""),
    LATITUDE("latitude", "The highest-level latitude in degrees", ""),
    ELEVATION("elevation", "The highest-level elevation", ""),
    PLANIMETRIC_ACCURACY("planimetricAccuracy", "The highest-level planimetric accuracy", ""),
    BOUNDARY_EXTENT("boundaryExtent", "The highest-level boundary extent", ""),
    GEOCODE_RELIABILITY_CODE("geocodeReliabilityCode", "The highest-level geocode reliability code", ""),
    GEOCODE_RELIABILITY_DESCRIPTION("geocodeReliabilityDescription", "The highest-level geocode reliability description", ""),
    GNAF_PID("gnafPid", "Persistent identifier of an address", "GANSW716798454"),
    GNAF_ADDRESS_TYPE_CODE("gnafAddressTypeCode", "This is the address type code", "R/RMB"),
    GNAF_ADDRESS_TYPE_DESCRIPTION("gnafAddressTypeDescription", "This is the address type description", "Rural Roadside Mail Box"),
    STREET_PID("streetPid", "This is a unique street persistent identifier", ""),
    LOCALITY_PID("localityPid", "This is a unique locality persistent identifier", ""),
    CONFIDENCE_LEVEL_CODE("confidenceLevelCode", "This is the confidence level code", "2"),
    CONFIDENCE_LEVEL_DESCRIPTION("confidenceLevelDescription", "This is the confidence level descriptor", "All three contributors have supplied an identical address"),
    MESH_BLOCK_ID_2021("2021MeshBlockId", "The 2021 version of the Mesh Block ID", ""),
    MESH_BLOCK_CODE_2021("2021MeshBlockCode", "The 11-digit 2021 version of the Mesh Block Code", ""),
    MESH_BLOCK_MATCH_CODE_2021("2021MeshBlockMatchCode", "The code for the level of matching to 2021 Mesh Blocks", ""),
    MESH_BLOCK_MATCH_DESCRIPTION_2021("2021MeshBlockMatchDescription", "The description of the 2021 Mesh Block match level", ""),
    MESH_BLOCK_ID_2016("2016MeshBlockId", "The 2016 version of the MeshBlock ID", ""),
    MESH_BLOCK_CODE_2016("2016MeshBlockCode", "The 11-digit 2016 version of the MeshBlock Code", ""),
    MESH_BLOCK_MATCH_CODE_2016("2016MeshBlockMatchCode", "The code for the level of matching to 2016 Mesh Blocks", ""),
    MESH_BLOCK_MATCH_DESCRIPTION_2016("2016MeshBlockMatchDescription", "The description of the 2016 Mesh Block match level", ""),
    COMPLEX_ADDRESS_TYPE_CODE("complexAddressTypeCode", "Returns the FormatAddress Type", "P"),
    PRIMARY_ADDRESS_PID("primaryAddressPid", "This element will only be populated if the input address is a secondary address", ""),
    ADDRESS_JOIN_TYPE_CODE("addressJoinTypeCode", "Returns the Join Type Code", ""),
    GNAF_LEGAL_PARCEL_IDENTIFIER("gnafLegalParcelIdentifier", "The Legal Parcel Id field", ""),
    COLLECTOR_DISTRICT_ID("collectorDistrictId", "This is a unique Collector District persistent identifier", ""),
    COLLECTOR_DISTRICT_CODE("collectorDistrictCode", "This is the Collector District Code", ""),
    COMMONWEALTH_ELECTORAL_BOUNDARY_ID("commonwealthElectoralBoundaryId", "This is a unique Commonwealth Electoral Boundary persistent identifier", ""),
    COMMONWEALTH_ELECTORAL_BOUNDARY_NAME("commonwealthElectoralBoundaryName", "This is the Commonwealth Electoral Boundary name", ""),
    LOCAL_GOVERNMENT_AREA_ID("localGovernmentAreaId", "This is a Local Government Area persistent identifier", ""),
    LOCAL_GOVERNMENT_AREA_NAME("localGovernmentAreaName", "This is the Local Government Area name", ""),
    STATISTICAL_LOCAL_AREA_ID("statisticalLocalAreaId", "This is a Statistical Local Area persistent identifier", ""),
    STATISTICAL_LOCAL_AREA_CODE("statisticalLocalAreaCode", "This is a Statistical Local Area code", ""),
    STATISTICAL_LOCAL_AREA_NAME("statisticalLocalAreaName", "This is a Statistical Local Area name", ""),
    STATE_ELECTORAL_BOUNDARY_ID("stateElectoralBoundaryId", "This is a State Electoral Boundary persistent identifier", ""),
    STATE_ELECTORAL_BOUNDARY_NAME("stateElectoralBoundaryName", "This is a State Electoral Boundary name", ""),
    STATE_ELECTORAL_EFFECTIVE_START("stateElectoralEffectiveStart", "This is the date that the electorate becomes effective", ""),
    STATE_ELECTORAL_EFFECTIVE_END("stateElectoralEffectiveEnd", "This is the end date when electorate is no longer in effect", ""),
    STATE_ELECTORAL_NEW_BOUNDARY_ID("stateElectoralNewBoundaryId", "This is the State Electoral Boundary identifier for new electorate", ""),
    STATE_ELECTORAL_NEW_BOUNDARY_NAME("stateElectoralNewBoundaryName", "This is the State Electoral Boundary name for new electorate", ""),
    STATE_ELECTORAL_NEW_EFFECTIVE_START("stateElectoralNewEffectiveStart", "This is the start date that the new electorate will become effective", ""),
    STATE_ELECTORAL_NEW_EFFECTIVE_END("stateElectoralNewEffectiveEnd", "This is the end date when the new electorate will no longer be in effect", ""),
    MOSAIC_GROUP("mosaicGroup", "Mosaic Group", "K"),
    MOSAIC_TYPE("mosaicType", "Mosaic Group and Type", "K39"),
    MOSAIC_SEGMENT_CODE("mosaicSegmentCode", "Mosaic Segment", "A01_3"),
    FACTOR_1_SCORE("factor1Score", "Factors score", "-24255"),
    FACTOR_1_PERCENTILE("factor1Percentile", "Factors percentile", "13"),
    FACTOR_2_SCORE("factor2Score", "Factors score", "-024255"),
    FACTOR_2_PERCENTILE("factor2Percentile", "Factors percentile", "13"),
    FACTOR_3_SCORE("factor3Score", "Factors score", "-24255"),
    FACTOR_3_PERCENTILE("factor3Percentile", "Factors percentile", "13"),
    FACTOR_4_SCORE("factor4Score", "Factors score", "-24255"),
    FACTOR_4_PERCENTILE("factor4Percentile", "Factors percentile", "13"),
    FACTOR_5_SCORE("factor5Score", "Factors score", "-24255"),
    FACTOR_5_PERCENTILE("factor5Percentile", "Factors percentile", "13"),
    LENGTH_OF_RESIDENCE("lengthOfResidence", "The code representing the Length of Residence band", "2"),
    HEAD_OF_HOUSEHOLD_AGE("headOfHouseholdAge", "The code representing the Age band", "11"),
    PROPENSITY_FOR_CHILDREN_0_TO_10_YEARS("propensityForChildren0To10Years", "Double digit code representing the band", "02"),
    PROPENSITY_FOR_CHILDREN_11_TO_18_YEARS("propensityForChildren11To18Years", "Double digit code representing the band", "02"),
    ADULTS_AT_ADDRESS("adultsAtAddress", "An estimate of the number of adults at the address", "3"),
    HOUSEHOLD_COMPOSITION("householdComposition", "Single digit code representing the Household Composition band", "2"),
    LIFESTAGE("lifestage", "2-digit code representing the Lifestage band", "09"),
    HOUSEHOLD_INCOME("householdIncome", "Single digit code representing the Household Income band", "5"),
    AFFLUENCE("affluence", "Single digit code representing the Affluence band", "3"),
    RISK_INSIGHT("riskInsight", "Code representing the Risk Insight band", "7"),
    CREDIT_DEMAND("creditDemand", "Code representing the Credit Demand band", "7");

    private final String elementName;
    private final String description;
    private final String example;

    Aug(String elementName, String description, String example) {
        this.elementName = elementName;
        this.description = description;
        this.example = example;
    }

    public String getElementName() {
        return elementName;
    }

    public String getDescription() {
        return description;
    }

    public String getExample() {
        return example;
    }

}