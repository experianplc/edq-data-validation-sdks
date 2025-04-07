using Newtonsoft.Json;

namespace DVSClient.Server.Phone
{
    public class RestApiPhoneValidateMetadata
    {
        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("phone_detail")]
        public RestApiPhoneValidatePhoneDetail? PhoneDetail { get; set; }
    }
}
