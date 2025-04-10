import { RestApiResponseError } from "../../restApiResponseError";
import { RestApiGetLayoutsListItem } from "./restApiGetLayoutsListItem";

export type RestApiGetLayoutListResponse = {
    error?: RestApiResponseError;
    result?: RestApiGetLayoutsListItem[];
};