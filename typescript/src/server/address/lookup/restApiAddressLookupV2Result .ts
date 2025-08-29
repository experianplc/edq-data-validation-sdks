import { RestApiAddressLookupSuggestion } from "./restApiAddresslookupSuggestion";
import { RestApiAddressLookupSuggestionV2 } from "./restApiAddressLookupSuggestionV2";
import { RestApiAddressLookupV2ResultAddressFormatted } from "./restApiAddressLookupV2ResultAddressFormatted";

export type RestApiAddressLookupV2Result = {
    more_results_available: boolean;
    confidence?: string;
    suggestions_key?: string;
    suggestions_prompt?: string;
    suggestions?: RestApiAddressLookupSuggestion[];
    addresses?: RestApiAddressLookupSuggestionV2[];
    addresses_formatted?: RestApiAddressLookupV2ResultAddressFormatted[];
};