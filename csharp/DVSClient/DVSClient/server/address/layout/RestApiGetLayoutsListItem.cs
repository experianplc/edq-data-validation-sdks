using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiGetLayoutsListItem
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("applies_to")]
        public IEnumerable<RestApiAddressLayoutAppliesTo>? AppliesTo { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }
    }
}
