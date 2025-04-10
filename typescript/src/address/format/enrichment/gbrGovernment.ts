import { RestApiEnrichmentGbrGovernment } from "../../../server/address/format/restApiEnrichmentGbrGovernment";

export type GbrGovernment = {
    eerCode: string;
    eerCodePre2011: string;
    eerName: string;
    gorCode: string;
    gorCodePre2011: string;
    gorName: string;
    leaCode: string;
    leaName: string;
    laCode: string;
    laCodePre2011: string;
    laName: string;
    wardCode: string;
    wardCodePre2011: string;
    wardName: string;
    censOutArea: string;
};

export function restApiResponseToGbrGovernment(response: RestApiEnrichmentGbrGovernment): GbrGovernment {
    return {
        eerCode: response.eer_code ?? "",
        eerCodePre2011: response.eer_code_pre_2011 ?? "",
        eerName: response.eer_name ?? "",
        gorCode: response.gor_code ?? "",
        gorCodePre2011: response.gor_code_pre_2011 ?? "",
        gorName: response.gor_name ?? "",
        leaCode: response.lea_code ?? "",
        leaName: response.lea_name ?? "",
        laCode: response.la_code ?? "",
        laCodePre2011: response.la_code_pre_2011 ?? "",
        laName: response.la_name ?? "",
        wardCode: response.ward_code ?? "",
        wardCodePre2011: response.ward_code_pre_2011 ?? "",
        wardName: response.ward_name ?? "",
        censOutArea: response.cens_out_area ?? ""
    };
}