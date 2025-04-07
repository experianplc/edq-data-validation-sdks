package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum GbrLocationCompleteAttribute {

    LATITUDE("latitude"),
    LONGITUDE("longitude"),
    MATCH_LEVEL("match_level"),
    UDPRN("udprn"),
    UPRN("uprn"),
    X_COORDINATE("x_coordinate"),
    Y_COORDINATE("y_coordinate");

    private final String value;
    // Map of value to GbrLocationCompleteAttribute
    private static final Map<String, GbrLocationCompleteAttribute> valueMap = Arrays.stream(GbrLocationCompleteAttribute.values()).collect(Collectors.toMap(GbrLocationCompleteAttribute::getValue, Function.identity()));

    public static GbrLocationCompleteAttribute fromValue(final String value) {
        return valueMap.get(value);
    }

    GbrLocationCompleteAttribute(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}
