package com.experian.dvs.client.address.format.components;

import com.experian.dvs.client.server.address.format.RestApiAddressFormatComponents;

import java.util.Objects;

public class AdditionalSubRegion {
    private final String administrativeCounty;
    private final String formerPostalCounty;
    private final String traditionalCounty;

    // Constructor
    public AdditionalSubRegion(RestApiAddressFormatComponents.RestApiAddressComponentAdditionalSubRegion api) {
        this.administrativeCounty = Objects.toString(api.getAdministrativeCounty(), "");
        this.formerPostalCounty = Objects.toString(api.getFormerPostalCounty(), "");
        this.traditionalCounty = Objects.toString(api.getTraditionalCounty(), "");
    }

    // Getters
    public String getAdministrativeCounty() {
        return administrativeCounty;
    }

    public String getFormerPostalCounty() {
        return formerPostalCounty;
    }

    public String getTraditionalCounty() {
        return traditionalCounty;
    }
}
