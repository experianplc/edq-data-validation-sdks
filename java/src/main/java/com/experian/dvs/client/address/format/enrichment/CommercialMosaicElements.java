package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.server.address.format.RestApiCommercialMosaicElements;

import java.util.Objects;

public class CommercialMosaicElements {

    private final String groupTypeCode;
    private final String groupTypeDescription;
    private final String groupCode;
    private final String groupDescription;

    // Constructor
    public CommercialMosaicElements(RestApiCommercialMosaicElements api) {
        this.groupTypeCode = Objects.toString(api.getGroupTypeCode(), "");
        this.groupTypeDescription = Objects.toString(api.getGroupTypeDescription(), "");
        this.groupCode = Objects.toString(api.getGroupCode(), "");
        this.groupDescription = Objects.toString(api.getGroupDescription(), "");
    }

    // Getters
    public String getGroupTypeCode() {
        return groupTypeCode;
    }

    public String getGroupTypeDescription() {
        return groupTypeDescription;
    }

    public String getGroupCode() {
        return groupCode;
    }

    public String getGroupDescription() {
        return groupDescription;
    }
}