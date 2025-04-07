package com.experian.dvs.client.address.format.components;

import com.experian.dvs.client.server.address.format.RestApiAddressFormatComponents;

public class AdditionalLocality {

    private final AdditionalSubRegion subRegion;

    // Constructor
    public AdditionalLocality(RestApiAddressFormatComponents.RestApiAddressComponentAdditionalLocality locality) {
        this.subRegion = locality.getSubRegion() != null ? new AdditionalSubRegion(locality.getSubRegion()) : null;
    }

    // Getters
    public AdditionalSubRegion getSubRegion() {
        return subRegion;
    }
}
