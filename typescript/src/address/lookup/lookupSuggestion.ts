import { RestApiAddressLookupSuggestion } from "../../server/address/lookup/restApiAddresslookupSuggestion";
import { LookupLocalityItem, restApiResponseToLookupLocalityItem } from "./lookupLocalityItem";


export type LookupSuggestion = {
    locality?: {
        region?: LookupLocalityItem;
        subRegion?: LookupLocalityItem;
        town?: LookupLocalityItem;
        district?: LookupLocalityItem;
        subDistrict?: LookupLocalityItem;
    };
    postalCode?: {
        fullName?: string;
        primary?: string;
        secondary?: string;
    };
    postalCodeKey?: string;
    localityKey?: string;
    what3words?: {
        name?: string;
        description?: string;
    };

}

export function restApiResponseToLookupSuggestion(response: RestApiAddressLookupSuggestion): LookupSuggestion {

    const result: LookupSuggestion = {};
    if (response.locality) {
        result.locality = {
            region: response.locality.region ? restApiResponseToLookupLocalityItem(response.locality.region) : {},
            subRegion: response.locality.sub_region ? restApiResponseToLookupLocalityItem(response.locality.sub_region) : {},
            town: response.locality.town ? restApiResponseToLookupLocalityItem(response.locality.town) : {},
            district: response.locality.district ? restApiResponseToLookupLocalityItem(response.locality.district) : {},
            subDistrict: response.locality.sub_district ? restApiResponseToLookupLocalityItem(response.locality.sub_district) : {}
        }
    }
    if (response.postal_code) {
        result.postalCode = {
            fullName: response.postal_code.full_name,
            primary: response.postal_code.primary,
            secondary: response.postal_code.secondary
        }
    }
    if (response.what3words) {
        result.what3words = {
            name: response.what3words.name,
            description: response.what3words.description
        }
    }

    if (response.postal_code_key) {
        result.postalCodeKey = response.postal_code_key;
    }
    if (response.locality_key) {
        result.localityKey = response.locality_key;
    }

    return result;

}