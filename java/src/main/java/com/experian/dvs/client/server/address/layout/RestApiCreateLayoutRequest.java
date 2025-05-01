package com.experian.dvs.client.server.address.layout;

import com.experian.dvs.client.address.layout.LayoutConfiguration;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;

@JsonInclude(JsonInclude.Include.NON_NULL)
public class RestApiCreateLayoutRequest {

    @JsonProperty("layout")
    private RestApiAddressLayout layout;

    public static RestApiCreateLayoutRequest using(final LayoutConfiguration configuration) {
        return new RestApiCreateLayoutRequest();
    }

    public RestApiAddressLayout getLayout() {
        return layout;
    }

    public void setLayout(RestApiAddressLayout layout) {
        this.layout = layout;
    }
}
