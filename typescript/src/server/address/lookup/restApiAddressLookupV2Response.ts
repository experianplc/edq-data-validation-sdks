import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiAddressLookupV2Result } from "./restApiAddressLookupV2Result ";

export type RestApiAddressLookupV2Response = {
    error?: RestApiResponseError;
    result?: RestApiAddressLookupV2Result
}