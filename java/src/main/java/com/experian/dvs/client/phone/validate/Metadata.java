package com.experian.dvs.client.phone.validate;

import com.experian.dvs.client.server.phone.RestApiPhoneValidateMetadata;

import java.util.Objects;

public class Metadata {

    private final String code;
    private final String message;
    private final PhoneDetail phoneDetail;

    public Metadata(final RestApiPhoneValidateMetadata metadata) {
        this.code = Objects.toString(metadata.getCode(), "");
        this.message = Objects.toString(metadata.getMessage(), "");
        this.phoneDetail = metadata.getPhoneDetail() != null ? new PhoneDetail(metadata.getPhoneDetail()) : null;

    }

    public String getCode() {
        return code;
    }

    public String getMessage() {
        return message;
    }

    public PhoneDetail getPhoneDetail() {
        return phoneDetail;
    }
}
