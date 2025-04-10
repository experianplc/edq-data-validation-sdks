import { RestApiAddressFormatComponents } from "../format/restApiAddressFormatComponents";
import { RestApiAddressFormatMetadata } from "../format/restApiAddressFormatMetadata";
import { RestApiAddressFormatted } from "../format/restApiAddressFormatted";
import { RestApiFormatAddress } from "../format/restApiFormatAddress";

export type RestApiSuggestionsFormatSuggestion = {
    global_address_key?: string;
    address?: RestApiFormatAddress;
    addresses_formatted?: RestApiAddressFormatted[];
    components?: RestApiAddressFormatComponents;
    metadata?: RestApiAddressFormatMetadata;
};