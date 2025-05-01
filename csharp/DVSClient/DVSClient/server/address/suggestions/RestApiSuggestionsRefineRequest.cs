using DVSClient.Address;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Suggestions
{
    public class RestApiSuggestionsRefineRequest
    {
        [JsonProperty("refinement")]
        public string? Refinement { get; set; }

        public static RestApiSuggestionsRefineRequest Using(AddressConfiguration configuration)
        {
            return new RestApiSuggestionsRefineRequest();
        }
    }
}