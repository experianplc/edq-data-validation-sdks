import { RestApiResponse } from "../../restApiResponse";
import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiGetLayoutResult } from "./restApiGetLayoutResult";

export type RestApiGetLayoutResponse = RestApiResponse & {
    error?: RestApiResponseError;
    result?: RestApiGetLayoutResult;
};