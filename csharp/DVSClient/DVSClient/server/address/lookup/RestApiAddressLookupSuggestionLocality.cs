using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupSuggestionLocality
    {
        [JsonProperty("region")]
        public RestApiAddressLookupLocalityItem? Region { get; set; }
        [JsonProperty("sub_region")]
        public RestApiAddressLookupLocalityItem? SubRegion { get; set; }
        [JsonProperty("town")]
        public RestApiAddressLookupLocalityItem? Town { get; set; }
        [JsonProperty("district")]
        public RestApiAddressLookupLocalityItem? District { get; set; }
        [JsonProperty("sub_district")]
        public RestApiAddressLookupLocalityItem? SubDistrict { get; set; }

    }
}