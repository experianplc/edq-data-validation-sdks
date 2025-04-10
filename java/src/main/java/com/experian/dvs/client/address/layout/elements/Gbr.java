package com.experian.dvs.client.address.layout.elements;

public enum Gbr implements AddressElement {

    EMPTY("empty", "Empty line", ""),
    COMPANY_NAME("companyName", "Company/organisation name assigned", ""),
    DEPARTMENT("department", "Departments within an organisation that are postally addressable", ""),
    STREET_NUMBER("streetNumber", "Street/Building number", ""),
    BUILDING_LEVEL("buildingLevel", "Building level", ""),
    BUILDING_GROUP("buildingGroup", "Building group", ""),
    BUILDING_GROUP_NAME("buildingGroupName", "Building group name", ""),
    BUILDING_GROUP_DESC("buildingGroupDesc", "Building group description", ""),
    EXTENSION("extension", "Building extension", ""),
    EXTENSION_ALT("extensionAlt", "Building extension alternative information", ""),
    EXTENSION_ALT_NAME("extensionAltName", "Building extension alternative name", ""),
    EXTENSION_NUMBER("extensionNumber", "Building extension number", ""),
    SUB_BUILDING_TYPE("subBuildingType", "Sub building type", ""),
    SUB_BUILDING_NUMBER("subBuildingNumber", "Sub building number", ""),
    PO_BOX("poBox", "PO Box / Delivery service full 1", ""),
    PO_BOX_TYPE("poBoxType", "PO Box type", ""),
    PO_BOX_NUMBER("poBoxNumber", "PO Box number", ""),
    BOX("box", "Box", ""),
    BOX_TYPE("boxType", "Box type", ""),
    BOX_NUMBER("boxNumber", "Box number", ""),
    STREET_PRIMARY("streetPrimary", "Street primary", ""),
    STREET_PRE_DIRECTIONAL_PRIMARY("streetPreDirectionalPrimary", "Street pre directional primary", ""),
    STREET_NAME_PRIMARY("streetNamePrimary", "Street name primary", ""),
    STREET_TYPE_PRIMARY("streetTypePrimary", "Street type primary", ""),
    STREET_POST_DIRECTIONAL_PRIMARY("streetPostDirectionalPrimary", "Street post directional primary", ""),
    STREET_SECONDARY("streetSecondary", "Street secondary", ""),
    STREET_NAME_SECONDARY("streetNameSecondary", "Street name secondary", ""),
    STREET_TYPE_SECONDARY("streetTypeSecondary", "Street type secondary", ""),
    REGION("region", "Region", ""),
    REGION_ALT("regionAlt", "Region alternative information", ""),
    STATE("state", "State", ""),
    STATE_ABBREVIATION("stateAbbreviation", "State abbreviation", ""),
    COUNTY("county", "County", ""),
    TOWN("town", "Town", ""),
    PREFERRED_TOWN("preferredTown", "Preferred town name", ""),
    LOCALITY_L1("localityL1", "Locality L1", ""),
    LOCALITY_L2("localityL2", "Locality L2", ""),
    LOCALITY_L3("localityL3", "Locality L3", ""),
    POSTCODE("postcode", "Postcode", ""),
    POSTCODE_ALT1("postcodeAlt1", "Postcode alternative information 1", ""),
    POSTCODE_ALT2("postcodeAlt2", "Postcode alternative information 2", ""),
    COUNTRY("country", "Country", ""),
    COUNTRY_CODE("countryCode", "Country code", ""),
    RETAINED("retained", "Retained", "");

    private final String elementName;
    private final String description;
    private final String example;

    Gbr(String elementName, String description, String example) {
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