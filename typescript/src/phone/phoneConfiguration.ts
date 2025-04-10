import { Configuration, ConfigurationOptions } from "../common/configuration";
import { Country } from "../common/country";

export interface PhoneConfigurationOptions extends ConfigurationOptions {    
    includeMetadata?: boolean;
    outputFormat?: string;
    cacheValueDays?: number;
    includeDisposableNumber?: boolean;
    includePortedDate?: boolean;
    liveStatusForMobile?: Country[];
    liveStatusForLandline?: Country[];
}

export class PhoneConfiguration extends Configuration {

    public static readonly defaultCacheValueDays = 7;
    public options: PhoneConfigurationOptions = {};
    
    constructor(token: string, options: PhoneConfigurationOptions = {}) {
        const defaultedOptions = PhoneConfiguration.applyDefaultOptions(options);
        super(token, options);
        this.options = defaultedOptions;
            
    }

    protected static applyDefaultOptions(options: PhoneConfigurationOptions) : PhoneConfigurationOptions {
    
        const baseResult = super.applyDefaultOptions(options);
        const result = {...options, ...baseResult}
        if (!result.cacheValueDays) {
            result.cacheValueDays = this.defaultCacheValueDays;
        }

        return result;
    }
}

