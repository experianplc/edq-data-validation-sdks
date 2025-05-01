using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupV2RequestNames
    {
        [JsonProperty("forename")]
        public string? Forename { get; set; }
        [JsonProperty("middlename")]
        public string? Middlename { get; set; }
        [JsonProperty("surname")]
        public string? Surname { get; set; }

    }
}