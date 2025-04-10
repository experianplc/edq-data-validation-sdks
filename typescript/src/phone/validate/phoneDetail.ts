import { Countries, Country } from "../../common/country";
import { RestApiPhoneValidatePhoneDetail } from "../../server/restApiPhoneValidatePhoneDetail";

export type PhoneDetail = {
    originalOperatorName: string;
    originalNetworkStatus: string;
    originalHomeNetworkIdentity: string;
    originalCountryPrefix: string;
    originalCountry: Country;
    operatorName: string;
    networkStatus: string;
    homeNetworkIdentity: string;
    countryPrefix: string;
    country: Country;
    isPorted: string;
    cacheValueDays?: number;
    dateCached: string;
    emailToSmsAddress: string;
    emailToMmsAddress: string;
};

export function restApiResponseToPhoneDetail(apiDetail: RestApiPhoneValidatePhoneDetail): PhoneDetail {

    return {
        originalOperatorName: apiDetail.original_operator_name??"",
        originalNetworkStatus: apiDetail.original_network_status??"",
        originalHomeNetworkIdentity: apiDetail.original_home_network_identity ?? "",
        originalCountryPrefix: apiDetail.original_country_prefix ?? "",
        originalCountry: apiDetail.original_country_iso ? Countries.fromIso3(apiDetail.original_country_iso) : Countries.Unknown,        
        operatorName: apiDetail.operator_name ?? "",
        networkStatus: apiDetail.network_status ?? "",
        homeNetworkIdentity: apiDetail.home_network_identity ?? "",
        countryPrefix: apiDetail.country_prefix ?? "",
        country: apiDetail.country_iso ? Countries.fromIso3(apiDetail.country_iso) : Countries.Unknown,
        isPorted: apiDetail.is_ported ?? "",
        cacheValueDays: apiDetail.cache_value_days,
        dateCached: apiDetail.date_cached ?? "",
        emailToSmsAddress: apiDetail.email_to_sms_address ?? "",
        emailToMmsAddress: apiDetail.email_to_mms_address ?? "",
    }


}