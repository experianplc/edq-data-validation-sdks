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

/**
 * Client class for interacting with the email-related APIs.
 * Provides methods for validating email addresses.
 */
public class Client implements Closeable {

    private final Configuration configuration;
    private final RestApiAsyncStub restApiAsyncStub;

    /**
     * Initializes a new instance of the {@link Client} class with the specified configuration.
     *
     * @param configuration The configuration settings for the client.
     */
    public Client(Configuration configuration) {
        this.configuration = configuration;
        this.restApiAsyncStub = new RestApiAsyncImpl(configuration);
    }

    /**
     * Closes the client and releases any resources held by it.
     *
     * @throws IOException If an I/O error occurs while closing the client.
     */
    @Override
    public void close() throws IOException {
        this.restApiAsyncStub.close();
    }

    /**
     * Validates an email address synchronously.
     *
     * @param email The email address to validate.
     * @return The validation result.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public com.experian.dvs.client.email.validate.Result validate(final String email) {
        try {
            return this.validateAsync(email).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Validates an email address asynchronously.
     *
     * @param email The email address to validate.
     * @return A future representing the asynchronous operation.
     */
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

