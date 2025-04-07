package com.experian.dvs.client.server;

import jakarta.ws.rs.core.Response;

import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.TimeoutException;

public class RestApiFuture<T> implements Future<T> {

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
        try (final Response response = this.responseFuture.get()) {
            return response.readEntity(this.clazz);
        }
    }

    @Override
    public T get(long timeout, TimeUnit unit) throws InterruptedException, ExecutionException, TimeoutException {
        try (final Response response = this.responseFuture.get(timeout, unit)) {
            return response.readEntity(this.clazz);
        }
    }
}
