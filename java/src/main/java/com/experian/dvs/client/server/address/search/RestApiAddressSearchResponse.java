package com.experian.dvs.client.server.address.search;

import com.experian.dvs.client.server.RestApiResponseError;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.Optional;

public class RestApiAddressSearchResponse {

    @JsonProperty("error")
    private RestApiResponseError error;

    @JsonProperty("result")
    private RestApiAddressSearchResult result;

    public Optional<RestApiResponseError> getError() {
        return Optional.ofNullable(error);
    }

    public void setError(RestApiResponseError error) {
        this.error = error;
    }

    public RestApiAddressSearchResult getResult() {
        return result;
    }

    public void setResult(RestApiAddressSearchResult result) {
        this.result = result;
    }
}
