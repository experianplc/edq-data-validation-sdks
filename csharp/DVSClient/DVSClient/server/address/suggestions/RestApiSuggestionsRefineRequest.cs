using DVSClient.Address;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Suggestions
{
    public class RestApiSuggestionsRefineRequest
    {
        [JsonProperty("refinement")]
        public string? Refinement { get; set; }

        public static RestApiSuggestionsRefineRequest Using(Configuration configuration)
        {
            return new RestApiSuggestionsRefineRequest();
        }
    }
}