import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiCreateLayoutResult } from "./restApiCreateLayoutResult";

export type RestApiCreateLayoutResponse = {
    error?: RestApiResponseError;
    result?: RestApiCreateLayoutResult;
};