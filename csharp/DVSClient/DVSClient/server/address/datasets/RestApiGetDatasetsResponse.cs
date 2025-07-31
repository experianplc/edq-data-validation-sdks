using Newtonsoft.Json;

namespace DVSClient.Server.Address.Datasets
{
    public class RestApiGetDatasetsResponse : RestApiResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public IEnumerable<RestApiAddressDatasetResult>? Result { get; set; }
    }
}
