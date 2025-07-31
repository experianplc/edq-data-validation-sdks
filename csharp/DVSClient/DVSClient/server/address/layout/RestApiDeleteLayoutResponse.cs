using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiGetLayoutResponse : RestApiResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public RestApiGetLayoutResult? Result { get; set; }
    }
}
