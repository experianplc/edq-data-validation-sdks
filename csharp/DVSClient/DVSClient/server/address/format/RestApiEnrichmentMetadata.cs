using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentMetadata
    {
        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("message")]
        public string? Message { get; set; }

        [JsonProperty("detail")]
        public string? Detail { get; set; }
    }
}