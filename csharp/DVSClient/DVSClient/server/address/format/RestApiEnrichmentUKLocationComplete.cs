using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentUKLocationComplete
    {
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("match_level")]
        public string? MatchLevel { get; set; }

        [JsonProperty("udprn")]
        public string? Udprn { get; set; }

        [JsonProperty("uprn")]
        public string? Uprn { get; set; }

        [JsonProperty("x_coordinate")]
        public double? XCoordinate { get; set; }

        [JsonProperty("y_coordinate")]
        public double? YCoordinate { get; set; }
    }
}