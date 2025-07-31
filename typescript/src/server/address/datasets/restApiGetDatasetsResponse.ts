import { RestApiResponse } from "../../restApiResponse";
import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiAddressDatasetResult } from "./restApiAddressDatasetResult";

export type RestApiGetDatasetsResponse = RestApiResponse & {
    error?: RestApiResponseError;
    result?: RestApiAddressDatasetResult[];
}
