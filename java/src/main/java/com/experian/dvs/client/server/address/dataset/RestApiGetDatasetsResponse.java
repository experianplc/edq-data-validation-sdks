package com.experian.dvs.client.server.address.dataset;

import com.experian.dvs.client.server.RestApiResponseError;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiGetDatasetsResponse {

    @JsonProperty("error")
    private RestApiResponseError error;
    @JsonProperty("result")
    private List<RestApiAddressDatasetResult> result;


    public RestApiResponseError getError() {
        return error;
    }

    public void setError(RestApiResponseError error) {
        this.error = error;
    }

    public List<RestApiAddressDatasetResult> getResult() {
        return result;
    }

    public void setResult(List<RestApiAddressDatasetResult> result) {
        this.result = result;
    }
}
