package com.experian.dvs.client.phone.validate;

import com.experian.dvs.client.phone.Confidence;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateMetadata;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateResponse;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateResult;

import java.util.Objects;

public class Result {

    private final String number;
    private final String validatedPhoneNumber;
    private final String formattedPhoneNumber;
    private final String phoneType;
    private final Confidence confidence;
    private final String portedDate;
    private final String disposableNumber;
    private final Metadata metadata;


    public Result(final RestApiPhoneValidateResponse response) {

        final RestApiPhoneValidateResult result = response.getResult();
        if (result != null) {
            this.number = Objects.toString(result.getNumber(), "");
            this.validatedPhoneNumber = Objects.toString(result.getValidatedPhoneNumber(), "");
            this.formattedPhoneNumber = Objects.toString(result.getFormattedPhoneNumber(), "");
            this.phoneType = Objects.toString(result.getPhoneType(), "");
            this.confidence = result.getConfidence() != null ? Confidence.fromValue(result.getConfidence()): Confidence.UNKNOWN;
            this.portedDate = Objects.toString(result.getPortedDate(), "");
            this.disposableNumber = Objects.toString(result.getDisposableNumber(), "");
        } else {
            this.number = "";
            this.validatedPhoneNumber = "";
            this.formattedPhoneNumber = "";
            this.phoneType = "";
            this.confidence = Confidence.UNKNOWN;
            this.portedDate = "";
            this.disposableNumber = "";
        }

        final RestApiPhoneValidateMetadata metadataFromApi = response.getMetadata();
        if (metadataFromApi != null) {
            this.metadata = new Metadata(metadataFromApi);
        } else {
            this.metadata = null;
        }

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

    public String getPhoneType() {
        return phoneType;
    }

    public Confidence getConfidence() {
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
}
