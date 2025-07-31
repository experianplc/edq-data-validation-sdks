import { RestApiResponse } from "../../restApiResponse";
import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiAddressFormatEnrichment } from "./restApiAddressFormatEnrichment";
import { RestApiAddressFormatMetadata } from "./restApiAddressFormatMetadata";
import { RestApiFormatResult } from "./restApiFormatResult";

export type RestApiAddressFormatResponse = RestApiResponse & {
    error?: RestApiResponseError;
    result?: RestApiFormatResult;
    metadata?: RestApiAddressFormatMetadata;
    enrichment?: RestApiAddressFormatEnrichment;
};