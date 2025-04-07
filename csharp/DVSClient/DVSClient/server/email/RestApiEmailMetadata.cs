using Newtonsoft.Json;

namespace DVSClient.Server.Email
{
    public class RestApiEmailMetadata
    {
        [JsonProperty("domain_detail")]
        public RestApiEmailDomainDetail? DomainDetail { get; set; }
    }
}
