package com.experian.dvs.client.server.address.layout;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiGetLayoutResult {

    @JsonProperty("layout")
    private RestApiGetLayoutLayout layout;


    public RestApiGetLayoutLayout getLayout() {
        return layout;
    }

    public void setLayout(RestApiGetLayoutLayout layout) {
        this.layout = layout;
    }
}
