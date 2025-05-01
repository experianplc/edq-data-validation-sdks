using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupV2RequestAttribute
    {
        [JsonProperty("locality_lookup")]
        public IEnumerable<string>? LocalityLookup { get; set; }
        [JsonProperty("postal_code_lookup")]
        public IEnumerable<string>? PostalCodeLookup { get; set; }

    }
}