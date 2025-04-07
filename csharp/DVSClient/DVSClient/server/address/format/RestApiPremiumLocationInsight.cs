using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiPremiumLocationInsight
    {
        [JsonProperty("geocodes")]
        public PremiumLocationInsightGeocodes? Geocodes { get; set; }

        [JsonProperty("geocodes_building_xy")]
        public PremiumLocationInsightGeocodesBuildingXy? GeocodesBuildingXy { get; set; }

        [JsonProperty("geocodes_access")]
        public IEnumerable<PremiumLocationInsightGeocodesAccess>? GeocodesAccess { get; set; }

        [JsonProperty("time")]
        public IEnumerable<PremiumLocationInsightTime>? Time { get; set; }

        public class PremiumLocationInsightGeocodes
        {
            [JsonProperty("latitude")]
            public double? Latitude { get; set; }

            [JsonProperty("longitude")]
            public double? Longitude { get; set; }

            [JsonProperty("match_level")]
            public string? MatchLevel { get; set; }
        }

        public class PremiumLocationInsightGeocodesBuildingXy
        {
            [JsonProperty("x_coordinate")]
            public double? XCoordinate { get; set; }

            [JsonProperty("y_coordinate")]
            public double? YCoordinate { get; set; }
        }

        public class PremiumLocationInsightGeocodesAccess
        {
            [JsonProperty("latitude")]
            public double? Latitude { get; set; }

            [JsonProperty("longitude")]
            public double? Longitude { get; set; }
        }

        public class PremiumLocationInsightTime
        {
            [JsonProperty("time_zone_id")]
            public string? TimeZoneId { get; set; }

            [JsonProperty("generic")]
            public string? Generic { get; set; }

            [JsonProperty("standard")]
            public string? Standard { get; set; }

            [JsonProperty("daylight")]
            public string? Daylight { get; set; }

            [JsonProperty("reference_time")]
            public PremiumLocationInsightReferenceTime? ReferenceTime { get; set; }

            [JsonProperty("time_transition")]
            public IEnumerable<PremiumLocationInsightTimeTransition>? TimeTransition { get; set; }
        }

        public class PremiumLocationInsightReferenceTime
        {
            [JsonProperty("tag")]
            public string? Tag { get; set; }

            [JsonProperty("standard_offset")]
            public string? StandardOffset { get; set; }

            [JsonProperty("daylight_savings")]
            public string? DaylightSavings { get; set; }

            [JsonProperty("sunrise")]
            public string? Sunrise { get; set; }

            [JsonProperty("sunset")]
            public string? Sunset { get; set; }
        }

        public class PremiumLocationInsightTimeTransition
        {
            [JsonProperty("tag")]
            public string? Tag { get; set; }

            [JsonProperty("standard_offset")]
            public string? StandardOffset { get; set; }

            [JsonProperty("daylight_savings")]
            public string? DaylightSavings { get; set; }

            [JsonProperty("utc_start")]
            public string? UtcStart { get; set; }

            [JsonProperty("utc_end")]
            public string? UtcEnd { get; set; }
        }
    }
}