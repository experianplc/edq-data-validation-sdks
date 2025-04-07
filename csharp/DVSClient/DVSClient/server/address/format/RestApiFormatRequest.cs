using DVSClient.Address;
using DVSClient.Server.Address.Validate;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Format
{
    public class RestApiFormatRequest
    {
        [JsonProperty("layouts")]
        public IEnumerable<string>? Layouts { get; set; }

        [JsonProperty("layout_format")]
        public string? LayoutFormat { get; set; }

        [JsonProperty("attributes")]
        public RestApiFormatAttribute? Attributes { get; set; }

        public static RestApiFormatRequest Using(Configuration configuration)
        {
            var request = new RestApiFormatRequest
            {
                Layouts = new List<string> { configuration.FormatLayoutName },
                LayoutFormat = configuration.LayoutFormat.ToString()
            };

            var attributes = RestApiAddressValidateRequest.GetFormatAttribute(configuration);
            if (attributes != null)
            {
                request.Attributes = attributes;
            }

            return request;
        }
    }
}