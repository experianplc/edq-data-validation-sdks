import { RestApiValidationDetail } from "../../server/address/validate/restApiValidationDetail";

export type ValidationDetail = {
    buildingFirmNameCorrected: boolean;
    primaryNumberCorrected: boolean;
    streetCorrected: boolean;
    ruralRouteHighwayContractMatched: boolean;
    cityNameCorrected: boolean;
    cityNameAliasMatched: boolean;
    stateCorrected: boolean;
    zipCodeCorrected: boolean;
    secondaryNumRetained: boolean;
    idenPreStInfoRetained: boolean;
    genPreStInfoRetained: boolean;
    postStInfoRetained: boolean;
};

export function restApiToValidationDetail(response: RestApiValidationDetail): ValidationDetail {
    return {
        buildingFirmNameCorrected: response.building_firm_name_corrected??false,
        primaryNumberCorrected: response.primary_number_corrected??false,
        streetCorrected: response.street_corrected??false,
        ruralRouteHighwayContractMatched: response.rural_route_highway_contract_matched??false,
        cityNameCorrected: response.city_name_corrected ?? false,
        cityNameAliasMatched: response.city_name_alias_matched ?? false,
        stateCorrected: response.state_corrected ?? false,
        zipCodeCorrected: response.zip_code_corrected ?? false,
        secondaryNumRetained: response.secondary_num_retained ?? false,
        idenPreStInfoRetained: response.iden_pre_st_info_retained ?? false,
        genPreStInfoRetained: response.gen_pre_st_info_retained ?? false,
        postStInfoRetained: response.post_st_info_retained ?? false


    }
}
