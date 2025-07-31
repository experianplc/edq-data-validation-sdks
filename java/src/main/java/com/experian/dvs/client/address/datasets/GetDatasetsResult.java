package com.experian.dvs.client.address.datasets;

import com.experian.dvs.client.server.address.dataset.RestApiGetDatasetsResponse;

import java.util.List;

public class GetDatasetsResult {

    private final List<AddressDataset> result;
    private final String referenceId;

    public GetDatasetsResult(final RestApiGetDatasetsResponse response) {
        final var res = response.getResult();
        if (res != null) {
            this.result = response.getResult().stream().map(AddressDataset::new).toList();
        } else {
            this.result = null;
        }

        this.referenceId = response.getReferenceId();
    }

    public List<AddressDataset> getResult() {
        return result;
    }

    public String getReferenceId() {
        return referenceId;
    }
}
