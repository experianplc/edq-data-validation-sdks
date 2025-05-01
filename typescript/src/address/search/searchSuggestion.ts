import { RestApiSearchResultSuggestion } from "../../server/address/search/restApiSearchResultSuggestion";
import { AdditionalAttribute } from "./additionalAttribute";

export type SearchSuggestion = {
    globalAddressKey: string;
    text: string;
    matched: number[][];
    formatUrl: string;
    dataset: string;
    additionalAttributes: AdditionalAttribute[]
}

export function restApiResponseToSuggestion(response: RestApiSearchResultSuggestion): SearchSuggestion {
    return {
        globalAddressKey: response.global_address_key??"",
        text: response.text??"",
        matched: response.matched??[],
        formatUrl: response.format??"",
        dataset: response.dataset??"",
        additionalAttributes: response.additional_attributes ? response.additional_attributes.map(attr => ({name: attr.name, value: attr.value})) : []

    }
}