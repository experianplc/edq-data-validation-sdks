import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiSuggestionsFormatResult } from "./restApiSuggestionsFormatResult";

export type RestApiSuggestionsFormatResponse = {
    error?: RestApiResponseError;
    result?: RestApiSuggestionsFormatResult;
};