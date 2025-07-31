import { RestApiResponse } from "../../restApiResponse";
import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiCreateLayoutResult } from "./restApiCreateLayoutResult";

export type RestApiCreateLayoutResponse = RestApiResponse & {
    error?: RestApiResponseError;
    result?: RestApiCreateLayoutResult;
};