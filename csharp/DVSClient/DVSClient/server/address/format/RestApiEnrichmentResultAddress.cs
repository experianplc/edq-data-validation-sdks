using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentResultAddress
    {
        [JsonProperty("geocodes")]
        public RestApiEnrichmentDatasetGeocodes? Geocodes { get; set; }

        [JsonProperty("usa_regional_geocodes")]
        public RestApiEnrichmentUsaRegionalGeocodes? UsaRegionalGeocodes { get; set; }

        [JsonProperty("aus_regional_geocodes")]
        public RestApiEnrichmentAusRegionalGeocodes? AusRegionalGeocodes { get; set; }

        [JsonProperty("nz_regional_geocodes")]
        public RestApiEnrichmentNzlRegionalGeocodes? NzRegionalGeocodes { get; set; }

        [JsonProperty("uk_location_complete")]
        public RestApiEnrichmentUKLocationComplete? GbrLocationComplete { get; set; }

        [JsonProperty("uk_location_essential")]
        public RestApiEnrichmentUKLocationEssential? GbrLocationEssential { get; set; }

        [JsonProperty("gbr_government")]
        public RestApiEnrichmentGbrGovernment? GbrGovernment { get; set; }

        [JsonProperty("gbr_business")]
        public RestApiEnrichmentGbAdditional? GbrBusiness { get; set; }

        [JsonProperty("gbr_health")]
        public RestApiEnrichmentGbrHealth? GbrHealth { get; set; }

        [JsonProperty("premium_location_insight")]
        public RestApiPremiumLocationInsight? PremiumLocationInsight { get; set; }

        [JsonProperty("what3words")]
        public RestApiEnrichmentWhat3Words? What3words { get; set; }
    }
}