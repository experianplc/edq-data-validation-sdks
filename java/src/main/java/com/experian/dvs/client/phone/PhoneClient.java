package com.experian.dvs.client.phone;

import com.experian.dvs.client.exceptions.EDVSException;
import com.experian.dvs.client.exceptions.RestApiInterruptionOrExecutionException;
import com.experian.dvs.client.phone.validate.PhoneResult;
import com.experian.dvs.client.server.RestApiAsyncImpl;
import com.experian.dvs.client.server.RestApiAsyncStub;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateRequest;
import com.experian.dvs.client.server.phone.RestApiPhoneValidateResponse;

import java.util.Map;
import java.util.concurrent.ExecutionException;

/**
 * AddressClient class for interacting with the phone-related APIs.
 * Provides methods for validating phone numbers.
 */
public class PhoneClient {

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
     * Validates a phone number synchronously.
     *
     * @param phoneNumber The phone number to validate.
     * @return The validation result.
     * @throws RestApiInterruptionOrExecutionException If the operation is interrupted or fails.
     * @throws EDVSException If the API response contains an error.
     */
    public PhoneResult validate(String phoneNumber) {
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
            return new PhoneResult(phoneValidateResponse);
        } catch (InterruptedException | ExecutionException e) {
            throw new RestApiInterruptionOrExecutionException(e);
        }
    }
}

