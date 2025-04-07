package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

@JsonIgnoreProperties(ignoreUnknown = true)
public class RestApiFormatResult {

    @JsonProperty("global_address_key")
    private String globalAddressKey;

    @JsonProperty("confidence")
    private String confidence;

    @JsonProperty("address")
    private RestApiFormatAddress address;

    @JsonProperty("addresses_formatted")
    private List<RestApiAddressFormatted> addressesFormatted;

    @JsonProperty("components")
    private RestApiAddressFormatComponents components;

    public String getGlobalAddressKey() {
        return globalAddressKey;
    }

    public void setGlobalAddressKey(String globalAddressKey) {
        this.globalAddressKey = globalAddressKey;
    }

    public String getConfidence() {
        return confidence;
    }

    public void setConfidence(String confidence) {
        this.confidence = confidence;
    }

    public RestApiFormatAddress getAddress() {
        return address;
    }

    public void setAddress(RestApiFormatAddress address) {
        this.address = address;
    }

    public List<RestApiAddressFormatted> getAddressesFormatted() {
        return addressesFormatted;
    }

    public void setAddressesFormatted(List<RestApiAddressFormatted> addressesFormatted) {
        this.addressesFormatted = addressesFormatted;
    }

    public RestApiAddressFormatComponents getComponents() {
        return components;
    }

    public void setComponents(RestApiAddressFormatComponents components) {
        this.components = components;
    }
}
