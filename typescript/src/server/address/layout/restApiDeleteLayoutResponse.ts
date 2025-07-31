import { RestApiResponse } from "../../restApiResponse";
import { RestApiResponseError } from "../../restApiResponseError";

export type RestApiDeleteLayoutResponse = RestApiResponse & {
    error?: RestApiResponseError;
};