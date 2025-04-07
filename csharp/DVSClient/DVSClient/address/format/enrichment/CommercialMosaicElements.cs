using DVSClient.Server.Address.Format;

namespace DVSClient.Address.Format.Enrichment
{
    public class CommercialMosaicElements
    {
        public string GroupTypeCode { get; }
        public string GroupTypeDescription { get; }
        public string GroupCode { get; }
        public string GroupDescription { get; }

        public CommercialMosaicElements(RestApiCommercialMosaicElements api)
        {
            GroupTypeCode = api.GroupTypeCode ?? string.Empty;
            GroupTypeDescription = api.GroupTypeDescription ?? string.Empty;
            GroupCode = api.GroupCode ?? string.Empty;
            GroupDescription = api.GroupDescription ?? string.Empty;
        }
    }
}