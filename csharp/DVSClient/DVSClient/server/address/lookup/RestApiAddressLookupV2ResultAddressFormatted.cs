using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupV2ResultAddressFormatted
    {
        [JsonProperty("layout_name")]
        public string? LayoutName { get; set; }
        [JsonProperty("address")]
        public AddressDetails? Address { get; set; }

        public class AddressDetails
        {
            [JsonProperty("electricity_meters")]
            public IEnumerable<RestApiAddressLookupElectricityMeter>? ElectricityMeters { get; set; }
            [JsonProperty("gas_meters")]
            public IEnumerable<RestApiAddressLookupGasMeter>? GasMeters { get; set; }


        }

    }
}