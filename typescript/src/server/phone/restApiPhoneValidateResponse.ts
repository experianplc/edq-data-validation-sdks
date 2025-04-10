import { RestApiResponseError } from "../restApiResponseError";
import { RestApiPhoneValidateMetadata } from "./restApiPhoneValidateMetadata";
import { RestApiPhoneValidateResult } from "./restApiPhoneValidateResult";

export type RestApiPhoneValidateResponse = {
    error?: RestApiResponseError;
    result?: RestApiPhoneValidateResult;
    metadata?: RestApiPhoneValidateMetadata;
};