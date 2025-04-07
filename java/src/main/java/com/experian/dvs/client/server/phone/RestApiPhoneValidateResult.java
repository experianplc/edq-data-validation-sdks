package com.experian.dvs.client.server.phone;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiPhoneValidateResult {

    @JsonProperty("number")
    private String number;
    @JsonProperty("validated_phone_number")
    private String validatedPhoneNumber;
    @JsonProperty("formatted_phone_number")
    private String formattedPhoneNumber;
    @JsonProperty("phone_type")
    private String phoneType;
    @JsonProperty("confidence")
    private String confidence;
    @JsonProperty("ported_date")
    private String portedDate;
    @JsonProperty("disposable_number")
    private String disposableNumber;

    public String getNumber() {
        return number;
    }

    public void setNumber(String number) {
        this.number = number;
    }

    public String getValidatedPhoneNumber() {
        return validatedPhoneNumber;
    }

    public void setValidatedPhoneNumber(String validatedPhoneNumber) {
        this.validatedPhoneNumber = validatedPhoneNumber;
    }

    public String getFormattedPhoneNumber() {
        return formattedPhoneNumber;
    }

    public void setFormattedPhoneNumber(String formattedPhoneNumber) {
        this.formattedPhoneNumber = formattedPhoneNumber;
    }

    public String getPhoneType() {
        return phoneType;
    }

    public void setPhoneType(String phoneType) {
        this.phoneType = phoneType;
    }

    public String getConfidence() {
        return confidence;
    }

    public void setConfidence(String confidence) {
        this.confidence = confidence;
    }

    public String getPortedDate() {
        return portedDate;
    }

    public void setPortedDate(String portedDate) {
        this.portedDate = portedDate;
    }

    public String getDisposableNumber() {
        return disposableNumber;
    }

    public void setDisposableNumber(String disposableNumber) {
        this.disposableNumber = disposableNumber;
    }
}
