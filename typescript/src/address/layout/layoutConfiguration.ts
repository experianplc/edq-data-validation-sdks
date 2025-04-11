import { Configuration, ConfigurationOptions } from "../../common/configuration";

/**
 * Interface defining the options for configuring the Layout client.
 */
export interface LayoutConfigurationOptions extends ConfigurationOptions {
}

/**
 * Configuration class for setting up the Layout client.
 * Provides options for customizing layout-related API requests.
 */
export class LayoutConfiguration extends Configuration {

    public options: LayoutConfigurationOptions = {};

    /**
     * Initializes a new instance of the {@link LayoutConfiguration} class with the specified token and options.
     *
     * @param token   The authentication token for the API.
     * @param options The configuration options for the Layout client.
     */
    constructor(token: string, options: LayoutConfigurationOptions = {}) {
        const defaultedOptions = LayoutConfiguration.applyDefaultOptions(options);
        super(token, options);
        this.options = defaultedOptions;
    }

    /**
     * Applies default values to the provided configuration options.
     *
     * @param options The configuration options to apply defaults to.
     * @return The configuration options with default values applied.
     */
    protected static applyDefaultOptions(options: LayoutConfigurationOptions): LayoutConfigurationOptions {
        const baseResult = super.applyDefaultOptions(options);
        const result = { ...options, ...baseResult };

        return result;
    }
}

