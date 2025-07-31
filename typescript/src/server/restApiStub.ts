import { Configuration } from "../common/configuration";
import { EDVSError } from "../exceptions/edvsException";
import { RestApiGetDatasetsResponse } from "./address/datasets/restApiGetDatasetsResponse";
import { RestApiAddressSearchRequest } from "./address/restApiSearchRequest";
import { RestApiAddressSearchResponse } from "./address/search/restApiAddressSearchResponse";
import { RestApiAddressValidateRequest } from "./address/validate/restApiAddressValidateRequest";
import { RestApiAddressValidateResponse } from "./address/validate/restApiAddressValidateResponse";
import { RestApiFormatRequest } from "./address/format/restApiFormatRequest";
import { RestApiAddressFormatResponse } from "./address/format/restApiAddressFormatResponse";
import { RestApiSuggestionsRefineRequest } from "./address/suggestions/restApiSuggestionsRefineRequest";
import { RestApiSuggestionsFormatResponse } from "./address/suggestions/restApiSuggestionsFormatResponse";
import { RestApiSuggestionsFormatRequest } from "./address/suggestions/restApiSuggestionsFormatRequest";
import { RestApiEmailValidateRequest } from "./email/restApiEmailValidateRequest";
import { RestApiPhoneValidateRequest } from "./phone/restApiPhoneValidateRequest";
import { RestApiPhoneValidateResponse } from "./phone/restApiPhoneValidateResponse";
import { RestApiEmailValidateResponse } from "./email/restApiEmailValidateResponse";
import { RestApiCreateLayoutRequest } from "./address/layout/restApiCreateLayoutRequest";
import { RestApiCreateLayoutResponse } from "./address/layout/restApiCreateLayoutResponse";
import { RestApiResponseError } from "./restApiResponseError";
import { RestApiGetLayoutListResponse } from "./address/layout/restApiGetLayoutListResponse";
import { RestApiGetLayoutResponse } from "./address/layout/restApiGetLayoutResponse";
import { RestApiDeleteLayoutResponse } from "./address/layout/restApiDeleteLayoutResponse";
import { isDevMode } from "../testSetup";
import { RestApiAddressLookupV2Request } from "./address/lookup/restApiAddressLookupV2Request";
import { RestApiAddressLookupV2Response } from "./address/lookup/restApiAddressLookupV2Response";
import { RestApiResponse } from "./restApiResponse";

interface RestApiStub {
    // Address utilities
    searchV1(searchRequest: RestApiAddressSearchRequest, headers: Map<string, object>): Promise<RestApiAddressSearchResponse>;
    validateV1(validateRequest: RestApiAddressValidateRequest,  headers: Map<string, object>): Promise<RestApiAddressValidateResponse>
    getDatasetsV1(countryIso3: string, headers: Map<string, object> ): Promise<RestApiGetDatasetsResponse>
    formatV1(addressKey: string, formatRequest: RestApiFormatRequest, headers: Map<string, object>): Promise<RestApiAddressFormatResponse>;
    suggestionsStepInV1(globalAddressKey: string, headers: Map<string, object>): Promise<RestApiAddressSearchResponse>;
    suggestionsRefineV1(globalAddressKey: string, request: RestApiSuggestionsRefineRequest, headers: Map<string, object>): Promise<RestApiAddressSearchResponse>;
    suggestionsFormatV1(formatRequest: RestApiSuggestionsFormatRequest, headers: Map<string, object>): Promise<RestApiSuggestionsFormatResponse>
    validateEmailV2(request: RestApiEmailValidateRequest, headers: Map<string, object>): Promise<RestApiEmailValidateResponse>;
    validatePhoneV2(request: RestApiPhoneValidateRequest, headers: Map<string, object>): Promise<RestApiPhoneValidateResponse>;
    createLayoutV2(request: RestApiCreateLayoutRequest, headers: Map<string, object>): Promise<RestApiCreateLayoutResponse>;
    getLayoutV2(name: string, headers: Map<string, object>): Promise<RestApiGetLayoutResponse>
    getLayoutsV2(countryIso3: string, datasets: string[], nameContains: string, headers: Map<string, object>): Promise<RestApiGetLayoutListResponse>
    deleteLayoutV2(layoutName: string, headers: Map<string, object>): Promise<RestApiDeleteLayoutResponse>;
    lookupV2(request: RestApiAddressLookupV2Request, headers: Map<string, object>): Promise<RestApiAddressLookupV2Response>;
    
}

