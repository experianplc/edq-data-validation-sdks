using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiGetLayoutLayout
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("comment")]
        public string? Comment { get; set; }

        [JsonProperty("applies_to")]
        public IEnumerable<RestApiAddressLayoutAppliesTo>? AppliesTo { get; set; }

        [JsonProperty("lines")]
        public IEnumerable<RestApiAddressLayoutLine>? Lines { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("license_id")]
        public string? LicenseId { get; set; }
    }
}
