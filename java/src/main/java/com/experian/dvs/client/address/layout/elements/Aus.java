package com.experian.dvs.client.address.layout.elements;

public enum Aus implements AddressElement {

    BUILDING_NAME_2("buildingName2", "Building Name 2", "North Wing"),
    BUILDING_NAME("buildingName", "Building Name", "Treasury Building"),
    FLAT_UNIT_NAME("flatUnitName", "Flat/unit name", "Flat 2"),
    FLAT_UNIT_TYPE("flatUnitType", "Flat/unit type", "Flat"),
    FLAT_UNIT_NUMBER("flatUnitNumber", "Flat/unit number", "2"),
    BUILDING_LEVEL("buildingLevel", "Building level", "Level 7"),
    BUILDING_LEVEL_TYPE("buildingLevelType", "Building level type", "Level"),
    BUILDING_LEVEL_NUMBER("buildingLevelNumber", "Building level number", "7"),
    ALLOTMENT_NUMBER_1("allotmentNumber1", "Allotment number", "Lot 16"),
    ALLOTMENT_LOT("allotmentLot", "Allotment lot", "Lot"),
    ALLOTMENT_NUMBER_2("allotmentNumber2", "Allotment number", "16"),
    SUBBUILDING_NUMBER("subbuildingNumber", "Sub-building number", "2a"),
    SUBBUILDING_NUMBER_NUMBER("subbuildingNumberNumber", "Sub-building number (number)", "2"),
    SUBBUILDING_NUMBER_ALPHA("subbuildingNumberAlpha", "Sub-building number (alpha)", "a"),
    BUILDING_NUMBER("buildingNumber", "Building number", "1-26"),
    BUILDING_NUMBER_FIRST("buildingNumberFirst", "Building number (first)", "1"),
    BUILDING_NUMBER_LAST("buildingNumberLast", "Building number (last)", "26"),
    ALL_POSTAL_DELIVERY_TYPES("allPostalDeliveryTypes", "All postal delivery types", ""),
    TYPE("type", "Type", "PO Box"),
    NUMBER("number", "Number", "87"),
    PO_BOX("poBox", "PO Box", "PO Box 65"),
    GPO_BOX("gpoBox", "GPO Box", "GPO Box M929"),
    CARE_PO("carePo", "Care PO", "Care PO"),
    ROADSIDE_MAIL_BOX("roadsideMailBox", "Roadside Mail Box", "RMB 65"),
    ROADSIDE_DELIVERY("roadsideDelivery", "Roadside Delivery", "RSD 21"),
    COMMUNITY_MAIL_AGENT("communityMailAgent", "Community Mail Agent", "CMA"),
    COMMUNITY_POSTAL_AGENT("communityPostalAgent", "Community Postal Agent", "CPA"),
    PRIVATE_BAG("privateBag", "Private Bag", "Private Bag 6060"),
    LOCKED_BAG("lockedBag", "Locked Bag", "Locked Bag 3"),
    MAIL_SERVICE("mailService", "Mail Service", "MS 494"),
    COMMUNITY_MAIL_BAG("communityMailBag", "Community Mail Bag", "CMB 111"),
    ROADSIDE_MAIL_SERVICE("roadsideMailService", "Roadside Mail Service", "RMS 1600"),
    STREET("street", "Street", "Tudor Court East"),
    STREET_NAME("streetName", "Street name", "Tudor"),
    STREET_TYPE("streetType", "Street type", "Court"),
    STREET_TYPE_SUFFIX("streetTypeSuffix", "Street type suffix", "East"),
    LOCALITY("locality", "Locality", "Ayr"),
    INVALID_LOCALITY_ALIAS("invalidLocalityAlias", "Invalid Locality Alias", "Mt Kelly"),
    BORDERING_LOCALITY("borderingLocality", "Bordering Locality", "Alderley"),
    STATE_CODE("stateCode", "State code", "QLD"),
    POSTAL_CODE("postalCode", "Postal code", "4807"),
    BORDERING_LOCALITY_POSTCODE("borderingLocalityPostcode", "Bordering Locality Postcode", "4051"),
    DELIVERY_POINT_IDENTIFIER_DPID_DID("deliveryPointIdentifierDpidDid", "Delivery Point Identifier (DPID/DID)", "56729927"),
    PRIMARY_POINT("primaryPoint", "Primary Point", "R"),
    STATE_NAME("stateName", "State name", "Queensland"),
    COUNTRY_NAME("countryName", "Country name", "Australia"),
    TWO_CHARACTER_ISO_COUNTRY_CODE("twoCharacterIsoCountryCode", "Two character ISO country code", "AU"),
    THREE_CHARACTER_ISO_COUNTRY_CODE("threeCharacterIsoCountryCode", "Three character ISO country code", "AUS"),
    BARCODE_SORT_PLAN_NUMBER("barcodeSortPlanNumber", "3 digit Barcode Sort Plan (BSP) number for an address", ""),
    CHANGE_OF_ADDRESS_DATE("changeOfAddressDate", "Change of FormatAddress date", ""),
    CHANGE_OF_ADDRESS_FLAG("changeOfAddressFlag", "Change of FormatAddress flag", "3"),
    HIN("hin", "10 digit Household Identification Number", ""),
    MOSAIC_GROUP("mosaicGroup", "Mosaic group", "K"),
    MOSAIC_TYPE("mosaicType", "Mosaic group and type", "K39"),
    MOSAIC_ELEMENT("mosaicElement", "Mosaic Element", "K39_1"),
    HOUSEHOLD_MOSAIC_ELEMENT("householdMosaicElement", "Household Mosaic Element", "K39_1"),
    AFFLUENCE("affluence", "Affluence band", "3"),
    HOUSEHOLD_INCOME("householdIncome", "Household Income band", "5"),
    MAXIMUM_LENGTH_OF_RESIDENCE("maximumLengthOfResidence", "Length of Residence band", "2"),
    RELATIONS("relations", "Household Composition category", "2"),
    HEAD_OF_HOUSEHOLD_AGE("headOfHouseholdAge", "Head of Household Age band", "11"),
    LIFESTAGE("lifestage", "Lifestage band", "09"),
    ADULTS_AT_ADDRESS("adultsAtAddress", "Number of adults at the address", "3"),
    PROPENSITY_FOR_CHILDREN_0_TO_10_YEARS("propensityForChildren0To10Years", "Propensity for Children 0-10 years", "02"),
    PROPENSITY_FOR_CHILDREN_11_TO_18_YEARS("propensityForChildren11To18Years", "Propensity for Children 11-18 years", "05"),
    F1_SCORE_FAMILY_COMPOSITION("f1ScoreFamilyComposition", "Factors score for Family Composition", "-24255"),
    F1_PERCENTILE_FAMILY_COMPOSITION("f1PercentileFamilyComposition", "Factors percentile for Family Composition", "13"),
    F2_SCORE_PROSPERITY("f2ScoreProsperity", "Factors score for Prosperity", "-024255"),
    F2_PERCENTILE_PROSPERITY("f2PercentileProsperity", "Factors percentile for Prosperity", "13"),
    F3_SCORE_DEPENDANTS("f3ScoreDependants", "Factors score for Dependants", "-24255"),
    F3_PERCENTILE_DEPENDANTS("f3PercentileDependants", "Factors percentile for Dependants", "13"),
    F4_SCORE_CULTURAL_DIVERSITY("f4ScoreCulturalDiversity", "Factors score for Cultural Diversity", "-24255"),
    F4_PERCENTILE_CULTURAL_DIVERSITY("f4PercentileCulturalDiversity", "Factors percentile for Cultural Diversity", "13"),
    F5_SCORE_HOUSING_OWNERSHIP("f5ScoreHousingOwnership", "Factors score for Housing Ownership", "-24255"),
    F5_PERCENTILE_HOUSING_OWNERSHIP("f5PercentileHousingOwnership", "Factors percentile for Housing Ownership", "13"),
    F6_SCORE_MULTI_DWELLINGS("f6ScoreMultiDwellings", "Factors score for Multi Dwellings", "-24255"),
    F6_PERCENTILE_MULTI_DWELLINGS("f6PercentileMultiDwellings", "Factors percentile for Multi Dwellings", "13"),
    GNAF_LATITUDE("gnafLatitude", "Latitude of the address", "-37.36555450"),
    GNAF_LONGITUDE("gnafLongitude", "Longitude of the address", "144.52962801"),
    LOCAL_GOVERNMENT_AREA_CODE("localGovernmentAreaCode", "LGA code", "39299"),
    LOCAL_GOVERNMENT_AREA_DESCRIPTION("localGovernmentAreaDescription", "Name of the Local Government Area", "Onkaparinga (C)"),
    BUSINESS_RESIDENTIAL_CODE("businessResidentialCode", "Premises type for the DPID", "R"),
    AUSBAR("ausbar", "Standard address barcode for an address", ""),
    MESH_BLOCK("meshblock", "11 digit meshblock code", ""),
    MESH_BLOCK_LATITUDE("meshblockLatitude", "Latitude of the Meshblock centroid", "-37.36647900"),
    MESH_BLOCK_LONGITUDE("meshblockLongitude", "Longitude of the Meshblock centroid", "144.53153100"),
    SA1_CODE("sa1Code", "7 digit SA1 code", ""),
    SA1_LATITUDE("sa1Latitude", "Latitude of the SA1 centroid", "-37.36647900"),
    SA1_LONGITUDE("sa1Longitude", "Longitude of the SA1 centroid", "144.53153100");

    private final String elementName;
    private final String description;
    private final String example;

    Aus(String elementName, String description, String example) {
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
