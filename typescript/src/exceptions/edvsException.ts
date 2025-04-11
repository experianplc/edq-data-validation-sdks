import { RestApiResponseError } from "../server/restApiResponseError";

/**
 * Represents a custom error for handling errors in the DVSClient.
 * Provides constructors for various error scenarios and a factory method for creating specific errors based on API response errors.
 */
export class EDVSError extends Error {
    public readonly detail;

    /**
     * Initializes a new instance of the {@link EDVSError} class with a specified error message and optional details.
     *
     * @param message The error message that explains the reason for the error.
     * @param detail  Additional details about the error (optional).
     */
    constructor(message: string, detail?: any) {
        super(message);
        this.detail = detail;
    }

    /**
     * Creates an appropriate error based on the provided {@link RestApiResponseError}.
     *
     * @param responseError The error response from the REST API.
     * @return An instance of {@link EDVSError} or a derived error type based on the error details.
     */
    public static using(responseError: RestApiResponseError): EDVSError {
        if (responseError.title === "Unauthorized") {
            return new UnauthorizedException(responseError);
        }

        if (responseError.title === "Not Found") {
            return new NotFoundException(responseError.title ?? "");
        }

        return new EDVSError(responseError.detail ?? "");
    }
}

/**
 * Represents an error that is thrown when an invalid configuration is detected in the DVSClient.
 */
export class InvalidConfigurationError extends EDVSError { }

/**
 * Represents an error that is thrown when a requested resource is not found in the DVSClient.
 */
export class NotFoundException extends EDVSError { }

/**
 * Represents an error that is thrown when a REST API call fails due to unauthorized access.
 */
export class UnauthorizedException extends EDVSError {
    /**
     * Initializes a new instance of the {@link UnauthorizedException} class with the details of the unauthorized error.
     *
     * @param responseError The error response from the REST API containing details about the unauthorized access.
     */
    constructor(responseError: RestApiResponseError) {
        super(responseError.detail ?? "");
    }
}

