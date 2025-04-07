using Newtonsoft.Json;

namespace DVSClient.Server.Address
{
    public class Address
    {
        [JsonProperty("unspecified")]
        public IEnumerable<string>? AddressLines { get; set; }

        public Address()
        {
        }

        public Address(string singleline) : this(new List<string> { singleline })
        {
        }

        public Address(List<string> lines)
        {
            AddressLines = lines;
        }
    }
}