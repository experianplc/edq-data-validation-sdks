import { RestApiAddressSearchResponse } from "../../server/address/search/restApiAddressSearchResponse";
import { AddressConfidence, lookupConfidence } from "../addressConfidence";
import { restApiResponseToSuggestion, SearchSuggestion } from "./searchSuggestion";

export type SearchResult = {
    moreResultsAvailable: boolean;
    confidence: AddressConfidence;
    suggestionsKey: string;
    suggestionsPrompt: string;
    suggestions: SearchSuggestion[];
    referenceId?: string;
}

export function restApiResponseToSearchResult(response: RestApiAddressSearchResponse): SearchResult {
        
    const apiResult = response.result;
    if (apiResult) {
        return {
            moreResultsAvailable: apiResult.more_results_available ?? false,
            confidence: lookupConfidence(apiResult.confidence),
            suggestionsKey: apiResult.suggestions_key??"",
            suggestionsPrompt: apiResult.suggestions_prompt??"",
            suggestions: apiResult.suggestions?.map(suggestion => restApiResponseToSuggestion(suggestion)) ?? [],
            referenceId: response.referenceId,
        }
    } else {
        return {
            moreResultsAvailable: false,
            confidence: AddressConfidence.Unknown,
            suggestionsKey: "",
            suggestionsPrompt: "",
            suggestions: [],
            referenceId: response.referenceId
        }
    }
}