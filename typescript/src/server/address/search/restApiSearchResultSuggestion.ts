import { RestApiSearchResultAdditionalAttribute } from "./restApiSearchResultAdditionalAttribute";

export type RestApiSearchResultSuggestion = {
    global_address_key?: string;
    text?: string;
    matched?: number[][],
    format?: string;
    dataset?: string;
    additional_attributes?: RestApiSearchResultAdditionalAttribute[]
}
