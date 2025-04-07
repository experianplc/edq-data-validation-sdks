using Newtonsoft.Json;

namespace DVSClient.Server.Phone
{
    public class RestApiPhoneValidatePhoneDetail
    {
        [JsonProperty("original_operator_name")]
        public string? OriginalOperatorName { get; set; }

        [JsonProperty("original_network_status")]
        public string? OriginalNetworkStatus { get; set; }

        [JsonProperty("original_home_network_identity")]
        public string? OriginalHomeNetworkIdentity { get; set; }

        [JsonProperty("original_country_prefix")]
        public string? OriginalCountryPrefix { get; set; }

        [JsonProperty("original_country_name")]
        public string? OriginalCountryName { get; set; }

        [JsonProperty("original_country_iso")]
        public string? OriginalCountryIso { get; set; }

        [JsonProperty("operator_name")]
        public string? OperatorName { get; set; }

        [JsonProperty("network_status")]
        public string? NetworkStatus { get; set; }

        [JsonProperty("home_network_identity")]
        public string? HomeNetworkIdentity { get; set; }

        [JsonProperty("country_prefix")]
        public string? CountryPrefix { get; set; }

        [JsonProperty("country_name")]
        public string? CountryName { get; set; }

        [JsonProperty("country_iso")]
        public string? CountryIso { get; set; }

        [JsonProperty("is_ported")]
        public string? IsPorted { get; set; }

        [JsonProperty("cache_value_days")]
        public int? CacheValueDays { get; set; }

        [JsonProperty("date_cached")]
        public string? DateCached { get; set; }

        [JsonProperty("email_to_sms_address")]
        public string? EmailToSmsAddress { get; set; }

        [JsonProperty("email_to_mms_address")]
        public string? EmailToMmsAddress { get; set; }
    }
}
