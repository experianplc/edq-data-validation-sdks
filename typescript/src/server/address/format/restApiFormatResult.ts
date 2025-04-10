import { RestApiAddressFormatComponents } from "./restApiAddressFormatComponents";
import { RestApiAddressFormatted } from "./restApiAddressFormatted";
import { RestApiFormatAddress } from "./restApiFormatAddress";

export type RestApiFormatResult = {
    global_address_key?: string;
    confidence?: string;
    address?: RestApiFormatAddress;
    addresses_formatted?: RestApiAddressFormatted[];
    components?: RestApiAddressFormatComponents;
};