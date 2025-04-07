using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiCreateLayoutResult
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}
