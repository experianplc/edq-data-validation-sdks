import { Configuration, ConfigurationOptions } from "../common/configuration";
import { Country } from "../common/country";

/**
 * Interface defining the options for configuring the Phone client.
 */
export interface PhoneConfigurationOptions extends ConfigurationOptions {
    includeMetadata?: boolean;
    outputFormat?: string;
    cacheValueDays?: number;
    includeDisposableNumber?: boolean;
    includePortedDate?: boolean;
    liveStatusForMobile?: Country[];
    liveStatusForLandline?: Country[];
}

/**
 * Configuration class for setting up the Phone client.
 * Provides options for customizing phone-related API requests.
 */
export class PhoneConfiguration extends Configuration {

    public static readonly defaultCacheValueDays = 7;
    public options: PhoneConfigurationOptions = {};

    /**
     * Initializes a new instance of the {@link PhoneConfiguration} class with the specified token and options.
     *
     * @param token   The authentication token for the API.
     * @param options The configuration options for the Phone client.
     */
    constructor(token: string, options: PhoneConfigurationOptions = {}) {
        const defaultedOptions = PhoneConfiguration.applyDefaultOptions(options);
        super(token, options);
        this.options = defaultedOptions;
    }

    /**
     * Applies default values to the provided configuration options.
     *
     * @param options The configuration options to apply defaults to.
     * @return The configuration options with default values applied.
     */
    protected static applyDefaultOptions(options: PhoneConfigurationOptions): PhoneConfigurationOptions {
        const baseResult = super.applyDefaultOptions(options);
        const result = { ...options, ...baseResult };
        if (!result.cacheValueDays) {
            result.cacheValueDays = this.defaultCacheValueDays;
        }

        return result;
    }
}

