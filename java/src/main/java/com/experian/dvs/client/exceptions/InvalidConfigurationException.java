package com.experian.dvs.client.exceptions;

public class InvalidConfigurationException extends EDVSException {

    public InvalidConfigurationException(final String message) {
        super(message);
    }

    public InvalidConfigurationException(final String message, final Throwable cause) {
        super(message, cause);
    }
}
