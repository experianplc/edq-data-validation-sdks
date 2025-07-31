using Newtonsoft.Json;

namespace DVSClient.Server.Address.Search
{
    public class RestApiAddressSearchResponse : RestApiResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public RestApiAddressSearchResult? Result { get; set; }
    }
}