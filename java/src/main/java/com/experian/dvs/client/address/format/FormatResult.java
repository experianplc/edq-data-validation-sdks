package com.experian.dvs.client.address.format;

import com.experian.dvs.client.address.AddressConfidence;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatEnrichment;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatMetadata;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatResponse;
import com.experian.dvs.client.server.address.format.RestApiFormatResult;

import java.util.Objects;
import java.util.Optional;

public class FormatResult {

    private final String globalAddressKey;
    private final AddressConfidence confidence;
    private final FormatAddress address;
    private final AddressFormatted addressFormatted;
    private final AddressComponents components;

    private final AddressMetadata metadata;
    private final AddressEnrichment addressEnrichment;

    public FormatResult(final RestApiAddressFormatResponse response) {

        final RestApiFormatResult apiResult = response.getResult();
        final RestApiAddressFormatMetadata apiMetadata = response.getMetadata();
        final RestApiAddressFormatEnrichment apiEnrichment = response.getEnrichment();

        if (apiResult != null) {
            this.globalAddressKey = Objects.toString(apiResult.getGlobalAddressKey(), "");
            this.confidence = apiResult.getConfidence() != null ? AddressConfidence.fromName(apiResult.getConfidence()) : null;
            this.address = apiResult.getAddress() != null ? new FormatAddress(apiResult.getAddress()) : null;
            //only one currently supported so just pick the first
            this.addressFormatted = apiResult.getAddressesFormatted() != null && !apiResult.getAddressesFormatted().isEmpty() ? new AddressFormatted(apiResult.getAddressesFormatted().get(0)) : null;
            this.components = apiResult.getComponents() != null ? new AddressComponents(apiResult.getComponents()) : null;
        } else {
            this.globalAddressKey = "";
            this.confidence = null;
            this.address = null;
            this.addressFormatted = null;
            this.components = null;
        }

        this.metadata = apiMetadata != null ? new AddressMetadata(apiMetadata) : null;
        this.addressEnrichment = apiEnrichment != null ? new AddressEnrichment(apiEnrichment) : null;
    }

    public String getGlobalAddressKey() {
        return globalAddressKey;
    }

    public AddressConfidence getConfidence() {
        return confidence;
    }

    public FormatAddress getAddress() {
        return address;
    }

    public AddressFormatted getAddressFormatted() {
        return addressFormatted;
    }

    public Optional<AddressMetadata> getMetadata() {
        return Optional.ofNullable(metadata);
    }

    public Optional<AddressEnrichment> getEnrichment() {
        return Optional.ofNullable(addressEnrichment);
    }

    public Optional<AddressComponents> getComponents() {
        return Optional.ofNullable(components);
    }
}