export class RestApiStubImpl implements RestApiStub {
    
    private readonly configuration: Configuration;
        
    constructor(configuration: Configuration) {
        this.configuration = configuration;
    }
    lookupV2(request: RestApiAddressLookupV2Request, headers: Map<string, object>): Promise<RestApiAddressLookupV2Response> {
        const endPoint = `address/lookup/v2`;
        return this.post<RestApiAddressLookupV2Response>(endPoint, request, headers);
    }
    deleteLayoutV2(layoutName: string, headers: Map<string, object>): Promise<RestApiDeleteLayoutResponse> {
        const endPoint = `address/layouts/v2/${layoutName}`;
        return this.delete(endPoint, headers, new Map());
    }
    getLayoutV2(layoutName: string, headers: Map<string, object>): Promise<RestApiGetLayoutResponse> {
        const endPoint = `address/layouts/v2/${layoutName}`;
        return this.get(endPoint, headers, new Map());
    }
    getLayoutsV2(countryIso3: string, datasets: string[], nameContains: string, headers: Map<string, object>): Promise<RestApiGetLayoutListResponse> {
        const endPoint = `address/layouts/v2/`;
            const parameters = new Map<string, string>();

            if (countryIso3)
            {
                parameters.set("country_iso", countryIso3);
            }

            if (datasets && datasets.length > 0)
            {
                parameters.set("datasets", datasets.join(","));
            }
            
            if (nameContains)
            {
                parameters.set("name_contains", nameContains);
            }

            return this.get(endPoint, headers, parameters);
    }
    createLayoutV2(request: RestApiCreateLayoutRequest, headers: Map<string, object>): Promise<RestApiCreateLayoutResponse> {
        const endPoint = "address/layouts/v2";
        return this.post<RestApiCreateLayoutResponse>(endPoint, request, headers);
    }
    validatePhoneV2(request: RestApiPhoneValidateRequest, headers: Map<string, object>): Promise<RestApiPhoneValidateResponse> {
        const endPoint = "phone/validate/v2";
        return this.post<RestApiPhoneValidateResponse>(endPoint, request, headers);
    }
    validateEmailV2(request: RestApiEmailValidateRequest, headers: Map<string, object>): Promise<RestApiEmailValidateResponse> {
        const endPoint = "email/validate/v2";
        return this.post<RestApiEmailValidateResponse>(endPoint, request, headers);
    }
    suggestionsFormatV1(formatRequest: RestApiSuggestionsFormatRequest, headers: Map<string, object>): Promise<RestApiSuggestionsFormatResponse> {
        const endPoint = `/address/suggestions/format/v1/`;
        return this.post<RestApiSuggestionsFormatResponse>(endPoint, formatRequest, headers);
    }
    suggestionsRefineV1(globalAddressKey: string, request: RestApiSuggestionsRefineRequest, headers: Map<string, object>): Promise<RestApiAddressSearchResponse> {
        const endPoint = `/address/suggestions/refine/v1/${globalAddressKey}`;
        return this.post<RestApiAddressFormatResponse>(endPoint, request, headers);
    }
    suggestionsStepInV1(globalAddressKey: string, headers: Map<string, object>): Promise<RestApiAddressSearchResponse> {
        const endPoint = `/address/suggestions/stepin/v1/${globalAddressKey}`;
        return this.get(endPoint, headers, new Map());
    }
    formatV1(addressKey: string, formatRequest: RestApiFormatRequest, headers: Map<string, object>): Promise<RestApiAddressFormatResponse> {
        const endPoint = `address/format/v1/${addressKey}`;
        return this.post<RestApiAddressFormatResponse>(endPoint, formatRequest, headers);
    }
    async validateV1(validateRequest: RestApiAddressValidateRequest, headers: Map<string, object>): Promise<RestApiAddressValidateResponse> {
        const endPoint = "address/validate/v1";
        return this.post<RestApiAddressValidateResponse>(endPoint, validateRequest, headers);
    }
    async searchV1(searchRequest: RestApiAddressSearchRequest, headers: Map<string, object>): Promise<RestApiAddressSearchResponse> {
        const endPoint = "address/search/v1";
        return this.post<RestApiAddressSearchResponse>(endPoint, searchRequest, headers);
    }

