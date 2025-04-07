package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum GlobalGeocodeAttribute {

    LATITUDE("latitude"),
    LONGITUDE("longitude"),
    MATCH_LEVEL("match_level");

    private final String value;
    // Map of value to GlobalGeocodeAttribute
    private static final Map<String, GlobalGeocodeAttribute> valueMap = Arrays.stream(GlobalGeocodeAttribute.values()).collect(Collectors.toMap(GlobalGeocodeAttribute::getValue, Function.identity()));

    public static GlobalGeocodeAttribute fromValue(final String value) {
        return valueMap.get(value);
    }

    GlobalGeocodeAttribute(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}
