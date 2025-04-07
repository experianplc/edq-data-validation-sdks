using Newtonsoft.Json;
using DVSClient.Phone;

namespace DVSClient.Server.Phone
{
    public class RestApiPhoneValidateRequest
    {
        [JsonProperty("number")]
        public string? Number { get; set; }

        [JsonProperty("output_format")]
        public string? OutputFormat { get; set; }

        [JsonProperty("cache_value_days")]
        public int? CacheValueDays { get; set; }

        [JsonProperty("country_iso")]
        public string? CountryIso { get; set; }

        [JsonProperty("get_ported_date")]
        public bool? GetPortedDate { get; set; }

        [JsonProperty("get_disposable_number")]
        public bool? GetDisposableNumber { get; set; }

        [JsonProperty("supplementary_live_status")]
        public RestApiPhoneSupplementaryLiveStatus? SupplementaryLiveStatus { get; set; }

        public static RestApiPhoneValidateRequest Using(Configuration phoneConfiguration)
        {
            var request = new RestApiPhoneValidateRequest();

            if (phoneConfiguration.OutputFormat != null)
            {
                request.OutputFormat = phoneConfiguration.OutputFormat;
            }

            if (phoneConfiguration.CacheValueDays.HasValue)
            {
                request.CacheValueDays = phoneConfiguration.CacheValueDays.Value;
            }

            if (phoneConfiguration.IncludePortedDate.HasValue)
            {
                request.GetPortedDate = phoneConfiguration.IncludePortedDate;
            }

            if (phoneConfiguration.IncludeDisposableNumber.HasValue)
            {
                request.GetDisposableNumber = phoneConfiguration.IncludeDisposableNumber;
            }

            if (phoneConfiguration.LiveStatusForLandline != null || phoneConfiguration.LiveStatusForMobile != null)
            {
                var supplementaryLiveStatus = new RestApiPhoneSupplementaryLiveStatus();

                if (phoneConfiguration.LiveStatusForMobile != null)
                {
                    supplementaryLiveStatus.Mobile = phoneConfiguration.LiveStatusForMobile.ToList().ConvertAll(c => c.Iso3Code);
                }

                if (phoneConfiguration.LiveStatusForLandline != null)
                {
                    supplementaryLiveStatus.Landline = phoneConfiguration.LiveStatusForLandline.ToList().ConvertAll(c => c.Iso3Code);
                }

                request.SupplementaryLiveStatus = supplementaryLiveStatus;
            }

            return request;
        }
    }
}
