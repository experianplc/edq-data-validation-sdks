package com.experian.dvs.client.server;

import jakarta.ws.rs.core.Response;

import java.util.Optional;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

public class RestApiResponseErrorFuture implements Future<Optional<RestApiResponseError>> {

    private final Future<Response> responseFuture;

    public RestApiResponseErrorFuture(Future<Response> responseFuture) {
        this.responseFuture = responseFuture;
    }

    @Override
    public boolean cancel(boolean mayInterruptIfRunning) {
        return false;
    }

    @Override
    public boolean isCancelled() {
        return false;
    }

    @Override
    public boolean isDone() {
        return false;
    }

    @Override
    public Optional<RestApiResponseError> get() throws InterruptedException, ExecutionException {
        try (Response response = this.responseFuture.get()) {
            return getOptionalError(response);
        }
    }

    @Override
    public Optional<RestApiResponseError> get(long timeout, TimeUnit unit) throws InterruptedException, ExecutionException, TimeoutException {
        try (Response response = this.responseFuture.get(timeout, unit)) {
            return getOptionalError(response);
        }
    }

    private Optional<RestApiResponseError> getOptionalError(final Response response) {
        if (response.getStatus() != Response.Status.ACCEPTED.getStatusCode()) {
            final RestApiResponseError error = new RestApiResponseError();
            error.setType(Integer.toString(response.getStatus()));
            error.setTitle(response.getStatusInfo().getReasonPhrase());
            return Optional.of(error);
        }
        return Optional.empty();
    }
}
