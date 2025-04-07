using DVSClient.Server.Address.Format;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Validate
{
    public class RestApiAddressValidateResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public RestApiAddressValidateResult? Result { get; set; }

        [JsonProperty("metadata")]
        public RestApiAddressFormatMetadata? Metadata { get; set; }

        [JsonProperty("enrichment")]
        public RestApiAddressFormatEnrichment? Enrichment { get; set; }
    }
}