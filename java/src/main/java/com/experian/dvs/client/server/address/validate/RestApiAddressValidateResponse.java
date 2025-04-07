package com.experian.dvs.client.server.address.validate;

import com.experian.dvs.client.server.RestApiResponseError;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatEnrichment;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatMetadata;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressValidateResponse {

    @JsonProperty("error")
    private RestApiResponseError error;

    @JsonProperty("result")
    private RestApiAddressValidateResult result;

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

    public RestApiAddressValidateResult getResult() {
        return result;
    }

    public void setResult(RestApiAddressValidateResult result) {
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
