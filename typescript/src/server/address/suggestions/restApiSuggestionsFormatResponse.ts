import { RestApiResponse } from "../../restApiResponse";
import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiSuggestionsFormatResult } from "./restApiSuggestionsFormatResult";

export type RestApiSuggestionsFormatResponse = RestApiResponse & {
    error?: RestApiResponseError;
    result?: RestApiSuggestionsFormatResult;
};