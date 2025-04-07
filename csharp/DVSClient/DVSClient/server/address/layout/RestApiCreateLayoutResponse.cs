using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiCreateLayoutResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public RestApiCreateLayoutResult? Result { get; set; }
    }
}
