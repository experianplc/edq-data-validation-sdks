package com.experian.dvs.client.phone;

import com.experian.dvs.client.common.Country;

import java.util.ArrayList;
import java.util.List;

/**
 * AddressConfiguration class for setting up the phone client.
 * Provides options for customizing phone-related API requests.
 */
public class PhoneConfiguration extends com.experian.dvs.client.common.Configuration {

    public static final int DEFAULT_CACHE_VALUE_DAYS = 7;
    private final boolean metadata;
    private final String outputFormat;
    private final int cacheValueDays;
    private final boolean getPortedDate;
    private final boolean getDisposableNumber;
    private final List<Country> liveStatusForMobile;
    private final List<Country> liveStatusForLandline;

    /**
     * Initializes a new instance of the {@link PhoneConfiguration} class using the specified builder.
     *
     * @param builder The builder containing the configuration settings.
     */
    protected PhoneConfiguration(PhoneBuilder builder) {
        super(builder);
        this.metadata = builder.metadata;
        this.outputFormat = builder.outputFormat;
        this.cacheValueDays = builder.cacheValueDays;
        this.getPortedDate = builder.getPortedDate;
        this.getDisposableNumber = builder.getDisposableNumber;
        this.liveStatusForMobile = builder.liveStatusForMobile;
        this.liveStatusForLandline = builder.liveStatusForLandline;
    }

    /**
     * Creates a new instance of the {@link PhoneBuilder} class to configure the phone client.
     *
     * @param token The authentication token for the API.
     * @return A new instance of the {@link PhoneBuilder} class.
     */
    public static PhoneBuilder newBuilder(String token) {
        return new PhoneBuilder(token);
    }

    /**
     * Retrieves the output format setting for the configuration.
     *
     * @return The output format as a string.
     */
    public String getOutputFormat() {
        return outputFormat;
    }

    /**
     * Retrieves the cache value days setting for the configuration.
     *
     * @return The number of days to cache values.
     */
    public int getCacheValueDays() {
        return cacheValueDays;
    }

    /**
     * Retrieves the ported date inclusion setting for the configuration.
     *
     * @return True if the ported date is included; otherwise, false.
     */
    public boolean getGetPortedDate() {
        return getPortedDate;
    }

    /**
     * Retrieves the disposable number inclusion setting for the configuration.
     *
     * @return True if disposable numbers are included; otherwise, false.
     */
    public boolean getGetDisposableNumber() {
        return getDisposableNumber;
    }

    /**
     * Retrieves the list of countries for which live status is enabled for landline numbers.
     *
     * @return A list of {@link Country} objects.
     */
    public List<Country> getLiveStatusForLandline() {
        return liveStatusForLandline;
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
     * Retrieves the list of countries for which live status is enabled for mobile numbers.
     *
     * @return A list of {@link Country} objects.
     */
    public List<Country> getLiveStatusForMobile() {
        return liveStatusForMobile;
    }

    /**
     * AddressBuilder class for constructing a {@link PhoneConfiguration} object with custom settings.
     */
    public static class PhoneBuilder extends com.experian.dvs.client.common.Configuration.Builder {
        private boolean metadata;
        private String outputFormat = "";
        private int cacheValueDays = DEFAULT_CACHE_VALUE_DAYS;
        private boolean getPortedDate;
        private boolean getDisposableNumber;
        private List<Country> liveStatusForMobile = new ArrayList<Country>();
        private List<Country> liveStatusForLandline = new ArrayList<Country>();

        /**
         * Initializes a new instance of the {@link PhoneBuilder} class with the specified token.
         *
         * @param token The authentication token for the API.
         */
        public PhoneBuilder(String token) {
            super(token);
        }

        /**
         * Sets a custom transaction ID for API requests.
         *
         * @param referenceId The transaction ID to use.
         * @return The current {@link PhoneBuilder} instance for method chaining.
         * @deprecated Set your reference ID as part every API interaction like the Validate call instead.
         */
        @Deprecated(since="1.1.10", forRemoval=true)
        public PhoneBuilder setTransactionId(String referenceId) {
            super.setTransactionId(referenceId);
            return this;
        }

        /**
         * Includes metadata in the API response.
         *
         * @return The current {@link PhoneBuilder} instance for method chaining.
         */
        public PhoneBuilder includeMetadata() {
            this.metadata = true;
            return this;
        }

        /**
         * Sets the output format for the API response.
         *
         * @param outputFormat The output format to use.
         * @return The current {@link PhoneBuilder} instance for method chaining.
         */
        public PhoneBuilder useOutputFormat(String outputFormat) {
            this.outputFormat = outputFormat;
            return this;
        }

        /**
         * Sets the number of days to cache values.
         *
         * @param cacheValueDays The number of days to cache values.
         * @return The current {@link PhoneBuilder} instance for method chaining.
         */
        public PhoneBuilder useCacheValueDays(Integer cacheValueDays) {
            this.cacheValueDays = cacheValueDays;
            return this;
        }

        /**
         * Includes the ported date in the API response.
         *
         * @return The current {@link PhoneBuilder} instance for method chaining.
         */
        public PhoneBuilder includePortedDate() {
            this.getPortedDate = true;
            return this;
        }

        /**
         * Includes disposable numbers in the API response.
         *
         * @return The current {@link PhoneBuilder} instance for method chaining.
         */
        public PhoneBuilder includeDisposableNumber() {
            this.getDisposableNumber = true;
            return this;
        }

        /**
         * Sets the list of countries for which live status is enabled for mobile numbers.
         *
         * @param liveStatusForMobile The list of countries to enable live status for mobile numbers.
         * @return The current {@link PhoneBuilder} instance for method chaining.
         */
        public PhoneBuilder useLiveStatusForMobile(List<Country> liveStatusForMobile) {
            this.liveStatusForMobile = liveStatusForMobile;
            return this;
        }

        /**
         * Sets the list of countries for which live status is enabled for landline numbers.
         *
         * @param liveStatusForLandline The list of countries to enable live status for landline numbers.
         * @return The current {@link PhoneBuilder} instance for method chaining.
         */
        public PhoneBuilder useLiveStatusForLandline(List<Country> liveStatusForLandline) {
            this.liveStatusForLandline = liveStatusForLandline;
            return this;
        }

        /**
         * Builds the {@link PhoneConfiguration} object with the specified settings.
         *
         * @return A new instance of the {@link PhoneConfiguration} class.
         */
        @Override
        public PhoneConfiguration build() {
            return new PhoneConfiguration(this);
        }
    }
}
