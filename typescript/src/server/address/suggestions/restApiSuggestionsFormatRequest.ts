import { AddressConfiguration } from "../../../address/addressConfiguration";
import { RestApiAddress } from "../restApiAddress";

export type RestApiSuggestionsFormatRequest = {
    country_iso?: string;
    datasets?: string[];
    max_suggestions?: number;
    components?: RestApiAddress;
    layouts?: string[];
};

export function getSuggestionsFormatRequestFromConfig(config: AddressConfiguration): RestApiSuggestionsFormatRequest {

    const request: RestApiSuggestionsFormatRequest = {};
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
    if (config.options.layoutName && config.options.layoutName.length > 0) {
        request.layouts = [config.options.layoutName];
    }

    return request;

};