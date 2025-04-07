package com.experian.dvs.client.exceptions;

import com.experian.dvs.client.server.RestApiResponseError;

public class UnauthorizedException extends EDVSException {

    public UnauthorizedException(final RestApiResponseError responseError) {
        super(responseError.getDetail());
    }

}
