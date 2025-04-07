package com.experian.dvs.client.server.address.format;

import com.experian.dvs.client.server.RestApiResponseError;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
public class RestApiAddressFormatResponse {

    @JsonProperty("error")
    private RestApiResponseError error;

    @JsonProperty("result")
    private RestApiFormatResult result;

    @JsonProperty("metadata")
    private RestApiAddressFormatMetadata metadata;

    @JsonProperty("enrichment")
    private RestApiAddressFormatEnrichment enrichment;


    public RestApiResponseError getError() {
        return error;
    }

    public void setError(RestApiResponseError error) {
        this.error = error;
    }

    public RestApiFormatResult getResult() {
        return result;
    }

    public void setResult(RestApiFormatResult result) {
        this.result = result;
    }

    public RestApiAddressFormatMetadata getMetadata() {
        return metadata;
    }

    public void setMetadata(RestApiAddressFormatMetadata metadata) {
        this.metadata = metadata;
    }

    public RestApiAddressFormatEnrichment getEnrichment() {
        return enrichment;
    }

    public void setEnrichment(RestApiAddressFormatEnrichment enrichment) {
        this.enrichment = enrichment;
    }
}
