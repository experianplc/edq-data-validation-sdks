import { RestApiAddressFormatComponents } from "../format/restApiAddressFormatComponents";
import { RestApiAddressFormatted } from "../format/restApiAddressFormatted";
import { RestApiFormatAddress } from "../format/restApiFormatAddress";
import { RestApiValidationDetail } from "./restApiValidationDetail";
import { RestApiSearchResultSuggestion } from "../search/restApiSearchResultSuggestion";
import { RestApiAddressValidateMatchInfo } from "./restApiAddressValidateMatchInfo";

export type RestApiAddressValidateResult = {
    validation_detail?: RestApiValidationDetail;
    global_address_key?: string;
    more_results_available?: boolean;
    confidence?: string;
    address?: RestApiFormatAddress;
    addresses_formatted?: RestApiAddressFormatted[];
    components?: RestApiAddressFormatComponents;
    suggestions_key?: string;
    suggestions_prompt?: string;
    suggestions?: RestApiSearchResultSuggestion[];
    match_type?: string;
    match_confidence?: string;
    match_info?: RestApiAddressValidateMatchInfo;
};