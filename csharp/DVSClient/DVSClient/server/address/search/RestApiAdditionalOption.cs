using Newtonsoft.Json;

namespace DVSClient.Server.Address.Search
{
    public class RestApiAdditionalOption
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("value")]
        public string? Value { get; set; }

        public RestApiAdditionalOption()
        {
        }

        public RestApiAdditionalOption(string? name, string? value)
        {
            Name = name;
            Value = value;
        }
    }
}