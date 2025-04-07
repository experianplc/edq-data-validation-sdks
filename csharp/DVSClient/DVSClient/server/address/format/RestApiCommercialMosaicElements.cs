using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiCommercialMosaicElements
    {
        [JsonProperty("group_type_code")]
        public string? GroupTypeCode { get; set; }

        [JsonProperty("group_type_description")]
        public string? GroupTypeDescription { get; set; }

        [JsonProperty("group_code")]
        public string? GroupCode { get; set; }

        [JsonProperty("group_description")]
        public string? GroupDescription { get; set; }
    }
}