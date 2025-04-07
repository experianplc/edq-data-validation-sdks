using Newtonsoft.Json;

namespace DVSClient.Server.Address.Datasets
{
    public class RestApiAddressDatasetElement
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
