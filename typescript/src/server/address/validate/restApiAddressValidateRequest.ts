import { AddressConfiguration } from "../../../address/addressConfiguration";
import { RestApiFormatAttribute } from "../format/restApiFormatAttribute";
import { RestApiAdditionalOption } from "../restApiAdditionalOption";
import { RestApiAddress } from "../restApiAddress";

export type RestApiAddressValidateRequest = {
    country_iso?: string;
    datasets?: string[];
    max_suggestions?: number;
    components?: RestApiAddress;
    options?: RestApiAdditionalOption[];
    attributes?: RestApiFormatAttribute;
    layouts?: string[];
    layout_format?: string;
};

export function getAddressValidateRequestFromConfig(config: AddressConfiguration): RestApiAddressValidateRequest {
    const request: RestApiAddressValidateRequest = {options: []};
    // Country
    if (config.options.datasets && config.options.datasets.length > 0) {
        request.country_iso = config.options.datasets[0].country.iso3Code;
    }
    // Datasets
    if (config.options.datasets && config.options.datasets.length > 0) {
        request.datasets = config.options.datasets.map(dataset => dataset.datasetCode);
    }
    // Max suggestions
    if (config.options.maxSuggestions !== AddressConfiguration.defaultMaxSuggestions) {
        request.max_suggestions = config.options.maxSuggestions;
    }
    //Layout name
    if (config.options.formatLayoutName && config.options.formatLayoutName.length > 0) {
        request.layouts = [config.options.formatLayoutName];
    }
    //Layout format
    if (config.options.layoutFormat && config.options.layoutFormat.length > 0) {
        request.layout_format = config.options.layoutFormat;
    }
    if (config.options.formatLayoutName) {
        request.options!.push({ name: "flatten", value: "true" });
    }
    if (config.options.searchIntensity) {
        request.options!.push({ name: "intensity", value: config.options.searchIntensity });
    }
    if (config.options.promptSet) {
        request.options!.push({ name: "prompt_set", value: config.options.promptSet });
    }

    request.attributes = getFormatAttribute(config);

    return request;
    
}

export function getFormatAttribute(configuration: AddressConfiguration): RestApiFormatAttribute {
    const attributes: RestApiFormatAttribute = {};

    if (configuration.options.globalGeocodes && configuration.options.globalGeocodes.length > 0) {
        attributes.geocodes = configuration.options.globalGeocodes;;
    }

    if (configuration.options.premiumLocationInsights && configuration.options.premiumLocationInsights.length > 0) {
        attributes.premium_location_insight = configuration.options.premiumLocationInsights;
    }

    if (configuration.options.what3Words && configuration.options.what3Words.length > 0) {
        attributes.what3words = configuration.options.what3Words;
    }

    if (configuration.options.gbrLocationComplete && configuration.options.gbrLocationComplete.length > 0) {
        attributes.uk_location_complete = configuration.options.gbrLocationComplete;
    }

    if (configuration.options.gbrLocationEssential && configuration.options.gbrLocationEssential.length > 0) {
        attributes.uk_location_essential = configuration.options.gbrLocationEssential;
    }

    if (configuration.options.gbrGovernment && configuration.options.gbrGovernment.length > 0) {
        attributes.gbr_government = configuration.options.gbrGovernment;
    }

    if (configuration.options.gbrHealth && configuration.options.gbrHealth.length > 0) {
        attributes.gbr_health = configuration.options.gbrHealth;
    }

    if (configuration.options.gbrBusiness && configuration.options.gbrBusiness.length > 0) {
        attributes.gbr_business = configuration.options.gbrBusiness;
    }

    if (configuration.options.usaRegionalGeocodes && configuration.options.usaRegionalGeocodes.length > 0) {
        attributes.usa_regional_geocodes = configuration.options.usaRegionalGeocodes;
    }

    if (configuration.options.ausRegionalGeocodes && configuration.options.ausRegionalGeocodes.length > 0) {
        attributes.aus_regional_geocodes = configuration.options.ausRegionalGeocodes;
    }

    if (configuration.options.nzlRegionalGeocodes && configuration.options.nzlRegionalGeocodes.length > 0) {
        attributes.nzl_regional_geocodes = configuration.options.nzlRegionalGeocodes;
    }

    return attributes;

}    
