package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum GBRHealth {

    AUTHORITY_CODE("authority_code"),
    AUTHORITY_CODE_2011("authority_code_2011"),
    AUTHORITY_NAME("authority_name"),
    PCLH_CODE("pclh_code"),
    PCLH_CODE_2011("pclh_code_2011"),
    PCLH_NAME("pclh_name"),
    WARD_CODE("ward_code"),
    WARD_CODE_2011("ward_code_2011"),
    WARD_NAME("ward_name"),
    CCG_CODE("ccg_code"),
    CCG_NAME("ccg_name"),
    DOH_CODE("doh_code");

    private final String value;
    // Map of value to GBRHealth
    private static final Map<String, GBRHealth> valueMap = Arrays.stream(GBRHealth.values()).collect(Collectors.toMap(GBRHealth::getValue, Function.identity()));

    public static GBRHealth fromValue(final String value) {
        return valueMap.get(value);
    }

    GBRHealth(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}


