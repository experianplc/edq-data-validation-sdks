package com.experian.dvs.client.server.address.search;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAdditionalOption {

    @JsonProperty("name")
    private String name;

    @JsonProperty("value")
    private String value;

    public RestApiAdditionalOption() {
    }

    public RestApiAdditionalOption(final String name, final String value) {
        this.name = name;
        this.value = value;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }
}
