import { RestApiSuggestionsFormatResponse } from "../../server/address/suggestions/restApiSuggestionsFormatResponse";
import { AddressConfidence, lookupConfidence } from "../addressConfidence";
import { restApiResponseToSuggestion, suggestionsFormatSuggestion } from "./suggestionsFormatSuggestion";

export type SuggestionsFormatResult = {
    moreResultsAvailable: boolean;
    confidence?: AddressConfidence;
    suggestions: suggestionsFormatSuggestion[];
    referenceId?: string;
};

export function restApiResponseToSuggestionsResult(response: RestApiSuggestionsFormatResponse): SuggestionsFormatResult {

    const apiResult = response.result;
    if (apiResult) {
        return {
            moreResultsAvailable: apiResult.more_results_available??false,
            confidence: lookupConfidence(apiResult.confidence),
            suggestions: apiResult.suggestions ? apiResult.suggestions.map(p => restApiResponseToSuggestion(p)): [],
            referenceId: response.referenceId
        }
    } else {
        return {
            moreResultsAvailable: false,
            confidence: AddressConfidence.Unknown,
            suggestions: [],
            referenceId: response.referenceId
        }
    }
}