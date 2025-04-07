using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiAddressMetadataBarcode
    {
        [JsonProperty("delivery_point_barcode")]
        public string? DeliveryPointBarcode { get; set; }

        [JsonProperty("check_digit")]
        public string? CheckDigit { get; set; }

        [JsonProperty("sort_plan_number")]
        public string? SortPlanNumber { get; set; }
    }
}