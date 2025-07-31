using Newtonsoft.Json;

namespace DVSClient.Server.Email
{
    public class RestApiEmailValidateResponse : RestApiResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public RestApiEmailValidateResult? Result { get; set; }

        [JsonProperty("metadata")]
        public RestApiEmailMetadata? Metadata { get; set; }
    }
}
