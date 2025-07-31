using Newtonsoft.Json;

namespace DVSClient.Server.Phone
{
    public class RestApiPhoneValidateResponse : RestApiResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public RestApiPhoneValidateResult? Result { get; set; }

        [JsonProperty("metadata")]
        public RestApiPhoneValidateMetadata? Metadata { get; set; }
    }
}
