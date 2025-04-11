package com.experian.dvs.client.exceptions;

/**
 * Represents an exception that is thrown when an invalid configuration is detected in the DVSClient.
 */
public class InvalidConfigurationException extends EDVSException {

    /**
     * Initializes a new instance of the {@link InvalidConfigurationException} class with a specified error message.
     *
     * @param message The error message that explains the reason for the exception.
     */
    public InvalidConfigurationException(final String message) {
        super(message);
    }

    /**
     * Initializes a new instance of the {@link InvalidConfigurationException} class with a specified error message and a reference to the cause.
     *
     * @param message The error message that explains the reason for the exception.
     * @param cause   The throwable that caused this exception.
     */
    public InvalidConfigurationException(final String message, final Throwable cause) {
        super(message, cause);
    }
}

