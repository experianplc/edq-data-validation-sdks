
import { ResponseError } from "../../common/responseError";
import { RestApiEmailValidateResponse } from "../../server/email/restApiEmailValidateResponse";
import { EmailConfidence, lookupConfidence } from "../emailConfidence";
import { DomainType, lookupDomainType } from "./domainType";
import { lookupVerboseOutput, VerboseOutput } from "./verboseOutput";

export type ValidateResult = {
    error?: ResponseError;
    confidence?: EmailConfidence;
    didYouMean?: string[];
    verboseOutput?: VerboseOutput;
    domainType?: DomainType;
};

export function restApiResponseToEmailValidateResult(response: RestApiEmailValidateResponse): ValidateResult {
    
    const result: ValidateResult = {};

    const apiResult = response.result;
    if (apiResult) {
        result.confidence = lookupConfidence(apiResult.confidence);
        if (apiResult.did_you_mean) {
            result.didYouMean = apiResult.did_you_mean;
        }
        if (apiResult.verbose_output) {
            result.verboseOutput = lookupVerboseOutput(apiResult.verbose_output);
        }        
    } 

    const apiMetadata = response.metadata;
    if (apiMetadata?.domain_detail?.type) {
        result.domainType = apiMetadata.domain_detail.type = lookupDomainType(apiMetadata.domain_detail.type);
    }

    return result;

}