using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupSuggestion
    {

        [JsonProperty("locality")]
        public RestApiAddressLookupSuggestionLocality? Locality { get; set; }
        [JsonProperty("postal_code")]
        public RestApiAddressLookupSuggestionPostalCode? PostalCode { get; set; }
        [JsonProperty("postal_code_key")]
        public string? PostalCodeKey { get; set; }
        [JsonProperty("locality_key")]
        public string? LocalityKey { get; set; }
        [JsonProperty("what3words")]
        public RestApiAddressLookupSuggestionW3W? What3words { get; set; }
        
    }
}