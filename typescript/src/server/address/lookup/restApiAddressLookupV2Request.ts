import { AddressConfiguration } from "../../../address/addressConfiguration";
import { EDVSError } from "../../../exceptions/edvsException";

export type RestApiAddressLookupV2Request = {
    country_iso: string;
    datasets: string[];
    max_addresses?: number;
    max_suggestions?: number;
    attributes?: {
        locality_lookup?: string[];
        postal_code_lookup?: string[];
    };
    key?: {
        type?: string;
        value?: string;
    };
    preferred_language?: string[];
    preferred_script?: string[];
    names?: {
        forename?: string;
        middlename?: string;
        surname?: string;
    }[];
    layouts?: string[];
};

export function getLookupRequestFromConfig(config: AddressConfiguration): RestApiAddressLookupV2Request {
    
    //Dataset must have been supplied
    if (!Array.isArray(config.options.datasets) || config.options.datasets.length === 0) {
        throw new EDVSError("No datasets have been supplied in the configuration.");
    }
    config.validateDatasetCountry();

    const request: RestApiAddressLookupV2Request = {
        country_iso: config.options.datasets[0].country.iso3Code,
        datasets: config.options.datasets.map(dataset => dataset.datasetCode)
    }
    if (config.options.lookup?.maxAddresses) {
        request.max_addresses = config.options.lookup.maxAddresses;
    }
    if (config.options.maxSuggestions) {
        request.max_suggestions = config.options.maxSuggestions;
    }
    if (config.options.lookup?.attributes) {        
        const lookupAttributes = config.options.lookup.attributes;
        if (lookupAttributes.localityLookup) {
            request.attributes = { locality_lookup: lookupAttributes.localityLookup };
        }
        if (lookupAttributes.postalCodeLookup) {
            if (!request.attributes) {
                request.attributes = {};
            }
            request.attributes.postal_code_lookup = lookupAttributes.postalCodeLookup;
        }        
    }
    if (config.options.layoutName) {
        request.layouts = [config.options.layoutName];
    }


    return request;

    
}