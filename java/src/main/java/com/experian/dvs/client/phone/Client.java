package com.experian.dvs.client.phone;

import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.exceptions.RestApiInterruptionOrExecutionException;
import com.experian.dvs.client.phone.validate.Result;
import com.experian.dvs.client.server.RestApiAsyncImpl;
import com.experian.dvs.client.server.RestApiAsyncStub;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateRequest;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateResponse;

import java.util.Map;
import java.util.concurrent.ExecutionException;

/**
 * Client class for interacting with the phone-related APIs.
 * Provides methods for validating phone numbers.
 */
public class Client {

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
     * Validates a phone number synchronously.
     *
     * @param phoneNumber The phone number to validate.
     * @return The validation result.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     * @throws EDVSException If the API response contains an error.
     */
    public Result validate(String phoneNumber) {
        final RestApiPhoneValidateRequest request = RestApiPhoneValidateRequest.using(configuration);
        request.setNumber(phoneNumber);
        final Map<String, Object> headers = this.configuration.getCommonHeaders();

        if (this.configuration.getMetadata()) {
            headers.put("Add-Metadata", Boolean.TRUE.toString());
        }

        try {
            final RestApiPhoneValidateResponse phoneValidateResponse = this.restApiAsyncStub.validatePhoneV2(request, headers).get();
            if (phoneValidateResponse.getError() != null) {
                throw EDVSException.using(phoneValidateResponse.getError());
            }
            return new Result(phoneValidateResponse);
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }
}

