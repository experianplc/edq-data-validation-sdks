using DVSClient.address.lookup;
using DVSClient.Common;
using DVSClient.Exceptions;
using Newtonsoft.Json;
using AddressConfiguration = DVSClient.Address.AddressConfiguration;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupV2Request
    {
        [JsonProperty("country_iso")]
        public string? CountryIso { get; set; }
        [JsonProperty("datasets")]
        public IEnumerable<string>? Datasets { get; set; }
        [JsonProperty("max_addresses")]
        public int? MaxAddresses { get; set; }
        [JsonProperty("max_suggestions")]
        public int? MaxSuggestions { get; set; }
        [JsonProperty("attributes")]
        public RestApiAddressLookupV2RequestAttribute? Attributes { get; set; }
        [JsonProperty("key")]
        public RestApiAddressLookupV2RequestKey? Key { get; set; }
        [JsonProperty("preferred_language")]
        public IEnumerable<string>? PreferredLanguage { get; set; }
        [JsonProperty("preferred_script")]
        public IEnumerable<string>? PreferredScript { get; set; }
        [JsonProperty("names")]
        public RestApiAddressLookupV2RequestNames[]? Names { get; set; }
        [JsonProperty("layouts")]
        public IEnumerable<string>? Layouts { get; set; }



        public static RestApiAddressLookupV2Request Using(string value, LookupType lookupType, AddressConfiguration configuration)
        {
            if (!configuration.Datasets.Any()) 
            {
                throw new EDVSException("No datasets have been supplied in the configuration.");
            }
            
            var result = new RestApiAddressLookupV2Request();
            
            //Key
            var key = new RestApiAddressLookupV2RequestKey();
            key.Value = value;
            key.Type = lookupType.GetJsonNameFromEnum<LookupType>();
            result.Key = key;

            result.CountryIso = configuration.Datasets.ElementAt(0).Country.Iso3Code;
            result.Datasets = configuration.Datasets.Select(dataset => dataset.DatasetCode);

            if (configuration.LookupMaxAddresses > 0) 
            {
                result.MaxAddresses = configuration.LookupMaxAddresses;
            }
            if (configuration.MaxSuggestions > 0)
            {
                result.MaxSuggestions = configuration.MaxSuggestions;
            }
            if (configuration.FormatLayoutName.Length > 0) {
                result.Layouts = new List<string> { configuration.FormatLayoutName };
            }
            
            return result;

        }
    }

}