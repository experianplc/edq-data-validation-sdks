import { Configuration, ConfigurationOptions } from "../common/configuration";

/**
 * Interface defining the options for configuring the Email client.
 */
export interface EmailConfigurationOptions extends ConfigurationOptions {
    includeMetadata?: boolean;
}

/**
 * Configuration class for setting up the Email client.
 * Provides options for customizing email-related API requests.
 */
export class EmailConfiguration extends Configuration {

    public options: EmailConfigurationOptions = {};

    /**
     * Initializes a new instance of the {@link EmailConfiguration} class with the specified token and options.
     *
     * @param token   The authentication token for the API.
     * @param options The configuration options for the Email client.
     */
    constructor(token: string, options: EmailConfigurationOptions = {}) {
        const defaultedOptions = EmailConfiguration.applyDefaultOptions(options);
        super(token, options);
        this.options = defaultedOptions;
    }

    /**
     * Applies default values to the provided configuration options.
     *
     * @param options The configuration options to apply defaults to.
     * @return The configuration options with default values applied.
     */
    protected static applyDefaultOptions(options: EmailConfigurationOptions): EmailConfigurationOptions {
        const baseResult = super.applyDefaultOptions(options);
        const result = { ...options, ...baseResult };

        return result;
    }
}
