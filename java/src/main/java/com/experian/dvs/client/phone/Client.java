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

public class Client {

    private final Configuration configuration;
    private final RestApiAsyncStub restApiAsyncStub;

    public Client(Configuration configuration) {
        this.configuration = configuration;
        this.restApiAsyncStub = new RestApiAsyncImpl(configuration);
    }

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
