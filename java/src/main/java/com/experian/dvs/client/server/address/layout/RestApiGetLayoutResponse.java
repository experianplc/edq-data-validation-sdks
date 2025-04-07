package com.experian.dvs.client.server.address.layout;

import com.experian.dvs.client.server.RestApiResponseError;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiGetLayoutResponse {

    @JsonProperty("error")
    private RestApiResponseError error;

    @JsonProperty("result")
    private RestApiGetLayoutResult result;

    public RestApiResponseError getError() {
        return error;
    }

    public void setError(RestApiResponseError error) {
        this.error = error;
    }

    public RestApiGetLayoutResult getResult() {
        return result;
    }

    public void setResult(RestApiGetLayoutResult result) {
        this.result = result;
    }
}
