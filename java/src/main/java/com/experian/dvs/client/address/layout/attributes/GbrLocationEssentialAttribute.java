package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum GbrLocationEssentialAttribute {

    LATITUDE("latitude"),
    LONGITUDE("longitude"),
    MATCH_LEVEL("match_level"),
    UDPRN("udprn"),
    UPRN("uprn"),
    X_COORDINATE("x_coordinate"),
    Y_COORDINATE("y_coordinate");

    private final String value;
    // Map of value to GbrLocationEssentialAttribute
    private static final Map<String, GbrLocationEssentialAttribute> valueMap = Arrays.stream(GbrLocationEssentialAttribute.values()).collect(Collectors.toMap(GbrLocationEssentialAttribute::getValue, Function.identity()));

    public static GbrLocationEssentialAttribute fromValue(final String value) {
        return valueMap.get(value);
    }

    GbrLocationEssentialAttribute(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}
