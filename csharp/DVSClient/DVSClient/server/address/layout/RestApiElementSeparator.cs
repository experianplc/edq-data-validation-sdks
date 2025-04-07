using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiElementSeparator
    {
        [JsonProperty("default")]
        public string? DefaultSeparator { get; set; }

        [JsonProperty("configuration_by_element")]
        public IDictionary<string, object>? ConfigurationByElement { get; set; }
    }
}
