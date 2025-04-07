package com.experian.dvs.client.address.format;

import com.experian.dvs.client.server.address.format.RestApiFormatAddress;

import java.util.Objects;

public class Address {

    private final String addressLine1;
    private final String addressLine2;
    private final String addressLine3;
    private final String locality;
    private final String region;
    private final String postalCode;
    private final String country;

    public Address(final RestApiFormatAddress apiAddress) {
        this.addressLine1 = Objects.toString(apiAddress.getAddressLine1(), "");
        this.addressLine2 = Objects.toString(apiAddress.getAddressLine2(), "");
        this.addressLine3 = Objects.toString(apiAddress.getAddressLine3(), "");
        this.locality = Objects.toString(apiAddress.getLocality(), "");
        this.region = Objects.toString(apiAddress.getRegion(), "");
        this.postalCode = Objects.toString(apiAddress.getPostalCode(), "");
        this.country = Objects.toString(apiAddress.getCountry(), "");
    }

    public String getAddressLine1() {
        return addressLine1;
    }

    public String getAddressLine2() {
        return addressLine2;
    }

    public String getAddressLine3() {
        return addressLine3;
    }

    public String getLocality() {
        return locality;
    }

    public String getRegion() {
        return region;
    }

    public String getPostalCode() {
        return postalCode;
    }

    public String getCountry() {
        return country;
    }
}
