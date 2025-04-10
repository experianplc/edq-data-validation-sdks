import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiAddressFormatEnrichment } from "../format/restApiAddressFormatEnrichment";
import { RestApiAddressFormatMetadata } from "../format/restApiAddressFormatMetadata";
import { RestApiAddressValidateResult } from "./restApiAddressValidateResult";

export type RestApiAddressValidateResponse = {
    error?: RestApiResponseError;
    result?: RestApiAddressValidateResult;
    metadata?: RestApiAddressFormatMetadata;
    enrichment?: RestApiAddressFormatEnrichment;
};