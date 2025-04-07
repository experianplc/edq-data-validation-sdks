package com.experian.dvs.client.server.address.format;

import com.experian.dvs.client.server.RestApiResponseError;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiAddressFormatEnrichment {

    @JsonProperty("error")
    private RestApiResponseError error;

    @JsonProperty("transaction_id")
    private String transactionId;

    @JsonProperty("result")
    private RestApiEnrichmentResultAddress result;

    @JsonProperty("metadata")
    private RestApiEnrichmentMetadata metadata;


    public String getTransactionId() {
        return transactionId;
    }

    public void setTransactionId(String transactionId) {
        this.transactionId = transactionId;
    }

    public RestApiEnrichmentResultAddress getResult() {
        return result;
    }

    public void setResult(RestApiEnrichmentResultAddress result) {
        this.result = result;
    }

    public RestApiEnrichmentMetadata getMetadata() {
        return metadata;
    }

    public void setMetadata(RestApiEnrichmentMetadata metadata) {
        this.metadata = metadata;
    }

    public RestApiResponseError getError() {
        return error;
    }

    public void setError(RestApiResponseError error) {
        this.error = error;
    }
}
