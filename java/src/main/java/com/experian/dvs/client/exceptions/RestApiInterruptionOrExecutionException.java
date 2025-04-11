package com.experian.dvs.client.exceptions;

/**
 * Represents an exception that is thrown when a REST API call is interrupted or fails during execution.
 */
public class RestApiInterruptionOrExecutionException extends EDVSException {

    /**
     * Initializes a new instance of the {@link RestApiInterruptionOrExecutionException} class with a reference to the exception that caused the error.
     *
     * @param e The exception that caused the REST API interruption or execution failure.
     */
    public RestApiInterruptionOrExecutionException(Exception e) {
        super(e);
    }
}

