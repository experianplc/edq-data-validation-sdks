import { RestApiSearchResultSuggestion } from "./restApiSearchResultSuggestion";

export type RestApiAddressSearchResult = {
    more_results_available?: boolean;
    confidence?: string;
    suggestions_key?: string;
    suggestions_prompt?: string;
    suggestions?: RestApiSearchResultSuggestion[]
}