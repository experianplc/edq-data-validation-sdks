using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiAddressFormattedLine
    {
        [JsonProperty("label")]
        public string? Label { get; set; }

        [JsonProperty("line")]
        public string? Line { get; set; }

        [JsonProperty("has_overflown_to_other_line")]
        public bool? HasOverflownToOtherLine { get; set; }

        [JsonProperty("is_truncated")]
        public bool? IsTruncated { get; set; }

        [JsonProperty("line_content")]
        public string? LineContent { get; set; }
    }
}
