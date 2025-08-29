import { RestApiAddressLookupSuggestionV2 } from "../../server/address/lookup/restApiAddressLookupSuggestionV2";

export type LookupAddressSuggestionV2 = {
    text?: string;
    matched?: number[];
    globalAddressKey?: string;
    format?: string;
    dataset?: string;
    names?: string[];
    uprn?: string;
}

export function restApiResponseToLookupAddressSuggestionV2Hub(response: RestApiAddressLookupSuggestionV2): LookupAddressSuggestionV2 {
    const result: LookupAddressSuggestionV2 = {
        text: response.text,
        matched: response.matched,
        globalAddressKey: response.global_address_key,
        format: response.format,
        dataset: response.dataset,
        names: response.names,
        uprn: response.uprn
    }
    return result;
}