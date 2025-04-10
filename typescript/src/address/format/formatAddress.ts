import { RestApiFormatAddress } from "../../server/address/format/restApiFormatAddress";

export type FormatAddress = {
    addressLine1: string;
    addressLine2: string;
    addressLine3: string;
    locality: string;
    region: string;
    postalCode: string;
    country: string;
}

export function restApiResponseToFormatAddress(response: RestApiFormatAddress): FormatAddress {
    return {
        addressLine1: response.address_line_1??"",
        addressLine2: response.address_line_2??"",
        addressLine3: response.address_line_3??"",
        locality: response.locality??"",
        region: response.region??"",
        postalCode: response.postal_code??"",
        country: response.country??""
    }
}