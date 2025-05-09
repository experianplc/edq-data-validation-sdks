package com.experian.dvs.client.address.validate;

import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.server.address.validate.RestApiAddressValidateResponse;

import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

public class ValidateResultFuture implements Future<ValidateResult> {

    private final Future<RestApiAddressValidateResponse> apiFuture;

    public ValidateResultFuture(Future<RestApiAddressValidateResponse> apiFuture) {
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
    public ValidateResult get() throws InterruptedException, ExecutionException {
        final RestApiAddressValidateResponse response = this.apiFuture.get();
        if (response.getError() != null) {
            throw EDVSException.using(response.getError());
        }
        return new ValidateResult(response);
    }

    @Override
    public ValidateResult get(long timeout, TimeUnit unit) throws InterruptedException, ExecutionException, TimeoutException {
        final RestApiAddressValidateResponse response = this.apiFuture.get(timeout, unit);
        if (response.getError() != null) {
            throw EDVSException.using(response.getError());
        }
        return new ValidateResult(response);
    }
}
