import { RestApiSuggestionsFormatSuggestion } from "./restApiSuggestionsFormatSuggestion";

export type RestApiSuggestionsFormatResult = {
    more_results_available: boolean;
    confidence?: string;
    suggestions?: RestApiSuggestionsFormatSuggestion[];
};