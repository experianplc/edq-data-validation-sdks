package com.experian.dvs.client.server.phone;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiPhoneValidateMetadata {

    @JsonProperty("code")
    private String code;
    @JsonProperty("message")
    private String message;
    @JsonProperty("phone_detail")
    private RestApiPhoneValidatePhoneDetail phoneDetail;

    public String getCode() {
        return code;
    }

    public void setCode(String code) {
        this.code = code;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public RestApiPhoneValidatePhoneDetail getPhoneDetail() {
        return phoneDetail;
    }

    public void setPhoneDetail(RestApiPhoneValidatePhoneDetail phoneDetail) {
        this.phoneDetail = phoneDetail;
    }
}
