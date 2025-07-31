package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.common.ResponseError;
import com.experian.dvs.client.server.address.layout.RestApiCreateLayoutResponse;

import java.util.Optional;

public class CreateLayoutResult {

    private final ResponseError error;
    private final String id;
    private final String referenceId;

    public CreateLayoutResult(final RestApiCreateLayoutResponse response) {
        this.error = response.getError() != null ? new ResponseError(response.getError()) : null;
        this.id = response.getResult() != null ? response.getResult().getId() : "";
        this.referenceId = response.getReferenceId();
    }

    public Optional<ResponseError> getError() {
        return Optional.ofNullable(error);
    }

    public String getId() {
        return id;
    }

    public String getReferenceId() {
        return referenceId;
    }
}
