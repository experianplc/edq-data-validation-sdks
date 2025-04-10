import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiGetLayoutResult } from "./restApiGetLayoutResult";

export type RestApiGetLayoutResponse = {
    error?: RestApiResponseError;
    result?: RestApiGetLayoutResult;
};