import { PhoneConfiguration } from "../../phone/phoneConfiguration";
import { RestApiPhoneSupplementaryLiveStatus } from "./restApiPhoneSupplementaryLiveStatus";

export type RestApiPhoneValidateRequest = {
    number?: string;
    output_format?: string;
    cache_value_days?: number;
    country_iso?: string;
    get_ported_date?: boolean;
    get_disposable_number?: boolean;
    supplementary_live_status?: RestApiPhoneSupplementaryLiveStatus;
};

export function getPhoneValidateRequestFromConfig(config: PhoneConfiguration): RestApiPhoneValidateRequest {
    const request: RestApiPhoneValidateRequest = {};
    if (config.options.outputFormat) {
        request.output_format = config.options.outputFormat;
    }
    if (config.options.cacheValueDays) {
        request.cache_value_days = config.options.cacheValueDays;
    }
    if (config.options.includePortedDate) {
        request.get_ported_date = config.options.includePortedDate;
    }
    if (config.options.includeDisposableNumber) {
        request.get_disposable_number = config.options.includeDisposableNumber;
    }
    if (config.options.liveStatusForMobile || config.options.liveStatusForLandline) {
        const liveStatus: RestApiPhoneSupplementaryLiveStatus = {};
        if (config.options.liveStatusForMobile) {
            liveStatus.mobile = config.options.liveStatusForMobile.map(country => country.iso3Code);
        }
        if (config.options.liveStatusForLandline) {
            liveStatus.landline = config.options.liveStatusForLandline.map(country => country.iso3Code);
        }
        request.supplementary_live_status = liveStatus;        

    }
    return request;
}