package com.experian.dvs.client.address.search;

import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.server.RestApiResponseError;
import com.experian.dvs.client.server.address.search.RestApiAddressSearchResponse;

import java.util.Optional;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

public class ResultFuture implements Future<Result> {

    private final Future<RestApiAddressSearchResponse> apiFuture;

    public ResultFuture(Future<RestApiAddressSearchResponse> apiFuture) {
        this.apiFuture = apiFuture;
    }

    @Override
    public boolean cancel(boolean mayInterruptIfRunning) {
        return this.apiFuture.cancel(mayInterruptIfRunning);
    }

    @Override
    public boolean isCancelled() {
        return this.apiFuture.isCancelled();
    }

    @Override
    public boolean isDone() {
        return this.apiFuture.isDone();
    }

    @Override
    public Result get() throws InterruptedException, ExecutionException {
        final RestApiAddressSearchResponse apiSearchResponse = this.apiFuture.get();
        final Optional<RestApiResponseError> optError = apiSearchResponse.getError();
        if (optError.isPresent()) {
          throw EDVSException.using(optError.get());
        }
        return new Result(apiSearchResponse);
    }

    @Override
    public Result get(long timeout, TimeUnit unit) throws InterruptedException, ExecutionException, TimeoutException {
        final RestApiAddressSearchResponse apiSearchResponse = this.apiFuture.get(timeout, unit);
        final Optional<RestApiResponseError> optError = apiSearchResponse.getError();
        if (optError.isPresent()) {
            throw EDVSException.using(optError.get());
        }
        return new Result(apiSearchResponse);
    }
}
