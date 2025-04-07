package com.experian.dvs.client.address.format;

import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.server.address.format.RestApiAddressFormatResponse;

import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

public class ResultFuture implements Future<Result> {

    private final Future<RestApiAddressFormatResponse> apiFuture;

    public ResultFuture(Future<RestApiAddressFormatResponse> apiFuture) {
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
        final RestApiAddressFormatResponse response = this.apiFuture.get();
        if (response.getError() != null) {
            throw EDVSException.using(response.getError());
        }
        return new Result(response);
    }

    @Override
    public Result get(long timeout, TimeUnit unit) throws InterruptedException, ExecutionException, TimeoutException {
        final RestApiAddressFormatResponse response = this.apiFuture.get(timeout, unit);
        if (response.getError() != null) {
            throw EDVSException.using(response.getError());
        }
        return new Result(response);
    }
}
