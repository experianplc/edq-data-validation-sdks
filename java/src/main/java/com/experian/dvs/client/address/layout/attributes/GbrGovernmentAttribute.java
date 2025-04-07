package com.experian.dvs.client.address.layout.attributes;

import java.util.Arrays;
import java.util.Map;
import java.util.function.Function;
import java.util.stream.Collectors;

public enum GbrGovernmentAttribute {

    EER_CODE("eer_code"),
    EER_CODE_PRE_2011("eer_code_pre_2011"),
    EER_NAME("eer_name"),
    GOR_CODE("gor_code"),
    GOR_CODE_PRE_2011("gor_code_pre_2011"),
    GOR_NAME("gor_name"),
    LEA_CODE("lea_code"),
    LEA_NAME("lea_name"),
    LA_CODE("la_code"),
    LA_CODE_PRE_2011("la_code_pre_2011"),
    LA_NAME("la_name"),
    WARD_CODE("ward_code"),
    WARD_CODE_PRE_2011("ward_code_pre_2011"),
    WARD_NAME("ward_name"),
    CENS_OUT_AREA("cens_out_area");

    private final String value;
    // Map of value to GbrGovernmentAttribute
    private static final Map<String, GbrGovernmentAttribute> valueMap = Arrays.stream(GbrGovernmentAttribute.values()).collect(Collectors.toMap(GbrGovernmentAttribute::getValue, Function.identity()));

    public static GbrGovernmentAttribute fromValue(final String value) {
        return valueMap.get(value);
    }

    GbrGovernmentAttribute(final String value) {
        this.value = value;
    }

    public String getValue() {
        return value;
    }
}