package com.experian.dvs.client.address.format.enrichment;

import com.experian.dvs.client.server.address.format.RestApiEnrichmentMetadata;

import java.util.Objects;

public class Metadata {

    private final String code;
    private final String message;
    private final String detail;


    public Metadata(RestApiEnrichmentMetadata api) {
        this.code = Objects.toString(api.getCode(), "");
        this.message = Objects.toString(api.getMessage(), "");
        this.detail = Objects.toString(api.getDetail(), "");
    }
    public String getCode() {
        return code;
    }

    public String getMessage() {
        return message;
    }

    public String getDetail() {
        return detail;
    }
}
