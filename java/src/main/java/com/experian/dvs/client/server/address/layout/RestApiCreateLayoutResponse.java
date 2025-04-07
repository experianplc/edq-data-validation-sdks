package com.experian.dvs.client.server.address.layout;

import com.experian.dvs.client.server.RestApiResponseError;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiCreateLayoutResponse {

    @JsonProperty("error")
    private RestApiResponseError error;
    @JsonProperty("result")
    private RestApiCreateLayoutResult result;

    public RestApiCreateLayoutResult getResult() {
        return result;
    }

    public void setResult(RestApiCreateLayoutResult result) {
        this.result = result;
    }

    public RestApiResponseError getError() {
        return error;
    }

    public void setError(RestApiResponseError error) {
        this.error = error;
    }
}
