import { RestApiResponseError } from "../server/restApiResponseError";

export type ResponseError = {
    type: string;
    title: string;
    detail: string;
    instance: string;
};

export function restApiResponseError2ResponseError(err: RestApiResponseError): ResponseError {
    return {
        type: err.type ?? '',
        title: err.title ?? '',
        detail: err.detail ?? '',
        instance: err.instance ?? ''
    };
}

