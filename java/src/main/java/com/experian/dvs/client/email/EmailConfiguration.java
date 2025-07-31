package com.experian.dvs.client.email;

/**
 * AddressConfiguration class for setting up the email client.
 * Provides options for customizing email-related API requests.
 */
public class EmailConfiguration extends com.experian.dvs.client.common.Configuration {

    private final boolean metadata;

    /**
     * Initializes a new instance of the {@link EmailConfiguration} class using the specified builder.
     *
     * @param builder The builder containing the configuration settings.
     */
    protected EmailConfiguration(EmailBuilder builder) {
        super(builder);
        this.metadata = builder.metadata;
    }

    /**
     * Creates a new instance of the {@link EmailBuilder} class to configure the email client.
     *
     * @param token The authentication token for the API.
     * @return A new instance of the {@link EmailBuilder} class.
     */
    public static EmailBuilder newBuilder(String token) {
        return new EmailBuilder(token);
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
     * AddressBuilder class for constructing a {@link EmailConfiguration} object with custom settings.
     */
    public static class EmailBuilder extends com.experian.dvs.client.common.Configuration.Builder {

        private boolean metadata;

        /**
         * Initializes a new instance of the {@link EmailBuilder} class with the specified token.
         *
         * @param token The authentication token for the API.
         */
        public EmailBuilder(String token) {
            super(token);
        }

        /**
         * Builds the {@link EmailConfiguration} object with the specified settings.
         *
         * @return A new instance of the {@link EmailConfiguration} class.
         */
        public EmailConfiguration build() {
            return new EmailConfiguration(this);
        }

        /**
         * Includes metadata in the API response.
         *
         * @return The current {@link EmailBuilder} instance for method chaining.
         */
        public EmailBuilder includeMetadata() {
            this.metadata = true;
            return this;
        }

        /**
         * Sets a custom transaction ID for API requests.
         *
         * @param referenceId The transaction ID to use.
         * @return The current {@link EmailBuilder} instance for method chaining.
         * @deprecated Set your reference ID as part every API interaction like the Validate call instead.
         */
        @Deprecated(since="1.1.10", forRemoval=true)
        public EmailBuilder setTransactionId(String referenceId) {
            super.setTransactionId(referenceId);
            return this;
        }
    }
}