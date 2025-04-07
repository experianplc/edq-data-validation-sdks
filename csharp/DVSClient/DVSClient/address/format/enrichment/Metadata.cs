using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class Metadata
    {
        public string Code { get; }
        public string Message { get; }
        public string Detail { get; }

        public Metadata(RestApiEnrichmentMetadata api)
        {
            Code = api.Code ?? string.Empty;
            Message = api.Message ?? string.Empty;
            Detail = api.Detail ?? string.Empty;
        }
    }
}