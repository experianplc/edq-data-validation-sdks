import { RestApiAddressSearchResponse } from "../../server/address/search/restApiAddressSearchResponse";
import { Confidence, lookupConfidence } from "../confidence";
import { restApiResponseToSuggestion, Suggestion } from "./suggestion";

export type SearchResult = {
    moreResultsAvailable: boolean;
    confidence: Confidence;
    suggestionsKey: string;
    suggestionsPrompt: string;
    suggestions: Suggestion[];
}

export function restApiResponseToSearchResult(response: RestApiAddressSearchResponse): SearchResult {
        
    const apiResult = response.result;
    if (apiResult) {
        return {
            moreResultsAvailable: apiResult.more_results_available ?? false,
            confidence: lookupConfidence(apiResult.confidence),
            suggestionsKey: apiResult.suggestions_key??"",
            suggestionsPrompt: apiResult.suggestions_prompt??"",
            suggestions: apiResult.suggestions?.map(suggestion => restApiResponseToSuggestion(suggestion)) ?? []
        }
    } else {
        return {
            moreResultsAvailable: false,
            confidence: Confidence.Unknown,
            suggestionsKey: "",
            suggestionsPrompt: "",
            suggestions: []
        }
    }
}