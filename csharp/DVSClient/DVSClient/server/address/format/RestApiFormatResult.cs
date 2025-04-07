using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RestApiFormatResult
    {
        [JsonProperty("global_address_key")]
        public string? GlobalAddressKey { get; set; }

        [JsonProperty("confidence")]
        public string? Confidence { get; set; }

        [JsonProperty("address")]
        public RestApiFormatAddress? Address { get; set; }

        [JsonProperty("addresses_formatted")]
        public IEnumerable<RestApiAddressFormatted>? AddressesFormatted { get; set; }

        [JsonProperty("components")]
        public RestApiAddressFormatComponents? Components { get; set; }
    }
}