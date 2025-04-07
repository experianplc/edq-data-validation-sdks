using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiAddressMetadataInfoIdentifier
    {
        [JsonProperty("umrrn")]
        public string? Umrrn { get; set; }

        [JsonProperty("udprn")]
        public string? Udprn { get; set; }

        [JsonProperty("dpid")]
        public string? Dpid { get; set; }

        [JsonProperty("gnafpid")]
        public string? Gnafpid { get; set; }

        [JsonProperty("paf_address_key")]
        public string? PafAddressKey { get; set; }

        [JsonProperty("hin")]
        public string? Hin { get; set; }
    }
}
