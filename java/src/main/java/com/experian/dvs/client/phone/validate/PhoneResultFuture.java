package com.experian.dvs.client.phone.validate;

import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateResponse;

import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

public class PhoneResultFuture implements Future<PhoneResult> {

    private final Future<RestApiPhoneValidateResponse> apiFuture;

    public PhoneResultFuture(Future<RestApiPhoneValidateResponse> apiFuture) {
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
    public PhoneResult get() throws InterruptedException, ExecutionException {
        final RestApiPhoneValidateResponse response = this.apiFuture.get();
        if (response.getError() != null) {
            throw EDVSException.using(response.getError());
        }
        return new PhoneResult(response);
    }

    @Override
    public PhoneResult get(long timeout, TimeUnit unit) throws InterruptedException, ExecutionException, TimeoutException {
        final RestApiPhoneValidateResponse response = this.apiFuture.get(timeout, unit);
        if (response.getError() != null) {
            throw EDVSException.using(response.getError());
        }
        return new PhoneResult(response);
    }
}
