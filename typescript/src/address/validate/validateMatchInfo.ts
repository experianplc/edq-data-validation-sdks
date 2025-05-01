import { RestApiAddressValidateMatchInfo } from "../../server/address/validate/restApiAddressValidateMatchInfo";
import { AddressAction, lookupAddressAction } from "./addressAction";
import { lookupPostalCodeAction, PostalCodeAction } from "./postalCodeAction";

export type ValidateMatchInfo = {
    postalCodeAction: PostalCodeAction;
    addressAction: AddressAction;
    generic_info?: string[];
    aus_info?: string[];
    fra_info?: string[];
    deu_info?: string[];
    gbr_info?: string[];
    nld_info?: string[];
    nzl_info?: string[];
    sgp_info?: string[];
};

export function restApiToValidateMatchInfo(response: RestApiAddressValidateMatchInfo): ValidateMatchInfo {
    return {
        postalCodeAction: lookupPostalCodeAction(response.postcode_action),
        addressAction: lookupAddressAction(response.address_action),
        generic_info: response.generic_info,
        aus_info: response.aus_info,
        deu_info: response.deu_info,
        fra_info: response.fra_info,
        gbr_info: response.gbr_info,
        nld_info: response.nld_info,
        nzl_info: response.nzl_info,
        sgp_info: response.sgp_info,
    }
}
