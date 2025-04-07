package com.experian.dvs.client.server.phone;

import com.experian.dvs.client.server.RestApiResponseError;
import com.fasterxml.jackson.annotation.JsonProperty;

public class RestApiPhoneValidateResponse {

    @JsonProperty("error")
    private RestApiResponseError error;
    @JsonProperty("result")
    private RestApiPhoneValidateResult result;
    @JsonProperty("metadata")
    private RestApiPhoneValidateMetadata metadata;


    public RestApiResponseError getError() {
        return error;
    }

    public void setError(RestApiResponseError error) {
        this.error = error;
    }

    public RestApiPhoneValidateResult getResult() {
        return result;
    }

    public void setResult(RestApiPhoneValidateResult result) {
        this.result = result;
    }

    public RestApiPhoneValidateMetadata getMetadata() {
        return metadata;
    }

    public void setMetadata(RestApiPhoneValidateMetadata metadata) {
        this.metadata = metadata;
    }
}
