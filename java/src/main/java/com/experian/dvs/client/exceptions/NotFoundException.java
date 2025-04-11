package com.experian.dvs.client.exceptions;

/**
 * Represents an exception that is thrown when a requested resource is not found in the DVSClient.
 */
public class NotFoundException extends EDVSException {

    /**
     * Initializes a new instance of the {@link NotFoundException} class with a specified error message.
     *
     * @param message The error message that explains the reason for the exception.
     */
    public NotFoundException(String message) {
        super(message);
    }
}


