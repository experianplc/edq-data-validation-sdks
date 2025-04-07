using DVSClient.Address.Layout;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiAddressLayoutLine
    {
        [JsonProperty("line_name")]
        public string? LineName { get; set; }

        [JsonProperty("max_width")]
        public int? MaxWidth { get; set; }

        [JsonProperty("elements")]
        public IEnumerable<RestApiAddressLayoutLineElement>? Elements { get; set; }

        public RestApiAddressLayoutLine() { }

        public RestApiAddressLayoutLine(ILayoutLine layoutLine)
        {
            LineName = layoutLine.Name;
            MaxWidth = layoutLine.MaxWidth;
            Elements = layoutLine.GetElements() != null && layoutLine.GetElements().Any()
                        ? layoutLine.GetElements().Select(e => new RestApiAddressLayoutLineElement(e)).ToList()
                        : null;
        }
    }
}
