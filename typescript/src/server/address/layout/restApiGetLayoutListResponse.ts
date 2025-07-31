import { RestApiResponse } from "../../restApiResponse";
import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiGetLayoutsListItem } from "./restApiGetLayoutsListItem";

export type RestApiGetLayoutListResponse = RestApiResponse & {
    error?: RestApiResponseError;
    result?: RestApiGetLayoutsListItem[];
};