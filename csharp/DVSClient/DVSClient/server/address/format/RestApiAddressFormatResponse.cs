using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RestApiAddressFormatResponse : RestApiResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public RestApiFormatResult? Result { get; set; }

        [JsonProperty("metadata")]
        public RestApiAddressFormatMetadata? Metadata { get; set; }

        [JsonProperty("enrichment")]
        public RestApiAddressFormatEnrichment? Enrichment { get; set; }
    }
}