import { RestApiResponse } from "../restApiResponse";
import { RestApiResponseError } from "../restApiResponseError";
import { RestApiPhoneValidateMetadata } from "./restApiPhoneValidateMetadata";
import { RestApiPhoneValidateResult } from "./restApiPhoneValidateResult";

export type RestApiPhoneValidateResponse = RestApiResponse & {
    error?: RestApiResponseError;
    result?: RestApiPhoneValidateResult;
    metadata?: RestApiPhoneValidateMetadata;
};