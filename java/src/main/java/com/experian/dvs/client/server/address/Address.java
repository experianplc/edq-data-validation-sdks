package com.experian.dvs.client.server.address;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class Address {

    @JsonProperty("unspecified")
    private List<String> addressLines;

    public Address() {
    }

    public Address(final String singleline) {
        this(List.of(singleline));
    }

    public Address(final List<String> lines) {
        this.addressLines = lines;
    }

    public  List<String> getAddressLines() {
        return this.addressLines;
    }

    public void setAddressLines(final List<String> addressLines) {
        this.addressLines = addressLines;
    }
}
