import { AddressConfiguration } from "../../address/addressConfiguration";
import { RestApiAdditionalOption } from "./restApiAdditionalOption";
import { RestApiAddress } from "./restApiAddress";

export type RestApiAddressSearchRequest = {
    country_iso?: string;
    datasets?: string[];
    max_suggestions?: number;
    components?: RestApiAddress;
    location?: string;
    options?: RestApiAdditionalOption[];
}

export function getAddressSearchRequestFromConfig(config: AddressConfiguration): RestApiAddressSearchRequest {
    const searchRequest: RestApiAddressSearchRequest = {};

    // Country
    if (config.options.datasets && config.options.datasets.length > 0) {
        searchRequest.country_iso = config.options.datasets[0].country.iso3Code;
    }
    // Datasets
    if (config.options.datasets && config.options.datasets.length > 0) {
        searchRequest.datasets = config.options.datasets.map(dataset => dataset.datasetCode);
    }
    // Max suggestions
    if (config.options.maxSuggestions !== AddressConfiguration.defaultMaxSuggestions) {
        searchRequest.max_suggestions = config.options.maxSuggestions;
    }
    // Location
    if (config.options.location && config.options.location.length > 0) {
        searchRequest.location = config.options.location;
    }

    searchRequest.options = [];
    if (config.options.flattenResults) {
        searchRequest.options.push({ name: "flatten", value: "true" });
    }
    if (config.options.searchIntensity) {
        searchRequest.options.push({ name: "intensity", value: config.options.searchIntensity});
    }
    if (config.options.promptSet) {
        searchRequest.options.push({ name: "prompt_set", value: config.options.promptSet });
    }

    // TODO: preferred language and preferred script

    return searchRequest;
}