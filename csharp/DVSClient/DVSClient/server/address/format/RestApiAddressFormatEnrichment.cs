using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiAddressFormatEnrichment
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("transaction_id")]
        public string? TransactionId { get; set; }

        [JsonProperty("result")]
        public RestApiEnrichmentResultAddress? Result { get; set; }

        [JsonProperty("metadata")]
        public RestApiEnrichmentMetadata? Metadata { get; set; }
    }
}
