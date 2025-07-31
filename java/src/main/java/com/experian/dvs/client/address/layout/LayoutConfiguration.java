package com.experian.dvs.client.address.layout;

import com.experian.dvs.client.common.Configuration;

/**
 * AddressConfiguration class for setting up the address layout client.
 * Provides options for customizing address layout-related API requests.
 */
public class LayoutConfiguration extends Configuration {

    /**
     * Initializes a new instance of the {@link LayoutConfiguration} class using the specified builder.
     *
     * @param builder The builder containing the configuration settings.
     */
    protected LayoutConfiguration(LayoutBuilder builder) {
        super(builder);
    }

    /**
     * Creates a new instance of the {@link LayoutBuilder} class to configure the address layout client.
     *
     * @param token The authentication token for the API.
     * @return A new instance of the {@link LayoutBuilder} class.
     */
    public static LayoutBuilder newBuilder(final String token) {
        return new LayoutBuilder(token);
    }

    /**
     * AddressBuilder class for constructing an {@link LayoutConfiguration} object with custom settings.
     */
    public static class LayoutBuilder extends Configuration.Builder {

        /**
         * Initializes a new instance of the {@link LayoutBuilder} class with the specified token.
         *
         * @param token The authentication token for the API.
         */
        public LayoutBuilder(String token) {
            super(token);
        }

        /**
         * Builds the {@link LayoutConfiguration} object with the specified settings.
         *
         * @return A new instance of the {@link LayoutConfiguration} class.
         */
        public LayoutConfiguration build() {
            return new LayoutConfiguration(this);
        }

        /**
         * Sets a custom transaction ID for API requests.
         *
         * @param referenceId The transaction ID to use.
         * @return The current {@link LayoutBuilder} instance for method chaining.
         * @deprecated Set your reference ID as part every API interaction like the creating or deleting a layout call instead.
         */
        @Deprecated(since="1.1.10", forRemoval=true)
        public LayoutBuilder setTransactionId(String referenceId) {
            super.setTransactionId(referenceId);
            return this;
        }
    }
}
