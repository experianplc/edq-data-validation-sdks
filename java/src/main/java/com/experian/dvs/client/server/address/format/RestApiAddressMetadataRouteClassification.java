package com.experian.dvs.client.server.address.format;

import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressMetadataRouteClassification {

    @JsonProperty("carrier_route")
    private String carrierRoute;

    @JsonProperty("id")
    private String id;

    @JsonProperty("elot")
    private String elot;

    public String getCarrierRoute() {
        return carrierRoute;
    }

    public void setCarrierRoute(String carrierRoute) {
        this.carrierRoute = carrierRoute;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getElot() {
        return elot;
    }

    public void setElot(String elot) {
        this.elot = elot;
    }
}
