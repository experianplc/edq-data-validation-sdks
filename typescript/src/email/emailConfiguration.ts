import { Configuration, ConfigurationOptions } from "../common/configuration";

export interface EmailConfigurationOptions extends ConfigurationOptions {
    includeMetadata?: boolean;
}

export class EmailConfiguration extends Configuration {

    public options: EmailConfigurationOptions = {};

    constructor(token: string, options: EmailConfigurationOptions = {}) {
        const defaultedOptions = EmailConfiguration.applyDefaultOptions(options);
        super(token, options);
        this.options = defaultedOptions;
            
    }


    protected static applyDefaultOptions(options: EmailConfigurationOptions) : EmailConfigurationOptions {

        const baseResult = super.applyDefaultOptions(options);
        const result = {...options, ...baseResult}

        return result;
    }
}