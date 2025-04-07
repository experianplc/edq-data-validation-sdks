using Newtonsoft.Json;

namespace DVSClient.Server.Email
{
    public class RestApiEmailDomainDetail
    {
        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}
