using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentDatasetGeocodes
    {
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("match_level")]
        public string? MatchLevel { get; set; }
    }
}