package com.experian.dvs.client.server.email;

import com.experian.dvs.client.server.RestApiResponseError;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiEmailValidateResponse {

    @JsonProperty("error")
    private RestApiResponseError error;

    @JsonProperty("result")
    private RestApiEmailValidateResult result;

    @JsonProperty("metadata")
    private RestApiEmailMetadata metadata;

    public RestApiResponseError getError() {
        return error;
    }

    public void setError(RestApiResponseError error) {
        this.error = error;
    }

    public RestApiEmailValidateResult getResult() {
        return result;
    }

    public void setResult(RestApiEmailValidateResult result) {
        this.result = result;
    }

    public RestApiEmailMetadata getMetadata() {
        return metadata;
    }

    public void setMetadata(RestApiEmailMetadata metadata) {
        this.metadata = metadata;
    }
}
