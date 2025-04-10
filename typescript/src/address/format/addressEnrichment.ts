import { RestApiAddressFormatEnrichment } from "../../server/address/format/restApiAddressFormatEnrichment";
import { AusRegionalGeocodes, restApiResponseToAusRegionalGeocodes } from "./enrichment/ausRegionalGeocodes";
import { GbrBusiness, restApiResponseToGbrBusiness } from "./enrichment/gbrBusiness";
import { GbrGovernment, restApiResponseToGbrGovernment } from "./enrichment/gbrGovernment";
import { GbrHealth, restApiResponseToGbrHealth } from "./enrichment/gbrHealth";
import { Geocodes } from "./enrichment/geocodes";
import { Metadata } from "./enrichment/metadata";
import { NzlRegionalGeocodes, restApiResponseToNzlRegionalGeocodes } from "./enrichment/nzlRegionalGeocodes";
import { restApiResponseToUKLocationComplete, UKLocationComplete } from "./enrichment/ukLocationComplete";
import { restApiResponseToUKLocationEssential, UKLocationEssential } from "./enrichment/ukLocationEssential";
import { UsaRegionalGeocodes } from "./enrichment/usaRegionalGeocodes";
import { lookupGeocodeMatchLevel } from "./geocodeMatchLevel";

export type AddressEnrichment = {
    transactionId?: string;
    geocodes?: Geocodes;
    usaRegionalGeocodes?: UsaRegionalGeocodes;
    ausRegionalGeocodes?: AusRegionalGeocodes;
    nzlRegionalGeocodes?: NzlRegionalGeocodes;
    gbrLocationComplete?: UKLocationComplete;
    gbrLocationEssential?: UKLocationEssential;
    gbrGovernment?: GbrGovernment;
    gbrBusiness?: GbrBusiness;
    gbrHealth?: GbrHealth;
    metadata?: Metadata;
};

export function restApiResponseToAddressEncrichment(response: RestApiAddressFormatEnrichment): AddressEnrichment {
    const result: AddressEnrichment = { transactionId: response.transaction_id ?? "" };
    const apiResponse = response.result;

    if (apiResponse) {
        handleGeocodes(apiResponse, result);
        handleRegionalGeocodes(apiResponse, result);
        handleUKLocation(apiResponse, result);
        handleGbrSpecificData(apiResponse, result);
    }

    if (response.metadata) {
        result.metadata = {
            code: response.metadata.code ?? "",
            message: response.metadata.message ?? "",
            detail: response.metadata.detail ?? ""
        };
    }

    return result;
}

function handleGeocodes(apiResponse: any, result: AddressEnrichment) {
    if (apiResponse.geocodes) {
        result.geocodes = {
            latitude: apiResponse.geocodes.latitude,
            longitude: apiResponse.geocodes.longitude,
            matchLevel: apiResponse.geocodes.match_level ? lookupGeocodeMatchLevel(apiResponse.geocodes.match_level) : undefined
        };
    }
}

function handleRegionalGeocodes(apiResponse: any, result: AddressEnrichment) {
    if (apiResponse.usa_regional_geocodes) {
        result.usaRegionalGeocodes = {
            latitude: apiResponse.usa_regional_geocodes.latitude,
            longitude: apiResponse.usa_regional_geocodes.longitude,
            matchLevel: lookupGeocodeMatchLevel(apiResponse.usa_regional_geocodes.match_level),
            censusTract: apiResponse.usa_regional_geocodes.census_tract ?? "",
            censusBlock: apiResponse.usa_regional_geocodes.census_block ?? "",
            coreBasedStatisticalArea: apiResponse.usa_regional_geocodes.core_based_statistical_area ?? "",
            congressionalDistrictCode: apiResponse.usa_regional_geocodes.congressional_district_code ?? "",
            countyCode: apiResponse.usa_regional_geocodes.county_code ?? ""
        };
    }
    if (apiResponse.aus_regional_geocodes) {
        result.ausRegionalGeocodes = restApiResponseToAusRegionalGeocodes(apiResponse.aus_regional_geocodes);
    }
    if (apiResponse.nz_regional_geocodes) {
        result.nzlRegionalGeocodes = restApiResponseToNzlRegionalGeocodes(apiResponse.nz_regional_geocodes);
    }
}

function handleUKLocation(apiResponse: any, result: AddressEnrichment) {
    if (apiResponse.uk_location_complete) {
        result.gbrLocationComplete = restApiResponseToUKLocationComplete(apiResponse.uk_location_complete);
    }
    if (apiResponse.uk_location_essential) {
        result.gbrLocationEssential = restApiResponseToUKLocationEssential(apiResponse.uk_location_essential);
    }
}

function handleGbrSpecificData(apiResponse: any, result: AddressEnrichment) {
    if (apiResponse.gbr_government) {
        result.gbrGovernment = restApiResponseToGbrGovernment(apiResponse.gbr_government);
    }
    if (apiResponse.gbr_business) {
        result.gbrBusiness = restApiResponseToGbrBusiness(apiResponse.gbr_business);
    }
    if (apiResponse.gbr_health) {
        result.gbrHealth = restApiResponseToGbrHealth(apiResponse.gbr_health);
    }
}