import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiAddressDatasetResult } from "./restApiAddressDatasetResult";

export interface RestApiGetDatasetsResponse {
    error?: RestApiResponseError;
    result?: RestApiAddressDatasetResult[];
}
