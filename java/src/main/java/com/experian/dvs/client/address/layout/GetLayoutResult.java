package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.common.ResponseError;
import com.experian.dvs.client.server.address.layout.RestApiGetLayoutResponse;
import com.experian.dvs.client.server.address.layout.RestApiGetLayoutResult;

import java.util.Optional;

public class GetLayoutResult {

    private final ResponseError error;
    private final GetLayoutLayout layout;
    private final String referenceId;

    public GetLayoutResult(final RestApiGetLayoutResponse response) {
        this.error = response.getError() != null ? new ResponseError(response.getError()) : null;
        final RestApiGetLayoutResult result = response.getResult();
        if (result.getLayout() != null) {
            this.layout = new GetLayoutLayout(result.getLayout());
        } else {
            this.layout = null;
        }
        this.referenceId = response.getReferenceId();
    }

    public Optional<ResponseError> getError() {
        return Optional.ofNullable(error);
    }

    public GetLayoutLayout getLayout() {
        return layout;
    }

    public String getReferenceId() {
        return referenceId;
    }
}
