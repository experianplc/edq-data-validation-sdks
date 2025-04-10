import { RestApiResponseError } from "../../restApiResponseError"
import { RestApiAddressSearchResult } from "./restApiAddressSearchResult";

export type RestApiAddressSearchResponse = {
    error?: RestApiResponseError;
    result?: RestApiAddressSearchResult;
}