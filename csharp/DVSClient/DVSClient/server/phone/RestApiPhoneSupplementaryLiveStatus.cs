using Newtonsoft.Json;

namespace DVSClient.Server.Phone
{
    public class RestApiPhoneSupplementaryLiveStatus
    {
        [JsonProperty("mobile")]
        public IEnumerable<string>? Mobile { get; set; }

        [JsonProperty("landline")]
        public IEnumerable<string>? Landline { get; set; }
    }
}
