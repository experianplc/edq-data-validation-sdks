using Newtonsoft.Json;

namespace DVSClient.Server.Address.Lookup
{
    public class RestApiAddressLookupLocalityItem   
    {
        [JsonProperty("name")]
        public string? Name { get; set; } // Locality name

        [JsonProperty("code")]
        public string? Code { get; set; } // Locality code

        [JsonProperty("description")]
        public string? Description { get; set; } // Locality description

    }

}