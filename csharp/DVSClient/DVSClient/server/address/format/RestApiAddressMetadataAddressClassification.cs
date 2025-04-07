using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiAddressMetadataAddressClassification
    {
        [JsonProperty("address_type")]
        public string? AddressType { get; set; }

        [JsonProperty("delivery_type")]
        public string? DeliveryType { get; set; }

        [JsonProperty("is_deliverable")]
        public bool? IsDeliverable { get; set; }
    }
}