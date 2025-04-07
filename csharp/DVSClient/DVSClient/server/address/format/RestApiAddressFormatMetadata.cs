using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiAddressFormatMetadata
    {
        [JsonProperty("address_info")]
        public RestApiAddressMetadataInfo? AddressInfo { get; set; }

        [JsonProperty("barcode")]
        public RestApiAddressMetadataBarcode? Barcode { get; set; }

        [JsonProperty("route_classification")]
        public RestApiAddressMetadataRouteClassification? RouteClassification { get; set; }

        [JsonProperty("address_classification")]
        public RestApiAddressMetadataAddressClassification? AddressClassification { get; set; }

        [JsonProperty("dpv")]
        public RestApiAddressMetadataDpv? Dpv { get; set; }
    }
}