package com.experian.dvs.client.email;

import com.experian.dvs.client.email.validate.ValidateResult;
import com.experian.dvs.client.email.validate.ValidateResultFuture;
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
 * AddressClient class for interacting with the email-related APIs.
 * Provides methods for validating email addresses.
 */
public class EmailClient implements Closeable {

    private final EmailConfiguration configuration;
    private final RestApiAsyncStub restApiAsyncStub;

    /**
     * Initializes a new instance of the {@link EmailClient} class with the specified configuration.
     *
     * @param configuration The configuration settings for the client.
     */
    public EmailClient(EmailConfiguration configuration) {
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
    public ValidateResult validate(final String email) {
        return validate(email, "");
    }

    /**
     * Validates an email address synchronously.
     *
     * @param email         The email address to validate.
     * @param referenceId   The reference ID for tracking the request.
     * @return The validation result.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public ValidateResult validate(final String email, final String referenceId) {
        try {
            return this.validateAsync(email, referenceId).get();
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
    public Future<ValidateResult> validateAsync(final String email) {
        return validateImpl(email, "");
    }

    /**
     * Validates an email address asynchronously.
     *
     * @param email         The email address to validate.
     * @param referenceId   The reference ID for tracking the request.
     * @return A future representing the asynchronous operation.
     */
    public Future<ValidateResult> validateAsync(final String email, final String referenceId) {
        return validateImpl(email, referenceId);
    }

    private Future<ValidateResult> validateImpl(final String email, final String referenceId) {
        RestApiEmailValidateRequest request = RestApiEmailValidateRequest.using(configuration);
        request.setEmail(email);
        final Map<String, Object> headers = this.configuration.getCommonHeaders(referenceId);

        final Future<RestApiEmailValidateResponse> response = this.restApiAsyncStub.validateEmailV2(request, headers);
        return new ValidateResultFuture(response);
    }
}

