package com.experian.dvs.client.exceptions;

public class RestApiInterruptionOrExecutionException extends EDVSException {
    public RestApiInterruptionOrExecutionException(Exception e) {
        super(e);
    }
}
