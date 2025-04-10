import { RestApiPhoneValidatePhoneDetail } from "../restApiPhoneValidatePhoneDetail";

export type RestApiPhoneValidateMetadata = {
    code?: string;
    message?: string;
    phone_detail?: RestApiPhoneValidatePhoneDetail;
};