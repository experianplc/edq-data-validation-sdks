using DVSClient.Address.Layout;
using Newtonsoft.Json;

namespace DVSClient.Server.Address.Layout
{
    public class RestApiAddressLayout
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("comment")]
        public string? Comment { get; set; }

        [JsonProperty("applies_to")]
        public IEnumerable<RestApiAddressLayoutAppliesTo>? AppliesTo { get; set; }

        [JsonProperty("options")]
        public RestApiAddressLayoutOptions? Options { get; set; }

        [JsonProperty("lines")]
        public List<RestApiAddressLayoutLine> Lines { get; set; }

        public RestApiAddressLayout(string name, IEnumerable<AppliesTo> appliesTo, IEnumerable<LayoutLineVariable> variableLayoutLines, IEnumerable<LayoutLineFixed> fixedLayoutLines)
        {
            Name = name;
            AppliesTo = appliesTo.ToList().ConvertAll(a => new RestApiAddressLayoutAppliesTo(a));
            Lines = new List<RestApiAddressLayoutLine>();
            Lines.AddRange(variableLayoutLines.ToList().ConvertAll(l => new RestApiAddressLayoutLine(l)));
            Lines.AddRange(fixedLayoutLines.ToList().ConvertAll(l => new RestApiAddressLayoutLine(l)));
        }
    }
}