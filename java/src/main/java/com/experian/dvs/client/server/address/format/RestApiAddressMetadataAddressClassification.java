package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressMetadataAddressClassification {

    @JsonProperty("address_type")
    private String addressType;

    @JsonProperty("delivery_type")
    private String deliveryType;

    @JsonProperty("is_deliverable")
    private Boolean isDeliverable;

    public String getAddressType() {
        return addressType;
    }

    public void setAddressType(String addressType) {
        this.addressType = addressType;
    }

    public String getDeliveryType() {
        return deliveryType;
    }

    public void setDeliveryType(String deliveryType) {
        this.deliveryType = deliveryType;
    }

    public Boolean getDeliverable() {
        return isDeliverable;
    }

    public void setDeliverable(Boolean deliverable) {
        isDeliverable = deliverable;
    }
}
