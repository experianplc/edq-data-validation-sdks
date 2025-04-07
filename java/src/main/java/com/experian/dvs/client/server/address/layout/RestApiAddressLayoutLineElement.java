package com.experian.dvs.client.server.address.layout;

import com.experian.dvs.client.address.layout.elements.AddressElement;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressLayoutLineElement {

    @JsonProperty("element_name")
    private String elementName;

    public RestApiAddressLayoutLineElement() {
    }

    public RestApiAddressLayoutLineElement(final AddressElement addressElement) {
        this.elementName = addressElement.getElementName();
    }

    public String getElementName() {
        return elementName;
    }

    public void setElementName(String elementName) {
        this.elementName = elementName;
    }
}
