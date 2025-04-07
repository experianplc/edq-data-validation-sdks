using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiDeleteLayoutResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }
    }
}
