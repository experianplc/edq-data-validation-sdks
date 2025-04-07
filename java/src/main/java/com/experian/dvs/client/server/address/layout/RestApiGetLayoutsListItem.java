package com.experian.dvs.client.server.address.layout;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiGetLayoutsListItem {

    @JsonProperty("id")
    private String id;
    @JsonProperty("name")
    private String name;
    @JsonProperty("applies_to")
    private List<RestApiAddressLayoutAppliesTo> appliesTo;
    @JsonProperty("status")
    private String status;

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

    public List<RestApiAddressLayoutAppliesTo> getAppliesTo() {
        return appliesTo;
    }

    public void setAppliesTo(List<RestApiAddressLayoutAppliesTo> appliesTo) {
        this.appliesTo = appliesTo;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }
}
