using Newtonsoft.Json;

namespace DVSClient.Server.Address.Suggestions
{
    public class RestApiSuggestionsFormatResponse
    {
        [JsonProperty("error")]
        public RestApiResponseError? Error { get; set; }

        [JsonProperty("result")]
        public RestApiSuggestionsFormatResult? Result { get; set; }
    }
}