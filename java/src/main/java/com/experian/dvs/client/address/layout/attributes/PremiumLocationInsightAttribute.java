package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum PremiumLocationInsightAttribute {

    GEOCODES("geocodes"),
    GEOCODES_BUILDING_XY("geocodes_building_xy"),
    GEOCODES_ACCESS("geocodes_access"),
    TIME("time");

    private final String value;
    // Map of value to PremiumLocationInsightAttribute
    private static final Map<String, PremiumLocationInsightAttribute> valueMap = Arrays.stream(PremiumLocationInsightAttribute.values()).collect(Collectors.toMap(PremiumLocationInsightAttribute::getValue, Function.identity()));

    public static PremiumLocationInsightAttribute fromValue(final String value) {
        return valueMap.get(value);
    }

    PremiumLocationInsightAttribute(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}
