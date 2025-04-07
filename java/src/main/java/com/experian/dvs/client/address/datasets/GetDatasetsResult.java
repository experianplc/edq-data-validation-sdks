package com.experian.dvs.client.address.datasets;

import com.experian.dvs.client.common.ResponseError;
import com.experian.dvs.client.server.address.dataset.RestApiGetDatasetsResponse;

import java.util.List;
import java.util.Optional;

public class GetDatasetsResult {

    private final List<AddressDataset> result;

    public GetDatasetsResult(final RestApiGetDatasetsResponse response) {
        final var res = response.getResult();
        if (res != null) {
            this.result = response.getResult().stream().map(AddressDataset::new).toList();
        } else {
            this.result = null;
        }
    }

    public List<AddressDataset> getResult() {
        return result;
    }
}
