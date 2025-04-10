
import { ResponseError } from "../../common/responseError";
import { RestApiEmailValidateResponse } from "../../server/email/restApiEmailValidateResponse";
import { Confidence, lookupConfidence } from "../confidence";
import { DomainType, lookupDomainType } from "./domainType";
import { lookupVerboseOutput, VerboseOutput } from "./verboseOutput";

export type EmailValidateResult = {
    error?: ResponseError;
    confidence?: Confidence;
    didYouMean?: string[];
    verboseOutput?: VerboseOutput;
    domainType?: DomainType;
};

export function restApiResponseToEmailValidateResult(response: RestApiEmailValidateResponse): EmailValidateResult {
    
    const result: EmailValidateResult = {};

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