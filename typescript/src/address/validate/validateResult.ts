
import { RestApiAddressValidateResponse } from "../../server/address/validate/restApiAddressValidateResponse"
import { AddressConfidence, lookupConfidence } from "../addressConfidence"
import { AddressComponents, restApiResponseToAddressComponents } from "../format/addressComponents"
import { AddressEnrichment, restApiResponseToAddressEncrichment as restApiResponseToAddressEnrichment } from "../format/addressEnrichment"
import { AddressFormatted } from "../format/addressFormatted"
import { AddressMetadata, restApiResponseToAddressMetadata } from "../format/addressMetadata"
import { FormatAddress, restApiResponseToFormatAddress } from "../format/formatAddress"
import { restApiResponseToSuggestion, SearchSuggestion } from "../search/searchSuggestion"
import { lookupMatchConfidence, ValidateMatchConfidence } from "./validateMatchConfidence"
import { ValidateMatchInfo, restApiToValidateMatchInfo } from "./validateMatchInfo"
import { lookupMatchType, ValidateMatchType } from "./validateMatchType"
import { restApiToValidationDetail, ValidationDetail } from "./validationDetail"

export type ValidateResult = {
    validationDetail?: ValidationDetail,
    globalAddressKey?: string,
    moreResultsAvailable?: boolean,
    confidence?: AddressConfidence,
    address?: FormatAddress,
    addressFormatted?: AddressFormatted
    suggestionsKey?: string;
    suggestionsPrompt?: string;
    suggestions?: SearchSuggestion[];
    matchConfidence?: ValidateMatchConfidence;
    matchType?: ValidateMatchType;
    components?: AddressComponents;
    metadata?: AddressMetadata;
    enrichment?: AddressEnrichment;
    matchInfo?: ValidateMatchInfo;
}

export function restApiResponseToValidationResult(response: RestApiAddressValidateResponse): ValidateResult {
    const result: ValidateResult = {};

    const apiResult = response.result;
    const apiMetadata = response.metadata;
    const apiEnrichment = response.enrichment;

    if (apiResult) {
        result.globalAddressKey = apiResult.global_address_key??"";
        result.suggestionsKey = apiResult.suggestions_key??"";
        result.suggestionsPrompt = apiResult.suggestions_prompt??"";
        result.matchConfidence = lookupMatchConfidence(apiResult.match_confidence);
        result.matchType = lookupMatchType(apiResult.match_type);
        result.moreResultsAvailable = apiResult.more_results_available??false;

        if (apiResult.validation_detail) {
            result.validationDetail = restApiToValidationDetail(apiResult.validation_detail);
        }

        if (apiResult.confidence) {
            result.confidence = lookupConfidence(apiResult.confidence);    
        }

        if (apiResult.address) {
            result.address = restApiResponseToFormatAddress(apiResult.address)
        }

        if (apiResult.suggestions) {
            result.suggestions = apiResult.suggestions?.map(suggestion => restApiResponseToSuggestion(suggestion)) ?? []
        }

        if (apiResult.match_confidence) {
            result.matchConfidence = lookupMatchConfidence(apiResult.match_confidence);
        }

        if (apiResult.match_type) {
            result.matchType = lookupMatchType(apiResult.match_type);
        }

        if (apiResult.components) {
            result.components = restApiResponseToAddressComponents(apiResult.components);
        }

        if (apiResult.match_info) {
            result.matchInfo = restApiToValidateMatchInfo(apiResult.match_info);
        }
    } else {
        return {
            globalAddressKey: "",
            suggestionsKey: "",
            suggestionsPrompt: ""
        }
    }

    if (apiMetadata) {
        result.metadata = restApiResponseToAddressMetadata(apiMetadata);
    }
    
    if (apiEnrichment) {
        result.enrichment = restApiResponseToAddressEnrichment(apiEnrichment);
    }

    return result;
}

