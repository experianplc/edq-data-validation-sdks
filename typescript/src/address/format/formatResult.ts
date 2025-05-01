import { RestApiAddressFormatResponse } from "../../server/address/format/restApiAddressFormatResponse";
import { AddressConfidence, lookupConfidence } from "../addressConfidence";
import { AddressComponents, restApiResponseToAddressComponents } from "./addressComponents";
import { AddressEnrichment, restApiResponseToAddressEncrichment } from "./addressEnrichment";
import { AddressFormatted, restApiToAddressFormatted } from "./addressFormatted";
import { AddressMetadata, restApiResponseToAddressMetadata } from "./addressMetadata";
import { FormatAddress, restApiResponseToFormatAddress } from "./formatAddress";

export type FormatResult = {
    globalAddressKey?: string;
    confidence?: AddressConfidence;
    address?: FormatAddress;
    addressFormatted?: AddressFormatted;
    components?: AddressComponents;
    metadata?: AddressMetadata;
    enrichment?: AddressEnrichment;
};

export function restApiResponseToFormatResult(response: RestApiAddressFormatResponse): FormatResult {
    
    const result: FormatResult = {};
    
    const apiResponse = response.result;
    const apiMetadata = response.metadata;
    const apiEnrichment = response.enrichment;

    if (apiResponse) {
        result.globalAddressKey = apiResponse.global_address_key;
        result.confidence = lookupConfidence(apiResponse.confidence);
        if (apiResponse.address) {
            result.address = restApiResponseToFormatAddress(apiResponse.address);
        }
        if (apiResponse.addresses_formatted && apiResponse.addresses_formatted.length > 0) {
            result.addressFormatted = restApiToAddressFormatted(apiResponse.addresses_formatted[0]);
        }
        if (apiResponse.components) {
            result.components = restApiResponseToAddressComponents(apiResponse.components);
        }       
    }
    if (apiMetadata) {
        result.metadata = restApiResponseToAddressMetadata(apiMetadata);
    }
    if (apiEnrichment) {
        result.enrichment = restApiResponseToAddressEncrichment(apiEnrichment);
    }

    return result;

}