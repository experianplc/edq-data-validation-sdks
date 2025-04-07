using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiStandardIndustryClassificationElements
    {
        [JsonProperty("sic_2007_code")]
        public string? Sic2007Code { get; set; }

        [JsonProperty("sic_2007_description")]
        public string? Sic2007Description { get; set; }

        [JsonProperty("thomson_code")]
        public string? ThomsonCode { get; set; }

        [JsonProperty("thomson_description")]
        public string? ThomsonDescription { get; set; }
    }
}