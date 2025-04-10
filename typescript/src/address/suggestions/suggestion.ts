import { RestApiSuggestionsFormatSuggestion } from "../../server/address/suggestions/restApiSuggestionsFormatSuggestion";
import { AddressComponents, restApiResponseToAddressComponents } from "../format/addressComponents";
import { AddressFormatted, restApiToAddressFormatted } from "../format/addressFormatted";
import { AddressMetadata, restApiResponseToAddressMetadata } from "../format/addressMetadata";
import { FormatAddress, restApiResponseToFormatAddress } from "../format/formatAddress";

export type Suggestion = {
    globalAddressKey?: string;
    address?: FormatAddress;
    addressFormatted?: AddressFormatted[];
    components?: AddressComponents;
    metadata?: AddressMetadata;
};

export function restApiResponseToSuggestion(response: RestApiSuggestionsFormatSuggestion): Suggestion {

    const result: Suggestion = {
        globalAddressKey: response.global_address_key
    }
    if (response.address) {
        result.address = restApiResponseToFormatAddress(response.address);
    }
    if (response.addresses_formatted) {
        result.addressFormatted = response.addresses_formatted.map(addr => restApiToAddressFormatted(addr));
    }
    if (response.components) {
        result.components = restApiResponseToAddressComponents(response.components);
    }
    if (response.metadata) {
        result.metadata = restApiResponseToAddressMetadata(response.metadata);
    }

    return result;

}
