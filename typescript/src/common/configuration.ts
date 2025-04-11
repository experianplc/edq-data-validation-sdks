import { randomUUID } from 'node:crypto';
import { InvalidConfigurationError } from '../exceptions/edvsException';

export const defaultApiRequestTimeoutInSeconds = 15;
export const defaultHttpClientTimeoutInSeconds = 20;
export const defaultRetries = 5;
export const defaultInitialDelayInMilliseconds = 1000;
export const defaultMaxDelayInMilliseconds = 15000;

/**
 * Interface defining the options for configuring the client.
 */
export interface ConfigurationOptions {
    alternativeToken?: string;
    transactionId?: string;
    apiRequestTimeoutInSeconds?: number;
    httpClientTimeoutInSeconds?: number;
    maxRetries?: number;
    initialDelayInMilliseconds?: number;
    maxDelayInMilliseconds?: number;
}

/**
 * Abstract base class for configuring API clients.
 * Provides common configuration options and utility methods for API requests.
 */
export abstract class Configuration {
    public static readonly serverUri: string = "https://api.experianaperture.io/";
    public token: string;
    public options: ConfigurationOptions;

    /**
     * Initializes a new instance of the {@link Configuration} class with the specified token and options.
     *
     * @param token   The authentication token for the API.
     * @param options The configuration options for the client.
     * @throws InvalidConfigurationError If the token is not provided or is empty.
     */
    constructor(token: string, options: ConfigurationOptions) {
        if (!token || token.length == 0) {
            throw new InvalidConfigurationError("The supplied configuration must contain an authorisation token");
        }

        this.token = token;
        this.options = options;
    }

    /**
     * Applies default values to the provided configuration options.
     *
     * @param options The configuration options to apply defaults to.
     * @return The configuration options with default values applied.
     */
    protected static applyDefaultOptions(options: ConfigurationOptions): ConfigurationOptions {
        const result = { ...options };
        result.apiRequestTimeoutInSeconds = options.apiRequestTimeoutInSeconds ?? defaultApiRequestTimeoutInSeconds;
        result.httpClientTimeoutInSeconds = options.httpClientTimeoutInSeconds ?? defaultHttpClientTimeoutInSeconds;
        result.maxRetries = options.maxRetries ?? defaultRetries;
        result.initialDelayInMilliseconds = options.initialDelayInMilliseconds ?? defaultInitialDelayInMilliseconds;
        result.maxDelayInMilliseconds = options.maxDelayInMilliseconds ?? defaultMaxDelayInMilliseconds;

        return result;
    }

    /**
     * Retrieves common headers for API requests.
     *
     * @param allowsDotInReferenceId Indicates whether dots are allowed in the reference ID (default is true).
     * @return A map of headers to include in the API request.
     */
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
