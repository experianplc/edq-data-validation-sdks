using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiGetLayoutListResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public IEnumerable<RestApiGetLayoutsListItem>? Result { get; set; }
    }
}
