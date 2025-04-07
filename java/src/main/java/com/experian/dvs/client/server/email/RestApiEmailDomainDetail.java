package com.experian.dvs.client.server.email;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEmailDomainDetail {

    @JsonProperty("type")
    private String type;

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }
}
