import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiEnrichmentMetadata } from "./restApiEnrichmentMetadata";
import { RestApiEnrichmentResultAddress } from "./restApiEnrichmentResultAddress";

export type RestApiAddressFormatEnrichment = {
    error?: RestApiResponseError;
    transaction_id?: string;
    result?: RestApiEnrichmentResultAddress;
    metadata?: RestApiEnrichmentMetadata;
};