import { RestApiEnrichmentGbrHealth } from "../../../server/address/format/restApiEnrichmentGbrHealth";

export type GbrHealth = {
    authorityCode: string;
    authorityCode2011: string;
    authorityName: string;
    pclhCode: string;
    pclhCode2011: string;
    pclhName: string;
    wardCode: string;
    wardCode2011: string;
    wardName: string;
    ccgCode: string;
    ccgName: string;
    dohCode: string;
};

export function restApiResponseToGbrHealth(response: RestApiEnrichmentGbrHealth): GbrHealth {
    return {
        authorityCode: response.authority_code ?? "",
        authorityCode2011: response.authority_code_2011 ?? "",
        authorityName: response.authority_name ?? "",
        pclhCode: response.pclh_code ?? "",
        pclhCode2011: response.pclh_code_2011 ?? "",
        pclhName: response.pclh_name ?? "",
        wardCode: response.ward_code ?? "",
        wardCode2011: response.ward_code_2011 ?? "",
        wardName: response.ward_name ?? "",
        ccgCode: response.ccg_code ?? "",
        ccgName: response.ccg_name ?? "",
        dohCode: response.doh_code ?? ""
    };
}