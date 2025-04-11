package com.experian.dvs.client.exceptions;

import com.experian.dvs.client.server.RestApiResponseError;

/**
 * Represents an exception that is thrown when a REST API call fails due to unauthorized access.
 */
public class UnauthorizedException extends EDVSException {

    /**
     * Initializes a new instance of the {@link UnauthorizedException} class with the details of the unauthorized error.
     *
     * @param responseError The error response from the REST API containing details about the unauthorized access.
     */
    public UnauthorizedException(final RestApiResponseError responseError) {
        super(responseError.getDetail());
    }
}

