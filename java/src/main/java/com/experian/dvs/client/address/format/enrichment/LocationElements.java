package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.server.address.format.RestApiEnrichmentLocationElements;

import java.util.Objects;

public class LocationElements {

    private final String code;
    private final String description;
    private final String smallOrHomeOffice;

    // Constructor
    public LocationElements(RestApiEnrichmentLocationElements api) {
        this.code = Objects.toString(api.getCode(), "");
        this.description = Objects.toString(api.getDescription(), "");
        this.smallOrHomeOffice = Objects.toString(api.getSmallOrHomeOffice(), "");
    }

    // Getters
    public String getCode() {
        return code;
    }

    public String getDescription() {
        return description;
    }

    public String getSmallOrHomeOffice() {
        return smallOrHomeOffice;
    }
}
