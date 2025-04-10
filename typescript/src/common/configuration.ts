import { randomUUID } from 'node:crypto';
import { InvalidConfigurationError } from '../exceptions/edvsException';
export const defaultApiRequestTimeoutInSeconds = 15;
export const defaultHttpClientTimeoutInSeconds = 20;
export const defaultRetries = 5;
export const defaultInitialDelayInMilliseconds = 1000;
export const defaultMaxDelayInMilliseconds = 15000;

export interface ConfigurationOptions {
    alternativeToken?: string;
    transactionId?: string;
    apiRequestTimeoutInSeconds?: number;
    httpClientTimeoutInSeconds?: number;
    maxRetries?: number;
    initialDelayInMilliseconds?: number;
    maxDelayInMilliseconds?: number;
}

export abstract class Configuration {
    public static readonly serverUri: string = "https://api.experianaperture.io/";
    public token: string;
    public options: ConfigurationOptions;

    constructor(token: string, options: ConfigurationOptions) {

        if (!token || token.length == 0) {
            throw new InvalidConfigurationError("The supplied configuration must contain an authorisation token");
        }

        this.token = token;
        this.options = options;
        
        
    }

    protected static applyDefaultOptions(options: ConfigurationOptions) : ConfigurationOptions {
        const result = {...options};
        result.apiRequestTimeoutInSeconds = options.apiRequestTimeoutInSeconds ?? defaultApiRequestTimeoutInSeconds; 
        result.httpClientTimeoutInSeconds = options.httpClientTimeoutInSeconds ?? defaultHttpClientTimeoutInSeconds;
        result.maxRetries = options.maxRetries ?? defaultRetries;
        result.initialDelayInMilliseconds = options.initialDelayInMilliseconds ?? defaultInitialDelayInMilliseconds;
        result.maxDelayInMilliseconds = options.maxDelayInMilliseconds ?? defaultMaxDelayInMilliseconds;

        return result;

    }

    public getCommonHeaders(allowsDotInReferenceId: boolean = true): Map<string, object> {
        const headers = new Map<string, object>();

        if (this.options.alternativeToken) {
            headers.set("x-app-key", this.options.alternativeToken as String); // NOSONAR
        } else {
            headers.set("Auth-Token", this.token as String); // NOSONAR
        }

        let transactionId = this.options.transactionId;

        if (!transactionId) {
            transactionId = randomUUID();
        }
        headers.set("Reference-Id", this.getReference(transactionId, allowsDotInReferenceId) as String); // NOSONAR

        if (this.options.apiRequestTimeoutInSeconds !== defaultHttpClientTimeoutInSeconds) {
            headers.set("Timeout-Seconds", this.options.apiRequestTimeoutInSeconds!.toString() as String); // NOSONAR
        }

        return headers;
    }

    private getReference(uuid: string, allowsDotInReferenceId: boolean = true): string {
        let version = "1.0.0"; // Replace with actual version retrieval logic
        const product = "SDK";
        const iface = "Typescript";

        if (!allowsDotInReferenceId) {
            version = version.replace(/\./g, '-');
        }

        return `product:${product}/version:${version}/interface:${iface}/transaction:${uuid}`;
    }
        
}


