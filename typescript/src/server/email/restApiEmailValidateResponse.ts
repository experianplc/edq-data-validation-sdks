import { RestApiResponse } from "../restApiResponse";
import { RestApiResponseError } from "../restApiResponseError";
import { RestApiEmailMetadata } from "./restApiEmailMetadata";
import { RestApiEmailValidateResult } from "./restApiEmailValidateResult";

export type RestApiEmailValidateResponse = RestApiResponse & {
    error?: RestApiResponseError;
    result?: RestApiEmailValidateResult;
    metadata?: RestApiEmailMetadata;
};