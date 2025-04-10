
import { RestApiAddressValidateResponse } from "../../server/address/validate/restApiAddressValidateResponse"
import { Confidence, lookupConfidence } from "../confidence"
import { AddressFormatted } from "../format/addressFormatted"
import { FormatAddress, restApiResponseToFormatAddress } from "../format/formatAddress"
import { restApiToValidationDetail, ValidationDetail } from "./validationDetail"

export type AddressValidationResult = {
    validationDetail?: ValidationDetail,
    globalAddressKey: string,
    moreResultsAvailable?: boolean,
    confidence?: Confidence,
    address?: FormatAddress,
    addressFormatted?: AddressFormatted
}

export function restApiResponseToValidationResult(response: RestApiAddressValidateResponse): AddressValidationResult {
    const apiResult = response.result;
    
    if (apiResult) {
        const result: AddressValidationResult = {globalAddressKey: apiResult.global_address_key??""}
        if (apiResult.validation_detail) {
            result.validationDetail = restApiToValidationDetail(apiResult.validation_detail);
        }
        result.moreResultsAvailable = apiResult.more_results_available??false;
        if (apiResult.confidence) {
            result.confidence = lookupConfidence(apiResult.confidence);    
        }
        if (apiResult.address) {
            result.address = restApiResponseToFormatAddress(apiResult.address)
        }
        return result;
    } else {
        return {
            globalAddressKey: ""
        }
    }
}

