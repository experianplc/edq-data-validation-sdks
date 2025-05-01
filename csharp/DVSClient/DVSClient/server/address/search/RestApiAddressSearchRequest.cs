using Newtonsoft.Json;
using DVSClient.Address;

namespace DVSClient.Server.Address.Search
{
    public class RestApiAddressSearchRequest
    {
        [JsonProperty("country_iso")]
        public string? CountryIso { get; set; }

        [JsonProperty("datasets")]
        public IEnumerable<string>? Datasets { get; set; }

        [JsonProperty("max_suggestions")]
        public int? MaxSuggestions { get; set; }

        [JsonProperty("components")]
        public Address? Address { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }

        [JsonProperty("options")]
        public IList<RestApiAdditionalOption>? Options { get; set; }

        public static RestApiAddressSearchRequest Using(AddressConfiguration configuration)
        {
            var searchRequest = new RestApiAddressSearchRequest();

            // Country
            if (configuration.GetCountry() != null)
            {
                searchRequest.CountryIso = configuration.GetCountry()?.Iso3Code;
            }

            // Datasets
            if (configuration.Datasets.Any())
            {
                searchRequest.Datasets = configuration.Datasets.ToList().ConvertAll(dataset => dataset.DatasetCode);
            }

            // Max suggestions
            if (configuration.MaxSuggestions != AddressConfiguration.DefaultMaxSuggestions)
            {
                searchRequest.MaxSuggestions = configuration.MaxSuggestions;
            }

            // Location
            if (!string.IsNullOrEmpty(configuration.Location))
            {
                searchRequest.Location = configuration.Location;
            }

            if (configuration.FlattenResults)
            {
                searchRequest.AddOption("flatten", true.ToString());
            }

            if (configuration.SearchIntensity.HasValue)
            {
                searchRequest.AddOption("intensity", configuration.SearchIntensity.Value.ToString());
            }

            if (configuration.PromptSet.HasValue)
            {
                searchRequest.AddOption("prompt_set", configuration.PromptSet.Value.ToString());
            }

            // TODO: Add preferred language and preferred script

            return searchRequest;
        }

        public void AddOption(string name, string value)
        {
            if (Options == null)
            {
                Options = new List<RestApiAdditionalOption>();
            }

            Options.Add(new RestApiAdditionalOption(name, value));
        }
    }
}