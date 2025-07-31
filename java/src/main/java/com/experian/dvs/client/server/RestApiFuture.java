package com.experian.dvs.client.server;

import jakarta.ws.rs.core.Response;

import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

public class RestApiFuture<T extends RestApiResponse> implements Future<T> {

    private final Class<T> clazz;
    private final Future<Response> responseFuture;

    public RestApiFuture(Class<T> clazz, Future<Response> responseFuture) {
        this.clazz = clazz;
        this.responseFuture = responseFuture;
    }

    @Override
    public boolean cancel(boolean mayInterruptIfRunning) {
        return this.responseFuture.cancel(mayInterruptIfRunning);
    }

    @Override
    public boolean isCancelled() {
        return this.responseFuture.isCancelled();
    }

    @Override
    public boolean isDone() {
        return this.responseFuture.isDone();
    }

    @Override
    public T get() throws InterruptedException, ExecutionException {
        try (final Response apiResponse = this.responseFuture.get()) {
            T response = apiResponse.readEntity(this.clazz);
            response.setReferenceId(getRefIdFromHeaderValue(apiResponse.getHeaderString("Reference-Id")));
            return response;
        }
    }

    @Override
    public T get(long timeout, TimeUnit unit) throws InterruptedException, ExecutionException, TimeoutException {
        try (final Response apiResponse = this.responseFuture.get(timeout, unit)) {
            T response = apiResponse.readEntity(this.clazz);
            response.setReferenceId(getRefIdFromHeaderValue(apiResponse.getHeaderString("Reference-Id")));
            return response;
        }
    }

    private String getRefIdFromHeaderValue(String referenceId)
    {
        final String pattern = "/transaction:";
        if (referenceId.contains(pattern))
        {
            referenceId = referenceId.substring(referenceId.lastIndexOf(pattern)+ pattern.length());
        }

        return referenceId;
    }
}
