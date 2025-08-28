import { RestApiPhoneValidateResponse } from "../../server/phone/restApiPhoneValidateResponse";
import { PhoneConfidence, lookupConfidence } from "../confidence";
import { Metadata } from "./metadata";
import { restApiResponseToPhoneDetail } from "./phoneDetail";
import { lookupPhoneType, PhoneType } from "./phoneType";

export type PhoneValidateResult = {
    number: string;
    validatedPhoneNumber: string;
    formattedPhoneNumber: string;
    phoneType?: PhoneType;
    confidence?: PhoneConfidence;
    portedDate: string;
    disposableNumber: string;
    metadata?: Metadata;
    referenceId?: string;
};

export function restApiResponseToPhoneValidateResult(response: RestApiPhoneValidateResponse): PhoneValidateResult {

    const apiResult = response.result;
    const apiMetadata = response.metadata;

    const result: PhoneValidateResult = {
        number: "",
        validatedPhoneNumber: "",
        formattedPhoneNumber: "",
        portedDate: "",
        disposableNumber: ""
    }

    if (apiResult) {
        result.number = apiResult.number??"";
        result.validatedPhoneNumber = apiResult.validated_phone_number??"";
        result.formattedPhoneNumber = apiResult.formatted_phone_number??"";
        result.phoneType = lookupPhoneType(apiResult.phone_type);
        result.confidence = lookupConfidence(apiResult.confidence);
        result.portedDate = apiResult.ported_date??"";
        result.disposableNumber = apiResult.disposable_number??"";
    }

    if (apiMetadata) {
        result.metadata = {
            code: apiMetadata.code??"",
            message: apiMetadata.message??"",            
        }
        if (apiMetadata.phone_detail) {
            result.metadata.phoneDetail = restApiResponseToPhoneDetail(apiMetadata.phone_detail);
        }
    }

    result.referenceId = response.referenceId;
    return result;
}