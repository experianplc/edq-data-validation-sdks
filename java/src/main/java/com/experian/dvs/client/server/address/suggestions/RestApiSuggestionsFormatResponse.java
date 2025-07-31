package com.experian.dvs.client.server.address.suggestions;

import com.experian.dvs.client.server.RestApiResponse;
import com.experian.dvs.client.server.RestApiResponseError;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiSuggestionsFormatResponse extends RestApiResponse {
    @JsonProperty("error")
    private RestApiResponseError error;

    @JsonProperty("result")
    private RestApiSuggestionsFormatResult result;

    public RestApiResponseError getError() {
        return error;
    }

    public void setError(RestApiResponseError error) {
        this.error = error;
    }

    public RestApiSuggestionsFormatResult getResult() {
        return result;
    }

    public void setResult(RestApiSuggestionsFormatResult result) {
        this.result = result;
    }
}
