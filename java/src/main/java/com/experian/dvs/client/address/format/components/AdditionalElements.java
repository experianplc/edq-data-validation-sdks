package com.experian.dvs.client.address.format.components;

import com.experian.dvs.client.server.address.format.RestApiAddressFormatComponents;

public class AdditionalElements {
    private final AdditionalLocality locality;

    // Constructor
    public AdditionalElements(RestApiAddressFormatComponents.RestApiAddressComponentAdditionalElements locality) {
        this.locality = locality.getLocality() != null ? new AdditionalLocality(locality.getLocality()) : null;
    }

    // Getters
    public AdditionalLocality getLocality() {
        return locality;
    }

}
