using Newtonsoft.Json;

namespace DVSClient.Server.Address.Datasets
{
    public class RestApiAddressDatasetResult
    {
        [JsonProperty("country_iso_3")]
        public string? CountryIso3 { get; set; }

        [JsonProperty("country_name")]
        public string? CountryName { get; set; }

        [JsonProperty("datasets")]
        public IEnumerable<RestApiAddressDatasetElement>? Datasets { get; set; }

        [JsonProperty("valid_combinations")]
        public IEnumerable<List<string>>? ValidCombinations { get; set; }
    }
}
