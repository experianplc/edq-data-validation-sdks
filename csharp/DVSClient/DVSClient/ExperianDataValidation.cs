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
        public static Address.Client GetAddressClient(Address.Configuration configuration)
        {
            return new Address.Client(configuration);
        }

        /// <summary>
        /// Gets a client for performing address layout related operations (e.g. create, get, list, delete)
        /// These layouts can be used when formatting address (By supplying the layout name in the FormatOption of an AddressConfiguration)
        /// </summary>
        /// <param name="configuration">The configuration options to be used for each method call</param>
        /// <returns>The created client object</returns>
        public static Address.Layout.Client GetAddressLayoutClient(Address.Layout.Configuration configuration)
        {
            return new Address.Layout.Client(configuration);
        }

        /// <summary>
        /// Gets a client for validating phone numbers
        /// </summary>
        /// <param name="configuration">The configuration options to be used for each validation</param>
        /// <returns>The created client object</returns>
        public static Phone.Client GetPhoneClient(Phone.Configuration configuration)
        {
            return new Phone.Client(configuration);
        }

        /// <summary>
        /// Gets a client for validating email addresses
        /// </summary>
        /// <param name="configuration">The configuration options to be used for each validation</param>
        /// <returns>The created client object</returns>
        public static Email.Client GetEmailClient(Email.Configuration configuration)
        {
            return new Email.Client(configuration);
        }
    }
}
