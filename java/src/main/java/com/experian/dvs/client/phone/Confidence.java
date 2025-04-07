package com.experian.dvs.client.phone;

import java.util.HashMap;
import java.util.Map;

public enum Confidence {
    VERIFIED("Verified"),
    ABSENT("Absent"),
    TELESERVICE_NOT_PROVISIONED("Teleservice not provisioned"),
    UNVERIFIED("Unverified"),
    NO_COVERAGE("No coverage"),
    UNKNOWN("Unknown"),
    DEAD("Dead")
    ;

    private final String value;

    //Map of value to PhoneValidationConfidence
    private static final Map<String, Confidence> valueMap = new HashMap<>();
    //Initialize the valueMap
    static {
        for (Confidence confidence : Confidence.values()) {
            valueMap.put(confidence.value, confidence);
        }
    }

    public static Confidence fromValue(String value) {
        return valueMap.get(value);
    }

    Confidence(String value) {
        this.value = value;
    }


}
