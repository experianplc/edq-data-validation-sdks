import { Configuration, ConfigurationOptions } from "../../common/configuration";

export interface LayoutConfigurationOptions extends ConfigurationOptions {    
}
export class LayoutConfiguration extends Configuration {

    public options: LayoutConfigurationOptions = {};

    constructor(token: string, options: LayoutConfigurationOptions = {}) {
        const defaultedOptions = LayoutConfiguration.applyDefaultOptions(options);
        super(token, options);
        this.options = defaultedOptions;
            
    }

    protected static applyDefaultOptions(options: LayoutConfigurationOptions) : LayoutConfigurationOptions {
    
        const baseResult = super.applyDefaultOptions(options);
        const result = {...options, ...baseResult}

        return result;
    }
}