package com.experian.dvs.client.server.address.dataset;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressDatasetElement {

    @JsonProperty("id")
    private String id;
    @JsonProperty("name")
    private String name;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
