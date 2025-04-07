using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentGbrHealth
    {
        [JsonProperty("authority_code")]
        public string? AuthorityCode { get; set; }

        [JsonProperty("authority_code_2011")]
        public string? AuthorityCode2011 { get; set; }

        [JsonProperty("authority_name")]
        public string? AuthorityName { get; set; }

        [JsonProperty("pclh_code")]
        public string? PclhCode { get; set; }

        [JsonProperty("pclh_code_2011")]
        public string? PclhCode2011 { get; set; }

        [JsonProperty("pclh_name")]
        public string? PclhName { get; set; }

        [JsonProperty("ward_code")]
        public string? WardCode { get; set; }

        [JsonProperty("ward_code_2011")]
        public string? WardCode2011 { get; set; }

        [JsonProperty("ward_name")]
        public string? WardName { get; set; }

        [JsonProperty("ccg_code")]
        public string? CcgCode { get; set; }

        [JsonProperty("ccg_name")]
        public string? CcgName { get; set; }

        [JsonProperty("doh_code")]
        public string? DohCode { get; set; }
    }
}