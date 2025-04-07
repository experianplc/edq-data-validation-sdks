using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentLocationElements
    {
        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("small_or_home_office")]
        public string? SmallOrHomeOffice { get; set; }
    }
}