package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.common.Configuration;

/**
 * Configuration class for setting up the address layout client.
 * Provides options for customizing address layout-related API requests.
 */
public class AddressLayoutConfiguration extends Configuration {

    /**
     * Initializes a new instance of the {@link AddressLayoutConfiguration} class using the specified builder.
     *
     * @param builder The builder containing the configuration settings.
     */
    protected AddressLayoutConfiguration(Builder builder) {
        super(builder);
    }

    /**
     * Creates a new instance of the {@link Builder} class to configure the address layout client.
     *
     * @param token The authentication token for the API.
     * @return A new instance of the {@link Builder} class.
     */
    public static Builder newBuilder(final String token) {
        return new Builder(token);
    }

    /**
     * Builder class for constructing an {@link AddressLayoutConfiguration} object with custom settings.
     */
    public static class Builder extends Configuration.Builder {

        /**
         * Initializes a new instance of the {@link Builder} class with the specified token.
         *
         * @param token The authentication token for the API.
         */
        public Builder(String token) {
            super(token);
        }

        /**
         * Builds the {@link AddressLayoutConfiguration} object with the specified settings.
         *
         * @return A new instance of the {@link AddressLayoutConfiguration} class.
         */
        public AddressLayoutConfiguration build() {
            return new AddressLayoutConfiguration(this);
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
