import { RestApiResponseError } from "../server/restApiResponseError";

export class EDVSError extends Error {
    public readonly detail;
    constructor(message: string, detail?: any) {
        super(message);
        this.detail = detail;
    }

    public static using(responseError: RestApiResponseError) : EDVSError
        {
            if (responseError.title === "Unauthorized")
            {
                return new UnauthorizedException(responseError);
            }

            if (responseError.title === "Not Found")
            {
                return new NotFoundException(responseError.title??"");
            }

            return new EDVSError(responseError.detail??"");
        }
}

export class InvalidConfigurationError extends EDVSError {}
export class NotFoundException extends EDVSError {}

export class UnauthorizedException extends EDVSError {
    constructor(responseError: RestApiResponseError) {
        super(responseError.detail??"")
    }
}
