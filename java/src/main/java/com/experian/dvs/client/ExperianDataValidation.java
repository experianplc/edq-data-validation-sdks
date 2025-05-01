package com.experian.dvs.client;

import com.experian.dvs.client.address.AddressClient;
import com.experian.dvs.client.address.AddressConfiguration;
import com.experian.dvs.client.address.layout.LayoutClient;
import com.experian.dvs.client.address.layout.LayoutConfiguration;
import com.experian.dvs.client.email.EmailClient;
import com.experian.dvs.client.email.EmailConfiguration;
import com.experian.dvs.client.phone.PhoneClient;
import com.experian.dvs.client.phone.PhoneConfiguration;

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
    public static AddressClient getAddressClient(final AddressConfiguration configuration) {
        return new AddressClient(configuration);
    }

    /**
     * Gets a client for performing address layout related operations (e.g. create, get, list, delete)
     * These layouts can be used when formatting address (By supplying the layout name in the {@code FormatOption} of an {@code AddressConfiguration} )
     * @param configuration the configuration options to be used for each method call
     * @return the created client object
     */
    public static LayoutClient getAddressLayoutClient(final LayoutConfiguration configuration) {
        return new LayoutClient(configuration);
    }

    /**
     * Gets a client for validating phone numbers
     * @param configuration the configuration options to be used for each validation
     * @return the created client object
     */
    public static PhoneClient getPhoneClient(final PhoneConfiguration configuration) {
        return new PhoneClient(configuration);
    }

    /**
     * Gets a client for validating email addresses
     * @param configuration the configuration options to be used for each validation
     * @return the created client object
     */
    public static EmailClient getEmailClient(final EmailConfiguration configuration) {
        return new EmailClient(configuration);
    }


}
