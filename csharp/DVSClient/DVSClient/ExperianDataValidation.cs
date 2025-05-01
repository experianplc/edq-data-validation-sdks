namespace DVSClient
{
    /// <summary>
    /// Entry point for the Experian Contact Validation Services client.
    /// Use this to create clients for the different services.
    /// When creating a client, you need to provide a configuration object. This contains the configuration details that
    /// are used for every subsequent call (like address formatting).
    /// </summary>
    public static class ExperianDataValidation
    {
        /// <summary>
        /// Gets a client for performing address related operations (e.g. search, validate, format)
        /// </summary>
        /// <param name="configuration">The configuration options to be used for each method call</param>
        /// <returns>The created client object</returns>
        public static Address.AddressClient GetAddressClient(Address.AddressConfiguration configuration)
        {
            return new Address.AddressClient(configuration);
        }

        /// <summary>
        /// Gets a client for performing address layout related operations (e.g. create, get, list, delete)
        /// These layouts can be used when formatting address (By supplying the layout name in the FormatOption of an AddressConfiguration)
        /// </summary>
        /// <param name="configuration">The configuration options to be used for each method call</param>
        /// <returns>The created client object</returns>
        public static Address.Layout.LayoutClient GetAddressLayoutClient(Address.Layout.LayoutConfiguration configuration)
        {
            return new Address.Layout.LayoutClient(configuration);
        }

        /// <summary>
        /// Gets a client for validating phone numbers
        /// </summary>
        /// <param name="configuration">The configuration options to be used for each validation</param>
        /// <returns>The created client object</returns>
        public static Phone.PhoneClient GetPhoneClient(Phone.PhoneConfiguration configuration)
        {
            return new Phone.PhoneClient(configuration);
        }

        /// <summary>
        /// Gets a client for validating email addresses
        /// </summary>
        /// <param name="configuration">The configuration options to be used for each validation</param>
        /// <returns>The created client object</returns>
        public static Email.EmailClient GetEmailClient(Email.EmailConfiguration configuration)
        {
            return new Email.EmailClient(configuration);
        }
    }
}
