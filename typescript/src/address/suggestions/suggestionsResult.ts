import { RestApiSuggestionsFormatResponse } from "../../server/address/suggestions/restApiSuggestionsFormatResponse";
import { Confidence, lookupConfidence } from "../confidence";
import { restApiResponseToSuggestion, Suggestion } from "./suggestion";

export type SuggestionsResult = {
    moreResultsAvailable: boolean;
    confidence?: Confidence;
    suggestions: Suggestion[];
};

export function restApiResponseToSuggestionsResult(response: RestApiSuggestionsFormatResponse): SuggestionsResult {

    const apiResult = response.result;
    if (apiResult) {
        return {
            moreResultsAvailable: apiResult.more_results_available??false,
            confidence: lookupConfidence(apiResult.confidence),
            suggestions: apiResult.suggestions ? apiResult.suggestions.map(p => restApiResponseToSuggestion(p)): []
        }
    } else {
        return {
            moreResultsAvailable: false,
            confidence: Confidence.Unknown,
            suggestions: []
        }
    }
}