using DVSClient.Address.Layout;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiAddressLayoutAppliesTo
    {
        [JsonProperty("country_iso")]
        public string? CountryIso { get; set; }

        [JsonProperty("datasets")]
        public IEnumerable<string>? Datasets { get; set; }

        [JsonProperty("language")]
        public string? Language { get; set; }

        [JsonProperty("script")]
        public string? Script { get; set; }

        public RestApiAddressLayoutAppliesTo() { }

        public RestApiAddressLayoutAppliesTo(AppliesTo layoutAppliesTo)
        {
            CountryIso = layoutAppliesTo.GetCountry()?.Iso3Code;
            Datasets = layoutAppliesTo.Datasets?.ToList().ConvertAll(dataset => dataset.DatasetCode);
            Language = layoutAppliesTo.Language;
            Script = layoutAppliesTo.Script;
        }
    }
}