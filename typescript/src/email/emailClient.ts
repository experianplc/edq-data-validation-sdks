import { EDVSError } from "../exceptions/edvsException";
import { RestApiEmailValidateRequest } from "../server/email/restApiEmailValidateRequest";
import { RestApiStubImpl } from "../server/restApiStub";
import { EmailConfiguration } from "./emailConfiguration";
import { EmailValidateResult, restApiResponseToEmailValidateResult } from "./validate/emailValidateResult";

export class EmailClient {

    private readonly configuration: EmailConfiguration;
    private readonly restApiStub: RestApiStubImpl;

    public constructor(configuration: EmailConfiguration) {
            this.configuration = configuration;
            this.restApiStub = new RestApiStubImpl(configuration);
    }

    public async validate(email: string): Promise<EmailValidateResult> {
        const headers = this.configuration.getCommonHeaders(false);
        const request: RestApiEmailValidateRequest = {
            email: email
        }
        if (this.configuration.options.includeMetadata) {
            headers.set("Add-Metadata", "true" as String); // NOSONAR
        }

        try {
            const resp = await this.restApiStub.validateEmailV2(request, headers);
            if (resp.error) {
                throw EDVSError.using(resp.error);
            }
            return restApiResponseToEmailValidateResult(resp);
        } catch (error) {
            return Promise.reject(error instanceof Error ? error : new Error(String(error)));
        }

    }


}