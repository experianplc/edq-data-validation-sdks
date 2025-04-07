package com.experian.dvs.client.server.address.layout;

import com.experian.dvs.client.server.RestApiResponseError;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class RestApiGetLayoutListResponse {

    @JsonProperty("error")
    private RestApiResponseError error;

    @JsonProperty("result")
    private List<RestApiGetLayoutsListItem> result;

    public RestApiResponseError getError() {
        return error;
    }

    public void setError(RestApiResponseError error) {
        this.error = error;
    }

    public List<RestApiGetLayoutsListItem> getResult() {
        return result;
    }

    public void setResult(List<RestApiGetLayoutsListItem> result) {
        this.result = result;
    }
}
