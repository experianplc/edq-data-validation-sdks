package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.common.ResponseError;
import com.experian.dvs.client.server.address.layout.RestApiGetLayoutListResponse;

import java.util.List;
import java.util.Optional;

public class GetLayoutListResult {

    private final ResponseError error;
    private final List<GetLayoutListItem> layouts;
    private final String referenceId;

    public GetLayoutListResult(final RestApiGetLayoutListResponse response) {
        this.error = response.getError() != null ? new ResponseError(response.getError()) : null;
        this.layouts = response.getResult() != null ? response.getResult().stream().map(GetLayoutListItem::new).toList() : List.of();
        this.referenceId = response.getReferenceId();
    }

    public Optional<ResponseError> getError() {
        return Optional.ofNullable(error);
    }

    public List<GetLayoutListItem> getLayouts() {
        return layouts;
    }

    public String getReferenceId() {
        return referenceId;
    }
}
