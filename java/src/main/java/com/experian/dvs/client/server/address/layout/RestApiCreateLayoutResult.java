package com.experian.dvs.client.server.address.layout;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiCreateLayoutResult {

    @JsonProperty("id")
    private String id;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }
}
