using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class RestApiAddressFormatted
    {
        [JsonProperty("layout_name")]
        public string? LayoutName { get; set; }

        [JsonProperty("not_enough_lines")]
        public bool? NotEnoughLines { get; set; }

        [JsonProperty("has_truncated_lines")]
        public bool? HasTruncatedLines { get; set; }

        [JsonProperty("address")]
        public Dictionary<string, string>? Address { get; set; }

        [JsonProperty("has_missing_sub_premises")]
        public bool? HasMissingSubPremises { get; set; }

        [JsonProperty("address_lines")]
        public IEnumerable<RestApiAddressFormattedLine>? AddressLines { get; set; }
    }
}
