import { RestApiResponse } from "../../restApiResponse";
import { RestApiResponseError } from "../../restApiResponseError"
import { RestApiAddressSearchResult } from "./restApiAddressSearchResult";

export type RestApiAddressSearchResponse = RestApiResponse & {
    error?: RestApiResponseError;
    result?: RestApiAddressSearchResult;
}