package com.experian.dvs.client.address.search;

import com.experian.dvs.client.server.address.search.RestApiSearchResultAdditionalAttribute;

import java.util.Objects;

public class AdditionalAttribute {

    private final String name;
    private final String value;

    public AdditionalAttribute(final RestApiSearchResultAdditionalAttribute restApiSearchResultAdditionalAttribute) {
        this.name = Objects.toString(restApiSearchResultAdditionalAttribute.getName(), "");
        this.value = Objects.toString(restApiSearchResultAdditionalAttribute.getValue());
    }

    public String getName() {
        return name;
    }

    public String getValue() {
        return value;
    }

}
