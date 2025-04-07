package com.experian.dvs.client.address.datasets;

import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.server.address.dataset.RestApiGetDatasetsResponse;

import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

public class GetDatasetsResultFuture implements Future<GetDatasetsResult> {

    private final Future<RestApiGetDatasetsResponse> apiResponse;

    public GetDatasetsResultFuture(Future<RestApiGetDatasetsResponse> apiResponse) {
        this.apiResponse = apiResponse;
    }

    @Override
    public boolean cancel(boolean mayInterruptIfRunning) {
        return this.apiResponse.cancel(mayInterruptIfRunning);
    }

    @Override
    public boolean isCancelled() {
        return this.apiResponse.isCancelled();
    }

    @Override
    public boolean isDone() {
        return this.apiResponse.isDone();
    }

    @Override
    public GetDatasetsResult get() throws InterruptedException, ExecutionException {
        final RestApiGetDatasetsResponse response = this.apiResponse.get();
        if (response.getError() != null) {
            throw EDVSException.using(response.getError());
        }
        return new GetDatasetsResult(response);
    }

    @Override
    public GetDatasetsResult get(long timeout, TimeUnit unit) throws InterruptedException, ExecutionException, TimeoutException {
        final RestApiGetDatasetsResponse response = this.apiResponse.get(timeout, unit);
        if (response.getError() != null) {
            throw EDVSException.using(response.getError());
        }
        return new GetDatasetsResult(response);
    }
}
