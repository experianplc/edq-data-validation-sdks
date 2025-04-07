package com.experian.dvs.client.server.address.suggestions;

import com.experian.dvs.client.server.address.format.RestApiAddressFormatComponents;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatMetadata;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatted;
import com.experian.dvs.client.server.address.format.RestApiFormatAddress;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiSuggestionsFormatSuggestion {
    @JsonProperty("global_address_key")
    private String globalAddressKey;

    @JsonProperty("address")
    private RestApiFormatAddress address;

    @JsonProperty("addresses_formatted")
    private List<RestApiAddressFormatted> addressesFormatted;

    @JsonProperty("components")
    private RestApiAddressFormatComponents components;

    @JsonProperty("metadata")
    private RestApiAddressFormatMetadata metadata;

    public String getGlobalAddressKey() {
        return globalAddressKey;
    }

    public void setGlobalAddressKey(String globalAddressKey) {
        this.globalAddressKey = globalAddressKey;
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

    public RestApiAddressFormatMetadata getMetadata() {
        return metadata;
    }

    public void setMetadata(RestApiAddressFormatMetadata metadata) {
        this.metadata = metadata;
    }

}
