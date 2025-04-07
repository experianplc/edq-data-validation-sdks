package com.experian.dvs.client.address.format.components;

import com.experian.dvs.client.server.address.format.RestApiAddressFormatComponents;

public class Locality {

    private final LocalityItem region;
    private final LocalityItem subRegion;
    private final LocalityItem town;
    private final LocalityItem district;
    private final LocalityItem subDistrict;

    // Constructor
    public Locality(RestApiAddressFormatComponents.RestApiAddressComponentLocality api) {
        this.region = api.getRegion() != null ? new LocalityItem(api.getRegion().getName(), api.getRegion().getCode(), api.getRegion().getDescription()) : null;
        this.subRegion = api.getSubRegion() != null ? new LocalityItem(api.getSubRegion().getName(), api.getSubRegion().getCode(), api.getSubRegion().getDescription()) : null;
        this.town = api.getTown() != null ? new LocalityItem(api.getTown().getName(), api.getTown().getCode(), api.getTown().getDescription()) : null;
        this.district = api.getDistrict() != null ? new LocalityItem(api.getDistrict().getName(), api.getDistrict().getCode(), api.getDistrict().getDescription()) : null;
        this.subDistrict = api.getSubDistrict() != null ? new LocalityItem(api.getSubDistrict().getName(), api.getSubDistrict().getCode(), api.getSubDistrict().getDescription()) : null;
    }

    // Getters
    public LocalityItem getRegion() {
        return region;
    }

    public LocalityItem getSubRegion() {
        return subRegion;
    }

    public LocalityItem getTown() {
        return town;
    }

    public LocalityItem getDistrict() {
        return district;
    }

    public LocalityItem getSubDistrict() {
        return subDistrict;
    }
}
