using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class LocationElements
    {
        public string Code { get; }
        public string Description { get; }
        public string SmallOrHomeOffice { get; }

        public LocationElements(RestApiEnrichmentLocationElements api)
        {
            Code = api.Code ?? string.Empty;
            Description = api.Description ?? string.Empty;
            SmallOrHomeOffice = api.SmallOrHomeOffice ?? string.Empty;
        }
    }
}