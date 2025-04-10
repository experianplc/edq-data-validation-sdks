import { RestApiCommercialMosaicElements } from "./restApiCommercialMosaicElements";
import { RestApiEnrichmentLocationElements } from "./restApiEnrichmentLocationElements";
import { RestApiStandardIndustryClassificationElements } from "./restApiStandardIndustryClassificationElements";

export type RestApiEnrichmentGbAdditional = {
    urn?: string;
    commercial_mosaic?: RestApiCommercialMosaicElements;
    registration?: string;
    non_limited_company_key?: string;
    phone?: string;
    number_of_employees?: string;
    standard_industry_classification?: RestApiStandardIndustryClassificationElements;
    location?: RestApiEnrichmentLocationElements;
};