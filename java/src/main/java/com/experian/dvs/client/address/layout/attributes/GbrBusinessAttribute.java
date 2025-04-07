package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum GbrBusinessAttribute {

    URN("urn"),
    COMMERCIAL_MOSAIC("commercial_mosaic"),
    REGISTRATION("registration"),
    PHONE("phone"),
    NUMBER_OF_EMPLOYEES("number_of_employees"),
    LOCATION("location"),
    STANDARD_INDUSTRY_CLASSIFICATION("standard_industry_classification"),
    NON_LIMITED_COMPANY_KEY("non_limited_company_key");

    private final String value;
    // Map of value to GbrBusinessAttribute
    private static final Map<String, GbrBusinessAttribute> valueMap = Arrays.stream(GbrBusinessAttribute.values()).collect(Collectors.toMap(GbrBusinessAttribute::getValue, Function.identity()));

    public static GbrBusinessAttribute fromValue(final String value) {
        return valueMap.get(value);
    }

    GbrBusinessAttribute(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}
