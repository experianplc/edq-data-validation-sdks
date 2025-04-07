using Newtonsoft.Json;

namespace DVSClient.Server.Address.Search
{
    public class RestApiSearchResultAdditionalAttribute
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }
    }
}
