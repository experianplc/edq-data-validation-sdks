using Newtonsoft.Json;

namespace DVSClient.Server.Address.Search
{
    public class RestApiAddressSearchResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public RestApiAddressSearchResult? Result { get; set; }
    }
}