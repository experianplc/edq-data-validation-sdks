using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiDeleteLayoutResponse : RestApiResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }
    }
}
