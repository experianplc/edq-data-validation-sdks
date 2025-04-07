using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiEnrichmentGbrGovernment
    {
        [JsonProperty("eer_code")]
        public string? EerCode { get; set; }

        [JsonProperty("eer_code_pre_2011")]
        public string? EerCodePre2011 { get; set; }

        [JsonProperty("eer_name")]
        public string? EerName { get; set; }

        [JsonProperty("gor_code")]
        public string? GorCode { get; set; }

        [JsonProperty("gor_code_pre_2011")]
        public string? GorCodePre2011 { get; set; }

        [JsonProperty("gor_name")]
        public string? GorName { get; set; }

        [JsonProperty("lea_code")]
        public string? LeaCode { get; set; }

        [JsonProperty("lea_name")]
        public string? LeaName { get; set; }

        [JsonProperty("la_code")]
        public string? LaCode { get; set; }

        [JsonProperty("la_code_pre_2011")]
        public string? LaCodePre2011 { get; set; }

        [JsonProperty("la_name")]
        public string? LaName { get; set; }

        [JsonProperty("ward_code")]
        public string? WardCode { get; set; }

        [JsonProperty("ward_code_pre_2011")]
        public string? WardCodePre2011 { get; set; }

        [JsonProperty("ward_name")]
        public string? WardName { get; set; }

        [JsonProperty("cens_out_area")]
        public string? CensOutArea { get; set; }
    }
}