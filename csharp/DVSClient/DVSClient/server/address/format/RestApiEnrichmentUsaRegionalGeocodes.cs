using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentUsaRegionalGeocodes
    {
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("match_level")]
        public string? MatchLevel { get; set; }

        [JsonProperty("census_tract")]
        public string? CensusTract { get; set; }

        [JsonProperty("census_block")]
        public string? CensusBlock { get; set; }

        [JsonProperty("core_based_statistical_area")]
        public string? CoreBasedStatisticalArea { get; set; }

        [JsonProperty("congressional_district_code")]
        public string? CongressionalDistrictCode { get; set; }

        [JsonProperty("county_code")]
        public string? CountyCode { get; set; }
    }
}