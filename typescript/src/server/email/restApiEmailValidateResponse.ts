import { RestApiResponseError } from "../restApiResponseError";
import { RestApiEmailMetadata } from "./restApiEmailMetadata";
import { RestApiEmailValidateResult } from "./restApiEmailValidateResult";

export type RestApiEmailValidateResponse = {
    error?: RestApiResponseError;
    result?: RestApiEmailValidateResult;
    metadata?: RestApiEmailMetadata;
};