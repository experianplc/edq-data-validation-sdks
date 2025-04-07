using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiFormatAttribute
    {
        [JsonProperty("geocodes")]
        public IEnumerable<string?>? Geocodes { get; set; }

        [JsonProperty("usa_regional_geocodes")]
        public IEnumerable<string?>? UsaRegionalGeocodes { get; set; }

        [JsonProperty("aus_regional_geocodes")]
        public IEnumerable<string?>? AusRegionalGeocodes { get; set; }

        [JsonProperty("nzl_regional_geocodes")]
        public IEnumerable<string?>? NzlRegionalGeocodes { get; set; }

        [JsonProperty("uk_location_complete")]
        public IEnumerable<string?>? GbrLocationComplete { get; set; }

        [JsonProperty("uk_location_essential")]
        public IEnumerable<string?>? GbrLocationEssential { get; set; }

        [JsonProperty("gbr_government")]
        public IEnumerable<string?>? GbrGovernment { get; set; }

        [JsonProperty("gbr_health")]
        public IEnumerable<string?>? GbrHealth { get; set; }

        [JsonProperty("gbr_business")]
        public IEnumerable<string?>? GbrBusiness { get; set; }

        [JsonProperty("premium_location_insight")]
        public IEnumerable<string?>? PremiumLocationInsight { get; set; }

        [JsonProperty("what3words")]
        public IEnumerable<string?>? What3words { get; set; }
    }
}
