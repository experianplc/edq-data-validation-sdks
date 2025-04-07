package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum What3WordsAttribute {

    LATITUDE("latitude"),
    LONGITUDE("longitude"),
    NAME("name"),
    DESCRIPTION("description");

    private final String value;
    // Map of value to What3WordsAttribute
    private static final Map<String, What3WordsAttribute> valueMap = Arrays.stream(What3WordsAttribute.values()).collect(Collectors.toMap(What3WordsAttribute::getValue, Function.identity()));

    public static What3WordsAttribute fromValue(final String value) {
        return valueMap.get(value);
    }

    What3WordsAttribute(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}
