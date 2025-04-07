package com.experian.dvs.client.email;

import com.experian.dvs.client.exceptions.RestApiInterruptionOrExecutionException;
import com.experian.dvs.client.server.RestApiAsyncImpl;
import com.experian.dvs.client.server.RestApiAsyncStub;
import com.experian.dvs.client.server.email.RestApiEmailValidateRequest;
import com.experian.dvs.client.server.email.RestApiEmailValidateResponse;

import java.io.Closeable;
import java.io.IOException;
import java.util.Map;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;

public class Client implements Closeable {

    private final Configuration configuration;
    private final RestApiAsyncStub restApiAsyncStub;


    public Client(Configuration configuration) {
        this.configuration = configuration;
        this.restApiAsyncStub = new RestApiAsyncImpl(configuration);
    }

    @Override
    public void close() throws IOException {
        this.restApiAsyncStub.close();
    }

    public com.experian.dvs.client.email.validate.Result validate(final String email) {
        try {
            return this.validateAsync(email).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    public Future<com.experian.dvs.client.email.validate.Result> validateAsync(final String email) {
        return validateImpl(email);
    }

    private Future<com.experian.dvs.client.email.validate.Result> validateImpl(final String email) {
        RestApiEmailValidateRequest request = RestApiEmailValidateRequest.using(configuration);
        request.setEmail(email);
        final Map<String, Object> headers = this.configuration.getCommonHeaders();

        final Future<RestApiEmailValidateResponse> response = this.restApiAsyncStub.validateEmailV2(request, headers);
        return new com.experian.dvs.client.email.validate.ResultFuture(response);
    }
}
