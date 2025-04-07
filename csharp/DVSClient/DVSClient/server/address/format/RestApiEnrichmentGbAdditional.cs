using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentGbAdditional
    {
        [JsonProperty("urn")]
        public string? Urn { get; set; }

        [JsonProperty("commercial_mosaic")]
        public RestApiCommercialMosaicElements? CommercialMosaic { get; set; }

        [JsonProperty("registration")]
        public string? Registration { get; set; }

        [JsonProperty("non_limited_company_key")]
        public string? NonLimitedCompanyKey { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("number_of_employees")]
        public string? NumberOfEmployees { get; set; }

        [JsonProperty("standard_industry_classification")]
        public RestApiStandardIndustryClassificationElements? StandardIndustryClassification { get; set; }

        [JsonProperty("location")]
        public RestApiEnrichmentLocationElements? Location { get; set; }
    }
}