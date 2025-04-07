package com.experian.dvs.client.phone.validate;

import java.util.HashMap;
import java.util.Map;

public enum PhoneType {
    MOBILE("Mobile"),
    LANDLINE("Landline"),
    MOBILE_OR_LANDLINE("Mobile or landline"),
    TOLL_FREE("Toll free"),
    PREMIUM("Premium"),
    SHARED_COST("Shared cost"),
    VOIP("VoIP"),
    STAGE_AND_SCREEN("Stage and screen"),
    PAGER("Pager"),
    UNIVERSAL_ACCESS_NUMBER("Universal access number"),
    PERSONAL_NUMBER("Personal number"),
    VOICEMAIL_ONLY("Voicemail only"),
    BAD_FORMAT("Bad format"),
    UNKNOWN("Unknown")
    ;

    private final String value;

    private static final Map<String, PhoneType> valueMap = new HashMap<>();

    static {
        for (PhoneType phoneValidationPhoneType : PhoneType.values()) {
            valueMap.put(phoneValidationPhoneType.value, phoneValidationPhoneType);
        }
    }

    public static PhoneType fromValue(String value) {
        return valueMap.get(value);
    }

    PhoneType(String value) {
        this.value = value;
    }
}
