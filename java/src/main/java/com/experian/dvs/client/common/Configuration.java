package com.experian.dvs.client.common;

import com.experian.dvs.client.exceptions.InvalidConfigurationException;

import java.net.URI;
import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

/**
 * Abstract base class for configuring API clients.
 * Provides common configuration options and utility methods for API requests.
 */
public abstract class Configuration {

    private static final URI SERVER_URI = URI.create("https://api.experianaperture.io/");
    public static final int DEFAULT_TIMEOUT_SECONDS = 15;
    private final String token;
    private final String transactionId;
    private final boolean useXAppAuthentication;
    private final int timeoutInSeconds;

    /**
     * Initializes a new instance of the {@link Configuration} class using the specified builder.
     *
     * @param builder The builder containing the configuration settings.
     */
    protected Configuration(Builder builder) {
        this.token = builder.token;
        this.transactionId = builder.transactionId;
        this.useXAppAuthentication = builder.useXAppAuthentication;
        this.timeoutInSeconds = builder.timeoutInSeconds;
    }

    /**
     * Retrieves the authentication token for the API.
     *
     * @return The authentication token as a string.
     */
    public String getToken() {
        return token;
    }

    /**
     * Retrieves the server URI for the API.
     *
     * @return The server URI as a {@link URI} object.
     */
    public URI getServerUri() {
        return SERVER_URI;
    }

    /**
     * Retrieves the transaction ID for the current configuration.
     *
     * @return The transaction ID as a string.
     */
    public String getTransactionId() {
        return transactionId;
    }

    /**
     * Retrieves the timeout value in seconds for API requests.
     *
     * @return The timeout value in seconds.
     */
    public int getTimeoutInSeconds() {
        return this.timeoutInSeconds;
    }

    /**
     * Indicates whether x-app-key header is enabled for the configuration.
     *
     * @return True if x-app-key header authentication is enabled; otherwise, false.
     */
    public boolean isUseXAppAuthentication() {
        return useXAppAuthentication;
    }

    /**
     * Retrieves common headers for API requests.
     *
     * @return A map of headers to include in the API request.
     */
    public Map<String, Object> getCommonHeaders() {
        return getCommonHeaders(Boolean.FALSE);
    }

    /**
     * Retrieves common headers for API requests with an option to allow dots in the reference ID.
     *
     * @param allowsDotInReferenceId Indicates whether dots are allowed in the reference ID.
     * @return A map of headers to include in the API request.
     */
    public Map<String, Object> getCommonHeaders(boolean allowsDotInReferenceId) {
        final Map<String, Object> headers = new HashMap<>();

        if (isUseXAppAuthentication()) {
            headers.put("x-app-key", getToken());
        } else {
            headers.put("Auth-Token", getToken());
        }

        String currentTransactionId = getTransactionId();
        if (currentTransactionId == null || currentTransactionId.isBlank()) {
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

    /**
     * Abstract builder class for constructing a {@link Configuration} object with custom settings.
     */
    public abstract static class Builder {

        private final String token;
        private String transactionId;
        private boolean useXAppAuthentication;
        private int timeoutInSeconds = DEFAULT_TIMEOUT_SECONDS;

        /**
         * Initializes a new instance of the {@link Builder} class with the specified token.
         *
         * @param token The authentication token for the API.
         * @throws InvalidConfigurationException If the token is null or empty.
         */
        protected Builder(String token) {
            if (token == null || token.isBlank()) {
                throw new InvalidConfigurationException("The supplied configuration must contain an authorisation token");
            }
            this.token = token;
        }

        /**
         * Builds the {@link Configuration} object with the specified settings.
         *
         * @return A new instance of the {@link Configuration} class.
         */
        public abstract Configuration build();

        /**
         * Enables or disables x-app-key header auhentication for the configuration.
         *
         * @param useXAppAuthentication True to enable x-app-key header auhentication; otherwise, false.
         * @return The current {@link Builder} instance for method chaining.
         */
        public Builder setUseXAppAuthentication(boolean useXAppAuthentication) {
            this.useXAppAuthentication = useXAppAuthentication;
            return this;
        }

        /**
         * Sets the timeout value in seconds for API requests.
         *
         * @param timeout The timeout value in seconds.
         * @return The current {@link Builder} instance for method chaining.
         */
        public Builder setTimeoutSeconds(int timeout) {
            this.timeoutInSeconds = timeout;
            return this;
        }

        /**
         * Sets the transaction ID for the configuration.
         *
         * @param transactionId The transaction ID to use.
         * @return The current {@link Builder} instance for method chaining.
         */
        public Builder setTransactionId(String transactionId) {
            this.transactionId = transactionId;
            return this;
        }
    }
}
