package com.experian.dvs.client.common;

import com.experian.dvs.client.exceptions.InvalidConfigurationException;

import java.net.URI;
import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

public abstract class Configuration {

    private static final URI SERVER_URI = URI.create("https://api.experianaperture.io/");
    public static final int DEFAULT_TIMEOUT_SECONDS = 15;
    private final String token;
    private final String transactionId;
    private final boolean useXAppAuthentication;
    private final int timeoutInSeconds;

    protected Configuration(Builder builder) {
        this.token = builder.token;
        this.transactionId = builder.transactionId;
        this.useXAppAuthentication = builder.useXAppAuthentication;
        this.timeoutInSeconds = builder.timeoutInSeconds;
    }

    public String getToken() {
        return token;
    }
    public URI getServerUri() {
        return SERVER_URI;
    }
    public String getTransactionId() { return transactionId; }

    public int getTimeoutInSeconds() {
        return this.timeoutInSeconds;
    }

    public boolean isUseXAppAuthentication() {
        return useXAppAuthentication;
    }

    public Map<String, Object> getCommonHeaders() {
        return getCommonHeaders(Boolean.FALSE);
    }

    public Map<String, Object> getCommonHeaders(boolean allowsDotInReferenceId) {

        final Map<String, Object> headers = new HashMap<>();

        if (isUseXAppAuthentication()) {
            headers.put("x-app-key", getToken());
        }
        else {
            headers.put("Auth-Token", getToken());
        }

        String currentTransactionId = getTransactionId();
        if (currentTransactionId == null || currentTransactionId.isBlank())
        {
            currentTransactionId = createTransactionId();
        }
        headers.put("Reference-Id", ClientReference.getReference(currentTransactionId, allowsDotInReferenceId));

        if (getTimeoutInSeconds() != com.experian.dvs.client.address.Configuration.DEFAULT_TIMEOUT_SECONDS) {
            headers.put("Timeout-Seconds", Integer.toString(getTimeoutInSeconds()));
        }

        return headers;
    }

    private String createTransactionId() {
        return UUID.randomUUID().toString();
    }

    public abstract static class Builder {

        private final String token;
        private String transactionId;
        private boolean useXAppAuthentication;
        private int timeoutInSeconds = DEFAULT_TIMEOUT_SECONDS;

        protected Builder(String token) {
            if (token == null || token.isBlank()) {
                throw new InvalidConfigurationException("The supplied configuration must contain an authorisation token");
            }
            this.token = token;
        }

        public abstract Configuration build();

        public Builder setUseXAppAuthentication(boolean useXAppAuthentication) {
            this.useXAppAuthentication = useXAppAuthentication;
            return this;
        }

        public Builder setTimeoutSeconds(int timeout) {
            this.timeoutInSeconds = timeout;
            return this;
        }

        public Builder setTransactionId(String transactionId) {
            this.transactionId = transactionId;
            return this;
        }

    }

}
