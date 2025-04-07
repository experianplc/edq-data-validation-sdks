package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum UsaRegionalGeocodeAttribute {

    LATITUDE("latitude"),
    LONGITUDE("longitude"),
    MATCH_LEVEL("match_level"),
    CENSUS_TRACT("census_tract"),
    CENSUS_BLOCK("census_block"),
    CORE_BASED_STATISTICAL_AREA("core_based_statistical_area"),
    CONGRESSIONAL_DISTRICT_CODE("congressional_district_code"),
    COUNTY_CODE("county_code");

    private final String value;
    // Map of value to UsaRegionalGeocodeAttribute
    private static final Map<String, UsaRegionalGeocodeAttribute> valueMap = Arrays.stream(UsaRegionalGeocodeAttribute.values()).collect(Collectors.toMap(UsaRegionalGeocodeAttribute::getValue, Function.identity()));

    public static UsaRegionalGeocodeAttribute fromValue(final String value) {
        return valueMap.get(value);
    }

    UsaRegionalGeocodeAttribute(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}
