package com.experian.dvs.client.exceptions;

import com.experian.dvs.client.server.RestApiResponseError;

public class EDVSException extends RuntimeException {

    public EDVSException(final Throwable t) {
        super(t);
    }

    public EDVSException(final String message) {
        super(message);
    }

    public EDVSException(final String message, final Throwable cause) {
        super(message, cause);
    }

    public static EDVSException using(final RestApiResponseError responseError) {

        if (responseError.getTitle().equals("Unauthorized")) {
            return new UnauthorizedException(responseError);
        }
        if (responseError.getTitle().equals("Not Found")) {
            return new NotFoundException(responseError.getDetail());
        }
        return new EDVSException(responseError.getDetail());
    }
}
