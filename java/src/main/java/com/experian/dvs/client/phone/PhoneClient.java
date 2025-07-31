package com.experian.dvs.client.phone;

import com.experian.dvs.client.exceptions.RestApiInterruptionOrExecutionException;
import com.experian.dvs.client.phone.validate.PhoneResult;
import com.experian.dvs.client.phone.validate.PhoneResultFuture;
import com.experian.dvs.client.server.RestApiAsyncImpl;
import com.experian.dvs.client.server.RestApiAsyncStub;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateRequest;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateResponse;

import java.io.Closeable;
import java.io.IOException;
import java.util.Map;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.Future;

/**
 * AddressClient class for interacting with the phone-related APIs.
 * Provides methods for validating phone numbers.
 */
public class PhoneClient implements Closeable {

    private final PhoneConfiguration configuration;
    private final RestApiAsyncStub restApiAsyncStub;

    /**
     * Initializes a new instance of the {@link PhoneClient} class with the specified configuration.
     *
     * @param configuration The configuration settings for the client.
     */
    public PhoneClient(PhoneConfiguration configuration) {
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
     * Validates an phone number synchronously.
     *
     * @param phoneNumber The email address to validate.
     * @return The validation result.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public PhoneResult validate(final String phoneNumber) {
        return validate(phoneNumber, "");
    }

    /**
     * Validates an email address synchronously.
     *
     * @param phoneNumber The email address to validate.
     * @param referenceId The reference ID for tracking the request.
     * @return The validation result.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     */
    public PhoneResult validate(final String phoneNumber, final String referenceId) {
        try {
            return this.validateAsync(phoneNumber, referenceId).get();
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }

    /**
     * Validates an email address asynchronously.
     *
     * @param phoneNumber The email address to validate.
     * @return A future representing the asynchronous operation.
     */
    public Future<PhoneResult> validateAsync(final String phoneNumber) {
        return validateImpl(phoneNumber, "");
    }

    /**
     * Validates an email address asynchronously.
     *
     * @param phoneNumber The email address to validate.
     * @param referenceId The reference ID for tracking the request.
     * @return A future representing the asynchronous operation.
     */
    public Future<PhoneResult> validateAsync(final String phoneNumber, final String referenceId) {
        return validateImpl(phoneNumber, referenceId);
    }

    private Future<PhoneResult> validateImpl(final String phoneNumber, final String referenceId) {
        RestApiPhoneValidateRequest request = RestApiPhoneValidateRequest.using(configuration);
        request.setNumber(phoneNumber);
        final Map<String, Object> headers = this.configuration.getCommonHeaders(referenceId);

        if (this.configuration.getMetadata()) {
            headers.put("Add-Metadata", Boolean.TRUE.toString());
        }

        final Future<RestApiPhoneValidateResponse> response = this.restApiAsyncStub.validatePhoneV2(request, headers);
        return new PhoneResultFuture(response);
    }
}

