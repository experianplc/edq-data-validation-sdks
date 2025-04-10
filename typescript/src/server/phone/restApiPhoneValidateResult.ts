export type RestApiPhoneValidateResult = {
    number?: string;
    validated_phone_number?: string;
    formatted_phone_number?: string;
    phone_type?: string;
    confidence?: string;
    ported_date?: string;
    disposable_number?: string;
};