package com.experian.dvs.client.exceptions;

import com.experian.dvs.client.server.RestApiResponseError;

/**
 * Represents a custom exception for handling errors in the DVSClient.
 * Provides constructors for various error scenarios and a factory method for creating specific exceptions based on API response errors.
 */
public class EDVSException extends RuntimeException {

    /**
     * Initializes a new instance of the {@link EDVSException} class with a specified cause.
     *
     * @param t The throwable that caused this exception.
     */
    public EDVSException(final Throwable t) {
        super(t);
    }

    /**
     * Initializes a new instance of the {@link EDVSException} class with a specified error message.
     *
     * @param message The error message that explains the reason for the exception.
     */
    public EDVSException(final String message) {
        super(message);
    }

    /**
     * Initializes a new instance of the {@link EDVSException} class with a specified error message and a reference to the cause.
     *
     * @param message The error message that explains the reason for the exception.
     * @param cause   The throwable that caused this exception.
     */
    public EDVSException(final String message, final Throwable cause) {
        super(message, cause);
    }

    /**
     * Creates an appropriate exception based on the provided {@link RestApiResponseError}.
     *
     * @param responseError The error response from the REST API.
     * @return An instance of {@link EDVSException} or a derived exception type based on the error details.
     */
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
