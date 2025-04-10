import { RestApiEnrichmentGbAdditional } from "../../../server/address/format/restApiEnrichmentGbAdditional";
import { CommercialMosaicElements } from "./commercialMosaicElements";
import { LocationElements } from "./locationElements";
import { StandardIndustryClassificationElements } from "./standardIndustryClassificationElements";

export type GbrBusiness = {
    urn?: string;
    commercialMosaic?: CommercialMosaicElements;
    registration?: string;
    nonLimitedCompanyKey?: string;
    phone?: string;
    numberOfEmployees?: string;
    standardIndustryClassification?: StandardIndustryClassificationElements;
    location?: LocationElements;
};

export function restApiResponseToGbrBusiness(response: RestApiEnrichmentGbAdditional): GbrBusiness {
    return {
        urn: response.urn ?? "",
        commercialMosaic: response.commercial_mosaic ? {
            groupTypeCode: response.commercial_mosaic.group_type_code ?? "",
            groupTypeDescription: response.commercial_mosaic.group_type_description ?? "",
            groupCode: response.commercial_mosaic.group_code ?? "",
            groupDescription: response.commercial_mosaic.group_description ?? "",
        }: undefined,
        registration: response.registration,
        nonLimitedCompanyKey: response.non_limited_company_key??"",
        phone: response.phone,
        numberOfEmployees: response.number_of_employees,
        standardIndustryClassification: response.standard_industry_classification ? {
            sic2007Code: response.standard_industry_classification.sic_2007_code ?? "",
            sic2007Description: response.standard_industry_classification.sic_2007_description ?? "",
            thomsonCode: response.standard_industry_classification.thomson_code ?? "",
            thomsonDescription: response.standard_industry_classification.thomson_description ?? ""
        } : undefined,
        location: response.location ? {
            code: response.location.code??"",
            description: response.location.description??"",
            smallOrHomeOffice: response.location.small_or_home_office??""
        } : undefined
    };
}