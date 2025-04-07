using Newtonsoft.Json;

namespace DVSClient.Server
{
    public class RestApiResponseError
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("detail")]
        public string? Detail { get; set; }

        [JsonProperty("instance")]
        public string? Instance { get; set; }
    }
}
