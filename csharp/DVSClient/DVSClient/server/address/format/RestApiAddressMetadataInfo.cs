using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiAddressMetadataInfo
    {
        [JsonProperty("sources")]
        public IEnumerable<string>? Sources { get; set; }

        [JsonProperty("number_of_households")]
        public string? NumberOfHouseholds { get; set; }

        [JsonProperty("just_built_date")]
        public string? JustBuiltDate { get; set; }

        [JsonProperty("identifier")]
        public RestApiAddressMetadataInfoIdentifier? Identifier { get; set; }
    }
}
