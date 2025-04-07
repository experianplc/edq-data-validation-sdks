using Newtonsoft.Json;

namespace DVSClient.Server.Email
{
    public class RestApiEmailValidateResult
    {
        [JsonProperty("confidence")]
        public string? Confidence { get; set; }

        [JsonProperty("did_you_mean")]
        public IEnumerable<string>? DidYouMean { get; set; }

        [JsonProperty("verbose_output")]
        public string? VerboseOutput { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }
    }
}
