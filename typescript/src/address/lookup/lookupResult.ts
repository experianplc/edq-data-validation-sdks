
import { RestApiAddressLookupV2Response } from "../../server/address/lookup/restApiAddressLookupV2Response"
import { AddressConfidence, lookupConfidence } from "../addressConfidence";
import { LookupAddressSuggestionV2, restApiResponseToLookupAddressSuggestionV2Hub } from "./lookupAddressSuggestionV2";
import { LookupSuggestion, restApiResponseToLookupSuggestion } from "./lookupSuggestion";
import { LookupV2ResultAddressFormatted, restApiResponseToLookupAddressFormatted } from "./lookupV2ResultAddressFormatted"

export type LookupResult = {
    moreResultsAvailable: boolean,
    confidence?: AddressConfidence,
    suggestionsKey?: string,
    suggestionsPrompt?: string,
    suggestions?: LookupSuggestion[],
    addresses?: LookupAddressSuggestionV2[],
    addressesFormatted?: LookupV2ResultAddressFormatted[]
}

export function restApiResponseToLookupResult(response: RestApiAddressLookupV2Response): LookupResult {

    const apiResult = response.result;
    if (apiResult) {

        const result: LookupResult = {
            moreResultsAvailable: apiResult.more_results_available
        }
        if (apiResult.confidence) {
            result.confidence = lookupConfidence(apiResult.confidence);
        }
        if (apiResult.suggestions_key) {
            result.suggestionsKey = apiResult.suggestions_key;
        }
        if (apiResult.suggestions_prompt) {
            result.suggestionsPrompt = apiResult.suggestions_prompt;
        }
        if (apiResult.suggestions) {
            result.suggestions = apiResult.suggestions.map(s => restApiResponseToLookupSuggestion(s));
        }
        if (apiResult.addresses) {
            result.addresses = apiResult.addresses.map(a => restApiResponseToLookupAddressSuggestionV2Hub(a));
        }
        if (apiResult.addresses_formatted) {
            result.addressesFormatted = apiResult.addresses_formatted.map( af => restApiResponseToLookupAddressFormatted(af));
        }
        return result;
    } else {
        return {moreResultsAvailable: false}
    }

}