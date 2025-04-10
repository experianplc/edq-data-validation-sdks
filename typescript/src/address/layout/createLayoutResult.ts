import { RestApiCreateLayoutResponse } from "../../server/address/layout/restApiCreateLayoutResponse";

export type CreateLayoutResult = {
    id: string;
};

export function restApiResponseToCreateLayoutResult(response: RestApiCreateLayoutResponse): CreateLayoutResult {
    return {id: response.result?.id??""}
}