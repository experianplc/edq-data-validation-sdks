package com.experian.dvs.client;

import com.experian.dvs.client.address.Client;
import com.experian.dvs.client.address.Configuration;
import com.experian.dvs.client.address.layout.AddressLayoutClient;
import com.experian.dvs.client.address.layout.AddressLayoutConfiguration;

/**
 * Entry point for the Experian Contact Validation Services client.
 * Use this to create clients for the different services.
 * When creating a client, you need to provide a configuration object. This contains the configuration details that
 * are used for every subsequent call (like address formatting).
 */
public class ExperianDataValidation {

    private ExperianDataValidation() {
        // private constructor
    }

    /**
     * Gets a client for performing address related operations (e.g. search, validate, format)
     * @param configuration the configuration options to be used for each method call
     * @return the created client object
     */
    public static Client getAddressClient(final Configuration configuration) {
        return new Client(configuration);
    }

    /**
     * Gets a client for performing address layout related operations (e.g. create, get, list, delete)
     * These layouts can be used when formatting address (By supplying the layout name in the {@code FormatOption} of an {@code AddressConfiguration} )
     * @param configuration the configuration options to be used for each method call
     * @return the created client object
     */
    public static AddressLayoutClient getAddressLayoutClient(final AddressLayoutConfiguration configuration) {
        return new AddressLayoutClient(configuration);
    }

    /**
     * Gets a client for validating phone numbers
     * @param configuration the configuration options to be used for each validation
     * @return the created client object
     */
    public static com.experian.dvs.client.phone.Client getPhoneClient(final com.experian.dvs.client.phone.Configuration configuration) {
        return new com.experian.dvs.client.phone.Client(configuration);
    }

    /**
     * Gets a client for validating email addresses
     * @param configuration the configuration options to be used for each validation
     * @return the created client object
     */
    public static com.experian.dvs.client.email.Client getEmailClient(final com.experian.dvs.client.email.Configuration configuration) {
        return new com.experian.dvs.client.email.Client(configuration);
    }


}