    async getDatasetsV1(countryIso3: string, headers: Map<string, object>): Promise<RestApiGetDatasetsResponse> {
        const endPoint = "address/datasets/v1";
        const parameters = new Map<string, string>([["country_iso", countryIso3]]);
        return this.get<RestApiGetDatasetsResponse>(endPoint, headers, parameters);
    }

    private async fetchImpl<T>(endPoint: string ,method: string, headers: Map<string, object>, parameters: Map<string, string>, body?: string): Promise<T> {
        const response =  await this.executeWithRetry(async () => {

            const url = new URL(endPoint, Configuration.serverUri);
            parameters.forEach((value, key) => {
                url.searchParams.append(key, value);
            });

            const requestHeaders: HeadersInit = {};
            headers.forEach((value, key) => {
                requestHeaders[key] = value.toString();
            });
            
            if (body) {
                requestHeaders['Content-Type'] = 'application/json';
            }

            const controller = new AbortController();
            const timeout = setTimeout(() => {
                controller.abort();
            }, this.configuration.options.httpClientTimeoutInSeconds! * 1000);

            const request: RequestInit = {
                method: method,
                headers: requestHeaders,
                signal: controller.signal
            }
            if (body) {
                request.body = body;
            }
            
            const urlString = url.toString();
            if (isDevMode()) {
                process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";
            }
            return await fetch(urlString, request)
            .then( response => {
                clearTimeout(timeout);
                return response;
            }).catch(error => {
                if (error.name === 'AbortError') {
                    throw new EDVSError("Request timed out")
                }
                throw error;
            });
        });

        const error = await this.getOptionalError(response);
        if (error) {
            throw EDVSError.using(error);
        } else {
            const resp = await response.json();
            resp.referenceId = this.getRefIdFromHeaderValue(response.headers.get("reference-id"));
            return resp;
        }
    }
    
    private async post<T>(endPoint: string, requestObject: any, headers: Map<string, object>, ): Promise<T> {
        return this.fetchImpl(endPoint, 'POST', headers, new Map(), JSON.stringify(requestObject));
    }

    private async get<T>(endPoint: string, headers: Map<string, object>, parameters: Map<string, string>): Promise<T> {
        return this.fetchImpl(endPoint, 'GET', headers, parameters);
    }

    private async delete<T>(endPoint: string, headers: Map<string, object>, parameters: Map<string, string>): Promise<T> {
        return this.fetchImpl(endPoint, 'DELETE', headers, parameters);
    }

    private async executeWithRetry<T>(fn: () => Promise<Response>): Promise<Response>  {

        let attempt = 0;
        let delay = this.configuration.options.initialDelayInMilliseconds!;

        while (attempt < this.configuration.options.maxRetries!) {
            try {
                const response = await fn();
                if (this.isHandledResponse(response)) {
                    return response;
                }
                throw new EDVSError(`Server error: ${response.status}`);
            } catch (error) {
                attempt++;
                if (attempt >= this.configuration.options.maxRetries!) {
                    throw error;
                }

                await new Promise(resolve => setTimeout(resolve, delay));
                delay = Math.min(delay * 2, this.configuration.options.maxDelayInMilliseconds!);
            }
        }
        throw new EDVSError("Max retry attempts exceeded.");
    };

    private isHandledResponse(response: Response): boolean {
        if (response.ok) {
            return true;
        }
        if (response.status >= 400 && response.status < 500) {
            return true;
        }
        return false;
    }

    private async getOptionalError(response: Response): Promise<RestApiResponseError | undefined> {
        if (response.status !== 202 && !response.ok) { // HTTP Status 'Accepted' is 202
            const body = await response.json();
            if (body && body.error) {
                return body.error;
            }
            const error: RestApiResponseError = {
                type: response.status.toString(),
                title: response.statusText,
                detail: response.statusText
            }
            
            return error;
        }
        return undefined;
    }

    private getRefIdFromHeaderValue(referenceId: string|null): string|null {
        const pattern = "/transaction:";
        if (referenceId != null && referenceId.includes(pattern))
        {
            referenceId = referenceId.substring(referenceId.lastIndexOf(pattern)+ pattern.length);
        }
        return referenceId;
    }
}