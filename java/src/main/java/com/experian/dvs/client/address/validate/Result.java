package com.experian.dvs.client.address.validate;

import com.experian.dvs.client.address.Confidence;
import com.experian.dvs.client.address.format.Address;
import com.experian.dvs.client.address.format.AddressFormatted;
import com.experian.dvs.client.server.address.validate.RestApiAddressValidateResponse;
import com.experian.dvs.client.server.address.validate.RestApiAddressValidateResult;

import java.util.Objects;

public class Result {

    private final ValidationDetail validationDetail;
    private final String globalAddressKey;
    private final boolean moreResultsAvailable;
    private final Confidence confidence;
    private final Address address;
    private final AddressFormatted addressFormatted;

    public Result(RestApiAddressValidateResponse response) {
        final RestApiAddressValidateResult result = response.getResult();
        if (result != null) {
            this.validationDetail = result.getValidationDetail() != null ? new ValidationDetail(result.getValidationDetail()) : null;
            this.globalAddressKey = Objects.toString(result.getGlobalAddressKey(), "");
            this.moreResultsAvailable = Boolean.TRUE.equals(result.isMoreResultsAvailable());
            this.confidence = result.getConfidence() != null ? Confidence.fromName(result.getConfidence()) : null;
            this.address = result.getAddress() != null ? new Address(result.getAddress()) : null;
            //only one currently supported so just pick the first
            this.addressFormatted = result.getAddressesFormatted() != null  && !result.getAddressesFormatted().isEmpty() ? new AddressFormatted(result.getAddressesFormatted().get(0)) : null;
            //todo complete this

        } else {
            this.validationDetail = null;
            this.globalAddressKey = "";
            this.moreResultsAvailable = false;
            this.confidence = null;
            this.address = null;
            this.addressFormatted = null;
        }
    }

    public ValidationDetail getValidationDetail() {
        return validationDetail;
    }

    public String getGlobalAddressKey() {
        return globalAddressKey;
    }

    public boolean isMoreResultsAvailable() {
        return moreResultsAvailable;
    }

    public Confidence getConfidence() {
        return confidence;
    }

    public Address getAddress() {
        return address;
    }

    public AddressFormatted getAddressFormatted() {
        return addressFormatted;
    }
}
