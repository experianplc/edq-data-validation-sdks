using DVSClient.Address.Layout.Elements;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiAddressLayoutLineElement
    {
        [JsonProperty("element_name")]
        public string? ElementName { get; set; }

        public RestApiAddressLayoutLineElement() { }

        public RestApiAddressLayoutLineElement(IAddressElement? addressElement)
        {
            ElementName = addressElement?.GetElementName();
        }
    }
}
