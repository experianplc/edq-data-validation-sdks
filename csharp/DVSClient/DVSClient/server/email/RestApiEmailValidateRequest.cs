using DVSClient.Email;
using Newtonsoft.Json;

namespace DVSClient.Server.Email
{
    public class RestApiEmailValidateRequest
    {
        [JsonProperty("email")]
        public string? Email { get; set; }

        public static RestApiEmailValidateRequest Using(Configuration emailConfiguration)
        {
            // Currently no optional attributes. Keeping same structure as Address & Phone requests though.
            var request = new RestApiEmailValidateRequest();
            return request;
        }
    }
}
