using Newtonsoft.Json;

namespace DVSClient.Server.Phone
{
    public class RestApiPhoneValidateResult
    {
        [JsonProperty("number")]
        public string? Number { get; set; }

        [JsonProperty("validated_phone_number")]
        public string? ValidatedPhoneNumber { get; set; }

        [JsonProperty("formatted_phone_number")]
        public string? FormattedPhoneNumber { get; set; }

        [JsonProperty("phone_type")]
        public string? PhoneType { get; set; }

        [JsonProperty("confidence")]
        public string? Confidence { get; set; }

        [JsonProperty("ported_date")]
        public string? PortedDate { get; set; }

        [JsonProperty("disposable_number")]
        public string? DisposableNumber { get; set; }
    }
}
