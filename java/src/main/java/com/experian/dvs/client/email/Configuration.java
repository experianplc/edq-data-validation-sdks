package com.experian.dvs.client.email;

/**
 * Configuration class for setting up the email client.
 * Provides options for customizing email-related API requests.
 */
public class Configuration extends com.experian.dvs.client.common.Configuration {

    private final boolean metadata;

    /**
     * Initializes a new instance of the {@link Configuration} class using the specified builder.
     *
     * @param builder The builder containing the configuration settings.
     */
    protected Configuration(Builder builder) {
        super(builder);
        this.metadata = builder.metadata;
    }

    /**
     * Creates a new instance of the {@link Builder} class to configure the email client.
     *
     * @param token The authentication token for the API.
     * @return A new instance of the {@link Builder} class.
     */
    public static Builder newBuilder(String token) {
        return new Builder(token);
    }

    /**
     * Retrieves the metadata inclusion setting for the configuration.
     *
     * @return True if metadata is included; otherwise, false.
     */
    public boolean getMetadata() {
        return metadata;
    }

    /**
     * Builder class for constructing a {@link Configuration} object with custom settings.
     */
    public static class Builder extends com.experian.dvs.client.common.Configuration.Builder {

        private boolean metadata;

        /**
         * Initializes a new instance of the {@link Builder} class with the specified token.
         *
         * @param token The authentication token for the API.
         */
        public Builder(String token) {
            super(token);
        }

        /**
         * Builds the {@link Configuration} object with the specified settings.
         *
         * @return A new instance of the {@link Configuration} class.
         */
        public Configuration build() {
            return new Configuration(this);
        }

        /**
         * Includes metadata in the API response.
         *
         * @return The current {@link Builder} instance for method chaining.
         */
        public Builder includeMetadata() {
            this.metadata = true;
            return this;
        }

        /**
         * Sets a custom transaction ID for API requests.
         *
         * @param transactionId The transaction ID to use.
         * @return The current {@link Builder} instance for method chaining.
         */
        public Builder setTransactionId(String transactionId) {
            super.setTransactionId(transactionId);
            return this;
        }
    }
}