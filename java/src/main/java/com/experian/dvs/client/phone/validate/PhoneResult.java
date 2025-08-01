package com.experian.dvs.client.phone.validate;

import com.experian.dvs.client.phone.PhoneConfidence;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateMetadata;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateResponse;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateResult;

import java.util.Objects;

public class PhoneResult {

    private final String number;
    private final String validatedPhoneNumber;
    private final String formattedPhoneNumber;
    private final PhoneType phoneType;
    private final PhoneConfidence confidence;
    private final String portedDate;
    private final String disposableNumber;
    private final Metadata metadata;
    private final String referenceId;

    public PhoneResult(final RestApiPhoneValidateResponse response) {

        final RestApiPhoneValidateResult result = response.getResult();
        if (result != null) {
            this.number = Objects.toString(result.getNumber(), "");
            this.validatedPhoneNumber = Objects.toString(result.getValidatedPhoneNumber(), "");
            this.formattedPhoneNumber = Objects.toString(result.getFormattedPhoneNumber(), "");
            this.phoneType = result.getPhoneType() != null ? PhoneType.fromValue(result.getPhoneType()): PhoneType.UNKNOWN;
            this.confidence = result.getConfidence() != null ? PhoneConfidence.fromValue(result.getConfidence()): PhoneConfidence.UNKNOWN;
            this.portedDate = Objects.toString(result.getPortedDate(), "");
            this.disposableNumber = Objects.toString(result.getDisposableNumber(), "");
        } else {
            this.number = "";
            this.validatedPhoneNumber = "";
            this.formattedPhoneNumber = "";
            this.phoneType = PhoneType.UNKNOWN;
            this.confidence = PhoneConfidence.UNKNOWN;
            this.portedDate = "";
            this.disposableNumber = "";
        }

        final RestApiPhoneValidateMetadata metadataFromApi = response.getMetadata();
        if (metadataFromApi != null) {
            this.metadata = new Metadata(metadataFromApi);
        } else {
            this.metadata = null;
        }

        this.referenceId = response.getReferenceId();
    }

    public String getNumber() {
        return number;
    }

    public String getValidatedPhoneNumber() {
        return validatedPhoneNumber;
    }

    public String getFormattedPhoneNumber() {
        return formattedPhoneNumber;
    }

    public PhoneType getPhoneType() {
        return phoneType;
    }

    public PhoneConfidence getConfidence() {
        return confidence;
    }

    public String getPortedDate() {
        return portedDate;
    }

    public String getDisposableNumber() {
        return disposableNumber;
    }

    public Metadata getMetadata() {
        return metadata;
    }

    public String getReferenceId() {
        return referenceId;
    }
}
