using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupV2Response : RestApiResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }
        [JsonProperty("result")]
        public RestApiAddressLookupV2Result? Result { get; set; }
    }
}