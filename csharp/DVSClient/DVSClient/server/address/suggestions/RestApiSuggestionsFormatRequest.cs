using DVSClient.Address;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Suggestions
{
    public class RestApiSuggestionsFormatRequest
    {
        [JsonProperty("country_iso")]
        public string? CountryIso { get; set; }

        [JsonProperty("datasets")]
        public IEnumerable<string>? Datasets { get; set; }

        [JsonProperty("max_suggestions")]
        public int? MaxSuggestions { get; set; }

        [JsonProperty("components")]
        public Address? Address { get; set; }

        [JsonProperty("layouts")]
        public IEnumerable<string>? Layouts { get; set; }

        public static RestApiSuggestionsFormatRequest Using(AddressConfiguration configuration)
        {
            var suggestionsFormat = new RestApiSuggestionsFormatRequest();

            // Country
            if (configuration.GetCountry() != null)
            {
                suggestionsFormat.CountryIso = configuration.GetCountry()?.Iso3Code;
            }

            // Datasets
            if (configuration.Datasets != null && configuration.Datasets.Any())
            {
                suggestionsFormat.Datasets = configuration.Datasets.ToList().ConvertAll(dataset => dataset.DatasetCode);
            }

            // Max suggestions
            if (configuration.MaxSuggestions != AddressConfiguration.DefaultMaxSuggestions)
            {
                suggestionsFormat.MaxSuggestions = configuration.MaxSuggestions;
            }

            // Layout name
            if (!string.IsNullOrEmpty(configuration.FormatLayoutName))
            {
                suggestionsFormat.Layouts = new List<string> { configuration.FormatLayoutName };
            }

            return suggestionsFormat;
        }
    }
}