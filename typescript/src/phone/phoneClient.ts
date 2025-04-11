import { EDVSError } from "../exceptions/edvsException";
import { getPhoneValidateRequestFromConfig } from "../server/phone/restApiPhoneValidateRequest";
import { RestApiStubImpl } from "../server/restApiStub";
import { PhoneConfiguration } from "./phoneConfiguration";
import { PhoneValidateResult, restApiResponseToPhoneValidateResult } from "./validate/phoneValidateResult";

/**
 * Client class for interacting with the phone-related APIs.
 * Provides methods for validating phone numbers.
 */
export class PhoneClient {

    private readonly configuration: PhoneConfiguration;
    private readonly restApiStub: RestApiStubImpl;

    /**
     * Initializes a new instance of the {@link PhoneClient} class with the specified configuration.
     *
     * @param configuration The configuration settings for the phone client.
     */
    public constructor(configuration: PhoneConfiguration) {
        this.configuration = configuration;
        this.restApiStub = new RestApiStubImpl(configuration);
    }

    /**
     * Validates a phone number asynchronously.
     *
     * @param phoneNumber The phone number to validate.
     * @return A promise that resolves to the validation result.
     * @throws EDVSError If the API response contains an error.
     */
    public async validate(phoneNumber: string): Promise<PhoneValidateResult> {
        const headers = this.configuration.getCommonHeaders(false);
        const request = getPhoneValidateRequestFromConfig(this.configuration);
        request.number = phoneNumber;

        if (this.configuration.options.includeMetadata) {
            headers.set("Add-Metadata", "true" as String); // NOSONAR
        }
        try {
            const resp = await this.restApiStub.validatePhoneV2(request, headers);
            if (resp.error) {
                throw EDVSError.using(resp.error);
            }
            return restApiResponseToPhoneValidateResult(resp);
        } catch (error) {
            return Promise.reject(error instanceof Error ? error : new Error(String(error)));
        }
    }
}
