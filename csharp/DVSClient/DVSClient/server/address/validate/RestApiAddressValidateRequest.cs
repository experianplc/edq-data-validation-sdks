using DVSClient.Address.Layout.Attributes;
using DVSClient.Common;
using DVSClient.Server.Address.Format;
using DVSClient.Server.Address.Search;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Validate
{
    public class RestApiAddressValidateRequest
    {
        [JsonProperty("country_iso")]
        public string? CountryIso { get; set; }

        [JsonProperty("datasets")]
        public IEnumerable<string>? Datasets { get; set; }

        [JsonProperty("max_suggestions")]
        public int? MaxSuggestions { get; set; }

        [JsonProperty("components")]
        public Address? Address { get; set; }

        [JsonProperty("options")]
        public IList<RestApiAdditionalOption>? Options { get; set; }

        [JsonProperty("attributes")]
        public RestApiFormatAttribute? Attributes { get; set; }

        [JsonProperty("layouts")]
        public IEnumerable<string>? Layouts { get; set; }

        [JsonProperty("layout_format")]
        public string? LayoutFormat { get; set; }

        public static RestApiAddressValidateRequest Using(DVSClient.Address.AddressConfiguration configuration)
        {
            var validateRequest = new RestApiAddressValidateRequest();

            // Country
            if (configuration.GetCountry() != null)
            {
                validateRequest.CountryIso = configuration.GetCountry()?.Iso3Code;
            }

            // Datasets
            if (configuration.Datasets != null && configuration.Datasets.Any())
            {
                validateRequest.Datasets = configuration.Datasets.ToList().ConvertAll(dataset => dataset.DatasetCode);
            }

            // Max suggestions
            if (configuration.MaxSuggestions != DVSClient.Address.AddressConfiguration.DefaultMaxSuggestions)
            {
                validateRequest.MaxSuggestions = configuration.MaxSuggestions;
            }

            // Layout name
            if (!string.IsNullOrEmpty(configuration.FormatLayoutName))
            {
                validateRequest.Layouts = new List<string> { configuration.FormatLayoutName };
            }

            // Layout format
            if (configuration.LayoutFormat.HasValue)
            {
                validateRequest.LayoutFormat = configuration.LayoutFormat.Value.ToString();
            }

            if (configuration.FormatLayoutName != null)
            {
                validateRequest.AddOption("flatten", true.ToString());
            }

            if (configuration.SearchIntensity.HasValue)
            {
                validateRequest.AddOption("intensity", configuration.SearchIntensity.Value.ToString());
            }

            if (configuration.PromptSet.HasValue)
            {
                validateRequest.AddOption("prompt_set", configuration.PromptSet.Value.ToString());
            }

            var formatAttributes = GetFormatAttribute(configuration);
            if (formatAttributes != null)
            {
                validateRequest.Attributes = formatAttributes;
            }

            return validateRequest;
        }

        public static RestApiFormatAttribute GetFormatAttribute(DVSClient.Address.AddressConfiguration configuration)
        {
            var attributes = new RestApiFormatAttribute();

            if (configuration.GlobalGeocodes != null && configuration.GlobalGeocodes.Any())
            {
                attributes.Geocodes = configuration.GlobalGeocodes.Select(attr => attr.GetJsonNameFromEnum<GlobalGeocodeAttribute>());
            }

            if (configuration.PremiumLocationInsights != null && configuration.PremiumLocationInsights.Any())
            {
                attributes.PremiumLocationInsight = (IEnumerable<string?>?)configuration.PremiumLocationInsights.Select(attr => attr.GetJsonNameFromEnum<PremiumLocationInsightAttribute>());
            }

            if (configuration.What3Words != null && configuration.What3Words.Any())
            {
                attributes.What3words = (IEnumerable<string?>?)configuration.What3Words.Select(attr => attr.GetJsonNameFromEnum<What3WordsAttribute>());
            }

            if (configuration.GbrLocationComplete != null && configuration.GbrLocationComplete.Any())
            {
                attributes.GbrLocationComplete = (IEnumerable<string?>?)configuration.GbrLocationComplete.Select(attr => attr.GetJsonNameFromEnum<GbrLocationCompleteAttribute>());
            }

            if (configuration.GbrLocationEssential != null && configuration.GbrLocationEssential.Any())
            {
                attributes.GbrLocationEssential = (IEnumerable<string?>?)configuration.GbrLocationEssential.Select(attr => attr.GetJsonNameFromEnum<GbrLocationEssentialAttribute>());
            }

            if (configuration.GbrGovernment != null && configuration.GbrGovernment.Any())
            {
                attributes.GbrGovernment = (IEnumerable<string?>?)configuration.GbrGovernment.Select(attr => attr.GetJsonNameFromEnum<GbrGovernmentAttribute>());
            }

            if (configuration.GbrHealth != null && configuration.GbrHealth.Any())
            {
                attributes.GbrHealth = (IEnumerable<string?>?)configuration.GbrHealth.Select(attr => attr.GetJsonNameFromEnum<GbrHealthAttribute>());
            }

            if (configuration.GbrBusiness != null && configuration.GbrBusiness.Any())
            {
                attributes.GbrBusiness = (IEnumerable<string?>?)configuration.GbrBusiness.Select(attr => attr.GetJsonNameFromEnum<GbrBusinessAttribute>());
            }

            if (configuration.UsaRegionalGeocodes != null && configuration.UsaRegionalGeocodes.Any())
            {
                attributes.UsaRegionalGeocodes = (IEnumerable<string?>?)configuration.UsaRegionalGeocodes.Select(attr => attr.GetJsonNameFromEnum<UsaRegionalGeocodeAttribute>());
            }

            if (configuration.AusRegionalGeocodes != null && configuration.AusRegionalGeocodes.Any())
            {
                attributes.AusRegionalGeocodes = (IEnumerable<string?>?)configuration.AusRegionalGeocodes.Select(attr => attr.GetJsonNameFromEnum<AusRegionalGeocodeAttribute>());
            }

            if (configuration.NzlRegionalGeocodes != null && configuration.NzlRegionalGeocodes.Any())
            {
                attributes.NzlRegionalGeocodes = (IEnumerable<string?>?)configuration.NzlRegionalGeocodes.Select(attr => attr.GetJsonNameFromEnum<NzlRegionalGeocodeAttribute>());
            }

            return attributes;
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